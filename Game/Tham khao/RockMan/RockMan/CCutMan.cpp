#include "CCutman.h"

CCutman::CCutman() :CEnemy()
{
}

CCutman::~CCutman()
{
	SAFE_DELETE(_bullet);
	SAFE_DELETE(_bulletRockMan);

	this->_bullet = nullptr;
	this->_bulletRockMan = nullptr;
}

int CCutman::Initlize()
{
	this->_dame = DAME_BULLET_CUTMAN;
	this->_blood = BLOOD_CUTMAN;
	this->_id = ID_CUTMAN;
	this->_speed = 1.5f;
	this->_isFire = false;
	this->_isWaepon = true;
	this->_isFixPosition = false;
	this->_spriteStatus = ID_SPRITE_CUTMAN_STAND0;
	this->_currentDirec = DIRECTIONACTION::START;
	this->_previousDirec = this->_currentDirec;
	this->_sprite = ResourceManager::GetSprite(this->_spriteStatus);
	this->_v = Vector2(-80.0f / 1000.0f, -100.0f / 1000.0f); // đơn vị pixel / tick
	this->_gravity = -9.8 / 1000.0f; // pixel / tick
	this->_positionOld = this->_position;
	this->_timeDelay = 0; // tick
	this->_timeStart = 0.0f;
	this->_isRandom = false;
	float _dieDistance = 50.0f / 1000.0f;
	this->_score = 5000;
	

	this->_timeHistoryCollideX = std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideY = std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideXBullet = std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideYBullet = std::numeric_limits<float>::infinity();

	this->_isRun = true;
	this->_isStartJump = false;
	this->_isLockRun = true;
	this->_isCollideBullet = false;
	this->_isOneHit = true;

	this->_collideNormalY = CDirection::NONE_DIRECT;
	this->_collideNormalX = CDirection::NONE_DIRECT;

	this->_collideNormalXBullet = CDirection::NONE_DIRECT;
	this->_collideNormalYBullet = CDirection::NONE_DIRECT;

	this->_bulletRockMan = nullptr;
	this->_timeEffectCollide = 600.0f;

	//bullet
	Vector2 _positionBullet = Vector2(this->_position.x, this->_position.y + this->_sprite.GetFrameHeight() / 2);
	this->_bullet = new CCutManBullet(10, ID_BULLET_CUTMAN, ResourceManager::GetSprite(ID_SPRITE_BULLET_CUT)
		, DAME_BULLET_CUTMAN, Vector2(0.0f / 1000.0f, 00.0f / 1000.0f), _positionBullet);

	

	return 1;
}

void CCutman::Render(CGameTime* gametime, CGraphics* graphics)
{
	switch (this->_currentDirec)
	{
	case DIRECTIONACTION::DIE:
	{
								 break;
	}
	default:

		if (this->_v.x > 0)
			graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true, SpriteEffects::FLIP_HORIZONTALLY);
		else
			graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true);

		if (this->_isFire)
			this->_bullet->Render(gametime, graphics);

		if (this->_isCollideBullet) // hiệu ứng trúng đạn
		{
			CSprite _spEffectCollideBullet = ResourceManager::GetSprite(ID_SPRITE_CUTMAN_COLLIDE);
			graphics->Draw(_spEffectCollideBullet.GetTexture(), _spEffectCollideBullet.GetDestinationRectangle(), this->_position, true);

			//tắt hiệu ứng khi bị chạm đạn của cut man
			this->_timeEffectCollide -= gametime->GetDeltaTime();
			if (this->_timeEffectCollide <= 0.0f)
			{
				this->_isCollideBullet = false;
				this->_timeEffectCollide = 600.0f;
			}
		}
		break;
	}

	string str;
	Rect rect;
	str.append(checkCon);
	rect.left = 100;
	rect.top = 100;
	rect.right = rect.left + 1000.0f;
	rect.bottom = rect.top + 1000.0f;

	graphics->DrawString(str, rect, D3DCOLOR_XRGB(255, 255, 255), Vector2(1.0f, 1.0f), false);
	CMoveableObject::Render(gametime, graphics);
}

