Attribute VB_Name = "Deva001"
'-----------------------------------------------------------------------------
'
'    Encoder card device driver header file
'
'-----------------------------------------------------------------------------
'
'    Revision History.
'
'    V1.0    01/05/1998     First controlled version
'    V3.0    18/04/2002     Added functions to support additional PCI features
'    V3.1    10/10/2002     Added support for MS Windows callbacks
'                           Added functions enclib_callback and NUM_LOSTCALLBACKS
'    V3.2    22/10/2004     Added PULSEGEN0_TIME, PULSEGEN0_SEQ_EN and PULSEGEN0_TIMEOUT
'-----------------------------------------------------------------------------

Declare Function open_encoder Lib "enclib32.dll" () As Integer
Declare Sub close_encoder Lib "enclib32.dll" ()
Declare Function read_encoder Lib "enclib32.dll" (ByVal com As Integer, ByVal chan As Integer) As Long
Declare Sub write_encoder Lib "enclib32.dll" (ByVal com As Integer, ByVal chan As Integer, ByVal value As Long)
Declare Function enclib_callback Lib "enclib32.dll" (ByVal com As Integer, ByVal value As Long) As Integer

' Functions
Public Const NUM_AXES = 1
Public Const NUM_TIMERS = 2
Public Const NUM_INPUTS = 3
Public Const NUM_DACS = 4
Public Const NUM_OUTPUTS = 5
Public Const NUM_COLLISIONS = 6
Public Const NUM_BOARDS = 7
Public Const CARD_TYPE = 8
Public Const VERSION_NUM = 9
Public Const CNT16 = 10
Public Const MODE = 11
Public Const AXIS_SIZE = 12
Public Const ENCODER_TYPE = 13
Public Const AXIS_INPUTS = 14
Public Const AXIS_STATUS = 15
Public Const AXIS_OUT_EN = 16
Public Const NUM_CHANNELS_PER_BOARD = 19
Public Const MARK16 = 20
Public Const MARK_INPUT = 21
Public Const MARK_INT = 22
Public Const MARK_FUNC = 23
Public Const MARK_INT_VECT = 24
Public Const MARK_INT_OCCUR = 25
Public Const MARK_LATCH_SEL = 26
Public Const MARK_OUT_EN = 27
Public Const ZERO_INPUT = 30
Public Const ZERO_INT = 31
Public Const ZERO_FUNC = 32
Public Const ZERO_INT_VECT = 33
Public Const ZERO_INT_OCCUR = 34
Public Const AXIS_32 = 40
Public Const MARK_32 = 41
Public Const VEL_INST = 42
Public Const VEL_FILT = 43
Public Const ACCEL_INST = 44
Public Const ACCEL_FILT = 45
Public Const PROBE_32 = 46
Public Const ABSOLUTE_32 = 47
Public Const TIMER_32 = 48
Public Const OPTICAL_32 = 49
Public Const DIGITAL_INPUT = 50
Public Const TIMER = 60
Public Const TIMER_INT = 61
Public Const TIMER_INT_VECT = 62
Public Const TIMER_INT_OCCUR = 63
Public Const TIMER_LATCH_SEL = 64
Public Const TIMER1_FUNC = 65
Public Const TIMER_OUT_EN = 66
Public Const CODED_MARKER_PHASE = 75
Public Const CODED_MARKER_PERIOD = 76
Public Const CODED_MARKER_DELTA = 77
Public Const PROBE_16 = 90
Public Const PROBE_INPUT = 91
Public Const PROBE_INT = 92
Public Const PROBE_FUNC = 93
Public Const PROBE_INT_VECT = 94
Public Const PROBE_INT_OCCUR = 95
Public Const PROBE_SENSE = 96
Public Const PROBE_LED = 97
Public Const PROBE_SOUND = 98
Public Const PROBE_FOOTSWITCH = 99
Public Const PROBE_LATCH_SEL = 100
Public Const PROBE_OUT_EN = 101
Public Const TIMESTAMP_NOW = 110
Public Const TIMESTAMP_EVENT = 111
Public Const TIMESTAMP_SEL = 112
Public Const PULSEGEN0 = 120
Public Const PULSEGEN0_MODE = 121
Public Const PULSEGEN0_EN = 122
Public Const PULSEGEN0_OCCUR = 123
Public Const PULSEGEN0_OUT_EN = 124
Public Const PULSEGEN0_INT_VECT = 125
Public Const PULSEGEN0_TIME = 126
Public Const PULSEGEN0_SEQ_EN = 127
Public Const PULSEGEN0_TIMEOUT = 128
Public Const COMPARE0 = 130
Public Const COMPARE0_FUNC = 131
Public Const COMPARE0_OCCUR = 132
Public Const COMPARE0_OUT_EN = 133
Public Const COMPARE0_INT_VECT = 134
Public Const COMPARE1 = 135
Public Const COMPARE1_FUNC = 136
Public Const COMPARE1_OCCUR = 137
Public Const COMPARE1_INT_VECT = 139
Public Const USEREVENT0_OCCUR = 140
Public Const USEREVENT0_OUT_EN = 141
Public Const BOARD_INPUT_EN = 150
Public Const BOARD_INPUT_OCCUR = 151
Public Const BOARD_INPUT_INT_VECT = 152
Public Const AXIS_INPUT_EN = 155
Public Const AXIS_INPUT_OCCUR = 156
Public Const AXIS_INPUT_INT_VECT = 157
Public Const IO = 160
Public Const IO_DIR = 161
Public Const IO_32 = 165
Public Const IO_32_DIR = 166
Public Const NUM_IOS = 169
Public Const BUF_CLK_CHANNEL = 170
Public Const BUF_CLK_TYPE = 171
Public Const BUF_CLK_DIV = 172
Public Const BUF_NUM_DATA = 173
Public Const BUF_DATA_INDEX = 174
Public Const BUF_DATA_CHANNEL = 175
Public Const BUF_DATA_TYPE = 176
Public Const BUF_SIZE = 180
Public Const BUF_MODE = 181
Public Const BUF_EN = 182
Public Const BUF_FLUSH = 183
Public Const BUF_STATUS = 184
Public Const BUF_READ = 185
Public Const BUF_MEMFREE = 187
Public Const BUF_MAXDATA = 188
Public Const NUM_BUFFERS = 189
Public Const NUM_LOSTCALLBACKS = 200
Public Const OPTICAL_LIGHT_LEVEL = 210
Public Const OPTICAL_INPUT = 211
Public Const OPTICAL_FUNC = 213
Public Const OPTICAL_INT_OCCUR = 215
Public Const OPTICAL_TRIGGER_LEVEL = 220
Public Const OPTICAL_HYSTERESIS_LEVEL = 221
Public Const OPTICAL_GAIN = 222
Public Const OPTICAL_REF_LEVEL = 223
Public Const OPTICAL_REF_GAIN = 224
Public Const OPTICAL_REF_NOM_LEVEL = 225

