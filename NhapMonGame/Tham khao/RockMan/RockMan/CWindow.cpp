#include "CWindow.h"

CWindow* CWindow::_pInstance = NULL;

CWindow::CWindow(){
	this->_hInstance=nullptr;
	this->_hwnd=nullptr;
}

int CWindow::Init(HINSTANCE hInstance)
{
	this->_hInstance = hInstance;

	WNDCLASSEX wc;
	wc.cbSize = sizeof(WNDCLASSEX); 

	//fill the struct with info
	wc.style         = CS_HREDRAW | CS_VREDRAW;
	wc.lpfnWndProc = (WNDPROC)CWindow::WinProc;
	wc.cbClsExtra	 = 0;
	wc.cbWndExtra	 = 0;
	wc.hInstance     = this->_hInstance;
	wc.hIcon         = NULL;
	wc.hCursor       = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName  = NULL;
	wc.lpszClassName = APP_TITLE;
	wc.hIconSm       = NULL;

	//set up the window with the class info
	RegisterClassEx(&wc);

	DWORD style;
	style = WS_OVERLAPPED | WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
	this->_hwnd = CreateWindow(
		APP_TITLE,
		APP_TITLE,
		style,
		CW_USEDEFAULT,
		CW_USEDEFAULT,
		2.0f*SCREEN_WIDTH,
		2.0f*SCREEN_HEIGHT,
		NULL,
		NULL,
		this->_hInstance,
		NULL);

	if(!(this->_hwnd))
	{
		MessageBox(NULL,L"Khong Khoi Tao Windows",L"Loi CreateWindows",MB_OK);
		return 0;
	}

	ShowWindow(this->_hwnd,SW_NORMAL); //?????? _isFullScreen
	UpdateWindow(this->_hwnd);

	return 1;
}

CWindow::~CWindow()
{
	if(this->_hInstance != nullptr)
		delete this->_hInstance;
	this->_hInstance = nullptr;

	if(this->_hwnd != nullptr)
		delete this->_hwnd;
	this->_hwnd = nullptr;

	if(this->_pInstance != nullptr)
		delete this->_pInstance;
	this->_pInstance = nullptr;

}

LRESULT CALLBACK CWindow::WinProc(HWND hWnd,UINT msg,WPARAM wParam,LPARAM lParam)
{
	switch(msg)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hWnd,msg,wParam,lParam);
}

CWindow* CWindow::GetInstance()
{
	if(_pInstance==nullptr)
		_pInstance=new CWindow();

	return _pInstance;
}

HWND CWindow::GetHWND()
{
	return this->_hwnd;
}