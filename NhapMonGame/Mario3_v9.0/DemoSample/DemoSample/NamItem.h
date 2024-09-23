#pragma once
#ifndef __NamItem_H__
#define __NamItem_H__

#include "MovableObject.h"
#include "Resource.h"
#include <vector>

#define NAMITEM_VELLOCITY_X 0.05

class ODauHoi;
class Gach;

class NamItem : public MovableObject
{
private:
	float originalY;
	void VaChamNen(BasicObject*, CollisionDirection);
	int Up;
	bool Hide;
	DWORD _Tick_Star;
public:
	int Loai;
public:
	NamItem(float, float, int, int);
	~NamItem();

	virtual void UpdatePosition();
	virtual void Render();					// Render object
	virtual void SetX(float);				// Set x va currBox->x
	virtual void SetY(float);
	virtual void SetXY(float, float);

	// Xu ly va cham voi ground
	void OnCollisionWithGround(BasicObject*, CollisionDirection);
	void OnCollisionWithODauHoi(ODauHoi*, CollisionDirection);
	void OnCollisionWithGach(Gach*, CollisionDirection); 
	void OnCollisionWithMario(); //8.4.3
};

#endif

