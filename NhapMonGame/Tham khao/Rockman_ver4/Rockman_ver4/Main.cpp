#pragma once
#include <iostream>
#include "Include.h"
#include "Game.h"
#include "GameRockman.h"
#include "ViewWindows.h"

using namespace Rockman;

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	CViewWindows::m_hInstance = hInstance;
	CGameRockman* game = new CGameRockman();
	game->Run();
}