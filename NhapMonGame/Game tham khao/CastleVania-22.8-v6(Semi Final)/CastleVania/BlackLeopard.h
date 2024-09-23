#ifndef _BLACKLEOPARD_H_
#define _BLACKLEOPARD_H_

#include "DynamicObject.h"
#include "CEnum.h"

class BlackLeopard :public DynamicObject
{
private:
	void Jump();
public:
	bool _hasJump;
	float _heightJump;

	BlackLeopard(void);
	BlackLeopard(float _x, float _y);
	void Update(int dt);
	void Collision(list<GameObject*> obj, int dt);
	void SetActive(float x, float y);
	void Draw(CCamera* camera);
	~BlackLeopard(void);
};

#endif