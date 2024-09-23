#include "CEnemyInk.h"
CEnemyInk::CEnemyInk(int kindInk) :CEnemy()
{
	_dame = DAME_ENEMY_INK;
	_PositionRockMan = Vector2(100, 100);
	if (kindInk == 0)
	{
		_kindInk = ID_SPRITE_ENEMY_INK_RED;
	}
	else
	{
		_kindInk = ID_SPRITE_ENEMY_INK_BLUE;
	}
	Initlize();
	_blood = 1;
	_score = SCORE_DEFAULT;
}
CEnemyInk::~CEnemyInk()
{

}
int CEnemyInk::Initlize()
{

	_heightInk = 100;
	_timeStand = 30;
	_timeStandDefault = 1000;

	_anpha = 0.7f;
	_timeaddspeed = 2.0f;
	_vFall = 0.0f;
	_testpositiony = 1000;
	_testbug = 0;
	_timeHistoryCollide = std::numeric_limits<float>::infinity();

	_timeJump = 1500;
	_sprite = ResourceManager::GetSprite(_kindInk);
	_v = Vector2(50.0f / 1000.0f, 50.0f / 1000.0f);
	_g = 0.2f / 1000.0f;//0.098f / 1000.0f;
	_V0 = 172.0f / 1000.0f;
	_static = StaticEnemyInk::STAND;
	_spriteStatus = ID_ENEMY_INK_STAND;
	UpdateBox();
	return 1;
}
void CEnemyInk::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	//CMoveableObject::Render(gameTime, graphics);
}
void CEnemyInk::Update(CGameTime* gameTime)
{

}

void CEnemyInk::UpdateBox()
{

	switch (_spriteStatus)
	{
	case ID_ENEMY_INK_SIT:
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y+2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = 10;
		break;
	case ID_ENEMY_INK_STAND:
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2+2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight();
		break;
	}
}


void CEnemyInk::Jump(Vector2 positionRockman)
{
	_PositionRockMan.x = positionRockman.x;
	_PositionRockMan.y = positionRockman.y;

	_lenghtMax = abs(_PositionRockMan.x - _position.x);
	// test lenght de va cham dung
	if (_lenghtMax<1)
		_lenghtMax = 1;

	if (abs(_PositionRockMan.y - _position.y) > 20)
	{
		_heightInk = abs(_PositionRockMan.y - _position.y) + 20;
		_anpha = atan((4 * _heightInk) / _lenghtMax);
	}
	else
	{
		_heightInk = abs(_PositionRockMan.y - _position.y) + 20;
		//_anpha = 0.7f;
		_anpha = atan((4 * _heightInk) / _lenghtMax);
	}


	_V0 = (float)sqrt((_lenghtMax*abs(_g)) / sin(2 * _anpha));

	OutputDebugStringW((L"V0: " + wstring(::to_wstring(_V0) + L"\n")).c_str());

	OutputDebugStringW((L"a: " + wstring(::to_wstring(_anpha) + L"\n")).c_str());

	OutputDebugStringW((L"leght: " + wstring(::to_wstring(_lenghtMax) + L"\n")).c_str());

	OutputDebugStringW((L"height: " + wstring(::to_wstring(_heightInk) + L"\n")).c_str());


	_v.x = _V0*cosf(_anpha);
	_v.y = _V0*sinf(_anpha);

	if (_PositionRockMan.x > _position.x)

		_v.x = abs(_v.x);
	else
		_v.x = abs(_v.x)*-1;

	_static = StaticEnemyInk::JUMP;

	_spriteStatus = ID_ENEMY_INK_STAND;
	_sprite.SetIndex(1);
}
void CEnemyInk::TestJump()
{

}
void CEnemyInk::Update(CGameTime* gameTime, CRockman* rockman)
{

	if (_historyCollide != CDirection::NONE_DIRECT)
	{
		switch (_historyCollide)
		{
		case CDirection::ON_UP:
			_position.y += _timeHistoryCollide*_v.y-2;
			_v.y = _vFall;
			_v.x = 0;
			_static = StaticEnemyInk::FALL;
			break;
		case CDirection::ON_RIGHT:
			_position.x += _timeHistoryCollide*_v.x-2;
			_v.y = _vFall;
			_v.x = 0;
			_static = StaticEnemyInk::FALL;
			break;
		case CDirection::ON_LEFT:
			_position.x += _timeHistoryCollide*_v.x+2;
			_v.x = 0;
			_v.y = _vFall;
			_static = StaticEnemyInk::FALL;
			break;
		case CDirection::ON_DOWN:
			_spriteStatus = ID_ENEMY_INK_SIT;
			_sprite.SetIndex(0);
			_timeStand = _timeStandDefault;//1000
			_position.y += _timeHistoryCollide*_v.y+1;
			_v.y = 0.0f;
			_v.x = 0.0f;
			_anpha = 0;
			_static = StaticEnemyInk::STAND;
			break;
		default:
			break;
		}
	}


	// xử lý cho va chạm trước đó 

	switch (_static)
	{
	case CEnemyInk::JUMP:
		_position.x += _v.x*(gameTime->GetDeltaTime());
		_position.y += _v.y*(gameTime->GetDeltaTime());// -0.5f*_g*pow((gameTime->GetDeltaTime()*_timeaddspeed), 2);

		_v.y -= _g*(gameTime->GetDeltaTime());// 1000/ 33 + 90 

		break;
	case CEnemyInk::STAND:
		_timeStand -= gameTime->GetDeltaTime();
		if (_timeStand <= 0)
			Jump(rockman->_position);
		break;
	case CEnemyInk::FALL:
		_position.y += _v.y*(gameTime->GetDeltaTime());
		_v.y -= _g*(gameTime->GetDeltaTime());
		break;
	default:
		break;
	}

	_historyCollide = CDirection::NONE_DIRECT;
	_timeHistoryCollide = std::numeric_limits<float>::infinity();
	_sprite.Update(gameTime);
	UpdateBox();
	CGameObject::Update(gameTime);
}
void CEnemyInk::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BLOCK:
	case ID_ROCK:
		if (normalX == CDirection::ON_LEFT)
		{
			if (_timeHistoryCollide > deltaTime)
			{
				_timeHistoryCollide = deltaTime;
				_historyCollide = CDirection::ON_LEFT;
			}
		}

		if (normalX == CDirection::ON_RIGHT)
		{
			if (_timeHistoryCollide > deltaTime)
			{
				_timeHistoryCollide = deltaTime;
				_historyCollide = CDirection::ON_RIGHT;
			}
		}

		if (normalY == CDirection::ON_UP)
		{

			if (_timeHistoryCollide > deltaTime)
			{
				_timeHistoryCollide = deltaTime;
				_historyCollide = CDirection::ON_UP;
			}
		}

		if (normalY == CDirection::ON_DOWN)
		{
			if (_timeHistoryCollide > deltaTime)
			{
				_timeHistoryCollide = deltaTime;
				_historyCollide = CDirection::ON_DOWN;
			}
		}
		OutputDebugStringW((L"va cham y: " + wstring(::to_wstring(normalY) + L"\n")).c_str());
		OutputDebugStringW((L"va cham x: " + wstring(::to_wstring(normalX) + L"\n")).c_str());

		break;
	case ID_BULLET_ROCKMAN_NORMAL: case ID_BULLET_ROCKMAN_BOOM : case ID_BULLET_ROCKMAN_CUT : case ID_BULLET_ROCKMAN_GUTS:
		_blood = 0;
		break;
	default:
		break;
	}
	
}
CEnemyInk* CEnemyInk::ToValue()
{
	return new CEnemyInk(*this);
}
