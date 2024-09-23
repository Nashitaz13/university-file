#include "CEnemyWorkerBullet.h"

CEnemyWorkerBullet::CEnemyWorkerBullet(int id, int typeID, CSprite sprite, int dame, Vector2 beginPosition, float lMaxJump, float angleJump)
	: CBullet(id, typeID, sprite, dame, 
	Vector2((sqrt(lMaxJump * GRAVITY / abs(sinf(2 * angleJump)))*cosf(angleJump)), sqrt(lMaxJump * GRAVITY / abs(sinf(2 * angleJump)))*abs(sinf(angleJump)) * 2), //Nhân _v.y cho 2 là để phía dưới trừ _v.y thật nhiều để tạo cảm giác di chuyển nhanh
			beginPosition)
{
	_state = BULLET_BASE_STATE::FLYING;
}

CEnemyWorkerBullet::~CEnemyWorkerBullet()
{
}

int CEnemyWorkerBullet::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	this->UpdateBox();
	return 1;
}

void CEnemyWorkerBullet::Update(CGameTime* gameTime)
{
	_sprite.Update(gameTime);
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

		_v.y -= GRAVITY * gameTime->GetDeltaTime() * 10;
	}
	this->UpdateBox();
}

void CEnemyWorkerBullet::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}

void CEnemyWorkerBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_state == BULLET_BASE_STATE::FLYING)
		if (_v.x<=0)
			graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
		else
			graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::FLIP_HORIZONTALLY);

	CGameObject::Render(gameTime, graphics);
}

void CEnemyWorkerBullet::OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime)
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
