#include "CEnemyMachineAutoBullet.h"


CEnemyMachineAutoBullet::CEnemyMachineAutoBullet(int id, int typeID, CSprite spriteBullet, int dame, float v0, Vector2 beginPosition, float angleFly)
	: CBullet(id, typeID, spriteBullet, dame, Vector2(v0*cosf(angleFly), v0*sinf(angleFly)), beginPosition)
{
	_state = BULLET_BASE_STATE::FLYING;
}

CEnemyMachineAutoBullet::~CEnemyMachineAutoBullet()
{
}

int CEnemyMachineAutoBullet::Initlize()
{	
	_origin = Vector2(_size.x / 2, _size.y / 2);
	this->UpdateBox();
	return 1;
}

void CEnemyMachineAutoBullet::Update(CGameTime* gameTime)
{
	if (_state == BULLET_BASE_STATE::FLYING)
	{
		//Do anything để tính toán vị trí tiếp theo của viên đạn
		//Phần code hướng dẫn của Tuấn
		//////////////////////////////////////////
		//	v0+=a*t;							//
		//	s+=v0*t;							//
		//	vX=v0*cos(@);						//
		//	vY=v0*sin(@);						//
		//	Sx=s*cos(@)=v0*t*cos(@)=vX*t;		//
		//	Sy=s*sin(@)=v0*t*sin(@)=vY*t;		//
		//////////////////////////////////////////
		_position.x += gameTime->GetDeltaTime()*_v.x;
		_position.y += gameTime->GetDeltaTime()*_v.y;
	}

	this->UpdateBox();
}

void CEnemyMachineAutoBullet::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}

void CEnemyMachineAutoBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_state == BULLET_BASE_STATE::FLYING)
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);

	CGameObject::Render(gameTime, graphics);
}

void CEnemyMachineAutoBullet::OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime)
{
	//switch (gameObj->_typeID)
	//{
	//case ID_ROCKMAN://Nếu đối tượng va chạm là ROCKMAN. 
	//	//Di chuyển đến vị trí va chạm
	//	_position.x += deltaTime*_v.x;
	//	_position.y += deltaTime*_v.y;
	//	//Thay đổi trạng thái của đạn từ trạng thái FLY(bay) thành trạng thái DIE(chết)
	//	_state = BULLET_BASE_STATE::DIE;
	//	_v = Vector2(0, 0);
	//	break;
	//}
}