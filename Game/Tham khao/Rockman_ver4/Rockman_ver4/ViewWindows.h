#pragma once
#ifndef __CVIEW_H__
#define __CVIEW_H__

#include "Include.h"
#include "CSingleton.h"
#include "CGlobal.h"
class CViewWindows : public CSingleton<CViewWindows>
{
public:
	~CViewWindows();
	friend class CSingleton<CViewWindows>;
protected:
	CViewWindows() : m_isFullScreen(false) {};
public:
	bool InitClienWindow();
	bool m_isFullScreen;
	static HWND m_hwndWindow;
	static HINSTANCE m_hInstance;
	static LRESULT CALLBACK WndProc(HWND hwnd, UINT message, WPARAM wparam, LPARAM lparam);
};

#endif // !__CVIEW_H__
