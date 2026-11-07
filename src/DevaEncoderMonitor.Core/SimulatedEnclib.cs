namespace DevaEncoderMonitor.Core;

/// <summary>
/// Thread-safe simulator that implements <see cref="IEnclib"/> for the DEVA001.
/// <para>
/// This is a singleton (<see cref="Lazy{T}"/>) so the polling service and any other
/// component share one simulated card. All reads/writes go through a single lock.
/// </para>
/// </summary>
public sealed class SimulatedEnclib : IEnclib
{
    private static readonly Lazy<SimulatedEnclib> _instance =
        new(() => new SimulatedEnclib(), isThreadSafe: true);

    /// <summary>The shared simulated card instance.</summary>
    public static SimulatedEnclib Instance => _instance.Value;

    private readonly object _lock = new();
    private readonly MotionEngine _engine = new();
    private readonly IMotionProfile[] _profiles;
    private bool _isOpen;

    private SimulatedEnclib()
    {
        _profiles = new IMotionProfile[MotionEngine.AxisCount];
        for (int axis = 0; axis < _profiles.Length; axis++)
        {
            _profiles[axis] = new StationaryProfile();
        }
    }

    /// <summary>
    /// Opens the simulated encoder device. Idempotent: returns 0 if already open.
    /// </summary>
    /// <returns>0 on success.</returns>
    public short OpenEncoder()
    {
        lock (_lock)
        {
            if (_isOpen)
            {
                return 0;
            }

            _isOpen = true;

            // Demo profile: Axis 0 spins at 60 RPM CW so the DRO shows live values immediately.
            _profiles[0] = new ConstantSpeedProfile(60);
            _engine.SetProfile(0, _profiles[0]);

            return 0;
        }
    }

    /// <summary>
    /// Closes the simulated encoder device. Pauses all axis motion.
    /// </summary>
    public void CloseEncoder()
    {
        lock (_lock)
        {
            // Pause motion by putting every axis on a stationary profile.
            for (int axis = 0; axis < _profiles.Length; axis++)
            {
                _profiles[axis] = new StationaryProfile();
            }

            _engine.SetProfiles(_profiles);
            _isOpen = false;
        }
    }

    /// <summary>True if the device is currently open.</summary>
    public bool IsOpen
    {
        get
        {
            lock (_lock)
            {
                return _isOpen;
            }
        }
    }

    /// <summary>Reads a 32-bit encoder value for the given command and channel.</summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="command"/> or <paramref name="channel"/> is invalid.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the device is not open.
    /// </exception>
    public long ReadEncoder(EnclibCmd command, short channel)
    {
        ValidateChannel(channel);
        ValidateCommand(command);

        lock (_lock)
        {
            if (!_isOpen)
            {
                throw new InvalidOperationException("The encoder device is not open.");
            }

            return ReadLocked(command, channel);
        }
    }

    /// <summary>Writes a 32-bit value to the encoder for the given command and channel.</summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="command"/> or <paramref name="channel"/> is invalid.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the device is not open.
    /// </exception>
    public void WriteEncoder(EnclibCmd command, short channel, long value)
    {
        ValidateChannel(channel);
        ValidateCommand(command);

        lock (_lock)
        {
            if (!_isOpen)
            {
                throw new InvalidOperationException("The encoder device is not open.");
            }

            WriteLocked(command, channel, value);
        }
    }

    /// <summary>
    /// Advances the simulator for every axis.
    /// <para>Called by the polling service. Motion is paused after <see cref="CloseEncoder"/>.</para>
    /// </summary>
    /// <param name="dtSeconds">Elapsed time in seconds since the last tick.</param>
    public void Tick(double dtSeconds)
    {
        lock (_lock)
        {
            for (int axis = 0; axis < MotionEngine.AxisCount; axis++)
            {
                _engine.UpdateAxis(axis, dtSeconds);
            }
        }
    }

    /// <summary>
    /// Assigns a motion profile to an axis.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="axis"/> is out of range.
    /// </exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="profile"/> is null.</exception>
    public void SetProfile(int axis, IMotionProfile profile)
    {
        if (profile is null)
        {
            throw new ArgumentNullException(nameof(profile));
        }

        if (axis < 0 || axis >= MotionEngine.AxisCount)
        {
            throw new ArgumentOutOfRangeException(
                nameof(axis), axis, $"Valid axis is 0..{MotionEngine.AxisCount - 1}.");
        }

        lock (_lock)
        {
            _profiles[axis] = profile;
            _engine.SetProfile(axis, profile);
        }
    }

    private long ReadLocked(EnclibCmd command, short channel)
    {
        int axis = channel;

        return command switch
        {
            EnclibCmd.NUM_AXES => MotionEngine.AxisCount,
            EnclibCmd.NUM_BOARDS => 1,
            EnclibCmd.CARD_TYPE => 0x00DE, // sim-only opaque card type
            EnclibCmd.VERSION_NUM => 350, // 3.50
            EnclibCmd.AXIS_SIZE => 2,
            EnclibCmd.ENCODER_TYPE => 0, // incremental
            EnclibCmd.ENCODER_MODE => 5, // QUADx4AB default
            EnclibCmd.AXIS_32 => _engine.ReadAxis(axis),
            EnclibCmd.VEL_INST => _engine.GetVelInst(axis),
            EnclibCmd.VEL_FILT => _engine.GetVelFilt(axis),
            EnclibCmd.AXIS_INPUTS => _engine.GetAxisInputs(axis),
            EnclibCmd.AXIS_STATUS => 0, // nominal; no faults simulated
            EnclibCmd.ACCEL_INST => 0, // deferred
            EnclibCmd.ACCEL_FILT => 0, // deferred
            EnclibCmd.MARK_32 => 0, // deferred
            EnclibCmd.PROBE_32 => 0, // deferred
            EnclibCmd.ABSOLUTE_32 => 0, // deferred
            _ => throw new ArgumentOutOfRangeException(
                nameof(command), command, "Command is not supported in the MVP subset.")
        };
    }

    private void WriteLocked(EnclibCmd command, short channel, long value)
    {
        int axis = channel;

        // In Phase 1 only the position register is writable (e.g. zeroing an axis).
        if (command == EnclibCmd.AXIS_32)
        {
            _engine.SetPosition(axis, (int)value);
        }
        // All other write commands are accepted but not simulated yet.
    }

    private void ValidateChannel(short channel)
    {
        if (channel < 0 || channel >= MotionEngine.AxisCount)
        {
            throw new ArgumentOutOfRangeException(
                nameof(channel), channel,
                $"Valid channel is 0..{MotionEngine.AxisCount - 1}.");
        }
    }

    private void ValidateCommand(EnclibCmd command)
    {
        if (!Enum.IsDefined(typeof(EnclibCmd), command))
        {
            throw new ArgumentOutOfRangeException(
                nameof(command), command, "Command is not defined in EnclibCmd.");
        }
    }
}
