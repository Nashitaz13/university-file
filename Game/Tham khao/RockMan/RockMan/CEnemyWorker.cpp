#include "CEnemyWorker.h"

//So sánh thời gian va chạm của hai biến CollisionInfo. Trả về True nếu first<second và ngược lại
bool CompareTimeCollide1(const CollisionInfo& first, const CollisionInfo& second)
{
	return (first._timeCollide < second._timeCollide);
}

CEnemyWorker::CEnemyWorker(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, float vX, Vector2 positionBegin, int dame, int blood, int score) :CEnemy()
{
	_id = id;
	_typeID = typeID;
	_sprite = sprite;
	_v = Vector2(vX,-vX);
	_dame = dame;
	_position = positionBegin;
	_positionAttack = positionBegin;
	_lstBullet = vector<CBullet*>();
	_timeAttackOrDefenseRemain = 0;
	_timeDelayFireRemain = 0;
	_blood = blood;
	_score = score;
	_state = ENEMYWORKER_STATE::JUMPING;
	_sprite.SetIndex(0);
	_isAppeared = false;
	_isHitDame = false;

	_spriteExplodingEffect = spriteExplodingEffect;
}

CEnemyWorker::~CEnemyWorker()
{
}

int CEnemyWorker::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	UpdateBox();
	return 1;
}

