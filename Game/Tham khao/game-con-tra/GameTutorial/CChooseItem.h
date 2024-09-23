#ifndef __CCHOOSE_ITEM_H__
#define __CCHOOSE_ITEM_H__

#include "CStaticObject.h"
#include "CAnimation.h"

class CChooseItem : public CStaticObject, public CAnimation
{
public:
	CChooseItem(void);
	CChooseItem(const std::vector<int>& info);
	~CChooseItem();
	std::string ClassName(){ return __CLASS_NAME__(CChooseItem); };
	RECT* GetRectRS();
protected:
	void Init();
public:
	int m_SelectedId;
};

#endif // !__CCHOOSE_ITEM_H__
