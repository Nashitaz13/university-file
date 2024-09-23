#ifndef __CDefenseCannonTurret_H__
#define __CDefenseCannonTurret_H__

#include "CAnimation.h"
#include "CStaticObject.h"
#include "CEnemyEffect.h"


enum DC_TURRECT_STATE
{
	DC_TURRECT_NORMAL = 0,//Ban dau
	DC_TURRECT_IS_DIE = 3,//chet
};

class CDefenseCannonTurret : public CStaticObject, public CAnimation
{
public:
	CDefenseCannonTurret(void);
	CDefenseCannonTurret(int, int);
	CDefenseCannonTurret(const std::vector<int>& info);
	~CDefenseCannonTurret();
	std::string ClassName(){ return __CLASS_NAME__(CDefenseCannonTurret); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init(int, int);
	void BulletUpdate(float deltaTime);
	void SetFrame();
	DC_TURRECT_STATE m_stateCurrent;
	//Tham so dung de test
public:
	float m_timeDelay;
};

#endif // !__CDefenseCannonTurret_H__
