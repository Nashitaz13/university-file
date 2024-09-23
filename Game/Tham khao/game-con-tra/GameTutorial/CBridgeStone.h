#ifndef __CBridgeStone_H__
#define __CBridgeStone_H__

#include "CDynamicObject.h"
#include "CAnimation.h"

class CBridgeStone : public CDynamicObject, CAnimation 
{
public:
	CBridgeStone(void);
	CBridgeStone(const std::vector<int>& info);
	~CBridgeStone();
	std::string ClassName(){ return __CLASS_NAME__(CBridgeStone); };
	virtual void SetFrame(float deltaTime);
	virtual void MoveUpdate(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
	void setRadius(float r);
	float GetVx();
protected:
	void Init();
	float m_radius;
	float m_minX;
	float m_maxX;
public:
	
};

#endif // !__CBridgeStone_H__