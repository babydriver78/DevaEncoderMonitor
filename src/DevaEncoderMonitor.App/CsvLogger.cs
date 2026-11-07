namespace DevaEncoderMonitor.App;

using System.Globalization;
using DevaEncoderMonitor.Core;

/// <summary>Timestamped CSV export for encoder snapshots.</summary>
public static class CsvLogger
{
    /// <summary>Exports one row per snapshot to a CSV file.</summary>
    /// <param name="snapshots">Snapshots to export.</param>
    /// <param name="path">
    /// Full output file path. The containing directory is created if it is missing.
    /// </param>
    public static void Export(List<PositionSnapshot> snapshots, string path)
    {
        ArgumentNullException.ThrowIfNull(snapshots);
        ArgumentNullException.ThrowIfNull(path);

        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        using var writer = new StreamWriter(path, append: false);

        writer.WriteLine("TimestampUtc,Axis,Counts,Rpm,VelInst,VelFilt,Inputs,Status,Direction");

        foreach (PositionSnapshot snapshot in snapshots)
        {
            writer.WriteLine(CsvRow(snapshot));
        }
    }

    private static string CsvRow(PositionSnapshot snapshot) =>
        string.Join(
            ",",
            snapshot.TimestampUtc.ToString("o"),
            snapshot.Axis,
            snapshot.Counts,
            snapshot.Rpm.ToString("F3", CultureInfo.InvariantCulture),
            snapshot.VelInst,
            snapshot.VelFilt,
            snapshot.Inputs,
            snapshot.Status,
            snapshot.Direction);
}
