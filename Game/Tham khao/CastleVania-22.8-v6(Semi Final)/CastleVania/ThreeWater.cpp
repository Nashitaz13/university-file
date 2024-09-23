#include "ThreeWater.h"


ThreeWater::ThreeWater(void)
{
}

ThreeWater::ThreeWater(float posX, float posY)
{	
	w = new list<Water*>();
	w->push_back(new Water(posX, posY, -0.01));
	w->push_back(new Water(posX, posY, -0.2));
	w->push_back(new Water(posX, posY, 0.2));
}

void ThreeWater::Update(int dt)
{	
	for (list<Water*>::iterator i = w->begin(); i != w->end(); i++)
	{
		if((*i)->active)
			(*i)->Update(dt);
	}
}

void ThreeWater::Draw(CCamera* camera)
{
	for (list<Water*>::iterator i = w->begin(); i != w->end(); i++)
	{
		if((*i)->active)
			(*i)->Draw(camera);
	}
}

ThreeWater::~ThreeWater(void)
{
}
