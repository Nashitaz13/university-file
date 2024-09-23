#pragma once
#include "csprite.h"
class SimonFightingSprite :
	public CSprite
{
public:
	SimonFightingSprite(void);

	SimonFightingSprite(CTexture* texture, int start, int end, int timeAnimation);

	void Next();

	void Update(int deltaTime_);

	~SimonFightingSprite(void);
};

