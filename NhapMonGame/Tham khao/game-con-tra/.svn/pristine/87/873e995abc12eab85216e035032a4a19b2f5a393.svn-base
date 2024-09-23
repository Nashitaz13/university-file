#include "CGunner.h"
#include "CContra.h"
#include <math.h>
#include "CCamera.h"
#include "CCollision.h"
#include "CPoolingObject.h"
#include "CManageAudio.h"

CGunner::CGunner(void)
{
	this->Init();
}

CGunner::CGunner(const std::vector<int>& info)
{
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
	this->Init();
}

// Ham khoi tao cua linh nup
void CGunner::Init()
{
	//Khoi tao cac thong so cua doi tuong
	// TT
	this->m_id = 6;
	this->m_idType = 11;
	this->m_idImage = 6;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 66.0f;
	this->m_height = 64.0f;
	this->m_left = false;
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.650f;

	this->m_increase = 1;
	this->m_totalFrame = 2;
	this->m_column = 2;
	//
	this->m_stateCurrent = GUNNER_STATE::GN_IS_NORMAL;
	this->m_bulletCount = 0;
	this->m_timeDelay = 0.40f;
	this->m_waitForShoot = 0.7f;
	this->m_isShoot = false;//true;
	this->m_allowShoot = true;
	this->m_HP = 5;
}

void CGunner::Update(float deltaTime)
{
	if (this->IsAlive())
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);
		this->OnCollision(deltaTime, nullptr);
	}

}

void CGunner::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->IsAlive())
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
}

void CGunner::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
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
		if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
		{
			if(obj->IsAlive() && obj->GetLayer() == LAYER::PLAYER)
			{
				this->m_HP--;
				it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
			}
			else
				++it;

			if (this->m_HP == 0)
			{
				// Gan trang thai die cho doi tuong
				this->m_stateCurrent = GUNNER_STATE::GN_IS_DIE;
				//Load sound die
				ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
				// Tang diem cua contra len
				CContra::GetInstance()->IncreateScore(300);
			}
		}
		else
		{
			++it;
		}
	}
}

void CGunner::BulletUpdate(float deltaTime)
{
#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
	D3DXVECTOR2 offset;
	offset.x = -this->m_width / 2;
	offset.y = this->m_height / 2 - 12.0f;
#pragma endregion

#pragma region THIET LAP TOC DO DAN

	if (this->m_isShoot)
	{
		if (this->m_currentFrame == 1)
		{
			if (m_bulletCount == 0)
			{
				CBullet_M* bullet = new CBullet_M(0, this->m_pos, offset, !this->m_left);
				bullet->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				m_bulletCount++;
			}
			else
			{
				this->m_isShoot = false;
			}
			//
			if (this->m_waitForShoot <= 0)
			{
				this->m_waitForShoot = 0.70f; // thoi gian delay frame 8
				this->m_bulletCount = 0;
				this->m_isShoot = true;
			}
			else
			{
				this->m_waitForShoot -= deltaTime;
			}
		}
	}
#pragma endregion

}

void CGunner::SetFrame(float deltaTime)
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
		case GUNNER_STATE::GN_IS_NORMAL:
		{
			this->m_startFrame = 0;
			this->m_endFrame = 0;
			if (!this->m_isShoot && this->m_bulletCount == 0)
				this->m_stateCurrent = GUNNER_STATE::GN_IS_SHOOTTING;
			break;
		}
	
		case GUNNER_STATE::GN_IS_SHOOTTING:
		{
			this->m_startFrame = 0;
			this->m_endFrame = 1;
			this->m_isShoot = true;
			break;
		}
		case GUNNER_STATE::GN_IS_DIE:
		{
			CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect->SetAlive(true);
			effect->SetPos(this->m_pos);
			this->m_isALive = false;
			break;
		}
		default:
			break;
	}
}

RECT* CGunner::GetBound()
{
	return nullptr;
}

RECT* CGunner::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CGunner::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 20, this->m_height, 0, 0);
}

CGunner::~CGunner()
{

}