void CEnemyWorker::Update(CGameTime* gameTime, CRockman* rockman)
{
	_sprite.Update(gameTime);

	#pragma region Kiểm tra xem nếu chưa xuất hiện lần nào
	if (!_isAppeared)
	{
		_isAppeared = true;
		if (rockman->_position.x >= this->_positionAttack.x)
		{
			_position = Vector2(_positionAttack.x - 50, _positionAttack.y + 50);
			_spriteEffect = SpriteEffects::FLIP_HORIZONTALLY;
		}
		else
		{
			_position = Vector2(_positionAttack.x + 50, _positionAttack.y + 50);
			_spriteEffect = SpriteEffects::NONE;
		}
	}
	#pragma endregion	
	
	#pragma region Vùng xử lý va chạm với BLOCK, ROCK objects (các đối tượng mà khi va chạm EnemyRobot phải dừng lại)
	for each (CollisionInfo item in _collidedInfoLst)
	{
		switch (item._direction)
		{
		case CDirection::INSIDE:
			break;

		case CDirection::ON_LEFT:
			//Set vị trí của EnemyRobot về vị trí bắt đầu xảy ra va chạm
			_position.x += item._timeCollide *_v.x;
			_v.x = 0;//Dừng chuyển động chiều x (ngang) của EnemyRobot bằng cách set v.x = 0
			break;

		case CDirection::ON_RIGHT:
			//Set vị trí của EnemyRobot về vị trí bắt đầu xảy ra va chạm
			_position.x += item._timeCollide*_v.x;
			_v.x = 0;//Dừng chuyển động chiều x (ngang) của EnemyRobot bằng cách set v.x = 0
			break;

		case CDirection::ON_UP:
			break;

		case CDirection::ON_DOWN:
			if (_state == ENEMYWORKER_STATE::JUMPING)
			{
				//Set vị trí của EnemyRobot về vị trí bắt đầu xảy ra va chạm
				_position.y += (item._timeCollide*_v.y);
				//Chuyển trạng thái của EnemyRobot thành đứng
				
				float lowRand = 0.0, highRand = 1.0;//Biến max, min Random
				float r3 = lowRand + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (highRand - lowRand)));
				if (r3 <= 0.2)//Tỉ lệ cho phòng thủ và tấn công tương ứng là 2/8
				{//Phòng thủ
					_state = ENEMYWORKER_STATE::DEFENSE;
					_sprite.SetIndex(0);
				}
				else
				{//Tấn công
					_state = ENEMYWORKER_STATE::ATTACK;
					_sprite.SetFrame(1, 2);
				}
				lowRand = 2.0, highRand = 5.0;//Biến max, min Random tìm _timeAttackOrDefenseRemain
				_timeAttackOrDefenseRemain = (lowRand + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (highRand - lowRand)))) * 1000;//Nhân 1000 vì đơn vị thơi gian của _timeAttackOrDefenseRemain là tick.

				_v = Vector2(0, 0);
			}
			break;
		}
	}

	this->ResetCollideVariable();
	#pragma endregion
	
	// Rockman ở phía bên nào thì phải quay mặt Worker về hướng đó
	if (rockman->_position.x > this->_positionAttack.x)
	{
		_spriteEffect = SpriteEffects::FLIP_HORIZONTALLY;
		_v.x = abs(_v.x);
	}
 	else
	{
		_spriteEffect = SpriteEffects::NONE;
		_v.x = -1 * abs(_v.x);
	}

	#pragma region Vùng nhảy xuất hiện ra
	if (_state == ENEMYWORKER_STATE::JUMPING)
	{
		_position.x += gameTime->GetDeltaTime()*_v.x;
		_position.y += gameTime->GetDeltaTime()*_v.y;
		_v.y *= 1.00;//Nhân 1.xx là để tạo cảm giác rớt nhanh dần đều
	}
	#pragma endregion	
	else
	#pragma region Vùng tấn công và phòng thủ
	{
		//Nếu đã hết thời gian tấn công hoặc thời gian phòng thủ thì tiến hành random lại để chọn trạng thái kế tiếp
		if (_timeAttackOrDefenseRemain <= 0)
		{
			float lowRand = 0.0, highRand = 1.0;//Biến max, min Random
			float r3 = lowRand + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (highRand - lowRand)));
			if (r3 <= 0.2)//Tỉ lệ cho phòng thủ và tấn công tương ứng là 2/8
			{//Phòng thủ
				_state = ENEMYWORKER_STATE::DEFENSE;
				_sprite.SetIndex(0);
			}
			else
			{//Tấn công
				_state = ENEMYWORKER_STATE::ATTACK;
				_sprite.SetFrame(1, 2);
			}
			lowRand = 2.0, highRand = 5.0;//Biến max, min Random tìm _timeAttackOrDefenseRemain
			_timeAttackOrDefenseRemain = (lowRand + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (highRand - lowRand)))) * 1000;//Nhân 1000 vì đơn vị thơi gian của _timeAttackOrDefenseRemain là tick.
		}

		if (_state == ENEMYWORKER_STATE::ATTACK)
		{
			//Bắn đạn
			_timeDelayFireRemain -= gameTime->GetDeltaTime();
			if (_timeDelayFireRemain <= 0)
			{
				//Tìm vị trí của viên đạn
				float posX, posY = _position.y + _sprite.GetFrameHeight() / 2 - 5;//Trừ 5 pixel là vì chọn vị trí tay nắm trên frameSprite có index = 1
				if (_spriteEffect == SpriteEffects::NONE)
				{//Đạn quăng qua trái
					posX = _position.x - 1 * _sprite.GetFrameWidth() / 2;
				}
				else
				{//Đạn quăng qua phải
					posX = _position.x + 1 * _sprite.GetFrameWidth() / 2;
				}

				//Để chắc ăn là đạn không còn trước khi được add vào thì tiến hành clear() trước
				_lstBullet.clear();
				//Thêm đạn vào list Đạn
				CBullet*  bullet = new CEnemyWorkerBullet(0, ID_BULLET_WORKER,
					ResourceManager::GetSprite(ID_SPRITE_BULLET_WORKER),
					DAME_BULLET_WORKER, Vector2(posX, posY),
					abs(rockman->_position.x-posX)*4.7,
					(_spriteEffect != SpriteEffects::NONE) ? 1.0f * PI / 7.50f : PI - 1.0f * PI / 7.50f);
				bullet->Initlize();
				_lstBullet.push_back(bullet);
				ResourceManager::PlayASound(ID_EFFECT_ENEMY_FIRE);

				//Reset thời gian nghỉ còn lại giữa 2 lần bắn 
				float lowRand = 0.7, highRand = 1.5;//Biến max, min Random.
				float r3 = (lowRand + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (highRand - lowRand))));
				_sprite.SetAllowAnimate(r3>1.2 ? 1.2 * TIME_DELAY_FIRE_OF_WORKER_ENEMY : r3*TIME_DELAY_FIRE_OF_WORKER_ENEMY);
				
				_timeDelayFireRemain = _sprite._timeFrameDefault;
			}
		}

		//if (_state == ENEMYWORKER_STATE::DEFENSE)//Chỗ này mặc dù không có cần thực hiện gì nhưng cũng để dòng code này để đọc có thể hiểu dc là có trạng thái Phòng thủ thì ko cần xử lý logic gì hết
		//{
		//	//Do not anything
		//}

		_timeAttackOrDefenseRemain -= gameTime->GetDeltaTime();
	}
	#pragma endregion

	_isHitDame = false;
	this->UpdateBox();
}

