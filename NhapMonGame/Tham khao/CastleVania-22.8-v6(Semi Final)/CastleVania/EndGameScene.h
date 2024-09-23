#pragma once
#include "scene.h"
#include "Singleton.h"
#include "FallingCastle.h"

class EndGameScene :
	public Scene
{
protected:
	FallingCastle* _fallingCasle;

public:
	EndGameScene();

	virtual void RenderFrame(LPDIRECT3DDEVICE9 d3ddv, int t);
	//virtual void ProcessInput(int keyCode);
	virtual void LoadResources(LPDIRECT3DDEVICE9 d3ddv);
	virtual void OnKeyDown(int KeyCode);



	~EndGameScene(void);
};

