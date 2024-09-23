#include "SimonFightingSprite.h"


SimonFightingSprite::SimonFightingSprite(void)
{
}

SimonFightingSprite::SimonFightingSprite(CTexture* texture, int start, int end, int timeAnimation):CSprite(texture, start, end, timeAnimation)
{

}

void SimonFightingSprite::Next() 
{
	_index++;
}


void SimonFightingSprite::Update(int ellapseTime)
{
	_timeLocal += ellapseTime;

	if(_timeLocal >= _timeAni) 
	{
		this->Next();
		_timeLocal = 0;
	}
}


SimonFightingSprite::~SimonFightingSprite(void)
{
}
