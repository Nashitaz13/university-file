#include "CFireBridge.h"
#include "CCollision.h"
#include "CContra.h"
#include "CPoolingObject.h"

CFireBridge::CFireBridge(D3DXVECTOR2 posBridge, bool isLeft)
{
	this->posOfBridge = posBridge;
	this->m_isLeft = isLeft;
	this->Init();
}

CFireBridge::CFireBridge(const std::vector<int>& info)
{
	this->Init();
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
}

void CFireBridge::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 4;
	this->m_idType = 16;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 32.0f;
	this->m_height = 32.0f;
	if (this->m_isLeft)
		this->m_pos = D3DXVECTOR2(posOfBridge.x + posOfBridge.x / 4, posOfBridge.y + 20);
	else
		this->m_pos = D3DXVECTOR2(posOfBridge.x - posOfBridge.x / 4, posOfBridge.y + 20);
	//Khoi tao cac thong so di chuyen
	this->m_left = m_isLeft;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0.0f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 2;
	this->m_column = 2;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	//
	this->m_vx = 80.0f;
	this->m_timeDelay = 0.40f;
	//	
	this->SetLayer(LAYER::ENEMY);
}

void CFireBridge::Update(float deltaTime)
{
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
	this->MoveUpdate(deltaTime);
}

void CFireBridge::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
	this->MoveUpdate(deltaTime);
	this->OnCollision(deltaTime, listObjectCollision);
}
void CFireBridge::MoveUpdate(float deltaTime)
{
	if (this->m_pos.x >= (this->posOfBridge.x + 112) || this->m_pos.x <= (this->posOfBridge.x - 112))
	{
		this->m_vx = -this->m_vx;
	}

	this->m_pos.x += this->m_vx* deltaTime;
}

void CFireBridge::SetFrame(float deltaTime)
{
	if (this->m_isALive)
	{
		this->m_startFrame = 0;
		this->m_endFrame = 1;
	}
}

RECT* CFireBridge::GetBound()
{
	return nullptr;
}

RECT* CFireBridge::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CFireBridge::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y - 4, this->m_width - 2, this->m_height - 8);
}

void CFireBridge::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	
}

CFireBridge::~CFireBridge()
{

}