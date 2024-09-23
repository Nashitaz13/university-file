#ifndef __CEFFECT_BACKGROUND_H__
#define __CEFFECT_BACKGROUND_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CFireBridge.h"
enum BACKGROUND_EFFECT_TYPE
{
	BE_TYPE_1 = 0,
	BE_TYPE_2 = 1,
	BE_TYPE_3= 2
};
class CEffect_Background : public CStaticObject, public CAnimation
{
public:
	CEffect_Background(void);
	CEffect_Background(const std::vector<int>& info);
	~CEffect_Background();
	std::string ClassName(){ return __CLASS_NAME__(CEffect_Background); };
	void Init(int col, int totalFrame, float frameWidth, float frameHeight, int frameStart, int frameEnd, int id);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetRectRS();
};

#endif // !__CEFFECT_BACKGROUND_H__
