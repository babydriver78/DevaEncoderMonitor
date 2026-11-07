
// Deva001CallbackExampleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "..\..\..\enclib.h"
#include "Deva001CallbackExample.h"
#include "Deva001CallbackExampleDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

extern void _stdcall Marker0_callback(void);
extern void _stdcall Marker1_callback(void);
extern void _stdcall Marker2_callback(void);
extern void _stdcall Probe_callback(void);
extern void _stdcall Timer0_callback(void);
extern void _stdcall Timer1_callback(void);
extern void _stdcall Comparex0_callback(void);
extern void _stdcall Comparex1_callback(void);
extern void _stdcall Comparey0_callback(void);
extern void _stdcall Comparey1_callback(void);
extern void _stdcall Comparez0_callback(void);
extern void _stdcall Comparez1_callback(void);

CDeva001CallbackExampleDlg *g_pMainDlg = NULL;

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CDeva001CallbackExampleDlg dialog
CDeva001CallbackExampleDlg::CDeva001CallbackExampleDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDeva001CallbackExampleDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
	m_TimerId = -1;
	StatusString = "";
	g_pMainDlg = this;
}

CDeva001CallbackExampleDlg::~CDeva001CallbackExampleDlg()
{
	if (m_TimerId != -1)
	{
		KillTimer(m_TimerId);
	}
	enclib_callback(0,0);
	close_encoder();
}

void CDeva001CallbackExampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STATUS_EDIT, m_StatusEdit);
	DDX_Control(pDX, IDC_X_POSITION_EDIT, m_xPositionEditBox);
	DDX_Control(pDX, IDC_Y_POSITION_EDIT, m_yPositionEditBox);
	DDX_Control(pDX, IDC_Z_POSITION_EDIT4, m_zPositionEditBox);
	DDX_Control(pDX, IDC_X_PROBE_EDIT, m_xProbeEditBox);
	DDX_Control(pDX, IDC_Y_PROBE_EDIT, m_yProbeEditBox);
	DDX_Control(pDX, IDC_Z_PROBE_EDIT, m_zProbeEditBox);
	DDX_Control(pDX, IDC_X_MARKER_EDIT, m_xMarkerEditBox);
	DDX_Control(pDX, IDC_Y_MARKER_EDIT, m_yMarkerEditBox);
	DDX_Control(pDX, IDC_Z_MARKER_EDIT, m_zMarkerEditBox);
	DDX_Control(pDX, IDC_PROBE_CHECK, m_ProbeCheckBox);
	DDX_Control(pDX, IDC_MARKER_CHECK, m_MarkerCheckBox);
	DDX_Control(pDX, IDC_TIMER_CHECK, m_TimerCheckBox);
	DDX_Control(pDX, IDC_LOST_CALLBACKS_EDIT1, m_LostCallbacksEditBox);
}

BEGIN_MESSAGE_MAP(CDeva001CallbackExampleDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_TIMER()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_PROBE_CHECK, &CDeva001CallbackExampleDlg::OnProbeClicked)
	ON_BN_CLICKED(IDC_MARKER_CHECK, &CDeva001CallbackExampleDlg::OnMarkerClicked)
	ON_BN_CLICKED(IDC_TIMER_CHECK, &CDeva001CallbackExampleDlg::OnTimerCLicked)
END_MESSAGE_MAP()


// CDeva001CallbackExampleDlg message handlers

