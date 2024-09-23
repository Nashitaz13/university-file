#ifndef __CCAPSULE_BOSS_H__
#define __CCAPSULE_BOSS_H__

#include "CDynamicObject.h"
#include "CAnimation.h"
#include "CExplosionEffect.h"

enum CAPSULE_STATE
{
	CAP_IS_START = 0,
	CAP_IS_NORMAL = 1,
	CAP_IS_DIE = 2
};
class CCapsuleBoss : public CDynamicObject, public CAnimation
{
public:
	CCapsuleBoss();
	CCapsuleBoss(const std::vector<int>& info);
	~CCapsuleBoss();
	std::string ClassName(){ return __CLASS_NAME__(CCapsuleBoss); };
	virtual void SetFrame();
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void MoveUpdate(float deltaTime);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	float m_timeDelay;
	float m_timeDelayWaitShoot;
	bool m_isShoot;
public:
	void Init();
	CAPSULE_STATE m_stateCurrent;
	int m_bulletCount; //So luong vien dan da ban ra
	float m_time;
	float m_space;//doan duong di dc
	float m_spaceCurrent;//doan dg di dc hien tai
	bool m_isCollisonWithGround;
};

#endif // !__CCAPSULE_BOSS_H__
