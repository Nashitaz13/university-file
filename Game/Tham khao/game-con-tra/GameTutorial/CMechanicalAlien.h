#ifndef __CMECHANICAL_ALIEN_H__
#define __CMECHANICAL_ALIEN_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CExplosionEffect.h"
#include "CHeadBoss.h"
#include "CBossArm.h"

enum STATE_MECHANICAL_ALIEN
{
	SMA_IS_START = 0, //bt
	SMA_IS_NORMAL = 1,//Binh Thuong
	SMA_IS_HAND_LEFT_DIE = 2,//Tay trai chet
	SMA_IS_HAND_RIGHT_DIE = 3,//Tay phai chet
	SMA_IS_HEAD_DIE = 4,//Dau boss chet
	SMA_IS_DIE = 5//Boss chet
};
class CMechanicalAlien : public CStaticObject, public CAnimation
{
public:
	CMechanicalAlien(void);
	CMechanicalAlien(const std::vector<int>& info);
	~CMechanicalAlien();
	std::string ClassName(){ return __CLASS_NAME__(CMechanicalAlien); };
	//void ChangeFrame(float deltaTime);
	virtual void SetFrame(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	STATE_MECHANICAL_ALIEN m_stateCurrent;
	void Init();
	float m_timeDelay;
	float m_timeDelayStartBoss;
	float m_timeDelayEffect;
public:
	CHeadBoss* m_Head;
	CBossArm* m_ArmLeft;
	CBossArm* m_ArmRight;
	//cho biet boss song hat chet
	bool m_isDie;
	bool m_isEffect;
};

#endif // !__CMECHANICAL_ALIEN_H__
