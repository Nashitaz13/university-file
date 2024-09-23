#ifndef _FISHMAN_H_
#define _FISHMAN_H_

#include "DynamicObject.h"
#include "CEnum.h"
#include "Water.h"
#include "FireBall.h"

class FishMan : public DynamicObject
{
private:
	void Jump();
public:
	bool _hasJump;
	float _heightJump;
	list<Water*> *w;
	list<FireBall*> *fireBall;

	FishMan(void);
	FishMan(float x, float y);
	void Update(int dt);
	void Draw(CCamera* camera);
	void Collision(list<GameObject*> obj, int dt);
	void SetActive(float x, float y);
	~FishMan(void);
};
#endif