void CCutman::Update(CGameTime* gameTime, CRockman* rockman)
{
	bool prevIsPosition = this->_isFixPosition;
	float t = gameTime->GetDeltaTime();
	float t2 = gameTime->GetDeltaTime();

	//các xử lý tien va chạm với đạn của rock man.
	if (_collideNormalXBullet != CDirection::NONE_DIRECT
		|| _collideNormalYBullet != CDirection::NONE_DIRECT)
	{
		// cut man bị trúng đạn ở phía trên hoặc dưới
		if (this->_collideNormalXBullet == CDirection::ON_LEFT
			|| this->_collideNormalXBullet == CDirection::ON_RIGHT
			|| this->_collideNormalYBullet == CDirection::ON_UP
			|| this->_collideNormalYBullet == CDirection::ON_DOWN
			|| this->_collideNormalYBullet == CDirection::INSIDE
			|| this->_collideNormalXBullet == CDirection::INSIDE
			)
		{
			if (this->_bulletRockMan != nullptr && this->_isOneHit)
			{
				// giảm máu cut man
				this->_blood -= this->_bulletRockMan->GetDame();

				if (this->_blood <= 0.0f) // hết máu bật hiệu ứng díe
				{
					_currentDirec = DIRECTIONACTION::DIE;
					this->_bullet->Hide();
				}


				// bất hiệu ứng chạm đạn.
				this->_isCollideBullet = true;
				this->_bulletRockMan = nullptr;
				this->_isOneHit = false;
			}
		}
	}
	else
		this->_isOneHit = true;

	//các xử lý tien va chạm với tường.
	if (_collideNormalX != CDirection::NONE_DIRECT
		|| _collideNormalY != CDirection::NONE_DIRECT)
	{
		if (this->_collideNormalX == CDirection::ON_RIGHT)
		{
			t = _timeHistoryCollideX;
			if (!this->_isStartJump)
				this->_currentDirec = DIRECTIONACTION::DOWNLEFT;
			this->_position.x += _v.x * t * _speed;

			if (this->_v.x > 0)
			{
				this->_isLockRun = true;
			}
			else
				this->_v.x = -0.07f;
			this->_gravity += -9.0f / 1000.0f;
			this->_isLockRun = true;
		}

		if (this->_collideNormalX == CDirection::ON_LEFT)
		{
			t = _timeHistoryCollideX;
			if (!this->_isStartJump)
				this->_currentDirec = DIRECTIONACTION::DOWNLEFT;
			this->_position.x += _v.x * t * _speed;
			if (this->_v.x > 0)
			{
				this->_isLockRun = true;
			}
			else
			{
				this->_v.x = -0.06f;
				this->_isLockRun = false;
				this->_gravity += -12.5f / 1000.0f;
			}
			// va chạm trái sẽ ko làm gì cả, đứng đó ném kéo.
		}


		if (_collideNormalY == CDirection::ON_DOWN)
		{
			t2 = _timeHistoryCollideY;
			this->_position.y += _v.y * t2 * _speed;

			//Cut man ở vị trí cao hơn thì cho cut man nhảy.
			if (this->_position.y - this->_posRockMan.y >= 10.0f)
			{
				this->_isRun = false;
			}
			else
			{
				this->_isRun = true;
			}

			if ((this->_currentDirec == DIRECTIONACTION::JUMPLEFT || this->_currentDirec == DIRECTIONACTION::JUMPRIGHT) || (this->_currentDirec == DIRECTIONACTION::DOWNRIGHT || this->_currentDirec == DIRECTIONACTION::DOWNLEFT))
			{

				// Khi chạm trái và còn chạm dưới thì ko dùng _gravity để kéo cutman xuống.
				if (this->_collideNormalX == CDirection::ON_RIGHT || this->_collideNormalX == CDirection::ON_LEFT)
					this->_gravity = 0.0f;
				else
					this->_gravity = -9.8f / 1000.0f;

				if (this->_isStartJump == false || !this->_isLockRun)
				{

					//xác định hướng cho cutman
					if (this->_position.x - this->_posRockMan.x > 0)
					{
						this->_currentDirec = DIRECTIONACTION::STANDLEFT;
						if (this->_v.x > 0)
							this->_v.x *= -1.0f;
					}
					else
					{
						this->_currentDirec = DIRECTIONACTION::STANDRIGHT;
						if (this->_v.x < 0)
							this->_v.x *= -1.0f;
					}
				}


			}
		}
	}

	//Xữ lý hiệu ứng start boss cut	
	if (this->_timeStart >= 1000.0f && this->_currentDirec == DIRECTIONACTION::START)
	{
		this->_currentDirec = DIRECTIONACTION::STANDLEFT;
	}
	else
	{
		if (this->_timeStart < 1000.0f)
			this->_timeStart += gameTime->GetDeltaTime();
	}

	// reset lại không khóa nửa
	this->_isLockRun = true;

	this->_posRockMan = rockman->_position;

	// Lưu lại spriteStatus vừa rồi, nếu khác thì mới chuyển sprite nếu không thì không chuyển sprite
	int previousSpriteID = this->_spriteStatus;

	if (!this->_isFire && this->_spriteStatus == ID_SPRITE_CUTMAN_FIRE0 && this->_sprite.GetIndex() == 1) // không bắn thì mới lấy vị trí
	{

		this->_bullet->_posCutMan = this->_position;
		this->_bullet->_posRockMan = rockman->_position;
		this->_bullet->_position = Vector2(this->_position.x, this->_position.y + this->_sprite.GetFrameHeight() / 2); // lấy lại vị trí của đạn								

		this->_sprite.Reset();
		this->_sprite.SetIndex(1);
		this->_isFire = true;
		this->_bullet->_isHide = true;
	}

	// lấy vị trí để đạn chuyển động ngược
	if (_bullet->_isReverse)
	{
		this->_bullet->_posCutMan = this->_position;
		this->_bullet->_posRockMan = _bullet->_posCutMan;
	}

	//Kiểm tra va chạm giửa đạn và cut man
	if (this->_bullet->_isReverse && this->_bullet->_spBulletAndCutMan <= 15)
	{
		this->_bullet->Hide();
		this->_isFire = false;
		this->_isWaepon = true;

		switch (this->_currentDirec)
		{
		case DIRECTIONACTION::JUMPRIGHT:
		case DIRECTIONACTION::JUMPLEFT:
		{
										  this->_spriteStatus = ID_SPRITE_CUTMAN_JUMP0;
										  this->_isFixPosition = false;
										  break;
		}

		case DIRECTIONACTION::RUNLEFT:
		case DIRECTIONACTION::RUNRIGHT:
		{
										  this->_spriteStatus = ID_SPRITE_CUTMAN_RUN0;
										  this->_isFixPosition = false;
										  break;
		}

		case DIRECTIONACTION::STANDLEFT:
		case DIRECTIONACTION::STANDRIGHT:
		{
											this->_spriteStatus = ID_SPRITE_CUTMAN_STAND0;
											this->_position.y += 4;// fix tâm của hình
											break;
		}
		}
	}

	//Di chuyển boss
	switch (this->_currentDirec)
	{
	case DIRECTIONACTION::RUNLEFT:
	{
									 this->_v.x = -0.09f;
									 this->_position.x += this->_v.x * gameTime->GetDeltaTime() * _speed;
	}
		break;
	case DIRECTIONACTION::RUNRIGHT:
	{
									  this->_v.x = 0.09f;

									  this->_position.x += this->_v.x * gameTime->GetDeltaTime() * _speed;
	}
		break;
	case DIRECTIONACTION::JUMPLEFT:
	{
									  this->_position.x += _v.x * gameTime->GetDeltaTime();
									  this->_position.y += _v.y * gameTime->GetDeltaTime() * _speed;
									  this->_v.y += _gravity;
									  this->_isStartJump = false;
	}
		break;
	case DIRECTIONACTION::JUMPRIGHT:
	{
									   this->_position.x += _v.x * gameTime->GetDeltaTime();
									   this->_position.y += _v.y * gameTime->GetDeltaTime() * _speed;
									   this->_v.y += _gravity;
									   this->_isStartJump = false;
	}
		break;
	case DIRECTIONACTION::DOWNRIGHT:
	case DIRECTIONACTION::DOWNLEFT:
	{
									  this->_v.y = _gravity*gameTime->GetDeltaTime();
									  this->_position.y += this->_v.y * _speed;
									  break;
	}
	case DIRECTIONACTION::STANDLEFT:
	case DIRECTIONACTION::STANDRIGHT:
	{
										this->_v.y = -100.0f / 1000.0f;
	}
		break;
	default:
		break;
	}

	// Kiểm tra và thay đổi trạng thái của Cut man
	if (this->_currentDirec != DIRECTIONACTION::START)
		this->CheckStatus(gameTime);

	//Thay đổi sprite
	if (previousSpriteID != this->_spriteStatus)
		this->_sprite = ResourceManager::GetSprite(this->_spriteStatus);

	//aminition
	this->_sprite.Update(gameTime);

	//amination bullet
	if (this->_isFire && this->_currentDirec != DIRECTIONACTION::START)
	{
		this->_bullet->Update(gameTime);
	}


	////Kiểm tra và fix tâm hình.
	if (prevIsPosition != _isFixPosition && _isFixPosition == true)
	{
		this->_position.y -= 4;// fix tâm của hình
	}
	else if (prevIsPosition != _isFixPosition && _isFixPosition == false)
	{
		this->_position.y += 4;// fix tâm của hình
	}

	this->UpdateBox();

	_timeHistoryCollideX = std::numeric_limits<float>::infinity();
	_timeHistoryCollideY = std::numeric_limits<float>::infinity();
	_collideNormalX = _collideNormalY = CDirection::NONE_DIRECT;

	_timeHistoryCollideXBullet = std::numeric_limits<float>::infinity();
	_timeHistoryCollideYBullet = std::numeric_limits<float>::infinity();
	_collideNormalXBullet = _collideNormalYBullet = CDirection::NONE_DIRECT;

}

