//-----------------------------------------------------------------------------
// File: CEnemyBoom.h
//
// Desc: Định nghĩa lớp CEnemyBoom
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_BOOM_H_
#define _CENEMY_BOOM_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "Config.h"
#include "CGlobal.h"
#include "CRockman.h"
#include "CEnemyBoomBullet.h"
#include <stdlib.h>
#include "ExplodingEffect.h"

enum class ENEMYBOOM_STATE
{
	FLYING,
	EXPLODING,
	DELAY
};

class CEnemyBoom : public CEnemy
{
public:
	CEnemyBoom(int id, int typeID, CSprite spriteEnemyBoom, CSprite spriteExplodingEffect, float vy, Vector2 positionBegin, int dame, int blood = 2, int score = SCORE_DEFAULT);
	~CEnemyBoom();

	int Initlize() override;

	void Update(CGameTime* gameTime, CRockman* rockman) override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

	CEnemyBoom* ToValue() override;

	vector<CBullet*> Fire() override;

private:
	// Tấn công Rockman
	void AttackRockman(float deltaTime);
	//Lưu giữ vận tốc ban đầu
	Vector2 _vBegin;
	// Cho biết trạng thái là đang tấn công hay không?
	ENEMYBOOM_STATE _state;
	// Danh sách đạn bắn ra
	vector<CBullet*> _lstBullet;
	// Thời gian nghỉ giữa 2 tấn công. Đơn vị là Tick
	int _timeDelayAttackRemain;
	//Đối tượng tạo hiệu ứng nổ
	CExplodingEffect* _explodingEffect;
	//Lưu lại vị trí xuất hiện ban đầu
	Vector2 _positionBegin;
};

#endif // !_CENEMY_BOOM_H_