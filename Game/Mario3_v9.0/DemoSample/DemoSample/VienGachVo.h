#pragma once
#ifndef __VienGachVo_H__
#define __VienGachVo_H__

#include "MovableObject.h"
#include "Resource.h"

#define DISTANCE_X1 30
#define DISTANCE_Y1 35
#define DISTANCE_X2 15
#define DISTANCE_Y2 10
#define VIENGACHVO_VELLOCITY_X 0.1

class VienGachVo : public MovableObject
{
private:
	D3DXVECTOR3* _Vector1;
	D3DXVECTOR3* _Vector2;
	float xLeft, xRight;
	float y1, y2;
private:
	float CalculateY(D3DXVECTOR3, float);
public:
	VienGachVo(float, float);
	~VienGachVo();
	virtual void Render();
	virtual void UpdatePosition();
};

#endif