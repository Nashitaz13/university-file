#ifndef __CEXPLOSION_EFFECT_H__
#define __CEXPLOSION_EFFECT_H__
#include "CDynamicObject.h"
#include "CAnimation.h"

class CExplosionEffect : public CDynamicObject, public CAnimation
{
public:
	CExplosionEffect(void);
	CExplosionEffect(D3DXVECTOR2 pos);
	~CExplosionEffect(void);

	virtual std::string ClassName(){ return __CLASS_NAME__(CExplosionEffect); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision);
	virtual void ChangeFrame(float deltaTime);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
private:
	void Init();
};

#endif // !__CEXPLOSION_EFFECT_H__


