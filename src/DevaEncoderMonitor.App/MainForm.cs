namespace DevaEncoderMonitor.App;

using DevaEncoderMonitor.Core;

public partial class MainForm : Form
{
    private readonly EncoderService _encoderService = new();
    private readonly System.Windows.Forms.Timer _uiTimer = new();
    private const int CprDefault = 1024;
    private const int AxisCount = MotionEngine.AxisCount;
    private bool _isPolling;

    public MainForm()
    {
        InitializeComponent();

        txtCpr.Text = CprDefault.ToString();
        UpdateStartStopButton();
        UpdateStatusStrip();

        // UI refresh timer: 50 ms. Never blocks; only reads snapshots from the service.
        _uiTimer.Interval = 50;
        _uiTimer.Tick += UiTimer_Tick;
        _uiTimer.Start();

        btnStartStop.Click += BtnStartStop_Click;
        btnExport.Click += BtnExport_Click;
        btnZero0.Click += (_, _) => ZeroAxis(0);
        btnZero1.Click += (_, _) => ZeroAxis(1);
        btnZero2.Click += (_, _) => ZeroAxis(2);

        FormClosed += (_, _) =>
        {
            _uiTimer.Stop();
            _encoderService.Stop().GetAwaiter().GetResult(); // best-effort cleanup on close
        };
    }

    private void UiTimer_Tick(object? sender, EventArgs e)
    {
        // Refresh all axis readouts from the latest snapshots. This runs on the UI thread
        // but only reads in-memory data, so it never blocks.
        UpdateAxisDisplay(0);
        UpdateAxisDisplay(1);
        UpdateAxisDisplay(2);

        bool running = _encoderService.IsRunning;
        lblOpenState.Text = running ? "Open" : "Closed";
        lblOpenState.ForeColor = running ? Color.Green : Color.Red;

        UpdateStatusStrip();
    }

    private async void BtnStartStop_Click(object? sender, EventArgs e)
    {
        if (_isPolling)
        {
            // Disable during Stop to prevent double-click races while Stop() awaits.
            btnStartStop.Enabled = false;
            try
            {
                await _encoderService.Stop();
            }
            finally
            {
                _isPolling = false;
                btnStartStop.Enabled = true;
                UpdateStartStopButton();
                UpdateStatusStrip();
            }
        }
        else
        {
            if (!int.TryParse(txtCpr.Text, out int cpr) || cpr <= 0)
            {
                MessageBox.Show(
                    this,
                    "Enter a valid positive Counts Per Rev (CPR).",
                    "Invalid CPR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // countsPerRev = CPR * quadrature x4.
            _encoderService.Start(cpr * 4);
            _isPolling = true;
            UpdateStartStopButton();
            UpdateStatusStrip();
        }
    }

    private void BtnExport_Click(object? sender, EventArgs e)
    {
        var snapshots = new List<PositionSnapshot>(AxisCount);
        for (int axis = 0; axis < AxisCount; axis++)
        {
            PositionSnapshot? snapshot = _encoderService.GetSnapshot((short)axis);
            if (snapshot is not null)
            {
                snapshots.Add(snapshot);
            }
        }

        string logsDirectory = Path.Combine(AppContext.BaseDirectory, "logs");
        Directory.CreateDirectory(logsDirectory);
        string fileName = $"encoder_log_{DateTime.UtcNow:yyyyMMdd_HHmmss}.csv";
        string path = Path.Combine(logsDirectory, fileName);

        try
        {
            CsvLogger.Export(snapshots, path);
            MessageBox.Show(
                this,
                $"Exported {snapshots.Count} row(s) to:\n{path}",
                "Export CSV",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                this,
                $"Export failed:\n{ex.Message}",
                "Export CSV",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void ZeroAxis(int axis)
    {
        _encoderService.ZeroAxis((short)axis);
        UpdateAxisDisplay(axis); // Immediate feedback: position should read 0.
    }

    private void UpdateAxisDisplay(int axis)
    {
        PositionSnapshot? snapshot = _encoderService.GetSnapshot((short)axis);
        int zeroOffset = _encoderService.GetZeroOffset((short)axis);

        int displayCounts = snapshot is null
            ? 0
            : snapshot.Counts - zeroOffset;

        GetPositionTextBox(axis).Text = displayCounts.ToString();

        double rpm = snapshot?.Rpm ?? 0.0;
        GetRpmLabel(axis).Text = $"RPM: {rpm:F1}";

        Direction direction = snapshot?.Direction ?? Direction.None;
        GetDirectionLabel(axis).Text = direction switch
        {
            Direction.Forward => "CW",
            Direction.Reverse => "CCW",
            _ => "—"
        };

        int inputs = snapshot?.Inputs ?? 0;
        string aBit = (inputs & 1) != 0 ? "1" : "0";
        string bBit = (inputs & 2) != 0 ? "1" : "0";
        GetInputsLabel(axis).Text = $"A:{aBit} B:{bBit}";

        GetModeLabel(axis).Text = $"ENCODER_MODE: {_encoderService.EncoderMode}";
    }

    private void UpdateStartStopButton()
    {
        bool running = _encoderService.IsRunning;
        btnStartStop.Text = running ? "Stop Polling" : "Start Polling";
        txtCpr.Enabled = !running;
    }

    private void UpdateStatusStrip()
    {
        lblSimBadge.Text = "SIMULATED";
        lblSimBadge.BackColor = Color.LimeGreen;
        lblSimBadge.ForeColor = Color.White;

        lblPollRate.Text = "Poll: 50 ms";
    }

    // ------------------------------------------------------------------
    // Control lookups (defined in MainForm.Designer.cs)
    // ------------------------------------------------------------------
    private TextBox GetPositionTextBox(int axis) => axis switch
    {
        0 => txtPosition0,
        1 => txtPosition1,
        _ => txtPosition2
    };

    private Label GetRpmLabel(int axis) => axis switch
    {
        0 => lblRpm0,
        1 => lblRpm1,
        _ => lblRpm2
    };

    private Label GetDirectionLabel(int axis) => axis switch
    {
        0 => lblDirection0,
        1 => lblDirection1,
        _ => lblDirection2
    };

    private Label GetModeLabel(int axis) => axis switch
    {
        0 => lblMode0,
        1 => lblMode1,
        _ => lblMode2
    };

    private Label GetInputsLabel(int axis) => axis switch
    {
        0 => lblInputs0,
        1 => lblInputs1,
        _ => lblInputs2
    };
}
