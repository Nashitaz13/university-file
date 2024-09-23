#ifndef _MAGICALCRYSTAL_H_
#define _MAGICALCRYsTAL_H_

#include "DynamicObject.h"
#include "CEnum.h"

class MagicalCrystal: public DynamicObject
{
public:
	MagicalCrystal(void);
	MagicalCrystal(float x, float y);
	void Collision(list<GameObject*> obj, int dt);
	~MagicalCrystal(void);
};

#endif