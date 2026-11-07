namespace DevaEncoderMonitor.Core;

/// <summary>
/// Pure helper for converting between encoder counts and RPM.
/// </summary>
public static class EncoderMath
{
    /// <summary>
    /// Converts counts-per-second to revolutions per minute (RPM).
    /// </summary>
    /// <param name="countsPerSec">
    /// Encoder counts per second, already quadrature-multiplied (x4).
    /// </param>
    /// <param name="countsPerRev">
    /// Counts per revolution of the encoder disk. Defaults to 1024 for the DEVA001,
    /// which with quadrature x4 becomes 4096 counts per revolution.
    /// </param>
    /// <returns>Speed in revolutions per minute.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="countsPerRev"/> is not positive.
    /// </exception>
    public static double CountsPerSecToRpm(double countsPerSec, int countsPerRev = 1024)
    {
        if (countsPerRev <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(countsPerRev), countsPerRev, "countsPerRev must be positive.");
        }

        return countsPerSec / countsPerRev * 60.0;
    }

    /// <summary>
    /// Computes the signed delta between two 32-bit counter values, handling wrap-around.
    /// <para>
    /// Because the operation is performed in an <c>unchecked</c> context, the result is the
    /// two's-complement difference, which correctly accounts for a counter wrapping from
    /// <see cref="int.MaxValue"/> to <see cref="int.MinValue"/> (or vice versa).
    /// </para>
    /// </summary>
    /// <param name="previous">The previous counter value.</param>
    /// <param name="current">The current counter value.</param>
    /// <returns>The signed delta from <paramref name="previous"/> to <paramref name="current"/>.</returns>
    public static int Delta32(int previous, int current)
    {
        unchecked
        {
            return current - previous;
        }
    }
}
