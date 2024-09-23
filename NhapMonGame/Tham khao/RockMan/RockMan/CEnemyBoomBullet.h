#pragma once
#include "CBullet.h"
#include "ExplodingEffect.h"

class CEnemyBoomBullet : public CBullet
{
public:
	//Hàm khởi tạo đạn
	//	+ angleFly: Góc bay tạo bởi quỹ đạo của viên đạn với trục Ox dương (không vượt quá 2PI). Đơn vị Radian
	//	+ v0: vận tốc di chuyển tổng hợp của Vx và Vy của viên đạn
	CEnemyBoomBullet(int id, int typeID, CSprite spriteBullet, CSprite spriteExplodingEffect, int dame, Vector2 beginPosition, float lMaxJump, float angleJump);
	virtual ~CEnemyBoomBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;

private:
	//Đối tượng vẽ hiệu ứng nổ
	CExplodingEffect* _explodingEffect;
	//Thời gian xảy ra va chạm ngắn nhất
	float _minCollideDeltaTime;
	//Hướng xảy ra va chạm với vật gần nhất
	CDirection _collideNormalX, _collideNormalY;
	//Reset các biến lưu giữ trạng thái va chạm
	void ResetCollideVariable();
};