void CEnemyWorker::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, _spriteEffect);

	CGameObject::Render(gameTime, graphics);
	CMoveableObject::Render(gameTime, graphics);
}

void CEnemyWorker::UpdateBox()
{
	switch (_sprite.GetIndex())
	{
	case 0:
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight();
		break;
	case 1:
		_box._x = _position.x - _sprite.GetFrameWidth() / 2 + 3;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth() - 6;
		_box._height = _sprite.GetFrameHeight();
		break;
	case 2:
		_box._x = _position.x - _sprite.GetFrameWidth() / 2 + 5;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth() - 9;
		_box._height = _sprite.GetFrameHeight();
		break;
	}
}

void CEnemyWorker::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BLOCK:
	case ID_ROCK:
		if (normalX != CDirection::NONE_DIRECT || normalY != CDirection::NONE_DIRECT)
		{
			//Biến đếm này dùng để kiểm tra xem đi hết vòng for hay là thoát ra bằng lệnh break()
			int count = 0;
			//Kiểm tra xem có cái nào cùng hướng va chạm mà thời gian thấp lớn hơn cái thời gian đang so sánh không?
			//Nếu có thì thay thế thời gian va chạm bằng thời gian mới
			for each (CollisionInfo item in _collidedInfoLst)
			{
				count++;
				if ((item._direction == normalX || item._direction == normalY)
					&& item._timeCollide>deltaTime)
				{
					item._timeCollide = deltaTime;
					break;
				}
			}
			//Nếu hướng va chạm là mới thì thêm vào _collidedInfoLst
			if (count == _collidedInfoLst.size())
			{
				_collidedInfoLst.push_back(CollisionInfo(gameObject, (normalX != CDirection::NONE_DIRECT) ? normalX : normalY, deltaTime));
			}
			//Sắp xếp tăng dần theo thời gian va chạm
			_collidedInfoLst.sort(CompareTimeCollide1);
		}
		break;
	case ID_BULLET_ROCKMAN_GUTS:
	case ID_BULLET_ROCKMAN_CUT:
	case ID_BULLET_ROCKMAN_BOOM:
	case ID_BULLET_ROCKMAN_NORMAL:
		if (normalX != CDirection::NONE_DIRECT 
			&& !_isHitDame)
		{
			_isHitDame = true;
			if (_state == ENEMYWORKER_STATE::ATTACK)
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
				if (_state == ENEMYWORKER_STATE::DEFENSE)
					ResourceManager::PlayASound(ID_EFFECT_BULLET_HIT_ENEMY_WITH_SHIELD);
		}
		break;
	}
}

CEnemyWorker* CEnemyWorker::ToValue()
{
	return new CEnemyWorker(*this);
}

vector<CBullet*> CEnemyWorker::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	return result;
}

void CEnemyWorker::ResetCollideVariable()
{
	_collidedInfoLst.clear();
}