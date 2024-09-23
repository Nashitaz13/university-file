#include "CBoomRockManBullet.h"

CBoomRockManBullet::CBoomRockManBullet(CRockman* master) : CBullet(0, ID_BULLET_ROCKMAN_BOOM_NONE, ResourceManager::GetSprite(ID_SPRITE_BULLET_BOSS_BOOM), 10, Vector2(0,0), master->_position)
{
	_master = master;

	// Tính lại vị trí xuất hiện của đạn
	_position.y = _master->GetBox()._y;
	if (_master->_isRight)
	{
		_position.x += _master->GetBox()._width ;

		_v.x = ROCK_BOOM_BULLET_VERLOCITY_X;
		_a.x = -ROCKMAN_ACCELERATE_X;

		_velocityYDefault=_v.y = ROCK_BOOM_BULLET_VERLOCITY_Y;
		_a.y = -ROCK_BOOM_BULLET_ACCELERATE_Y;
	}
	else
	{
		_position.x -= _master->GetBox()._width;

		_v.x = -ROCK_BOOM_BULLET_VERLOCITY_X;
		_a.x = ROCKMAN_ACCELERATE_X;

		_velocityYDefault = _v.y = ROCK_BOOM_BULLET_VERLOCITY_Y;
		_a.y = -ROCK_BOOM_BULLET_ACCELERATE_Y;
	}
	UpdateBox();
	_isChangeSprite = false;
	_collideLeft = CollisionInfo(NULL, CDirection::ON_LEFT, 100);
	_collideRight = CollisionInfo(NULL, CDirection::ON_RIGHT, 100);
	_collideUp = CollisionInfo(NULL, CDirection::ON_UP, 100);
	_collideDown = CollisionInfo(NULL, CDirection::ON_DOWN, 100);
}

int CBoomRockManBullet::Initlize()
{
	
	return 0;
}

CBoomRockManBullet::~CBoomRockManBullet()
{

}

void CBoomRockManBullet::Update(CGameTime* gameTime)
{
	if (_deltaTimeExplode == 0)
	{
		bool hasCollideHorizontal = false;
		if (_collideLeft._object != NULL)
		{
			_position.x += _v.x*_collideLeft._timeCollide;
			_v.x = 0.0f;
			_a.x = 0.0f;
			hasCollideHorizontal = true;
		}
		if (_collideRight._object != NULL)
		{
			_position.x += _v.x*_collideRight._timeCollide;
			_v.x = 0.0f;
			_a.x = 0.0f;
			hasCollideHorizontal = true;
		}
		if (_collideUp._object != NULL)
		{
			_position.y += _v.y*_collideUp._timeCollide-1;
			_v.y = 0.0f;

		}if (_collideDown._object != NULL)
		{
			_position.y += _v.y*_collideDown._timeCollide;
			_velocityYDefault /= 2.0f;
			if (_velocityYDefault > ROCK_BOOM_BULLET_VERLOCITY_Y/100)
				_v.y = _velocityYDefault;
			else{
				_typeID = ID_BULLET_ROCKMAN_BOOM;
				_deltaTimeExplode = 1;		// Tăng lên một để đảm bảo là đếm thời gian bắt đầu phát nổ
				CExplodingEffectManager::Add(new  CExplodingEffectX(_position, ResourceManager::GetSprite(ID_SPRITE_BOOMMAN_BOOM_BURST),false));
				UpdateBox();
			}
		}

		_position += _v*gameTime->GetDeltaTime();
		_v += _a*gameTime->GetDeltaTime();

		UpdateBox();
		_collideLeft = CollisionInfo(NULL, CDirection::ON_LEFT, 100);
		_collideRight = CollisionInfo(NULL, CDirection::ON_RIGHT, 100);
		_collideUp = CollisionInfo(NULL, CDirection::ON_UP, 100);
		_collideDown = CollisionInfo(NULL, CDirection::ON_DOWN, 100);
	}
	else
	{
		_deltaTimeExplode += gameTime->GetDeltaTime();
		if (_deltaTimeExplode >= 1000)
			Destroy();
	}
	_sprite.Update(gameTime);
}

void CBoomRockManBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_deltaTimeExplode==0)
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::NONE);

	CGameObject::Render(gameTime, graphics);
}

void CBoomRockManBullet::Destroy()
{
	_master->_canFire = true;
	_state = BULLET_BASE_STATE::DIE;
}
void CBoomRockManBullet::UpdateBox()
{
	if (_deltaTimeExplode>0)
	{
		_box._width = _sprite.GetFrameWidth() * 4;
		_box._height = _sprite.GetFrameHeight() * 4;
		_box._x = _position.x - _box._width / 2;
		_box._y = _position.y + _box._height / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
	}
	else
	{
		_box._width = _sprite.GetFrameWidth()-4;
		_box._height = _sprite.GetFrameHeight()-4;
		_box._x = _position.x -_box._width/ 2;
		_box._y = _position.y + _box._height / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
	}
}

void CBoomRockManBullet::OnCollideWith(CGameObject *obj, CDirection normalX, CDirection normalY, float collideTime)
{
	switch (obj->_typeID)
	{
	case ID_ROCK_IN_GUT_STAGE:
	case ID_BLOCK:
	case ID_ROCK:
	case ID_DOOR1_BOOMMAN:
	case ID_DOOR2_BOOMMAN:
	case ID_DOOR1_CUTMAN:
	case ID_DOOR2_CUTMAN:
	case ID_DOOR1_GUTSMAN:
	case ID_DOOR2_GUTSMAN:
		if (normalX == CDirection::ON_LEFT&& collideTime < _collideLeft._timeCollide)
		{
			_collideLeft._timeCollide = collideTime;
			_collideLeft._object = obj;
		}
		else if (normalX == CDirection::ON_RIGHT&& collideTime < _collideRight._timeCollide)
		{
			_collideRight._timeCollide = collideTime;
			_collideRight._object = obj;
		}
		if (normalY == CDirection::ON_UP && collideTime < _collideUp._timeCollide)
		{
			_collideUp._timeCollide = collideTime;
			_collideUp._object = obj;
		}
		else if (normalY == CDirection::ON_DOWN &&  collideTime <= _collideDown._timeCollide)
		{
			_collideDown._timeCollide = collideTime;
			_collideDown._object = obj;
		}
		break;
	}
}