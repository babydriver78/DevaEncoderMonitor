using DevaEncoderMonitor.Core;
using Xunit;

namespace DevaEncoderMonitor.Tests;

public class EncoderMathTests
{
    [Fact]
    public void CountsPerSecToRpm_60RpmAtCpr1024_Returns60()
    {
        // 60 RPM = 1 rev/sec. At CPR 1024 that is 1024 counts/sec.
        double rpm = EncoderMath.CountsPerSecToRpm(1024, 1024);
        Assert.Equal(60.0, rpm);
    }

    [Fact]
    public void CountsPerSecToRpm_X4CountsPerRev_Returns60()
    {
        // MotionEngine integrates with 4096 counts/rev (1024 CPR * quadrature x4).
        // 4096 counts/sec at 4096 counts/rev = 60 RPM.
        double rpm = EncoderMath.CountsPerSecToRpm(4096, 4096);
        Assert.Equal(60.0, rpm);
    }

    [Fact]
    public void CountsPerSecToRpm_InvalidCountsPerRev_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => EncoderMath.CountsPerSecToRpm(100, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => EncoderMath.CountsPerSecToRpm(100, -5));
    }

    [Fact]
    public void Delta32_NoWrap_ReturnsSimpleDifference()
    {
        Assert.Equal(100, EncoderMath.Delta32(1000, 1100));
        Assert.Equal(-50, EncoderMath.Delta32(1000, 950));
    }

    [Fact]
    public void Delta32_WrapAround_ReturnsCorrectDelta()
    {
        // One increment past int.MaxValue wraps to int.MinValue: delta = 1.
        Assert.Equal(1, EncoderMath.Delta32(int.MaxValue, int.MinValue));

        // Two increments past the top: delta = 2.
        Assert.Equal(2, EncoderMath.Delta32(int.MaxValue - 1, int.MinValue));

        // Wrapping the other way.
        Assert.Equal(-1, EncoderMath.Delta32(int.MinValue, int.MaxValue));
    }
}
