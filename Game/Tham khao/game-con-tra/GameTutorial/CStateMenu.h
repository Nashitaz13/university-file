#ifndef __CSTATEMENU_H__
#define __CSTATEMENU_H__
#include "CState.h"
#include "CMenuGameScense.h"
#include "CScoreScense.h"

class CStateMenu : public CState
{
public:
	CStateMenu();
	virtual ~CStateMenu();
	void Init();
	void Update(float deltaTime);
	void Render();
	void Destroy();
protected:
	CMenuGameScense* mainMenu;
};

#endif // !__CSTATEMENU_H__

