#include "CBigStone.h"
#include "CCollision.h"
#include "CBullet.h"
#include "CPoolingObject.h"
#include "CCamera.h"
#include "CContra.h"
#include "CManageAudio.h"

CBigStone::CBigStone(void)
{
	this->Init();
}

CBigStone::CBigStone(const std::vector<int>& info)
{
	this->Init();//
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}

}

void CBigStone::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 1;
	this->m_idType = 12;
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 54.0f;//56.0f; //78
	this->m_height = 54.0f; //88.0f; //84
	this->m_pos = D3DXVECTOR2(0.0f, 320.0f);
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_a = -100.0f;
	this->m_canJump = false;
	this->m_jumpMax = 0.0f;
	//this->m_currentJump = 0.0f;
	this->m_vxDefault = 180.0f;
	this->m_vyDefault = 80.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = -this->m_vyDefault;
	this->m_left = false;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.14f;
	this->m_increase = 1.4;
	this->m_totalFrame = 5;
	this->m_column = 5;

	this->m_HP = 3;
	this->m_currentState = STATE_STONE::STANDING;

	this->m_timeDelay = 0.0f;
	this->m_isColGround = false;
}

void CBigStone::Update(float deltaTime)
{
	this->MoveUpdate(deltaTime);
}

void CBigStone::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
	this->Update(deltaTime);
	this->OnCollision(deltaTime, listObjectCollision);
}

void CBigStone::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
#pragma region XU_LY_VA_CHAM
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;
	//Kiem tra va cham voi ground
	bool checkColWithGround = false;
	for (std::vector<CGameObject*>::iterator it = listObjectCollision->begin(); it != listObjectCollision->end(); it++)
	{
		CGameObject* obj = *it;
		//Lay thoi gian va cham
		//Neu doi tuong la ground va dang va cham
		if ((obj->GetIDType() == 15 && obj->GetID()== 1) && !checkColWithGround)
		{
			timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				if (normalY > 0.0f){
					checkColWithGround = true;
					if (timeCollision == 2 && this->m_vy < 0 && !this->m_isColGround)
					{
						this->m_vy = this->m_vyDefault;
						this->m_lastYGround = obj->GetPos().y;
						this->m_isColGround = true;
					}
				}
			}
		}
	}
	//Kiem tra va cham voi dan contra chet
	for (std::vector<CBullet*>::iterator cit = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); 
		cit != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CGameObject* bObj = *cit;
		if (bObj->IsAlive() && bObj->GetLayer() == LAYER::PLAYER)
		{
			if (CCollision::GetInstance()->Collision(bObj, this))
			{
				cit = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(cit);
				this->m_HP--;

				if (this->m_HP == 0)
				{
					CGameObject* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
					effect->SetAlive(true);
					effect->SetPos(this->m_pos);
					this->m_isALive = false;
					//Load sound die
					ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
					// Tang diem cua contra len
					CContra::GetInstance()->IncreateScore(500);
				}
			}
			else
				++cit;
		}
		else
			++cit;
	}

#pragma endregion
}

void CBigStone::MoveUpdate(float deltaTime)
{
	if (this->m_currentState == STATE_STONE::STANDING){
		this->m_timeDelay += deltaTime;
		if (m_timeDelay > 1.0f)
		{
			this->m_timeDelay = 0.0f;
			this->m_currentState = STATE_STONE::FALL;
		}
	}
	else if (this->m_currentState == STATE_STONE::FALL){
		this->m_vy += this->m_a*deltaTime;
		this->m_pos.y += this->m_vy * deltaTime;

		if (this->m_pos.y < this->m_lastYGround){
			this->m_isColGround = false;
		}

		//Set Alive = false khi ra khoi man hinh
		D3DXVECTOR2 pos = CCamera::GetInstance()->GetPointTransform(this->m_pos.x, this->m_pos.y);
		if (pos.x > __SCREEN_WIDTH || pos.x < 0 || pos.y > __SCREEN_HEIGHT || pos.y < 0 || !this->IsAlive())
			this->m_isALive = false;
	}
}

void CBigStone::SetFrame(float deltaTime)
{
	switch (this->m_currentState)
	{
		case STATE_STONE::STANDING:
			//Chuyen frame
			this->m_startFrame = 0;
			this->m_endFrame = 1;
			break;
		case STATE_STONE::FALL:
			//Chuyen frame
			this->m_startFrame = 1;
			this->m_endFrame = 4;
			break;
	}

	
}

RECT* CBigStone::GetBound()
{
	return nullptr;
}

RECT* CBigStone::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CBigStone::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 15, this->m_height - 15, this->m_vx, this->m_vy);
}

CBigStone::~CBigStone()
{

}