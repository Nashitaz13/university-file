#include "CBoomMan.h"

CBoomMan::CBoomMan() : CEnemy()
{

}

CBoomMan::~CBoomMan()
{
	SAFE_DELETE(_bullet);
	SAFE_DELETE(_bulletRockMan);

	this->_bullet = nullptr;
	this->_bulletRockMan = nullptr;
}

int CBoomMan::Initlize()
{
	this->_blood = BLOOD_BOOMMAN;
	this->_id = ID_BOOMMAN;
	//this->_isFire = true;
	this->_isJump = false;
	this->_spriteStatus = ID_SPRITE_BOOMMAN_BOOM_PUSH;
	this->_currentDirec = DIRECTIONACTION::START;
	this->_previousDirec = this->_currentDirec;
	this->_sprite = ResourceManager::GetSprite(this->_spriteStatus);
	this->_v = Vector2(-50.0f / 1000.0f , 100.0f / 1000.0f); // đơn vị pixel / tick
	this->_gravity = -9.8f / 1000.0f; // pixel / tick
	this->_positionOld = Vector2(0,0);
	this->_dieDistance = 50.0f / 1000.0f;
	this->_timeDelay = 0; // tick
	this->_timeFire = 0.0f;
	this->_timeStart = 0.0f;
	this->_speed = 1.3f;
	this->_isStartJump = false;
	this->_isLockRun = true;
	this->_isCollideBullet = false;
	this->_isOneHit = true;
	this->_score = 5000;

	this->_collideNormalY = CDirection::NONE_DIRECT;
	this->_collideNormalX = CDirection::NONE_DIRECT;

	this->_timeHistoryCollideX=std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideY=std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideXBullet=std::numeric_limits<float>::infinity();
	this->_timeHistoryCollideYBullet=std::numeric_limits<float>::infinity();

	this->_collideNormalXBullet = CDirection::NONE_DIRECT;
	this->_collideNormalYBullet = CDirection::NONE_DIRECT;

	this->_bulletRockMan = nullptr;
	this->_timeEffectCollide = 600.0f;

	//bullet	
	this->_positionBullet = Vector2(this->_position.x - 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2); //Vector2(this->_position.x, this->_position.y + this->_sprite.GetFrameHeight() / 2);
	this->_bullet = new CBoomManBullet(10, ID_BULLET_BOOMMAN, ResourceManager::GetSprite(ID_SPRITE_BULLET_BOSS_BOOM)
		, DAME_BULLET_BOOMMAN, Vector2(0.0f / 1000.0f, 00.0f / 1000.0f), this->_positionBullet);

	this->_posStartDefault = this->_position;
	return 1;
}

void CBoomMan::Render(CGameTime* gametime, CGraphics* graphics)
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

