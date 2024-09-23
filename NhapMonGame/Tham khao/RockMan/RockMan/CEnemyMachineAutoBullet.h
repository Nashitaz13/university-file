
#ifndef _CENEMY_CENEMY_MACHINEAUTO_BULLET_H_
#define _CENEMY_CENEMY_MACHINEAUTO_BULLET_H_

#include "CBullet.h"
#include "ExplodingEffect.h"

class CEnemyMachineAutoBullet :	public CBullet
{
public:
	//Hàm khởi tạo đạn
	//	+ angleFly: Góc bay tạo bởi quỹ đạo của viên đạn với trục Ox dương (không vượt quá 2PI). Đơn vị Radian
	//	+ v0: vận tốc di chuyển tổng hợp của Vx và Vy của viên đạn
	CEnemyMachineAutoBullet(int id, int typeID, CSprite spriteBullet, int dame, float v0, Vector2 beginPosition, float angleFly);
	virtual ~CEnemyMachineAutoBullet();

	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;
private:
};

#endif // !_CENEMY_CENEMY_MACHINEAUTO_BULLET_H_