#include "CBossArm.h"
#include "CDrawObject.h"
#include "CContra.h"
#include "CPoolingObject.h"
#include "CManageAudio.h"

CBossArm::CBossArm(D3DXVECTOR2 posOfBoss, bool isArmLeft)
{
	this->m_posOfBoss = posOfBoss;
	this->m_isArmLeft = isArmLeft;
	this->Init();
}

CBossArm::~CBossArm()
{
	this->m_pos = D3DXVECTOR2(0,0);
}

void CBossArm::Init()
{
	this->m_stateCurrent = BOSS_ARM_STATE::BAS_IS_POPUP;
	this->m_isChangeDirection = false;
	this->m_timeCurr = 0.0f;
	this->vecIncreate = 0.7f;
	this->subArms = new CSubArm*[5];
	this->m_timeDelayRotate = 6.0f;
	this->m_timeDelayFlow = 4.0f;
	this->m_timeDelay = 0.0f;
	//
	if (this->m_isArmLeft)//Canh tay ben trai
	{
		this->m_pos = D3DXVECTOR2(this->m_posOfBoss.x - 115.0f, this->m_posOfBoss.y + 90.0f);
	}
	else//Canh tay ben phai
	{
		this->m_pos = D3DXVECTOR2(this->m_posOfBoss.x + 115.0f, this->m_posOfBoss.y + 90.0f);
	}
	//
	for (int i = 0; i < 5; i++)
	{
		this->subArms[i] = new CSubArm();
		this->subArms[i]->SetPos(this->m_pos);
		if (i == 4)
			this->subArms[i]->SetArmType(SUB_ARM_TYPE::SUB_ARM_FIRST);
		else
			this->subArms[i]->SetArmType(SUB_ARM_TYPE::SUB_ARM_COMPONENT);
		this->subArms[i]->Init();
		this->subArms[i]->WaitForAppear = (5 - i)* 0.6;
	}

	if (this->m_isArmLeft)//Canh tay ben trai
		this->subArms[1]->SetAngle(0);
	else//Canh tay ben phai
		this->subArms[1]->SetAngle(PI);
}

void CBossArm::Update(float deltaTime)
{

}

void CBossArm::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	for (int i = 0; i < 5; i++)
	{
		this->subArms[i]->Update(deltaTime, listObjectCollision);
		if (!this->subArms[i]->IsAlive() && this->m_stateCurrent != BOSS_ARM_STATE::BAS_IS_POPUP)
		{
			//play sound
			ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
			//
			this->m_isALive = false;
			CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect->SetAlive(true);
			effect->SetPos(this->subArms[0]->GetPos());
			this->subArms[0]->SetAlive(false);
			//
			CExplosionEffect* effect1 = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect1->SetAlive(true);
			effect1->SetPos(this->subArms[1]->GetPos());
			this->subArms[1]->SetAlive(false);
			//
			CExplosionEffect* effect2 = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect2->SetAlive(true);
			effect2->SetPos(this->subArms[2]->GetPos());
			this->subArms[2]->SetAlive(false);
			//
			CExplosionEffect* effect3 = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect3->SetAlive(true);
			effect3->SetPos(this->subArms[3]->GetPos());
			this->subArms[3]->SetAlive(false);
			//
			CExplosionEffect* effect4 = CPoolingObject::GetInstance()->GetExplosionEffect();
			effect4->SetAlive(true);
			effect4->SetPos(this->subArms[4]->GetPos());
			this->subArms[4]->SetAlive(false);

			// Tang diem cua contra len
			CContra::GetInstance()->IncreateScore(2000);
		}
	}
	if (this->m_isALive)
		this->MoveUpdate(deltaTime, listObjectCollision);
	else
		//play sound
		ManageAudio::GetInstance()->stopSound(TypeAudio::ENEMY_DEAD_SFX);
}

