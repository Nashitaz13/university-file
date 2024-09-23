#include "CHeadBoss.h"
#include "CCollision.h"
#include "CContra.h"
#include "CCamera.h"
#include "CPoolingObject.h"
#include "CBulletMechanicalAlien.h"
#include "CManageAudio.h"

CHeadBoss::CHeadBoss(D3DXVECTOR2 posBoss)
{
	this->posOfBoss = posBoss;
	this->Init();
}

CHeadBoss::CHeadBoss(const std::vector<int>& info)
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

void CHeadBoss::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 6;
	this->m_idType = 17;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 192.0f;
	this->m_height = 160.0f;
	this->m_pos = D3DXVECTOR2(this->posOfBoss.x - 2.0f, this->posOfBoss.y + 155.0f);
	//Khoi tao cac thong so di chuyens
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.450f;
	this->m_increase = 1;
	this->m_totalFrame = 9;
	this->m_column = 3;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	this->m_stateCurrent = STATE_HEAD_BOSS::SHB_IS_NORMAL;
	this->m_HP = 50;
	//
	this->m_timeDelay = 0.450f;
	this->m_timeDelayWaitShoot = 2.80f;
	//
	this->m_isShoot = false;
	this->m_allowShoot = true;
}

void CHeadBoss::Update(float deltaTime)
{
	if (this->m_isALive)
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);
	}
	else
	{
		// Nguoc lai chi update dan thoi.
		this->BulletUpdate(deltaTime);
	}
}

void CHeadBoss::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
	else
		//play sound
		ManageAudio::GetInstance()->stopSound(TypeAudio::ENEMY_DEAD_SFX);
}

void CHeadBoss::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		if (this->m_currentFrame > 2 && this->m_currentFrame < 8)
		{
			CGameObject* obj = *it;
			timeCollision = CCollision::GetInstance()->Collision(obj, this, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				if (obj->IsAlive() && obj->GetLayer() == LAYER::PLAYER)
				{
					this->m_HP--;
					it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
					//
					CBulletEffect* effect = CPoolingObject::GetInstance()->GetBulletEffect();
					effect->SetAlive(true);
					effect->SetPos(obj->GetPos());
				}
				else
					++it;

				if (this->m_HP == 0)
				{
					// Gan trang thai die cho doi tuong
					this->m_stateCurrent = STATE_HEAD_BOSS::SHB_IS_DIE;
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
		else
			++it;
	}
}

void CHeadBoss::BulletUpdate(float deltaTime)
{
	// Kiem tra, neu Gun alive thi tao dan, nguoc lai chi update ma thoi.
	if (this->IsAlive())
	{
#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
		D3DXVECTOR2 offset1;
		offset1.x = 0.0f;
		offset1.y = -35.0f;
		D3DXVECTOR2 offset2;
		offset2.x = 0.0f;
		offset2.y = -37.0f;
#pragma endregion

#pragma region THIET LAP TOC DO DAN

		if (this->m_isShoot)
		{
			if (m_bulletCount >= 1)
			{
				this->m_bulletCount = 0;
				this->m_isShoot = false;
			}
#pragma region THIET LAP GOC BAN
			//Thiet lap vi tri cua 3 vien dan
#pragma endregion
			if (this->m_timeDelay >= 0.75f)
			{
				CBulletMechanicalAlien* bullet1 = new CBulletMechanicalAlien(-PI / 3, this->m_pos, offset1, !this->m_left);
				bullet1->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet1);

				CBulletMechanicalAlien* bullet2 = new CBulletMechanicalAlien(-PI/2, this->m_pos, offset2, this->m_left);
				bullet2->SetV(0.0f, 100.0f);
				bullet2->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet2);

				CBulletMechanicalAlien* bullet3 = new CBulletMechanicalAlien(-PI / 3, this->m_pos, offset1, this->m_left);
				bullet3->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet3);

				this->m_timeDelay = 0;
				m_bulletCount++;
			}

			m_timeDelay += deltaTime;
		}

	}
#pragma endregion
}

void CHeadBoss::SetFrame(float deltaTime)
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
		case STATE_HEAD_BOSS::SHB_IS_NORMAL:
		{
			this->m_startFrame = 0;
			this->m_endFrame = 2;
			//Time delay 2 s rui ban dan
			if (this->m_timeDelayWaitShoot <= 0.0f)
			{
				this->m_timeDelayWaitShoot = 2.80f;
				this->m_stateCurrent = STATE_HEAD_BOSS::SHB_IS_SHOOT;
			}
			else
				this->m_timeDelayWaitShoot -= deltaTime;
			break;
		}
		case STATE_HEAD_BOSS::SHB_IS_SHOOT:
		{
			this->m_startFrame = 1;
			this->m_endFrame = 8;
			if (this->m_currentFrame == 5)
				this->m_isShoot = true;
			break;
		}
		case  STATE_HEAD_BOSS::SHB_IS_DIE:
		{							  
			// Lay doi tuong ra
			CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect->SetAlive(true);
			effect->SetPos(D3DXVECTOR2(this->m_pos.x, this->m_pos.y - 20));

			this->m_isALive = false;
			break;
		}
	}
}

RECT* CHeadBoss::GetBound()
{
	return nullptr;
}

RECT* CHeadBoss::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CHeadBoss::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y - 21, this->m_width - 120, this->m_height - 82);
}
CHeadBoss::~CHeadBoss()
{

}