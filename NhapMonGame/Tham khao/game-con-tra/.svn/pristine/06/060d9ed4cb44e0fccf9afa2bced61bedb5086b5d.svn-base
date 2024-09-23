#ifndef __CBIG_CAPSULE_BOSS_H__
#define __CBIG_CAPSULE_BOSS_H__

#include "CDynamicObject.h"
#include "CAnimation.h"
#include "CExplosionEffect.h"
#include "CCapsuleBoss.h"
//co 7 con con
enum BIG_CAPSULE_STATE
{
	BIG_CAP_IS_START = 0,//bat dau
	BIG_CAP_IS_NORMAL = 1,//shoot va tha linh con
	BIG_CAP_IS_BACK = 2,
	BIG_CAP_IS_HIDEN = 3,
	BIG_CAP_IS_DIE = 4
};
class CBigCapsule : public CDynamicObject, public CAnimation
{
public:
	CBigCapsule();
	CBigCapsule(const std::vector<int>& info);
	~CBigCapsule();
	std::string ClassName(){ return __CLASS_NAME__(CBigCapsule); };
	virtual void SetFrame(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void MoveUpdate(float deltaTime);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	BIG_CAPSULE_STATE m_stateCurrent;
	void Init();
	void BulletUpdate(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	float m_timeDelay;
	float m_timeDelayWaitShoot;
	float m_timeDelayWaitChangePos;
	float m_timeDelayShowWinner;
	bool m_isShoot;
public:
	int m_bulletCount;//So luong vien dan da ban ra
	int m_CapsuleCount;//so luong capsule sinh ra 7 con
	float m_time;
	float m_spaceMoveCapsuleLeft;
	float m_spaceMoveCapsuleRight;
	float m_timeDelayShootBullet;

	int m_countEffect;
	bool m_isFirst;
	bool m_isShowScenseScore;
	//Ham set random vi tri cua boss
	void resetPosOfBoss(float);
};

#endif // !__CBIG_CAPSULE_BOSS_H__
