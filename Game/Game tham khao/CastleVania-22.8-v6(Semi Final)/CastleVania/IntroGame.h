#ifndef _INTROGAME_H
#define _INTROGAME_H

#include "HeaderObj.h"

class IntroGame
{
public:	
	IntroGame();
	~IntroGame(void);
	GameObject* _helicopter;
	GameObject* _simon;
	GameObject* _bat1;
	GameObject* _bat2;
	GameObject* _bat3;

	GameObject* _introScene;

	bool _loadOK;
	void Update(int dt);
	void Draw(CCamera*);
};

#endif