#ifndef __CBRIDGE_FIRE_H__
#define __CBRIDGE_FIRE_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CExplosionEffect.h"
#include "CFireBridge.h"

class CBridgeFire : public CStaticObject, public CAnimation
{
public:
	CBridgeFire(void);
	CBridgeFire(const std::vector<int>& info);
	~CBridgeFire();
	std::string ClassName(){ return __CLASS_NAME__(CBridgeFire); };
	virtual void SetFrame(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();

	CFireBridge* fireLeft;
	CFireBridge* fireRight;
protected:
	void Init();
	float m_timeDelay;
};

#endif // !__CBRIDGE_FIRE_H__
