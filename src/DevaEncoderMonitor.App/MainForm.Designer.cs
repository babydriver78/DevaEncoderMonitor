#nullable disable

namespace DevaEncoderMonitor.App;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.btnStartStop = new System.Windows.Forms.Button();
        this.lblCpr = new System.Windows.Forms.Label();
        this.txtCpr = new System.Windows.Forms.TextBox();
        this.btnExport = new System.Windows.Forms.Button();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblSimBadge = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblOpenState = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblPollRate = new System.Windows.Forms.ToolStripStatusLabel();
        this.grpAxis0 = new System.Windows.Forms.GroupBox();
        this.lblMode0 = new System.Windows.Forms.Label();
        this.lblInputs0 = new System.Windows.Forms.Label();
        this.btnZero0 = new System.Windows.Forms.Button();
        this.lblDirection0 = new System.Windows.Forms.Label();
        this.lblRpm0 = new System.Windows.Forms.Label();
        this.txtPosition0 = new System.Windows.Forms.TextBox();
        this.lblPosTitle0 = new System.Windows.Forms.Label();
        this.grpAxis1 = new System.Windows.Forms.GroupBox();
        this.lblMode1 = new System.Windows.Forms.Label();
        this.lblInputs1 = new System.Windows.Forms.Label();
        this.btnZero1 = new System.Windows.Forms.Button();
        this.lblDirection1 = new System.Windows.Forms.Label();
        this.lblRpm1 = new System.Windows.Forms.Label();
        this.txtPosition1 = new System.Windows.Forms.TextBox();
        this.lblPosTitle1 = new System.Windows.Forms.Label();
        this.grpAxis2 = new System.Windows.Forms.GroupBox();
        this.lblMode2 = new System.Windows.Forms.Label();
        this.lblInputs2 = new System.Windows.Forms.Label();
        this.btnZero2 = new System.Windows.Forms.Button();
        this.lblDirection2 = new System.Windows.Forms.Label();
        this.lblRpm2 = new System.Windows.Forms.Label();
        this.txtPosition2 = new System.Windows.Forms.TextBox();
        this.lblPosTitle2 = new System.Windows.Forms.Label();
        this.statusStrip.SuspendLayout();
        this.grpAxis0.SuspendLayout();
        this.grpAxis1.SuspendLayout();
        this.grpAxis2.SuspendLayout();
        this.SuspendLayout();
        //
        // btnStartStop
        //
        this.btnStartStop.Location = new System.Drawing.Point(230, 10);
        this.btnStartStop.Size = new System.Drawing.Size(130, 30);
        this.btnStartStop.TabIndex = 0;
        this.btnStartStop.Text = "Start Polling";
        this.btnStartStop.UseVisualStyleBackColor = true;
        //
        // lblCpr
        //
        this.lblCpr.Location = new System.Drawing.Point(12, 14);
        this.lblCpr.Size = new System.Drawing.Size(116, 18);
        this.lblCpr.TabIndex = 1;
        this.lblCpr.Text = "Counts Per Rev (CPR):";
        //
        // txtCpr
        //
        this.txtCpr.Location = new System.Drawing.Point(134, 10);
        this.txtCpr.Size = new System.Drawing.Size(80, 23);
        this.txtCpr.TabIndex = 2;
        this.txtCpr.Text = "1024";
        //
        // btnExport
        //
        this.btnExport.Location = new System.Drawing.Point(376, 10);
        this.btnExport.Size = new System.Drawing.Size(110, 30);
        this.btnExport.TabIndex = 3;
        this.btnExport.Text = "Export CSV";
        this.btnExport.UseVisualStyleBackColor = true;
        //
        // statusStrip
        //
        this.statusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
        {
            this.lblSimBadge,
            this.lblOpenState,
            this.lblPollRate
        });
        this.statusStrip.Location = new System.Drawing.Point(0, 578);
        this.statusStrip.Size = new System.Drawing.Size(960, 22);
        this.statusStrip.TabIndex = 4;
        this.statusStrip.Text = "statusStrip1";
        //
        // lblSimBadge
        //
        this.lblSimBadge.BackColor = System.Drawing.Color.LimeGreen;
        this.lblSimBadge.ForeColor = System.Drawing.Color.White;
        this.lblSimBadge.Name = "lblSimBadge";
        this.lblSimBadge.Size = new System.Drawing.Size(78, 17);
        this.lblSimBadge.Text = "SIMULATED";
        this.lblSimBadge.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
        this.lblSimBadge.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
        //
        // lblOpenState
        //
        this.lblOpenState.Name = "lblOpenState";
        this.lblOpenState.Size = new System.Drawing.Size(78, 17);
        this.lblOpenState.Text = "Closed";
        //
        // lblPollRate
        //
        this.lblPollRate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        this.lblPollRate.Name = "lblPollRate";
        this.lblPollRate.Size = new System.Drawing.Size(70, 17);
        this.lblPollRate.Text = "Poll: 50 ms";
        //
        // grpAxis0
        //
        this.grpAxis0.Controls.Add(this.lblMode0);
        this.grpAxis0.Controls.Add(this.lblInputs0);
        this.grpAxis0.Controls.Add(this.btnZero0);
        this.grpAxis0.Controls.Add(this.lblDirection0);
        this.grpAxis0.Controls.Add(this.lblRpm0);
        this.grpAxis0.Controls.Add(this.txtPosition0);
        this.grpAxis0.Controls.Add(this.lblPosTitle0);
        this.grpAxis0.Location = new System.Drawing.Point(12, 52);
        this.grpAxis0.Size = new System.Drawing.Size(300, 340);
        this.grpAxis0.TabIndex = 5;
        this.grpAxis0.TabStop = false;
        this.grpAxis0.Text = "Axis 0";
        //
        // lblMode0
        //
        this.lblMode0.Location = new System.Drawing.Point(10, 192);
        this.lblMode0.Size = new System.Drawing.Size(200, 18);
        this.lblMode0.TabIndex = 7;
        this.lblMode0.Text = "ENCODER_MODE: QUADx4AB";
        //
        // lblInputs0
        //
        this.lblInputs0.Location = new System.Drawing.Point(10, 218);
        this.lblInputs0.Size = new System.Drawing.Size(120, 18);
        this.lblInputs0.TabIndex = 6;
        this.lblInputs0.Text = "A:0 B:0";
        //
        // btnZero0
        //
        this.btnZero0.Location = new System.Drawing.Point(10, 152);
        this.btnZero0.Size = new System.Drawing.Size(80, 28);
        this.btnZero0.TabIndex = 5;
        this.btnZero0.Text = "Zero";
        this.btnZero0.UseVisualStyleBackColor = true;
        //
        // lblDirection0
        //
        this.lblDirection0.Location = new System.Drawing.Point(10, 122);
        this.lblDirection0.Size = new System.Drawing.Size(100, 18);
        this.lblDirection0.TabIndex = 4;
        this.lblDirection0.Text = "Direction: —";
        //
        // lblRpm0
        //
        this.lblRpm0.Location = new System.Drawing.Point(10, 98);
        this.lblRpm0.Size = new System.Drawing.Size(120, 18);
        this.lblRpm0.TabIndex = 3;
        this.lblRpm0.Text = "RPM: 0.0";
        //
        // txtPosition0
        //
        this.txtPosition0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtPosition0.Location = new System.Drawing.Point(10, 44);
        this.txtPosition0.Size = new System.Drawing.Size(260, 42);
        this.txtPosition0.TabIndex = 2;
        this.txtPosition0.Text = "0";
        this.txtPosition0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        this.txtPosition0.ReadOnly = true;
        //
        // lblPosTitle0
        //
        this.lblPosTitle0.Location = new System.Drawing.Point(10, 22);
        this.lblPosTitle0.Size = new System.Drawing.Size(60, 18);
        this.lblPosTitle0.TabIndex = 1;
        this.lblPosTitle0.Text = "Position";
        //
        // grpAxis1
        //
        this.grpAxis1.Controls.Add(this.lblMode1);
        this.grpAxis1.Controls.Add(this.lblInputs1);
        this.grpAxis1.Controls.Add(this.btnZero1);
        this.grpAxis1.Controls.Add(this.lblDirection1);
        this.grpAxis1.Controls.Add(this.lblRpm1);
        this.grpAxis1.Controls.Add(this.txtPosition1);
        this.grpAxis1.Controls.Add(this.lblPosTitle1);
        this.grpAxis1.Location = new System.Drawing.Point(324, 52);
        this.grpAxis1.Size = new System.Drawing.Size(300, 340);
        this.grpAxis1.TabIndex = 6;
        this.grpAxis1.TabStop = false;
        this.grpAxis1.Text = "Axis 1";
        //
        // lblMode1
        //
        this.lblMode1.Location = new System.Drawing.Point(10, 192);
        this.lblMode1.Size = new System.Drawing.Size(200, 18);
        this.lblMode1.TabIndex = 7;
        this.lblMode1.Text = "ENCODER_MODE: QUADx4AB";
        //
        // lblInputs1
        //
        this.lblInputs1.Location = new System.Drawing.Point(10, 218);
        this.lblInputs1.Size = new System.Drawing.Size(120, 18);
        this.lblInputs1.TabIndex = 6;
        this.lblInputs1.Text = "A:0 B:0";
        //
        // btnZero1
        //
        this.btnZero1.Location = new System.Drawing.Point(10, 152);
        this.btnZero1.Size = new System.Drawing.Size(80, 28);
        this.btnZero1.TabIndex = 5;
        this.btnZero1.Text = "Zero";
        this.btnZero1.UseVisualStyleBackColor = true;
        //
        // lblDirection1
        //
        this.lblDirection1.Location = new System.Drawing.Point(10, 122);
        this.lblDirection1.Size = new System.Drawing.Size(100, 18);
        this.lblDirection1.TabIndex = 4;
        this.lblDirection1.Text = "Direction: —";
        //
        // lblRpm1
        //
        this.lblRpm1.Location = new System.Drawing.Point(10, 98);
        this.lblRpm1.Size = new System.Drawing.Size(120, 18);
        this.lblRpm1.TabIndex = 3;
        this.lblRpm1.Text = "RPM: 0.0";
        //
        // txtPosition1
        //
        this.txtPosition1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtPosition1.Location = new System.Drawing.Point(10, 44);
        this.txtPosition1.Size = new System.Drawing.Size(260, 42);
        this.txtPosition1.TabIndex = 2;
        this.txtPosition1.Text = "0";
        this.txtPosition1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        this.txtPosition1.ReadOnly = true;
        //
        // lblPosTitle1
        //
        this.lblPosTitle1.Location = new System.Drawing.Point(10, 22);
        this.lblPosTitle1.Size = new System.Drawing.Size(60, 18);
        this.lblPosTitle1.TabIndex = 1;
        this.lblPosTitle1.Text = "Position";
        //
        // grpAxis2
        //
        this.grpAxis2.Controls.Add(this.lblMode2);
        this.grpAxis2.Controls.Add(this.lblInputs2);
        this.grpAxis2.Controls.Add(this.btnZero2);
        this.grpAxis2.Controls.Add(this.lblDirection2);
        this.grpAxis2.Controls.Add(this.lblRpm2);
        this.grpAxis2.Controls.Add(this.txtPosition2);
        this.grpAxis2.Controls.Add(this.lblPosTitle2);
        this.grpAxis2.Location = new System.Drawing.Point(636, 52);
        this.grpAxis2.Size = new System.Drawing.Size(300, 340);
        this.grpAxis2.TabIndex = 7;
        this.grpAxis2.TabStop = false;
        this.grpAxis2.Text = "Axis 2";
        //
        // lblMode2
        //
        this.lblMode2.Location = new System.Drawing.Point(10, 192);
        this.lblMode2.Size = new System.Drawing.Size(200, 18);
        this.lblMode2.TabIndex = 7;
        this.lblMode2.Text = "ENCODER_MODE: QUADx4AB";
        //
        // lblInputs2
        //
        this.lblInputs2.Location = new System.Drawing.Point(10, 218);
        this.lblInputs2.Size = new System.Drawing.Size(120, 18);
        this.lblInputs2.TabIndex = 6;
        this.lblInputs2.Text = "A:0 B:0";
        //
        // btnZero2
        //
        this.btnZero2.Location = new System.Drawing.Point(10, 152);
        this.btnZero2.Size = new System.Drawing.Size(80, 28);
        this.btnZero2.TabIndex = 5;
        this.btnZero2.Text = "Zero";
        this.btnZero2.UseVisualStyleBackColor = true;
        //
        // lblDirection2
        //
        this.lblDirection2.Location = new System.Drawing.Point(10, 122);
        this.lblDirection2.Size = new System.Drawing.Size(100, 18);
        this.lblDirection2.TabIndex = 4;
        this.lblDirection2.Text = "Direction: —";
        //
        // lblRpm2
        //
        this.lblRpm2.Location = new System.Drawing.Point(10, 98);
        this.lblRpm2.Size = new System.Drawing.Size(120, 18);
        this.lblRpm2.TabIndex = 3;
        this.lblRpm2.Text = "RPM: 0.0";
        //
        // txtPosition2
        //
        this.txtPosition2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtPosition2.Location = new System.Drawing.Point(10, 44);
        this.txtPosition2.Size = new System.Drawing.Size(260, 42);
        this.txtPosition2.TabIndex = 2;
        this.txtPosition2.Text = "0";
        this.txtPosition2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        this.txtPosition2.ReadOnly = true;
        //
        // lblPosTitle2
        //
        this.lblPosTitle2.Location = new System.Drawing.Point(10, 22);
        this.lblPosTitle2.Size = new System.Drawing.Size(60, 18);
        this.lblPosTitle2.TabIndex = 1;
        this.lblPosTitle2.Text = "Position";
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(960, 600);
        this.Controls.Add(this.grpAxis2);
        this.Controls.Add(this.grpAxis1);
        this.Controls.Add(this.grpAxis0);
        this.Controls.Add(this.statusStrip);
        this.Controls.Add(this.btnExport);
        this.Controls.Add(this.txtCpr);
        this.Controls.Add(this.lblCpr);
        this.Controls.Add(this.btnStartStop);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "DevaEncoderMonitor - DEVA001 Simulator";
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.grpAxis0.ResumeLayout(false);
        this.grpAxis0.PerformLayout();
        this.grpAxis1.ResumeLayout(false);
        this.grpAxis1.PerformLayout();
        this.grpAxis2.ResumeLayout(false);
        this.grpAxis2.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button btnStartStop;
    private System.Windows.Forms.Label lblCpr;
    private System.Windows.Forms.TextBox txtCpr;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblSimBadge;
    private System.Windows.Forms.ToolStripStatusLabel lblOpenState;
    private System.Windows.Forms.ToolStripStatusLabel lblPollRate;
    private System.Windows.Forms.GroupBox grpAxis0;
    private System.Windows.Forms.Label lblPosTitle0;
    private System.Windows.Forms.TextBox txtPosition0;
    private System.Windows.Forms.Label lblRpm0;
    private System.Windows.Forms.Label lblDirection0;
    private System.Windows.Forms.Button btnZero0;
    private System.Windows.Forms.Label lblInputs0;
    private System.Windows.Forms.Label lblMode0;
    private System.Windows.Forms.GroupBox grpAxis1;
    private System.Windows.Forms.Label lblPosTitle1;
    private System.Windows.Forms.TextBox txtPosition1;
    private System.Windows.Forms.Label lblRpm1;
    private System.Windows.Forms.Label lblDirection1;
    private System.Windows.Forms.Button btnZero1;
    private System.Windows.Forms.Label lblInputs1;
    private System.Windows.Forms.Label lblMode1;
    private System.Windows.Forms.GroupBox grpAxis2;
    private System.Windows.Forms.Label lblPosTitle2;
    private System.Windows.Forms.TextBox txtPosition2;
    private System.Windows.Forms.Label lblRpm2;
    private System.Windows.Forms.Label lblDirection2;
    private System.Windows.Forms.Button btnZero2;
    private System.Windows.Forms.Label lblInputs2;
    private System.Windows.Forms.Label lblMode2;
}
