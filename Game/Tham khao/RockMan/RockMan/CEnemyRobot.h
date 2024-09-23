//-----------------------------------------------------------------------------
// File: CEnemyRobot.h
//
// Desc: Định nghĩa lớp CEnemyRobot
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_ROBOT_H_
#define _CENEMY_ROBOT_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "Config.h"
#include "CGlobal.h"
#include "CRockman.h"
#include "CBlock.h"
#include <stdlib.h>
#include "CollisionInfo.h"
#include <list>

enum ENEMYROBOT_STATE
{
	STANDING,
	JUMPING
};

using namespace std;

class CEnemyRobot :public CEnemy
{
public:
	CEnemyRobot(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, Vector2 positionBegin, int dame, int blood = 50, int score=SCORE_DEFAULT);
	~CEnemyRobot();

	int Initlize() override;

	void Update(CGameTime* gameTime, CRockman* rockman) override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

	CEnemyRobot* ToValue() override;

private:
	//Reset các biến lưu giữ trạng thái Collide
	void ResetCollideVariable();
	//Tấn công Rockman
	void Jump(float deltaTime);
	//Cho biết trạng thái là đang ở trên không trung hay là đang tiếp đất?
	ENEMYROBOT_STATE _state;
	//Biến này để lưu vị trí y dừng nhảy. Khi Add vào project thực thì xóa cái này đi vì không cần nó nữa, đã dùng va chạm để tìm điểm dừng rồi
	float _pyOriginal;
	//Thời gian ở trạng thái đứng còn lại. Đơn vị là Tick.
	float _timeStandingRemain;
	//Lưu giữ những thông tin va chạm các hướng gần nhất
	list<CollisionInfo> _collidedInfoLst;
	//Hướng lật sprite
	SpriteEffects _spriteEffect;
	// Hiệu ứng nổ
	CSprite _spriteExplodingEffect;
	// Cho biết là đã trừ máu vì va chạm đạn chưa
	bool _isHitDame;
};

#endif // !_CENEMY_BUBBLE_H_