#ifndef __CQUAD_OBJECT_H__
#define __CQUAD_OBJECT_H__
#include "CGameObject.h"

class CQuadObject
{
public:
	int GetID(){return m_Id;};
	CGameObject* GetGameObject(){return this->m_obj;};
	CQuadObject();
	CQuadObject(int iD, CGameObject*&);
	~CQuadObject();
protected:
	int m_Id;
	CGameObject* m_obj;
};

#endif // !__CQUAD_OBJECT_H__
