namespace DevaEncoderMonitor.App;

using System.Collections.Concurrent;
using DevaEncoderMonitor.Core;

/// <summary>
/// Background polling service for the DEVA001 encoder simulator.
/// <para>
/// Runs a polling loop on a background <see cref="Task"/>, reads all three axes
/// from the simulated enclib, and publishes the latest <see cref="PositionSnapshot"/>
/// per axis. The UI never calls the enclib directly; it only reads snapshots
/// from this service, which keeps the UI thread responsive.
/// </para>
/// </summary>
public sealed class EncoderService : IDisposable
{
    /// <summary>Simulated time advanced per poll tick (10 ms).</summary>
    private const double PollIntervalSeconds = 0.01;

    /// <summary>Number of DEVA001 axes.</summary>
    private const int AxisCount = MotionEngine.AxisCount;

    /// <summary>The simulated enclib (shared singleton).</summary>
    private readonly IEnclib _enc = SimulatedEnclib.Instance;

    private readonly object _lock = new();
    private readonly ConcurrentDictionary<short, PositionSnapshot> _snapshots = new();
    private readonly int[] _lastCounts = new int[AxisCount];
    private readonly int[] _zeroOffsets = new int[AxisCount];
    private readonly bool[] _initialized = new bool[AxisCount];

    private CancellationTokenSource? _cts;
    private Task? _pollTask;
    private int _countsPerRev = MotionEngine.CountsPerRev; // CPR 1024 * quadrature x4
    private string _encoderMode = "QUADx4AB";
    private bool _running;

    /// <summary>True while the polling loop is running.</summary>
    public bool IsRunning
    {
        get { lock (_lock) { return _running; } }
    }

    /// <summary>True if the simulated device is open.</summary>
    public bool IsOpen => _enc.IsOpen;

