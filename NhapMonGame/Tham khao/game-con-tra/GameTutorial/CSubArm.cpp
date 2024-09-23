#include "CSubArm.h"
#include "CPoolingObject.h"
#include "CCollision.h"
#include "CBulletMechanicalAlien.h"
#include "CManageAudio.h"

CSubArm::CSubArm()
{
	this->Init();
}


CSubArm::~CSubArm()
{
	
}

void CSubArm::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_idType = 17; 
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 32.0f;//56.0f; //78
	this->m_height = 32.0f; //88.0f; //84
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_a = -700.0f;
	this->m_canJump = true;
	this->m_jumpMax = 40.0f;
	this->m_vxDefault = 50.0f;
	this->m_vyDefault = 50.0f;
	this->m_vx = 0;
	this->m_vy = -this->m_vyDefault;
	this->m_left = false;
	this->m_HP = 20;
	//
	this->m_angleDefault = 0.08f;
	this->m_curveCurr = 0.0f;
	this->m_rotation = PI/4;
	this->m_angle = 0;
	this->m_radian = 0.0f;
	this->m_posCenter = D3DXVECTOR2(0.0f, 0.0f);
	switch (this->m_armType)
	{
	case SUB_ARM_TYPE::SUB_ARM_FIRST:
		{
			this->m_id = 8;
			this->m_allowShoot = true;
			this->m_isShoot = false;
			this->m_bulletCount = 0;
			this->m_timeDelayWaitShoot = 3.20f;
			break;
		}
	case SUB_ARM_TYPE::SUB_ARM_COMPONENT:
		{
			this->m_id = 7;
			this->m_allowShoot = false;
			break;
		}
	default:
		this->m_id = 8;
		break;
	}
	this->m_waitForHandAppear = 0.0f;
}

void CSubArm::Update(float deltaTime)
{
	this->m_waitForHandAppear += deltaTime;
	if(this->m_waitForHandAppear > this->WaitForAppear)
	{
		if (this->m_HP > 0)
		{
			this->m_isALive = true;
			if (this->m_id == 8)
				this->BulletUpdate(deltaTime);
		}
	}
}

void CSubArm::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->m_waitForHandAppear += deltaTime;
	if (this->m_waitForHandAppear > this->WaitForAppear)
	{
		if (this->m_HP > 0)
		{
			this->m_isALive = true;
			if (this->m_id == 8)
				this->BulletUpdate(deltaTime);
		}
	}
}

void CSubArm::BulletUpdate(float deltaTime)
{
	// Kiem tra, neu Gun alive thi tao dan, nguoc lai chi update ma thoi.
	if (this->IsAlive())
	{
#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
		D3DXVECTOR2 offset;
		offset.x = 0.0f;
		offset.y = 0.0f;
#pragma endregion

#pragma region THIET LAP TOC DO DAN

		if (this->m_isShoot)
		{
			if (m_bulletCount >= 1)
			{
				this->m_bulletCount = 0;
				this->m_isShoot = false;
			}
#pragma region THIET LAP GOC BAN
			//Thiet lap vi tri cua 3 vien dan
#pragma endregion
			if (this->m_timeDelayWaitShoot >= 3.20f)
			{
				CBulletMechanicalAlien* bullet = new CBulletMechanicalAlien(this->m_angle, this->m_pos, offset, !this->m_left);
				bullet->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				this->m_timeDelayWaitShoot = 0;
				m_bulletCount++;
				//Load sound
				ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_ATTACKED_SFX);
			}

			this->m_timeDelayWaitShoot += deltaTime;
		}

	}
#pragma endregion
}

void CSubArm::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CGameObject* obj = *it;
		timeCollision = CCollision::GetInstance()->Collision(obj, this, normalX, normalY, moveX, moveY, deltaTime);
		if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
		{
			if (obj->IsAlive() && obj->GetLayer() == LAYER::PLAYER)
			{
				this->m_HP--;
				it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
				//
				CBulletEffect* effect = CPoolingObject::GetInstance()->GetBulletEffect();
				effect->SetAlive(true);
				effect->SetPos(obj->GetPos());
			}
			else
				++it;

			if (this->m_HP == 0)
			{
				this->m_isALive = false;
			}
		}
		else
		{
			++it;
		}
	}
}

void CSubArm::MoveUpdate(float deltaTime)
{

}

bool CSubArm::Move(D3DXVECTOR2 posCenter, float radian, double angleStart, double angleEnd, float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->OnCollision(deltaTime, listObjectCollision);
	bool direction = false;
	if(this->m_angle > angleEnd|| this->m_angle < angleStart)
	{
		this->m_angleDefault = -this->m_angleDefault;
		direction = true;
	}
	this->m_angle -= this->m_angleDefault;
	this->m_radian = radian;
	this->m_posCenter = posCenter;
	this->m_pos.x = this->m_posCenter.x +  int(this->m_radian * std::cos(this->m_angle));
	this->m_pos.y = this->m_posCenter.y + int(this->m_radian * std::sin(this->m_angle));
	return direction;
}
//Di chuyen cho node 1 len xuong
bool CSubArm::Move(D3DXVECTOR2 posCenter, float radian, double vecAngle, double angleStart, double angleEnd, float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->OnCollision(deltaTime, listObjectCollision);
	bool direction = false;
	this->m_angleDefault = (this->m_angleDefault > 0) ? vecAngle : -vecAngle;
	if(this->m_angle > angleEnd|| this->m_angle < angleStart)
	{
		this->m_angleDefault = -this->m_angleDefault;
		direction = true;
	}
	this->m_angle += this->m_angleDefault;
	this->m_radian = radian;
	this->m_posCenter = posCenter;
	this->m_pos.x = this->m_posCenter.x +  int(this->m_radian * std::cos(this->m_angle));
	this->m_pos.y = this->m_posCenter.y + int(this->m_radian * std::sin(this->m_angle));
	return direction;
}

