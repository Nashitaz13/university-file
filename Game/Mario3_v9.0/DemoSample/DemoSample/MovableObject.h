#pragma once
#ifndef __MovableObject_H__
#define __MovableObject_H__

#include "MyRectangle.h"
#include "BasicObject.h"
#include "Resource.h"

#define GRAVITY -0.05f

class MovableObject : public BasicObject
{
public:
	MyRectangle *currRect, *preRect;
	SpriteEffects effect;

public:
	MovableObject();
	MovableObject(float, float, float, float);
	~MovableObject();
	virtual void UpdatePosition() {};
	virtual void UpdateRootPosition() {};
	virtual void UpdateCollision() {};
	virtual void Render() {};				// Render object
	virtual void SetX(float x);				// Set x va currBox->x
	virtual void SetY(float y);				// Set y va currBox->y
	virtual void SetXY(float x, float y);	// Set x, y va currBox->x, currBox->y
};

#endif