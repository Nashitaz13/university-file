#include "CBulletNinja.h"


CBulletNinja::CBulletNinja(int id, int typeID, CSprite spriteBullet, int dame, float v0, Vector2 beginPosition, float angleFly, int x, int y) :CBullet(id, typeID, spriteBullet, dame, Vector2(v0*cosf(angleFly), v0*sinf(angleFly)), beginPosition)
{
	_position.x = x;
	_position.y = y;
	_state = BULLET_BASE_STATE::FLYING;
	Initlize();
	UpdateBox();
}
int CBulletNinja::Initlize()
{
	_v.x = 100.0f / 1000.0f;
	return 1;
}
void CBulletNinja::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
}
void CBulletNinja::Update(CGameTime* gameTime)
{
	_position.x -= gameTime->GetDeltaTime()*_v.x;
}
void CBulletNinja::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}
void CBulletNinja::OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime)
{

}
CBulletNinja::~CBulletNinja()
{
}
