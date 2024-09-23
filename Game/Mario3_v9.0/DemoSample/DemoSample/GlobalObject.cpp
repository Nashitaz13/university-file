#include "GlobalObject.h"

char* Name = "Game Mario 3";
HINSTANCE HInstance = NULL;
HWND HWnd = NULL;
LPDIRECT3DDEVICE9 D3ddv = NULL;
LPD3DXSPRITE SpriteHandler = NULL;
int FrameRate = 30;
DWORD DeltaTime = 0;
int _ScreenWidth = 270;
int _ScreenHeight = 210;
_VIEWPORT* ViewPort = new _VIEWPORT(0, _ScreenHeight - 40, _ScreenWidth, _ScreenHeight - 40);
int Level = 1;
int preLevel = 1;

