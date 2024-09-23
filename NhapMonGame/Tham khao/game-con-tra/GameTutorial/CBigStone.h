#ifndef __CBIGSTONE_H__
#define __CBIGSTONE_H__

#include "CDynamicObject.h"
#include "CAnimation.h"

enum STATE_STONE{
	STANDING = 0,
	FALL = 1
};

class CBigStone : public CDynamicObject, public CAnimation{
public:
	CBigStone(void);
	CBigStone(const std::vector<int>& info);
	~CBigStone();
	std::string ClassName(){ return __CLASS_NAME__(CBigStone); };
	virtual void SetFrame(float deltaTime);
	virtual void MoveUpdate(float deltaTime);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	void OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	RECT* GetBound();
	RECT* GetRectRS();
	Box GetBox();
	void Init();
protected:
	STATE_STONE m_currentState;
	float m_timeDelay;
	bool m_isColGround;
	float m_lastYGround;
};

#endif // !__CBIGSTONE_H__