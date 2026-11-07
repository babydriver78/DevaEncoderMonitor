// win32 msvc example1.h : main header file for the WIN32 MSVC EXAMPLE1 application
//

#if !defined(AFX_WIN32MSVCEXAMPLE1_H__F69F3119_ABE0_11D4_9A8E_0050048699BC__INCLUDED_)
#define AFX_WIN32MSVCEXAMPLE1_H__F69F3119_ABE0_11D4_9A8E_0050048699BC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CWin32msvcexample1App:
// See win32 msvc example1.cpp for the implementation of this class
//

class CWin32msvcexample1App : public CWinApp
{
public:
	CWin32msvcexample1App();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWin32msvcexample1App)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CWin32msvcexample1App)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_WIN32MSVCEXAMPLE1_H__F69F3119_ABE0_11D4_9A8E_0050048699BC__INCLUDED_)
