#pragma once
#ifndef __GlobalObject_H__
#define __GlobalObject_H__

#include <d3dx9.h>

struct _VIEWPORT
{
public:
	int _Width;		// Height of view port
	int _Height;		// Width of view port

	int _X;			// Position of view port in World space
	int _Y;

public:
	_VIEWPORT(int x, int y, int width, int height)
	{
		_X = x; _Y = y; _Width = width; _Height = height;
	}
	RECT getRECT() {
		RECT temp = { _X, _Y, _X + _Width, _Y - _Height };
		return temp;
	}
};


// Name of this Game
extern char* Name;

// Handle the game instance
extern HINSTANCE HInstance;

// Handle the Game Window
extern HWND HWnd;

// Device
extern LPDIRECT3DDEVICE9 D3ddv;

// SpriteHandler object
extern LPD3DXSPRITE SpriteHandler;

// The number of frame per second will be rendered
extern int FrameRate;

// Time between the last frame and current frame
extern DWORD DeltaTime;

// Size of Screen
extern int _ScreenWidth;
extern int _ScreenHeight;

// ViewPort
extern _VIEWPORT* ViewPort;

// Level ?ang ch?i hi?n hành
extern int Level;
extern int preLevel;

#endif

