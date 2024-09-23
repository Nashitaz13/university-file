#ifndef _THREEWATER_H_
#define _THREEWATER_H_

#include "Water.h"

class ThreeWater
{
public:
	list<Water*> *w;
	ThreeWater(void);
	ThreeWater(float, float);
	void Draw(CCamera*);
	void Update(int dt);
	~ThreeWater(void);
};

#endif