#include "CGutsRockManBullet.h"

CGutsRockmanBullet::CGutsRockmanBullet(CRockman* master, int rockTypeID) :CBullet(0, ID_BULLET_ROCKMAN_GUTS, ResourceManager::GetSprite(ID_SPRITE_BULLET_ROCKMAN_GUTS_BIG), 5, Vector2(0, 0), master->_position)
{
	_master = master;
	_isAtFirst = true;
	_deltaTime = 0;
	_dame = DAME_BULLET_GUTS_ROCKMAN;

	if (_master->_isRight)
	{
		_position = _master->_position + Vector2(_sprite.GetFrameWidth()/2,_sprite.GetFrameHeight()/2);
	}
	else
	{
		_position = _master->_position + Vector2(-_sprite.GetFrameWidth() / 2, _sprite.GetFrameHeight() / 2);
	}
	switch (rockTypeID)
	{
	case ID_ROCK_IN_GUT_STAGE:
		_sprite = ResourceManager::GetSprite(ID_SPRITE_BULLET_ROCKMAN_GUTS_STAGE_BIG);
	}
	UpdateBox();
}

CGutsRockmanBullet::~CGutsRockmanBullet()
{

}

int CGutsRockmanBullet::Initlize()
{
	return 1;
}

void CGutsRockmanBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	CGameObject::Render(gameTime, graphics);
}

void CGutsRockmanBullet::Update(CGameTime* gameTime)
{
		if (!_isAtFirst)
		{
			if (_master->_isThrowRock||_master->_currentSkill!=Skill::GUTS)
			{
				if (_master->_currentSkill == Skill::GUTS)
				{
					_master->_canFire = true;
					_spriteStatus = ID_SPRITE_BULLET_ROCKMAN_GUTS_SMALL;
					_sprite = ResourceManager::GetSprite(_spriteStatus);
				}
				Vector2 v = Vector2(135.0f / 1000.0f, 5.0f / 1000.0f);
				if (!_master->_isRight)
					v.x *= -1.0f;

				CBulletRockman *bullet1 = new CBulletRockman(v + Vector2(48.0f / 1000.0f, 5.0f / 1000.0f), _position + Vector2(-8, 8), ID_BULLET_ROCKMAN_GUTS, ResourceManager::GetSprite(ID_SPRITE_BULLET_ROCKMAN_GUTS_SMALL), DAME_BULLET_GUTS_ROCKMAN);
				CBulletRockman *bullet2 = new CBulletRockman(v + Vector2(32.0f / 1000.0f, 10.0f / 1000.0f), _position + Vector2(8, 8), ID_BULLET_ROCKMAN_GUTS, ResourceManager::GetSprite(ID_SPRITE_BULLET_ROCKMAN_GUTS_SMALL), DAME_BULLET_GUTS_ROCKMAN);
				CBulletRockman *bullet3 = new CBulletRockman(v + Vector2(16.0f / 1000.0f, 0.0f / 1000.0f), _position + Vector2(-8, -8), ID_BULLET_ROCKMAN_GUTS, ResourceManager::GetSprite(ID_SPRITE_BULLET_ROCKMAN_GUTS_SMALL), DAME_BULLET_GUTS_ROCKMAN);
				CBulletRockman *bullet4 = new CBulletRockman(v + Vector2(8.0f / 1000.0f, 5.0f), _position + Vector2(8, -8), ID_BULLET_ROCKMAN_GUTS, ResourceManager::GetSprite(ID_SPRITE_BULLET_ROCKMAN_GUTS_SMALL), DAME_BULLET_GUTS_ROCKMAN);

				_master->_bullets.push_back(bullet1);
				_master->_bullets.push_back(bullet2);
				_master->_bullets.push_back(bullet3);
				_master->_bullets.push_back(bullet4);

				Die();

			}
			_position = _master->_position + Vector2(0, _master->GetBox()._height / 2 + GetBox()._height / 2);
		}
		else
		{
			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 50)
			{
				_isAtFirst = false;
				_deltaTime = 0;
				_position = _master->_position + Vector2(0, _master->GetBox()._height / 2 + GetBox()._height / 2);
			}
		}
	UpdateBox();
}

void CGutsRockmanBullet::UpdateBox(){
	_box._width = _sprite.GetFrameWidth() - 4;
	_box._height = _sprite.GetFrameHeight() - 4;
	_box._x = _position.x - _box._width / 2;
	_box._y = _position.y + _box._height / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
}


void CGutsRockmanBullet::Destroy()
{

}