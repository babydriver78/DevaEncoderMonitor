using DevaEncoderMonitor.Core;
using Xunit;

namespace DevaEncoderMonitor.Tests;

public class SimulatedEnclibTests
{
    [Fact]
    public void OpenEncoder_IsIdempotent()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();

        short first = lib.OpenEncoder();
        short second = lib.OpenEncoder();

        Assert.Equal((short)0, first);
        Assert.Equal((short)0, second);
        Assert.True(lib.IsOpen);

        lib.CloseEncoder();
    }

    [Fact]
    public void NumAxes_ReturnsThree()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();
        lib.OpenEncoder();

        Assert.Equal(3, lib.ReadEncoder(EnclibCmd.NUM_AXES, 0));

        lib.CloseEncoder();
    }

    [Fact]
    public void ReadEncoder_WhenNotOpen_Throws()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();

        Assert.Throws<InvalidOperationException>(
            () => lib.ReadEncoder(EnclibCmd.NUM_AXES, 0));
    }

    [Fact]
    public void ReadEncoder_InvalidChannel_Throws()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();
        lib.OpenEncoder();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => lib.ReadEncoder(EnclibCmd.NUM_AXES, 3));
        Assert.Throws<ArgumentOutOfRangeException>(
            () => lib.ReadEncoder(EnclibCmd.NUM_AXES, -1));

        lib.CloseEncoder();
    }

    [Fact]
    public void ReadEncoder_ReturnsDocumentedConstants()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();
        lib.OpenEncoder();

        Assert.Equal(1, lib.ReadEncoder(EnclibCmd.NUM_BOARDS, 0));
        Assert.Equal(0x00DE, lib.ReadEncoder(EnclibCmd.CARD_TYPE, 0));
        Assert.Equal(350, lib.ReadEncoder(EnclibCmd.VERSION_NUM, 0)); // 3.50
        Assert.Equal(2, lib.ReadEncoder(EnclibCmd.AXIS_SIZE, 0));
        Assert.Equal(0, lib.ReadEncoder(EnclibCmd.ENCODER_TYPE, 0)); // incremental
        Assert.Equal(5, lib.ReadEncoder(EnclibCmd.ENCODER_MODE, 0)); // QUADx4AB

        lib.CloseEncoder();
    }

    [Fact]
    public void Axis32_ReturnsLivePosition()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();
        lib.OpenEncoder();

        int before = (int)lib.ReadEncoder(EnclibCmd.AXIS_32, 0); // stationary by default

        lib.SetProfile(0, new ConstantSpeedProfile(60.0));
        lib.Tick(1.0);

        int after = (int)lib.ReadEncoder(EnclibCmd.AXIS_32, 0);
        int delta = after - before;

        // 60 RPM should produce roughly 4096 counts in one second.
        Assert.InRange(delta, 4096 - 100, 4096 + 100);

        lib.CloseEncoder();
    }

    [Fact]
    public void CloseEncoder_PausesMotion()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();
        lib.OpenEncoder();

        lib.SetProfile(0, new ConstantSpeedProfile(60.0));
        lib.Tick(1.0);
        int before = (int)lib.ReadEncoder(EnclibCmd.AXIS_32, 0);

        lib.CloseEncoder(); // pauses motion

        // Reopen to read; profiles are still stationary so the position must not change.
        lib.OpenEncoder();
        lib.Tick(5.0);
        int after = (int)lib.ReadEncoder(EnclibCmd.AXIS_32, 0);

        Assert.Equal(before, after);

        lib.CloseEncoder();
    }

    [Fact]
    public void SetProfile_Null_Throws()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();
        lib.OpenEncoder();

        Assert.Throws<ArgumentNullException>(
            () => lib.SetProfile(0, null!));

        lib.CloseEncoder();
    }

    [Fact]
    public void SetProfile_InvalidAxis_Throws()
    {
        var lib = SimulatedEnclib.Instance;
        lib.CloseEncoder();
        lib.OpenEncoder();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => lib.SetProfile(3, new StationaryProfile()));

        lib.CloseEncoder();
    }
}
