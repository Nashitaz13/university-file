#include "CInput.h"

CInput* CInput::_pInstance = NULL;

CInput::CInput()
{
	_isActive = true;
}

CInput::~CInput()
{}

int CInput::InitInput(HINSTANCE hInstance, HWND hwnd)
{
	if (this->InitInputDirect(hInstance) == 0)
	{
		MessageBox(NULL, L"Lỗi không khởi tạo được đối tượng InputDirectX", L"Lỗi khởi tạo", MB_OK);
		return 0;
	}

	if (this->InitKeyboard(hwnd) == 0)
	{
		MessageBox(NULL, L"Lỗi không khởi tạo được đối tượng Keyboard DirectX", L"Lỗi khởi tạo", MB_OK);
		return 0;
	}

	return 1;
}

int CInput::InitInputDirect(HINSTANCE hInstance)
{
	HRESULT result;

	result = DirectInput8Create(hInstance, DIRECTINPUT_VERSION, IID_IDirectInput8, (VOID**)&_directInput, NULL);
	if (result != DI_OK) return 0;
	Trace(L"DirectInput has been created");

	result = _directInput->CreateDevice(GUID_SysKeyboard, &_keyBoard, NULL);
	if (result != DI_OK) return 0;
	Trace(L"DirectInput keyboard has been created");

	return 1;
}

int CInput::InitKeyboard(HWND hWnd)
{
	HRESULT result;

	result = _keyBoard->SetDataFormat(&c_dfDIKeyboard);
	if (result != DI_OK) return 0;
	Trace(L"SetDataFormat for keyboard successfully");

	result = _keyBoard->SetCooperativeLevel(hWnd, DISCL_FOREGROUND | DISCL_NONEXCLUSIVE);
	if (result != DI_OK) return 0;
	Trace(L"SetCooperativeLevel for keyboard successfully");

	DIPROPDWORD dipdw;
	dipdw.diph.dwSize = sizeof(DIPROPDWORD);
	dipdw.diph.dwHeaderSize = sizeof(DIPROPHEADER);
	dipdw.diph.dwObj = 0;
	dipdw.diph.dwHow = DIPH_DEVICE;
	dipdw.dwData = KEYBOARD_BUFFER_SIZE;

	_keyBoard->SetProperty(DIPROP_BUFFERSIZE, &dipdw.diph);
	if (result != DI_OK) return 0;
	Trace(L"SetProperty for keyboard successfully");

	result = _keyBoard->Acquire();
	if (result != DI_OK) return 0;
	Trace(L"Keyboard has been acquired successfully");

	return 1;
}

CInput* CInput::GetInstance()
{
	if (_pInstance == NULL)
		_pInstance = new CInput();

	return _pInstance;
}

void CInput::Update(HWND hWnd)
{
	//Lấy trạng thái của bàn phím
	_keyBoard->Poll();
	if (!SUCCEEDED(_keyBoard->GetDeviceState(256, (LPVOID)&_keyStates)))
	{
		//Nếu bàn phím không được focus thì yêu cầu lại
		_keyBoard->Acquire();
	}

	if (this->IsKeyDown(DIK_ESCAPE))
	{
		Trace(L"Escape key pressed! Exiting game.");
		PostMessage(hWnd, WM_QUIT, 0, 0);
	}
}

int CInput::IsKeyDown(int keyCode)
{
	if (_isActive)
	{
		if ((_keyStates[keyCode] & 0x80) != 0)
		{
			if ((_preKeyStates[keyCode] & 0x80) == 0)
				return true;
			else return false;
		}
		else return false;
	}
	else return false;
}

int CInput::IsKeyUp(int keyCode)
{
	if (_isActive)
	{
		if ((_keyStates[keyCode] & 0x80) == 0)
		{
			if ((_preKeyStates[keyCode] & 0x80) != 0)
				return true;
			else return false;
		}
		else return false;
	}
	else return false;
}

int CInput::IsKeyPress(int keyCode)
{
	if (_isActive)
	{
		if ((_keyStates[keyCode] & 0x80) != 0)
		{
			if ((_preKeyStates[keyCode] & 0x80) != 0)
				return true;
			else return false;
		}
		else return false;
	}
	else return false;
}

int CInput::IsKeyRelease(int keyCode)
{
	if (_isActive)
	{
		if ((_keyStates[keyCode] & 0x80) == 0)
		{
			if ((_preKeyStates[keyCode] & 0x80) == 0)
				return true;
			else return false;
		}
		else return false;
	}
	else return false;
}

void CInput::SaveKeyStateHistory()
{
	for (int i = 0; i < 256; i++)
		_preKeyStates[i] = _keyStates[i];
}

BYTE CInput::GetKeyState(int keyCode)
{
	return _keyStates[keyCode];
}

void CInput::Active(){
	_isActive = true;
}

void CInput::Deactive()
{
	_isActive = false;
}