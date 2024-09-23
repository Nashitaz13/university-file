#include "Input.h"

CInput::CInput()
{
	_isActive = true;
}

CInput::~CInput()
{

}

void CInput::Init()
{
	this->InitInputDirect();
	this->InitKeyboard();
}

void CInput::InitInputDirect()
{
	DirectInput8Create(HInstance, DIRECTINPUT_VERSION, IID_IDirectInput8, (VOID**)&_directInput, NULL);
	_directInput->CreateDevice(GUID_SysKeyboard, &_keyBoard, NULL);
}

void CInput::InitKeyboard()
{
	_keyBoard->SetDataFormat(&c_dfDIKeyboard);
	_keyBoard->SetCooperativeLevel(HWnd, DISCL_FOREGROUND | DISCL_NONEXCLUSIVE);

	DIPROPDWORD dipdw;
	dipdw.diph.dwSize = sizeof(DIPROPDWORD);
	dipdw.diph.dwHeaderSize = sizeof(DIPROPHEADER);
	dipdw.diph.dwObj = 0;
	dipdw.diph.dwHow = DIPH_DEVICE;
	dipdw.dwData = 1024;

	_keyBoard->SetProperty(DIPROP_BUFFERSIZE, &dipdw.diph);
	_keyBoard->Acquire();
}

void CInput::Update()
{
	_keyBoard->Poll();	//Gets keyboard states
	_keyBoard->GetDeviceState(256, (LPVOID)&_keyStates);
	_keyBoard->Acquire();
}

//	Vi?c ki?m tra s? ki?n KeyDown ???c th?c hi?n theo 2 ?i?u ki?n:
//	+ Phím ?ó ???c nh?n trong frame này
//	+ Phím ?ó không ???c nh?n trong frame tr??c
bool CInput::IsKeyDown(int keyCode)
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

//	Vi?c ki?m tra s? ki?n KeyUp ???c th?c hi?n theo 2 ?i?u ki?n:
//	+ Phím ?ó không ???c nh?n trong frame này
//	+ Phím ?ó ???c nh?n trong frame tr??c
bool CInput::IsKeyUp(int keyCode)
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

//	Vi?c ki?m tra s? ki?n KeyPress ???c th?c hi?n theo 2 ?i?u ki?n:
//	+ Phím ?ó ???c nh?n trong frame này
//	+ Phím ?ó ???c nh?n trong frame tr??c
bool CInput::IsKeyPress(int keyCode)
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

//	Vi?c ki?m tra s? ki?n KeyRelease ???c th?c hi?n theo 2 ?i?u ki?n:
//	+ Phím ?ó không ???c nh?n trong frame này
//	+ Phím ?ó không ???c nh?n trong frame tr??c
bool CInput::IsKeyRelease(int keyCode)
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

void CInput::Active() {
	_isActive = true;
}

void CInput::Deactive()
{
	_isActive = false;
}


CInput* input;
void IniInput()
{
	input = new CInput();
	input->Init();
}