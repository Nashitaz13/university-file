#include "CBridgeStone.h"
#include "CCollision.h"
#include "CContra.h"

CBridgeStone::CBridgeStone(void)
{
	this->Init();
}

CBridgeStone::CBridgeStone(const std::vector<int>& info)
{
	this->Init();//
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);

		this->m_minX = this->m_pos.x - this->m_radius;
		this->m_maxX = this->m_pos.x + this->m_radius;
	}
}

void CBridgeStone::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 3;
	this->m_idType = 16;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 64.0f;
	this->m_height = 62.0f; 
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_a = 700.0f;
	this->m_canJump = false;
	this->m_jumpMax = 0.0f;
	//this->m_currentJump = 0.0f;
	this->m_vxDefault = 60.0f;
	this->m_vyDefault = 100.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_left = false;
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.10f;
	this->m_increase = 1;
	this->m_totalFrame = 1;
	this->m_column = 1;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	//
	this->m_radius = 100.0f;
}

void CBridgeStone::Update(float deltaTime)
{
	this->MoveUpdate(deltaTime);
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
}

void CBridgeStone::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->MoveUpdate(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
}

void CBridgeStone::SetFrame(float deltaTime)
{
	this->m_startFrame = 0;
	this->m_endFrame = 0;
}
void CBridgeStone::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
}

void CBridgeStone::setRadius(float r)
{
	this->m_radius = r;
}

void CBridgeStone::MoveUpdate(float deltaTime)
{
	if (this->m_pos.x > this->m_maxX){
		this->m_vx = -this->m_vxDefault;
	}
	else if(this->m_pos.x < this->m_minX){
		this->m_vx = +this->m_vxDefault;
	}

	this->m_pos.x += this->m_vx * deltaTime;
}
RECT* CBridgeStone::GetBound()
{
	return nullptr;
}

RECT* CBridgeStone::GetRectRS()
{
	RECT* rs = new RECT();
	rs->left = 0;
	rs->right = this->m_width;
	rs->top = 0;
	rs->bottom = this->m_height;
	return rs;
}

Box CBridgeStone::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y - 5, this->m_width, this->m_height - 10, this->m_vx, this->m_vy);
}

float CBridgeStone::GetVx()
{
	return this->m_vx;
}

CBridgeStone::~CBridgeStone()
{

}