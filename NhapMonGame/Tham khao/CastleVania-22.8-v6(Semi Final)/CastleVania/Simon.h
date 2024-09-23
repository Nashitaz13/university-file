#ifndef _SIMON_H_
#define _SIMON_H_

#include "DynamicObject.h"
#include "SweptAABB.h"
#include "MorningStar.h"
#include "Dagger.h"
#include "Boomerang.h"
#include "FireBomb.h"
#include "Axe.h"
#include "ThreeWater.h"

class Simon: public DynamicObject
{
protected:
	bool bActiveHurt;
	bool _bHurt;
	DWORD _localHurtTime;
	DWORD _deltaHurtTime;
	bool _usingCross;
	bool _usingWatch;
public:	
	bool _eatMagicalCrystal;
	MorningStar* _morningStar;
	list<Weapon*> *_weapon;
	EnumID _weaponID;
	bool _usingWeapon; //Co cho su dung dung vk ko? - co dang nhan DIK_Q?
	bool _hasWeapon;

	CSprite* _simonFightingSprite;
	CSprite* _simonSprite;
	CSprite* _simonFightingSittingSprite;
	CSprite* _simonFightingUpStairSprite;
	CSprite* _simonFightingDownStairSprite;
	CSprite* _simonStair;
	GameObject* _stair;	//Thong tin stair;

	CSprite *simonJump;

	float _vLast;
	Action _action;

	bool _hasJump;
	float _heightJump;

	bool _allowPress;		//Cho phep nhan phim
	bool _hasSit;
	bool _movingByMovingPlatform;
	bool _onLand;
	bool _hasFall;			//Simon dang rot
	//---------Stair-------------
	bool _isDraw;
	EKindStair _kindStair;
	bool _hasStair; //Co the len cau thang
	bool _onStair;	
	bool _colStair;	//kiem tra xem simon co cham 2 dau cau thang ko
	bool _outStair; //kiem tra cho phep simon ra khoi cau thang
	bool _upStair, _downStair, _stopOnStair;	// len, xuong, dung im tren cau thang
	int rangeStair; // Khoang cach tu simon den chan cau thang
	int _timeSpawn;	//
	//---Gate & Door-------
	GameObject* _door;
	int rangeGate;			//khoang cach simon den Castle Gate
	bool _colCastleGate;
	bool _colDoor;
	void OnGateCastle();
	void UpdateGateCastle(int dt);
	EDirectDoor _directDoor;
	void SetDirectDoor(EDirectDoor _direct);
	EDirectDoor GetDirectDoor();
	bool AutoMove(int &range, int dt);
	//-----------Simon Death---
	bool _simonDeath;			//Kiemer tra simon chet hay song
	bool _isReset;				//cho phep reset nhan vat sau khi chet
	ThreeWater * _threeWater;	//Giot nuoc ban len khi simon rot xuong ho
	CSprite* _simonDeathSprite;	//sprite simon death
	void SimonDeath(int &_timeCount);
	int GetHPSimon();
	void SetHPSimon();
	//---------------Dung tren MovingPltform--------
	bool _onMovingPlatform;
	//----------------Khoi Tao
	Simon(void);
	Simon(int, int);
	Simon(int, int, LPDIRECT3DDEVICE9);

	~Simon(void);
	//----Simon Action----------------
	void Update(int deltaTime);
	void TurnLeft();
	void TurnRight();
	void Jump();
	void Stop();
	void Draw(CCamera*);

	void Fight();
	void UseWeapon();
	void SetWeapon();
	void ChangeWeapon(EnumID idWeapon);
	void UpgradeMorningStar();
	void OnFight(int t);

	void UpdateSimonStair(int dt);
	void UpStair();
	void DownStair();
	void OutStair();
	void ResetStair();
	bool OnStair();

	void Sit();
	void Fall();
	bool IsFight();
	Box GetBox();
	void Collision(list<GameObject*> &obj, float dt);

	bool IsHurt();
	void Initialize();	
	D3DXVECTOR2* getPos();
	bool GetUsingCross();
	void SetUsingCross(bool);
	bool GetUsingWatch();
	void SetUsingWatch(bool);
};

#endif
