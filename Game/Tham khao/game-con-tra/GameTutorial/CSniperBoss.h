#ifndef __CSniperBoss_H__
#define __CSniperBoss_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CBulletN.h"
#include "CEnemyEffect.h"

enum SNIPERBOSS_STATE
{
	SNB_IS_SHOOTING = 0,
	SNB_IS_HIDING = 1,
	SNB_IS_DIE = 2
};

enum SNIPERBOSS_SHOOT_STATE
{
	SNB_IS_SHOOTING_DOWN = 0,
	SNB_IS_SHOOTING_NORMAL = 1,
	SNB_IS_SHOOTING_DIAGONAL_DOWN = 2,
};

class CSniperBoss : public CStaticObject, public CAnimation
{
public:
	CSniperBoss(void);
	CSniperBoss(const std::vector<int> &info);
	~CSniperBoss();
	std::string ClassName(){return __CLASS_NAME__(CSniperBoss);};
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltatime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init();
	void BulletUpdate(float deltaTime);
	SNIPERBOSS_STATE m_stateCurrent;
	SNIPERBOSS_SHOOT_STATE m_stateShoot;
	void SetFrame(float deltaTime);
	bool m_isShoot;
public:
	// Hieu ung no
	CEnemyEffect* effect;

	int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
	float m_timeDelayForStand;
	float m_waitForChangeToDie;
	float m_waitForGrowUp;

};

#endif