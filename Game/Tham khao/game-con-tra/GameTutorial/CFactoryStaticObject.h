#ifndef __CFACTORY_STATIC_OBJECT_H__
#define ____CFACTORY_STATIC_OBJECT_H__

#include "CGlobal.h"
#include "CFactoryObject.h"
#include "CGameObject.h"
#include "CSingleton.h"

class CFactoryStaticObject : public CFactoryObject, public CSingleton<CFactoryStaticObject>
{
	friend class CSingleton<CFactoryStaticObject>;
public:
	CFactoryStaticObject() : CFactoryObject(){};
public:
	~CFactoryStaticObject();
	virtual CGameObject* CreateObject(int idObject);
	virtual CGameObject* CreateObject(const std::vector<int>& info);
};

#endif // !__CFACTORY_STATIC_OBJECT_H__
