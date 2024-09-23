#ifndef __CTANK_H__
#define __CTANK_H__

#include "CDynamicObject.h"
#include "CAnimation.h"

enum TANK_STATE
{
	TANK_IS_NORMAL = 0,
	TANK_IS_DIE1 = 1,
	TANK_IS_DIE2 = 2,
	TANK_IS_DIE3 = 3,
	TANK_IS_DIE = 4

};

enum TANK_SHOOT_STATE
{
	T_IS_SHOOTING_NORMAL = 5,
	T_IS_SHOOTING_DOWN = 6,
	T_IS_SHOOTING_DOWN2X = 7
};

class CTank : public CDynamicObject, public CAnimation
{
public:
	CTank();
	CTank(const std::vector<int>& info);
	~CTank();
	std::string ClassName(){ return __CLASS_NAME__(CTank); };
	virtual void SetFrame(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void MoveUpdate(float deltaTime);
	virtual void BulletUpdate(float deltaTime);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();

private:
	TANK_STATE m_stateCurrent;
	TANK_SHOOT_STATE m_tankShootState;
	void Init();
	float m_timeDelay;
	float m_timeDelayWaitShoot;
	D3DXVECTOR2 posOfBoss;
	bool m_isShoot;
protected:
	float m_waitForExplosion;
public:
	int m_bulletCount; //So luong vien dan da ban ra
	int m_countEffect; // Dem so luong effect.
	float m_delayForNextShoot;

	static bool m_shooted;
	double angle;
	double oldAngle;
};


#endif