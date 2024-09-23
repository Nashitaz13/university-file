//-----------------------------------------------------------------------------
// File: CCollisionInfo.h
//
// Desc: Định nghĩa lớp CItem có các dạng như Score, Mana, Power
//
//-----------------------------------------------------------------------------
#ifndef _COLLISION_IFNO_H_
#define _COLLISION_IFNO_H_

#include "CGameObject.h"

struct CollisionInfo
{
public:
	CGameObject*	_object;
	CDirection		_direction;
	float			_timeCollide;

	CollisionInfo();
	CollisionInfo(CGameObject* object, CDirection direction, float timeCollide);
};


#endif // !_COLLISION_IFNO_H_