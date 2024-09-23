#ifndef _SINGLETON_H_
#define _SINGLETON_H_

#include "CTexture.h"
#include "CEnum.h"

class Singleton
{
private:
	CTexture* simon;
	CTexture* simonDeath;

	//enemy
	CTexture* zombie;
	CTexture* blackKnight;
	CTexture* blackLeopard;
	CTexture* fishMan;
	CTexture* dragonSkullCannon;
	CTexture* vampireBat;
	CTexture* medusa;
	//ground
	CTexture* candle;
	CTexture* largeCandle;
	CTexture* movingPlatform;
	CTexture* openDoor;
	CTexture* stupidDoor;
	//weapon
	CTexture* morningStar;
	CTexture* fireBomb;
	CTexture* dagger;
	CTexture* boomerang;
	CTexture* axe;
	//item
	CTexture* largeHeartItem;
	CTexture* smallHeartItem;
	CTexture* moneyBagItem;
	CTexture* crossItem;
	CTexture* morningStarItem;
	CTexture* fireBombItem;
	CTexture* daggerItem;
	CTexture* boomerangItem;
	CTexture* axeItem;
	CTexture* watchItem;

	CTexture* magicalCrystal;
	//boss
	CTexture* phantombat;
	CTexture* queenMedusa;	
	CTexture* littleSnake;
	//other
	CTexture* fireDie;
	CTexture* water;
	CTexture* fireBall;

	CTexture* bgMenu;
	//IntroScene
	CTexture* helicopter;
	CTexture* bat;
	CTexture* introBackground;

	CTexture* gameScore;
	CTexture* hp;

	CTexture* fallingCastle;
	CTexture* simonInCastle;

	static Singleton *single;
	Singleton();

public:
	static Singleton* getInstance();
	~Singleton();
	CTexture* getTexture(EnumID id);
};

#endif