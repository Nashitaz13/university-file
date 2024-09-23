#include "Singleton.h"
#include <string>
#include <sstream>
#include <windows.h>
#include <iostream>
#include <malloc.h>

using namespace std;

Singleton* Singleton::single = NULL;

Singleton* Singleton::getInstance()
{
	if(single == NULL)
		single = new Singleton();
	return single;
}

Singleton::Singleton()
{
	simon = new CTexture("Resources/simon.png", 8, 3, 24);
	simonDeath = new CTexture("Resources/simondeath.png", 1, 1, 1);

	vampireBat = new CTexture("Resources/enemy/0.png", 4, 1, 4);
	zombie = new CTexture("Resources/enemy/1.png", 2, 1, 2);
	blackLeopard = new CTexture("Resources/enemy/2.png", 4, 1, 4);
	fishMan = new CTexture("Resources/enemy/3.png", 3, 1, 3);
	blackKnight = new CTexture("Resources/enemy/5.png", 4, 1, 4);
	medusa = new CTexture("Resources/enemy/6.png", 2, 1, 2);
	dragonSkullCannon = new CTexture("Resources/enemy/8.png", 1, 1, 1);

	candle = new CTexture("Resources/ground/1.png", 2, 1, 2);
	largeCandle = new CTexture("Resources/ground/0.png", 2, 1, 2);
	movingPlatform = new CTexture("Resources/ground/9.png", 1, 1, 1);	
	openDoor = new CTexture("Resources/ground/Gate1.png", 4, 1, 4);
	stupidDoor = new CTexture("Resources/ground/7_3.png", 2, 1, 2);

	morningStar = new CTexture("Resources/morningstar.png", 3, 3, 9);
	fireBomb = new CTexture("Resources/weapon/2.png", 3, 1, 3);
	dagger = new CTexture("Resources/weapon/1.png", 1, 1, 1);
	boomerang = new CTexture("Resources/weapon/4.png", 3, 1, 3);
	axe = new CTexture("Resources/weapon/3.png", 4, 1, 4);

	largeHeartItem = new CTexture("Resources/item/1.png", 1, 1, 1);
	smallHeartItem = new CTexture("Resources/item/0.png", 1, 1, 1);
	moneyBagItem = new CTexture("Resources/item/2.png", 3, 1, 3);
	crossItem = new CTexture("Resources/item/6.png", 1, 1, 1);
	morningStarItem = new CTexture("Resources/item/3.png", 1, 1, 1);
	fireBombItem = new CTexture("Resources/item/9.png", 1, 1, 1);
	daggerItem = new CTexture("Resources/item/4.png", 1, 1, 1);
	boomerangItem = new CTexture("Resources/item/8.png", 1, 1, 1);
	axeItem = new CTexture("Resources/item/7.png", 1, 1, 1);
	watchItem = new CTexture("Resources/item/5.png", 1, 1, 1);

	magicalCrystal = new CTexture("Resources/item/13.png", 2, 1, 2);

	phantombat = new CTexture("Resources/boss/0.png", 3, 1, 3);
	queenMedusa = new CTexture("Resources/boss/1.png", 5, 1, 5);	
	littleSnake = new CTexture("Resources/boss/2.png", 2, 1, 2);

	fireDie = new CTexture("Resources/other/1.png", 3, 1, 3);
	water = new CTexture("Resources/other/2.png", 1, 1, 1);
	fireBall = new CTexture("Resources/fireball.png", 1, 1, 1);

	bgMenu = new CTexture("Resources/mainmenu.png", 1, 1, 1);


	helicopter = new CTexture("Resources/helicopter.png", 1, 1, 1);
	introBackground = new CTexture("Resources/intro.png", 1, 1, 1);
	bat = new CTexture("Resources/bat.png", 2, 1, 2);


	gameScore = new CTexture("Resources/blackboard.png", 1, 1, 1);
	hp = new CTexture("Resources/heal.png",3,1,3);

	fallingCastle = new CTexture("Resources/FallingCastle.png",3,1,3);
	simonInCastle = new CTexture("Resources/SimonInCastle.png",2,1,2);

}

CTexture* Singleton::getTexture(EnumID id)
{
	switch(id)
	{
	case EnumID::Simon_ID:
		return simon;
	case EnumID::SimonDeath_ID:
		return simonDeath;

	case EnumID::VampireBat_ID:
		return vampireBat;
	case EnumID::Zombie_ID:
		return zombie;
	case EnumID::FishMan_ID:
		return fishMan;
	case EnumID::BlackLeopard_ID:
		return blackLeopard;
	case EnumID::BlackKnight_ID:
		return blackKnight;
	case EnumID::Medusa_ID:
		return medusa;
	case EnumID::DragonSkullCannon_ID:
		return dragonSkullCannon;

	case EnumID::Candle_ID:
		return candle;
	case EnumID::LargeCandle_ID:
		return largeCandle;
	case EnumID::MovingPlatform_ID:
		return movingPlatform;
	case EnumID::StupidDoor_ID:
		return stupidDoor;

	case EnumID::MorningStar_ID:
		return morningStar;
	case EnumID::FireBomb_ID:
		return fireBomb;
	case EnumID::Dagger_ID:
		return dagger;
	case EnumID::Boomerang_ID:
		return boomerang;
	case EnumID::Axe_ID:
		return axe;

	case EnumID::LargeHeartItem_ID:
		return largeHeartItem;
	case EnumID::SmallHeartItem_ID:
		return smallHeartItem;
	case EnumID::MoneyBagItem_ID:
		return moneyBagItem;
	case EnumID::CrossItem_ID:
		return crossItem;
	case EnumID::WatchItem_ID:
		return watchItem;
	case EnumID::DaggerItem_ID:
		return daggerItem;
	case EnumID::FireBombItem_ID:
		return fireBombItem;
	case EnumID::BoomerangItem_ID:
		return boomerangItem;
	case EnumID::AxeItem_ID:
		return axeItem;
	case EnumID::MorningStarItem_ID:
		return morningStarItem;

	case EnumID::MagicalCrystal_ID:
		return magicalCrystal;

	case EnumID::PhantomBat_ID:
		return phantombat;
	case EnumID::QueenMedusa_ID:
		return queenMedusa;
	case EnumID::LittleSnake_ID:
		return littleSnake;

	case EnumID::Fire_ID:
		return fireDie;
	case EnumID::Water_ID:
		return water;
	case EnumID::FireBall_ID:
		return fireBall;

	case EnumID::BGMenu_ID:
		return bgMenu;

	case EnumID::Helicopter_ID:
		return helicopter;
	case EnumID::Bat_ID:
		return bat;
	case EnumID::IntroScene_ID:
		return introBackground;
	case EnumID::OpenDoor_ID:
		return openDoor;


	case EnumID::GameScore_ID:
		return gameScore;

	case EnumID::HP_ID:
		return hp;

	case EnumID::FallingCastle_ID:
		return fallingCastle;
	case EnumID::SimonInCastle_ID:
		return simonInCastle;
	}
}