using DevaEncoderMonitor.Core;
using Xunit;

namespace DevaEncoderMonitor.Tests;

public class MotionEngineTests
{
    [Fact]
    public void ConstantSpeed_IsDeterministic()
    {
        // Two engines with the same fixed seed must produce identical results.
        var engine1 = new MotionEngine();
        var engine2 = new MotionEngine();
        engine1.SetProfile(0, new ConstantSpeedProfile(60.0));
        engine2.SetProfile(0, new ConstantSpeedProfile(60.0));

        for (int i = 0; i < 10; i++)
        {
            engine1.UpdateAxis(0, 0.1);
            engine2.UpdateAxis(0, 0.1);
        }

        Assert.Equal(engine1.ReadAxis(0), engine2.ReadAxis(0));
        Assert.Equal(engine1.GetVelInst(0), engine2.GetVelInst(0));
    }

    [Fact]
    public void ConstantSpeed_MovesInExpectedDirection()
    {
        var engine = new MotionEngine();
        engine.SetProfile(0, new ConstantSpeedProfile(60.0));
        engine.UpdateAxis(0, 1.0);

        // 60 RPM = 1 rev/sec = 4096 counts/sec (CPR 1024 * x4).
        int counts = engine.ReadAxis(0);
        Assert.InRange(counts, 4096 - 100, 4096 + 100);
        Assert.Equal(Direction.Forward, engine.GetDirection(0));
        Assert.True(engine.GetVelInst(0) > 0);
    }

    [Fact]
    public void Stationary_StaysZero()
    {
        var engine = new MotionEngine();
        engine.SetProfile(0, new StationaryProfile());

        for (int i = 0; i < 10; i++)
        {
            engine.UpdateAxis(0, 1.0);
        }

        Assert.Equal(0, engine.ReadAxis(0));
        Assert.Equal(0, engine.GetVelInst(0));
        Assert.Equal(0, engine.GetVelFilt(0));
        Assert.Equal(Direction.None, engine.GetDirection(0));
    }

    [Fact]
    public void Reverse_FlipsSign()
    {
        var engine = new MotionEngine();
        engine.SetProfile(0, new ConstantSpeedProfile(-60.0));
        engine.UpdateAxis(0, 1.0);

        int counts = engine.ReadAxis(0);
        Assert.InRange(counts, -4096 - 100, -4096 + 100);
        Assert.Equal(Direction.Reverse, engine.GetDirection(0));
        Assert.True(engine.GetVelInst(0) < 0);
        // Bit1 (B high) should be set for counter-clockwise motion.
        Assert.Equal(0x0002, engine.GetAxisInputs(0) & 0x0002);
    }

    [Fact]
    public void InvalidAxis_Throws()
    {
        var engine = new MotionEngine();
        Assert.Throws<ArgumentOutOfRangeException>(() => engine.UpdateAxis(3, 0.1));
        Assert.Throws<ArgumentOutOfRangeException>(() => engine.UpdateAxis(-1, 0.1));
        Assert.Throws<ArgumentOutOfRangeException>(() => engine.ReadAxis(3));
        Assert.Throws<ArgumentOutOfRangeException>(() => engine.ReadAxis(-1));
    }
}
