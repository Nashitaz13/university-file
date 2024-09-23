#include "DynamicObject.h"


CDynamicObject::CDynamicObject(void)
{
	this->m_isMoveLeft = false;
	this->m_isMoveRight = false;
	this->m_canJump = 0;
	this->m_left = false;
	this->m_vx = 0;
	this->m_vy = 0;
	this->m_jumpMax = 0;
}

CDynamicObject::CDynamicObject(std::vector<std::string> arr) : CGameObject(arr)
{

}

CDynamicObject::~CDynamicObject(void)
{
}

void CDynamicObject::MoveUpdate(float deltaTime)
{
	if (this->m_pos.x < this->m_width / 2)
		this->m_pos.x = this->m_width / 2;

	if (this->m_isMoveLeft)
	{
		if (this->m_vx < 0)
		{
			this->m_pos.x += this->m_vx * deltaTime;
		}
	}

	if (this->m_isMoveRight)
	{
		if (this->m_vx > 0)
		{
			this->m_pos.x += this->m_vx * deltaTime;
		}
	}

	//this->m_pos.y += this->m_vy * deltaTime;
	//if (this->m_pos.y < 0)
	//{
	//	this->m_isALive = false;//die
	//}
}

std::string CDynamicObject::ClassName()
{
	return __CLASS_NAME__(CDynamicObject);
}

void CDynamicObject::Update(float deltaTime)
{

}

void CDynamicObject::Update(float deltaTime, std::vector<CGameObject*> listObjectCollision)
{
	this->MoveUpdate(deltaTime);
	//this->move(delta_Time);
}
