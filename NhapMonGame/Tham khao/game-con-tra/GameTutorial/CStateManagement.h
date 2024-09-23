#ifndef __CSTATEMANAGEMENT_H__
#define __CSTATEMANAGEMENT_H__

#include "CSingleton.h"
#include "CState.h"

class CStateManagement : public CSingleton<CStateManagement>
{
	friend class CSingleton<CStateManagement>;
public:
	//static CStateManagement* m_instante;
	//static CStateManagement* GetInstance();
	void Update(bool isUpdate, float deltaTime);
	void ChangeState(CState* );
protected:
	CStateManagement(): m_pNext(0), m_pCurrent(0){}
protected:
	CState* m_pNext;
	CState* m_pCurrent;
};
#endif // !__CSTATEMANAGEMENT_H__
