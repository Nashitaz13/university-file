#ifndef _BAT_H_
#define _BAT_H_

#include "DynamicObject.h"
#include "CEnum.h"

class VampireBat :public DynamicObject
{
public:
	bool getUp;

	VampireBat(void);
	VampireBat(float x, float y);
	void MoveSinPath(int deltaTime);
	void Update(int deltaTime);
	void Draw(CCamera* camera);
	void SetActive(float x, float y);
	void Collision(list<GameObject*> obj, int dt);
	~VampireBat(void);
};

#endif