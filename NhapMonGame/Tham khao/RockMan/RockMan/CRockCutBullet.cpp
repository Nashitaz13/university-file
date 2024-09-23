#include "CRockCutBullet.h"

CRockCutBullet::CRockCutBullet(CRockman* master) : CBullet(0, ID_BULLET_ROCKMAN_CUT, ResourceManager::GetSprite(ID_SPRITE_BULLET_CUT), 10, Vector2(0, 0), master->_position)
{
	_master = master;

	// Tính lại vị trí xuất hiện của đạn
	_position.y = _master->GetBox()._y;
	_oldPosition = _master->_position;
	_isChangedState = false;
	_timeReturn = 0;
	_timeDelay = 0;
	_defaultVelocity = Vector2(130.0f / 1000.0f, 65.0f / 1000.0f);
	_defaultAccelerate = Vector2(0.075f / 1000.0f, 0.15f / 1000.0f);

	if (_master->_isRight)
	{
		_position.x += _master->GetBox()._width;

		_v.x = _defaultVelocity.x;
		_a.x = -_defaultAccelerate.x;

		_v.y = _defaultVelocity.y;
		_a.y = -_defaultAccelerate.y;
	}
	else
	{
		_position.x -= _master->GetBox()._width;

		_v.x = -_defaultVelocity.x;
		_a.x = _defaultAccelerate.y;

		_v.y = _defaultVelocity.y;
		_a.y = -_defaultAccelerate.y;
	}
	UpdateBox();
}

int CRockCutBullet::Initlize()
{

	return 0;
}

CRockCutBullet::~CRockCutBullet()
{

}

void CRockCutBullet::Update(CGameTime* gameTime)
{
	float collideTime;
	CDirection normalX, normalY;
	collideTime = CheckCollision(this, _master->GetBox(), normalX, normalY, gameTime->GetDeltaTime());
	if (collideTime<gameTime->GetDeltaTime())
	{
		Die();
		_master->_canFire = true;
	}
	else
	{
		// Bắt đầu tìm rockman
		_timeReturn = 1;

		collideTime = CheckCollision(this, CBox(_oldPosition.x - 10.0f, _oldPosition.y + 10.0f, 20.0f, 20.0f, 0.0f, 0.0f), normalX, normalY, gameTime->GetDeltaTime());
		if (collideTime<gameTime->GetDeltaTime())
		{
			_timeReturn = 0;
			Find();
		}
	}

	_position += _v*gameTime->GetDeltaTime();
	_v += _a*gameTime->GetDeltaTime();

	_timeDelay += gameTime->GetDeltaTime();

	if (_timeDelay > 1000 && !_isChangedState)
	{
		_isChangedState = true;
		_v.x *= -1.0f;
		_a.y *= -1.0f;
	}
	if (_timeReturn > 2000)
	{
		_timeReturn = 0;
		Find();
	}
	UpdateBox();

	_sprite.Update(gameTime);
}

void CRockCutBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::NONE);

	CGameObject::Render(gameTime, graphics);
}

void CRockCutBullet::Destroy()
{
	_master->_canFire = true;
	_state = BULLET_BASE_STATE::DIE;
}
void CRockCutBullet::UpdateBox()
{
	_box._width = _sprite.GetFrameWidth() - 4;
	_box._height = _sprite.GetFrameHeight() - 4;
	_box._x = _position.x - _box._width / 2;
	_box._y = _position.y + _box._height / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
}
float CRockCutBullet::CheckCollision(CGameObject* obj1, CBox staticBox, CDirection &normalX, CDirection &normalY, float frameTime)
{
	float timeCollision = frameTime;
	CBox moveBox = obj1->GetBox();

	// Cố định lại box của object và tính lại vận tốc của box nội tại
	moveBox._vx -= staticBox._vx;
	moveBox._vy -= staticBox._vy;
	staticBox._vx = 0;
	staticBox._vy = 0;


	// tạo broad phase box để kiểm tra tổng quát với đối tượng đứng yên obj
	// Nếu có xảy ra va chạm, thì tiến hành kiểm tra bằng AABBSweep và đưa ra thời gian va chạm
	CBox broadBox = CCollision::GetSweptBox(moveBox, frameTime);
	if (CCollision::AABBCheck(staticBox, broadBox))
		timeCollision = CCollision::SweepAABB(moveBox, staticBox, normalX, normalY, frameTime);

	return timeCollision;
}

void CRockCutBullet::Find()
{
	float deltaX, deltaY;
	deltaX = _master->GetBox()._x - _position.x;
	deltaY = _master->GetBox()._y - _position.y;

	_oldPosition = _master->_position;

	_v.x = 3.0f*deltaX / 1000.0f;
	_v.y = 3.0f* deltaY / 1000.0f;

	if (_v.x > 0)
		_a.x = 3.0f*_defaultAccelerate.y;
	else if (_v.x<0)
		_a.x = 3.0f* -_defaultAccelerate.y;
	else
		_a.x = 0;

	if (_v.y > 0)
		_a.y = 3.0f* _defaultAccelerate.y;
	else if (_v.y<0)
		_a.y = 3.0f* -_defaultAccelerate.y;
	else
		_a.y = 0;
}