'Axis exMODES
Public Const QUADx4AB = 5
Public Const CNTAx2DIRB = 8
Public Const CNTADIRB = 9

' Axis Mode
Public Const INC_MODE_MODE As Long = &HF
Public Const INC_MODE_INVA As Long = &H10
Public Const INC_MODE_INVB As Long = &H20
Public Const INC_MODE_INVM As Long = &H40
Public Const INC_MODE_INVZ As Long = &H80
Public Const INC_MODE_MSD As Long = &H100

Public Const SSI_MODE_LENGTH_ADJ As Long = &H1000000
Public Const SSI_MODE_FREQ_ADJ As Long = &H1
Public Const SSI_MODE_OFFSET_ADJ As Long = &H100
Public Const SSI_MODE_CHECK_ADJ As Long = &H1000
Public Const SSI_MODE_CODE_ADJ As Long = &H4000
Public Const SSI_MODE_OUT_ADJ As Long = &H8000
Public Const SSI_MODE_OPER_ADJ As Long = &H10000
Public Const SSI_MODE_RCIE_ADJ As Long = &H800000

Public Const SSI_MODE_LENGTH_MASK As Long = &H3F000000
Public Const SSI_MODE_FREQ_MASK As Long = &H7
Public Const SSI_MODE_OFFSET_MASK As Long = &HF00
Public Const SSI_MODE_CHECK_MASK As Long = &H3000
Public Const SSI_MODE_CODE_MASK As Long = &H4000
Public Const SSI_MODE_OUT_MASK As Long = &H8000
Public Const SSI_MODE_OPER_MASK As Long = &H70000
Public Const SSI_MODE_RCIE_MASK As Long = &H800000

Public Const SSI_MODE_OPER_ONESHOT = 0
Public Const SSI_MODE_OPER_TIMED = 1
Public Const SSI_MODE_OPER_CONTINUOUS = 2
Public Const SSI_MODE_OPER_CHANNEL_DI0 = 4

Public Const SSI_MODE_FREQ_2M50Hz = 0
Public Const SSI_MODE_FREQ_1M25Hz = 1
Public Const SSI_MODE_FREQ_625kHz = 2
Public Const SSI_MODE_FREQ_313kHz = 3
Public Const SSI_MODE_FREQ_156kHz = 4
Public Const SSI_MODE_FREQ_78k1Hz = 5

