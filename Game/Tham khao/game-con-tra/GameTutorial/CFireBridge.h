#ifndef __CFIRE_BRIDGE_H__
#define __CFIRE_BRIDGE_H__

#include "CDynamicObject.h"
#include "CAnimation.h"


class CFireBridge : public CDynamicObject, public CAnimation
{
public:
	CFireBridge(D3DXVECTOR2, bool);
	CFireBridge(const std::vector<int>& info);
	~CFireBridge();
	std::string ClassName(){ return __CLASS_NAME__(CFireBridge); };
	//void ChangeFrame(float deltaTime);
	virtual void SetFrame(float deltaTime);
	virtual void MoveUpdate(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
protected:
	void Init();
	float m_timeDelay;
	D3DXVECTOR2 posOfBridge;
	bool m_isLeft;
};

#endif // !__CFIRE_BRIDGE_H__