    /// <summary>
    /// Counts per revolution used for RPM (CPR * 4). Defaults to 4096 (CPR 1024).
    /// </summary>
    public int CountsPerRev
    {
        get => _countsPerRev;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "countsPerRev must be positive.");
            }

            _countsPerRev = value;
        }
    }

    /// <summary>Latest encoder mode text (for example "QUADx4AB").</summary>
    public string EncoderMode
    {
        get { lock (_lock) { return _encoderMode; } }
    }

    /// <summary>
    /// Opens the device and starts the background polling loop.
    /// </summary>
    /// <param name="countsPerRev">Counts per revolution (CPR * 4).</param>
    public void Start(int countsPerRev = MotionEngine.CountsPerRev)
    {
        lock (_lock)
        {
            if (_running)
            {
                return;
            }

            _cts = new CancellationTokenSource();
            _countsPerRev = countsPerRev;
            Array.Clear(_lastCounts, 0, _lastCounts.Length);
            Array.Clear(_zeroOffsets, 0, _zeroOffsets.Length);
            Array.Clear(_initialized, 0, _initialized.Length);
            _running = true;
        }

        _pollTask = Task.Run(() => PollLoop(_cts!.Token));
    }

    /// <summary>
    /// Signals the loop to cancel, awaits its exit, then closes the device.
    /// </summary>
    public async Task Stop(CancellationToken cancellationToken = default)
    {
        CancellationTokenSource? cts;
        Task? pollTask;
        lock (_lock)
        {
            if (!_running)
            {
                return;
            }

            cts = _cts;
            pollTask = _pollTask;
        }

        cts?.Cancel();

        if (pollTask is not null)
        {
            try
            {
                await pollTask.ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Expected on cancellation.
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Poll loop faulted: {ex}");
            }
        }

        lock (_lock)
        {
            _cts = null;
            _pollTask = null;
            _running = false;
        }
    }

    /// <summary>
    /// Returns the latest snapshot for <paramref name="axis"/>, or null if none has been captured yet.
    /// </summary>
    public PositionSnapshot? GetSnapshot(short axis)
    {
        return _snapshots.TryGetValue(axis, out var snapshot) ? snapshot : null;
    }

    /// <summary>
    /// Zeros the display for <paramref name="axis"/> by capturing the current raw
    /// counts as the app-layer offset. Displayed position becomes raw - offset.
    /// </summary>
    public void ZeroAxis(short axis)
    {
        int currentCounts;
        lock (_lock)
        {
            currentCounts = _snapshots.TryGetValue(axis, out var snapshot)
                ? snapshot.Counts
                : 0;
            _zeroOffsets[axis] = currentCounts;
        }
    }

    /// <summary>Returns the app-layer zero offset for <paramref name="axis"/>.</summary>
    public int GetZeroOffset(short axis)
    {
        lock (_lock) { return _zeroOffsets[axis]; }
    }

    /// <summary>Releases the service and stops polling if it is running.</summary>
    public void Dispose()
    {
        try
        {
            // Cancel and let the poll task observe cancellation on its own.
            // Do not await here: blocking on an async Task from Dispose can deadlock
            // if the caller holds the UI synchronization context.
            _cts?.Cancel();
        }
        catch
        {
            // Best-effort cleanup during disposal.
        }

        _cts?.Dispose();
        GC.SuppressFinalize(this);
    }

    private async Task PollLoop(CancellationToken token)
    {
        try
        {
            _enc.OpenEncoder();

            while (!token.IsCancellationRequested)
            {
                // Advance the simulator by one tick (10 ms of simulated motion).
                // Tick lives on SimulatedEnclib; the field stays typed as IEnclib per design.
                ((SimulatedEnclib)_enc).Tick(PollIntervalSeconds);

                for (short axis = 0; axis < AxisCount; axis++)
                {
                    int counts = (int)_enc.ReadEncoder(EnclibCmd.AXIS_32, axis);
                    int velInst = (int)_enc.ReadEncoder(EnclibCmd.VEL_INST, axis);
                    int velFilt = (int)_enc.ReadEncoder(EnclibCmd.VEL_FILT, axis);
                    int inputs = (int)_enc.ReadEncoder(EnclibCmd.AXIS_INPUTS, axis);
                    int status = (int)_enc.ReadEncoder(EnclibCmd.AXIS_STATUS, axis);
                    int encoderMode = (int)_enc.ReadEncoder(EnclibCmd.ENCODER_MODE, axis);

                    // Delta from the last polled count; first poll reports zero delta.
                    int delta = _initialized[axis]
                        ? EncoderMath.Delta32(_lastCounts[axis], counts)
                        : 0;
                    _lastCounts[axis] = counts;
                    _initialized[axis] = true;

                    // deltaCounts / dt = counts per second; CPR * 4 = counts per rev.
                    double countsPerSec = delta / PollIntervalSeconds;
                    double rpm = EncoderMath.CountsPerSecToRpm(countsPerSec, _countsPerRev);

                    Direction direction = delta switch
                    {
                        > 0 => Direction.Forward,
                        < 0 => Direction.Reverse,
                        _ => Direction.None
                    };

                    var snapshot = new PositionSnapshot
                    {
                        Axis = axis,
                        Counts = counts,
                        Rpm = rpm,
                        VelInst = velInst,
                        VelFilt = velFilt,
                        Inputs = inputs,
                        Status = status,
                        Direction = direction,
                        TimestampUtc = DateTimeOffset.UtcNow
                    };
                    _snapshots[axis] = snapshot;

                    lock (_lock) { _encoderMode = ModeText(encoderMode); }
                }

                // Pace the loop so it does not hot-spin between ticks.
                await Task.Delay(10, token).ConfigureAwait(false);
            }
        }
        catch (OperationCanceledException)
        {
            // Expected on Stop().
        }
        finally
        {
            _enc.CloseEncoder();
            lock (_lock) { _running = false; }
        }
    }

    private static string ModeText(int mode) => mode switch
    {
        5 => "QUADx4AB",
        var m => m.ToString()
    };
}
