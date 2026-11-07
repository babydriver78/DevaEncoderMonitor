// win32 msvc example1Dlg.cpp : implementation file
//

#include "stdafx.h"
#include "msvc example1.h"
#include "msvc example1Dlg.h"
#include "enclib.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CWin32msvcexample1Dlg dialog

CWin32msvcexample1Dlg::CWin32msvcexample1Dlg(CWnd* pParent /*=NULL*/)
	: CDialog(CWin32msvcexample1Dlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CWin32msvcexample1Dlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CWin32msvcexample1Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CWin32msvcexample1Dlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CWin32msvcexample1Dlg, CDialog)
	//{{AFX_MSG_MAP(CWin32msvcexample1Dlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_WM_DESTROY()
	ON_WM_TIMER()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWin32msvcexample1Dlg message handlers

BOOL CWin32msvcexample1Dlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
		// 	test is there granted access to encoder
	if(open_encoder()==0)
	{
		SetWindowText("DEVA001 Visual C++ example Version 1");
		SetTimer(1,500,NULL);
	}	
	else
		SetWindowText("Failed to access DEVA001 device");
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CWin32msvcexample1Dlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

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
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CWin32msvcexample1Dlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CWin32msvcexample1Dlg::OnDestroy() 
{
	CDialog::OnDestroy();
	
	// TODO: Add your message handler code here
	
	// Close encoder access as Window is closing
	close_encoder();

}

void CWin32msvcexample1Dlg::OnTimer(UINT_PTR nIDEvent) 
{
	// TODO: Add your message handler code here and/or call default
	char str[80];

	// Read encoder on Channel 0 and copy string to Label IDC_READING
	sprintf_s(str,80,"%ld",read_encoder(AXIS_32,0));
	SetDlgItemText(IDC_READING,str);
	
	// Call Default Function
	CDialog::OnTimer(nIDEvent);
}
