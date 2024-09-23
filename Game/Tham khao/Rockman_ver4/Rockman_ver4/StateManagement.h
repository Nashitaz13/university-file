#pragma once
#ifndef __CSTATEMANAGEMENT_H__
#define __CSTATEMANAGEMENT_H__

#include "CSingleton.h"
#include "State.h"
class CStateManagement : public CSingleton<CStateManagement>
{
	friend class CSingleton<CStateManagement>;
public:

	void Update(bool isUpdate, float deltaTime);
	void ChangeState(CState*);

	CStateManagement() : m_pNext(0), m_pCurrent(0){}

	CState* m_pNext;
	CState* m_pCurrent;

};
#endif // !__CSTATEMANAGEMENT_H__
