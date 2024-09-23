#include "CEnemyBall.h"


CEnemyBall::CEnemyBall(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, float vX, Vector2 positionBegin, int dame, int blood, int score) :CEnemy()
{
	_id = id;
	_typeID = typeID;
	_sprite = sprite;
	_v = Vector2(vX, 0);
	_dame = dame;
	_position = positionBegin;
	_lstBullet = vector<CBullet*>();
	_timeDefenseRemain = TIME_DEFENSE_OF_BALL_ENEMY;
	_timeAttackRemain = TIME_ATTACK_OF_BALL_ENEMY;
	_blood = blood;
	_isHitDame = false;
	_score = score;


	_spriteExplodingEffect = spriteExplodingEffect;
}

CEnemyBall::~CEnemyBall()
{
}

int CEnemyBall::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	_sprite.SetIndex(0);
	UpdateBox();
	return 1;
}

void CEnemyBall::Update(CGameTime* gameTime, CRockman* rockman)
{
	_sprite.Update(gameTime);

	//Nếu hết thời gian nghỉ tấn công thì tiến hành tấn công
	if (_timeDefenseRemain <= 0
		&& _state==ENEMYBALL_STATE::DEFENSE)
	{
		_sprite.SetIndex(1);
		_state = ENEMYBALL_STATE::ATTACK;
		_timeAttackRemain = TIME_ATTACK_OF_BALL_ENEMY;
	}

	if (_state == ENEMYBALL_STATE::ATTACK )
	{
		if (_timeAttackRemain <= 0)
			AttackRockman(gameTime->GetDeltaTime());
		else
			_timeAttackRemain -= gameTime->GetDeltaTime();
	}
	else
	{
		_timeDefenseRemain -= gameTime->GetDeltaTime();
		_position.x += gameTime->GetDeltaTime()*-abs(_v.x);
	}

	_isHitDame = false;
	this->UpdateBox();
}

void CEnemyBall::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	CGameObject::Render(gameTime, graphics);
	CMoveableObject::Render(gameTime, graphics);
}

void CEnemyBall::UpdateBox()
{
	switch (_sprite.GetIndex())
	{
	case 0:
		_box._y = _position.y + _sprite.GetFrameHeight() / 2 - 5;
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight() / 2 + 1;
		break;
	default:
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight();
		break;
	}
}

void CEnemyBall::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BULLET_ROCKMAN_GUTS:
	case ID_BULLET_ROCKMAN_CUT:
	case ID_BULLET_ROCKMAN_BOOM:
	case ID_BULLET_ROCKMAN_NORMAL:
		if (normalX != CDirection::NONE_DIRECT 
			&& !_isHitDame)
		{
			_isHitDame = true;
			if (_state == ENEMYBALL_STATE::ATTACK)
			{
				_blood -= ((CBullet*)gameObject)->GetDame();
				if (_blood <= 0)
				{
					CExplodingEffect* explodingEffect = new CExplodingEffect(this->_position, _spriteExplodingEffect);
					explodingEffect->Initlize();
					CExplodingEffectManager::Add(explodingEffect);
				}
			}
			else
				ResourceManager::PlayASound(ID_EFFECT_BULLET_HIT_ENEMY_WITH_SHIELD);
		}
		break;
	}
}

CEnemyBall* CEnemyBall::ToValue()
{
	return new CEnemyBall(*this);
}

void CEnemyBall::AttackRockman(float deltaTime)
{
	#pragma region Bắn đạn
	//Tìm vị trí của viên đạn
	float posX = _position.x;
	float posY = _position.y, angleFly = 0;

	//Để chắc ăn là đạn không còn trước khi được add vào thì tiến hành clear() trước
	_lstBullet.clear();
	//Thực hiện việc bắn đạn ra
	for (int i = 0; i < 8; i++)
	{
		CBullet*  bullet = new CEnemyMachineAutoBullet(0, ID_BULLET_BALL,
			ResourceManager::GetSprite(ID_SPRITE_BULLET_ORANGE_COLOR), 
			DAME_BULLET_BALL, 230.0f / 1000.0f, Vector2(posX, posY),
			angleFly + i * PI / 4.0f);
		bullet->Initlize();
		_lstBullet.push_back(bullet);
	}
	#pragma endregion	
	ResourceManager::PlayASound(ID_EFFECT_ENEMY_FIRE);

	_state = ENEMYBALL_STATE::DEFENSE;
	_sprite.SetIndex(0);
	_timeDefenseRemain = TIME_DEFENSE_OF_BALL_ENEMY;
}

vector<CBullet*> CEnemyBall::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	return result;
}