//Tinh Test quay tay 
void CSubArm::Move(D3DXVECTOR2 posCenter, float radian, float angle, double vecAngle, float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->OnCollision(deltaTime, listObjectCollision);
	//
	this->m_angleDefault = vecAngle;
	this->m_angle = angle;
	this->m_angle += this->m_angleDefault;
	this->m_radian = radian;
	this->m_posCenter = posCenter;
	this->m_pos.x = this->m_posCenter.x + int(this->m_radian * std::cos(this->m_angle));
	this->m_pos.y = this->m_posCenter.y + int(this->m_radian * std::sin(this->m_angle));
}

bool CSubArm::Move(D3DXVECTOR2 posCenter, float radian, double vecAngle, double angleStart, double angleEnd, bool direction, float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->OnCollision(deltaTime, listObjectCollision);
	//
	this->m_angleDefault = (this->m_angleDefault > 0) ? vecAngle : -vecAngle;
	bool direction1 = false;
	if(direction)
	{
		this->m_angleDefault = -this->m_angleDefault;
		this->m_angle = (this->m_angleDefault > 0) ? angleEnd : angleStart;
		direction1 = true;
	}
	this->m_angle -= this->m_angleDefault;
	this->m_radian = radian;
	this->m_posCenter = posCenter;
	this->m_pos.x = this->m_posCenter.x +  int(this->m_radian * std::cos(this->m_angle));
	this->m_pos.y = this->m_posCenter.y + int(this->m_radian * std::sin(this->m_angle));
	return direction1;
}
//Di chuyen cho node 2, 3, 4 len xuong--> dang test
bool CSubArm::Move(D3DXVECTOR2 posCenter, float radian, double vecAngle, bool direction, float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->OnCollision(deltaTime, listObjectCollision);
	this->m_angleDefault = (this->m_angleDefault > 0) ? vecAngle : -vecAngle;
	bool direction1 = false;
	/*if(direction)
	{
		this->m_angleDefault = -this->m_angleDefault;
		direction1 = true;
	}
	this->m_angle -= this->m_angleDefault;
	this->m_radian = radian;
	this->m_posCenter = posCenter;

	int tempx = int(this->m_radian * std::cos(this->m_angle));
	int tempy = int(this->m_radian * std::sin(this->m_angle));

	this->m_pos.x = this->m_posCenter.x +  int(this->m_radian * std::cos(this->m_angle));
	this->m_pos.y = this->m_posCenter.y + int(this->m_radian * std::sin(this->m_angle));*/

	this->m_angleDefault = (this->m_angleDefault > 0) ? vecAngle : -vecAngle;
	if (direction)
		this->m_angle -= this->m_angleDefault;
	else
		this->m_angle += this->m_angleDefault;
	this->m_radian = radian;
	this->m_posCenter = posCenter;
	this->m_pos.x = this->m_posCenter.x + int(this->m_radian * std::cos(this->m_angle));
	this->m_pos.y = this->m_posCenter.y + int(this->m_radian * std::sin(this->m_angle));
	return direction1;
}
//Tinh test flow 
void CSubArm::Move(float rotation, D3DXVECTOR2 posCenter, float radian, double vecAngle, float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->OnCollision(deltaTime, listObjectCollision);

	this->m_radian = radian;
	this->m_posCenter = posCenter;
	this->m_pos.x = this->m_posCenter.x + int(this->m_radian * std::cos(rotation));
	this->m_pos.y = this->m_posCenter.y + int(this->m_radian * std::sin(rotation));
}
//Di chuyen thang dung 1 goc PI/4
void CSubArm::Move(float rotation, D3DXVECTOR2 posStart, D3DXVECTOR2 posEnd, float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->OnCollision(deltaTime, listObjectCollision);
	//
	this->m_rotation = rotation;
	this->m_vx = this->m_vxDefault * sin(this->m_rotation);
	this->m_vy = this->m_vyDefault * cos(this->m_rotation);
	if(this->m_posCenter.x == 0 && this->m_posCenter.y == 0)
	{
		this->m_posCenter = posStart;
	}
	//tu trai qua phai
	if(posStart.x < posEnd.x && this->m_pos.x < posEnd.x)
	{
		this->m_posCenter.x += this->m_vx * deltaTime;
		this->m_posCenter.y += this->m_vy * deltaTime;
	}
	else if(posStart.x > posEnd.x && this->m_pos.x > posEnd.x)
	{
		this->m_posCenter.x -= this->m_vx * deltaTime;
		this->m_posCenter.y += this->m_vy * deltaTime;
	}
	this->m_pos.x = this->m_posCenter.x;
	this->m_pos.y = this->m_posCenter.y;
}

RECT* CSubArm::GetRectRS()
{
	RECT* rs = new RECT();
	rs->left = 0;
	rs->right = this->m_width;
	rs->top = 0;
	rs->bottom = this->m_height;
	return rs;
}

Box CSubArm::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 2, this->m_height - 2, this->m_vx, this->m_vy);
}

float CSubArm::GetAngle()
{
	return this->m_angle;
}
void CSubArm::SetAngle(float angle)
{
	this->m_angle = angle;
}
void CSubArm::SetVectorAngle(float vecAngle)
{
	this->m_angleDefault = vecAngle;
}