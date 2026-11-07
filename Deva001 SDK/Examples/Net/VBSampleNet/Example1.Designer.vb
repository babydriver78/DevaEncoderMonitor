<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Example1
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents TimerUpdate As System.Windows.Forms.Timer
	Public WithEvents _LabelAccel_0 As System.Windows.Forms.Label
	Public WithEvents _LabelVelocity_0 As System.Windows.Forms.Label
	Public WithEvents _LabelMark_0 As System.Windows.Forms.Label
	Public WithEvents _LabelPosition_0 As System.Windows.Forms.Label
	Public WithEvents _LabelName_0 As System.Windows.Forms.Label
	Public WithEvents LabelAccel As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents LabelProbe As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
    Public WithEvents LabelMark As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents LabelName As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents LabelPosition As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents LabelVelocity As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerUpdate = New System.Windows.Forms.Timer(Me.components)
        Me._LabelAccel_0 = New System.Windows.Forms.Label
        Me._LabelProbe_0 = New System.Windows.Forms.Label
        Me._LabelVelocity_0 = New System.Windows.Forms.Label
        Me._LabelMark_0 = New System.Windows.Forms.Label
        Me._LabelPosition_0 = New System.Windows.Forms.Label
        Me._LabelName_0 = New System.Windows.Forms.Label
        Me.LabelAccel = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.LabelProbe = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.LabelMark = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.LabelName = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.LabelPosition = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.LabelVelocity = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me._ProbeEnableCheckBox = New System.Windows.Forms.CheckBox
        CType(Me.LabelAccel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelProbe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelVelocity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerUpdate
        '
        Me.TimerUpdate.Enabled = True
        '
        '_LabelAccel_0
        '
        Me._LabelAccel_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelAccel_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelAccel_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LabelAccel_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelAccel.SetIndex(Me._LabelAccel_0, CType(0, Short))
        Me._LabelAccel_0.Location = New System.Drawing.Point(368, 16)
        Me._LabelAccel_0.Name = "_LabelAccel_0"
        Me._LabelAccel_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelAccel_0.Size = New System.Drawing.Size(81, 20)
        Me._LabelAccel_0.TabIndex = 4
        Me._LabelAccel_0.Text = "Acceleration"
        Me._LabelAccel_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_LabelProbe_0
        '
        Me._LabelProbe_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelProbe_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelProbe_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LabelProbe_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelProbe.SetIndex(Me._LabelProbe_0, CType(0, Short))
        Me._LabelProbe_0.Location = New System.Drawing.Point(464, 16)
        Me._LabelProbe_0.Name = "_LabelProbe_0"
        Me._LabelProbe_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelProbe_0.Size = New System.Drawing.Size(49, 20)
        Me._LabelProbe_0.TabIndex = 5
        Me._LabelProbe_0.Text = "Probe"
        Me._LabelProbe_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_LabelVelocity_0
        '
        Me._LabelVelocity_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelVelocity_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelVelocity_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LabelVelocity_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelVelocity.SetIndex(Me._LabelVelocity_0, CType(0, Short))
        Me._LabelVelocity_0.Location = New System.Drawing.Point(280, 16)
        Me._LabelVelocity_0.Name = "_LabelVelocity_0"
        Me._LabelVelocity_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelVelocity_0.Size = New System.Drawing.Size(81, 20)
        Me._LabelVelocity_0.TabIndex = 3
        Me._LabelVelocity_0.Text = "Velocity"
        Me._LabelVelocity_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_LabelMark_0
        '
        Me._LabelMark_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelMark_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelMark_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LabelMark_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelMark.SetIndex(Me._LabelMark_0, CType(0, Short))
        Me._LabelMark_0.Location = New System.Drawing.Point(184, 16)
        Me._LabelMark_0.Name = "_LabelMark_0"
        Me._LabelMark_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelMark_0.Size = New System.Drawing.Size(81, 20)
        Me._LabelMark_0.TabIndex = 2
        Me._LabelMark_0.Text = "Mark"
        Me._LabelMark_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_LabelPosition_0
        '
        Me._LabelPosition_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelPosition_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelPosition_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LabelPosition_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelPosition.SetIndex(Me._LabelPosition_0, CType(0, Short))
        Me._LabelPosition_0.Location = New System.Drawing.Point(96, 16)
        Me._LabelPosition_0.Name = "_LabelPosition_0"
        Me._LabelPosition_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelPosition_0.Size = New System.Drawing.Size(81, 20)
        Me._LabelPosition_0.TabIndex = 1
        Me._LabelPosition_0.Text = "Position"
        Me._LabelPosition_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_LabelName_0
        '
        Me._LabelName_0.BackColor = System.Drawing.SystemColors.Control
        Me._LabelName_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._LabelName_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._LabelName_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelName.SetIndex(Me._LabelName_0, CType(0, Short))
        Me._LabelName_0.Location = New System.Drawing.Point(8, 16)
        Me._LabelName_0.Name = "_LabelName_0"
        Me._LabelName_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._LabelName_0.Size = New System.Drawing.Size(81, 20)
        Me._LabelName_0.TabIndex = 0
        Me._LabelName_0.Tag = "Encoder Channel"
        Me._LabelName_0.Text = "Axes Name"
        Me._LabelName_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_ProbeEnableCheckBox
        '
        Me._ProbeEnableCheckBox.AutoSize = True
        Me._ProbeEnableCheckBox.Location = New System.Drawing.Point(543, 16)
        Me._ProbeEnableCheckBox.Name = "_ProbeEnableCheckBox"
        Me._ProbeEnableCheckBox.Size = New System.Drawing.Size(89, 18)
        Me._ProbeEnableCheckBox.TabIndex = 6
        Me._ProbeEnableCheckBox.Text = "Probe Enable"
        Me._ProbeEnableCheckBox.UseVisualStyleBackColor = True
        '
        'Example1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(636, 128)
        Me.Controls.Add(Me._ProbeEnableCheckBox)
        Me.Controls.Add(Me._LabelProbe_0)
        Me.Controls.Add(Me._LabelAccel_0)
        Me.Controls.Add(Me._LabelVelocity_0)
        Me.Controls.Add(Me._LabelMark_0)
        Me.Controls.Add(Me._LabelPosition_0)
        Me.Controls.Add(Me._LabelName_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Example1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Digital Read Out"
        CType(Me.LabelAccel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelProbe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelVelocity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _LabelProbe_0 As System.Windows.Forms.Label
    Friend WithEvents _ProbeEnableCheckBox As System.Windows.Forms.CheckBox
#End Region 
End Class