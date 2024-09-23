#include "CSniperBoss.h"
#include "CPoolingObject.h"
#include "CCollision.h"
#include "CContra.h"
#include "CLoadGameObject.h"
#include "CCamera.h"
#include "CManageAudio.h"

CSniperBoss::CSniperBoss(void)
{
	this->Init();
}

CSniperBoss::CSniperBoss(const std::vector<int> &info)
{
	if(!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
	this->Init();//
}

// Ham khoi tao
void CSniperBoss::Init()
{
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 48.0f;
	this->m_height = 80.0f;
	this->m_left = false;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.25f;

	this->m_increase = 1;
	this->m_totalFrame = 8;
	this->m_column = 8;
	//
	this->m_isShoot = false;
	this->m_stateCurrent = SNIPERBOSS_STATE::SNB_IS_HIDING;

	this->m_bulletCount = 0;
	this->m_timeDelay = 2.0f;
	this->m_timeDelayForStand = 0.8f;
	this->m_waitForGrowUp = 0.0f;
	this->m_waitForChangeToDie = 0.0f;

	this->m_allowShoot = true;
	//
	this->SetLayer(LAYER::ENEMY);
}

void CSniperBoss::Update(float deltaTime)
{

}

void CSniperBoss::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->IsAlive())
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);
		if (this->m_currentFrame != 0)
		{
			this->OnCollision(deltaTime, nullptr);
		}
	}
	else
	{
		//play sound
		ManageAudio::GetInstance()->stopSound(TypeAudio::ENEMY_DEAD_SFX);
	}
}

void CSniperBoss::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CGameObject* obj = *it;
		timeCollision = CCollision::GetInstance()->Collision(obj, this, normalX, normalY, moveX, moveY, deltaTime);
		if((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
		{
			if(obj->IsAlive() && obj->GetLayer() == LAYER::PLAYER)
			{
				// Gan trang thai die cho doi tuong
				this->m_stateCurrent = SNB_IS_DIE;
				// Xoa vien dan ra khoi d.s
				it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
				
				//play sound
				ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
			}
			else
				++it;
		}
		else
		{
			++it;
		}
	}
}

void CSniperBoss::BulletUpdate(float deltaTime)
{
#pragma region THIET LAP GOC BAN
	D3DXVECTOR2 posContra = CContra::GetInstance()->GetPos();
	float spaceX = posContra.x - this->m_pos.x; //
	float spaceY = posContra.y - this->m_pos.y;
	double shootAngleNormal = PI / 10; //
	double angle = 0.0f;

	if(spaceX != 0)
	{
		angle = atan(spaceY / abs(spaceX));
		if(angle < 0)
		{
			//Chuyen sang toa do duong
			angle += 2*PI;
		}
		if(int(angle / shootAngleNormal) != 0 && int(angle / shootAngleNormal) != 10)
			angle = (int(angle / shootAngleNormal) + 1) * shootAngleNormal;
		else
			angle = (int(angle / shootAngleNormal)) * shootAngleNormal;
	}
	else
	{
		if(spaceY > 0)
		{
			angle = PI/2;
		}
		else
		{
			angle = -PI/2;
		}
	}
#pragma endregion

#pragma region THIET LAP TRANG THAI BAN

	if(this->m_isShoot && this->m_stateCurrent != SNB_IS_DIE)
	{
		angle = (angle > 2 * PI) ? angle - 2*PI : angle;
		int space = int(angle / shootAngleNormal);
		switch(space)
		{
		case 0: case 10: case 20:
			{
				this->m_stateShoot = SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_NORMAL;
				break;
			}
		case 11: case 12: case 13: case 14: case 16: case 17: case 18: case 19:
			{
				this->m_stateShoot = SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_DIAGONAL_DOWN;
				break;
			}
		case 15:
			{
				this->m_stateShoot = SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_DOWN;
				break;
			}
		}
	}

#pragma endregion

#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
	D3DXVECTOR2 offset;
	switch(this->m_stateShoot)
	{
	case SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_NORMAL:
		{
			if (this->m_left)
			{
				offset.x = this->m_width / 2;
				offset.y = 17.0f;
			}
			else
			{
				offset.y = 17.0f;
				offset.x = 0;
			}
			break;
		}
	case SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_DOWN:
		{
			if (this->m_left)
			{
				offset.y = 0;
				offset.x = this->m_width / 2;
			}
			else
			{
				offset.y = 0.0f;
				offset.x = this->m_width / 2;
			}
			break;
		}
	case SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_DIAGONAL_DOWN:
		{
			if (this->m_left)
			{
				offset.y = -8.0f;
				offset.x = this->m_width / 2;
			}
			else
			{
				offset.y = -8.0f;
				offset.x = -10.0f;
			}
			break;
		}
	default:
		{
			break;
		}
	}
#pragma endregion

#pragma region THIET LAP TOC DO DAN

	if (this->m_currentFrame == 4 && this->m_increase >= 1)
	{
		this->m_isShoot = true;
		this->m_stateCurrent = SNIPERBOSS_STATE::SNB_IS_SHOOTING;
	}

	// Cho phep ban dan
	if(this->m_isShoot)
	{
		// Sau khi ban xong
		if(m_bulletCount > 2 && this->m_stateCurrent == SNIPERBOSS_STATE::SNB_IS_SHOOTING)
		{
			this->m_currentFrame = 5;
			this->m_increase = 0;
			if (this->m_timeDelayForStand > 0.8f)
			{
				this->m_bulletCount = 0;
				this->m_isShoot = false;
				this->m_timeDelayForStand = 0.0f;
				this->m_increase = -1;
				this->m_stateCurrent = SNIPERBOSS_STATE::SNB_IS_HIDING;
			}
			this->m_timeDelayForStand += deltaTime;
		}
		else
		{
			if(this->m_timeDelay >= 0.35f)
			{
				CBullet_N* bullet = new CBullet_N(angle, this->m_pos, offset, !this->m_left);
				bullet->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				this->m_timeDelay = 0;
				m_bulletCount ++;
			}
			m_timeDelay += deltaTime;
		}
	}
#pragma endregion
}

