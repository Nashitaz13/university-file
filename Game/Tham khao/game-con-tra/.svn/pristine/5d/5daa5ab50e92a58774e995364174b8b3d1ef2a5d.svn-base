#ifndef __CENEMY_EFFECT_H__
#define __CENEMY_EFFECT_H__
#include "CDynamicObject.h"
#include "CAnimation.h"

class CEnemyEffect : public CDynamicObject, public CAnimation
{
public:
	CEnemyEffect(void);
	CEnemyEffect(D3DXVECTOR2 pos);
	~CEnemyEffect(void);

	virtual std::string ClassName(){ return __CLASS_NAME__(CEnemyEffect); };
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision);
	virtual void ChangeFrame(float deltaTime);
	virtual RECT* GetRectRS();
	virtual RECT* GetBound();
	virtual Box GetBox();
private:
	void Init();
};

#endif // !__CENEMY_EFFECT_H__


