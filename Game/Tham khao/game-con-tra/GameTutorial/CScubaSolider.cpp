#include "CScubaSolider.h"
#include "CContra.h"
#include <math.h>
#include "CCamera.h"
#include "CCollision.h"
#include "CPoolingObject.h"
#include "CManageAudio.h"

CScubaSolider::CScubaSolider(void)
{
	this->Init();
}

CScubaSolider::CScubaSolider(const std::vector<int>& info)
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

// Ham khoi tao cua linh nup
void CScubaSolider::Init()
{
	//Khoi tao cac thong so cua doi tuong
	// TT
	this->m_id = 5;
	this->m_idType = 11;
	this->m_idImage = 5;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 32.0f;
	this->m_height = 64.0f;
	this->m_left = false;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.60f;

	this->m_increase = 1;
	this->m_totalFrame = 4;
	this->m_column = 4;

	//
	this->m_isShoot = true;
	this->m_allowShoot = true;
	this->m_stateCurrent = SCUBAR_SOLIDER_STATE::SBS_IS_NORMAL;

	this->m_bulletCount = 0;
	this->m_timeDelay = 0.40f;
	this->m_timeDelay1 = 0.80f;
	this->m_waitForChangeSprite = 0.0f;

	//khoi tao gia tri no
	this->m_maxYRandom = this->m_pos.y + 190 + rand() % (101);
}

void CScubaSolider::Update(float deltaTime)
{

}

void CScubaSolider::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime, listObjectCollision);
		this->OnCollision(deltaTime, listObjectCollision);
	}
	else
		this->BulletUpdate(deltaTime, listObjectCollision);
}

void CScubaSolider::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;
	if ((this->m_currentFrame == 0) || (this->m_currentFrame == 1))
	{
		return;
	}
	else
	{
		for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
		{
			CGameObject* obj = *it;
			if (obj->IsAlive() && obj->GetLayer() == LAYER::PLAYER)
			{
				timeCollision = CCollision::GetInstance()->Collision(obj, this, normalX, normalY, moveX, moveY, deltaTime);
				if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
				{
					// Gan trang thai die cho doi tuong
					this->m_stateCurrent = SCUBAR_SOLIDER_STATE::SBS_IS_DIE;
					// Xoa vien dan ra khoi d.s
					CGameObject* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
					effect->SetAlive(true);
					effect->SetPos(this->m_pos);
					this->m_isALive = false;
					it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
					//Load sound die
					ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
					// Tang diem cua contra len
					CContra::GetInstance()->IncreateScore(1000);
				}
				else
					++it;
			}
			else
				++it;
		}
	}
}

