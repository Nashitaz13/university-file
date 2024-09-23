#pragma once
#include "DynamicObject.h"



#define FALLING_CASTLE_VX 0.2f
#define FALLING_CASTLE_VY 0.05f
#define FALLING_CASTLE_RATE 5
#define SIMON_IN_CASTLE_RATE 20
#define FALLING_CASTLE_DELTA_Y_MAX 111


class FallingCastle :
	public DynamicObject
{
protected:
	CSprite* _sprite;
	CSprite* _simonInCastleSprite;
	float _posX0;
	float _posY0;
	int _localTime;
	bool _isFalled;
public:
	FallingCastle(void);
	FallingCastle(float posX_, float posY_,float vX = FALLING_CASTLE_VX, float vY = FALLING_CASTLE_VY);
	virtual void Update(int deltaTime_);
	virtual void Draw(CCamera* camera_);
	bool isFalled();
	~FallingCastle(void);
};

