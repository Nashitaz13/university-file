#include "CEnemyRobot.h"

//So sánh thời gian va chạm của hai biến CollisionInfo. Trả về True nếu first<second và ngược lại
bool CompareTimeCollide(const CollisionInfo& first, const CollisionInfo& second)
{
	return (first._timeCollide < second._timeCollide);
}

CEnemyRobot::CEnemyRobot(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, Vector2 positionBegin, int dame, int blood, int score) : CEnemy()
{
	_id = id;
	_typeID = typeID;
	_sprite = sprite;
	_v = Vector2(0,0);
	_dame = dame;
	_position = positionBegin;
	_pyOriginal = positionBegin.y;
	_blood = blood;
	_score = score;
	_isHitDame = false;

	_spriteExplodingEffect = spriteExplodingEffect;
}

CEnemyRobot::~CEnemyRobot()
{
}

int CEnemyRobot::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	_state = ENEMYROBOT_STATE::JUMPING;

	this->ResetCollideVariable();
	this->UpdateBox();
	return 1;
}

void CEnemyRobot::Update(CGameTime* gameTime, CRockman* rockman)
{
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
			//Set vị trí của EnemyRobot về vị trí bắt đầu xảy ra va chạm
			_position.y += (item._timeCollide*_v.y);// -0.5f*GRAVITY*pow(_minCollideDeltaTime, 2));
			_v.y = 0 - GRAVITY*gameTime->GetDeltaTime();//Dừng chuyển động chiều y đi lên (dọc) của EnemyRobot bằng cách set v.y < 0
			break;

		case CDirection::ON_DOWN:
			if (_state == ENEMYROBOT_STATE::JUMPING)
			{
				//Set vị trí của EnemyRobot về vị trí bắt đầu xảy ra va chạm
				_position.y += (item._timeCollide*_v.y);// -0.5f*GRAVITY*pow(_minCollideDeltaTime, 2));
				//Chuyển trạng thái của EnemyRobot thành đứng
				_state = ENEMYROBOT_STATE::STANDING;
				_v = Vector2(0, 0);
				_timeStandingRemain = TIME_STANDING_OF_ROBOT_ENEMY;
				ResourceManager::PlayASound(ID_EFFECT_BIG_ROBOT_ON_LAND);
			}
			break;
		}
	}
	
#pragma endregion

	if (_state == ENEMYROBOT_STATE::STANDING)
	{
		if (_timeStandingRemain > 0)//Còn trong thời gian đứng nghỉ (không nhảy)
		{
			_timeStandingRemain -= gameTime->GetDeltaTime();
			_sprite.SetIndex(0);
		}
		else//Vừa hết trạng thái nghỉ
		{
			//Xét dấu cho Vector vận tốc X (đi sang phải hay sang trái)
			if ((rockman->_position.x - this->_position.x) > 0)//Nếu EnemyRobot nằm phía bên trái Rockman
				_v.x = 1;
			else//Nếu EnemyRobot nằm phía bên phải Rockman
				_v.x = -1;
			//-----Tính toán lực sẽ cấp cho EnemyRobot để nhảy-----
			//Áp dụng công thức Lmax=(v0^2*Sin2@)/g trong chuyển động ném xiên để tính vận tốc bắt đầu chuyển động của EnemyRobot
			float v0 = sqrt(SPACE_X_JUMP_OF_ROBOT_ENEMY * GRAVITY / sinf(2 * ANGLE_OF_JUMP_OF_ROBOT_ENEMY));
			
			for each (CollisionInfo item in _collidedInfoLst)
			{
				switch (item._direction)
				{
				case CDirection::ON_LEFT:
					if (_v.x < 0)
					{
						_v.x = 0;
						goto continues;
					}
					break; 
				case CDirection::ON_RIGHT:
					if (_v.x > 0)
					{
						_v.x = 0;
						goto continues;
					}
					break;
				}
			}
			
			_v.x = abs(v0*cosf(ANGLE_OF_JUMP_OF_ROBOT_ENEMY)) * (abs(_v.x) / _v.x);
			
			continues:
			float lowRand = 1.3, highRand = 2.0;//Biến max, min Random để chọn giá trị nhân vận tốc _v.y lên
			float r3 = lowRand + static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / (highRand - lowRand)));
			_v.y = v0*sinf(ANGLE_OF_JUMP_OF_ROBOT_ENEMY) * ((r3<1.68)?1.4:2);// -GRAVITY*gameTime->GetDeltaTime();//Chỗ này không hiểu từ phần "-GRAVITY*gameTime->GetDeltaTime()" để làm gì nên tạm thời khóa lại không sử dụng nữa.

			//Chuyển trạng thái của Enemy
			_state = ENEMYROBOT_STATE::JUMPING;
			
		}
	}
	this->ResetCollideVariable();

	if (_state == ENEMYROBOT_STATE::JUMPING)// Nếu đang ở trên không trung thì thực hiện tiếp quỹ đạo của vật ném xiên
	{
		_sprite.SetIndex(1);
		Jump(gameTime->GetDeltaTime()*1);//Nhân 2 là để cho EnemyRobot di chuyển nhanh hơn trên quỹ đạo ném xiên
	}

	if (_v.x < 0)
		_spriteEffect = SpriteEffects::NONE;
	else
		if (_v.x > 0)
			_spriteEffect = SpriteEffects::FLIP_HORIZONTALLY;

	_isHitDame = false;
	this->UpdateBox();
}

void CEnemyRobot::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, _spriteEffect);

	CGameObject::Render(gameTime, graphics);
	CMoveableObject::Render(gameTime, graphics);
}

void CEnemyRobot::UpdateBox()
{
	if (_state == ENEMYROBOT_STATE::JUMPING)
	{
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight();
	}
	else
	{
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 4 + 5;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = 3 * _sprite.GetFrameHeight()/4 + 5;
	}
}

void CEnemyRobot::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
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
			_collidedInfoLst.sort(CompareTimeCollide);
		}
		break;
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

CEnemyRobot* CEnemyRobot::ToValue()
{
	return new CEnemyRobot(*this);
}

void CEnemyRobot::Jump(float deltaTime)
{
	_position.x += deltaTime*_v.x;
	_position.y += (deltaTime*_v.y);// -0.5f*GRAVITY*pow(deltaTime, 2));

	_v.y -= GRAVITY*deltaTime * 4;
}

void CEnemyRobot::ResetCollideVariable()
{
	_collidedInfoLst.clear();
}