' Axis Inputs
Public Const INC_INPUT_A = &H1
Public Const INC_INPUT_B = &H2
Public Const INC_INPUT_M = &H4
Public Const INC_INPUT_Z = &H8
Public Const INC_INPUT_LIM0 = &H10
Public Const INC_INPUT_LIM1 = &H20

Public Const SSI_INPUT_DATA = &H1

' Axis Status
Public Const INC_STATUS_PWRF = &H1
Public Const INC_STATUS_QUADF = &H2
Public Const INC_STATUS_DATAL = &H4
Public Const INC_STATUS_DISCN = &H8

Public Const SSI_STATUS_PWRF = &H1
Public Const SSI_STATUS_PARF = &H2

' Timer Latch Selector
Public Const TLS_TIMER1_SYNCOCCUR = 0
Public Const TLS_READ_COUNTER = 1
Public Const TLS_PULSEGEN0_SYNCOCCUR = 2
Public Const TLS_USEREVENT0_OCCUR = 3

' Marker Latch Selector
Public Const MLS_MARKER_OCCUR = 0
Public Const MLS_ZERO_OCCUR = 1
Public Const MLS_PULSEGEN0_SYNCOCCUR = 2
Public Const MLS_USEREVENT0_OCCUR = 3
Public Const MLS_CHANNEL_DI0_OCCUR = 4
Public Const MLS_AXISCOMP0_SYNCOCCUR = 5
Public Const MLS_AXISCOMP1_SYNCOCCUR = 6

' Probe Latch Selector
Public Const PLS_PROBE_OCCUR = 0
Public Const PLS_READ_COUNTER = 1
Public Const PLS_PULSEGEN0_SYNCOCCUR = 2
Public Const PLS_USEREVENT0_OCCUR = 3
Public Const PLS_CHANNEL_DI0_OCCUR = 4
Public Const PLS_AXISCOMP0_SYNCOCCUR = 5
Public Const PLS_AXISCOMP1_SYNCOCCUR = 6

' Time-stamper Selector Definitions
Public Const TSTS_PROBE_OCCUR = 0
Public Const TSTS_TIMER1_SYNCOCCUR = 1
Public Const TSTS_USEREVENT0_OCCUR = 2
Public Const TSTS_BOARD_DI0_OCCUR = 3
Public Const TSTS_PULSEGEN0_SYNCOCCUR = 4
Public Const TSTS_AXISCOMP0_SYNCOCCUR = 5
Public Const TSTS_AXISCOMP1_SYNCOCCUR = 6

' Pulse Generator Mode
Public Const PULSEGEN_MODE_DIR = &H1
Public Const PULSEGEN_MODE_BIDIR = &H2
Public Const PULSEGEN_MODE_HWCTRL = &H4
Public Const PULSEGEN_MODE_DEGLCH = &H8

Public Const PULSEGEN_MODE_DIR_NEG = 0
Public Const PULSEGEN_MODE_DIR_POS = 1

' Buffer Mode
Public Const BUF_MODE_LOG = &H1
Public Const BUF_MODE_LOG_DISCARDNEWDATA = 0
Public Const BUF_MODE_LOG_DISCARDOLDDATA = 1

' Buffer Clock Type
Public Const BUF_CLK_TIMER_OCCUR = 0
Public Const BUF_CLK_PROBE_OCCUR = 1
Public Const BUF_CLK_BOARD_DI0_OCCUR = 2
Public Const BUF_CLK_USEREVENT0_OCCUR = 3
Public Const BUF_CLK_MARKER_OCCUR = 16
Public Const BUF_CLK_ZERO_OCCUR = 17
Public Const BUF_CLK_PULSEGEN0_OCCUR = 18
Public Const BUF_CLK_AXISCOMP0_OCCUR = 19
Public Const BUF_CLK_AXISCOMP1_OCCUR = 20
Public Const BUF_CLK_CHAN_DI0_OCCUR = 21
Public Const BUF_CLK_SSI_READ_COMPLETE_OCCUR = 22

' Buffer Data Type
Public Const BUF_DATA_BUFFER_CLOCK_COUNTER = 0
Public Const BUF_DATA_TIMESTAMP_NOW = 1
Public Const BUF_DATA_TIMESTAMP_EVENT = 2
Public Const BUF_DATA_IO_32 = 3
Public Const BUF_DATA_TIMER_LATCH = 16
Public Const BUF_DATA_SSI_LATCH = 16
Public Const BUF_DATA_MARKER_LATCH = 17
Public Const BUF_DATA_PROBE_LATCH = 18
Public Const BUF_DATA_AXIS_32 = 19
