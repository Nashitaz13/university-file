#include "CBulletItem.h"
#include "CCollision.h"
#include "CContra.h"
#include "CCamera.h"

CBulletItem::CBulletItem(void)
{
	this->Init();
}

CBulletItem::CBulletItem(D3DXVECTOR2 pos)
{
	this->Init();
	this->m_pos = pos;
}

CBulletItem::CBulletItem(D3DXVECTOR2 pos, STATE_BULLET_ITEM state)
{
	this->Init();
	this->m_pos = pos;
	this->m_stateItem = state;
}

CBulletItem::CBulletItem(const std::vector<int>& info)
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

void CBulletItem::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 8;
	this->m_idType = 14;
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 49.0f;//56.0f; //78
	this->m_height = 27.0f; //88.0f; //84
	this->m_pos = D3DXVECTOR2(1100.0f, 200.0f);
	this->m_left = false;
	this->m_a = -700.0f;
	this->m_vx = 80.0f;
	this->m_vy = 400.0f;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.20f;
	this->m_increase = 1;
	this->m_totalFrame = 10;
	this->m_column = 10;

	this->m_stateItem = STATE_BULLET_ITEM::BULLET_ITEM_L;
}

void CBulletItem::Update(float deltaTime)
{
	this->MoveUpdate(deltaTime);
	this->SetFrame();
	this->ChangeFrame(deltaTime);

}

void CBulletItem::MoveUpdate(float deltaTime)
{
	
	//this->m_vx -= this->m_a  * deltaTime;
	//this->m_vy += this->m_a * deltaTime * sin(this->m_angle);
	this->m_pos.x += this->m_vx * deltaTime;
	this->m_vy += this->m_a * deltaTime;
	this->m_pos.y += this->m_vy * deltaTime;
	//this->m_pos.y += 5.0f * sin(this->m_angle);
 	//this->m_angle += 4.0 * deltaTime;
	// Xet' alive = false khi soldier ra khoi man hinh
	D3DXVECTOR3 pos;
	pos = CCamera::GetInstance()->GetPointTransform(this->m_pos.x, this->m_pos.y);
	if(pos.x > __SCREEN_WIDTH + 100 || pos.x < -100)
	{
		this->m_isALive = false;
	}
}

void CBulletItem::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if(this->m_isALive)
	{
		this->MoveUpdate(deltaTime);
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
}

void CBulletItem::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision){

#pragma region XU_LY_VA_CHAM
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;
	//Kiem tra va cham voi ground
	bool checkColWithGround = false;
	timeCollision = CCollision::GetInstance()->Collision(CContra::GetInstance(), this, normalX, normalY, moveX, moveY, deltaTime);
	if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
	{
		CContra::GetInstance()->SetTypeBullet(this->m_stateItem);
		this->m_isALive = false;
	}
	for (std::vector<CGameObject*>::iterator it = listObjectCollision->begin(); it != listObjectCollision->end(); it++)
	{
		CGameObject* obj = *it;
		//Lay thoi gian va cham
		//Neu doi tuong la ground va dang va cham
		if (obj->GetIDType() == 15 && !checkColWithGround)
		{
			timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				if (normalY > 0.0f){
					checkColWithGround = true;
					if(timeCollision == 2 && this->m_vy < 0)
					{
						this->m_pos.y += moveY;
						this->m_vx = 0;
						this->m_vy = 0;
				
					}
					else
					{

					}
				}
			}
		}	
	}

#pragma endregion
}

void CBulletItem::SetFrame()
{
	switch (this->m_stateItem)
	{
		case STATE_BULLET_ITEM::BULLET_ITEM_B:
		{
			this->m_currentFrame = 2;
			this->m_startFrame = 2;
			this->m_endFrame = 2;
			break;
		}
		case STATE_BULLET_ITEM::BULLET_ITEM_F:
		{
			this->m_currentFrame = 3;
			this->m_startFrame = 3;
			this->m_endFrame = 3;
			break;
		}
		case STATE_BULLET_ITEM::BULLET_ITEM_L:
		{
			this->m_currentFrame = 5;
			this->m_startFrame = 5;
			this->m_endFrame = 5;
			break;
		}
		case STATE_BULLET_ITEM::BULLET_ITEM_M:
		{
			this->m_currentFrame = 1;
			this->m_startFrame = 1;
			this->m_endFrame = 1;
			break;
		}
		case STATE_BULLET_ITEM::BULLET_ITEM_R:
		{
			this->m_currentFrame = 6;
			this->m_startFrame = 6;
			this->m_endFrame = 6;
			break;
		}
		case STATE_BULLET_ITEM::BULLET_ITEM_S:
		{
			this->m_currentFrame = 4;
			this->m_startFrame = 4;
			this->m_endFrame = 4;
			break;
		}
		default:
		{
			break;
		}
	}
}

RECT* CBulletItem::GetBound()
{
	return nullptr;
}

RECT* CBulletItem::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CBulletItem::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height, this->m_vx, this->m_vy);
}

CBulletItem::~CBulletItem()
{

}