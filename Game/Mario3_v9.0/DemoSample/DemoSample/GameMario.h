#pragma once
#ifndef __GameMario_H__
#define __GameMario_H__
#include "QuadTree.h"
#include "Game.h"
#include "BGLevel1.h"
#include "mario.h"
#include "World.h"
#include "GameInformation.h"

class GameMario : public CGame
{
private:
	// Update lai ViewPort sau moi Frame game
	void UpdateViewPort();
	QuadTree* quadtree2;
public:
	GameMario(HINSTANCE hInstance);
	~GameMario();

	virtual void Init();
	virtual void RenderFrame();
	virtual void Update();
};

#endif

