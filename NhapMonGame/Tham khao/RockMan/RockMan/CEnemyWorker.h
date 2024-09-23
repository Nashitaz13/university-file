//-----------------------------------------------------------------------------
// File: CEnemyWorker.h
//
// Desc: Định nghĩa lớp CEnemyWorker
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_WORKER_H_
#define _CENEMY_WORKER_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "Config.h"
#include "CGlobal.h"
#include "CRockman.h"
#include <stdlib.h>
#include "CEnemyWorkerBullet.h"
#include "CollisionInfo.h"
#include <list>

enum class ENEMYWORKER_STATE
{
	JUMPING,//Nhảy
	DEFENSE,//phòng thủ
	ATTACK//tấn công
};

class CEnemyWorker :public CEnemy
{
public:
	CEnemyWorker(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, float vX, Vector2 positionBegin, int dame, int blood = 30, int score=SCORE_DEFAULT);
	~CEnemyWorker();

	int Initlize() override;

	void Update(CGameTime* gameTime, CRockman* rockman) override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

	CEnemyWorker* ToValue() override;

	vector<CBullet*> Fire() override;

private:
	//Reset các biến lưu giữ trạng thái Collide
	void ResetCollideVariable();
	// Cho biết trạng thái 
	ENEMYWORKER_STATE _state;
	// Danh sách đạn bắn ra
	vector<CBullet*> _lstBullet;
	// Thời gian tấn công hoặc thời gian phòng thủ còn lại. Đơn vị là Tick
	int _timeAttackOrDefenseRemain;
	// Thời gian giữa 2 lần bắn đạn. Đơn vị là Tick
	int _timeDelayFireRemain;//
	// Hiệu ứng nổ
	CSprite _spriteExplodingEffect;
	// Vị trí tấn công
	Vector2 _positionAttack;
	//Lưu giữ những thông tin va chạm các hướng gần nhất
	list<CollisionInfo> _collidedInfoLst;
	//Hướng quay của Sprite
	SpriteEffects _spriteEffect;

	// Cho biết là đối tượng đã xuất hiện hay chưa
	bool _isAppeared;
	// Cho biết là đã trừ máu vì va chạm đạn chưa
	bool _isHitDame;
};

#endif // !_CENEMY_WORKER_H_