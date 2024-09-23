#include "CGutsMan.h"

CGutsMan::CGutsMan() :CEnemy()
{
	
}

CGutsMan::~CGutsMan()
{
	SAFE_DELETE(_bullet);
	SAFE_DELETE(_bulletRockMan);

	this->_bullet = nullptr;
	this->_bulletRockMan = nullptr;
}

int CGutsMan::Initlize()
{
	this->_blood = BLOOD_GUTSMAN;
	this->_id = ID_GUTSMAN;
	this->_isFire = false;
	this->_isJump = false;
	this->_speed = 2.0f;
	this->_spriteStatus = ID_SPRITE_GUSTMAN_STAND;
	this->_currentDirec = DIRECTIONACTION::STANDLEFT;
	this->_previousDirec = this->_currentDirec;
	this->_sprite = ResourceManager::GetSprite(this->_spriteStatus);
	this->_v = Vector2(-50.0f / 1000.0f , 0.0f / 1000.0f); // đơn vị pixel / tick
	this->_gravity = -GRAVITY * 1000.0f; // pixel / tick
	this->_dieDistance = 50.0f / 1000.0f;
	this->_positionOld = Vector2(0,0);
	this->_timeDelay = 0; // tick
	this->_score = 5000;

	this->_isStartJump = false;
	this->_isLockRun = true;
	this->_isCollideBullet = false;
	this->_isSkillJump = true;
	this->_isOneHit = true;

	this->_timeHistoryCollideX=std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideY=std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideXBullet=std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideYBullet=std::numeric_limits<float>::infinity();

	this->_collideNormalY = CDirection::NONE_DIRECT;
	this->_collideNormalX = CDirection::NONE_DIRECT;

	this->_collideNormalXBullet = CDirection::NONE_DIRECT;
	this->_collideNormalYBullet = CDirection::NONE_DIRECT;

	this->_bulletRockMan = nullptr;
	this->_timeEffectCollide = 600.0f; // thời gian xãy ra vụ nổ chết

	//bullet
	Vector2 _positionBullet = Vector2(this->_position.x, this->_position.y + this->_sprite.GetFrameHeight() / 2 + 90.0f);
	this->_bullet = new CGutsManBullet(10, ID_GUTSMAN, ResourceManager::GetSprite(ID_SPRITE_GUSTMAN_ROCKFIRE)
		, DAME_BULLET_GUTSMAN, Vector2(0.0f / 1000.0f, 00.0f / 1000.0f), _positionBullet);

	return 1;
}

void CGutsMan::Render(CGameTime* gametime, CGraphics* graphics)
{
	switch (this->_currentDirec)
	{
	case DIRECTIONACTION::DIE:
		{			
			break;
		}
	default:
		if(this->_v.x > 0)
			graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true, SpriteEffects::FLIP_HORIZONTALLY);
		else
			graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true);

		//this->_bullet->Render(gametime, graphics);

		if(this->_isCollideBullet) // hiệu ứng trúng đạn
		{
			CSprite _spEffectCollideBullet = ResourceManager::GetSprite(ID_SPRITE_CUTMAN_COLLIDE);
			graphics->Draw(_spEffectCollideBullet.GetTexture(), _spEffectCollideBullet.GetDestinationRectangle(), this->_position, true);

			//tắt hiệu ứng khi bị chạm đạn của cut man
			this->_timeEffectCollide -= gametime->GetDeltaTime();
			if(this->_timeEffectCollide <= 0.0f)
			{
				this->_isCollideBullet = false;
				this->_timeEffectCollide = 600.0f;
			}
		}
		break;
	}
	CMoveableObject::Render(gametime, graphics);
}

