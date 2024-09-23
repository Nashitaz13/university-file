#ifndef __CDYNAMIC_OBJECT_H__
#define __CDYNAMIC_OBJECT_H__


#include "CGameObject.h"
#include "CMove.h"
//#include <list>

class CDynamicObject : public CGameObject, public CMove
{
public:
	virtual void MoveUpdate(float DeltaTime);// overide IMOVE
	virtual std::string ClassName();
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision);
	virtual void OnCollision(float deltatime, std::vector<CGameObject*>* listObjectCollision);
	CDynamicObject(void);
	CDynamicObject(const std::vector<int>& info);
	~CDynamicObject(void);
};

#endif // !__DYNAMIC_OBJECT_H__