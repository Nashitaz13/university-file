#include "Resource.h"

// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
// Toan bo Sprite cua game se Load mot lan va luu tru o day
// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

CSprite* marioSprite;
CSprite* LmarioSprite;
CSprite *marioStarSprite;
CSprite *LmarioStarSprite;
CSprite *background1;
CSprite *background1_1;
CSprite *background2;
CSprite *background2_1;


void iniSprite()
{
	marioSprite = new CSprite("Image\\marioSprite.png");
	LmarioSprite = new CSprite("Image\\LmarioSprite.png");
	marioStarSprite = new CSprite("Image\\marioStarSprite.png");
	LmarioStarSprite = new CSprite("Image\\LmarioStarSprite.png");
	background1 = new CSprite("Map\\Lv1\\Sprite.png");
	background1_1 = new CSprite("Map\\Lv1.1\\Sprite.png");
	background2 = new CSprite("Map\\Lv2\\Sprite.png");
	background2_1 = new CSprite("Map\\Lv2.1\\Sprite.png");
}

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
