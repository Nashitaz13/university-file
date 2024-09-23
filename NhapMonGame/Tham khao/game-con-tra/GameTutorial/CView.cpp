#include "CView.h"

HWND CView::m_hwndWindow = nullptr;
HINSTANCE CView::m_hInstance = nullptr;

bool CView::InitClienWindow()
{
		WNDCLASSEX wc;
	wc.cbSize = sizeof(WNDCLASSEX);

	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.hInstance = CView::m_hInstance;

	wc.lpfnWndProc = (WNDPROC)CView::WndProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hIcon = NULL;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = __CLASS_NAME;
	wc.hIconSm = NULL;

	RegisterClassEx(&wc);

	CView::m_hwndWindow = 
		CreateWindow(
		__CLASS_NAME,
		__CLASS_NAME,
		WS_OVERLAPPEDWINDOW, 
		CW_USEDEFAULT,
		CW_USEDEFAULT, 
		__SCREEN_WIDTH,
		__SCREEN_HEIGHT,
		NULL,
		NULL,
		CView::m_hInstance,
		NULL);
	if (!CView::m_hwndWindow) 
	{ 
		return false;
	}

	ShowWindow(CView::m_hwndWindow,SW_SHOWNORMAL);
	UpdateWindow(CView::m_hwndWindow);

	return true;
}

LRESULT CALLBACK CView::WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message) 
	{
		case WM_DESTROY: 
			PostQuitMessage(0);
			break;
		default: 
			return DefWindowProc(hWnd, message, wParam,lParam);
	}

	return 0;
}