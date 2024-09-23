#include "CBulletS.h"
#include <math.h>
#include "CGlobal.h"
#include "CContra.h"

/**		
/	Class CBullet_S:
/		+ Chua set chuyen frame
/
*/
CBullet_S::CBullet_S()
{
	
	
}

CBullet_S::CBullet_S(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset)
{
	CBullet_S();
	this->Init();
	this->m_rotation = rotation;
	this->m_bullet_1 = new CBullet_M(rotation, pos, offset);
	this->m_bullet_2 = new CBullet_M(rotation + PI / 24, pos, offset);
	this->m_bullet_3 = new CBullet_M(rotation + PI / 12, pos, offset);
	this->m_bullet_4 = new CBullet_M(rotation - PI / 24, pos, offset);
	this->m_bullet_5 = new CBullet_M(rotation - PI / 12, pos, offset);
}

CBullet_S::CBullet_S(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction)
{
	this->Init();
	this->m_rotation = rotation;
	this->m_bullet_1 = new CBullet_M(rotation, pos, offset, direction);
	this->m_bullet_2 = new CBullet_M(rotation + PI / 24, pos, offset, direction);
	this->m_bullet_3 = new CBullet_M(rotation + PI / 12, pos, offset, direction);
	this->m_bullet_4 = new CBullet_M(rotation - PI / 24, pos, offset, direction);
	this->m_bullet_5 = new CBullet_M(rotation - PI / 12, pos, offset, direction);
}

void CBullet_S::SetLayer(LAYER layer)
{
	m_bullet_1->SetLayer(layer);
	m_bullet_2->SetLayer(layer);
	m_bullet_3->SetLayer(layer);
	m_bullet_4->SetLayer(layer);
	m_bullet_5->SetLayer(layer);
}

void CBullet_S::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 0;
	this->m_idType = 20;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 10.0f;//56.0f; //78
	this->m_height = 10.0f; //88.0f; //84
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_canJump = false;
	this->m_jumpMax = 40.0f;
	this->m_vxDefault = 200.0f;
	this->m_vyDefault = 400.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	//Chuyen doi sprite
	this->m_totalFrame= 3;
	this->m_column = 3;
	this->m_elapseTimeChangeFrame = 0.35f;
	this->m_currentTime = 0;
	this->m_increase = 1;
	this->m_currentFrame = 0;
}

void CBullet_S::MoveUpdate(float deltaTime)
{
#pragma region __XET_TRANG_THAI_DAN__
	if(m_vx != 0) 
	{
		if(this->m_vx > 0)
		{
			this->m_vx += this->m_a * deltaTime;
		}
		else
		{
			this->m_vx -= this->m_a * deltaTime;
		}
	}
	if(m_vy != 0)
	{
		if(this->m_vy > 0)
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
void CBullet_S::Update(float deltaTime)
{
	#pragma region CAP_NHAT_THONG_TIN_TUNG_VIEN_DAN
	this->m_bullet_1->MoveUpdate(deltaTime);
	this->m_bullet_2->MoveUpdate(deltaTime);
	this->m_bullet_3->MoveUpdate(deltaTime);
	this->m_bullet_4->MoveUpdate(deltaTime);
	this->m_bullet_5->MoveUpdate(deltaTime);
	#pragma endregion
	#pragma region CAP_NHAT_TRANG_THAI_TUNG_VIEN_DAN
	this->m_bullet_1->ChangeFrame(deltaTime);
	this->m_bullet_2->ChangeFrame(deltaTime);
	this->m_bullet_3->ChangeFrame(deltaTime);
	this->m_bullet_4->ChangeFrame(deltaTime);
	this->m_bullet_5->ChangeFrame(deltaTime);
	#pragma endregion
	//this->MoveUpdate(deltaTime);
}

void CBullet_S::ChangeFrame(float deltaTime)
{
	this->m_currentTime += deltaTime;
	if(this->m_currentTime > this->m_elapseTimeChangeFrame)
	{
		this->m_currentFrame += this->m_increase;
		if(this->m_currentFrame > 3 || this->m_currentFrame < 0)
		{
			this->m_currentFrame = 0;
		}
		this->m_currentTime -= this->m_elapseTimeChangeFrame;
	}
}


RECT* CBullet_S::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

void CBullet_S::Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision)
{
#pragma region CAP_NHAT_THONG_TIN_TUNG_VIEN_DAN
	this->m_bullet_1->MoveUpdate(deltaTime);
	this->m_bullet_2->MoveUpdate(deltaTime);
	this->m_bullet_3->MoveUpdate(deltaTime);
	this->m_bullet_4->MoveUpdate(deltaTime);
	this->m_bullet_5->MoveUpdate(deltaTime);
#pragma endregion
#pragma region CAP_NHAT_TRANG_THAI_TUNG_VIEN_DAN
	this->m_bullet_1->ChangeFrame(deltaTime);
	this->m_bullet_2->ChangeFrame(deltaTime);
	this->m_bullet_3->ChangeFrame(deltaTime);
	this->m_bullet_4->ChangeFrame(deltaTime);
	this->m_bullet_5->ChangeFrame(deltaTime);
#pragma endregion
}

void CBullet_S::OnCollision(float deltaTime, std::hash_map<int, CGameObject*>* listObjectCollision)
{

}


RECT* CBullet_S::GetBound()
{
	return nullptr;
}

CBullet_S::~CBullet_S()
{

}