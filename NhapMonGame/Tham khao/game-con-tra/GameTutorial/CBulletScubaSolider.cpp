#include "CBulletScubaSolider.h"
#include <math.h>
#include "CGlobal.h"
#include "CContra.h"
#include "CCollision.h"
#include "CLoadGameObject.h"
#include "CPoolingObject.h"

CBullet_ScubaSolider::CBullet_ScubaSolider()
{
	this->m_rotation = 0; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
	this->m_offset = D3DXVECTOR2(0.0f, 0.0f);
	this->Init();
}

CBullet_ScubaSolider::CBullet_ScubaSolider(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

CBullet_ScubaSolider::CBullet_ScubaSolider(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = direction;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

void CBullet_ScubaSolider::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 3;
	this->m_idType = 20;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = false;
	this->m_width = 18.0f;//56.0f; //78
	this->m_height = 18.0f; //88.0f; //84
	//Khoi tao cac thong so di chuyen
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_canJump = false;
	this->m_vxDefault = 10.0f;
	this->m_vyDefault = 12.0f;
	this->m_isFirstBullet = false;
	this->m_time = 0;
	//
	this->m_pos += this->m_offset; //Vi tri cua vien dan
	this->SetLayer(LAYER::ENEMY);
}

void CBullet_ScubaSolider::MoveUpdate(float deltaTime)
{
#pragma region __SET_TOA_DO_DAN__

	m_time += deltaTime;

	//xet van toc cho vx
	this->m_pos.x += this->m_vxDefault * cos(this->m_rotation) * m_time;
	this->m_pos.y += 3.50f + this->m_vyDefault * sin(this->m_rotation) * m_time - this->m_a * m_time*m_time / 2;
#pragma endregion

}

void CBullet_ScubaSolider::Update(float deltaTime)
{
	
}

void CBullet_ScubaSolider::Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision)
{
	if (this->IsAlive())
	{
		this->MoveUpdate(deltaTime);
		this->OnCollision(deltaTime, _listObjectCollision);
	}
	// collion
}

void CBullet_ScubaSolider::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	std::vector<CGameObject*>::iterator it;

	// kiem tra co phai la vien dan dau tien hay k
	if (!this->m_isFirstBullet)
	{
		for (it = listObjectCollision->begin();
			it != listObjectCollision->end(); ++it)
		{
			CGameObject* obj = *it;
			// Neu doi tuong la ground
			if (obj->GetIDType() == 15 && (obj->GetID() == 1 || obj->GetID() == 8))
			{
				timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
				if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
				{
					if (normalY > 0)
					{
						if (this->m_vy <= 0)
						{
							// Gan trang thai die cho doi tuong
							CGameObject* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
							effect->SetAlive(true);
							effect->SetPos(this->m_pos);

							this->SetAlive(false);
						}
					}
				}
			}
		}
	}
}

RECT* CBullet_ScubaSolider::GetRectRS()
{
	RECT* rs = new RECT();
	rs->left = 0;
	rs->right = this->m_width;
	rs->top = 0;
	rs->bottom = this->m_height;
	return rs;
}

RECT* CBullet_ScubaSolider::GetBound()
{
	return nullptr;
}

Box CBullet_ScubaSolider::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 4, this->m_height - 4, 0, 0);
}

CBullet_ScubaSolider::~CBullet_ScubaSolider()
{

}
void CBullet_ScubaSolider::SetIsFirstBullet(bool isFirst)
{
	this->m_isFirstBullet = isFirst;
}