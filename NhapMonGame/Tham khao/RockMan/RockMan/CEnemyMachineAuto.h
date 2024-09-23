//-----------------------------------------------------------------------------
// File: CEnemyMachineAuto.h
//
// Desc: Định nghĩa lớp CEnemyMachineAuto
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_MACHINE_AUTO_H_
#define _CENEMY_MACHINE_AUTO_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "Config.h"
#include "CGlobal.h"
#include "CRockman.h"
#include "CEnemyMachineAutoBullet.h"
#include <stdlib.h>

enum class ENEMYMACHINEAUTO_ORIENTATION
{
	TOP,
	BOTTOM
};

class CEnemyMachineAuto :public CEnemy
{
public:
	CEnemyMachineAuto(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, int spriteIDBullet, ENEMYMACHINEAUTO_ORIENTATION orientation, Vector2 v, Vector2 positionBegin, int dame, int blood = 10, int score=SCORE_DEFAULT);
	~CEnemyMachineAuto();

	int Initlize() override;

	void Update(CGameTime* gameTime, CRockman* rockman) override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

	CEnemyMachineAuto* ToValue() override;

	vector<CBullet*> Fire() override;

private:
	// Tấn công Rockman
	void AttackRockman(float deltaTime);
	// Cho biết trạng thái là đang tấn công hay không?
	//ENEMYMACHINEAUTO_STATE _state;
	// Danh sách đạn bắn ra
	vector<CBullet*> _lstBullet;
	// Thời gian tấn công. Đơn vị là Tick
	int _timeAttackRemain;
	// Thời gian giữa 2 lần bắn đạn. Đơn vị là Tick
	int _timeDelayFireRemain;
	// Hướng canh của Enemy Machine Auto
	ENEMYMACHINEAUTO_ORIENTATION _orientation;
	// Hiệu ứng nổ
	CSprite _spriteExplodingEffect;
	//ID_SPRITE_BULLET của EnemyMachineAuto này
	int _spriteIdBullet;
	// Cho biết là đã trừ máu vì va chạm đạn chưa
	bool _isHitDame;
};

#endif // !_CENEMY_MACHINE_AUTO_H_