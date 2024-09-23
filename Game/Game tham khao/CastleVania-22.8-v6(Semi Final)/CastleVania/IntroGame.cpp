#include "IntroGame.h"

IntroGame::IntroGame()
{
	_loadOK = false;
	_helicopter = new GameObject(390, 270, EnumID::Helicopter_ID);
	_helicopter->vX = -0.01;
	_helicopter->vY = 0.01;
	_simon = new Simon(G_ScreenWidth, 78);
	_simon->vX = -1;
	_bat1 = new GameObject(200, 300, EnumID::Bat_ID);
	_bat2 = new GameObject(200, 350, EnumID::Bat_ID);
	_bat3 = new GameObject(250, 300, EnumID::Bat_ID);
	_bat1->vX = _bat1->vY = 0.02;
	_bat2->vX = _bat3->vY = 0.03;
	_bat3->vX = _bat2->vY = 0.01;
	_introScene = new GameObject((float)G_ScreenWidth / 2, (float)G_ScreenHeight / 2, EnumID::IntroScene_ID);
	
	SoundManager::GetInst()->RemoveAllBGM();
	SoundManager::GetInst()->PlayBGSound(EBGSound::EIntroSound);
}

IntroGame::~IntroGame(){}

void IntroGame::Update(int dt)
{
	_bat1->posX += _bat1->vX * dt;
	_bat1->posY += _bat1->vY * dt;
	_bat2->posX += _bat2->vX * dt;
	_bat2->posY += _bat2->vY * dt;	
	_bat3->posX += _bat3->vX * dt;
	_bat3->posY += _bat3->vY * dt;
	_helicopter->posX += _helicopter->vX * dt;
	_helicopter->posY += _helicopter->vY * dt;
	if(_simon->posX > (G_ScreenWidth / 2))
	{
		_simon->posX -= 2;
	}
	else
	{
		_loadOK = true;
		_simon->sprite->SelectIndex(9);
		return;
	}
	_bat3->sprite->Update(dt);
	_bat2->sprite->Update(dt);
	_bat1->sprite->Update(dt);

	_simon->sprite->Update (dt);

}

void IntroGame::Draw(CCamera* camera)
{
	D3DXVECTOR2 center = camera->Transform(_introScene->posX, _introScene->posY);
	_introScene->sprite->Draw(center.x, center.y);
	center = camera->Transform(_bat1->posX, _bat1->posY);
	_bat1->sprite->Draw(center.x, center.y);
	center = camera->Transform(_bat2->posX, _bat2->posY);
	_bat2->sprite->Draw(center.x, center.y);
	center = camera->Transform(_bat3->posX, _bat3->posY);
	_bat3->sprite->Draw(center.x, center.y);
	center = camera->Transform(_helicopter->posX, _helicopter->posY);
	_helicopter->sprite->Draw(center.x, center.y);
	center = camera->Transform(_simon->posX, _simon->posY);
	_simon->sprite->Draw(center.x, center.y);
}