//-----------------------------------------------------------------------------
// File: CEnemyWallShooter.h
//
// Desc: Định nghĩa lớp CEnemyWallShooter
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_WALL_SHOOTER_H_
#define _CENEMY_WALL_SHOOTER_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "Config.h"
#include "CGlobal.h"
#include "CRockman.h"
#include "CEnemyMachineAutoBullet.h"
#include <stdlib.h>

//Hướng bắn của súng (hướng bay của đạn)
enum class ENEMYWALLSHOOTER_ORIENTATION
{
	RIGHT,
	LEFT
};

enum class ENEMYWALLSHOOTER_STATE
{
	DEFENSE,//phòng thủ
	ATTACK//tấn công
};

class CEnemyWallShooter :public CEnemy
{
public:
	CEnemyWallShooter(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, ENEMYWALLSHOOTER_ORIENTATION orientation, Vector2 v, Vector2 positionBegin, int dame, int blood = 2, int score=SCORE_DEFAULT);
	~CEnemyWallShooter();

	int Initlize() override;

	void Update(CGameTime* gameTime, CRockman* rockman) override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

	CEnemyWallShooter* ToValue() override;

	vector<CBullet*> Fire() override;

private:
	// Cho biết trạng thái là đang tấn công hay phòng thủ?
	ENEMYWALLSHOOTER_STATE _state;
	// Danh sách đạn bắn ra
	vector<CBullet*> _lstBullet;
	// Thời gian giữa 2 viên đạn được bắn ra. Đơn vị là Tick
	int _timeDelayFireRemain;
	// Thời gian giữa 2 lần tấn công (thời gian phòng thủ). Đơn vị là Tick
	int _timeDefense;
	// Hướng canh của Enemy Wall Shooter
	ENEMYWALLSHOOTER_ORIENTATION _orientation;
	// Hiệu ứng nổ
	CSprite _spriteExplodingEffect;
	// Số thứ tự của viên đạn trước đó đã bắn. Bắt đầu từ 1;
	int _numOfPrevBullet;
	// Cho biết là đã trừ máu vì va chạm đạn chưa
	bool _isHitDame;
};

#endif // !_CENEMY_WALL_SHOOTER_H_