void CSniperBoss::SetFrame(float deltaTime)
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
	case SNIPERBOSS_STATE::SNB_IS_HIDING:
		{
			this->m_startFrame = 0;
			this->m_endFrame = 4;
			if (this->m_currentFrame == 0)
			{
				this->m_increase = 0;
				if (this->m_waitForGrowUp > 0.4f)
				{
					this->m_waitForGrowUp = 0.0f;
					this->m_increase = 1;
				}
				this->m_waitForGrowUp += deltaTime;
			}
			break;
		}
	case SNIPERBOSS_STATE::SNB_IS_SHOOTING:
		{
			this->m_startFrame = 4;
			this->m_endFrame = 7;
			break;
		}
	case SNIPERBOSS_STATE::SNB_IS_DIE:
		{
			this->m_currentFrame = 5;
			this->m_startFrame = 5;
			this->m_endFrame = 5;
			// dich chuyen doi tuong.
			if (this->m_waitForChangeToDie <= 0.2f)
			{
				this->m_waitForChangeToDie += deltaTime;
				this->m_pos.y += 3;
				this->m_pos.x -= 1;
			}
			else
			{
				// Lay doi tuong ra
				CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
				effect->SetAlive(true);
				effect->SetPos(this->m_pos);

				this->m_isALive = false;
			}

			break;
		}
	default:
		break;
	}

	// Neu trang thai dang ban, moi set lai frame
	if (this->m_stateCurrent == SNIPERBOSS_STATE::SNB_IS_SHOOTING)
	{
		switch (this->m_stateShoot)
		{
		case SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_NORMAL:
			{
				if(this->m_isShoot)
				{
					this->m_startFrame = 4;
					this->m_endFrame = 5;
				}
				else
				{
					this->m_startFrame = 4;
					this->m_endFrame = 4;
				}
				break;
			}
		case SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_DIAGONAL_DOWN: case SNIPERBOSS_SHOOT_STATE::SNB_IS_SHOOTING_DOWN:
			{
				if(this->m_isShoot)
				{
					this->m_startFrame = 6;
					this->m_endFrame = 7;
				}
				else
				{
					this->m_startFrame = 6;
					this->m_endFrame = 6;
				}
				break;
			}
		default:
			break;
		}
	}
}

RECT* CSniperBoss::GetBound()
{
	return nullptr;
}

RECT* CSniperBoss::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CSniperBoss::GetBox()
{
	if (this->m_stateCurrent == SNIPERBOSS_STATE::SNB_IS_HIDING)
	{
		return Box(this->m_pos.x, this->m_pos.y - 20, this->m_width - 20, this->m_height - 50, 0, 0);
	}
	else
	{
		return Box(this->m_pos.x, this->m_pos.y, this->m_width - 20, this->m_height - 4, 0, 0);
	}
}

CSniperBoss::~CSniperBoss()
{

}