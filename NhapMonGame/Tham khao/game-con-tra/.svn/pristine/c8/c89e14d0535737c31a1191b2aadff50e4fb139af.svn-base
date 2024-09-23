#include "CDefenseCannon.h"
#include "CContra.h"
#include <math.h>
#include "CCamera.h"
#include "CPoolingObject.h"
#include "CStateGamePlay.h"
#include "CManageAudio.h"

CDefenseCannon::CDefenseCannon(void)
{
	this->Init();
}

CDefenseCannon::CDefenseCannon(const std::vector<int>& info)
{
	
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		//this->m_width = info.at(3);
		//this->m_height = info.at(4);
	}
	this->Init();
}

void CDefenseCannon::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 1;
	this->m_idType = 17;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 224.0f;
	this->m_height = 368.0f;
	this->m_left = false;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_oldFrame = 0;
	this->m_count = 0;
	this->m_elapseTimeChangeFrame = 0.45f;
	this->m_increase = 1;
	this->m_totalFrame = 11;
	this->m_column = 4;
	//

	// cho nay la sao, moi dzo die lien ha
	//@@
	this->m_stateCurrent = DEFENSE_CANNON_STATE::DC_NORMAL;
	//Test
	this->m_timeDelay = 0.25f;

	//Khoi tao cac doi tuong con
	std::vector<int> info;
	info.push_back(17004);
	info.push_back(this->m_pos.x - 80);
	info.push_back(this->m_pos.y + 145);
	info.push_back(48);
	info.push_back(80);
	this->sniper = new CSniperBoss(info);

	this->gunLeft = new CDefenseCannonGun(true, this->m_pos.x, this->m_pos.y);
	this->gunRight = new CDefenseCannonGun(false, this->m_pos.x, this->m_pos.y);
	this->turrect = new CDefenseCannonTurret(this->m_pos.x, this->m_pos.y);

	//
	this->m_allowShoot = true;
}

void CDefenseCannon::Update(float deltaTime)
{
}

void CDefenseCannon::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		//////Update cho cac doi tuong con
		//Co doi tuong linh nup tren dau nua
		// update effect isalive
		if (this->sniper->IsAlive())
			this->sniper->Update(deltaTime, listObjectCollision);
		//
		if (this->turrect->IsAlive())
			this->turrect->Update(deltaTime, listObjectCollision);

		// TT test
		// 2 gun die
		if (!this->gunLeft->IsAlive())
		{
			this->m_stateCurrent = DEFENSE_CANNON_STATE::DC_GUNLEFT_DIE;
		}
		if (!this->gunRight->IsAlive())
		{
			this->m_stateCurrent = DEFENSE_CANNON_STATE::DC_GUNRIGHT_DIE;
		}

		// Boss die
		if (!this->turrect->IsAlive())
		{
			this->sniper->SetAlive(false);
			this->m_stateCurrent = DEFENSE_CANNON_STATE::DC_IS_DIE;
		}

		this->gunLeft->Update(deltaTime, listObjectCollision);
		this->gunRight->Update(deltaTime, listObjectCollision);
	}
}

void CDefenseCannon::SetFrame(float deltaTime)
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
	case DEFENSE_CANNON_STATE::DC_NORMAL:
		{
			this->m_startFrame = 0;
			this->m_endFrame = 0;
			break;
		}

	case DEFENSE_CANNON_STATE::DC_FIRE_ONE_GUN:
		{
			this->gunLeft->SetAlive(false) ;
			this->m_startFrame = 1;
			this->m_endFrame = 1;
			break;
		}
	case DEFENSE_CANNON_STATE::DC_FIRE_TWO_GUN:
		{
			this->gunLeft->SetAlive(false);
			this->gunRight->SetAlive(false);
			this->m_startFrame = 2;
			this->m_endFrame = 2;
			break;
		}
	case DEFENSE_CANNON_STATE::DC_FIRE_TURRECT:
		{
			this->gunLeft->SetAlive(false);
			this->gunRight->SetAlive(false);
			this->turrect->SetAlive(false);
			this->m_startFrame = 2;
			this->m_endFrame = 2;
			break;
		}

	case DEFENSE_CANNON_STATE::DC_GUNLEFT_DIE:
		{
			this->m_currentFrame = 1;
			this->m_startFrame = 1;
			this->m_endFrame = 1;
			break;
		}

	case DEFENSE_CANNON_STATE::DC_GUNRIGHT_DIE:
		{
			this->m_currentFrame = 2;
			this->m_startFrame = 2;
			this->m_endFrame = 2;
			break;
		}

	case DEFENSE_CANNON_STATE::DC_IS_DIE:
		{
			this->gunLeft->SetAlive(false);
			this->gunRight->SetAlive(false);
			this->turrect->SetAlive(false);
			this->m_startFrame = 4;
			this->m_endFrame = 11;
			//Load sound boss die
			ManageAudio::GetInstance()->playSound(TypeAudio::BOSS_DEAD_SFX);
			//Tinh
			if (m_currentFrame != m_oldFrame)
			{
				m_oldFrame = m_currentFrame;
				CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
				D3DXVECTOR2 posEff;
				if (this->m_currentFrame % 2 == 0)
				{
					posEff.x = this->m_pos.x - 90 + 30 * this->m_count;
					posEff.y = this->m_pos.y - 40;
					this->m_count++;
				}
				else
				{
					posEff.x = this->m_pos.x - 90 + 30 * (this->m_count - 1);
					posEff.y = this->m_pos.y - 105;
					this->m_count++;
				}
				effect->SetAlive(true);
				effect->SetPos(posEff);
			}
			//tinh
			if (this->m_currentFrame == 11) 
			{
				this->m_currentFrame = 11;
				this->m_startFrame = 11;
				this->m_endFrame = 11;
			
				//Dung play sound boss die
				ManageAudio::GetInstance()->stopSound(TypeAudio::BOSS_DEAD_SFX);

				if (!CScenseManagement::m_isWinScenseShowed)
				//gan cho bien hien thi mann hinh diem qua man
					CContra::GetInstance()->m_isBossCurrentDie = true;
				else
					this->m_isALive = false;
			}
			break;
		}
	default:
		break;
	}
}

RECT* CDefenseCannon::GetBound()
{
	return nullptr;
}

RECT* CDefenseCannon::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CDefenseCannon::GetBox()
{
	return Box();
}

CDefenseCannon::~CDefenseCannon()
{

}