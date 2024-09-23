#include "CDefenseCannonTurret.h"
#include "CContra.h"
#include <math.h>
#include "CCamera.h"
#include "CPoolingObject.h"
#include "CCollision.h"
#include "CManageAudio.h"

CDefenseCannonTurret::CDefenseCannonTurret(void)
{
	this->Init(0, 0);
}

CDefenseCannonTurret::CDefenseCannonTurret(int xBoss, int yBoss)
{
	this->Init(xBoss, yBoss);
}

CDefenseCannonTurret::CDefenseCannonTurret(const std::vector<int>& info)
{
	this->Init(0, 0);
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
}

void CDefenseCannonTurret::Init(int xBoss, int yBoss)
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 3;
	this->m_idType = 17;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 48.0f;
	this->m_height = 62.0f;
	this->m_pos = D3DXVECTOR2(xBoss - 71.0f, yBoss - 69.0f);
	this->m_left = false;
	//@@
	this->m_stateCurrent = DC_TURRECT_STATE::DC_TURRECT_NORMAL;
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.55f;
	this->m_increase = 1;
	this->m_totalFrame = 3;
	this->m_column = 3;
	this->m_HP = 15;
	//Test
	this->m_timeDelay = 0.25f;

}

void CDefenseCannonTurret::Update(float deltaTime)
{
	
}

void CDefenseCannonTurret::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
	else
		//play sound
		ManageAudio::GetInstance()->stopSound(TypeAudio::ENEMY_DEAD_SFX);
}

void CDefenseCannonTurret::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
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

				CBulletEffect* effect = CPoolingObject::GetInstance()->GetBulletEffect();
				effect->SetAlive(true);
				effect->SetPos(obj->GetPos());
			}
			else
				++it;

			if (this->m_HP == 0)
			{
				// Gan trang thai die cho doi tuong
				this->m_stateCurrent = DC_TURRECT_STATE::DC_TURRECT_IS_DIE;
				//play sound
				ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
				// Tang diem cua contra len
				CContra::GetInstance()->IncreateScore(10000);
			}
		}
		else
		{
			++it;
		}
	}
}

void CDefenseCannonTurret::SetFrame()
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
	case DC_TURRECT_STATE::DC_TURRECT_NORMAL:
		{
			this->m_startFrame = 0;
			this->m_endFrame = 2;
			break;
		}
	case DC_TURRECT_STATE::DC_TURRECT_IS_DIE:
	{
			CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect->SetAlive(true);
			effect->SetPos(D3DXVECTOR2(this->m_pos.x, this->m_pos.y));
			this->m_isALive = false;
			break;
		}
	}
}

RECT* CDefenseCannonTurret::GetBound()
{
	return nullptr;
}

RECT* CDefenseCannonTurret::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CDefenseCannonTurret::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 4, this->m_height - 4, 0, 0);
}

CDefenseCannonTurret::~CDefenseCannonTurret()
{

}