#include "CElevator.h"


CElevator::CElevator(int id, int typeID, CSprite sprite, float vX, Vector2 positionBegin) :CMoveableObject()
{
	_id = id;
	_typeID = typeID;
	_sprite = sprite;
	_v = Vector2(vX, 0);
	_blood = 100;//Gán đại 1 con số vì thực sự đối tượng Elevator này không cần có thuộc tính này _blood
	_position = positionBegin;
	_isRaisedTrouble = false;
}

CElevator::~CElevator()
{
}

int CElevator::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	_state = ELEVATOR_STATE::NORMAL;
	_sprite.SetIndex(0);
	UpdateBox();
	return 1;
}

void CElevator::Update(CGameTime* gameTime)
{
	_sprite.Update(gameTime);

	if ((_position.x - _sprite.GetFrameWidth() / 2) <= this->GetCollideRegion()._x
		|| (_position.x + _sprite.GetFrameWidth() / 2) >= this->GetCollideRegion()._x + this->GetCollideRegion()._width)
	{
		_v.x *= -1;
	}

	//Do anything for logic here
	if (_state == ELEVATOR_STATE::TROUBLE)
		this->RaiseATrouble();

	_position.x += gameTime->GetDeltaTime()*_v.x;
	this->UpdateBox();
}

void CElevator::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);

	CGameObject::Render(gameTime, graphics);
	CMoveableObject::Render(gameTime, graphics);
}

void CElevator::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}

void CElevator::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BLOCK_TROUBLE_OF_ELEVATOR:
		if (normalX == CDirection::INSIDE)
		{
			CBox boxObjs = gameObject->GetBox();
			int posXLeft = _position.x - _sprite.GetFrameWidth() / 2;//Vị trí X của lề trái cái đuôi
			int posXRight = posXLeft + 8;//Vị trí X của lề phải cái đuôi
			if ((posXLeft >= boxObjs._x && posXLeft <= (boxObjs._x + boxObjs._width))
				|| (posXRight >= boxObjs._x && posXRight <= (boxObjs._x + boxObjs._width)))
			{
				if (_state == ELEVATOR_STATE::NORMAL)
				{
					//Do anything for logic make a trouble
					_state = ELEVATOR_STATE::TROUBLE;
					_sprite.SetFrame(1, 2);
					_typeID = ID_ELEVATOR_TROUBLE;
				}
			}
			else
			{
				_typeID = ID_ELEVATOR;
				_sprite.SetIndex(0);
				_state = ELEVATOR_STATE::NORMAL;
				_isRaisedTrouble = false;
			}
		}
		else
		{
			_typeID = ID_ELEVATOR;
			_sprite.SetIndex(0);
			_state = ELEVATOR_STATE::NORMAL;
			_isRaisedTrouble = false;
		}
		break;
	case ID_ROCKMAN://Check va chạm Rockman chưa đúng hết. Còn 1 trường hợp nữa chưa xử lý đó là khi Rockman chưa đứng trên đó thì Box của Elevator chỉ gồm 1 khúc ở giữa
		if ((normalY == CDirection::ON_UP)
			&& _state == ELEVATOR_STATE::NORMAL)
		{
			gameObject->_position.x += deltaTime*_v.x;
		}
		break;
	}
}

void CElevator::RaiseATrouble()
{
	if (_sprite.GetIndex() == 2)
	{
		_isRaisedTrouble = true;
		_sprite.SetFrame(2, 0);
	}

	if (_isRaisedTrouble && _sprite.GetIndex() == 0)
	{
		_sprite.SetIndex(0);
		_state = ELEVATOR_STATE::NORMAL;
		_isRaisedTrouble = false;
	}

}
