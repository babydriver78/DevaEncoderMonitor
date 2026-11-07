namespace DevaEncoderMonitor.Core;

/// <summary>
/// Supplies the target RPM for an axis over a time step.
/// </summary>
public interface IMotionProfile
{
    /// <summary>
    /// Returns the target RPM for this axis during the given time step.
    /// </summary>
    /// <param name="dtSeconds">Elapsed time since the last call, in seconds.</param>
    double GetRpm(double dtSeconds);
}

/// <summary>
/// Axis that never moves (0 RPM).
/// </summary>
public sealed class StationaryProfile : IMotionProfile
{
    public double GetRpm(double dtSeconds) => 0.0;
}

/// <summary>
/// Axis that runs at a constant RPM.
/// </summary>
public sealed class ConstantSpeedProfile : IMotionProfile
{
    private readonly double _rpm;

    public ConstantSpeedProfile(double rpm) => _rpm = rpm;

    public double GetRpm(double dtSeconds) => _rpm;
}

/// <summary>
/// Axis that ramps linearly from 0 RPM to a target over a fixed duration.
/// </summary>
public sealed class RampProfile : IMotionProfile
{
    private readonly double _targetRpm;
    private readonly double _rampSeconds;
    private double _elapsedSeconds;

    public RampProfile(double targetRpm, double rampSeconds)
    {
        _targetRpm = targetRpm;
        _rampSeconds = rampSeconds;
    }

    public double GetRpm(double dtSeconds)
    {
        _elapsedSeconds += dtSeconds;
        double t = _elapsedSeconds / _rampSeconds;
        if (t > 1.0) t = 1.0;
        if (t < 0.0) t = 0.0;
        return _targetRpm * t;
    }
}

/// <summary>
/// Deterministic motion simulator for the DEVA001's three axes.
/// <para>
/// Integrates RPM into quadrature counts (CPR = 1024, x4 => 4096 counts/rev),
/// tracks instantaneous and filtered velocity, and reports axis input bits.
/// Uses a fixed seed (<see cref="Random"/>(42)) so a given sequence of updates
/// is reproducible.
/// </para>
/// </summary>
public sealed class MotionEngine
{
    /// <summary>Number of axes on the DEVA001.</summary>
    public const int AxisCount = 3;

    /// <summary>
    /// Counts per revolution after quadrature x4 (1024 CPR * 4).
    /// </summary>
    public const int CountsPerRev = 4096;

    private const double VelFilterAlpha = 0.2;

    private readonly Random _random = new(42);
    private readonly int[] _counts = new int[AxisCount];
    private readonly int[] _lastVelInst = new int[AxisCount];
    private readonly double[] _velFilt = new double[AxisCount];
    private readonly IMotionProfile[] _profiles;

    public MotionEngine()
    {
        _profiles = new IMotionProfile[AxisCount];
        for (int axis = 0; axis < AxisCount; axis++)
        {
            _profiles[axis] = new StationaryProfile();
        }
    }

    /// <summary>Assigns a motion profile to an axis.</summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="axis"/> is not in 0..<see cref="AxisCount"/>-1.
    /// </exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="profile"/> is null.</exception>
    public void SetProfile(int axis, IMotionProfile profile)
    {
        if (profile is null)
        {
            throw new ArgumentNullException(nameof(profile));
        }

        ValidateAxis(axis);
        _profiles[axis] = profile;
    }

    /// <summary>Assigns motion profiles to all axes at once.</summary>
    public void SetProfiles(IMotionProfile[] profiles)
    {
        if (profiles is null)
        {
            throw new ArgumentNullException(nameof(profiles));
        }

        if (profiles.Length != AxisCount)
        {
            throw new ArgumentOutOfRangeException(
                nameof(profiles), profiles.Length,
                $"Expected {AxisCount} profiles.");
        }

        for (int axis = 0; axis < AxisCount; axis++)
        {
            _profiles[axis] = profiles[axis] ?? new StationaryProfile();
        }
    }

    /// <summary>
    /// Sets the raw position count for an axis (for example, zeroing via <c>AXIS_32</c>).
    /// </summary>
    public void SetPosition(int axis, int position)
    {
        ValidateAxis(axis);
        _counts[axis] = position;
    }

