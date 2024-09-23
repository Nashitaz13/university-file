#ifndef __CGUNNER_H__
#define __CGUNNER_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CEnemyEffect.h"

enum GUNNER_STATE
{
	GN_IS_NORMAL = 0,
	GN_IS_SHOOTTING = 1,
	GN_IS_DIE = 2
};

class CGunner : public CStaticObject, public CAnimation
{
public:
	CGunner(void);
	CGunner(const std::vector<int>& info);
	~CGunner();
	std::string ClassName(){ return __CLASS_NAME__(CGunner); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init();
	void BulletUpdate(float deltaTime);
	GUNNER_STATE m_stateCurrent;
	void SetFrame(float deltaTime);
	bool m_isShoot;
	//Tham so dung de test
public:
	int m_bulletCount; //So luong vien dan da ban ra
	float m_timeDelay;
	float m_waitForShoot;//1s
};

#endif // !__CGUNNER_H__
