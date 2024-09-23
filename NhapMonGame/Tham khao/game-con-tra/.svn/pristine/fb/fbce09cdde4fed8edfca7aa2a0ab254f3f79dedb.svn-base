#ifndef __CVIEW_H__
#define __CVIEW_H__

#pragma once
#include "CSingleton.h"
#include "CGlobal.h"

class CView : public CSingleton<CView> 
{
	friend class CSingleton<CView>;
protected:
	CView() : m_isFullScreen(false) {};
public:
	bool InitClienWindow();
	bool m_isFullScreen;
	static HWND m_hwndWindow;
	static HINSTANCE m_hInstance;
	static LRESULT CALLBACK WndProc( HWND hwnd, UINT message, WPARAM wparam, LPARAM lparam );
};

#endif // !__CVIEW_H__
