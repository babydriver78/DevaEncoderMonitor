namespace DevaEncoderMonitor.Core;

/// <summary>Direction of axis motion.</summary>
public enum Direction
{
    None,
    Forward,
    Reverse,
}

/// <summary>
/// A single snapshot of one encoder axis at a point in time.
/// </summary>
public record PositionSnapshot
{
    /// <summary>Axis index (0-based).</summary>
    public int Axis { get; init; }

    /// <summary>Raw 32-bit position count (quadrature x4).</summary>
    public int Counts { get; init; }

    /// <summary>Current speed in revolutions per minute.</summary>
    public double Rpm { get; init; }

    /// <summary>Instantaneous velocity (counts per second).</summary>
    public int VelInst { get; init; }

    /// <summary>Filtered velocity (counts per second).</summary>
    public int VelFilt { get; init; }

    /// <summary>Instantaneous acceleration (counts per second squared).</summary>
    public int AccelInst { get; init; }

    /// <summary>Filtered acceleration (counts per second squared).</summary>
    public int AccelFilt { get; init; }

    /// <summary>Axis input bits: bit0 = A high (CW), bit1 = B high (CCW).</summary>
    public int Inputs { get; init; }

    /// <summary>Axis status bits (nominal = 0 in the simulator).</summary>
    public int Status { get; init; }

    /// <summary>Direction of motion.</summary>
    public Direction Direction { get; init; }

    /// <summary>Time the snapshot was taken (UTC).</summary>
    public DateTimeOffset TimestampUtc { get; init; }
}
