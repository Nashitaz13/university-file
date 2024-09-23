#include "CBulletCapsule.h"
#include <math.h>
#include "CGlobal.h"
#include "CContra.h"
#include "CCollision.h"
#include "CLoadGameObject.h"
#include "CPoolingObject.h"

CBullet_Capsule::CBullet_Capsule()
{
	this->m_rotation = 0; //Lay sin cua goc
	this->m_left = true;
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
	this->m_offset = D3DXVECTOR2(0.0f, 0.0f);
	this->Init();
}

CBullet_Capsule::CBullet_Capsule(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

CBullet_Capsule::CBullet_Capsule(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = !direction;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

void CBullet_Capsule::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 12;
	this->m_idType = 20;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = false;
	this->m_width = 12.0f;
	this->m_height = 12.0f;
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = true;
	this->m_isMoveRight = false;
	this->m_canJump = false;
	this->m_vxDefault = 0.0f;
	this->m_vyDefault = 130.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_a = 2.0f;
	this->m_time = 0.0f;
	this->m_left = true;
	//
	this->m_currentFrame = 0;
	this->m_totalFrame = 1;
	this->m_column = 1;
	if (!this->m_left)
	{
		this->m_vx = -this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = -this->m_vyDefault * sin(this->m_rotation);
	}
	else
	{
		this->m_vx = this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = this->m_vyDefault * sin(this->m_rotation);
	}

	this->m_pos += this->m_offset; //Vi tri cua vien dan
	this->m_layer = LAYER::ENEMY;
}

void CBullet_Capsule::MoveUpdate(float deltaTime)
{
#pragma region ___SET_TOA_DO_DAN__
	if (m_vx != 0)
	{
		if (this->m_vx > 0)
		{
			this->m_vx += this->m_a * deltaTime;
		}
		else
		{
			this->m_vx -= this->m_a * deltaTime;
		}
	}
	if (m_vy != 0)
	{
		if (this->m_vy > 0)
		{
			this->m_vy += this->m_a * deltaTime;
		}
		else
		{
			this->m_vy -= this->m_a * deltaTime;
		}
	}
	this->m_pos.x += this->m_vx * deltaTime;
	this->m_pos.y += this->m_vy * deltaTime;
#pragma endregion
}
void CBullet_Capsule::Update(float deltaTime)
{
	if (this->IsAlive())
		this->MoveUpdate(deltaTime);
}

void CBullet_Capsule::Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision)
{
	// collion
	if (this->IsAlive()){
		this->MoveUpdate(deltaTime);
		this->OnCollision(deltaTime, _listObjectCollision);
	}
}

void CBullet_Capsule::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	std::vector<CGameObject*>::iterator it;
	std::vector<CBullet*>::iterator cit;
	//Xet va cham giua dan voi dat
	for (it = listObjectCollision->begin(); it != listObjectCollision->end(); ++it)
	{
		CGameObject* obj = *it;
		// Neu doi tuong la ground
		if (obj->GetIDType() == 15 && (obj->GetID() == 1 || obj->GetID() == 8))
		{
			timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				// Gan trang thai die cho doi tuong
				CGameObject* obj = CPoolingObject::GetInstance()->GetExplosionEffect();
				obj->SetAlive(true);
				obj->SetPos(this->m_pos);
				this->m_isALive = false;
			}
		}
	}
	//Xet va cham dan boss voi dan contra
	for (cit = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); cit != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CGameObject* bObj = *cit;
		if (bObj->IsAlive() && bObj->GetLayer() == LAYER::PLAYER)
		{
			if (CCollision::GetInstance()->Collision(bObj, this))
			{
				cit = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(cit);

				CGameObject* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
				effect->SetAlive(true);
				effect->SetPos(this->m_pos);
				this->m_isALive = false;
			}
			else
				++cit;
		}
		else
			++cit;
	}
}

RECT* CBullet_Capsule::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

RECT* CBullet_Capsule::GetBound()
{
	return nullptr;
}

Box CBullet_Capsule::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 2, this->m_height - 2, 0, 0);
}

CBullet_Capsule::~CBullet_Capsule()
{

}