void CBoomMan::Update(CGameTime* gameTime, CRockman* rockman)
{	
	// lấy vị trí đứng đầu tiên của rock man.
	if(this->_bullet->_posRockManStand == Vector2(0,0))
	{
		this->_bullet->_posRockManStand = this->_position;
		this->_posStartDefault = this->_position;
	}

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
			if(this->_bulletRockMan != nullptr && this->_isOneHit)
			{
				// giảm máu cut man
				this->_blood -= this->_bulletRockMan->GetDame();

				if(this->_blood <= 0.0f && this->_currentDirec != DIRECTIONACTION::DIE) // hết máu bật hiệu ứng díe
				{
					this->_bullet->SetStatus(false); // hủy viên đạn
					this->_currentDirec = DIRECTIONACTION::DIE;
					this->_bullet->_isBoomManDie = true;
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

	//các xử lý tien va chạm với các nền.
	if (_collideNormalX != CDirection::NONE_DIRECT
		|| _collideNormalY != CDirection::NONE_DIRECT)
	{
		if(this->_collideNormalX == CDirection::ON_RIGHT)
		{
			t = _timeHistoryCollideX;
			if(!this->_isStartJump && this->_isLockRun)
				this->_currentDirec = DIRECTIONACTION::DOWNRIGHT;
			this->_position.x += _v.x * t * _speed;

			this->_gravity = -50.0f/1000.0f;			
		}

		if(this->_collideNormalX == CDirection::ON_LEFT)
		{
			t = _timeHistoryCollideX;			
			if(!this->_isStartJump && this->_isLockRun)
				this->_currentDirec = DIRECTIONACTION::DOWNLEFT;
			this->_position.x += _v.x * t * _speed;			

			this->_gravity = -50.0f/1000.0f;
			// va chạm trái sẽ ko làm gì cả, đứng đó ném kéo.
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
	this->_bullet->_posRockMan = rockman->_position;
	if(!this->_bullet->_isBoomManDie) // khi boom man đã chết thì ko lấy vị trí nửa. 
		this->_bullet->_posBoomMan = this->_position;
	else // reset lại đạn boom man mới
		this->_bullet->_posBoomMan = this->_posStartDefault;

	// Lưu lại spriteStatus vừa rồi, nếu khác thì mới chuyển sprite nếu không thì không chuyển sprite
	int previousSpriteID = this->_spriteStatus;

	//Di chuyển boss
	switch (this->_currentDirec)
	{
		case DIRECTIONACTION::DOWNRIGHT:
			{
			this->_v.y = _gravity * gameTime->GetDeltaTime();
			this->_position.y += this->_v.y * _speed;
			this->_positionBullet = Vector2(this->_position.x + 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2 + 5.0f);
			break;
			}
	case DIRECTIONACTION::DOWNLEFT:		
		{						
			this->_v.y = _gravity * gameTime->GetDeltaTime();
			this->_position.y += this->_v.y * _speed;

			this->_positionBullet = Vector2(this->_position.x - 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2 + 5.0f);
		}
		break;
	case DIRECTIONACTION::JUMPLEFT:
		{	
			this->_position.x += _v.x * gameTime->GetDeltaTime() * this->_speed;
			this->_position.y += _v.y * gameTime->GetDeltaTime() * this->_speed;
			this->_isStartJump = false;
			this->_v.y += _gravity;

			this->_positionBullet = Vector2(this->_position.x - 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2 + 5.0f);
		}
		break;
	case DIRECTIONACTION::JUMPRIGHT:
		{
			this->_position.x += _v.x * gameTime->GetDeltaTime() * this->_speed;
			this->_position.y += _v.y * gameTime->GetDeltaTime() * this->_speed;
			this->_isStartJump = false;
			this->_v.y += _gravity;

			this->_positionBullet = Vector2(this->_position.x + 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2 + 5.0f);
		}
		break;
	case DIRECTIONACTION::STANDLEFT:
	case DIRECTIONACTION::STANDRIGHT:
		{
			this->_v.y = -100.0f / 1000.0f;
		}
		break;
	default:
		break;
	} 

	/////Start boss
	this->_timeStart += gameTime->GetDeltaTime();
	if(this->_timeStart >= 2000.0f && this->_currentDirec == DIRECTIONACTION::START)
	{
		this->_bullet->_sttBoom = STTBOOM::NONE;
		this->_currentDirec = DIRECTIONACTION::STANDLEFT;
		this->_spriteStatus = ID_SPRITE_BOOMMAN_JUMP_STAND;
	}

	// Kiểm tra và thay đổi trạng thái của Cut man
	if(this->_currentDirec != DIRECTIONACTION::START)
		this->CheckStatus(gameTime);

	//Thay đổi sprite
	if (previousSpriteID != this->_spriteStatus)
		this->_sprite = ResourceManager::GetSprite(this->_spriteStatus);

	//aminition
	this->_sprite.Update(gameTime);

	//set position boom để nó bắn
	if(this->_bullet->_isfire)
	{

	}
	else if(this->_bullet->_sttBoom == STTBOOM::NONE && this->_currentDirec != DIRECTIONACTION::START)
	{
		this->_bullet->_position = _positionBullet;
	}

	//amination bullet
//	this->_bullet->Update(gameTime);

	this->UpdateBox();

	_timeHistoryCollideX=std::numeric_limits<float>::infinity();
	_timeHistoryCollideY=std::numeric_limits<float>::infinity();
	_collideNormalX=_collideNormalY=CDirection::NONE_DIRECT;

	_timeHistoryCollideXBullet=std::numeric_limits<float>::infinity();
	_timeHistoryCollideYBullet=std::numeric_limits<float>::infinity();
	_collideNormalXBullet=_collideNormalYBullet=CDirection::NONE_DIRECT;
}

void CBoomMan::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	// Nếu va chạm với .......
	switch (gameObject->_typeID)
	{
	case ID_BLOCK:

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

void CBoomMan::CheckStatus(CGameTime* gameTime)
{
	if(this->_currentDirec == DIRECTIONACTION::DIE)
	{
		return;
	}

	if((this->_previousDirec == DIRECTIONACTION::JUMPLEFT && this->_v.y == -100.0f / 1000.0f) && this->_position.x - this->_posRockMan.x < 0)
	{
		this->_currentDirec = DIRECTIONACTION::STANDRIGHT;		

		this->_spriteStatus = ID_SPRITE_BOOMMAN_JUMP_STAND;
		//this->_position.y += 4.0f;

		this->_timeDelay = 0.0f;
		if(this->_v.x < 0)
			this->_v.x *= -1;
		this->_isJump = true;
		this->_isLockRun = true;

		this->_positionBullet = Vector2(this->_position.x + 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2);
	}
	else if((this->_previousDirec == DIRECTIONACTION::JUMPRIGHT && this->_v.y == -100.0f / 1000.0f) && this->_position.x - this->_posRockMan.x > 0)
	{
		this->_currentDirec = DIRECTIONACTION::STANDLEFT;

		this->_spriteStatus = ID_SPRITE_BOOMMAN_JUMP_STAND;
		this->_timeDelay = 0.0f;

		if(this->_v.x > 0)
			this->_v.x *= -1;
		this->_isJump = true;
		this->_isLockRun = true;

		this->_positionBullet = Vector2(this->_position.x - 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2);
	}
	else
	{
		//sau khi nhảy dừng 1s sau đó hoạt động tiếp
		this->_timeDelay += gameTime->GetDeltaTime();

		if(this->_timeDelay >= 1000)
		{
			this->_timeDelay = 1000.0f;

			if(abs(this->_posRockMan.x - this->_position.x) > RANK_BOOMMAN && this->_v.y == -100.0f / 1000.0f)// điều kiện là nhảy phải xa hơn rank quy định
			{	  				
				//Jump	
				this->JumpAI();	
				this->_isJump = false;
			}
			else
			{				
				//Jump			
				this->JumpAI();
				this->_isJump = false;
			}				
		}	
		else 
			if(this->_timeDelay >= 800)
			{	
				if(this->_spriteStatus == ID_SPRITE_BOOMMAN_FIRE)
					this->_sprite.SetIndex(1);

				this->_bullet->_isfire = true;
				this->_spriteStatus = ID_SPRITE_BOOMMAN_FIRE;	
			}

	}

	// Nếu boom man đang đứng thì kiểm tra hướng đứng(trái or phải)
	if(this->_currentDirec == DIRECTIONACTION::STANDLEFT && this->_position.x - this->_posRockMan.x < 0)
	{
		this->_currentDirec = DIRECTIONACTION::STANDRIGHT;
		if(this->_previousDirec != this->_currentDirec)
			this->_v.x *= -1;

		this->_positionBullet = Vector2(this->_position.x + 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2);
	}
	else if(this->_currentDirec == DIRECTIONACTION::STANDRIGHT && this->_position.x - this->_posRockMan.x > 0)
	{	
		this->_currentDirec = DIRECTIONACTION::STANDLEFT;
		if(this->_previousDirec != this->_currentDirec)
			if(this->_v.x > 0)
				this->_v.x *= -1;
		this->_positionBullet = Vector2(this->_position.x - 10.0f, this->_position.y + this->_sprite.GetFrameHeight() / 2);
	}

	this->_previousDirec = this->_currentDirec;
}

void CBoomMan::JumpAI()
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
		this->_isJump = false;
		this->_isStartJump = true;
		srand (time(NULL));
		int r = rand() % 2 + 1;
		if(r % 2 == 0)
		{	
			//xét độ cao để nhảy thấp.
			this->_v.y += 210.0f / (1000.0f);
			this->_spriteStatus = ID_SPRITE_BOOMMAN_JUMP_LOW;	
		}
		else
		{
			//xét độ cao để nhảy cao.
			this->_v.y += 250.0f / (1000.0f);
			this->_spriteStatus = ID_SPRITE_BOOMMAN_JUMP_HEIGHT;	
		}
	}
}

void CBoomMan::GetPositioRockMan(Vector2 pos)
{
	this->_posRockMan = pos;
}

void CBoomMan::UpdateBox()
{
	switch(this->_spriteStatus)
	{
	case ID_SPRITE_BOOMMAN_FIRE:
	case ID_SPRITE_BOOMMAN_JUMP_LOW:
	case ID_SPRITE_BOOMMAN_JUMP_HEIGHT:
	case ID_SPRITE_BOOMMAN_JUMP_STAND:
	case ID_SPRITE_BOOMMAN_BOOM_PUSH:
		this->_box._width = 25.0f;
		this->_box._height = 28.0f;
		this->_box._x = this->_position.x - this->_sprite.GetFrameWidth() / 2;
		this->_box._y = this->_position.y + this->_sprite.GetFrameHeight() / 2;
		this->_box._vx = this->_v.x * _speed;
		this->_box._vy = this->_v.y * _speed;
		break;	
	}
}

vector<CBullet*> CBoomMan::Fire()
{
	vector<CBullet*> vbullet = vector<CBullet*>();
	if (this->_bullet->_isOneHitBullet)
	{
		vbullet.push_back(this->_bullet);
		this->_bullet->_isOneHitBullet = false;
		this->_bullet->SetStatus(true);
	}
	return vbullet;
}

CBoomMan* CBoomMan::ToValue()
{
	return new CBoomMan(*this);
}