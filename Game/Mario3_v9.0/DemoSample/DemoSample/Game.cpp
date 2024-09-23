#include "Game.h"
#include "Input.h"

CGame::CGame(HINSTANCE _hInstance)
{
	_d3d = NULL;
	_BackBuffer = NULL;
	HInstance = _hInstance;
}

void CGame::_InitWindow()
{
//	glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
	WNDCLASSEX wc;
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = CS_HREDRAW | CS_VREDRAW;
	wc.hInstance = HInstance;
	wc.lpfnWndProc = (WNDPROC)CGame::_WinProc;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hIcon = NULL;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = (LPCSTR)Name;
	wc.hIconSm = NULL;

	RegisterClassEx(&wc);

	HWnd =
		CreateWindow(
			(LPCSTR)Name,
			(LPCSTR)Name,
			WS_OVERLAPPEDWINDOW,
			CW_USEDEFAULT,
			CW_USEDEFAULT,
			640,		//	_ScreenWidth,
			480,		//	_ScreenHeight,
			NULL,
			NULL,
			HInstance,
			NULL);

	ShowWindow(HWnd, SW_SHOWNORMAL);
	UpdateWindow(HWnd);
}


void CGame::_InitDirectX()
{
	_d3d = Direct3DCreate9(D3D_SDK_VERSION);
	D3DPRESENT_PARAMETERS d3dpp;
	ZeroMemory(&d3dpp, sizeof(d3dpp));

	d3dpp.Windowed = TRUE;
	d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
	d3dpp.BackBufferFormat = _BackBufferFormat;
	d3dpp.BackBufferCount = 1;
	d3dpp.BackBufferHeight = _ScreenHeight;
	d3dpp.BackBufferWidth = _ScreenWidth;

	_d3d->CreateDevice(
		D3DADAPTER_DEFAULT,
		D3DDEVTYPE_HAL,
		HWnd,
		D3DCREATE_SOFTWARE_VERTEXPROCESSING,
		&d3dpp,
		&D3ddv);

	D3DXCreateSprite(D3ddv, &SpriteHandler);
	D3ddv->GetBackBuffer(0, 0, D3DBACKBUFFER_TYPE_MONO, &_BackBuffer);
}


void CGame::Init()
{
	_InitWindow();
	_InitDirectX();
	IniInput();
	iniSprite();
}


void CGame::RenderFrame()
{
	D3ddv->ColorFill(_BackBuffer, NULL, D3DCOLOR_XRGB(0, 0, 0));
}


void CGame::_RenderFrame()
{
	if (D3ddv->BeginScene())
	{
		RenderFrame();
		D3ddv->EndScene();
	}
	D3ddv->Present(NULL, NULL, NULL, NULL);
}

// Main game message loop
void CGame::Run()
{
	MSG msg;
	int done = 0;
	DWORD frame_start = GetTickCount();
	DWORD tick_per_frame = 100 / FrameRate;

	while (!done)
	{
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			if (msg.message == WM_QUIT) done = 1;

			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}

		DWORD now = GetTickCount();
		DeltaTime = now - frame_start;
		input->Update();
		if (DeltaTime >= tick_per_frame)
		{
			frame_start = now;
			// bat buoc phai de trong if nay, khong duoc de ngoai nhu version cu
			// de trong khoi if nay moi su dung duoc delta time
			Update();
			_RenderFrame();
			input->SaveKeyStateHistory();
		}
	}
}


void CGame::Update()
{
}


CGame::~CGame()
{
	if (D3ddv != NULL) D3ddv->Release();
	if (_d3d != NULL) _d3d->Release();
}


LRESULT CALLBACK CGame::_WinProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}

	return 0;
}
