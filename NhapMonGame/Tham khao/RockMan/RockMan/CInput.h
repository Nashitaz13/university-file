#pragma once
#include "CGlobal.h"
#include "Config.h"
#include "Trace.h"
class CInput
{//Mới lấy lại
public:
	~CInput();

	//===================================================
	static CInput* GetInstance();

	// Khởi tạo Input
	int InitInput(HINSTANCE hInstance, HWND hwnd);

	// Update KeyState từ KeyEvents
	void Update(HWND hWnd);
	// Lấy trạng thái bàn phím có được kích hoạt hay không? Nếu không thì kích hoạt
	void SaveKeyStateHistory();

	int IsKeyDown(int keyCode);

	int IsKeyUp(int keyCode);

	int IsKeyPress(int keyCode);

	int IsKeyRelease(int keyCode);

	// Hủy đối tượng bàn phím và dữ liệu bộ đệm
	void ReleaseKeyboard();

	void Active();

	void Deactive();

private:
	CInput();

	//=========Phương thức===============================

	// Khởi tạo Direct Input
	int InitInputDirect(HINSTANCE hInstance);

	// Khởi tạo bàn phím
	int InitKeyboard(HWND hWnd);


	// Lấy trạng thái phím với "key"
	BYTE GetKeyState(int keyCode);

	//=========Thuộc tính================================

	static CInput* _pInstance;

	// Đối tượng DirectInput 
	LPDIRECTINPUT8 _directInput;

	// Bàn phím 
	LPDIRECTINPUTDEVICE8 _keyBoard;

	// Bộ đệm trạng thái của bàn phím DirectInput 
	BYTE  _keyStates[256];

	// Bộ đệm trạng thái của bàn phím DirectInput 
	BYTE  _preKeyStates[256];

	bool  _isActive;
};

