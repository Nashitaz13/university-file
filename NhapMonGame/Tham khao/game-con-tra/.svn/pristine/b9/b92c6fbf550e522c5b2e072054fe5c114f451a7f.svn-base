#ifndef __CSCENSE_MANAGEMENT_H__
#define __CSCENSE_MANAGEMENT_H__
#include "CState.h"
#include "CMenuGameScense.h"
#include "CGameOverItem.h"
#include "CScoreScense.h"
#include "CWinScense.h"

#define _STRING_GAME_OVER_ "GAME COMPLETE"
#define _STRING_THANKS_PLAY "THANKS FOR PLAY"
class CScenseManagement
{
public:
	CScenseManagement();
	CScenseManagement(int);
	virtual ~CScenseManagement();
	void Init();
	void Update(float deltaTime);
	void Move(float deltaTime);
	void Render();
	void Destroy();
protected:
	int m_mapId;
	CGameOverItem* m_gameOverItem;
	CScoreScense* m_scoreGameOver;
	CScoreScense* m_scoreWin;
	CWinScense* m_thankScense;
	bool m_isLoadScenseGameComplete;
	float m_timeDelay;
	float m_timeDelayLoadMapNew;
public:
	static bool m_isGameOverred;
	static bool m_isWinScenseShowed;
	static bool m_isGameWinner;
};

#endif // !__CSCENSE_MANAGEMENT_H__
