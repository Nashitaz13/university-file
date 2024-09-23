#include "CEnemyWallShooter.h"

CEnemyWallShooter::CEnemyWallShooter(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, ENEMYWALLSHOOTER_ORIENTATION orientation, Vector2 v, Vector2 positionBegin, int dame, int blood, int score) :CEnemy()
{
	_id = id;
	_typeID = typeID;
	_sprite = sprite;
	_orientation = orientation;
	_v = v;
	_dame = dame;
	_position = positionBegin;
	_lstBullet = vector<CBullet*>();
	_timeDefense = TIME_DEFENSE_OF_WALL_SHOOTER_ENEMY - 2.0f * TIME_DEFENSE_OF_WALL_SHOOTER_ENEMY/3.0f;//Giảm thời gian phòng thủ lúc ban đầu lại để cho đẹp hơn
	_timeDelayFireRemain = 0;
	_numOfPrevBullet = 0;
	_blood = blood;
	_score = score;
	_isHitDame = false;

	float lowRand = 0.0, highRand = 1.0;//Biến max, min Random
	float r3 = lowRand + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (highRand - lowRand)));
	if (r3 < 0.5)
	{
		_state = ENEMYWALLSHOOTER_STATE::DEFENSE;
	}
	else
	{
		_state = ENEMYWALLSHOOTER_STATE::ATTACK;
	}

	_spriteExplodingEffect = spriteExplodingEffect;
}

CEnemyWallShooter::~CEnemyWallShooter()
{
}

int CEnemyWallShooter::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	_sprite.SetIndex(0);
	UpdateBox();
	return 1;
}

void CEnemyWallShooter::Update(CGameTime* gameTime, CRockman* rockman)
{
	//Nếu thời gian phòng thủ đã hết
	if (_timeDefense <= 0
		&& _state==ENEMYWALLSHOOTER_STATE::DEFENSE)
	{
		_state = ENEMYWALLSHOOTER_STATE::ATTACK;
		_sprite.SetFrame(1, 3);
	}

	#pragma region Trạng thái tấn công
	if (_state == ENEMYWALLSHOOTER_STATE::ATTACK)
	{
		if (_sprite.GetIndex() == 3)
		{
			_sprite.SetIndex(3);//Chỉ vẽ sprite có súng dài nhất
		}
		_timeDelayFireRemain -= gameTime->GetDeltaTime();
		if (_timeDelayFireRemain <= 0)
		{
			//Tìm vị trí của viên đạn
			float posY = _position.y;
			//angleFly: Góc bắn của viên đạn, lấy trục dương Ox làm gốc tọa độ. Đơn vị Radian
			float posX, angleFly;
			//Giá trị để cho biết hướng bay của đạn là qua trái (1) hay qua phải (-1).
			int vectorXOfFLyOfBullet = 1;
			if (_orientation == ENEMYWALLSHOOTER_ORIENTATION::LEFT)
			{
				posX = _position.x - 1 * _sprite.GetFrameWidth() / 2;
				angleFly = PI / 2.0f + PI / 4.0f;
				vectorXOfFLyOfBullet = 1;
			}
			else
			{
				posX = _position.x + 1 * _sprite.GetFrameWidth() / 2;
				angleFly = 2 * PI + PI / 4.0f;
				vectorXOfFLyOfBullet = -1;
			}
			//Tính toán góc bắn cho viên đạn sắp bắn ra dựa vào số thứ tự viên đạn trước đó.
			angleFly = angleFly + vectorXOfFLyOfBullet * (_numOfPrevBullet++*(PI / 6.0f));//Cần phải nhân vectorXOfFLyOfBullet là do khi đạn bay sang phải thì góc bắn theo thứ tự phải là trừ dần so với góc đã xác định ban đầu.

			//Để chắc ăn là đạn không còn trước khi được add vào thì tiến hành clear() trước
			_lstBullet.clear();
			//Thêm đạn vào list Đạn
			CBullet*  bullet = new CEnemyMachineAutoBullet(0, ID_BULLET_WALL_SHOOTER,
				ResourceManager::GetSprite(ID_SPRITE_BULLET_RED_COLOR),
				DAME_BULLET_WALL_SHOOTER, 120.f / 1000.0f, Vector2(posX, posY), angleFly);
			bullet->Initlize();
			_lstBullet.push_back(bullet);
			ResourceManager::PlayASound(ID_EFFECT_ENEMY_FIRE);

			//Reset thời gian nghỉ còn lại giữa 2 lần bắn 
			_timeDelayFireRemain = TIME_DELAY_FIRE_OF_WALL_SHOOTER_ENEMY;
			//Nếu viên đạn vừa bắn có _numOfPrevBullet == 4 thì reset về giá trị 0 để lần tới tiếp tục bắn từ viên thứ 1.
			if (_numOfPrevBullet == 4)
			{
				_numOfPrevBullet = 0;
				_sprite.SetFrame(2, 0);
			}
		}

		if (_sprite.GetIndex() == 0)
		{
			_sprite.SetIndex(0);
			_state = ENEMYWALLSHOOTER_STATE::DEFENSE;//Chuyển về trạng thái phòng thủ
			_timeDefense = TIME_DEFENSE_OF_WALL_SHOOTER_ENEMY;
		}
	}
	#pragma endregion	

	#pragma region Trạng thái phòng thủ
	if (_state == ENEMYWALLSHOOTER_STATE::DEFENSE)
	{
		_timeDefense -= gameTime->GetDeltaTime();
	}
	#pragma endregion

	_isHitDame = false;
	this->UpdateBox();
	_sprite.Update(gameTime);
}

void CEnemyWallShooter::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_orientation == ENEMYWALLSHOOTER_ORIENTATION::LEFT)
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	else
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::FLIP_HORIZONTALLY);

	CGameObject::Render(gameTime, graphics);
	CMoveableObject::Render(gameTime, graphics);
}

void CEnemyWallShooter::UpdateBox()
{
	switch (_sprite.GetIndex())
	{
	case 3:
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight();
		break;
	default:
		if (_orientation == ENEMYWALLSHOOTER_ORIENTATION::LEFT)
			_box._x = _position.x-1;
		else
			_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth()/2 + 2;
		_box._height = _sprite.GetFrameHeight();
		break;
	}
}

void CEnemyWallShooter::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BULLET_ROCKMAN_GUTS:
	case ID_BULLET_ROCKMAN_CUT:
	case ID_BULLET_ROCKMAN_BOOM:
	case ID_BULLET_ROCKMAN_NORMAL:
		if (normalX != CDirection::NONE_DIRECT 
			&& !_isHitDame )
		{
			_isHitDame = true;
			if (_state == ENEMYWALLSHOOTER_STATE::ATTACK)
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

CEnemyWallShooter* CEnemyWallShooter::ToValue()
{
	return new CEnemyWallShooter(*this);
}

vector<CBullet*> CEnemyWallShooter::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	return result;
}