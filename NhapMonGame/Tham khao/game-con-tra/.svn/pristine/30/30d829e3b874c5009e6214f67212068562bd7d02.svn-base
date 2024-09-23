#ifndef __CFACE_BOSS_H__
#define __CFACE_BOSS_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CExplosionEffect.h"

enum STATE_HEAD_BOSS
{
	SHB_IS_NORMAL = 0, //bt
	SHB_IS_SHOOT = 1,//Dau boss chet
	SHB_IS_DIE = 2//Dau boss chet
};
class CHeadBoss : public CStaticObject, public CAnimation
{
public:
	CHeadBoss(D3DXVECTOR2);
	CHeadBoss(const std::vector<int>& info);
	~CHeadBoss();
	std::string ClassName(){ return __CLASS_NAME__(CHeadBoss); };
	//void ChangeFrame(float deltaTime);
	virtual void SetFrame(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	STATE_HEAD_BOSS m_stateCurrent;
	void Init();
	void BulletUpdate(float deltaTime);
	float m_timeDelay;
	float m_timeDelayWaitShoot;
	D3DXVECTOR2 posOfBoss;
	bool m_isShoot;
public:
	int m_bulletCount; //So luong vien dan da ban ra
};

#endif // !__CFACE_BOSS_H__
