#include "CEnemyMachine.h"


CEnemyMachine::CEnemyMachine() :CEnemy()
{

}

int CEnemyMachine::Initlize()
{
	_dame = DAME_ENEMY_MACHINE;
	_v = Vector2(50.0f / 1000.0f, 0.0f / 1000.0f);
	_static = STATICMACHINE::RunSlowMachine;
	_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_MACHINE);
	_timeFrame = 200;
	_timeStand = 0;
	_timeStandDefault = 2000;
	_timeFrame = TIMEFRAME::TimeSlow;
	_sprite.SetAllowAnimate(_timeFrame);
	UpdateBox();
	_blood = 1;
	return 1;
}

void CEnemyMachine::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
}
void CEnemyMachine::Update(CGameTime* gameTime, CRockman* rockman)
{

	switch (_static)
	{
	case STATICMACHINE::StandMachine:
		_timeStand += gameTime->GetDeltaTime();
		OutputDebugStringW((L"time Stand " + wstring(::to_wstring(_timeStand) + L"\n")).c_str());
		if (_timeStand > _timeStandDefault)
		{
			_timeStand = 0;
			_static = STATICMACHINE::RunSlowMachine;
			_timeFrame = TIMEFRAME::TimeSlow;
			_v.x = 50.0f / 1000.0f;
			_sprite.SetAllowAnimate(_timeFrame);
		}
		break;
	case STATICMACHINE::RunSlowMachine:
		
		if (_box._x<=this->GetCollideRegion()._x || _box._x+_box._width>=this->GetCollideRegion()._x + this->GetCollideRegion()._width)
		{
			_v.x *= -1;
		}
		_position.x += _v.x*gameTime->GetDeltaTime();
		if (rockman->_position.x>this->GetCollideRegion()._x&&rockman->_position.x<this->GetCollideRegion()._x + this->GetCollideRegion()._width)
		{
			_static = STATICMACHINE::RunFastMachine;
			_timeFrame = TIMEFRAME::TimeFast;
			_v.x *= 2;
			_sprite.SetAllowAnimate(_timeFrame);
		}
		break;
	case STATICMACHINE::RunFastMachine:
		
		if (_box._x<=this->GetCollideRegion()._x || _box._x + _box._width>=this->GetCollideRegion()._x + this->GetCollideRegion()._width)
		{
			_v.x *= -1;
		}
		_position.x += _v.x*gameTime->GetDeltaTime();
		if (rockman->_position.x<this->GetCollideRegion()._x||rockman->_position.x>this->GetCollideRegion()._x + this->GetCollideRegion()._width)
		{
			_static = STATICMACHINE::RunSlowMachine;
			_timeFrame = TIMEFRAME::TimeSlow;
			_v.x /= 2;
			_sprite.SetAllowAnimate(_timeFrame);
		}
		break;
	default:
		break;
	}
	OutputDebugStringW((L"va toc" + wstring(::to_wstring(_v.x) + L"\n")).c_str());
	UpdateBox();
	_sprite.Update(gameTime);
	
}
void CEnemyMachine::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_ROCKMAN://Nếu đối tượng va chạm là ROCKMAN. 
		break;
	case ID_BULLET_ROCKMAN_NORMAL: case ID_BULLET_ROCKMAN_BOOM: case ID_BULLET_ROCKMAN_CUT: case ID_BULLET_ROCKMAN_GUTS:
		_timeStand = 0;
		_static = STATICMACHINE::StandMachine;
		_timeFrame = TIMEFRAME::TimeStand;
		_sprite.SetIndex(1);
		_v.x = 0;
		_sprite.SetAllowAnimate(_timeFrame);
		ResourceManager::PlayASound(ID_EFFECT_BULLET_HIT_ENEMY_WITH_SHIELD);
		break;
	}
}
void CEnemyMachine::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}
CEnemyMachine* CEnemyMachine::ToValue()
{
	return new CEnemyMachine(*this);
}
CEnemyMachine::~CEnemyMachine()
{

}

