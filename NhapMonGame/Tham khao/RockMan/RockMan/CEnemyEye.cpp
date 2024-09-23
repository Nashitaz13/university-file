#include "CEnemyEye.h"

CEnemyEye::CEnemyEye(int kindEye) :CEnemy()
{
	_dame = DAME_ENEMY_EYE;
	_kindEye = kindEye;
	Initlize();
	_status = Status::Stand;
	_blood = 1;
	_score = SCORE_DEFAULT;
}
CEnemyEye::~CEnemyEye()
{
	
}
int CEnemyEye::Initlize()
{
	_timeStand = 30; // thời gian giản cách giữa các lần nhảy
	_timeStandSet = 2000;// đây là thời gian dừng cố định 
	_testminx = 100; 
	_testmaxx = 200; 
	_testminy = 900; 
	_testmaxy = 1050;
	_timeCollide = std::numeric_limits<float>::infinity();
	_normalHistory = CDirection::NONE_DIRECT;
	_vEyeDefault = 100.0f / 1000.0f;

	_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_EYE);
	_v = Vector2(100.0f / 1000.0f, 100.0f / 1000.0f);
	UpdateBox();
	return 1;
}
void CEnemyEye::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	CMoveableObject::Render(gameTime, graphics);
}
void CEnemyEye::Update(CGameTime* gameTime)
{
	// xử lý tiền va chạm trước đó, do eye chỉ có 1 chuyển động cơ bản là di chuyển qua lại nên dùng duy nhất 1 biến time không cần quan tâm va chạm trái phải 
	if (_status == Status::Run && _normalHistory != CDirection::NONE_DIRECT)
	{
		_status = Status::Stand;
		_timeStand = _timeStandSet;
		_sprite.SetIndex(2);
		if (_kindEye == 0)
		{
			_position.x += _timeCollide*_v.x;
		}
		else
		{
			_position.y += _timeCollide*_v.y;
		}
	}
	// xử lý khi hoàn thành hoàn thành xử lý tiền va chạm tức xử lý trạng tjai1 tiếp theo
	if (_status == Status::Stand)
	{
		_timeStand -= gameTime->GetDeltaTime();
		if (_timeStand <= 200)// 200 là thời gian mắt mở bậc 1 
		{
			_sprite.SetIndex(1);
		}
		if (_timeStand <= 0)
			Slide();
	}
	if (_status == Status::Run)
	{
		if (_kindEye == 0)
		{
			_position.x += gameTime->GetDeltaTime()*_v.x;
		}
		else
		{
			_position.y += gameTime->GetDeltaTime()*_v.y;
		}
	}
	_timeCollide = std::numeric_limits<float>::infinity();
	_normalHistory = CDirection::NONE_DIRECT;

	_sprite.Update(gameTime);
	UpdateBox();
	CGameObject::Update(gameTime);
}

void CEnemyEye::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}


void CEnemyEye::Update(CGameTime* gameTime, CRockman* rockman)
{
	
}
void CEnemyEye::Slide()
{
	_sprite.SetIndex(0);
	if (_kindEye == 0)
		_v.x *= -1;
	else
		_v.y *= -1;
	_status = Status::Run;
}
void CEnemyEye::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BLOCK:
	case ID_ROCK:		
		if (_kindEye == 0)
		{
			if (normalX == CDirection::ON_LEFT || normalX == CDirection::ON_RIGHT)
			{
				if (deltaTime < _timeCollide)
				{
					_normalHistory = normalX;
					_timeCollide = deltaTime;
				}
			}
		}
		else
		{			
			if (normalY == CDirection::ON_DOWN || normalY == CDirection::ON_UP)
			{
				if (deltaTime < _timeCollide)
				{
					_normalHistory = normalY;
					_timeCollide = deltaTime;
				}
			}

		}
		break;
	case ID_BULLET_ROCKMAN_NORMAL: case ID_BULLET_ROCKMAN_BOOM: case ID_BULLET_ROCKMAN_CUT: case ID_BULLET_ROCKMAN_GUTS:
		if (_status==Status::Run)
			_blood = 0;
		else
			ResourceManager::PlayASound(ID_EFFECT_BULLET_HIT_ENEMY_WITH_SHIELD);
		break;
	}
}
CEnemyEye::Status CEnemyEye::GetStatus()
{
	return _status;
}
CEnemyEye* CEnemyEye::ToValue()
{
	return new CEnemyEye(*this);
}