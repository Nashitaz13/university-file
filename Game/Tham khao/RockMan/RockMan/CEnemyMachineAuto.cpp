#include "CEnemyMachineAuto.h"

CEnemyMachineAuto::CEnemyMachineAuto(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, int spriteIDBullet, ENEMYMACHINEAUTO_ORIENTATION orientation, Vector2 v, Vector2 positionBegin, int dame, int blood, int score) :CEnemy()
{
	_id = id;
	_typeID = typeID;
	_sprite = sprite;
	_orientation = orientation;
	_v = v;
	_dame = dame;
	_position = positionBegin;
	_lstBullet = vector<CBullet*>();
	_timeAttackRemain = 0;
	_timeDelayFireRemain = 0;
	_blood = blood;
	_score = score;
	_isHitDame = false;
	_spriteIdBullet = spriteIDBullet;
	_spriteExplodingEffect = spriteExplodingEffect;
}

CEnemyMachineAuto::~CEnemyMachineAuto()
{
}

int CEnemyMachineAuto::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	_sprite.SetIndex(0);
	UpdateBox();
	return 1;
}

void CEnemyMachineAuto::Update(CGameTime* gameTime, CRockman* rockman)
{
	_sprite.Update(gameTime);

	//Nếu Rockman nằm trong vùng cho phép tấn công và thời gian tấn công còn lại đã hết
	if (abs(rockman->_position.x - this->_position.x) <= SPACE_X_TO_MACHINE_AUTO_ENEMY_ATTACK
		&& _timeAttackRemain <= 0)
	{
		_timeAttackRemain = TIME_ATTACK_OF_MACHINE_AUTO_ENEMY + TIME_DELAY_ATTACK_OF_MACHINE_AUTO_ENEMY;//Gán lại thời gian tấn công còn lại
		_timeDelayFireRemain = TIME_DELAY_FIRE_OF_MACHINE_AUTO_ENEMY;
		_sprite.SetFrame(1, 3);
	}

	if (_timeAttackRemain > TIME_DELAY_ATTACK_OF_MACHINE_AUTO_ENEMY)//Nếu thời gian tấn công còn lại vẫn còn
	{
		//Trong vùng - TIme TC còn; Ngoài vùng - Time TC còn
		AttackRockman(gameTime->GetDeltaTime()); 
	}			
	else
	{
		//Trong vùng - Time TC hết; Ngoài vùng - Time TC hết
		_timeDelayFireRemain = 0;
		_sprite.SetIndex(0);
	}
	_timeAttackRemain -= gameTime->GetDeltaTime();
	_isHitDame = false;
	this->UpdateBox();	
}

void CEnemyMachineAuto::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_orientation==ENEMYMACHINEAUTO_ORIENTATION::BOTTOM)
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	else
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::FLIP_VERTICALLY);

	CGameObject::Render(gameTime, graphics);
	CMoveableObject::Render(gameTime, graphics);
}

void CEnemyMachineAuto::UpdateBox()
{
	switch (_sprite.GetIndex())
	{
	case 0:
		if (_orientation == ENEMYMACHINEAUTO_ORIENTATION::BOTTOM)
			_box._y = _position.y +1;
		else
			_box._y = _position.y + _sprite.GetFrameHeight() / 2;

		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight()/2+1;
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

void CEnemyMachineAuto::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BULLET_ROCKMAN_GUTS:
	case ID_BULLET_ROCKMAN_CUT:
	case ID_BULLET_ROCKMAN_BOOM:
	case ID_BULLET_ROCKMAN_NORMAL:
		if (normalX != CDirection::NONE_DIRECT && !_isHitDame)
		{
			_isHitDame = true;
			_blood -= ((CBullet*)gameObject)->GetDame();
			if (_blood <= 0)
			{
				CExplodingEffect* explodingEffect = new CExplodingEffect(this->_position, _spriteExplodingEffect);
				explodingEffect->Initlize();
				CExplodingEffectManager::Add(explodingEffect);
			}
		}
		break;
	}
}


CEnemyMachineAuto* CEnemyMachineAuto::ToValue()
{
	return new CEnemyMachineAuto(*this);
}

void CEnemyMachineAuto::AttackRockman(float deltaTime)
{ 
	#pragma region Bắn đạn
	//Nếu hết thời gian nghỉ bắn thì tiến hành bắn đạn
	if (_timeDelayFireRemain <= 0)
	{
		//Tìm vị trí của viên đạn
		float posX = _position.x;
		float posY, angleFly;
		if (_orientation == ENEMYMACHINEAUTO_ORIENTATION::TOP)
		{
			posY = _position.y - 1 * _sprite.GetFrameHeight() / 4;
			angleFly = PI;
		}
		else
		{
			posY = _position.y + 1 * _sprite.GetFrameHeight() / 4;
			angleFly = 0;
		}

		//Để chắc ăn là đạn không còn trước khi được add vào thì tiến hành clear() trước
		_lstBullet.clear();
		//Thực hiện việc bắn đạn ra
		for (int i = 0; i < 5; i++)
		{
			CBullet*  bullet = new CEnemyMachineAutoBullet(0, ID_BULLET_MACHINE_AUTO,
				ResourceManager::GetSprite(_spriteIdBullet),
				DAME_BULLET_MACHINE_AUTO, 100.f / 1000.0f, Vector2(posX, posY),
				angleFly + i * PI / 4.0f);
			bullet->Initlize();
			_lstBullet.push_back(bullet);
		}
		ResourceManager::PlayASound(ID_EFFECT_ENEMY_FIRE);
		//Reset lại thời gian nghỉ bắn đạn
		_timeDelayFireRemain = TIME_DELAY_FIRE_OF_MACHINE_AUTO_ENEMY;
	}
	else
		_timeDelayFireRemain -= deltaTime;
	#pragma endregion		
}

vector<CBullet*> CEnemyMachineAuto::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	return result;
}