#include "CSWeapon.h"
#include "CCollision.h"
#include "CContra.h"
#include "CPoolingObject.h"

CSWeapon::CSWeapon(void)
{
	this->Init();
}
	
CSWeapon::CSWeapon(const std::vector<int>& info)
{
	this->Init();//
	if(!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}

	//
	switch (this->m_id)
	{
	case 1:
		this->m_stateItem =  STATE_BULLET_ITEM::BULLET_ITEM_B;
		break;
	case 2:
		this->m_stateItem = STATE_BULLET_ITEM::BULLET_ITEM_F;
		break;
	case 3:
		this->m_stateItem = STATE_BULLET_ITEM::BULLET_ITEM_L;
		break;
	case 4:
		this->m_stateItem = STATE_BULLET_ITEM::BULLET_ITEM_M;
		break;
	case 5:
		this->m_stateItem = STATE_BULLET_ITEM::BULLET_ITEM_R;
		break;
	case 6:
		this->m_stateItem = STATE_BULLET_ITEM::BULLET_ITEM_S;
		break;
	default:
		break;
	}
}

void CSWeapon::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 1;
	this->m_idType = 13; 
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 64.0f;//56.0f; //78
	this->m_height = 64.0f; //88.0f; //84
	this->m_pos = D3DXVECTOR2(900.0f, 100.0f);
	//Khoi tao cac thong so di chuyen
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 6;
	this->m_elapseTimeChangeFrame = 0.9f;
	this->m_increase = 1.4;
	this->m_totalFrame = 7;
	this->m_column = 7;
	//
	this->m_timeDelay = 0.0f;
}

void CSWeapon::Update(float deltaTime)
{
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
	if (this->item != NULL){
		this->item->Update(deltaTime);
	}
}

void CSWeapon::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
}

void CSWeapon::SetFrame(float deltaTime)
{
	if(this->m_currentFrame >= 1 && this->m_currentFrame <= 4)
	{
		this->m_elapseTimeChangeFrame = 0.03f;
	}
	else if(this->m_currentFrame <= 0)
	{
		this->m_elapseTimeChangeFrame = 1.4f;
	}
	else
	{
		this->m_elapseTimeChangeFrame = 0.45f;
	}
	//Chuyen frame
	this->m_startFrame = 0;
	this->m_endFrame = 6;
}

RECT* CSWeapon::GetBound()
{
	return nullptr;
}

RECT* CSWeapon::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CSWeapon::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height);
}

void CSWeapon::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
#pragma region XU_LY_VA_CHAM
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CBullet* obj = *it;
		if(obj && obj->GetLayer() == LAYER::PLAYER)
		{
			timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
			if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				//trên - xuống normalY = 1
				//Trái phải normalX = -1
				// ==0 ko va chạm theo Y, X	
				CExplosionEffect* eff = CPoolingObject::GetInstance()->GetExplosionEffect();
				eff->SetAlive(true);
				eff->SetPos(this->m_pos);

				//
				it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
				//
				CBulletItem* bulletItem = CPoolingObject::GetInstance()->GetBulletItem();
				bulletItem->SetAlive(true);
				bulletItem->SetPos(this->m_pos);
				bulletItem->m_stateItem = this->m_stateItem;
			
				this->m_isALive = false;
			}
			else
			{
				++it;
			}
		}
		else
		{
			++it;
		}
	}
#pragma endregion 
}

CBulletItem* CSWeapon::CreateItem()
{
	switch (this->m_id)
	{
	case 1:
		return new CBulletItem(this->GetPos(), STATE_BULLET_ITEM::BULLET_ITEM_B);
	case 2:
		return new CBulletItem(this->GetPos(), STATE_BULLET_ITEM::BULLET_ITEM_F);
	case 3:
		return new CBulletItem(this->GetPos(), STATE_BULLET_ITEM::BULLET_ITEM_L);
	case 4:
		return new CBulletItem(this->GetPos(), STATE_BULLET_ITEM::BULLET_ITEM_M);
	case 5:
		return new CBulletItem(this->GetPos(), STATE_BULLET_ITEM::BULLET_ITEM_R);
	case 6:
		return new CBulletItem(this->GetPos(), STATE_BULLET_ITEM::BULLET_ITEM_S);
	default:
		break;
	}
}

CSWeapon::~CSWeapon()
{

}