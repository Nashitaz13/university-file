#pragma once
#ifndef __Resource_H__
#define __Resource_H__

#include "Sprite.h"


enum SpriteEffects
{
	SE_right,
	SE_left,
};

// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// Toan bo Sprite cua game se Load mot lan va luu tru o day
// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

extern CSprite *marioSprite;
extern CSprite *LmarioSprite;
extern CSprite *marioStarSprite;
extern CSprite *LmarioStarSprite;
extern CSprite *background1;
extern CSprite *background1_1;
extern CSprite *background2;
extern CSprite *background2_1;

void iniSprite();

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

#endif