void CScubaSolider::BulletUpdate(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
#pragma region THIET LAP GOC BAN

#pragma endregion

#pragma region THIET LAP TRANG THAI BAN
	//
	if (this->m_currentFrame == 2)
	{
		this->m_stateCurrent = SCUBAR_SOLIDER_STATE::SBS_IS_SHOOTING;
		this->m_isShoot = true;
	}
	else
	if (this->m_currentFrame == 0)
	{
		this->m_stateCurrent = SCUBAR_SOLIDER_STATE::SBS_IS_NORMAL;
		this->m_isShoot = false;
	}
#pragma endregion

#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
	D3DXVECTOR2 offset;
	offset.x = this->m_width /2 - 8;
	offset.y = 16;
#pragma endregion

#pragma region THIET LAP TOC DO DAN

	if (this->m_isShoot)
	{
		if (this->m_currentFrame == 3)
		{
			// tai vi no k chay vo day ne
			if (CPoolingObject::GetInstance()->m_listBulletScubaSolider.size() == 0)
			{
				CPoolingObject::GetInstance()->m_listBulletScubaSolider.clear();
				//
				CBullet_ScubaSolider* m_bullet_1 = new CBullet_ScubaSolider(PI / 2, this->m_pos, offset);
				m_bullet_1->SetAlive(true);
				m_bullet_1->SetV(0.0f, 5.0f);
				m_bullet_1->SetIsFirstBullet(true);
				m_bullet_1->m_time = 0;

				m_bullet_1->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletScubaSolider.push_back(m_bullet_1);
				this->m_isBullectExplosive = false;
			}
		}
	}
	//Update trang thai dan
	D3DXVECTOR3 pos, pos1;
	if (CPoolingObject::GetInstance()->m_listBulletScubaSolider.size() != 0)
	{
		for (int i = 0; i < CPoolingObject::GetInstance()->m_listBulletScubaSolider.size(); i++)
		{
			if (CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(i)->IsAlive())
			{
				pos.x = CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(i)->GetPos().x;
				pos.y = CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(i)->GetPos().y;

				if (pos.y >= this->m_maxYRandom && !m_isBullectExplosive)
				{
					//tao hieu ung no
					CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
					effect->SetAlive(true);
					effect->SetPos(CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(0)->GetPos());
					CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(0)->SetAlive(false);

					//Tao moi 3 vien dan kia
					CBullet_ScubaSolider* m_bullet_2 = new CBullet_ScubaSolider(PI / 2, CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(0)->GetPos(), D3DXVECTOR2(0, 0));
					m_bullet_2->SetV(0.0f, -6.0f);
					m_bullet_2->SetAlive(true);
					m_bullet_2->SetIsFirstBullet(false);
					m_bullet_2->SetLayer(LAYER::ENEMY);
					m_bullet_2->m_time = 0;
					//
					CBullet_ScubaSolider* m_bullet_3 = new CBullet_ScubaSolider(PI / 6, CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(0)->GetPos(), D3DXVECTOR2(0, 0));
					m_bullet_3->SetV(3.0f, -14.50f);
					m_bullet_3->SetAlive(true);
					m_bullet_3->SetIsFirstBullet(false);
					m_bullet_3->SetLayer(LAYER::ENEMY);
					m_bullet_3->m_time = 0;

					CBullet_ScubaSolider* m_bullet_4 = new CBullet_ScubaSolider(5 * PI / 6, CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(0)->GetPos(), D3DXVECTOR2(0, 0));
					m_bullet_4->SetV(3.0f, -14.50f);
					m_bullet_4->SetAlive(true);
					m_bullet_4->SetIsFirstBullet(false);
					m_bullet_4->SetLayer(LAYER::ENEMY);
					m_bullet_4->m_time = 0;

					//xoa khoi list & gan gia tri 
					this->m_isBullectExplosive = true;
					delete CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(0);
					CPoolingObject::GetInstance()->m_listBulletScubaSolider.clear();

					//
					CPoolingObject::GetInstance()->m_listBulletScubaSolider.push_back(m_bullet_2);
					CPoolingObject::GetInstance()->m_listBulletScubaSolider.push_back(m_bullet_3);
					CPoolingObject::GetInstance()->m_listBulletScubaSolider.push_back(m_bullet_4);
					//
				}
			}

			pos1 = CCamera::GetInstance()->GetPointTransform(pos.x, pos.y);
			if (pos1.x > __SCREEN_WIDTH || pos1.x < 0 || pos1.y > __SCREEN_HEIGHT || pos1.y < 0 ||
				!CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(i)->IsAlive())
			{
				delete CPoolingObject::GetInstance()->m_listBulletScubaSolider.at(i);
				CPoolingObject::GetInstance()->m_listBulletScubaSolider.erase(CPoolingObject::GetInstance()->m_listBulletScubaSolider.begin() + i);
			}
		}
	}

#pragma endregion
}

void CScubaSolider::SetFrame(float deltaTime)
{
	switch (this->m_stateCurrent)
	{
		case SCUBAR_SOLIDER_STATE::SBS_IS_NORMAL:
		{
			this->m_startFrame = 0;
			this->m_endFrame = 1;

			if (this->m_timeDelay1 <= 0.0f)
			{
				this->m_timeDelay1 = 0.80f;
				if (this->m_pos.y < CContra::GetInstance()->GetPos().y)
					this->m_stateCurrent = SCUBAR_SOLIDER_STATE::SBS_IS_SHOOTING;
			}
			else
				this->m_timeDelay1 -= deltaTime;
			break;
		}
		case SCUBAR_SOLIDER_STATE::SBS_IS_SHOOTING:
		{
			if (this->m_isShoot)
			{
				this->m_startFrame = 2;
				this->m_endFrame = 3;

				if (this->m_timeDelay <= 0.0f)
				{
					if (this->m_currentFrame == 2)
					{
						this->m_bulletCount = 0;
					}
					this->m_timeDelay = 0.40f;
					this->m_stateCurrent = SCUBAR_SOLIDER_STATE::SBS_IS_NORMAL;
				}
				else
					this->m_timeDelay -= deltaTime;
			}
			else
			{
				this->m_startFrame = 2;
				this->m_endFrame = 2;
			}
			break;
		}
		case SCUBAR_SOLIDER_STATE::SBS_IS_DIE:
		{
			this->m_currentFrame = 2;
			this->m_startFrame = 2;
			this->m_endFrame = 2;
			// dich chuyen doi tuong.
			if (this->m_waitForChangeSprite <= 0.2f)
			{
				this->m_waitForChangeSprite += deltaTime;
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
	}
}


RECT* CScubaSolider::GetBound()
{
	return nullptr;
}

RECT* CScubaSolider::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CScubaSolider::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y - 15, this->m_width, this->m_height - 32, 0, 0);
}

CScubaSolider::~CScubaSolider()
{

}