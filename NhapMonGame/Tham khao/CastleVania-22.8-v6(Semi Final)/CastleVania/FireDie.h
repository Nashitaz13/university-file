#ifndef _FIREDIE_H_
#define _FIREDIE_H_

#include "DynamicObject.h"
#include "CEnum.h"
#include <time.h>
#include <random>


class FireDie :public DynamicObject
{
public:
	int deltatime;
	FireDie(void);
	FireDie(float x, float y);
	void Update(int dt);
	void Collision(list<GameObject*> obj, int dt);
	~FireDie(void);
};

#endif