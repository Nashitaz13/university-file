#ifndef _FIREBOMB_H_
#define _FIREBOMB_H_

#include "weapon.h"

#define	PRIMARY_STATE_RATE 1
#define SECONDARY_STATE_RATE 5
#define FIREBOMB_SPEED_X 1.f
#define G 0.01f
#define FIREBOMB_ANPHA 70

enum EFireBombState
{
	Primary,
	Secondary
};


class FireBomb :
	public Weapon
{
protected:
	EFireBombState _eFireBombState;
	D3DXVECTOR2* _gold;
	float _anpha;
	float _posX0;
	float _posY0;


	void _initialize();
	int _localTime;
public:
	FireBomb(void);
	FireBomb(float x_, float y_, float huong_);
	//virtual void Draw(CCamera* camera_);
	void Update(int deltaTime_);
	void Collision(list<GameObject*> &obj, int dt);
	void prepareFighting(float simonX_, float simonY_, float direct_);
	~FireBomb(void);
};

#endif