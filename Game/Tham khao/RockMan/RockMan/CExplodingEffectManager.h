//-----------------------------------------------------------------------------
// File: CExplodingEffectManager.h
//
// Desc: Định nghĩa lớp quản lý các hiệu ứng nổ của quái
//
//-----------------------------------------------------------------------------
#ifndef _CEXPLODING_EFFECT_MANAGER_H_
#define _CEXPLODING_EFFECT_MANAGER_H_

#include "CObject.h"
#include "ExplodingEffect.h"

class CExplodingEffectManager
{
private:
	CExplodingEffectManager();

	~CExplodingEffectManager();

	static CExplodingEffectManager* _instance;
	vector<CExplodingEffect*>		_effectedList;

public:
	static CExplodingEffectManager* GetInstance();

	static void Add(CExplodingEffect* effect);

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	static void Render(CGameTime* gameTime, CGraphics* graphics);

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	static void Update(CGameTime* gameTime);
};

#endif // !_EXPLODING_EXFFECT_MANAGER_H_
