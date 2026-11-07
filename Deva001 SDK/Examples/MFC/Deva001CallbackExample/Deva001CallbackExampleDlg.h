
// Deva001CallbackExampleDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CDeva001CallbackExampleDlg dialog
class CDeva001CallbackExampleDlg : public CDialogEx
{
// Construction
public:
	CDeva001CallbackExampleDlg(CWnd* pParent = NULL);	// standard constructor
	~CDeva001CallbackExampleDlg();	// standard destructor

// Dialog Data
	enum { IDD = IDD_DEVA001CALLBACKEXAMPLE_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	virtual void OnTimer(UINT_PTR nIDEvent);
	DECLARE_MESSAGE_MAP()
public:
	CEdit m_StatusEdit;
private:
	UINT_PTR m_TimerId;
	double m_dAxisValues[9];
	double m_dLastAxisValues[9];
	CEdit *m_pAxisDialogs[9];
	CString StatusString;
	double m_dLostCallbacks;
	double m_dLastLostCallbacks;
public:
	CEdit m_xPositionEditBox;
	CEdit m_yPositionEditBox;
	CEdit m_zPositionEditBox;
	CEdit m_xProbeEditBox;
	CEdit m_yProbeEditBox;
	CEdit m_zProbeEditBox;
	CEdit m_xMarkerEditBox;
	CEdit m_yMarkerEditBox;
	CEdit m_zMarkerEditBox;
	afx_msg void OnProbeClicked();
	CButton m_ProbeCheckBox;
	CButton m_MarkerCheckBox;
	afx_msg void OnMarkerClicked();
	afx_msg void OnTimerCLicked();
	CButton m_TimerCheckBox;
	CEdit m_LostCallbacksEditBox;
	void AddStatusString(LPCTSTR pText);
};
