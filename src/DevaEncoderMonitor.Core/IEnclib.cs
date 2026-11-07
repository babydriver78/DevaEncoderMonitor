namespace DevaEncoderMonitor.Core;

/// <summary>
/// Abstraction over the Deva.Enclib native driver so the rest of the application
/// stays card-agnostic.
/// <para>
/// When the real PCIe card arrives, bring-up is a one-file swap: implement this
/// interface against <c>enclib32.dll</c>/<c>enclib64.dll</c> and plug it in.
/// </para>
/// </summary>
public interface IEnclib
{
    /// <summary>Opens the encoder device. Returns 0 on success.</summary>
    short OpenEncoder();

    /// <summary>Closes the encoder device.</summary>
    void CloseEncoder();

    /// <summary>
    /// Reads a 32-bit encoder value for the given command and channel.
    /// </summary>
    /// <param name="command">The encoder command to read.</param>
    /// <param name="channel">The axis/board channel (0-based).</param>
    /// <returns>The 32-bit value returned by the card.</returns>
    long ReadEncoder(EnclibCmd command, short channel);

    /// <summary>
    /// Writes a 32-bit value to the encoder for the given command and channel.
    /// </summary>
    /// <param name="command">The encoder command to write.</param>
    /// <param name="channel">The axis/board channel (0-based).</param>
    /// <param name="value">The 32-bit value to write.</param>
    void WriteEncoder(EnclibCmd command, short channel, long value);

    /// <summary>True if the device is currently open.</summary>
    bool IsOpen { get; }
}
