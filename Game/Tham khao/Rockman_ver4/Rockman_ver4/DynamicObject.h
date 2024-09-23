#ifndef __CDYNAMIC_OBJECT_H__
#define __CDYNAMIC_OBJECT_H__


#include "GameObject.h"
#include "Move.h"
//#include <list>

class CDynamicObject : public CGameObject, public CMove
{
public:
	virtual void MoveUpdate(float DeltaTime);// overide IMOVE
	virtual std::string ClassName();
	virtual void Update(float deltaTime);
	virtual void Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision);

	CDynamicObject(void);
	CDynamicObject(std::vector<std::string> arr);
	~CDynamicObject(void);
};

#endif // !__DYNAMIC_OBJECT_H__