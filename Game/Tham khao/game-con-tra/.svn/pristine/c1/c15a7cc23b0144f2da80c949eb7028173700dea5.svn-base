#include "CCapsuleBoss.h"
#include "CCollision.h"
#include "CContra.h"
#include "CCamera.h"
#include "CPoolingObject.h"
#include "CBulletMechanicalAlien.h"
#include "CManageAudio.h"

CCapsuleBoss::CCapsuleBoss()
{
	this->Init();
}

CCapsuleBoss::CCapsuleBoss(const std::vector<int>& info)
{
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
	this->Init();//
}

void CCapsuleBoss::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 11;
	this->m_idType = 17;
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 52.0f;
	this->m_height = 36.0f;
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.20f;
	this->m_increase = 1;
	this->m_totalFrame = 3;
	this->m_column = 3;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	this->m_stateCurrent = CAPSULE_STATE::CAP_IS_NORMAL;
	//Khoi tao cac thong so di chuyens
	this->m_vxDefault = 220.0f;
	this->m_vyDefault = 200.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_space = 100.0f;
	this->m_spaceCurrent = 0;
	//
	this->m_timeDelay = 0.20f;
	//
	this->m_isShoot = false;
	this->m_allowShoot = true;
	this->m_time = 0;

	this->m_layer = LAYER::ENEMY;
}

void CCapsuleBoss::Update(float deltaTime)
{
	if (this->m_isALive)
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->MoveUpdate(deltaTime);
	}
}

void CCapsuleBoss::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->MoveUpdate(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
	else
		//play sound
		ManageAudio::GetInstance()->stopSound(TypeAudio::ENEMY_DEAD_SFX);
}

void CCapsuleBoss::MoveUpdate(float deltaTime)
{
#pragma region TRANG_THAI_CHAY
	if (this->m_stateCurrent == CAPSULE_STATE::CAP_IS_NORMAL)
	{
		if (this->m_spaceCurrent < this->m_space)
		{
			if (this->m_left)
			{
				if (this->m_spaceCurrent == 0)
					this->m_vx = this->m_vxDefault;
			}
			else
			{
				if (this->m_spaceCurrent == 0)
					this->m_vx = -this->m_vxDefault;
			}
			this->m_pos.x += this->m_vx * deltaTime;
			this->m_spaceCurrent += abs(this->m_vx * deltaTime);
		}
		else
		{
			if (this->m_isCollisonWithGround)
			{
				if (this->m_left)
					this->m_vx = -this->m_vxDefault;
				else
					this->m_vx = +this->m_vxDefault;

				this->m_vy = 0;
			}
			else
			{
				this->m_vy = this->m_vyDefault;
				this->m_vx = 0;
				this->m_pos.y -= this->m_vy * deltaTime;
			}
			if (this->m_vx != 0)
				this->m_pos.x += this->m_vx * deltaTime;
		}
	}
#pragma endregion

	//Xoa doi tuong ra khoi man hinh
	D3DXVECTOR2 pos = CCamera::GetInstance()->GetPointTransform(this->m_pos.x, this->m_pos.y);
	if (pos.x > __SCREEN_WIDTH || pos.x < 0 || pos.y > __SCREEN_HEIGHT || pos.y < 0 || !this->IsAlive())
	{
		this->m_isALive = false;
		this->m_spaceCurrent = 0;
	}
}

void CCapsuleBoss::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;
	//Xet va cham voi dan
	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CGameObject* obj = *it;
		if (obj->GetLayer() == LAYER::PLAYER)
		{
			timeCollision = CCollision::GetInstance()->Collision(obj, this, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				if (obj->IsAlive())
				{
					// Gan trang thai die cho doi tuong
					this->m_stateCurrent = CAPSULE_STATE::CAP_IS_DIE;
					//play sound
					ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
					// Xoa vien dan ra khoi d.s
					it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
				}
				else
				{
					++it;
				}
			}
			else
			{
				++it;
			}
		}
		else
			++it;
	}

	//xet va cham vs dat
	for (std::vector<CGameObject*>::iterator it = listObjectCollision->begin(); it != listObjectCollision->end(); it++)
	{
		CGameObject* obj = *it;
		//Lay thoi gian va cham
		//Neu doi tuong la ground va dang va cham
		if (((obj->GetIDType() == 15 && (obj->GetID() == 1 || obj->GetID() == 8)) || (obj->GetIDType() == 16 && obj->GetID() == 1)))
		{
			timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				if (normalY > 0)
				{
					this->m_vy = 0;
					this->m_isCollisonWithGround = true;
				}
				else
					this->m_isCollisonWithGround = false;
			}
		}
	}
}

void CCapsuleBoss::SetFrame()
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
	case CAPSULE_STATE::CAP_IS_START:
	{
										this->m_startFrame = 0;
										this->m_endFrame = 2;
										break;
	}
	case CAPSULE_STATE::CAP_IS_NORMAL:
	{
										 this->m_startFrame = 0;
										 this->m_endFrame = 2;
										 break;
	}
	case CAPSULE_STATE::CAP_IS_DIE:
	{
									  // Lay doi tuong ra
									  CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
									  effect->SetAlive(true);
									  effect->SetPos(this->m_pos);

									  this->m_isALive = false;
									  break;
	}
	}
}

RECT* CCapsuleBoss::GetBound()
{
	return nullptr;
}

RECT* CCapsuleBoss::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CCapsuleBoss::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 4, this->m_height - 4);
}
CCapsuleBoss::~CCapsuleBoss()
{

}