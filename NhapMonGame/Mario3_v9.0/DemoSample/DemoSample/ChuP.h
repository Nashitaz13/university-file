#pragma once
#ifndef __ChuP_H__
#define __ChuP_H__

#include <vector>
#include "MovableObject.h"
#include "Resource.h"
#include "ChuP_Off.h"

using namespace std;

class ChuP : public MovableObject
{
public:
	ChuP(float, float);
	~ChuP();

	virtual void Render();
	void OnCollisionWithMario();
};

#endif
