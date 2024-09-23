#pragma once
#include "CBullet.h"
#include "ExplodingEffect.h"

class CEnemyWorkerBullet : public CBullet
{
public:
	//Hàm khởi tạo đạn
	//	+ angleFly: Góc bay tạo bởi quỹ đạo của viên đạn với trục Ox dương (không vượt quá 2PI). Đơn vị Radian
	//	+ v0: vận tốc di chuyển tổng hợp của Vx và Vy của viên đạn
	CEnemyWorkerBullet(int id, int typeID, CSprite sprite, int dame, Vector2 beginPosition, float lMaxJump, float angleJump);
	virtual ~CEnemyWorkerBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

private:
};

