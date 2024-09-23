#include "CEnemyHat.h"
CEnemyHat::CEnemyHat()
{
	_dame = DAME_ENEMY_HAT;
	_blood = 1;
	_score = SCORE_DEFAULT;
}
CEnemyHat::~CEnemyHat()
{
	//SAFE_DELETE(_sprite);
}
int CEnemyHat::Initlize()
{
	_timeDistant = 1000;
	_timeChangeFrame = -1;
	_isChangeDirection = false;

	TIMEDISTANTDEFAULT = 1500;
	TIMECHANGEFRAME = 500;

	// khoảng cách rockman với enemy để enemy thực hiện bắn 
	_spaceFire = 100;
	_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_HAT);
	_statusEnemyHat = StaTusEnemyHat::Stand;
	UpdateBox();
	//_statusHat = STATUS_HAT::NONE_ATTACK;
	return 1;
}
void CEnemyHat::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (!_isChangeDirection)
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	else
	{
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true,Vector2(1,1),SpriteEffects::FLIP_HORIZONTALLY);
	}

}

void CEnemyHat::Update(CGameTime* gameTime, CRockman* rockman)
{
	if (abs(rockman->_position.x - this->_position.x) <= _spaceFire)
	{
		_timeDistant -= gameTime->GetDeltaTime();
		if (_timeDistant <= 0)
		{
			FireRockMan(gameTime->GetDeltaTime());
			_timeDistant = TIMEDISTANTDEFAULT;
			_timeChangeFrame = 0;
			_sprite.SetIndex(1);
			_statusEnemyHat = StaTusEnemyHat::Fire;
		}

	}
	if (_timeChangeFrame >= 0)
	{
		_timeChangeFrame += gameTime->GetDeltaTime();
		if (_timeChangeFrame > TIMECHANGEFRAME)
		{
			_timeChangeFrame = -1;
			_sprite.SetIndex(0);
			_statusEnemyHat = StaTusEnemyHat::Stand;
		}
	}
	if (rockman->_position.x < _position.x)
		_isChangeDirection = false;
	else
		_isChangeDirection = true;
	_sprite.Update(gameTime);
	UpdateBox();
}
void CEnemyHat::FireRockMan(float deltatime)
{
	float posX = _position.x-9;
	float posY = _position.y - 4, angleFly,_positiontemX;
	// kiem tra neu rockman đi qua hat thi doi huong
	if (!_isChangeDirection)
	{
		angleFly = 3 * PI / 4;
		_positiontemX = posX;
	}
	else
	{
		angleFly = 7 * PI / 4;
		_positiontemX = posX + _sprite.GetFrameWidth();
	}
	_lstBullet.clear();
	for (int i = 0; i < 3; i++)
	{
		
		CEnemyMachineAutoBullet*  bullet = new CEnemyMachineAutoBullet(0, ID_BULLET_ENEMY_HAT, ResourceManager::GetSprite(ID_SPRITE_BULLET_ENEMY_HAT),
			DAME_BULLET_HAT, 80.f / 1000.0f, Vector2(_positiontemX, posY),
			angleFly + i * PI / 4.0f);

		((CBullet*)bullet)->Initlize();
		_lstBullet.push_back(bullet);
		ResourceManager::PlayASound(ID_EFFECT_ENEMY_FIRE);
	}

}
void CEnemyHat::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BULLET_ROCKMAN_NORMAL: 
		if (_statusEnemyHat == StaTusEnemyHat::Fire)
			_blood = 0;
		else
		{
			ResourceManager::PlayASound(ID_EFFECT_BULLET_HIT_ENEMY_WITH_SHIELD);
			//((CBullet*)gameObject)->Die();
		}
		break;
	case ID_BULLET_ROCKMAN_BOOM: case ID_BULLET_ROCKMAN_CUT: case ID_BULLET_ROCKMAN_GUTS:
		_blood = 0;
		break;
	default:
		break;
	}
}
void CEnemyHat::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}
vector<CBullet*> CEnemyHat::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	return result;
}
CEnemyHat* CEnemyHat::ToValue()
{
	return new CEnemyHat(*this);
}
