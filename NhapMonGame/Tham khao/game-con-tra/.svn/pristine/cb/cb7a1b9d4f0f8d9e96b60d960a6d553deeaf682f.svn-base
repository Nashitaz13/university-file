#include "CBridgeFire.h"
#include "CCollision.h"
#include "CContra.h"
#include "CPoolingObject.h"

CBridgeFire::CBridgeFire(void)
{
	this->Init();
}

CBridgeFire::CBridgeFire(const std::vector<int>& info)
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

void CBridgeFire::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 2;
	this->m_idType = 16;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 256.0f;
	this->m_height = 32.0f;
	//Khoi tao cac thong so di chuyen
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 2;
	this->m_column = 2;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	//
	this->m_timeDelay = 0.40f;

	//Khoi tao 2 cuc lua
	this->fireLeft = new CFireBridge(this->m_pos, true);
	this->fireRight = new CFireBridge(this->m_pos, false);
}

void CBridgeFire::Update(float deltaTime)
{
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
	this->fireLeft->Update(deltaTime);
	this->fireRight->Update(deltaTime);
}

void CBridgeFire::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
	this->fireLeft->Update(deltaTime, listObjectCollision);
	this->fireRight->Update(deltaTime, listObjectCollision);
}

void CBridgeFire::SetFrame(float deltaTime)
{
	if (this->m_isALive)
	{
		this->m_startFrame = 0;
		this->m_endFrame = 1;
	}
}

RECT* CBridgeFire::GetBound()
{
	return nullptr;
}

RECT* CBridgeFire::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CBridgeFire::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height - 10);
}

void CBridgeFire::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{

}


CBridgeFire::~CBridgeFire()
{

}