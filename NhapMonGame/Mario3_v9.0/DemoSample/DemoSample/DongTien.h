#pragma once
#ifndef __DongTien_H__
#define __DongTien_H__

#include "MovableObject.h"
#include "Resource.h"

class DongTien : public MovableObject
{
public:
	bool isNhay = false;
	float originalY;
public:
	DongTien(float, float, bool);
	~DongTien();

	virtual void UpdatePosition();
	virtual void Render();

	void OnCollisionWithMario();
	void SetNhay();
};

#endif