void CCutman::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	// Nếu va chạm với .......
	switch (gameObject->_typeID)
	{
	case ID_ROCK:
	case ID_BLOCK:
	case ID_DOOR2_CUTMAN:

	{
					 if (normalX == CDirection::ON_RIGHT || normalX == CDirection::ON_LEFT)
					 if (_timeHistoryCollideX > deltaTime)
					 {
						 _timeHistoryCollideX = deltaTime;

						 _collideNormalX = normalX;
					 }


					 if (normalY == CDirection::ON_DOWN || normalY == CDirection::ON_UP)

					 if (_timeHistoryCollideY > deltaTime)
					 {
						 _timeHistoryCollideY = deltaTime;
						 _collideNormalY = normalY;
					 }

					 break;
	}	
	case ID_ROCKMAN: // xử lý va chạm với rockman
		break;
	case ID_BULLET_ROCKMAN_NORMAL: case ID_BULLET_ROCKMAN_BOOM: case ID_BULLET_ROCKMAN_CUT: case ID_BULLET_ROCKMAN_GUTS:
	{
					this->_bulletRockMan = (CBullet*)gameObject;

									 if (normalX == CDirection::ON_RIGHT || normalX == CDirection::ON_LEFT)
									   if (_timeHistoryCollideXBullet > deltaTime)
									   {
										   _timeHistoryCollideXBullet = deltaTime;
										   _collideNormalXBullet = normalX;
									   }

									   if (normalY == CDirection::ON_DOWN || normalY == CDirection::ON_UP)
									   if (_timeHistoryCollideYBullet > deltaTime)
									   {
										   _timeHistoryCollideYBullet = deltaTime;
										   _collideNormalYBullet = normalY;
									   }


									   if (normalY == CDirection::INSIDE || normalX == CDirection::INSIDE)
									   if (_timeHistoryCollideYBullet > deltaTime)
									   {
										   _timeHistoryCollideYBullet = deltaTime;
										   _collideNormalYBullet = normalY;
									   }

									   break;
	}
	default:
		break;
	}
}

