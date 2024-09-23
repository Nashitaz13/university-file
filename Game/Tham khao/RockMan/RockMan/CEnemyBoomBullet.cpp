#include "CEnemyBoomBullet.h"

CEnemyBoomBullet::CEnemyBoomBullet(int id, int typeID, CSprite spriteBullet, CSprite spriteExplodingEffect, int dame, Vector2 beginPosition, float lMaxJump, float angleJump)
	: CBullet(id, typeID, spriteBullet, dame, 
	Vector2((sqrt(lMaxJump * GRAVITY / abs(sinf(2 * angleJump)))*cosf(angleJump)), sqrt(lMaxJump * GRAVITY / abs(sinf(2 * angleJump)))*abs(sinf(angleJump)) * 2), //Nhân _v.y cho 2 là để phía dưới trừ _v.y thật nhiều để tạo cảm giác di chuyển nhanh
			beginPosition)
{
	_state = BULLET_BASE_STATE::FLYING;
	_explodingEffect = new CExplodingEffect(_position, spriteExplodingEffect);
	_explodingEffect->Initlize();
}

CEnemyBoomBullet::~CEnemyBoomBullet()
{
	SAFE_DELETE(_explodingEffect);
}

int CEnemyBoomBullet::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	this->UpdateBox();
	this->ResetCollideVariable();
	return 1;
}

void CEnemyBoomBullet::Update(CGameTime* gameTime)
{
#pragma region Vùng xử lý va chạm với BLOCK, ROCK objects (các đối tượng mà khi va chạm Bullet phải dừng lại và nổ)
	if (_collideNormalX != CDirection::NONE_DIRECT
		|| _collideNormalY != CDirection::NONE_DIRECT)
	{
		//Di chuyển đến vị trí va chạm
		_position.x += _minCollideDeltaTime*_v.x;
		_position.y += _minCollideDeltaTime*_v.y;
		//Thay đổi trạng thái của đạn từ trạng thái FLY(bay) thành trạng thái EXPLODING(nổ)
		_state = BULLET_BASE_STATE::EXPLODING;
		//Set vị trí hiệu ứng nổ tại vị trí xảy ra va chạm
		_explodingEffect->_position = _position;
		_explodingEffect->SetSoundEffect(ID_EFFECT_BULLET_BOOM_EXPLODING);
		_v = Vector2(0, 0);
	}
	this->ResetCollideVariable();
#pragma endregion


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

		_v.y -= GRAVITY * gameTime->GetDeltaTime() * 20;
	}

	if (_state == BULLET_BASE_STATE::EXPLODING)// Nếu đang ở trạng thái nổ thì vẽ sprite nổ
	{
		_explodingEffect->Update(gameTime);
		if (_explodingEffect->IsDone() == true)
			_state = BULLET_BASE_STATE::DIE;
	}
	this->UpdateBox();
}

void CEnemyBoomBullet::UpdateBox()
{
	if (_state == BULLET_BASE_STATE::FLYING)
	{
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight();
	}
	else
		if (_state == BULLET_BASE_STATE::EXPLODING)
		{
			_box = _explodingEffect->GetBox();
		}
		else
		{
			_box._vx = 0;
			_box._vy = 0;
			_box._width = 0;
			_box._height = 0;
		}
}

void CEnemyBoomBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_state == BULLET_BASE_STATE::FLYING)
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	else
		if (_state == BULLET_BASE_STATE::EXPLODING)
			_explodingEffect->Render(gameTime, graphics);

	CGameObject::Render(gameTime, graphics);
}

void CEnemyBoomBullet::OnCollideWith(CGameObject* gameObj, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObj->_typeID)
	{
	case ID_BLOCK:
	case ID_ROCK:
		if (_minCollideDeltaTime > deltaTime)
		{
			_minCollideDeltaTime = deltaTime;
			_collideNormalX = normalX;
			_collideNormalY = normalY;
		}
		break;
	}
}

void CEnemyBoomBullet::ResetCollideVariable()
{
	_minCollideDeltaTime = std::numeric_limits<float>::infinity();;
	_collideNormalX = CDirection::NONE_DIRECT;
	_collideNormalY = CDirection::NONE_DIRECT;
}
