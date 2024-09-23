#ifndef __CSTATIC_OBJECT__H__
#define __CSTATIC_OBJECT__H__

#include "CGameObject.h"

class CStaticObject : public CGameObject
{
public:
	virtual std::string ClassName() = 0;
	CStaticObject(void);
	CStaticObject(const std::vector<int>& info);
	~CStaticObject(void);
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision);
	virtual void OnCollision(float deltatime, std::vector<CGameObject*>* listObjectCollision);
};
// ;)
#endif