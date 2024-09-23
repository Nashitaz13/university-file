#include "CExplodingEffectManager.h"

CExplodingEffectManager* CExplodingEffectManager::_instance = NULL;

CExplodingEffectManager::CExplodingEffectManager()
{

}

CExplodingEffectManager::~CExplodingEffectManager()
{

}

CExplodingEffectManager* CExplodingEffectManager::GetInstance()
{
	if (_instance == NULL)
	_instance = new CExplodingEffectManager();
	
	return _instance;
}

void CExplodingEffectManager::Add(CExplodingEffect* effect)
{
	CExplodingEffectManager::GetInstance()->_effectedList.push_back(effect);
}

void CExplodingEffectManager::Render(CGameTime* gameTime, CGraphics* graphics)
{
	for (int i = 0; i < CExplodingEffectManager::GetInstance()->_effectedList.size(); i++)
		CExplodingEffectManager::GetInstance()->_effectedList[i]->Render(gameTime, graphics);
}

void CExplodingEffectManager::Update(CGameTime* gameTime)
{
	int count = CExplodingEffectManager::GetInstance()->_effectedList.size();

	for (int i = 0; i < count; i++)
	{
		CExplodingEffectManager::GetInstance()->_effectedList[i]->Update(gameTime);
		CExplodingEffectManager::GetInstance()->_effectedList[i]->UpdateBox();

		if (CExplodingEffectManager::GetInstance()->_effectedList[i]->IsDone())
		{
			CExplodingEffectManager::GetInstance()->_effectedList.erase(CExplodingEffectManager::GetInstance()->_effectedList.begin() + i);
			count -= 1;
			i -= 1;
		}
	}
}