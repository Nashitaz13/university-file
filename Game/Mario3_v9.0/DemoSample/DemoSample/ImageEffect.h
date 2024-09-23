#pragma once
#ifndef __ImageEffect_H__
#define __ImageEffect_H__

#include "MovableObject.h"
using namespace std;

class ImageEffect : public MovableObject
{
private:
	int Type;
public:
	ImageEffect(float, float, int);
	~ImageEffect();

	//virtual void UpdatePosition();
	virtual void Render();
	virtual void SetX(float);				// Set x va currBox->x
	virtual void SetY(float);
	virtual void SetXY(float, float);
};
#endif