BOOL CDeva001CallbackExampleDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	for (int i = 0;i < 9;i++)
	{
		m_dAxisValues[i] = 0.0;
		m_dLastAxisValues[i] = -1.0;
	}
	m_pAxisDialogs[0] = &m_xPositionEditBox;
	m_pAxisDialogs[1] = &m_yPositionEditBox;
	m_pAxisDialogs[2] = &m_zPositionEditBox;
	m_pAxisDialogs[3] = &m_xProbeEditBox;
	m_pAxisDialogs[4] = &m_yProbeEditBox;
	m_pAxisDialogs[5] = &m_zProbeEditBox;
	m_pAxisDialogs[6] = &m_xMarkerEditBox;
	m_pAxisDialogs[7] = &m_yMarkerEditBox;
	m_pAxisDialogs[8] = &m_zMarkerEditBox;
	m_dLostCallbacks = 0.0;
	m_dLastLostCallbacks = -1.0;

	if (open_encoder())
	{
		MessageBox(TEXT("open_encoder failed"),TEXT("Load Error"),MB_OK);
		PostMessage(WM_CLOSE,0,0);
		return TRUE;
	}
	if (enclib_callback(1,THREAD_PRIORITY_TIME_CRITICAL))
	{
		AddStatusString(TEXT("enclib_callback failed to enable callbacks!\r\n"));
	}
	else		// we have enabled callbacks so now enable the sources
	{
#if !defined(_WIN64)
		write_encoder(MARK_INT_VECT,0,(long)&Marker0_callback);
		write_encoder(MARK_INT_VECT,1,(long)&Marker1_callback);
		write_encoder(MARK_INT_VECT,2,(long)&Marker2_callback);
		write_encoder(PROBE_INT_VECT,0,(long)&Probe_callback);

		if (read_encoder(MARK_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Marker0_Callback\r\n"));
		}
		if (read_encoder(MARK_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Marker1_Callback\r\n"));
		}
		if (read_encoder(MARK_INT_VECT,2) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Marker2_Callback\r\n"));
		}
		if (read_encoder(PROBE_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Probe_Callback\r\n"));
		}
		write_encoder(COMPARE0_INT_VECT,0,(long)&Comparex0_callback);
		write_encoder(COMPARE1_INT_VECT,0,(long)&Comparex1_callback);
		write_encoder(COMPARE0_FUNC,0,1);
		write_encoder(COMPARE1_FUNC,0,1);
		write_encoder(COMPARE0,0,0);
		write_encoder(COMPARE1,0,10000);
		write_encoder(COMPARE0_INT_VECT,1,(long)&Comparey0_callback);
		write_encoder(COMPARE1_INT_VECT,1,(long)&Comparey1_callback);
		write_encoder(COMPARE0_FUNC,1,1);
		write_encoder(COMPARE1_FUNC,1,1);
		write_encoder(COMPARE0,1,5000);
		write_encoder(COMPARE1,1,0);
		write_encoder(COMPARE0_INT_VECT,2,(long)&Comparez0_callback);
		write_encoder(COMPARE1_INT_VECT,2,(long)&Comparez1_callback);
		write_encoder(COMPARE0_FUNC,2,1);
		write_encoder(COMPARE1_FUNC,2,1);
		write_encoder(COMPARE0,2,0);
		write_encoder(COMPARE1,2,7500);
		if (read_encoder(COMPARE0_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparex0_Callback\r\n"));
		}
		if (read_encoder(COMPARE1_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparex1_Callback\r\n"));
		}
		if (read_encoder(COMPARE0_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparey0_Callback\r\n"));
		}
		if (read_encoder(COMPARE1_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparey1_Callback\r\n"));
		}
		if (read_encoder(COMPARE0_INT_VECT,2) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparez0_Callback\r\n"));
		}
		if (read_encoder(COMPARE1_INT_VECT,2) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparez1_Callback\r\n"));
		}
#else
		write_encoder64(MARK_INT_VECT,0,(long long)&Marker0_callback);
		write_encoder64(MARK_INT_VECT,1,(long long)&Marker1_callback);
		write_encoder64(MARK_INT_VECT,2,(long long)&Marker2_callback);
		write_encoder64(PROBE_INT_VECT,0,(long long)&Probe_callback);

		if (read_encoder64(MARK_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Marker0_Callback\r\n"));
		}
		if (read_encoder64(MARK_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Marker1_Callback\r\n"));
		}
		if (read_encoder64(MARK_INT_VECT,2) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Marker2_Callback\r\n"));
		}
		if (read_encoder64(PROBE_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Probe_Callback\r\n"));
		}
		write_encoder64(COMPARE0_INT_VECT,0,(long long)&Comparex0_callback);
		write_encoder64(COMPARE1_INT_VECT,0,(long long)&Comparex1_callback);
		write_encoder(COMPARE0_FUNC,0,1);
		write_encoder(COMPARE1_FUNC,0,1);
		write_encoder(COMPARE0,0,0);
		write_encoder(COMPARE1,0,10000);
		write_encoder64(COMPARE0_INT_VECT,1,(long long)&Comparey0_callback);
		write_encoder64(COMPARE1_INT_VECT,1,(long long)&Comparey1_callback);
		write_encoder(COMPARE0_FUNC,1,1);
		write_encoder(COMPARE1_FUNC,1,1);
		write_encoder(COMPARE0,1,5000);
		write_encoder(COMPARE1,1,0);
		write_encoder64(COMPARE0_INT_VECT,2,(long long)&Comparez0_callback);
		write_encoder64(COMPARE1_INT_VECT,2,(long long)&Comparez1_callback);
		write_encoder(COMPARE0_FUNC,2,1);
		write_encoder(COMPARE1_FUNC,2,1);
		write_encoder(COMPARE0,2,0);
		write_encoder(COMPARE1,2,7500);
		if (read_encoder64(COMPARE0_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparex0_Callback\r\n"));
		}
		if (read_encoder64(COMPARE1_INT_VECT,0) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparex1_Callback\r\n"));
		}
		if (read_encoder64(COMPARE0_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparey0_Callback\r\n"));
		}
		if (read_encoder64(COMPARE1_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparey1_Callback\r\n"));
		}
		if (read_encoder64(COMPARE0_INT_VECT,2) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparez0_Callback\r\n"));
		}
		if (read_encoder64(COMPARE1_INT_VECT,2) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Comparez1_Callback\r\n"));
		}
#endif
	}
	m_TimerId = SetTimer(1,10,NULL);
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CDeva001CallbackExampleDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CDeva001CallbackExampleDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CDeva001CallbackExampleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

void CDeva001CallbackExampleDlg::OnTimer(UINT_PTR nIDEvent)
{
	for (int i = 0;i < 3;i++)
	{
		m_dAxisValues[i] = read_encoder(AXIS_32,i);
		m_dAxisValues[3 + i] = read_encoder(PROBE_32,i);
		m_dAxisValues[6 + i] = read_encoder(MARK_32,i);
	}
	m_dLostCallbacks = read_encoder(NUM_LOSTCALLBACKS,0);
	for (int i = 0;i < 9;i++)
	{
		if (m_dAxisValues[i] != m_dLastAxisValues[i])
		{
			TCHAR Text[80];
			_stprintf_s(Text,79,TEXT("%3.3lf"),m_dAxisValues[i]);
			m_pAxisDialogs[i]->SetWindowText(Text);
			m_dLastAxisValues[i] = m_dAxisValues[i];
		}
	}
	if (m_dLostCallbacks != m_dLastLostCallbacks)
	{
		TCHAR Text[80];
		_stprintf_s(Text,79,TEXT("%3.3lf"),m_dLostCallbacks);
		m_LostCallbacksEditBox.SetWindowText(Text);
		m_dLastLostCallbacks = m_dLostCallbacks;
	}
	CDialog::OnTimer(nIDEvent);
}


void CDeva001CallbackExampleDlg::OnProbeClicked()
{
	long lVal = m_ProbeCheckBox.GetCheck();
	write_encoder(PROBE_FUNC,0,lVal);
}


void CDeva001CallbackExampleDlg::OnMarkerClicked()
{
	long lVal = m_MarkerCheckBox.GetCheck();
	for (int i = 0;i < 3;i++)
	{
		write_encoder(MARK_FUNC,i,lVal);
	}
}


void CDeva001CallbackExampleDlg::OnTimerCLicked()
{
	long lVal = m_TimerCheckBox.GetCheck();
	if (lVal)
	{
#if !defined(_WIN64)
		write_encoder(TIMER_INT_VECT,1,(long)&Timer1_callback);
		if (read_encoder(TIMER_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Timer1_Callback\r\n"));
		}
#else
		write_encoder64(TIMER_INT_VECT,1,(long long)&Timer1_callback);
		if (read_encoder64(TIMER_INT_VECT,1) == 0)
		{
			AddStatusString(TEXT("enclib_callback failed to enable Timer1_Callback\r\n"));
		}
#endif
		write_encoder(TIMER_INT,1,1);
		write_encoder(TIMER,1,255);
	}
	else
	{
#if !defined(_WIN64)
		write_encoder(TIMER_INT_VECT,1,(long)NULL);
#else
		write_encoder64(TIMER_INT_VECT,1,(long long)NULL);
#endif
		write_encoder(TIMER_INT,1,0);
		write_encoder(TIMER,1,0);
	}
}

void CDeva001CallbackExampleDlg::AddStatusString(LPCTSTR pText)
{
	StatusString += pText;
	while (StatusString.GetLength() > 0x2000)
	{
		CString NewString;
		int nIndex = StatusString.Find(TEXT("\r\n"));
		NewString = StatusString.Right(StatusString.GetLength() - nIndex - 2);
		StatusString = NewString;
	}
	m_StatusEdit.SetWindowText(StatusString);
	m_StatusEdit.LineScroll(m_StatusEdit.GetLineCount());
}

void _stdcall Marker0_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Marker0_callback occurred\r\n"));
	}
}

void _stdcall Marker1_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Marker1_callback occurred\r\n"));
	}
}

void _stdcall Marker2_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Marker2_callback occurred\r\n"));
	}
}

void _stdcall Probe_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Probe_callback occurred\r\n"));
	}
}

void _stdcall Timer0_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Timer0_callback occurred\r\n"));
	}
}

void _stdcall Timer1_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Timer1_callback occurred\r\n"));
	}
}

void _stdcall Comparex0_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Comparex0_callback occurred\r\n"));
	}
}

void _stdcall Comparex1_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Comparex1_callback occurred\r\n"));
	}
}
void _stdcall Comparey0_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Comparey0_callback occurred\r\n"));
	}
}

void _stdcall Comparey1_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Comparey1_callback occurred\r\n"));
	}
}
void _stdcall Comparez0_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Comparez0_callback occurred\r\n"));
	}
}

void _stdcall Comparez1_callback(void)
{
	if (g_pMainDlg)
	{
		g_pMainDlg->AddStatusString(TEXT("Comparez1_callback occurred\r\n"));
	}
}
