#include "CChooseItem.h"
#include "CInput.h"
#include "CStateGamePlay.h"
#include "CStateManagement.h"

CChooseItem::CChooseItem(void)
{
	this->Init();
}

CChooseItem::CChooseItem(const std::vector<int>& info)
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

void CChooseItem::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 3;
	this->m_idType = 60;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 32;
	this->m_height = 20;
	//Khoi tao cac thong so di chuyen
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 1;
	this->m_column = 1;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	//
	this->m_SelectedId = 0;
}

RECT* CChooseItem::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

CChooseItem::~CChooseItem()
{

}