#include "CWeapon.h"
#include "CCollision.h"
#include "CContra.h"
#include "CDrawObject.h"
#include "CPoolingObject.h"

CWeapon::CWeapon(void)
{
	this->Init();
}

CWeapon::CWeapon(D3DXVECTOR2 position, int id)
{
	this->Init();
	this->m_pos = position;
	this->m_id = id;
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

CWeapon::CWeapon(const std::vector<int>& info)
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

	//
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

void CWeapon::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_idType = 14;
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 49.0f;//56.0f; //78
	this->m_height = 27.0f; //88.0f; //84
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_isMoveRight = true;
	this->m_a = 700.0f;
	this->m_canJump = false;
	this->m_jumpMax = 0.0f;
	//this->m_currentJump = 0.0f;
	this->m_vxDefault = 180.0f;
	this->m_vyDefault = 100.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_left = false;
	this->m_angle = 0;

	//this->m_stateItem = STATE_BULLET_ITEM::BULLET_ITEM_M;
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

void CWeapon::SetID(int id)
{
	this->m_id = id;
}

void CWeapon::Update(float deltaTime)
{
	this->MoveUpdate(deltaTime);
}

void CWeapon::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	this->MoveUpdate(deltaTime);
	this->OnCollision(deltaTime, listObjectCollision);
}

void CWeapon::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
#pragma region XU_LY_VA_CHAM
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	//Sắp va chạm > 0 và < 1
	//Hai Box Giao Nhau (Đã va chạm rồi) = 2 và moveX, moveY (độ lún)
	//timeCollision = CCollision::GetInstance()->Collision(this, CContra::GetInstance(), normalX, normalY, moveX, moveY, deltaTime);
	//if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
	//{
	//	//trên - xuống normalY = 1
	//	//Trái phải normalX = -1
	//	// ==0 ko va chạm theo Y, X	
	//	if (this->effect == NULL){
	//		this->effect = new CExplosionEffect(this->GetPos());
	//	}

	//	if (this->item == NULL){
	//		
	//		this->item = new CBulletItem(this->GetPos());

	//		this->item->m_stateItem = this->m_stateItem;
	//	}
	//	this->m_isALive = false;
	//}

	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CBullet* obj = *it;
		timeCollision = CCollision::GetInstance()->Collision(this, obj, normalX, normalY, moveX, moveY, deltaTime);
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

void CWeapon::MoveUpdate(float deltaTime)
{
	this->m_angle += 4.0 * deltaTime;
	this->m_pos.x += this->m_vx * deltaTime;
	this->m_pos.y += 4.0f * sin(this->m_angle);
}
RECT* CWeapon::GetBound()
{
	return nullptr;
}

RECT* CWeapon::GetRectRS()
{
	RECT* rs = new RECT();
	rs->left = 0;
	rs->right = this->m_width;
	rs->top = 0;
	rs->bottom = this->m_height;
	return rs;
}

Box CWeapon::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height, this->m_vx, this->m_vy);
}

CWeapon::~CWeapon()
{

}