void CGutsMan::Update(CGameTime* gameTime, CRockman* rockman)
{
	float t = gameTime->GetDeltaTime();
	float t2 = gameTime->GetDeltaTime();

	//các xử lý tien va chạm với đạn của rock man.
	if (_collideNormalXBullet != CDirection::NONE_DIRECT
		|| _collideNormalYBullet != CDirection::NONE_DIRECT)
	{
		// cut man bị trúng đạn ở phía trên hoặc dưới
		if(this->_collideNormalXBullet == CDirection::ON_LEFT 
			|| this->_collideNormalXBullet == CDirection::ON_RIGHT 
			|| this->_collideNormalYBullet == CDirection::ON_UP 
			|| this->_collideNormalYBullet == CDirection::ON_DOWN
			|| this->_collideNormalYBullet == CDirection::INSIDE 
			|| this->_collideNormalXBullet == CDirection::INSIDE
			)
		{
			if(this->_bulletRockMan != nullptr  && this->_isOneHit)
			{
				// giảm máu cut man
				this->_blood -= this->_bulletRockMan->GetDame();

				if (this->_blood <= 0.0f) // hết máu bật hiệu ứng díe
				{
					Asset::GetInstance()->__is_require_shake_screen = false;
					_currentDirec = DIRECTIONACTION::DIE;
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

	//các xử lý tien va chạm.
	if (_collideNormalX != CDirection::NONE_DIRECT
		|| _collideNormalY != CDirection::NONE_DIRECT)
	{
		if (this->_collideNormalX == CDirection::ON_RIGHT && _timeHistoryCollideX <= 0.001f)
		{
			t = _timeHistoryCollideX;
			if(!this->_isStartJump && this->_isLockRun)
				this->_currentDirec = DIRECTIONACTION::DOWNRIGHT;
			this->_position.x += _v.x * t * _speed;

			this->_gravity = -50.0f/1000.0f;			
		}

		if (this->_collideNormalX == CDirection::ON_LEFT && _timeHistoryCollideX <= 0.001f)
		{
			t = _timeHistoryCollideX;			
			if(!this->_isStartJump && this->_isLockRun)
				this->_currentDirec = DIRECTIONACTION::DOWNLEFT;

			this->_position.x += _v.x * t * _speed;					
			this->_gravity = -50.0f/1000.0f;	
		}


		if(_collideNormalY == CDirection::ON_DOWN)
		{
			t2 = _timeHistoryCollideY;		

			if(this->_currentDirec == DIRECTIONACTION::DOWNRIGHT || this->_currentDirec == DIRECTIONACTION::DOWNLEFT)
			{
				// Khi chạm trái và còn chạm dưới thì ko dùng _gravity để kéo cutman xuống.
				if(this->_collideNormalX == CDirection::ON_RIGHT || this->_collideNormalX == CDirection::ON_LEFT)
				{			
					this->_gravity = 0.0f;
				}
				else
					this->_gravity = -9.8f/1000.0f;

				if(t2 <= 15.0f) // thời gian va chạm bé hơn 15 tich thì fix vị trí của boss xát nền
					this->_position.y += _v.y * t2 * _speed;

				if(this->_position.x - this->_posRockMan.x > 0 && t2==0.0f && this->_isLockRun)
				{
					this->_isLockRun = false;
					this->_isStartJump = true;
					this->_isJump = true;
					this->_currentDirec = DIRECTIONACTION::STANDLEFT;
					if(this->_v.x > 0)
						this->_v.x *= -1.0f;
				}
				else if(t2==0.0f && this->_isLockRun)
				{
					this->_isLockRun = false;
					this->_isStartJump = true;
					this->_isJump = true;
					this->_currentDirec = DIRECTIONACTION::STANDRIGHT;
					if(this->_v.x < 0)
						this->_v.x *= -1.0f;
				}	

			}

			if((this->_currentDirec == DIRECTIONACTION::JUMPLEFT || this->_currentDirec == DIRECTIONACTION::JUMPRIGHT))
			{

				this->_position.y += _v.y * t2 * _speed;						

				// Khi chạm trái và còn chạm dưới thì ko dùng _gravity để kéo cutman xuống.
				if(this->_collideNormalX == CDirection::ON_RIGHT || this->_collideNormalX == CDirection::ON_LEFT)
				{			
					this->_gravity = 0.0f;
				}
				else
					this->_gravity = -9.8f/1000.0f;

				if(this->_isStartJump == false)
				{	
					this->_isStartJump = true;
					this->_isJump = true;
					//xác định hướng cho cutman
					if(this->_position.x - this->_posRockMan.x > 0)
					{
						this->_currentDirec = DIRECTIONACTION::STANDLEFT;
						if(this->_v.x > 0)
							this->_v.x *= -1.0f;
					}
					else 
					{
						this->_currentDirec = DIRECTIONACTION::STANDRIGHT;
						if(this->_v.x < 0)
							this->_v.x *= -1.0f;
					}		

					//Xử lý va chạm rung đất.
					if (!this->_isSkillJump && !Asset::GetInstance()->__is_require_shake_screen)
					{
						Asset::GetInstance()->__is_require_shake_screen = true;
					}
				}

				
			}

			// Va chạm tạo góc trái và phải
			if(t == 0.0f && t2 == 0.0f && this->_collideNormalX == CDirection::ON_LEFT)
			{
				if(this->_v.x <= 0)
					this->_v.x *= -1;
			}
			else if(t == 0.0f && t2 == 0.0f && this->_collideNormalX == CDirection::ON_RIGHT)
			{
				if(this->_v.x >= 0)
					this->_v.x *= -1;
			}

		}	
	}

	this->_posRockMan = rockman->_position;

	//Lưu lại vị trí củ của Cut man khi nó đang đứng.(xet va cham)
	if(this->_currentDirec == DIRECTIONACTION::STANDLEFT || this->_currentDirec == DIRECTIONACTION::STANDRIGHT)
		this->_positionOld = this->_position;

	// Lưu lại spriteStatus vừa rồi, nếu khác thì mới chuyển sprite nếu không thì không chuyển sprite
	int previousSpriteID = this->_spriteStatus;


	//Di chuyển boss
	switch (this->_currentDirec)
	{
	case DIRECTIONACTION::DOWNLEFT:
	case DIRECTIONACTION::DOWNRIGHT:
		{
			this->_v.y = _gravity * gameTime->GetDeltaTime();
			this->_position.y += this->_v.y * _speed;
			break;
		}
	case DIRECTIONACTION::JUMPLEFT:
		{
			if(this->_isSkillJump)
				this->_position.x += _v.x * gameTime->GetDeltaTime() * this->_speed;

			this->_position.y += _v.y * gameTime->GetDeltaTime() * this->_speed;
			this->_isStartJump = false;
			this->_v.y += _gravity;
		}
		break;
	case DIRECTIONACTION::JUMPRIGHT:
		{
			if(this->_isSkillJump)
				this->_position.x += _v.x * gameTime->GetDeltaTime() * this->_speed;

			this->_position.y += _v.y * gameTime->GetDeltaTime() * this->_speed;
			this->_isStartJump = false;
			this->_v.y += _gravity;
		}
		break;
	case DIRECTIONACTION::STANDLEFT:
	case DIRECTIONACTION::STANDRIGHT:
		{
			this->_v.y =-100.0f / 1000.0f;
		}
		break;
	default:
		break;
	} 

	// Kiểm tra và thay đổi trạng thái của Cut man
	this->CheckStatus(gameTime);

	//Thay đổi sprite
	if (previousSpriteID != this->_spriteStatus)
		this->_sprite = ResourceManager::GetSprite(this->_spriteStatus);

	//aminition
	this->_sprite.Update(gameTime);

	//amination bullet
	//this->_bullet->Update(gameTime);		

	this->UpdateBox();

	_timeHistoryCollideX=std::numeric_limits<float>::infinity();
	_timeHistoryCollideY=std::numeric_limits<float>::infinity();
	_collideNormalX=_collideNormalY=CDirection::NONE_DIRECT;

	_timeHistoryCollideXBullet=std::numeric_limits<float>::infinity();
	_timeHistoryCollideYBullet=std::numeric_limits<float>::infinity();
	_collideNormalXBullet=_collideNormalYBullet=CDirection::NONE_DIRECT;
}

void CGutsMan::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	// Nếu va chạm với .......
	switch (gameObject->_typeID)
	{
	case ID_ROCK:
	case ID_BLOCK:
	case ID_ROCK_IN_GUT_STAGE:

		if(normalX == CDirection::ON_RIGHT||normalX==CDirection::ON_LEFT)
			if (_timeHistoryCollideX > deltaTime)
			{
				_timeHistoryCollideX = deltaTime;

				_collideNormalX = normalX;		
			}


			if(normalY == CDirection::ON_DOWN||normalY==CDirection::ON_UP)

				if (_timeHistoryCollideY > deltaTime)
				{
					_timeHistoryCollideY = deltaTime;
					_collideNormalY = normalY;		
				}

				break;
	case ID_ROCKMAN: // xử lý va chạm với rockman
		break;
	case ID_BULLET_ROCKMAN_NORMAL: case ID_BULLET_ROCKMAN_BOOM : case ID_BULLET_ROCKMAN_CUT : case ID_BULLET_ROCKMAN_GUTS:
		this->_bulletRockMan = (CBullet*)gameObject;

		if(normalX == CDirection::ON_RIGHT||normalX==CDirection::ON_LEFT)
			if (_timeHistoryCollideXBullet > deltaTime)
			{
				_timeHistoryCollideXBullet = deltaTime;
				_collideNormalXBullet = normalX;		
			}

			if(normalY == CDirection::ON_DOWN||normalY==CDirection::ON_UP)
				if (_timeHistoryCollideYBullet > deltaTime)
				{
					_timeHistoryCollideYBullet = deltaTime;
					_collideNormalYBullet = normalY;		
				}

					if(normalY == CDirection::INSIDE || normalX == CDirection::INSIDE)
						if (_timeHistoryCollideYBullet > deltaTime)
						{
							_timeHistoryCollideYBullet = deltaTime;
							_collideNormalYBullet = normalY;		
						}	
					break;
	default:	
		break;
	}	
}

void CGutsMan::CheckStatus(CGameTime* gameTime)
{
	if(this->_currentDirec == DIRECTIONACTION::DIE)
	{

		return;
	}

	if((this->_previousDirec == DIRECTIONACTION::JUMPLEFT && this->_v.y == -100.0f / 1000.0f) )
	{
		this->_currentDirec = DIRECTIONACTION::STANDRIGHT;		

		this->_spriteStatus = ID_SPRITE_GUSTMAN_STAND;

		this->_timeDelay = 0.0f;
		if(this->_v.x < 0)
			this->_v.x *= -1;

		this->_isJump = true;
		this->_isLockRun = true;
	}
	else if((this->_previousDirec == DIRECTIONACTION::JUMPRIGHT && this->_v.y == -100.0f / 1000.0f) )
	{

		this->_currentDirec = DIRECTIONACTION::STANDLEFT;

		this->_spriteStatus = ID_SPRITE_GUSTMAN_STAND;

		this->_timeDelay = 0.0f;

		if(this->_v.x > 0)
			this->_v.x *= -1;

		this->_isJump = true;
		this->_isLockRun = true;
	}
	else
	{			
		//sau khi nhảy dừng 1.5s sau đó hoạt động tiếp
		this->_timeDelay += gameTime->GetDeltaTime();

		if(this->_timeDelay >= 3100)
		{
			this->_timeDelay = 3100.0f;		
			//Jump			
			this->JumpAI();
			this->_isJump = false;
		}	
		else 
			if(this->_timeDelay >= 2000)
			{				
				srand (time(NULL));
				int r = rand() % 2 + 1;
				if(0 == 0)
				{	
					// lấy vị trí để bắn
					this->_bullet->_posGutsMan = this->_position;
					this->_bullet->_posRockMan = this->_posRockMan;

					if(this->_spriteStatus != ID_SPRITE_GUSTMAN_THROW)
					{
						this->_bullet->_isfire = true;
						this->_bullet->_position = Vector2(this->_position.x, this->_position.y + this->_sprite.GetFrameHeight() + 100.0f);
					}	
					this->_spriteStatus = ID_SPRITE_GUSTMAN_THROW;
				}
				else
				{
					this->_timeDelay = 3100.0f;
				}
			}
	}

	// Nếu boom man đang đứng thì kiểm tra hướng đứng(trái or phải)
	if(this->_currentDirec == DIRECTIONACTION::STANDLEFT && this->_position.x - this->_posRockMan.x < 0)
	{
		this->_currentDirec = DIRECTIONACTION::STANDRIGHT;
		if(this->_previousDirec != this->_currentDirec)
			this->_v.x *= -1;	
	}
	else if(this->_currentDirec == DIRECTIONACTION::STANDRIGHT && this->_position.x - this->_posRockMan.x > 0)
	{	
		this->_currentDirec = DIRECTIONACTION::STANDLEFT;
		if(this->_previousDirec != this->_currentDirec)
			if(this->_v.x > 0)
				this->_v.x *= -1;		
	}

	this->_previousDirec = this->_currentDirec;
}

void CGutsMan::JumpAI()
{
	this->_gravity = -9.8f/1000.0f;
	if(this->_v.x > 0)
	{
		this->_currentDirec = DIRECTIONACTION::JUMPRIGHT;
	}
	else
	{
		this->_currentDirec = DIRECTIONACTION::JUMPLEFT;
	}

	if( this->_currentDirec != this->_previousDirec || this->_isJump)
	{			
		srand (time(NULL));
		int r = rand() % 2 + 1;
		if(r % 2 == 0)
		{	
			this->_isSkillJump = false; // nhảy thẳng làm động đất			
		}
		else
			this->_isSkillJump = true; // nhảy cong

		Asset::GetInstance()->__is_require_shake_screen = false;
		this->_isJump = false;
		this->_isStartJump = true;
		//xét độ cao để nhảy.
		this->_v.y +=  200.0f/ (1000.0f);
		this->_spriteStatus = ID_SPRITE_GUSTMAN_STOMING;					

	}	
}

void CGutsMan::GetPositioRockMan(Vector2 pos)
{
	this->_posRockMan = pos;
}

void CGutsMan::UpdateBox()
{
	this->_box._width = 30.0f;
	this->_box._height = 30.0f;
	this->_box._x = this->_position.x - this->_box._width / 2;
	this->_box._y = this->_position.y + this->_box._height / 2;
	this->_box._vx = this->_v.x * _speed;
	this->_box._vy = this->_v.y * _speed;

}

vector<CBullet*> CGutsMan::Fire()
{
	vector<CBullet*> vbullet = vector<CBullet*>();

	if (this->_bullet->_isOneHitBullet)
	{
		vbullet.push_back(this->_bullet);
		this->_bullet->_isOneHitBullet = false;
		this->_bullet->SetStatus();
	}
	return vbullet;
}

CGutsMan* CGutsMan::ToValue()
{
	return new CGutsMan(*this);
}
