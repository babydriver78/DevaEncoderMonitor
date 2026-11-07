namespace namespaceExample1
{
	partial class classExample1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this._xZeroButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._xIncrementalLabel = new System.Windows.Forms.Label();
            this._xAbsoluteLabel = new System.Windows.Forms.Label();
            this._xMarkCheckBox = new System.Windows.Forms.CheckBox();
            this._xMarkersLabel = new System.Windows.Forms.Label();
            this._xProbeLabel = new System.Windows.Forms.Label();
            this._yProbeLabel = new System.Windows.Forms.Label();
            this._yMarkersLabel = new System.Windows.Forms.Label();
            this._yMarkCheckBox = new System.Windows.Forms.CheckBox();
            this._yAbsoluteLabel = new System.Windows.Forms.Label();
            this._yIncrementalLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this._yZeroButton = new System.Windows.Forms.Button();
            this._zProbeLabel = new System.Windows.Forms.Label();
            this._zMarkersLabel = new System.Windows.Forms.Label();
            this._zMarkCheckBox = new System.Windows.Forms.CheckBox();
            this._zAbsoluteLabel = new System.Windows.Forms.Label();
            this._zIncrementalLabel = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this._zZeroButton = new System.Windows.Forms.Button();
            this._pollTimer = new System.Windows.Forms.Timer(this.components);
            this._footswitchEnableCheckBox = new System.Windows.Forms.CheckBox();
            this._probeEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _xZeroButton
            // 
            this._xZeroButton.Location = new System.Drawing.Point(59, 48);
            this._xZeroButton.Name = "_xZeroButton";
            this._xZeroButton.Size = new System.Drawing.Size(27, 23);
            this._xZeroButton.TabIndex = 0;
            this._xZeroButton.Text = "Z";
            this._xZeroButton.UseVisualStyleBackColor = true;
            this._xZeroButton.Click += new System.EventHandler(this._xZeroButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Axis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Zero";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Incremental";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Absolute";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mark";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(387, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Markers";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(-4, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 8);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(-4, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(753, 8);
            this.panel2.TabIndex = 10;
            // 
            // _xIncrementalLabel
            // 
            this._xIncrementalLabel.BackColor = System.Drawing.SystemColors.Control;
            this._xIncrementalLabel.Location = new System.Drawing.Point(112, 53);
            this._xIncrementalLabel.Name = "_xIncrementalLabel";
            this._xIncrementalLabel.Size = new System.Drawing.Size(107, 15);
            this._xIncrementalLabel.TabIndex = 11;
            this._xIncrementalLabel.Text = "0";
            // 
            // _xAbsoluteLabel
            // 
            this._xAbsoluteLabel.BackColor = System.Drawing.SystemColors.Control;
            this._xAbsoluteLabel.Location = new System.Drawing.Point(225, 53);
            this._xAbsoluteLabel.Name = "_xAbsoluteLabel";
            this._xAbsoluteLabel.Size = new System.Drawing.Size(107, 15);
            this._xAbsoluteLabel.TabIndex = 12;
            this._xAbsoluteLabel.Text = "0";
            // 
            // _xMarkCheckBox
            // 
            this._xMarkCheckBox.AutoSize = true;
            this._xMarkCheckBox.Location = new System.Drawing.Point(338, 53);
            this._xMarkCheckBox.Name = "_xMarkCheckBox";
            this._xMarkCheckBox.Size = new System.Drawing.Size(41, 17);
            this._xMarkCheckBox.TabIndex = 13;
            this._xMarkCheckBox.Text = "Mk";
            this._xMarkCheckBox.UseVisualStyleBackColor = true;
            this._xMarkCheckBox.CheckedChanged += new System.EventHandler(this._xMarkCheckBox_CheckedChanged);
            // 
            // _xMarkersLabel
            // 
            this._xMarkersLabel.BackColor = System.Drawing.SystemColors.Control;
            this._xMarkersLabel.Location = new System.Drawing.Point(385, 54);
            this._xMarkersLabel.Name = "_xMarkersLabel";
            this._xMarkersLabel.Size = new System.Drawing.Size(107, 15);
            this._xMarkersLabel.TabIndex = 14;
            this._xMarkersLabel.Text = "0";
            // 
            // _xProbeLabel
            // 
            this._xProbeLabel.BackColor = System.Drawing.SystemColors.Control;
            this._xProbeLabel.Location = new System.Drawing.Point(498, 53);
            this._xProbeLabel.Name = "_xProbeLabel";
            this._xProbeLabel.Size = new System.Drawing.Size(107, 15);
            this._xProbeLabel.TabIndex = 15;
            this._xProbeLabel.Text = "0";
            // 
            // _yProbeLabel
            // 
            this._yProbeLabel.BackColor = System.Drawing.SystemColors.Control;
            this._yProbeLabel.Location = new System.Drawing.Point(497, 96);
            this._yProbeLabel.Name = "_yProbeLabel";
            this._yProbeLabel.Size = new System.Drawing.Size(107, 15);
            this._yProbeLabel.TabIndex = 23;
            this._yProbeLabel.Text = "0";
            // 
            // _yMarkersLabel
            // 
            this._yMarkersLabel.BackColor = System.Drawing.SystemColors.Control;
            this._yMarkersLabel.Location = new System.Drawing.Point(384, 97);
            this._yMarkersLabel.Name = "_yMarkersLabel";
            this._yMarkersLabel.Size = new System.Drawing.Size(107, 15);
            this._yMarkersLabel.TabIndex = 22;
            this._yMarkersLabel.Text = "0";
            // 
            // _yMarkCheckBox
            // 
            this._yMarkCheckBox.AutoSize = true;
            this._yMarkCheckBox.Location = new System.Drawing.Point(337, 96);
            this._yMarkCheckBox.Name = "_yMarkCheckBox";
            this._yMarkCheckBox.Size = new System.Drawing.Size(41, 17);
            this._yMarkCheckBox.TabIndex = 21;
            this._yMarkCheckBox.Text = "Mk";
            this._yMarkCheckBox.UseVisualStyleBackColor = true;
            this._yMarkCheckBox.CheckedChanged += new System.EventHandler(this._yMarkCheckBox_CheckedChanged);
            // 
            // _yAbsoluteLabel
            // 
            this._yAbsoluteLabel.BackColor = System.Drawing.SystemColors.Control;
            this._yAbsoluteLabel.Location = new System.Drawing.Point(224, 96);
            this._yAbsoluteLabel.Name = "_yAbsoluteLabel";
            this._yAbsoluteLabel.Size = new System.Drawing.Size(107, 15);
            this._yAbsoluteLabel.TabIndex = 20;
            this._yAbsoluteLabel.Text = "0";
            // 
            // _yIncrementalLabel
            // 
            this._yIncrementalLabel.BackColor = System.Drawing.SystemColors.Control;
            this._yIncrementalLabel.Location = new System.Drawing.Point(111, 96);
            this._yIncrementalLabel.Name = "_yIncrementalLabel";
            this._yIncrementalLabel.Size = new System.Drawing.Size(107, 15);
            this._yIncrementalLabel.TabIndex = 19;
            this._yIncrementalLabel.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(-5, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(753, 8);
            this.panel3.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Y";
            // 
            // _yZeroButton
            // 
            this._yZeroButton.Location = new System.Drawing.Point(58, 91);
            this._yZeroButton.Name = "_yZeroButton";
            this._yZeroButton.Size = new System.Drawing.Size(27, 23);
            this._yZeroButton.TabIndex = 16;
            this._yZeroButton.Text = "Z";
            this._yZeroButton.UseVisualStyleBackColor = true;
            this._yZeroButton.Click += new System.EventHandler(this._yZeroButton_Click);
            // 
            // _zProbeLabel
            // 
            this._zProbeLabel.BackColor = System.Drawing.SystemColors.Control;
            this._zProbeLabel.Location = new System.Drawing.Point(498, 139);
            this._zProbeLabel.Name = "_zProbeLabel";
            this._zProbeLabel.Size = new System.Drawing.Size(107, 15);
            this._zProbeLabel.TabIndex = 31;
            this._zProbeLabel.Text = "0";
            // 
            // _zMarkersLabel
            // 
            this._zMarkersLabel.BackColor = System.Drawing.SystemColors.Control;
            this._zMarkersLabel.Location = new System.Drawing.Point(385, 140);
            this._zMarkersLabel.Name = "_zMarkersLabel";
            this._zMarkersLabel.Size = new System.Drawing.Size(107, 15);
            this._zMarkersLabel.TabIndex = 30;
            this._zMarkersLabel.Text = "0";
            // 
            // _zMarkCheckBox
            // 
            this._zMarkCheckBox.AutoSize = true;
            this._zMarkCheckBox.Location = new System.Drawing.Point(338, 139);
            this._zMarkCheckBox.Name = "_zMarkCheckBox";
            this._zMarkCheckBox.Size = new System.Drawing.Size(41, 17);
            this._zMarkCheckBox.TabIndex = 29;
            this._zMarkCheckBox.Text = "Mk";
            this._zMarkCheckBox.UseVisualStyleBackColor = true;
            this._zMarkCheckBox.CheckedChanged += new System.EventHandler(this._zMarkCheckBox_CheckedChanged);
            // 
            // _zAbsoluteLabel
            // 
            this._zAbsoluteLabel.BackColor = System.Drawing.SystemColors.Control;
            this._zAbsoluteLabel.Location = new System.Drawing.Point(225, 139);
            this._zAbsoluteLabel.Name = "_zAbsoluteLabel";
            this._zAbsoluteLabel.Size = new System.Drawing.Size(107, 15);
            this._zAbsoluteLabel.TabIndex = 28;
            this._zAbsoluteLabel.Text = "0";
            // 
            // _zIncrementalLabel
            // 
            this._zIncrementalLabel.BackColor = System.Drawing.SystemColors.Control;
            this._zIncrementalLabel.Location = new System.Drawing.Point(112, 139);
            this._zIncrementalLabel.Name = "_zIncrementalLabel";
            this._zIncrementalLabel.Size = new System.Drawing.Size(107, 15);
            this._zIncrementalLabel.TabIndex = 27;
            this._zIncrementalLabel.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 139);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(14, 13);
            this.label22.TabIndex = 25;
            this.label22.Text = "Z";
            // 
            // _zZeroButton
            // 
            this._zZeroButton.Location = new System.Drawing.Point(59, 134);
            this._zZeroButton.Name = "_zZeroButton";
            this._zZeroButton.Size = new System.Drawing.Size(27, 23);
            this._zZeroButton.TabIndex = 24;
            this._zZeroButton.Text = "Z";
            this._zZeroButton.UseVisualStyleBackColor = true;
            this._zZeroButton.Click += new System.EventHandler(this._zZeroButton_Click);
            // 
            // _pollTimer
            // 
            this._pollTimer.Interval = 50;
            this._pollTimer.Tick += new System.EventHandler(this._pollTimer_Tick);
            // 
            // _footswitchEnableCheckBox
            // 
            this._footswitchEnableCheckBox.AutoSize = true;
            this._footswitchEnableCheckBox.Location = new System.Drawing.Point(563, 8);
            this._footswitchEnableCheckBox.Name = "_footswitchEnableCheckBox";
            this._footswitchEnableCheckBox.Size = new System.Drawing.Size(79, 17);
            this._footswitchEnableCheckBox.TabIndex = 32;
            this._footswitchEnableCheckBox.Text = "FootSwitch";
            this._footswitchEnableCheckBox.UseVisualStyleBackColor = true;
            this._footswitchEnableCheckBox.CheckedChanged += new System.EventHandler(this._footswitchEnableCheckBox_CheckedChanged);
            // 
            // _probeEnableCheckBox
            // 
            this._probeEnableCheckBox.AutoSize = true;
            this._probeEnableCheckBox.Location = new System.Drawing.Point(476, 8);
            this._probeEnableCheckBox.Name = "_probeEnableCheckBox";
            this._probeEnableCheckBox.Size = new System.Drawing.Size(54, 17);
            this._probeEnableCheckBox.TabIndex = 33;
            this._probeEnableCheckBox.Text = "Probe";
            this._probeEnableCheckBox.UseVisualStyleBackColor = true;
            this._probeEnableCheckBox.CheckedChanged += new System.EventHandler(this._probeEnableCheckBox_CheckedChanged);
            // 
            // classExample1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 169);
            this.Controls.Add(this._probeEnableCheckBox);
            this.Controls.Add(this._footswitchEnableCheckBox);
            this.Controls.Add(this._zProbeLabel);
            this.Controls.Add(this._zMarkersLabel);
            this.Controls.Add(this._zMarkCheckBox);
            this.Controls.Add(this._zAbsoluteLabel);
            this.Controls.Add(this._zIncrementalLabel);
            this.Controls.Add(this.label22);
            this.Controls.Add(this._zZeroButton);
            this.Controls.Add(this._yProbeLabel);
            this.Controls.Add(this._yMarkersLabel);
            this.Controls.Add(this._yMarkCheckBox);
            this.Controls.Add(this._yAbsoluteLabel);
            this.Controls.Add(this._yIncrementalLabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this._yZeroButton);
            this.Controls.Add(this._xProbeLabel);
            this.Controls.Add(this._xMarkersLabel);
            this.Controls.Add(this._xMarkCheckBox);
            this.Controls.Add(this._xAbsoluteLabel);
            this.Controls.Add(this._xIncrementalLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._xZeroButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "classExample1";
            this.Text = "MSCS Example1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _xZeroButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label _xIncrementalLabel;
		private System.Windows.Forms.Label _xAbsoluteLabel;
		private System.Windows.Forms.CheckBox _xMarkCheckBox;
		private System.Windows.Forms.Label _xMarkersLabel;
		private System.Windows.Forms.Label _xProbeLabel;
		private System.Windows.Forms.Label _yProbeLabel;
		private System.Windows.Forms.Label _yMarkersLabel;
		private System.Windows.Forms.CheckBox _yMarkCheckBox;
		private System.Windows.Forms.Label _yAbsoluteLabel;
		private System.Windows.Forms.Label _yIncrementalLabel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button _yZeroButton;
		private System.Windows.Forms.Label _zProbeLabel;
		private System.Windows.Forms.Label _zMarkersLabel;
		private System.Windows.Forms.CheckBox _zMarkCheckBox;
		private System.Windows.Forms.Label _zAbsoluteLabel;
		private System.Windows.Forms.Label _zIncrementalLabel;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button _zZeroButton;
		private System.Windows.Forms.Timer _pollTimer;
		private System.Windows.Forms.CheckBox _footswitchEnableCheckBox;
		private System.Windows.Forms.CheckBox _probeEnableCheckBox;

	}
}

