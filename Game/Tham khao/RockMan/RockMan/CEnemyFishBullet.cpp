#include "CEnemyFishBullet.h"


CEnemyFishBullet::CEnemyFishBullet(int id, int typeID, CSprite spriteBullet, int dame, float v0, Vector2 beginPosition, float angleFly,int x, int y)
:CBullet(id, typeID, spriteBullet, dame, Vector2(v0*cosf(angleFly), v0*sinf(angleFly)), beginPosition)
{
	_position.x = x;
	_position.y = y;
	_timeDelete =0;
	_timeDeleteDefault = 2000;
	_state = BULLET_BASE_STATE::FLYING;
}

int CEnemyFishBullet::Initlize()
{
	return 1;
}
void CEnemyFishBullet::Update(CGameTime* gameTime)
{
	_timeDelete += gameTime->GetDeltaTime();
	if (_timeDelete > _timeDeleteDefault)
		_state == BULLET_BASE_STATE::DIE;
	_sprite.Update(gameTime);
	UpdateBox();
}
void CEnemyFishBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_timeDelete<_timeDeleteDefault)
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
}
void CEnemyFishBullet::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}
void CEnemyFishBullet::OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime)
{

}
CEnemyFishBullet::~CEnemyFishBullet()
{
}
