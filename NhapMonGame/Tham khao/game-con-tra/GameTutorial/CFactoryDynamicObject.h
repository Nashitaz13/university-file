#ifndef __CFACTORY_DYNAMIC_OBJECT_H__
#define __CFACTORY_DYNAMIC_OBJECT_H__

#include "CGlobal.h"
#include "CFactoryObject.h"
#include "CGameObject.h"
#include "CSingleton.h"

class CFactoryDynamicObject : public CFactoryObject, public CSingleton<CFactoryDynamicObject>
{
	friend class CSingleton<CFactoryDynamicObject>;
public:
	CFactoryDynamicObject() : CFactoryObject(){};
public:
	~CFactoryDynamicObject();
	virtual CGameObject* CreateObject(int idObject);
	virtual CGameObject* CreateObject(const std::vector<int>& info);
};

#endif // !__CFACTORY_DYNAMIC_OBJECT_H__
