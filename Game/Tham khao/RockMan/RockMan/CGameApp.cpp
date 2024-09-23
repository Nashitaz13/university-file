#include "CGameApp.h"

CGameApp::CGameApp(HINSTANCE hInstance, int isFullScreen)
{
	// Khởi tạo đối tượng cửa sổ window
	if (CWindow::GetInstance()->Init(hInstance) == 0)
	{
		MessageBox(NULL, L"Lỗi không khởi tạo được cửa sổ", L"Lỗi khởi tạo", MB_OK);
		return;
	}

	HWND hwnd = CWindow::GetInstance()->GetHWND();

	// Khởi tạo các đối tượng DirectX
	if (CGraphics::GetInstance()->Init(hwnd) == 0)
	{
		MessageBox(NULL, L"Lỗi không khởi tạo được các đối tượng DirecX", L"Lỗi khởi tạo", MB_OK);
		return;
	}

	// Khởi tạo đối tượng đếm thời gian 
	this->_gameTime = new CGameTime(FRAME_PER_SECOND);

	//Khởi tạo Resource
	if (ResourceManager::Init(hwnd) == 0)
	{
		MessageBox(NULL, L"Lỗi không khởi tạo được các đối tượng Sound", L"Lỗi khởi tạo", MB_OK);
		return;
	}

	// Load thông tin game
	CGameInfo::GetInstance()->Load();

	// Khởi tạo đối tượng quản lý màn hình
	CScreenManager::GetInstance()->SetStartScreen(new CGameStart());

	// Khởi tạo Keyboard
	if (CInput::GetInstance()->InitInput(hInstance, hwnd) == 0)
	{
		MessageBox(NULL, L"Lỗi không khởi tạo được các đối tượng Input", L"Lỗi khởi tạo", MB_OK);
		return;
	}

}

CGameApp::~CGameApp()
{
	if (CGraphics::GetInstance() != nullptr)
		CGraphics::GetInstance()->~CGraphics();

	if (CWindow::GetInstance() != nullptr)
		CWindow::GetInstance()->~CWindow();

	SAFE_DELETE(this->_gameTime);
};

void CGameApp::Run()
{
	MSG msg;
	bool done = false;

	while (!done)
	{
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			if (msg.message == WM_QUIT)
				done = true;
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
		_gameTime->Update();
		CInput::GetInstance()->Update(CWindow::GetInstance()->GetHWND());
		if (_gameTime->AvailableNextFrame())
		{
			if (CInput::GetInstance()->IsKeyDown(DIK_A))
			{
				CGameObject::IsDebugMode = !CGameObject::IsDebugMode;
			}
			if (CInput::GetInstance()->IsKeyDown(DIK_M))
			{
				ResourceManager::IsPlaySound = !ResourceManager::IsPlaySound;
				if (ResourceManager::IsPlaySound)
					ResourceManager::ReplaySound();
				else
				{
					ResourceManager::MuteSound();
				}
			}
			CScreenManager::GetInstance()->UpdateInput(CInput::GetInstance());
			CScreenManager::GetInstance()->Update(_gameTime);
			CScreenManager::GetInstance()->Render(_gameTime, CGraphics::GetInstance());
			CInput::GetInstance()->SaveKeyStateHistory();
		}
	}
}