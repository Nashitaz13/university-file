#include "GameRockman.h"

#include "StateManagement.h"
#include "StateMain.h"	
#include "Device.h"
#include "Input.h"

CGameRockman::CGameRockman()
{
}



void CGameRockman::Init()
{
	CViewWindows::GetInstance()->InitClienWindow();
	CDevice::GetInstance()->InitDerect3D();
	CInput::GetInstance()->InitInput(CViewWindows::m_hInstance);
	CInput::GetInstance()->InitKeyboard(CViewWindows::m_hwndWindow);
	CStateManagement::GetInstance()->ChangeState(new CStateMain());
}

void CGameRockman::Destroy()
{

}

void CGameRockman::ProcessInput()
{
	CInput::GetInstance()->ProcessKeyboard();
	CInput::GetInstance()->Update();
}