    /// <summary>
    /// Advances one axis by <paramref name="dtSeconds"/> seconds using its current profile.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="axis"/> is out of range or <paramref name="dtSeconds"/> is negative.
    /// </exception>
    public void UpdateAxis(int axis, double dtSeconds)
    {
        ValidateAxis(axis);

        if (dtSeconds < 0.0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dtSeconds), dtSeconds, "dtSeconds must not be negative.");
        }

        if (dtSeconds == 0.0)
        {
            return;
        }

        double rpm = _profiles[axis].GetRpm(dtSeconds);

        // RPM -> counts per second -> counts this step (quadrature x4 already applied).
        double countsPerSec = rpm / 60.0 * CountsPerRev;

        // Small deterministic dither so the fixed seed Random is exercised.
        double jitter = 1.0 + (_random.NextDouble() - 0.5) * 0.01; // +/- 0.5%
        int deltaCounts = (int)Math.Round(countsPerSec * jitter * dtSeconds);

        _counts[axis] = unchecked(_counts[axis] + deltaCounts);

        int velInst = dtSeconds > 0.0
            ? (int)Math.Round(deltaCounts / dtSeconds)
            : 0;
        _lastVelInst[axis] = velInst;

        // Exponential moving average for filtered velocity.
        _velFilt[axis] = _velFilt[axis] + VelFilterAlpha * (velInst - _velFilt[axis]);
    }

    /// <summary>Returns the raw 32-bit position count for an axis.</summary>
    public int ReadAxis(int axis)
    {
        ValidateAxis(axis);
        return _counts[axis];
    }

    /// <summary>Returns the instantaneous velocity for an axis (counts per second).</summary>
    public int GetVelInst(int axis)
    {
        ValidateAxis(axis);
        return _lastVelInst[axis];
    }

    /// <summary>Returns the filtered velocity for an axis (counts per second).</summary>
    public int GetVelFilt(int axis)
    {
        ValidateAxis(axis);
        return (int)Math.Round(_velFilt[axis]);
    }

    /// <summary>Instantaneous acceleration (deferred; returns 0).</summary>
    public int GetAccelInst(int axis)
    {
        ValidateAxis(axis);
        return 0;
    }

    /// <summary>Filtered acceleration (deferred; returns 0).</summary>
    public int GetAccelFilt(int axis)
    {
        ValidateAxis(axis);
        return 0;
    }

    /// <summary>Marker/index position (deferred; returns 0).</summary>
    public int GetMarker(int axis)
    {
        ValidateAxis(axis);
        return 0;
    }

    /// <summary>
    /// Returns the axis input bits.
    /// <para>
    /// Bit0 = A high (CW motion), Bit1 = B high (CCW motion).
    /// </para>
    /// </summary>
    public int GetAxisInputs(int axis)
    {
        ValidateAxis(axis);

        int inputs = 0;
        int vel = _lastVelInst[axis];
        if (vel > 0)
        {
            inputs |= 0x0001; // A high -> clockwise
        }
        else if (vel < 0)
        {
            inputs |= 0x0002; // B high -> counter-clockwise
        }

        return inputs;
    }

    /// <summary>Returns the direction of motion for an axis.</summary>
    public Direction GetDirection(int axis)
    {
        ValidateAxis(axis);
        int vel = _lastVelInst[axis];
        return vel switch
        {
            > 0 => Direction.Forward,
            < 0 => Direction.Reverse,
            _ => Direction.None
        };
    }

    /// <summary>Builds a full <see cref="PositionSnapshot"/> for an axis.</summary>
    public PositionSnapshot GetSnapshot(int axis)
    {
        ValidateAxis(axis);

        int counts = _counts[axis];
        int velInst = _lastVelInst[axis];

        return new PositionSnapshot
        {
            Axis = axis,
            Counts = counts,
            Rpm = EncoderMath.CountsPerSecToRpm(velInst, CountsPerRev),
            VelInst = velInst,
            VelFilt = GetVelFilt(axis),
            AccelInst = GetAccelInst(axis),
            AccelFilt = GetAccelFilt(axis),
            Inputs = GetAxisInputs(axis),
            Status = 0, // nominal; no faults simulated in Phase 1
            Direction = GetDirection(axis),
            TimestampUtc = DateTimeOffset.UtcNow
        };
    }

    private void ValidateAxis(int axis)
    {
        if (axis < 0 || axis >= AxisCount)
        {
            throw new ArgumentOutOfRangeException(
                nameof(axis), axis, $"Valid axis is 0..{AxisCount - 1}.");
        }
    }
}
