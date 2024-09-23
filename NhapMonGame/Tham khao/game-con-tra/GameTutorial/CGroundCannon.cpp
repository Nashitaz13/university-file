#include "CGroundCannon.h"
#include "CContra.h"
#include <math.h>
#include "CCamera.h"
#include "CCollision.h"
#include "CPoolingObject.h"
#include "CEnemyEffect.h"
#include "CManageAudio.h"

CGroundCanon::CGroundCanon(void)
{
	this->Init();
}

CGroundCanon::CGroundCanon(const std::vector<int>& info)
{
	this->Init();//
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
		this->m_height = 0;
	}
}

void CGroundCanon::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 4;
	this->m_idType = 11;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 64.0f;
	this->m_height = 0.0f; 
	this->m_heightMax = 64.0f;
	this->m_pos = D3DXVECTOR2(770.0f, 220.0f);
	this->m_left = false;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.25f;
	this->m_increase = 1;
	this->m_totalFrame = 9;
	this->m_column = 3;
	this->m_allowShoot = true;//cho phep ban dan
	this->m_moveUpComplete = false;
	this->m_HP = 7;
	//
	this->m_isShoot = true;
	this->m_stateCurrent = GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_NORMAL;
	//Test
	this->m_bulletCount = 0;
	this->m_timeDelay = 0.25f;
	this->m_waitForShoot = 0.0f;
}

void CGroundCanon::Update(float deltaTime)
{
	if (this->m_isALive)
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->MoveUp(deltaTime);
		this->OnCollision(deltaTime, nullptr);
	}
}

void CGroundCanon::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		//if(abs(this->m_pos.x - CContra::GetInstance()->GetPos().x) >  250)
		//{
		//	//this->MoveDown(deltaTime);
		//}
		//else
		//{
			if(abs(this->m_pos.x - CContra::GetInstance()->GetPos().x) <=  250)
			{
				this->m_moveUpComplete = true;
			}
			if(this->m_moveUpComplete)
			{		
				this->SetFrame();
				this->ChangeFrame(deltaTime);
				this->MoveUp(deltaTime);
				this->OnCollision(deltaTime, listObjectCollision);
			}
		//}
		
	}
}

void CGroundCanon::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
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

				CBulletEffect* effect = CPoolingObject::GetInstance()->GetBulletEffect();
				effect->SetAlive(true);
				effect->SetPos(obj->GetPos());
			}
			else
				++it;

			if (this->m_HP == 0)
			{
				// Gan trang thai die cho doi tuong
				this->m_stateCurrent = GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIE;
				//Load sound die
				ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
				// Tang diem cua contra len
				CContra::GetInstance()->IncreateScore(300);
			}
		}
		else
		{
			++it;
		}
	}
}
void CGroundCanon::BulletUpdate(float deltaTime)
{
#pragma region THIET LAP GOC BAN
	D3DXVECTOR2 posContra = CContra::GetInstance()->GetPos();
	float spaceX = posContra.x - this->m_pos.x;
	float spaceY = posContra.y - this->m_pos.y;
	double shootAngleNormal = PI / 6;
	double angle = 0.0f;
	this->m_left = false;

	if (spaceY + this->m_height / 2 < 0)
	{
		this->m_allowShoot = false;
	}
		
	else
	{
		this->m_allowShoot = true;
		if (spaceX < 0 && spaceY >= 0 )
		{
			angle = atan(spaceY / abs(spaceX));
		}
		else
		{
			angle = 0;
		}
	}
	
	
#pragma endregion

#pragma region THIET LAP TRANG THAI BAN
	if (this->m_isShoot)
	{
	//	angle = (angle > 2 * PI) ? angle - 2 * PI : angle;
		int space = int(angle / shootAngleNormal);
		switch (space)
		{
		case 0:
			{
				this->m_stateCurrent = GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_NORMAL;
				break;
			}
		case 1:
			{
				this->m_stateCurrent = GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIAGONAL_UP_X;
				break;
			}
		case 2:
			{
				this->m_stateCurrent = GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIAGONAL_UP_2X;
				break;
			}
		case 3:
			{
				this->m_stateCurrent = GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIE;
				break;
			}
		}
	}
#pragma endregion

#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
	D3DXVECTOR2 offset;
	switch (this->m_stateCurrent)
	{
	case GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_NORMAL:
	{
		offset.x = -this->m_width/2;
		offset.y = 0.0f;
		break;
	}
	case GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIAGONAL_UP_X:
	{
		offset.y = 20.0f;
		offset.x = -this->m_width / 2;
		break;
	}
	case GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIAGONAL_UP_2X:
	{
		offset.y = 48.0f;
		offset.x = -this->m_width / 4 - 2;
		break;
	}
	default:
	{
		break;
	}
	}
#pragma endregion

#pragma region THIET LAP TOC DO DAN

	this->m_waitForShoot += deltaTime;
	if(this->m_waitForShoot > 1.5f)
	{
		this->m_waitForShoot = 0.0f;
		this->m_isShoot = true;
	}
	if (this->m_isShoot && spaceX < 0)
	{
		if (m_bulletCount > 2)
		{
			this->m_bulletCount = 0;
			this->m_isShoot = false;
		}
		if (this->m_timeDelay >= 0.25f)
		{
			CBullet_N* bullet = new CBullet_N(angle, this->m_pos, offset, !this->m_left);
			bullet->SetLayer(LAYER::ENEMY);
			CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
			this->m_timeDelay = 0;
			m_bulletCount++;
		}
		m_timeDelay += deltaTime;
	}
#pragma endregion

}

void CGroundCanon::MoveUp(float deltaTime){
	if (this->m_height != this->m_heightMax){
		this->m_timeDelay += deltaTime;
		if (this->m_timeDelay > 0.1) //0.3 co the thay tuy y cua minh
		{
			this->m_timeDelay = 0;
			this->m_height += 8;
		}
	}
	else
	{
		this->BulletUpdate(deltaTime);
	}

}


void CGroundCanon::MoveDown(float deltaTime){
	if (this->m_height != 0){
		this->m_timeDelay += deltaTime;
		if (this->m_timeDelay > 0.1) //0.3 co the thay tuy y cua minh
		{
			this->m_timeDelay = 0;
			this->m_height -= 8;
		}
	}

}

void CGroundCanon::SetFrame()
{
	//Chuyen doi frame
	int currentFrame = this->m_currentFrame;
	switch (this->m_stateCurrent)
	{
	case GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_NORMAL:
	{
		this->m_startFrame = 0;
		this->m_endFrame = 2;
		break;
	}
	case GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIAGONAL_UP_X:
	{
		this->m_startFrame = 3;
		this->m_endFrame = 5;
		break;
	}
	case GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIAGONAL_UP_2X:
	{
		this->m_startFrame = 6;
		this->m_endFrame = 8;
		break;
	}
	case GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIE:
	{
			  this->m_stateCurrent = GROUNDCANON_SHOOT_STATE::G_IS_SHOOTING_DIE;
			  //hieu ung no
			  CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
			  effect->SetAlive(true);
			  effect->SetPos(this->m_pos);
			  this->m_isALive = false;
			  break;
	}
	default:
	{
		break;
	}
	}
}

RECT* CGroundCanon::GetBound()
{
	return nullptr;
}

RECT* CGroundCanon::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CGroundCanon::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height, 0, 0);
}

CGroundCanon::~CGroundCanon()
{

}