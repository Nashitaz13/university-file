#include "CBullet.h"

CBullet::CBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition) : CMoveableObject()
{
	_sprite = sprite;
	_v = v;
	_dame = dame;
	_id = id;
	_typeID = typeID;
	_position = beginPosition;
	_state = BULLET_BASE_STATE::FLYING;
}

CBullet::~CBullet()
{
}
void CBullet::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{

}

BULLET_BASE_STATE CBullet::GetState()
{
	return _state;
}

void CBullet::UpdateBox()
{
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth() - 2;
	_box._height = _sprite.GetFrameHeight() - 2;
	_box._x = _position.x - _box._width / 2;
	_box._y = _position.y + _box._height / 2;
}
void CBullet::Die()
{
	_state = BULLET_BASE_STATE::DIE;
}

void CBullet::Destroy()
{

}