#pragma once
#include <iostream>
#include "CGameContra.h"

using namespace GameTutorial;

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	CView::m_hInstance = hInstance;
	CGameContra* game = new CGameContra();
	game->Run();
}