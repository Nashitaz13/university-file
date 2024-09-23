#include "Game.h"
#include "Include.h"
#include <iostream>
#include "CGlobal.h"
#include "StateManagement.h"

namespace Rockman
{
	CGame::CGame() : m_isAlived(true), m_isPaused(false) {}

	void CGame::Run()
	{
		MSG msg;
		int done = 0;
		DWORD frameStart = GetTickCount();
		DWORD tickPerFrame = 1000 / __FRAME_RATE;
		this->Init(); //Khoi tao game

		while (!done)
		{
			if (!this->m_isAlived) //Kiem tra game con hoat dong
			{
				return;
			}
			if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
			{
				if (msg.message == WM_QUIT) done = 1;

				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}

			DWORD now = GetTickCount();//Xem lai sau
			DWORD deltaTime = (now - frameStart);
			if (deltaTime >= tickPerFrame)
			{
				frameStart = now;
				float delta_time = (float)deltaTime / 1000;
				this->ProcessInput();
				if (this->m_isPaused)
				{
					CStateManagement::GetInstance()->Update(true, delta_time);
				}
				else
				{
					CStateManagement::GetInstance()->Update(false, delta_time);
				}
			}
		}
		//CStateManagement::GetInstance()->Update(true, 1);
		//while (this->m_isAlived)
		//{
		//	if(this->m_isPaused)
		//	{
		//		CStateManagement::GetInstance()->Update(true);
		//	}
		//	else
		//	{
		//		CStateManagement::GetInstance()->Update(false);
		//	}
		//	Sleep(80);
		//}
		Destroy();
	}

	void CGame::Destroy()
	{
		this->m_isAlived = false;
	}

	void CGame::Pause()
	{
		this->m_isPaused = true;
	}

	void CGame::Resume()
	{
		this->m_isPaused = false;
	}

	void CGame::Exit()
	{

	}

	void CGame::ProcessInput()
	{

	}
}