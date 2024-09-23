#include "CBulletLaze.h"
#include <math.h>
#include "CGlobal.h"
#include "CContra.h"
#include "CCollision.h"
#include "CLoadGameObject.h"
#include "CPoolingObject.h"

CBulletLaze::CBulletLaze()
{
	this->m_rotation = 0; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = D3DXVECTOR2(100.0f, 300.0f);
	this->m_offset = D3DXVECTOR2(0.0f, 0.0f);
	this->Init();
}

CBulletLaze::CBulletLaze(const std::vector<int>& info)
{
	this->Init();//
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
}

CBulletLaze::CBulletLaze(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

CBulletLaze::CBulletLaze(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = !direction;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

void CBulletLaze::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 5;
	this->m_idType = 12;
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 28.0f;
	this->m_height = 28.0f;
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = true;
	this->m_isMoveRight = false;
	this->m_canJump = false;
	this->m_vxDefault = 2.10f;
	this->m_vyDefault = 0.0000001f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_a = 9.80f;
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.10f;
	this->m_stateCurrent = LAZE_STATE::LAZ_IS_NORMAL;
	this->m_increase = 1;
	this->m_totalFrame = 4;
	this->m_column = 4;
	this->m_rotation = PI / 6;
	this->m_time = 0;
	//
	this->m_timeDelay = 0.10f;

	if (!this->m_left)
	{
		this->m_vx = this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = this->m_vyDefault * sin(this->m_rotation);
	}
	else
	{
		this->m_vx = -this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = this->m_vyDefault * sin(this->m_rotation);
	}

	if (!this->m_left)
	{
		this->m_pos += this->m_offset; //Vi tri cua vien dan
	}
}

void CBulletLaze::MoveUpdate(float deltaTime)
{
#pragma region __SET_TOA_DO_DAN__

	this->m_time += deltaTime;

	this->m_pos.x += this->m_vx * this->m_time;
	this->m_pos.y += 2.90f + this->m_vy*this->m_time - this->m_a * this->m_time*this->m_time / 2;

#pragma endregion
}

void CBulletLaze::Update(float deltaTime)
{

}

void CBulletLaze::Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision)
{
	// collion
	if (this->IsAlive())
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->MoveUpdate(deltaTime);
		this->OnCollision(deltaTime, _listObjectCollision);
	}
}
void CBulletLaze::SetFrame()
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
	case LAZE_STATE::LAZ_IS_NORMAL:
	{
		this->m_startFrame = 0;
		this->m_endFrame = 3;
		break;
	}
	case LAZE_STATE::LAZ_IS_DIE:
	{
		CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
		effect->SetAlive(true);
		effect->SetPos(this->m_pos);
		this->m_isALive = false;
		break;
	}
	}
}
void CBulletLaze::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	std::vector<CGameObject*>::iterator it;

	// va cham voi ground
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
				this->m_stateCurrent = LAZE_STATE::LAZ_IS_DIE;
			}
		}
	}
	// va cham voi contra

}

RECT* CBulletLaze::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

RECT* CBulletLaze::GetBound()
{
	return nullptr;
}

Box CBulletLaze::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 2, this->m_height - 2, 0, 0);
}

CBulletLaze::~CBulletLaze()
{

}