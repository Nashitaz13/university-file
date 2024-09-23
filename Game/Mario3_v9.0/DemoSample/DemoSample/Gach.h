#pragma once
#ifndef __Gach_H__
#define __Gach_H__

#include "MovableObject.h"
#include "Resource.h"
#include "DongTien.h"
#include "VienGachVo.h"
#include "Turtle.h"

class Gach : public MovableObject
{
private:
	bool _Nhay;
	float originalY;
public:
	Gach(float, float);
	~Gach();

	virtual void UpdatePosition();
	virtual void Render();

	void OnCollisionWithMario(CollisionDirection);
	void OnCollisionWithTurtle(Turtle*, CollisionDirection);
	void XuatHienDongTien();
};

#endif
