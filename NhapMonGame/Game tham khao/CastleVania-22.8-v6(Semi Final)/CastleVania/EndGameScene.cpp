
#include "EndGameScene.h"



EndGameScene::EndGameScene():Scene(ESceneState::EndGame_Scene)
{
	
	camera = new CCamera();
}

void EndGameScene::RenderFrame(LPDIRECT3DDEVICE9 d3ddv, int t)
{
	this->_fallingCasle->Update(t);
	G_SpriteHandler->Begin(D3DXSPRITE_ALPHABLEND);
	this->_fallingCasle->Draw(camera);
	G_SpriteHandler->End();
	
}
//virtual void ProcessInput(int keyCode);
void EndGameScene::LoadResources(LPDIRECT3DDEVICE9 d3ddv)
{
	_fallingCasle = new FallingCastle(257,225);
	HRESULT res = D3DXCreateSprite(d3ddv,&G_SpriteHandler);
	SoundManager::GetInst()->RemoveAllBGM();
	SoundManager::GetInst()->PlayBGSound(EBGSound::EEndGameSound);
}

void EndGameScene::OnKeyDown(int KeyCode)
{
	switch(KeyCode)
	{
	case DIK_RETURN:
		if(this->_fallingCasle->isFalled())
			sceneState = ESceneState::Menu_Scene;
		break;
	default:
		break;
	}
}

EndGameScene::~EndGameScene(void)
{
}