void CCutman::CheckStatus(CGameTime* gameTime)
{

	if (this->_currentDirec == DIRECTIONACTION::DIE)
	{
		return;
	}

	if (this->_currentDirec == DIRECTIONACTION::DOWNLEFT || this->_currentDirec == DIRECTIONACTION::DOWNRIGHT)
		return;

	if ((this->_previousDirec == DIRECTIONACTION::JUMPLEFT && this->_v.y == -100.0f / 1000.0f))
	{
		this->_currentDirec = DIRECTIONACTION::STANDRIGHT;

		if (this->_isWaepon)
		{
			this->_isFixPosition = false;
			this->_spriteStatus = ID_SPRITE_CUTMAN_STAND0;
		}
		else
		{
			this->_spriteStatus = ID_SPRITE_CUTMAN_STAND1;
			this->_isFixPosition = true;
		}

		this->_timeDelay = 0.0f;
		if (this->_v.x < 0)
			this->_v.x *= -1;
	}
	else if ((this->_previousDirec == DIRECTIONACTION::JUMPRIGHT && this->_v.y == -100.0f / 1000.0f))
	{
		this->_currentDirec = DIRECTIONACTION::STANDLEFT;

		if (this->_isWaepon)
		{
			this->_isFixPosition = false;
			this->_spriteStatus = ID_SPRITE_CUTMAN_STAND0;
		}
		else
		{
			this->_spriteStatus = ID_SPRITE_CUTMAN_STAND1;
			this->_isFixPosition = true;
		}

		this->_timeDelay = 0.0f;

		if (this->_v.x > 0)
			this->_v.x *= -1;
	}
	else
	{
		//sau khi nhảy dừng 3.1s sau đó hoạt động tiếp
		this->_timeDelay += gameTime->GetDeltaTime();

		if (this->_timeDelay >= 1200)
		{
			this->_timeDelay = 1200.0f;
			if (!this->_isFire && !this->_isWaepon)
			{
				// nếu chưa bắn thì không làm gì cả.
			}
			else if (this->_isRun && abs(this->_posRockMan.x - this->_position.x) > RANK_CUTMAN && this->_v.y == -100.0f / 1000.0f)// điều kiện là nhảy phải xa hơn rank quy định
			{
				//Run				
				this->RunAI();

				if (this->_v.x > 0)// đang ở góc trái mà rock man ở bên phải thì cho phép nhảy,
					//ngược lại nếu rock man ở bên trái thì cho phép đứng tại chổ bắn.
				{
					this->_gravity = -9.8f / 1000.0f;
					this->JumpAI();
				}
				else
					// cut man khi đang nằm trong góc phải thì bắn.
				if (_collideNormalX == CDirection::ON_RIGHT && _collideNormalY == CDirection::ON_DOWN)
				{
					if (this->_v.x < 0)// đang ở góc phải mà rock man ở bên trái thì cho phép nhảy,
						//ngược lại nếu rock man ở bên trái thì cho phép đứng tại chổ bắn.
					{
						this->_gravity = -9.8f / 1000.0f;
						this->JumpAI();
					}

					if (this->_timeDelay >= 1000 && !this->_isFire && this->_isWaepon)
					{
						//bắn
						this->_spriteStatus = ID_SPRITE_CUTMAN_FIRE0;
						this->_isWaepon = false;
						this->_isFire = false;
					}
					else
					{
						if (this->_sprite.GetIndex() == 1 && this->_spriteStatus == ID_SPRITE_CUTMAN_FIRE0)
						{
							this->_spriteStatus = ID_SPRITE_CUTMAN_STAND1;
							this->_position.y -= 4;// fix tâm của hình
						}
					}
				}
			}
			else
			{
				//Jump
				// cut man khi đang nằm trong góc trái thì không làm gì cả.
				if (_collideNormalX == CDirection::ON_LEFT && _collideNormalY == CDirection::ON_DOWN)
				{

					if (this->_timeDelay >= 1000 && !this->_isFire && this->_isWaepon)
					{
						//bắn
						this->_spriteStatus = ID_SPRITE_CUTMAN_FIRE0;
						this->_isWaepon = false;
						this->_isFire = false;
					}
					else
					{
						if (this->_sprite.GetIndex() == 1 && this->_spriteStatus == ID_SPRITE_CUTMAN_FIRE0)
						{
							this->_spriteStatus = ID_SPRITE_CUTMAN_STAND1;
							this->_position.y -= 4;// fix tâm của hình
						}
					}
				}
				else
				{
					this->_gravity = -9.8f / 1000.0f;
					this->JumpAI();
				}
			}

		}
		else
		if (this->_timeDelay >= 1000)
		{
			this->_spriteStatus = ID_SPRITE_CUTMAN_FIRE0;
			this->_isWaepon = false;
			this->_isFire = false;
			this->_isFixPosition = false;
		}
	}


	// Nếu boom man đang đứng thì kiểm tra hướng đứng(trái or phải)
	if (this->_currentDirec == DIRECTIONACTION::STANDLEFT && this->_position.x - this->_posRockMan.x < 0)
	{
		this->_currentDirec = DIRECTIONACTION::STANDRIGHT;
		if (this->_previousDirec != this->_currentDirec)
		if (this->_v.x < 0)
			this->_v.x *= -1;
	}
	else if (this->_currentDirec == DIRECTIONACTION::STANDRIGHT && this->_position.x - this->_posRockMan.x > 0)
	{
		this->_currentDirec = DIRECTIONACTION::STANDLEFT;
		if (this->_previousDirec != this->_currentDirec)
		if (this->_v.x > 0)
			this->_v.x *= -1;
	}

	this->_previousDirec = this->_currentDirec;

}

