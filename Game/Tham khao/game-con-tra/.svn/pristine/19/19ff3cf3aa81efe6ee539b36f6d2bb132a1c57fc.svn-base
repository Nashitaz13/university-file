#include "CHidenObject.h"
#include "CCamera.h"
#include "CCollision.h"
#include "CContra.h"
#include "CSoldier.h"
#include "CSoldierShoot.h"
#include "CPoolingObject.h"
#include "CBulletLaze.h"

bool CHidenObject::m_createBigStone = false;
bool CHidenObject::m_createEnemy = false;
bool CHidenObject::m_createWeapon = false;
bool CHidenObject::m_createBulletLaze = false;
float CHidenObject::m_posHiddenItem = 0.0f;

CHidenObject::CHidenObject() : CStaticObject()
{
	this->m_id = 1;
	this->m_idType = 15;
	this->m_width = 1450;
	this->m_height = 10;
	this->m_pos = D3DXVECTOR2(735.0f, 5.0f);
	this->m_isALive = true;
}

CHidenObject::CHidenObject(const std::vector<int>& info) : CStaticObject()
{
	this->m_isALive = true;//
	this->m_waitForCreateEnemy = 1.20f;
	this->m_waitForCreateSoliderShoot = 1.60f;
	this->m_waitForCreateBigStone = 7.0f;
	this->m_waitForCreateBulletLaze = 2.0f;
	this->countWeapon = 0;
	// TT
	if(!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
		switch (info.at(0))
		{
		case 15001:
			this->m_type = HIDEN_OBJECT_TYPE::ON_GROUND;
			break;
		case 15002:
			this->m_type = HIDEN_OBJECT_TYPE::UNDER_WATER;
			break;
		case 15003:
			this->m_type = HIDEN_OBJECT_TYPE::CREATE_WEAPON;
			break;
		case 15004:
			this->m_type = HIDEN_OBJECT_TYPE::CREATE_ENEMY;
			break;
		case 15006:
			this->m_type = HIDEN_OBJECT_TYPE::ENEMY_POS_R;
			break; 
		case 15007:
			this->m_type = HIDEN_OBJECT_TYPE::ENEMY_POS_L;
			break;
		case 15008:
			this->m_type = HIDEN_OBJECT_TYPE::GROUND_NO_FALL;
			break;
		case 15009:
			this->m_type = HIDEN_OBJECT_TYPE::ENEMY_SHOOT_L;
			break;
		case 15010:
			this->m_type = HIDEN_OBJECT_TYPE::ENEMY_SHOOT_R;
			break;
		case 15011:
			this->m_type = HIDEN_OBJECT_TYPE::H_BIG_STONE;
			break;
		case 15012:
			this->m_type = HIDEN_OBJECT_TYPE::CREATE_STONE;
			break;
		case 15013:
			this->m_type = HIDEN_OBJECT_TYPE::CREATE_LAZE;
			break;
		case 15014:
			this->m_type = HIDEN_OBJECT_TYPE::H_BULLET_LAZE;
			break;
		case 15015:
			this->m_type = HIDEN_OBJECT_TYPE::NO_OVER_STONE;
			break;
		default:
			break;
		}
	}
}

CHidenObject::~CHidenObject()
{

}

void CHidenObject::Update(float deltaTime)
{

}

Box CHidenObject::GetBox()
{
	///D3DXVECTOR3 pos = CCamera::GetInstance()->GetPointTransform(this->m_pos.x, this->m_pos.y);
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height, 0, 0);
}

