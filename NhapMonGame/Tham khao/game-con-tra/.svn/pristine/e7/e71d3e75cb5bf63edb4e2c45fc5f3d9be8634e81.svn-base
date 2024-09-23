#ifndef __CWIN_SCENSE_H__
#define __CWIN_SCENSE_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CScense.h"

class CWinScense : public CScense
{
public:
	CWinScense();
	CWinScense(string);
	CWinScense(string, string);
	CWinScense(const std::vector<int>& info);
	virtual ~CWinScense(){};
	std::string ClassName(){ return __CLASS_NAME__(CWinScense); };
	void Update(float deltaTime);
	void Move(float deltaTime);
	void Draw();
	void Init();
	void InitTitile();
	void InitMessage();
	RECT* GetRectRS();
protected:
	float m_timeDelay;
	bool m_isHided;
	string m_title;
	string m_Message;
public:
	CWordItem** m_listTitleWord;
	CWordItem** m_listMessageWord;
	int lenghtTitleWord;
	int lenghtMessageWord;
};

#endif // !__CWIN_SCENSE_H__
