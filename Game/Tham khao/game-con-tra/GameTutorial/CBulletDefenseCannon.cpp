#include "CBulletDefenseCannon.h"
#include <math.h>
#include "CGlobal.h"
#include "CContra.h"
#include "CCollision.h"
#include "CLoadGameObject.h"
#include "CPoolingObject.h"

CBullet_DefenseCannon::CBullet_DefenseCannon()
{
	this->m_rotation = 0; //Lay sin cua goc
	this->m_left = true;
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
	this->m_offset = D3DXVECTOR2(0.0f, 0.0f);
	this->Init();
}

CBullet_DefenseCannon::CBullet_DefenseCannon(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

CBullet_DefenseCannon::CBullet_DefenseCannon(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = !direction;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

void CBullet_DefenseCannon::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 9;
	this->m_idType = 20;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = false;
	this->m_width = 18.0f;
	this->m_height = 18.0f;
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = true;
	this->m_isMoveRight = false;
	this->m_canJump = false;
	this->m_vxDefault = 5.0f;
	this->m_vyDefault = 10.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_a = 22.0f;
	this->m_time = 0.0f;

	if (!this->m_left)
	{
		this->m_vx = (float)-this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = (float)-this->m_vyDefault * sin(this->m_rotation);
	}
	else
	{
		this->m_vx = (float)this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = (float)this->m_vyDefault * sin(this->m_rotation);
	}

	if (!this->m_left)
	{
		this->m_pos += this->m_offset; //Vi tri cua vien dan
	}
}

void CBullet_DefenseCannon::MoveUpdate(float deltaTime)
{
#pragma region ___SET_TOA_DO_DAN__
	m_time += deltaTime;

	this->m_pos.x += (float)this->m_vx * m_time;
	this->m_pos.y += (float)(3.0f + this->m_vy*m_time - this->m_a * m_time*m_time / 2);
#pragma endregion
}
void CBullet_DefenseCannon::Update(float deltaTime)
{
	this->MoveUpdate(deltaTime);
}

void CBullet_DefenseCannon::Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision)
{
	if (this->IsAlive())
	{
		this->MoveUpdate(deltaTime);
		this->OnCollision(deltaTime, _listObjectCollision);
	}
}

void CBullet_DefenseCannon::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	std::vector<CGameObject*>::iterator it;

	for (it = listObjectCollision->begin();
		it != listObjectCollision->end(); ++it)
	{
		CGameObject* obj = *it;
		// Neu doi tuong la ground
		float possY = obj->GetPos().y;
		if (obj->GetIDType() == 15 && (obj->GetID() == 1 || obj->GetID() == 8) && possY <= 45)
		{
			timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				CGameObject* obj =  CPoolingObject::GetInstance()->GetExplosionEffect();
				obj->SetAlive(true);
				obj->SetPos(this->m_pos);
				this->m_isALive = false;

			}
		}
	} 
}

RECT* CBullet_DefenseCannon::GetRectRS()
{
	RECT* rs = new RECT();
	rs->left = 0;
	rs->right = this->m_width;
	rs->top = 0;
	rs->bottom = this->m_height;
	return rs;
}

RECT* CBullet_DefenseCannon::GetBound()
{
	return nullptr;
}

Box CBullet_DefenseCannon::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 2, this->m_height - 2, 0, 0);
}

CBullet_DefenseCannon::~CBullet_DefenseCannon()
{

}