void CCutman::RunAI()
{
	if (this->_posRockMan.x < this->_position.x)
	{
		//cut man khi đang nằm trong góc trái thì không làm gì cả.
		if (_collideNormalX == CDirection::ON_LEFT && _collideNormalY == CDirection::ON_DOWN)
		{
			return;
		}

		//cut man khi đang nằm trong góc trái thì không làm gì cả.
		if (_collideNormalX == CDirection::ON_RIGHT && _collideNormalY == CDirection::ON_DOWN)
		{
			return;
		}

		this->_currentDirec = DIRECTIONACTION::RUNLEFT;
		if (this->_currentDirec != this->_previousDirec)
		{
			if (this->_v.x > 0)
				this->_v.x *= -1;
			if (this->_isWaepon)
			{
				this->_spriteStatus = ID_SPRITE_CUTMAN_RUN0;
				this->_isFixPosition = false;
			}
			else
			{
				this->_spriteStatus = ID_SPRITE_CUTMAN_RUN1;
				this->_isFixPosition = true;
			}
		}
	}
	else if (this->_posRockMan.x > this->_position.x)
	{
		this->_currentDirec = DIRECTIONACTION::RUNRIGHT;
		if (this->_currentDirec != this->_previousDirec)
		{
			this->_v.x = abs(_v.x);
			if (this->_isWaepon)
			{
				this->_isFixPosition = false;
				this->_spriteStatus = ID_SPRITE_CUTMAN_RUN0;
			}
			else
			{
				this->_spriteStatus = ID_SPRITE_CUTMAN_RUN1;
				this->_isFixPosition = true;
			}
		}
	}
}

