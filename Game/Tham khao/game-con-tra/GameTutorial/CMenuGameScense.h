#ifndef __CMENU_GAME_SCENSE_H__
#define __CMENU_GAME_SCENSE_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CChooseItem.h"
#include "CScoreScense.h"

class CMenuGameScense : public CStaticObject, public CAnimation
{
public:
	CMenuGameScense(void);
	CMenuGameScense(const std::vector<int>& info);
	~CMenuGameScense();
	std::string ClassName(){ return __CLASS_NAME__(CMenuGameScense); };
	virtual void Update(float deltaTime);
	virtual void Move(float deltaTime);
	virtual void Draw();
	RECT* GetRectRS();
protected:
	void Init();
	float m_timeDelay;
	float m_timeDelayHiding;
public: 
	static int m_mapId;
	CChooseItem* m_itemChoose;
	CScoreScense* m_scoreScense;
	bool m_isMoveComplete;
	bool m_isPlaySoundMenu;
	bool m_isChoosePlay;
	bool m_isCanShowScoreScense;
	bool m_isHided;
};

#endif // !__CMENU_GAME_SCENSE_H__
