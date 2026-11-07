namespace DevaEncoderMonitor.Core;

/// <summary>
/// Command IDs for the DEVA001 encoder interface (datasheet §3.2).
/// <para>
/// This is the MVP subset only. It mirrors the real <c>Deva.Enclib</c> <c>COMMANDS</c> enum
/// found in the vendor <c>ENCLIB.H</c>, so a real-driver swap later is mechanical.
/// </para>
/// </summary>
public enum EnclibCmd : short
{
    /// <summary>Number of axes on the board.</summary>
    NUM_AXES = 1,
    /// <summary>Number of boards present.</summary>
    NUM_BOARDS = 7,
    /// <summary>Card type identifier (0x00DE in the simulator).</summary>
    CARD_TYPE = 8,
    /// <summary>
    /// Firmware version encoded as major * 100 + minor (for example, 350 = 3.50).
    /// </summary>
    VERSION_NUM = 9,
    /// <summary>Encoder mode (see <c>exMODES</c>; QUADx4AB = 5).</summary>
    ENCODER_MODE = 11,
    /// <summary>Size, in bytes, of each axis data element.</summary>
    AXIS_SIZE = 12,
    /// <summary>Encoder type (0 = incremental).</summary>
    ENCODER_TYPE = 13,
    /// <summary>Axis input bits (A, B, marker, index, limits).</summary>
    AXIS_INPUTS = 14,
    /// <summary>Axis status bits.</summary>
    AXIS_STATUS = 15,
    /// <summary>32-bit incremental position counter for an axis.</summary>
    AXIS_32 = 40,
    /// <summary>32-bit marker (index) position.</summary>
    MARK_32 = 41,
    /// <summary>Instantaneous velocity (counts per second).</summary>
    VEL_INST = 42,
    /// <summary>Filtered velocity (counts per second).</summary>
    VEL_FILT = 43,
    /// <summary>Instantaneous acceleration.</summary>
    ACCEL_INST = 44,
    /// <summary>Filtered acceleration.</summary>
    ACCEL_FILT = 45,
    /// <summary>32-bit probe position.</summary>
    PROBE_32 = 46,
    /// <summary>32-bit absolute position.</summary>
    ABSOLUTE_32 = 47,
}
