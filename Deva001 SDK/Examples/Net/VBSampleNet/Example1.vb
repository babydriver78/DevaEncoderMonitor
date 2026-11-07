Option Strict Off
Option Explicit On
Friend Class Example1
	Inherits System.Windows.Forms.Form
	'-----------------------------------------------------------------------------
	'
	'    Encoder card MSVB example
	'
	'-----------------------------------------------------------------------------
	'
	'    Revision History.
	'
	'    V1.0    25/04/1998     First controlled version
	'-----------------------------------------------------------------------------
	'UPGRADE_WARNING: Lower bound of array Axes_name was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
	Dim Axes_name(12) As String
	Dim Version_string As String
	Dim Channel As Short
	Dim temp As Short
	Private Sub Example1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		If (Deva.Enclib.open_encoder() <> 0) Then
            Call MsgBox("Unable to load Driver Info", MsgBoxStyle.Exclamation, "Digital Read Out")
            End
        End If
        Call Deva.Enclib.write_encoder(Deva.Enclib.COMMANDS.TIMER, 1, 10)
        Call Deva.Enclib.write_encoder(Deva.Enclib.COMMANDS.TIMER_INT, 1, 1)
		
		For Channel = 1 To 3
            Call Deva.Enclib.write_encoder(Deva.Enclib.COMMANDS.MARK_FUNC, Channel - 1, 1)
			LabelName.Load(Channel)
			With LabelName(Channel)
				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height) * Channel)
				.Visible = True
			End With
			LabelPosition.Load(Channel)
			With LabelPosition(Channel)
				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height) * Channel)
				.Visible = True
			End With
			LabelMark.Load(Channel)
			With LabelMark(Channel)
				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height) * Channel)
				.Visible = True
			End With
			LabelVelocity.Load(Channel)
			With LabelVelocity(Channel)
				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height) * Channel)
				.Visible = True
			End With
			LabelAccel.Load(Channel)
			With LabelAccel(Channel)
				.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height) * Channel)
				.Enabled = True
				.Visible = True
			End With
            LabelProbe.Load(Channel)
            With LabelProbe(Channel)
                .Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(.Top) + VB6.PixelsToTwipsY(.Height) * Channel)
                .Enabled = True
                .Visible = True
            End With
        Next Channel
        _ProbeEnableCheckBox.Checked = Deva.Enclib.read_encoder(Deva.Enclib.COMMANDS.PROBE_FUNC, 0)
    End Sub
	Private Sub Example1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Call Deva.Enclib.close_encoder()
	End Sub
	Private Sub TimerUpdate_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TimerUpdate.Tick
        LabelName(1).Text = "x"
        LabelName(2).Text = "y"
        LabelName(3).Text = "z"
        For Channel = 1 To 3
            LabelPosition(Channel).Text = CStr(Deva.Enclib.read_encoder(Deva.Enclib.COMMANDS.AXIS_32, Channel - 1))
            LabelMark(Channel).Text = CStr(Deva.Enclib.read_encoder(Deva.Enclib.COMMANDS.MARK_32, Channel - 1))
            LabelVelocity(Channel).Text = CStr(Deva.Enclib.read_encoder(Deva.Enclib.COMMANDS.VEL_INST, Channel - 1))
            LabelAccel(Channel).Text = CStr(Deva.Enclib.read_encoder(Deva.Enclib.COMMANDS.ACCEL_INST, Channel - 1))
            LabelProbe(Channel).Text = CStr(Deva.Enclib.read_encoder(Deva.Enclib.COMMANDS.PROBE_32, Channel - 1))
        Next Channel
    End Sub

    Private Sub OnProbeEnableChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _ProbeEnableCheckBox.CheckedChanged
        Deva.Enclib.write_encoder(Deva.Enclib.COMMANDS.PROBE_FUNC, 0, _ProbeEnableCheckBox.Checked)

    End Sub
End Class