void CBossArm::MoveUpdate(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	switch (this->m_stateCurrent)
	{
		case	BOSS_ARM_STATE::BAS_IS_POPUP:
		{
			#pragma region TRANG THAI THANG DUNG
			if (this->m_isArmLeft)//tay ben trai
			{
				for (int i = 0; i < 5; i++)
				{
					if (this->subArms[i]->IsAlive())
						this->subArms[i]->Move(PI / 4, this->m_pos, D3DXVECTOR2(this->m_pos.x - i * 16 * sqrt(2), this->m_pos.y), deltaTime, listObjectCollision);
				}
			}
			else
			{//Tay ben phai
				for (int i = 0; i < 5; i++)
				{
					if (this->subArms[i]->IsAlive())
						this->subArms[i]->Move(PI / 4, this->m_pos, D3DXVECTOR2(this->m_pos.x + i * 16 * sqrt(2), this->m_pos.y), deltaTime, listObjectCollision);
				}
			}

			//Neu da di chuyen xong thi chuyen sang trang thai rotate
			//Khi quay cho 5s xong chuyen sang trang thai flow
			if (this->m_timeDelay >= this->subArms[0]->WaitForAppear)
			{
				this->m_stateCurrent = BOSS_ARM_STATE::BAS_IS_ROTATE;
				this->m_timeDelay = 0.0f;
			}
			this->m_timeDelay += deltaTime;
			//
			#pragma endregion
			break;
		}
		case	BOSS_ARM_STATE::BAS_IS_UP_DOWN:
		{
			#pragma region TRANG THAI DUA LEN DUA XUONG
			//if (this->m_isArmLeft)//tay ben trai
			//{
			//	//if (this->subArms[0]->IsAlive())
			//	//{
			//	//	bool direction = this->subArms[1]->Move(this->m_pos, 18 * sqrt(2) + 6, 0.07,-8* PI / 3, PI / 3, deltaTime);
			//	//	bool direction1 = this->subArms[2]->Move(this->subArms[1]->GetPos(), 18 * sqrt(2) + 6, 0.04, direction, deltaTime);
			//	//	bool direction2 = this->subArms[3]->Move(this->subArms[2]->GetPos(), 18 * sqrt(2) + 6, 0.035, direction1, deltaTime);
			//	//	this->subArms[4]->Move(this->subArms[3]->GetPos(), 18 * sqrt(2) + 6, 0.03, direction2, deltaTime);
			//	//}
			//}
			//else
			//{//Tay ben phai
			//	if (this->subArms[0]->IsAlive())
			//	{
			//		/*bool direction = this->subArms[1]->Move(this->m_pos, 30, 0.07, -2 * PI / 3, 2 * PI / 3, deltaTime);
			//		if (this->subArms[1]->GetAngle() < PI / 3 || this->subArms[1]->GetAngle() > - PI / 3)
			//		{
			//		this->subArms[2]->Move(this->subArms[1]->GetPos(), 30, this->subArms[1]->GetAngle(), 0.8, deltaTime);
			//		this->subArms[3]->Move(this->subArms[2]->GetPos(), 30, this->subArms[2]->GetAngle(), 0.8, deltaTime);
			//		this->subArms[4]->Move(this->subArms[3]->GetPos(), 30, this->subArms[3]->GetAngle(), 0.8, deltaTime);
			//		}
			//		else
			//		{
			//		this->subArms[2]->Move(this->subArms[1]->GetPos(), 30, this->subArms[1]->GetAngle(), -0.8, deltaTime);
			//		this->subArms[3]->Move(this->subArms[2]->GetPos(), 30, this->subArms[2]->GetAngle(), -0.8, deltaTime);
			//		this->subArms[4]->Move(this->subArms[3]->GetPos(), 30, this->subArms[3]->GetAngle(), -0.8, deltaTime);
			//		}*/
			//	}
			//}

			this->m_stateCurrent = BOSS_ARM_STATE::BAS_IS_ROTATE;
			#pragma endregion	
			break;
		}
		case	BOSS_ARM_STATE::BAS_IS_ROTATE:
		{
			#pragma region TRANG THAI XOAY TRON
			//set cho phep ban
			this->subArms[4]->m_isShoot = false;
			if (this->m_isArmLeft)//tay ben trai
			{
				if (this->subArms[0]->IsAlive())
				{
					this->subArms[1]->Move(this->m_pos, 30, 0.13, true, deltaTime, listObjectCollision);
					for (int i = 2; i < 5; ++i)
					{
						this->subArms[i]->Move(this->subArms[i - 1]->GetPos(), 30, this->subArms[i - 1]->GetAngle(), this->vecIncreate, deltaTime, listObjectCollision);
					}
				}
			}
			else
			{//Tay ben phai
				if (this->subArms[0]->IsAlive())
				{
					this->subArms[1]->Move(this->m_pos, 30, 0.13, false, deltaTime, listObjectCollision);
					for (int i = 2; i < 5; ++i){
						this->subArms[i]->Move(this->subArms[i - 1]->GetPos(), 30, this->subArms[i - 1]->GetAngle(), -this->vecIncreate, deltaTime, listObjectCollision);
					}
				}
			}
			//Khi quay cho 5s xong chuyen sang trang thai flow
			if (this->m_timeDelayRotate <= 0)
			{
				this->m_stateCurrent = BOSS_ARM_STATE::BAS_IS_FLOW;
				this->m_timeDelayRotate = 6.0f;
			}
			this->m_timeDelayRotate -= deltaTime;
			#pragma endregion
			break;
		}
		case	BOSS_ARM_STATE::BAS_IS_FLOW:
		{
			#pragma region TRANG THAI HUONG THEO CONTRA
			//Lay goc giua contra va tay
			float angleWithContra = (float)(atan((CContra::GetInstance()->GetPos().x - this->m_pos.x) / abs(CContra::GetInstance()->GetPos().y - this->m_pos.y)));
			angleWithContra -= PI/2;
			//set cho phep ban
			this->subArms[4]->m_isShoot = true;
			//0
			if (this->m_isArmLeft)//tay ben trai
			{
				if (this->subArms[0]->IsAlive())
				{
					float temp = this->subArms[1]->GetAngle()*180/PI;
					float temp1 = angleWithContra * 180 / PI;
					if (this->subArms[1]->GetAngle() < angleWithContra)
						for (int i = 1; i < 5; i++)
						{
							this->subArms[i]->Move(angleWithContra, this->subArms[i - 1]->GetPos(), 30, 10.0f, deltaTime, listObjectCollision);
						}
					else
					if (this->subArms[1]->GetAngle() > angleWithContra)
						for (int i = 1; i < 5; i++)
						{
							this->subArms[i]->Move(angleWithContra, this->subArms[i - 1]->GetPos(), 30, -1.0f, deltaTime, listObjectCollision);
						}
				}
			}
			else
			{//Tay ben phai
				if (this->subArms[0]->IsAlive())
				{
					if (this->subArms[1]->GetAngle() < angleWithContra)
						for (int i = 1; i < 5; i++)
						{
							this->subArms[i]->Move(angleWithContra, this->subArms[i - 1]->GetPos(), 30, 10.0f, deltaTime, listObjectCollision);
						}
					else
					if (this->subArms[1]->GetAngle() > angleWithContra)
						for (int i = 1; i < 5; i++)
						{
							this->subArms[i]->Move(angleWithContra, this->subArms[i - 1]->GetPos(), 30, -1.0f, deltaTime, listObjectCollision);
						}
				}
			}
			//Khi quay cho 5s xong chuyen sang trang thai flow
			if (this->m_timeDelayFlow <= 0)
			{
				this->m_stateCurrent = BOSS_ARM_STATE::BAS_IS_ROTATE;
				this->m_timeDelayFlow = 4.0f;
			}
			this->m_timeDelayFlow -= deltaTime;
		#pragma endregion
			break;
		}
		case	BOSS_ARM_STATE::BAS_IS_DIE:
		{
												  break;
		}
	}
}

void CBossArm::Draw()
{
	for (int i = 0; i < 5; i++)
	{
		if (this->subArms[i]->IsAlive())
			CDrawObject::GetInstance()->Draw(this->subArms[i]);
	}
}

void CBossArm::Move(float curve, float deltaTime)
{

}

RECT* CBossArm::GetRectRS()
{
	RECT* rs = new RECT();
	rs->left = 0;
	rs->right = this->m_width;
	rs->top = 0;
	rs->bottom = this->m_height;
	return rs;
}

Box CBossArm::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height, this->m_vx, this->m_vy);
}

void CBossArm::SetAngle(float angle)
{
	this->subArms[0]->SetAngle(angle);
}