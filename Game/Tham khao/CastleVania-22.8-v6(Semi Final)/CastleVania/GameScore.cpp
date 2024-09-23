#include "GameScore.h"


void GameScore::_initialize()
{
	// init weaponSprite
	_vWeaponSprite = vector<CSprite*>();
	_vWeaponSprite.push_back(new CSprite(Singleton::getInstance()->getTexture(EnumID::WatchItem_ID),1));
	_vWeaponSprite.push_back(new CSprite(Singleton::getInstance()->getTexture(EnumID::DaggerItem_ID),1));
	_vWeaponSprite.push_back(new CSprite(Singleton::getInstance()->getTexture(EnumID::FireBombItem_ID),1));
	_vWeaponSprite.push_back(new CSprite(Singleton::getInstance()->getTexture(EnumID::BoomerangItem_ID),1));
	_vWeaponSprite.push_back(new CSprite(Singleton::getInstance()->getTexture(EnumID::AxeItem_ID),1));

	// init hp sprite
	_hpSprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::HP_ID),1);

	_gameTimer = 0;
}

void GameScore::drawTable()
{
	// draw table
	_sprite->Draw(260,40);

	// draw hp
	//simon
	for(int i = 0;i<_simonHP;i++)
	{
		_hpSprite->DrawIndex(0,100+10*i,30);
	}
	for(int i = _simonHP;i<MAX_HP;i++)
	{
		_hpSprite->DrawIndex(1,100+10*i,30);
	}
	// boss
	for(int i = 0;i<_enemyHP;i++)
	{
		_hpSprite->DrawIndex(2,100+10*i,50);
	}
	for(int i = _enemyHP;i<MAX_HP;i++)
	{
		_hpSprite->DrawIndex(1,100+10*i,50);
	}


	// draw weapon
	if(_currentWeapon!=-1)
	{
		_vWeaponSprite.at(_currentWeapon)->Draw(345,48);
	}
}

void GameScore::drawScore()
{
	_arial->onLost();
	_arial->render("SCORE",5,0);
	_arial->render(_simonScore, 100, 0);
	_arial->render("TIME", 230, 0);
	_arial->render(_gameTimer/1000, 310, 0);
	_arial->render("STAGE", 400, 0);
	_arial->render(_gameStage, 490, 0);
	_arial->render("PLAYER", 5, 20);
	_arial->render("ENEMY", 5, 40);
	_arial->render(_weaponCount, 420, 30);
	_arial->render(_liveCount,430,50);
}

void GameScore::initTimer(int deltaTime_)
{
	_gameTimer = deltaTime_*1000;
}

int GameScore::getTimer()
{
	return _gameTimer/1000;
}

void GameScore::SetTimer(int x)
{
	_gameTimer += x;
}

int GameScore::GetWeaponCount()
{
	return _weaponCount;
}

void GameScore::SetWeaponCount(int x)
{
	_weaponCount += x;
}

void GameScore::SetSimonScore(int x)
{
	_simonScore += x;
}

GameScore::GameScore(void)
{
	
}

GameScore::GameScore(LPDIRECT3DDEVICE9 d3ddev_, int size_, int screenWidth_, int screenHeight_)
{
	this->_initialize();
	_sprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::GameScore_ID),1);
	_arial = new Font(d3ddev_,size_,screenWidth_,screenHeight_);
}
	

void GameScore::updateScore(int gameStage_,int simonScore_, int deltaTime_, int simonHP_,int liveCount_, EnumID weaponID_,  int weaponCount_, int enemyHP_)
{
	_gameStage = gameStage_;
	_simonScore = simonScore_;
	if(_gameTimer <= 0)
	{}
	else
	_gameTimer = _gameTimer-deltaTime_;
	_weaponCount = weaponCount_;
	_simonHP = simonHP_;
	_enemyHP = enemyHP_;
	_liveCount = liveCount_;

	switch (weaponID_)
	{
	case Watch_ID:
		_currentWeapon = 0;
		break;
	case Dagger_ID:
		_currentWeapon = 1;
		break;
	case FireBomb_ID:
		_currentWeapon = 2;
		break;
	case Boomerang_ID:
		_currentWeapon = 3;
		break;
	case Axe_ID:
		_currentWeapon = 4;
		break;
	default:
		_currentWeapon = -1;
		break;
	}

}


GameScore::~GameScore(void)
{
}
