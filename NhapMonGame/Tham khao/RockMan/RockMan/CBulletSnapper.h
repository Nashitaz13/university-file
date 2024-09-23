#pragma once
#include "CBullet.h"
class CBulletSnapper : public CBullet
{
public:
	CBulletSnapper(int id, int typeID, CSprite spriteBullet, int dame, float v0, Vector2 beginPosition, float angleFly, int x, int y,int xRockMan);
	~CBulletSnapper();
	int Initlize() override;

	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	void Update(CGameTime* gameTime) override;

	void UpdateBox() override;

	void OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime) override;
private:
	void SetValueCut();
	int _hMax;
	int _lMax;
	int _positionXRockMan;//_positionX, _positionY,
	boolean _setValueCut;
	float _v0, _a, _g,_anpha;
	
};

