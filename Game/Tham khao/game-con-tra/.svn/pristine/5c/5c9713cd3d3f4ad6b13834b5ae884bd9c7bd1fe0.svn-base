#ifndef __CBULLET_EFFECT_H__
#define __CBULLET_EFFECT_H__
#include "CDynamicObject.h"
#include "CAnimation.h"

class CBulletEffect : public CDynamicObject, public CAnimation
{
public:
	CBulletEffect(void);
	CBulletEffect(D3DXVECTOR2 pos);
	~CBulletEffect(void);

	virtual std::string ClassName(){ return __CLASS_NAME__(CBulletEffect); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision);
	virtual void ChangeFrame(float deltaTime);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
private:
	void Init();
};

#endif // !__CBULLET_EFFECT_H__


