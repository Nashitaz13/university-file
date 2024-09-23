#ifndef __CGAME_CONTRA_H__
#define __CGAME_CONTRA_H__

#pragma once
#include "CGame.h"
#include "CView.h"

using namespace GameTutorial;

class CGameContra : public CGame
{
public:
	CGameContra();
	virtual ~CGameContra(){};
protected:
	virtual void Init();
	virtual void ProcessInput();
	virtual void Destroy();
};
#endif // !__CGAME_CONTRA_H__
