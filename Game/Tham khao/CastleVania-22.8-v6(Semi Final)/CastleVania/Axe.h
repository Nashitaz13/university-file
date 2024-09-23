#ifndef _AXE_H_
#define _AEX_H_

#include "Weapon.h"

#define AXE_ANPHA 70
#define AXE_SPEED_X 1.5
#define G 0.01f

class Axe :
	public Weapon
{
protected:
	D3DXVECTOR2* _gold;
	float _anpha;
	float _posX0;
	float _posY0;
	void _initialize();
public:
	Axe(void);
	Axe(float x_, float y_, float huong_);
	virtual void Update(int deltaTime_);
	void prepareFighting(float simonX_, float simonY_, float direct_);
	~Axe(void);
};

#endif