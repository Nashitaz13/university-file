#ifndef __CSUBARSOLIDER_H__
#define __CSUBARSOLIDER_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CEnemyEffect.h"
#include "CBulletScubaSolider.h"

enum SCUBAR_SOLIDER_STATE
{
	SBS_IS_NORMAL = 0,
	SBS_IS_SHOOTING = 1,
	SBS_IS_DIE = 2
};

class CScubaSolider : public CStaticObject, public CAnimation
{
public:
	CScubaSolider(void);
	CScubaSolider(const std::vector<int>& info);
	~CScubaSolider();
	std::string ClassName(){ return __CLASS_NAME__(CScubaSolider); };
	virtual void SetFrame(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void BulletUpdate(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init();
	SCUBAR_SOLIDER_STATE m_stateCurrent;
	bool m_isShoot;
	//Tham so dung de test
public:
	int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
	float m_timeDelay1;
	float m_waitForChangeSprite;

	bool m_isBullectExplosive;
	float m_maxYRandom;
};

#endif // !__CSUBARSOLIDER_H__
