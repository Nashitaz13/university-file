#include "CTank.h"
#include "CCollision.h"
#include "CContra.h"
#include "CCamera.h"
#include "CPoolingObject.h"


bool CTank::m_shooted = true;
CTank::CTank()
{
	this->Init();
}

CTank::CTank(const std::vector<int>& info)
{
	this->Init();
	if(!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
}

void CTank::Init()
{
	//TT
	this->m_pos = D3DXVECTOR2(550.0f, 400.0f);
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 4;
	this->m_idType = 12; 
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 196.0f;//56.0f; //78
	this->m_height = 130.0f; //88.0f; //84
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_a = -25.0f;
	//this->m_currentJump = 0.0f;
	this->m_vxDefault = 2.0f;
	this->m_vyDefault = 400.0f;
	this->m_vx = -this->m_vxDefault;
	this->m_vy = 0;
	this->m_left = false;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_countEffect = 0;
	this->m_elapseTimeChangeFrame = 0.20f;
	this->m_increase = 1;
	this->m_totalFrame = 29;
	this->m_column = 6;
	//
	this->m_isShoot = false;
	this->m_stateCurrent = TANK_STATE::TANK_IS_NORMAL;
	this->m_tankShootState = TANK_SHOOT_STATE::T_IS_SHOOTING_NORMAL;
	this->m_HP = 20;
	this->m_waitForExplosion = 0.2f;
	this->m_isMoveLeft = true;
	// thoi gian dung o giua man hinh
	this->m_timeDelay = 0.0f;
	// thoi gian ban luot dan thu 2
	this->m_timeDelayWaitShoot = 0.25f;
	this->m_bulletCount = 0;
	this->m_allowShoot = true;

	this->m_delayForNextShoot = 1.0f;
	this->angle = 0.0f;
}

void CTank::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->IsAlive())
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->MoveUpdate(deltaTime);
		this->BulletUpdate(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
}

