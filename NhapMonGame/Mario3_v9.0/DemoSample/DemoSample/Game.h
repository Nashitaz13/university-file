#pragma once
#ifndef _Game_H_
#define _Game_H_

#include <windows.h>
#include <d3d9.h>
#include <d3dx9.h>
#include "GlobalObject.h"
#include "Resource.h"
#include "mario.h"
//#include "glut.h"

class CGame
{
protected:
	LPDIRECT3D9 _d3d;
	LPDIRECT3DSURFACE9 _BackBuffer;

	static LRESULT CALLBACK _WinProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);

	D3DFORMAT _BackBufferFormat = D3DFMT_X8R8G8B8;

	void _InitWindow();
	void _InitDirectX();

	void _RenderFrame();		// Render a single frame

public:
	virtual void Init();		// Khoi tao toan bo cac doi tuong trong game
	void Run();					// Run game
	virtual void RenderFrame();	// Render cac toan bo cac doi tuong trong game
	virtual void Update();		// Update toan bo cac doi tuong trong game

	CGame(HINSTANCE hInstance);
	~CGame();
};

#endif