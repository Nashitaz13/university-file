#include "CEnemyFish.h"
CEnemyFish::CEnemyFish(int positionYStart, CCameraPath* cameraPath)
{
	_dame = DAME_ENEMY_FISH;
	_positionYStart = positionYStart;
	_static = StaticFish::Fly;
	_spacePositionYChange = 50;
	_cameraPath = cameraPath;
	_blood = 1;
	_score = SCORE_DEFAULT;
	
}
CEnemyFish::~CEnemyFish()
{

}
int CEnemyFish::Initlize()
{
	_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_FISH);
	_v = Vector2(50.0f / 1000.0f, 60.0f / 1000.0f);
	_g = 0.098f / 1000.0f;
	UpdateBox();
	return 1;
}
void CEnemyFish::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_static==StaticFish::Fly)
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
}
void CEnemyFish::Update(CGameTime* gameTime, CRockman* rockman)
{
	
	/*if (timetest > 2000)
	{
		_static = StaticFish::Fire;
	}
	else
		timetest += gameTime->GetDeltaTime();*/
	if (_static == StaticFish::Fly)
	{
		_position.x -= _v.x*gameTime->GetDeltaTime();
		_position.y += _v.y*gameTime->GetDeltaTime();
		if (_position.y > _positionYStart + _spacePositionYChange || _position.y < _positionYStart - _spacePositionYChange)
		{
			_v.y *= -1;
		}
	}
	if (_static == StaticFish::Efforts)
	{
		_lstBullet.clear();
		_lstBullet.push_back( new CEnemyFishBullet(0, ID_BULLET_ENEMY_FISH, ResourceManager::GetSprite(ID_SPRITE_BULLET_ENEMY_FISH), 1, 0, Vector2(0, 0), 0, _position.x, _position.y));
		_static = StaticFish::Die;

	}
	if (_static == StaticFish::Die)
	{
		_position.x = _cameraPath->GetCameraPointOnPath().x + SCREEN_WIDTH/2;
		_position.y = _cameraPath->GetCameraPointOnPath().y;
		_static = StaticFish::Fly;
	}
	UpdateBox();
}
void CEnemyFish::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_ROCKMAN://Nếu đối tượng va chạm là ROCKMAN. 
		if (_static==StaticFish::Fly)
		   _static = StaticFish::Efforts;
		break;
	case ID_BULLET_ROCKMAN_NORMAL: case ID_BULLET_ROCKMAN_BOOM: case ID_BULLET_ROCKMAN_CUT: case ID_BULLET_ROCKMAN_GUTS:
		    _static = StaticFish::Efforts;
			_blood = 0;
		break;
	}
}
void CEnemyFish::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}
vector<CBullet*> CEnemyFish::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	return result;
}
StaticFish CEnemyFish::GetStaticFish()
{
	return _static;
}
CEnemyFish* CEnemyFish::ToValue()
{
	return new CEnemyFish(*this);
}