#ifndef __CCOLLISION_H__
#define __CCOLLISION_H__

#define NOMINMAX

#include "CCollision.h"
#include "CGlobal.h"
#include "CGameObject.h"
#include "CSingleton.h"

class CCollision : public CSingleton<CCollision>
{
	friend class CSingleton<CCollision>;
public:
	float SweptAABB(Box first, Box second, float& normalx, float& normaly, float deltaTime);
	Box GetSweptBroadphaseBox(Box box, float deltaTime);
	bool AABBCheck(Box b1, Box b2, float& moveX, float& moveY, float& normalX, float& normalY);
	bool AABBCheck(Box b1, Box b2);
	float Collision(CGameObject* ObjectA, CGameObject* ObjectB, float& normalx, float& normaly, float& moveX, float& moveY, float deltaTime);
	bool Collision(CGameObject* ObjectA, CGameObject* ObjectB);
	CCollision();
	~CCollision();
private:

};

#endif // !__CCOLLISION_H__