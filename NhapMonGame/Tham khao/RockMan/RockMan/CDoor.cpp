#include "CDoor.h"

CDoor::CDoor(CSprite doorSprite) :CMoveableObject()
{
	_sprite = doorSprite;
	_state = DoorState::WAITING;
}

CDoor::~CDoor()
{

}

int CDoor::Initlize()
{
	UpdateBox();
	_sprite.SetAllowAnimate(0.0f);
	return 0;
}

void CDoor::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::NONE);
	CGameObject::Render(gameTime, graphics);
}

void CDoor::Update(CGameTime* gameTime)
{
	switch (_state)
	{
	case OPENING:
		_tick += gameTime->GetDeltaTime();
		if (_tick >= 200.0f)
		{
			_sprite.SetIndex((_sprite.GetIndex() + 1) % _sprite.GetCountFrame());
			_tick = 0.0f;
			if (_sprite.GetIndex() == 0)
			{
				_state = DoorState::WAITING_FOR_THROUGH;
				_sprite.SetIndex(_sprite.GetCountFrame() - 1);
			}
		}
		break;
	case CLOSING:
		_tick += gameTime->GetDeltaTime();
		if (_tick >= 200.0f)
		{
			_sprite.SetIndex((_sprite.GetIndex() - 1) % _sprite.GetCountFrame());
			_tick = 0.0f;
			if (_sprite.GetIndex() == 0)
			{
				_state = DoorState::WAITING;
			}
		}
		break;
	}
	UpdateBox();
}

void CDoor::UpdateBox()
{
	if (_typeID != ID_DOOR2_BOOMMAN)
	{
		switch (_sprite.GetIndex())
		{
		case 0:
			_box._width = _size.x;
			_box._height = 64;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 1:
			_box._width = _size.x;
			_box._height = 48;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 2:
			_box._width = _size.x;
			_box._height = 32;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 3:
			_box._width = _size.x;
			_box._height = 16;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 4:
			_box._width = _size.x;
			_box._height = 0;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		}
	}
	else
	{
		switch (_sprite.GetIndex())
		{
		case 0:
			_box._width = 64;
			_box._height = _size.y;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 1:
			_box._width = 48;
			_box._height = _size.y;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 2:
			_box._width = 32;
			_box._height = _size.y;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 3:
			_box._width = 16;
			_box._height = _size.y;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		case 4:
			_box._width = 0;
			_box._height = _size.y;
			_box._x = _position.x - _box._width / 2;
			_box._y = _position.y + _box._height / 2;
			_box._vx = 0;
			_box._vy = 0;
			break;
		}
	}

}

bool CDoor::CanGoUp()
{
	switch (_typeID)
	{
	default:
		return false;
	}
}

bool CDoor::CanGoDown()
{
	switch (_typeID)
	{
	case ID_DOOR2_BOOMMAN:
		return true;
	default:
		return false;
	}
}

bool CDoor::CanGoLeft()
{
	return false;
}
bool CDoor::CanGoRight()
{
	switch (_typeID)
	{
	case ID_DOOR1_GUTSMAN:
	case ID_DOOR1_CUTMAN:
	case ID_DOOR2_GUTSMAN:
	case ID_DOOR2_CUTMAN:
	case ID_DOOR1_BOOMMAN:
		return true;
	default:
		return false;
	}
}

DoorState CDoor::GetState()
{
	return _state;
}

void CDoor::OpenDoor()
{
	_state = DoorState::OPENING;
}

void CDoor::CloseDoor()
{
	_state = DoorState::CLOSING;
}