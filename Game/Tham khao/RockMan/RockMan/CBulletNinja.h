#pragma once
#include "CBullet.h"
class CBulletNinja : public CBullet
{
public:
	CBulletNinja(int id, int typeID, CSprite spriteBullet, int dame, float v0, Vector2 beginPosition, float angleFly, int x, int y);
	~CBulletNinja();
	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;
private:
	
	

};