void CCutman::JumpAI()
{
	if (this->_v.x > 0)
	{
		this->_currentDirec = DIRECTIONACTION::JUMPRIGHT;
	}
	else
	{
		this->_currentDirec = DIRECTIONACTION::JUMPLEFT;
	}

	if (this->_currentDirec != this->_previousDirec)
	{
		this->_isStartJump = true;
		//xét độ cao để nhảy.
		this->_v.y += JUMP_HEIGHT / (1000.0f);

		if (this->_isWaepon)
		{
			this->_spriteStatus = ID_SPRITE_CUTMAN_JUMP0;
			this->_isFixPosition = false;
		}
		else
		{
			this->_isFixPosition = true;
			this->_spriteStatus = ID_SPRITE_CUTMAN_JUMP1;
		}
	}
}

void CCutman::GetPositioRockMan(Vector2 pos)
{
	this->_posRockMan = pos;
}

void CCutman::UpdateBox()
{
	if (_currentDirec == DIRECTIONACTION::STANDLEFT)
	{
		int xoo = 0;
	}
	switch (this->_spriteStatus)
	{

	case ID_SPRITE_CUTMAN_RUN1:
		this->_box._width = 25.0f;
		this->_box._height = 26.0f;
		this->_box._x = this->_position.x - this->_box._width / 2;
		this->_box._y = this->_position.y + this->_box._height / 2 - 4.0f + 4.0f;
		this->_box._vx = this->_v.x * _speed;
		this->_box._vy = this->_v.y * _speed;
		break;
	case ID_SPRITE_CUTMAN_JUMP0:
	case ID_SPRITE_CUTMAN_RUN0:
	case ID_SPRITE_CUTMAN_STAND0:
		this->_box._width = 25.0f;
		this->_box._height = 26.0f;
		this->_box._x = this->_position.x - this->_box._width / 2;
		this->_box._y = this->_position.y + this->_box._height / 2 - 4.0f;
		this->_box._vx = this->_v.x * _speed;
		this->_box._vy = this->_v.y * _speed;
		break;
	case ID_SPRITE_CUTMAN_JUMP1:
		this->_box._width = 25.0f;
		this->_box._height = 26.0f;
		this->_box._x = this->_position.x - this->_box._width / 2;
		this->_box._y = this->_position.y + this->_box._height / 2 - 4.0f;
		this->_box._vx = this->_v.x * _speed;
		this->_box._vy = this->_v.y * _speed;
		break;
	case ID_SPRITE_CUTMAN_STAND1:
		this->_box._width = 25.0f;
		this->_box._height = 26.0f;
		this->_box._x = this->_position.x - this->_box._width / 2;
		this->_box._y = this->_position.y + this->_box._height / 2;

		this->_box._vx = this->_v.x * _speed;
		this->_box._vy = this->_v.y * _speed;
		break;
	case ID_SPRITE_CUTMAN_FIRE0:
		this->_box._width = 25.0f;
		this->_box._height = 26.0f;
		this->_box._x = this->_position.x - this->_box._width / 2;
		this->_box._y = this->_position.y + this->_box._height / 2 - 4.0f;
		this->_box._vx = this->_v.x * _speed;
		this->_box._vy = this->_v.y * _speed;
		break;
	}
}

vector<CBullet*> CCutman::Fire()
{
	vector<CBullet*> vBullet = vector<CBullet*>();
	vBullet.push_back(this->_bullet);
	return vBullet;
}

CCutman* CCutman::ToValue()
{
	return new CCutman(*this);
}