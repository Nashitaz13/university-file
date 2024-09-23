#include "CBulletSnapper.h"


CBulletSnapper::CBulletSnapper(int id, int typeID, CSprite spriteBullet, int dame, float v0, Vector2 beginPosition, float angleFly, int x, int y,int xRockMan) :CBullet(id, typeID, spriteBullet, dame, Vector2(v0*cosf(angleFly), v0*sinf(angleFly)), beginPosition)
{
	_position.x = x;
	_position.y = y;
	_positionXRockMan = xRockMan;
	_state = BULLET_BASE_STATE::FLYING;
	Initlize();
	UpdateBox();
}
int CBulletSnapper::Initlize()
{
	_g = 0.4f / 1000.0f;
	_a = 0;
	_v0 = 0;
	_setValueCut = false;
	_hMax = 40;

	return 1;
}
void CBulletSnapper::SetValueCut()
{
	_lMax = abs(_positionXRockMan - _position.x);
	if (_lMax<1)
		_lMax = 1;
	_anpha = atan((4 * _hMax) / _lMax);
	_v0 = (float)sqrt((_lMax*abs(_g)) / sin(2 * _anpha));
	_v.x = _v0*cosf(_anpha);
	_v.y = _v0*sinf(_anpha);
	if (_positionXRockMan > _position.x)

		_v.x = abs(_v.x);
	else
		_v.x = abs(_v.x)*-1;

	_setValueCut = true;
}
void CBulletSnapper::Update(CGameTime* gameTime)
{
	if (!_setValueCut)
		SetValueCut();
	else
	{
		_position.x += _v.x*(gameTime->GetDeltaTime());
		_position.y += _v.y*(gameTime->GetDeltaTime());

		_v.y -= _g*(gameTime->GetDeltaTime());
	}
	_sprite.Update(gameTime);
	UpdateBox();
}
void CBulletSnapper::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_v.x<0)
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	else
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true,Vector2(1,1),SpriteEffects::FLIP_HORIZONTALLY);
}
void CBulletSnapper::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}
void CBulletSnapper::OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime)
{

}
CBulletSnapper::~CBulletSnapper()
{
}
