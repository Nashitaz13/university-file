#pragma once
#include "CGlobal.h"
#include "Include.h"
#include "Texture.h"
#include "State.h"
#include "Sprite.h"
class CStateMain: public CState
{
public:
	CStateMain();

	virtual ~CStateMain();
	void Init();
	void Update(float deltaTime);
	void Render();
	void Destroy();

	int m_count;
	CSprite* sprite;
	CTexture** texture;
};

