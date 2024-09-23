#ifndef __CWordItem_ITEM_H__
#define __CWordItem_ITEM_H__

#include "CStaticObject.h"
#include "CAnimation.h"

class CWordItem : public CStaticObject, public CAnimation
{
public:
	CWordItem(int number);
	CWordItem(const std::vector<int>& info);
	~CWordItem();
	std::string ClassName(){ return __CLASS_NAME__(CWordItem); };
	virtual void Update(float deltaTime);
	RECT* GetRectRS();
protected:
	void Init();
	void InitWord();
	float m_timeDelay;
	int m_numberWord;
};

#endif // !__CWordItem_ITEM_H__