void CTank::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{

	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CBullet* obj = *it;
		timeCollision = CCollision::GetInstance()->Collision(obj, this, normalX, normalY, moveX, moveY, deltaTime);
		if((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
		{
			if(obj->IsAlive() && obj->GetLayer() == LAYER::PLAYER)
			{
				this->m_HP --;
				// Xoa vien dan ra khoi d.s
				it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);

				CBulletEffect* effect = CPoolingObject::GetInstance()->GetBulletEffect();
				effect->SetAlive(true);
				effect->SetPos(obj->GetPos());

				if (this->m_HP >= 15)
				{
					this->m_stateCurrent = TANK_STATE::TANK_IS_NORMAL;
				}
				else if (this->m_HP <= 14 && this->m_HP >= 10)
				{
					this->m_stateCurrent = TANK_STATE::TANK_IS_DIE1;
				}
				else if (this->m_HP <=9 && this->m_HP >= 5)
				{
					this->m_stateCurrent = TANK_STATE::TANK_IS_DIE2;
				}
				else if (this->m_HP > 0)
				{
					// Gan trang thai die cho doi tuong
					this->m_stateCurrent = TANK_STATE::TANK_IS_DIE3;
				}
				else if (this->m_HP == 0)
				{
					this->m_vy = 0;
					this->m_a = 0;
					this->m_stateCurrent = TANK_STATE::TANK_IS_DIE;

					// Tang diem cua contra len
					CContra::GetInstance()->IncreateScore(5000);
				}
			}
			else
				++it;
		}
		else
		{
			++it;
		}
	}

	if (this->m_stateCurrent != TANK_STATE::TANK_IS_DIE)
	{
		//Kiem tra va cham voi ground
		bool checkColWithGround = false;
		// xet va cham vs ground
		for (std::vector<CGameObject*>::iterator it = listObjectCollision->begin(); it != listObjectCollision->end(); it++)
		{
			CGameObject* obj = *it;
			//Lay thoi gian va cham
			//Neu doi tuong la ground va dang va cham
			if (((obj->GetIDType() == 15 && (obj->GetID() == 1 || obj->GetID() == 8)) || 
				(obj->GetIDType() == 16 && obj->GetID() == 1)) && !checkColWithGround)
			{
				timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
				if((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
				{
					if(normalY > 0)
					{

						checkColWithGround = true;
						if( timeCollision == 2.0f)
						{
							//this->m_isJumping = false;
							this->m_pos.y += moveY;
							this->m_vy = 0;
							//this->m_a = 0;
						}
					}
				}
			}
		}
	}
}

void CTank::MoveUpdate(float deltaTime)
{
	D3DXVECTOR2 tankPos = CCamera::GetInstance()->GetPointTransform(this->m_pos.x, this->m_pos.y);
	D3DXVECTOR2 centerScreen = D3DXVECTOR2(__SCREEN_WIDTH/ 2, __SCREEN_HEIGHT/2);

	// Neu den giua man hinh, va dang chay thi dung lai
	if ((tankPos.x <= (centerScreen.x + this->m_width/2) && this->m_isMoveLeft) || !this->m_isMoveLeft)
	{
		this->m_isMoveLeft = false;
		this->m_timeDelay += deltaTime;
		if (this->m_timeDelay >= 10.0f)
		{
			this->m_isMoveLeft = true;
		}
	}
	// Neu tank di chuyen thi cap nhat posx.
	if (this->m_isMoveLeft)
	{
		this->m_vx += this->m_a * deltaTime;
		this->m_pos.x += int(this->m_vx * deltaTime);
	}
	else // nguoc lai thi ban dan theo huong cua contra
	{
		this->m_isShoot = true;
	}

	// Kiem tra tank co dang di chuyen hay k
	this->m_vy += this->m_a * deltaTime;
	this->m_pos.y += this->m_vy * deltaTime;

}

void CTank::BulletUpdate(float deltaTime)
{
	D3DXVECTOR2 posContra = CContra::GetInstance()->GetPos();

	if (!CTank::m_shooted)
	{
		if (posContra.y > this->m_pos.y)
		{
			angle = 0.0f;
			this->m_tankShootState = TANK_SHOOT_STATE::T_IS_SHOOTING_NORMAL;
		}
		else if (this->m_pos.x - posContra.x > this->m_width)
		{
			angle = -PI/6;
			this->m_tankShootState = TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN;
		}
		else if (this->m_pos.x - posContra.x < this->m_width)
		{
			angle = -PI/4;
			this->m_tankShootState = TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN2X;
		}
	}
#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
	D3DXVECTOR2 offset;
	switch (this->m_tankShootState )
	{
	case TANK_SHOOT_STATE::T_IS_SHOOTING_NORMAL:
		{
			offset.x = -95.0f;
			offset.y = 35.0f;
			break;
		}
	case TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN:
		{
			offset.y = 20.0f;
			offset.x = -this->m_width / 2 + 20.0f;
			break;
		}
	case TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN2X:
		{
			offset.y = 10.0f;
			offset.x = -this->m_width / 2 + 23.0f;
			break;
		}
	default:
		{
			break;
		}
	}
#pragma endregion

#pragma region THIET LAP TOC DO DAN
	if (this->m_isShoot)
	{
		if (m_bulletCount > 2)
		{
			if (this->m_delayForNextShoot <= 0)
			{
				this->m_delayForNextShoot = 1.5f;
				this->m_bulletCount = 0;
				this->m_isShoot = false;
				CTank::m_shooted = false;
			}
			this->m_delayForNextShoot -= deltaTime;
		}
		else
		{
			if (this->m_timeDelayWaitShoot >= 0.25f)
			{
				CBullet_M* bullet = new CBullet_M(angle, this->m_pos, offset, !this->m_left);
				bullet->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				this->m_timeDelayWaitShoot = 0;
				m_bulletCount++;
				CTank::m_shooted = true;
			}
			m_timeDelayWaitShoot += deltaTime;
		}
	}
#pragma endregion
}


void CTank::SetFrame(float deltaTime)
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
	case TANK_STATE::TANK_IS_NORMAL:
		{
			if (this->m_isMoveLeft)
			{
				this->m_startFrame = 0;
				this->m_endFrame = 1;
			}
			else
			{
				if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_NORMAL)
				{
					this->m_startFrame = 0;
					this->m_endFrame = 0;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN)
				{
					this->m_startFrame = 2;
					this->m_endFrame = 3;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN2X)
				{
					this->m_startFrame = 4;
					this->m_endFrame = 5;
				}
			}
			break;
		}
	case TANK_STATE::TANK_IS_DIE1:
		{
			if (this->m_isMoveLeft)
			{
				this->m_startFrame = 6;
				this->m_endFrame = 7;
			}
			else
			{
				if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_NORMAL)
				{
					this->m_startFrame = 6;
					this->m_endFrame = 6;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN)
				{
					this->m_startFrame = 8;
					this->m_endFrame = 9;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN2X)
				{
					this->m_startFrame = 10;
					this->m_endFrame = 11;
				}
			}
			break;
		}
	case TANK_STATE::TANK_IS_DIE2:
		{
			if (this->m_isMoveLeft)
			{
				this->m_startFrame = 12;
				this->m_endFrame = 13;
			}
			else
			{
				if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_NORMAL)
				{
					this->m_startFrame = 12;
					this->m_endFrame = 12;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN)
				{
					this->m_startFrame = 14;
					this->m_endFrame = 15;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN2X)
				{
					this->m_startFrame = 16;
					this->m_endFrame = 17;
				}
			}
			break;
		}
	case TANK_STATE::TANK_IS_DIE3:
		{
			if (this->m_isMoveLeft)
			{
				this->m_startFrame = 18;
				this->m_endFrame = 19;
			}
			else
			{
				if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_NORMAL)
				{
					this->m_startFrame = 18;
					this->m_endFrame = 18;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN)
				{
					this->m_startFrame = 20;
					this->m_endFrame = 21;
				}
				else if (this->m_tankShootState == TANK_SHOOT_STATE::T_IS_SHOOTING_DOWN2X)
				{
					this->m_startFrame = 22;
					this->m_endFrame = 23;
				}
			}
			break;
		}
	case TANK_STATE::TANK_IS_DIE:
		{
			this->m_startFrame = 24;
			this->m_endFrame = 29;
			
			CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
			D3DXVECTOR2 posEff;

			if (this->m_currentFrame == this->m_endFrame)
			{
				this->m_isALive = false;
			}

			this->m_waitForExplosion -= deltaTime;
			if (this->m_waitForExplosion <= 0)
			{
				this->m_waitForExplosion = 0.15f;

				if (this->m_countEffect % 2 == 0)
				{
					posEff.x = this->m_pos.x - 90 + 30 * this->m_countEffect;
					posEff.y = this->m_pos.y + 10;
					this->m_countEffect++;
				}
				else
				{
					posEff.x = this->m_pos.x - 90 + 30 * (this->m_countEffect - 1);
					posEff.y = this->m_pos.y - 20;
					this->m_countEffect++;
				}
				effect->SetAlive(true);
				effect->SetPos(posEff);
			}
			break;
		}
	default:
		break;
	}
}

RECT* CTank::GetBound()
{
	return nullptr;
}

RECT* CTank::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CTank::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 10, this->m_height - 10, this->m_vx, this->m_vy);
}

CTank::~CTank()
{

}