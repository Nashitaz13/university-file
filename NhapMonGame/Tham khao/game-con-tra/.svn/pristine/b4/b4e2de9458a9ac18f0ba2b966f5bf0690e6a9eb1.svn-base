#include "CWordItem.h"
#include "CStateGamePlay.h"
#include "CStateManagement.h"

CWordItem::CWordItem(int number)
{
	this->m_numberWord = number;
	this->Init();
}

CWordItem::CWordItem(const std::vector<int>& info)
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
void CWordItem::InitWord()
{
	if (this->m_numberWord < 10)
	{
		
	}
	else
	{
		switch (this->m_numberWord)
		{
		case 10://a
			break;
		case 11://b
			break;
		case 12://c
			break;
		case 13://d
			break;
		case 14://e
			break;
		case 15://f
			break;
		case 16://g
			break;
		case 17://h
			break;
		case 18://i
			break;
		case 19://j
			break;
		case 20://k
			break;
		case 21://l
			break;
		case 22://m
			break;
		case 23://n
			break;
		case 24://o
			break;
		case 25://p
			break;
		case 26://q
			break;
		case 27://r
			break;
		case 28://s
			break;
		case 29://t
			break;
		case 30://u
			break;
		case 31://v
			break;
		case 32://w
			break;
		case 33://x
			break;
		case 34://y
			break;
		case 35://z
			break;
		}
	}
}
void CWordItem::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = this->m_numberWord;
	this->m_idType = 70;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 16.0f;
	this->m_height = 16.0f;
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
	this->m_endFrame = 1;
	//
	this->m_timeDelay = 3.0f;
}

void CWordItem::Update(float deltaTime)
{
	//this->ChangeFrame(deltaTime);
}
RECT* CWordItem::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

CWordItem::~CWordItem()
{

}