void CHidenObject::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_type == HIDEN_OBJECT_TYPE::CREATE_ENEMY)
	{
		if (CCollision::GetInstance()->Collision(CContra::GetInstance(), this))
		{
			CHidenObject::m_createEnemy = true;
		}
		else
		{
			CHidenObject::m_createEnemy = false;
		}
	}

	// create enemy posision
	if (this->m_type == HIDEN_OBJECT_TYPE::ENEMY_POS_L || this->m_type == HIDEN_OBJECT_TYPE::ENEMY_POS_R)
	{
		if (CHidenObject::m_createEnemy)
		{
			// Sinh enemy 
			this->m_waitForCreateEnemy += deltaTime;

			if (this->m_waitForCreateEnemy > 1.0f)
			{
				this->m_waitForCreateEnemy = 0.0f;

				CSoldier* soldier = CPoolingObject::GetInstance()->GetSoliderObject();
				if (soldier != nullptr)
				{
					soldier->SetAlive(true);
					// Random jump
					soldier->setJump(rand()%2 == 1);
					// set left right
					if (this->m_id == 7)
						soldier->SetLeft(false);
					else
						soldier->SetLeft(true);
					// Set vi tri cho soldier
					D3DXVECTOR2 soldierPos = this->m_pos;
					soldierPos.x = CContra::GetInstance()->GetPos().x + 100;
					soldier->SetPos(this->m_pos);
				}
			}
		}
	}

	// create solider shoot posision
	if (this->m_type == HIDEN_OBJECT_TYPE::ENEMY_SHOOT_L || this->m_type == HIDEN_OBJECT_TYPE::ENEMY_SHOOT_R)
	{
		if (CHidenObject::m_createEnemy)
		{
			// Sinh enemy 
			this->m_waitForCreateSoliderShoot += deltaTime;

			if (this->m_waitForCreateSoliderShoot > 1.4f)
			{
				this->m_waitForCreateSoliderShoot = 0.0f;

				CSoldierShoot* soldierShoot = CPoolingObject::GetInstance()->GetSoliderShootObject();
				if (soldierShoot != nullptr)
				{
					soldierShoot->SetAlive(true);
					// Random jump
					soldierShoot->setJump(rand() % 2 == 1);
					// set left right
					if (this->m_id == 7)
						soldierShoot->SetLeft(false);
					else
						soldierShoot->SetLeft(true);
					// Set vi tri cho soldier
					D3DXVECTOR2 soldierPos = this->m_pos;
					soldierPos.x = CContra::GetInstance()->GetPos().x + 100;
					soldierShoot->SetPos(this->m_pos);
				}
			}
		}
	}

	//Kiem tra co va cham vs cuc cho phep da roi
	if (this->m_type == HIDEN_OBJECT_TYPE::CREATE_STONE)
	{
		if (CCollision::GetInstance()->Collision(CContra::GetInstance(), this))
		{
			CHidenObject::m_createBigStone = true;
		}
		else
		{
			CHidenObject::m_createBigStone = false;
		}
	}

	//Sinh da tri vi ri nay
	if (this->m_type == HIDEN_OBJECT_TYPE::H_BIG_STONE)
	{
		if (CHidenObject::m_createBigStone)
		{
			this->m_waitForCreateBigStone += deltaTime;

			if (this->m_waitForCreateBigStone > 6.0f)
			{
				this->m_waitForCreateBigStone = 0.0f;
				CBigStone* bigStone = CPoolingObject::GetInstance()->GetBigStone();
				if (bigStone != nullptr)
				{
					bigStone->SetAlive(true);
					bigStone->SetPos(this->m_pos);
				}
			}
		}
	}
	
	//Kiem tra co va cham vs Hiden cho phep sinh Laze
	if (this->m_type == HIDEN_OBJECT_TYPE::CREATE_LAZE)
	{
		if (CCollision::GetInstance()->Collision(CContra::GetInstance(), this))
		{
			CHidenObject::m_createBulletLaze = true;
		}
		else
		{
			CHidenObject::m_createBulletLaze = false;
		}
	}

	//Sinh Laze tri vi ri nay
	if (this->m_type == HIDEN_OBJECT_TYPE::H_BULLET_LAZE)
	{
		if (CHidenObject::m_createBulletLaze)
		{
			this->m_waitForCreateBulletLaze += deltaTime;

			if (this->m_waitForCreateBulletLaze > 2.0f)
			{
				this->m_waitForCreateBulletLaze = 0.0f;
				CBulletLaze* laze = CPoolingObject::GetInstance()->GetBulletLaze();
				if (laze != nullptr)
				{
					laze->SetAlive(true);
					laze->SetPos(this->m_pos);
				}
			}
		}
	}

	// Create weapon
	if (this->m_type == HIDEN_OBJECT_TYPE::CREATE_WEAPON)
	{
		if (CCollision::GetInstance()->Collision(CContra::GetInstance(), this))
		{
			CHidenObject::m_createWeapon = true;
			// tao weapon tai vi tri phia sau hidden item.
			CHidenObject::m_posHiddenItem = this->m_pos.x;
		}
	}

	if (CHidenObject::m_createWeapon)
	{
		if (this->m_idType == 14 && this->countWeapon == 0 && this->m_pos.x < CHidenObject::m_posHiddenItem)
		{
			CWeapon* weapon = CPoolingObject::GetInstance()->GetWeapon();
			weapon->SetID(this->m_id);
			weapon->Init();
			weapon->SetPos(this->GetPos());
			weapon->SetAlive(true);

			this->countWeapon ++;
			CHidenObject::m_createWeapon = false;
		}
	}
}

//Sang test
RECT* CHidenObject::GetRectRS()
{
	RECT* rectRS = new RECT();
	rectRS->left = 0;
	rectRS->right = 64;
	rectRS->top = 0 ;
	rectRS->bottom = 64;

	return rectRS;
}