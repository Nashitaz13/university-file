#include "CStateMenu.h"	
#include <iostream>
#include "CDrawObject.h"
#include "CContra.h"
CStateMenu::CStateMenu()
{

}

CStateMenu::~CStateMenu()
{

}

void CStateMenu::Init()	
{
	this->mainMenu = new CMenuGameScense();
	this->mainMenu->SetPos(D3DXVECTOR2(this->mainMenu->GetWidth(), this->mainMenu->GetHeight() / 2));
}

void CStateMenu::Update(float detaTime)
{
	this->mainMenu->Update(detaTime);
}

void CStateMenu::Render()
{
	this->mainMenu->Draw();
}

void CStateMenu::Destroy()
{
}