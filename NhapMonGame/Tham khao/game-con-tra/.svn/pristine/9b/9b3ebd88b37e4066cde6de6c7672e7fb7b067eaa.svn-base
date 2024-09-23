#include "CBulletMechanicalAlien.h"
#include <math.h>
#include "CGlobal.h"
#include "CContra.h"
#include "CCollision.h"
#include "CLoadGameObject.h"
#include "CPoolingObject.h"

CBulletMechanicalAlien::CBulletMechanicalAlien()
{
	this->m_rotation = 0; //Lay sin cua goc
	this->m_left = true;
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
	this->m_offset = D3DXVECTOR2(0.0f, 0.0f);
	this->Init();
}

CBulletMechanicalAlien::CBulletMechanicalAlien(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

CBulletMechanicalAlien::CBulletMechanicalAlien(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction)
{
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = !direction;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

void CBulletMechanicalAlien::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 11;
	this->m_idType = 20;
	this->m_idImage = 0;
	this->m_isALive = true;
	//this->m_isAnimatedSprite = true;
	this->m_width = 32.0f;
	this->m_height = 32.0f;
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = true;
	this->m_isMoveRight = false;
	this->m_canJump = false;
	this->m_vxDefault = 130.0f;
	this->m_vyDefault = 130.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_a = 22.0f;
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 4;
	this->m_column = 4;
	//
	this->m_timeDelay = 0.40f;

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

	this->m_pos += this->m_offset; //Vi tri cua vien dan
}

void CBulletMechanicalAlien::MoveUpdate(float deltaTime)
{
#pragma region __SET_TOA_DO_DAN__

	if (this->m_vxDefault == 0)
	{
		this->m_vx = 0.0f;
	}

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

void CBulletMechanicalAlien::Update(float deltaTime)
{
	this->SetFrame();
	this->ChangeFrame(deltaTime);
	this->MoveUpdate(deltaTime);
}

void CBulletMechanicalAlien::Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision)
{
	if (this->IsAlive())
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->MoveUpdate(deltaTime);
	}
}
void CBulletMechanicalAlien::SetFrame()
{
	//chuyeenr doi frame
	this->m_startFrame = 0;
	this->m_endFrame = 3;
}
void CBulletMechanicalAlien::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{

}

RECT* CBulletMechanicalAlien::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

RECT* CBulletMechanicalAlien::GetBound()
{
	return nullptr;
}

Box CBulletMechanicalAlien::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 4, this->m_height - 4, 0, 0);
}

CBulletMechanicalAlien::~CBulletMechanicalAlien()
{

}