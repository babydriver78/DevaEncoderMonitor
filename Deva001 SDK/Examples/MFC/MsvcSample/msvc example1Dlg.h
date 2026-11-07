// win32 msvc example1Dlg.h : header file
//

#if !defined(AFX_WIN32MSVCEXAMPLE1DLG_H__F69F311B_ABE0_11D4_9A8E_0050048699BC__INCLUDED_)
#define AFX_WIN32MSVCEXAMPLE1DLG_H__F69F311B_ABE0_11D4_9A8E_0050048699BC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CWin32msvcexample1Dlg dialog

class CWin32msvcexample1Dlg : public CDialog
{
// Construction
public:
	CWin32msvcexample1Dlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CWin32msvcexample1Dlg)
	enum { IDD = IDD_WIN32MSVCEXAMPLE1_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWin32msvcexample1Dlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CWin32msvcexample1Dlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnDestroy();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_WIN32MSVCEXAMPLE1DLG_H__F69F311B_ABE0_11D4_9A8E_0050048699BC__INCLUDED_)
