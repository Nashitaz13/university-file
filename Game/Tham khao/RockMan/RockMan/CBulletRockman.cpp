#include "CBulletRockman.h"

CBulletRockman::CBulletRockman(Vector2 v, Vector2 beginPosition, int typeID, CSprite sprite, int dame) :CBullet(0, ID_BULLET_ROCKMAN_NORMAL, sprite, dame, v, beginPosition)
{
	_box._width = _sprite.GetWidth();
	_box._height = _sprite.GetHeight();
	_box._x = _position.x - _box._width / 2;
	_box._y = _position.y + _box._height / 2;
	_box._vx = _box._vy = 0.0f;

	_collidedObject = CollisionInfo(NULL, CDirection::ON_LEFT, 1000);
}

CBulletRockman::~CBulletRockman()
{

}

int CBulletRockman::Initlize()
{
	return 1;
}

void CBulletRockman::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::NONE);
	CGameObject::Render(gameTime, graphics);
}

void CBulletRockman::Update(CGameTime* gameTime)
{
	if (_collidedObject._object != NULL)
		Die();

	_position += _v*gameTime->GetDeltaTime();
	UpdateBox();

	_collidedObject = CollisionInfo(NULL, CDirection::ON_LEFT, 1000);
}

void CBulletRockman::OnCollideWith(CGameObject *obj, CDirection normalX, CDirection normalY, float collideTime)
{
	switch (obj->_typeID)
	{
	case  ID_ENEMY_BALL:
	case  ID_ENEMY_BOOM_BLUE:
	case  ID_ENEMY_EYE_RED_UP:
	case  ID_ENEMY_EYE_RED_RIGHT:
	case  ID_ENEMY_FISH_ORANGE:
	case  ID_ENEMY_INK_RED:
	case  ID_ENEMY_MACHINE_AUTO_BLUE_TOP:
	case  ID_ENEMY_MACHINE_ORANGE:
	case  ID_ENEMY_NINJA_GREEN:
	case  ID_ENEMY_BUBBLE_BLUE:
	case  ID_ENEMY_CUT:
	case  ID_ENEMY_INK_BLUE:
	case  ID_ENEMY_MACHINE_AUTO_ORGANGE_TOP:
	case  ID_ENEMY_ROBOT_RED:
	case  ID_ENEMY_EYE_RED:
	case  ID_ENEMY_WALL_SHOOTER_LEFT:
	case  ID_ENEMY_WALL_SHOOTER_RIGHT:
	case  ID_ENEMY_BUBBLE_GREEN:
	case  ID_ENEMY_HAT:
	case  ID_ENEMY_ROBOT_BLUE:
	case  ID_ENEMY_WORKER:
	case  ID_ENEMY_INK_SIT:
	case  ID_ENEMY_INK_STAND:
	case  ID_ENEMY_SNAPPER:
	case  ID_ENEMY_MACHINE_AUTO_BLUE_BOTTOM:
	case  ID_ENEMY_MACHINE_AUTO_ORGANGE_BOTTOM:
	case ID_CUTMAN:
	case ID_GUTSMAN:
	case ID_BOOMMAN:
		if (normalX == CDirection::INSIDE &&normalY == CDirection::INSIDE&& collideTime < _collidedObject._timeCollide)
		{
			_collidedObject._timeCollide = collideTime;
			_collidedObject._object = obj;
		}
		break;
	}
}