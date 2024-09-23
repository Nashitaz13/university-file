#ifndef __CSCENSE_H__
#define __CSCENSE_H__

#include "CStaticObject.h"
#include "CAnimation.h"
#include "CWordItem.h"

class CScense : public CStaticObject, public CAnimation
{
public:
	CScense();
	virtual ~CScense(){};
	std::string ClassName(){ return __CLASS_NAME__(CScense); };
	virtual void Update(float deltaTime) = 0;
	virtual void Move(float deltaTime) = 0;
	virtual void Draw() = 0;
	virtual void Init() = 0;
	int InitWord(char);
};
#endif // !__CSCENSE_H__
