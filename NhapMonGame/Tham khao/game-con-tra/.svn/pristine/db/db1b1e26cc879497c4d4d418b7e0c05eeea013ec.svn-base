#include "CBulletL.h"

/**		
/	Class CBullet:
/		+ Chua set chuyen frame
/
*/
CBullet_L::CBullet_L() : CBullet()
{

	this->m_rotation = 0; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
	this->m_offset = D3DXVECTOR2(0.0f, 0.0f);
	this->Init();
	
}

CBullet_L::CBullet_L(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset)
{
	CBullet_L();
	//
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = false;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

CBullet_L::CBullet_L(double rotation, D3DXVECTOR2 pos, D3DXVECTOR2 offset, bool direction)
{
	CBullet_L();
	//
	this->m_rotation = rotation; //Lay sin cua goc
	this->m_left = direction;
	this->m_pos = pos;
	this->m_offset = offset;
	this->Init();
}

void CBullet_L::Init()
{
	//Khoi tao cac thong so cua doi tuong
	//
	this->m_id = 2;
	this->m_idType = 20;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 125.0f;//112.0f;//56.0f; //78
	this->m_height = 13.0f;//17.63f; //88.0f; //84
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_canJump = false;
	this->m_vxDefault = 200.0f;
	this->m_vyDefault = 200.0f;
	//Chuyen doi sprite
	this->m_totalFrame = 11;
	this->m_column = 1;
	this->m_elapseTimeChangeFrame = 0.05f;
	this->m_currentTime = 0;
	this->m_increase = 1;
	this->m_currentFrame = 0;
	this->m_startFrame = 0;
	this->m_endFrame = 10;

	this->m_stateRotation = L_ROTATION::L;

	if(!this->m_left)
	{
		this->m_vx = this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = this->m_vyDefault * sin(this->m_rotation);
	}
	else
	{
		this->m_vx = -this->m_vxDefault * cos(this->m_rotation);
		this->m_vy = this->m_vyDefault * sin(this->m_rotation);
	}
	
	if(!this->m_left)
	{
		if (this->m_rotation == (float)PI / 2)
		{
			this->m_stateRotation = L_ROTATION::L_PI_2;
			this->m_drawRotation = -PI / 2;
		}
		else if (this->m_rotation == (float)PI / 4){
			this->m_stateRotation = L_ROTATION::L_PI_4;
			this->m_drawRotation = -PI / 4;
		}
		else if (this->m_rotation == (float)-PI / 4){
			this->m_stateRotation = L_ROTATION::L_PI7_4;
			this->m_drawRotation = -7 * PI / 4;
		}
	}
	else
	{
		//Neu la ban len
		if(this->m_rotation == (float)PI/2)
		{
			this->m_stateRotation = L_ROTATION::L_PI_2;
			this->m_drawRotation = -PI / 2;
		}
		else if (this->m_rotation == (float)PI / 4){
			this->m_stateRotation = L_ROTATION::L_PI_4;
			this->m_drawRotation = -3 * PI / 4;
		}
		else if (this->m_rotation == (float)-PI / 4){
			this->m_stateRotation = L_ROTATION::L_PI5_4;
			this->m_drawRotation = -5 * PI / 4;
		}
	}
	this->m_pos += this->m_offset;
}

void CBullet_L::MoveUpdate(float deltaTime)
{
#pragma region __SET_TOA_DO_DAN__

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

void CBullet_L::Update(float deltaTime)
{
	this->MoveUpdate(deltaTime);
	this->ChangeFrame(deltaTime);

}
void CBullet_L::Update(float deltaTime, std::vector<CGameObject*>* _listObjectCollision)
{
	this->MoveUpdate(deltaTime);
	this->ChangeFrame(deltaTime);
}

void CBullet_L::OnCollision(float deltaTime, std::hash_map<int, CGameObject*>* listObjectCollision)
{
	this->MoveUpdate(deltaTime);
	this->ChangeFrame(deltaTime);
}


void CBullet_L::ChangeFrame(float deltaTime)
{
	if(this->m_currentFrame != this->m_endFrame)
	{
		this->m_currentTime += deltaTime;
		if(this->m_currentTime > this->m_elapseTimeChangeFrame)
		{
			this->m_currentFrame += this->m_increase;
			if(this->m_currentFrame > this->m_endFrame || this->m_currentFrame < this->m_startFrame)
			{
				this->m_currentFrame = 0;
			}
			this->m_currentTime -= this->m_elapseTimeChangeFrame;
		}
	}
}


RECT* CBullet_L::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

RECT* CBullet_L::GetBound()
{
	return nullptr;
}

Box CBullet_L::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 4, this->m_height - 4, this->m_vx, this->m_vy);
}

int CBullet_L::getStateRotation()
{
	return this->m_stateRotation;
}

float CBullet_L::getDrawRotation()
{
	return this->m_drawRotation;
}

CBullet_L::~CBullet_L()
{

}