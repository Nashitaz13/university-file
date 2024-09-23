#include "CEffectBackground.h"
#include "CCollision.h"
#include "CContra.h"
#include "CPoolingObject.h"

CEffect_Background::CEffect_Background(void)
{
}

CEffect_Background::CEffect_Background(const std::vector<int>& info)
{

	//if (!info.empty())
	//{
	//	this->m_id = info.at(0) % 1000;
	//	this->m_idType = info.at(0) / 1000;
	//	this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
	//	this->m_width = info.at(3);
	//	this->m_height = info.at(4);
	//}
	//this->Init();//
}

void CEffect_Background::Init(int col, int totalFrame, float frameWidth, float frameHeight, int frameStart, int frameEnd, int id)
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = id;
	this->m_idType = 50;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = frameWidth;
	this->m_height = frameHeight;
	//Khoi tao cac thong so di chuyen
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0.0f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = totalFrame;
	this->m_column = col;
	this->m_startFrame = frameStart;
	this->m_endFrame = frameEnd;
	//Cai nay tuy cai hieu ung, viet them cai phuong thuc truyen vao cai column, totalFrame, width, height
}

void CEffect_Background::Update(float deltaTime)
{	this->ChangeFrame(deltaTime);
}

void CEffect_Background::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->ChangeFrame(deltaTime);
}


RECT* CEffect_Background::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

CEffect_Background::~CEffect_Background()
{

}