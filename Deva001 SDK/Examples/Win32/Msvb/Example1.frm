VERSION 5.00
Begin VB.Form Example1 
   Caption         =   "Digital Read Out"
   ClientHeight    =   1920
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7005
   LinkTopic       =   "DRO"
   ScaleHeight     =   1920
   ScaleWidth      =   7005
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer TimerUpdate 
      Interval        =   100
      Left            =   1200
      Top             =   960
   End
   Begin VB.Label LabelAccel 
      Alignment       =   1  'Right Justify
      Caption         =   "Acceleration"
      Height          =   300
      Index           =   0
      Left            =   5520
      TabIndex        =   4
      Top             =   240
      Width           =   1215
   End
   Begin VB.Label LabelVelocity 
      Alignment       =   1  'Right Justify
      Caption         =   "Velocity"
      Height          =   300
      Index           =   0
      Left            =   4200
      TabIndex        =   3
      Top             =   240
      Width           =   1215
   End
   Begin VB.Label LabelMark 
      Alignment       =   1  'Right Justify
      Caption         =   "Mark"
      Height          =   300
      Index           =   0
      Left            =   2760
      TabIndex        =   2
      Top             =   240
      Width           =   1215
   End
   Begin VB.Label LabelPosition 
      Alignment       =   1  'Right Justify
      Caption         =   "Position"
      Height          =   300
      Index           =   0
      Left            =   1440
      TabIndex        =   1
      Top             =   240
      Width           =   1215
   End
   Begin VB.Label LabelName 
      Alignment       =   1  'Right Justify
      Caption         =   "Axes Name"
      Height          =   300
      Index           =   0
      Left            =   120
      TabIndex        =   0
      Tag             =   "Encoder Channel"
      Top             =   240
      Width           =   1215
   End
End
Attribute VB_Name = "Example1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
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
Option Explicit
Dim Axes_name(1 To 12) As String
Dim Version_string As String
Dim Channel As Integer
Dim temp As Integer
Private Sub Form_Load()
    If (open_encoder() <> 0) Then
        Call MsgBox("Unable to load Driver Info", vbExclamation, "Digital Read Out")
        End
    End If
    Call write_encoder(TIMER, 1, 10)
    Call write_encoder(TIMER_INT, 1, 1)
    
   For Channel = 1 To 3
        Call write_encoder(MARK_FUNC, Channel - 1, 1)
        Load LabelName(Channel)
        With LabelName(Channel)
            .Top = .Top + .Height * Channel
            .Visible = True
        End With
        Load LabelPosition(Channel)
        With LabelPosition(Channel)
            .Top = .Top + .Height * Channel
            .Visible = True
        End With
        Load LabelMark(Channel)
        With LabelMark(Channel)
            .Top = .Top + .Height * Channel
            .Visible = True
        End With
        Load LabelVelocity(Channel)
        With LabelVelocity(Channel)
            .Top = .Top + .Height * Channel
            .Visible = True
        End With
        Load LabelAccel(Channel)
        With LabelAccel(Channel)
            .Top = .Top + .Height * Channel
            .Enabled = True
            .Visible = True
        End With
    Next Channel
End Sub
Private Sub Form_Unload(Cancel As Integer)
    Call close_encoder
End Sub
Private Sub TimerUpdate_Timer()
    LabelName(1).Caption = "x"
    LabelName(2).Caption = "y"
    LabelName(3).Caption = "z"
    For Channel = 1 To 3
        LabelPosition(Channel).Caption = read_encoder(AXIS_32, Channel - 1)
        LabelMark(Channel).Caption = read_encoder(MARK_32, Channel - 1)
        LabelVelocity(Channel).Caption = read_encoder(VEL_INST, Channel - 1)
        LabelAccel(Channel).Caption = read_encoder(ACCEL_INST, Channel - 1)
    Next Channel
End Sub
