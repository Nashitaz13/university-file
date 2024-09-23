#include "CItem.h"
CItem::CItem(int typeID, Vector2 position, bool itemOfBoss, bool isDefault) :CMoveableObject()
{
	_typeID = typeID;
	_itemOfBoss = itemOfBoss;
	_isDefault = isDefault;
	_position = position;
}

CItem::~CItem()
{

}

int CItem::Initlize()
{
	_isGot = false;
	_timeAppear = 5000;
	_collisionUp = CollisionInfo(NULL, CDirection::ON_UP, std::numeric_limits<float>::infinity());
	_collisionDown = CollisionInfo(NULL, CDirection::ON_DOWN, std::numeric_limits<float>::infinity());

	switch (_typeID)
	{
	case ID_ITEM_BOSS_CUT:
		_spriteStatus = ID_SPRITE_ITEM_BOSS_CUT;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_BOSS_GUTS:
		_spriteStatus = ID_SPRITE_ITEM_BOSS_GUTS;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_BOSS_BOOM:
		_spriteStatus = ID_SPRITE_ITEM_BOSS_BOOM;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_LIFE:
		_spriteStatus = ID_SPRITE_ITEM_LIFE;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_BLOOD_BIG:
		_spriteStatus = ID_SPRITE_ITEM_BLOOD_BIG;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_BLOOD_SMALL:
		_spriteStatus = ID_SPRITE_ITEM_BLOOD_SMALL;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_MANA_BIG:
		_spriteStatus = ID_SPRITE_ITEM_MANA_BIG;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_MANA_SMALL:
		_spriteStatus = ID_SPRITE_ITEM_MANA_SMALL;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	case ID_ITEM_BONUS:
		std::srand(time(NULL));
		int rand = std::rand() % 3 + 1;
		if (rand == 1)
			_spriteStatus = ID_SPRITE_ITEM_BONUS_BLUE;
		else if (rand == 2)
			_spriteStatus = ID_SPRITE_ITEM_BONUS_RED;
		else if (rand == 3)
			_spriteStatus = ID_SPRITE_ITEM_BONUS_ORANGE;
		_sprite = ResourceManager::GetSprite(_spriteStatus);
		break;
	}
	if (!_itemOfBoss)
	{
		_v.y = 205.0f / 1000.0f;
		_a.y = -1.09f / 1000.0f;
	}
	else
	{
		_v.y = -205.0f / 1000.0f;
		_a.y = 0.0f;
	}
	UpdateBox();
	SetCollideRegion(_box._x, _box._y, _box._width, _box._height);

	return 1;
}

void CItem::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (!_isGot)
	{
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
		CGameObject::Render(gameTime, graphics);
	}
}

void CItem::Update(CGameTime* gameTime)
{
	if (!_isDefault)
	{
		if (_collisionUp._object != NULL)
		{
			switch (_collisionUp._object->_typeID)
			{
			case ID_BLOCK:
			case ID_ROCK:
				if (_v.y > 0)
				{
					_position.y += _v.y*_collisionUp._timeCollide;
					_v.y = 0.0f;
				}
				break;
			}
		}
		if (_collisionDown._object != NULL)
		{
			switch (_collisionDown._object->_typeID)
			{
			case ID_BLOCK:
			case ID_ROCK:
				if (_v.y < 0)
				{
					_position.y += _v.y*_collisionDown._timeCollide;
					_v.y = _a.y = 0.0f;
					_timeAppear -= 1;		// Bắt đầu đếm thời gian xuất hiện của item
				}
				break;
			}
		}
		_position += _v*gameTime->GetDeltaTime();
		_v += _a*gameTime->GetDeltaTime();

		if (!_itemOfBoss&& _timeAppear != 5000)
		{
			_timeAppear -= gameTime->GetDeltaTime();
			if (_timeAppear <= 0)
				GotIt();
		}

		UpdateBox();

		_collisionUp = CollisionInfo(NULL, CDirection::ON_UP, std::numeric_limits<float>::infinity());
		_collisionDown = CollisionInfo(NULL, CDirection::ON_DOWN, std::numeric_limits<float>::infinity());
	}
}

void CItem::UpdateCollision(CGameObject* obj, CDirection normalX, CDirection normalY, float collideTime, float remainCollideTime)
{
	if (normalY == CDirection::ON_UP&&_collisionUp._timeCollide > collideTime)
	{
		_collisionUp._direction = normalY;
		_collisionUp._object = obj;
		_collisionUp._timeCollide = collideTime;
	}
	if (normalY == CDirection::ON_DOWN &&_collisionDown._timeCollide > collideTime)
	{
		_collisionDown._direction = normalY;
		_collisionDown._object = obj;
		_collisionDown._timeCollide = collideTime;
	}
}

void CItem::UpdateBox()
{
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
	_box._x = _position.x - _box._width / 2;
	_box._y = _position.y + _box._height / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
}

void CItem::GotIt()
{
	_isGot = true;
}

bool CItem::IsGot()
{
	return _isGot;
}

CItem* CItem::ToValue()
{
	return new CItem(*this);
}