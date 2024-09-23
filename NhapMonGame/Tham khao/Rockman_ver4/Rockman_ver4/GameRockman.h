#pragma once
#ifndef __CGAME_CONTRA_H__
#define __CGAME_CONTRA_H__

#pragma once
#include "Game.h"
#include "ViewWindows.h"

using namespace Rockman;
class CGameRockman : public CGame
{
public:
	CGameRockman();
	virtual ~CGameRockman(){};

	virtual void Init();
	virtual void ProcessInput();
	virtual void Destroy();
};
#endif // !__CGAME_CONTRA_H__
