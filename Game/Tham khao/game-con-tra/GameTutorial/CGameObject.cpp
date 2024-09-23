#include "CGameObject.h"
using namespace std;

CGameObject::CGameObject(void)
{
	//_ID = 0;
	m_isALive = true;
	m_rectRS = NULL;
	m_isAnimatedSprite = false;
	this->m_height = 0;
	this->m_width = 0;
	this->m_posZ = 0;
	this->m_allowShoot = false;
}

CGameObject::CGameObject(const std::vector<int>& info)
{
	if(!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos.x = info.at(1);
		this->m_pos.y = info.at(2);
	}
	this->m_posZ = 0;
}

CGameObject::~CGameObject(void)
{
}

std::string CGameObject::ClassName()
{
	return __CLASS_NAME__(CGameObject);
}

void CGameObject::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{

}

void CGameObject::Update(float deltaTime)
{

}

void CGameObject::SetPos(D3DXVECTOR2 pos)
{
	this->m_pos = pos;
}

void CGameObject::SetAlive(bool alive)
{
	this->m_isALive = alive;
}

void CGameObject::SetLeft(bool left)
{
	this->m_left = left;
}

//Dung de xet va cham + xen trong quad tree
Box CGameObject::GetBox()
{
	return Box(this->m_pos, this->m_width, this->m_height, 0, 0);
}

RECT* CGameObject::GetBound()
{
	RECT* rect = new RECT();
	rect->top = this->m_pos.y;
	rect->left = this->m_pos.x;
	rect->bottom = rect->top + this->m_height;
	rect->right = rect->left + this->m_width;
	return rect;
}

RECT* CGameObject::GetRectRS()
{
	return NULL;
}