#include "CWallTurret.h"
#include "CContra.h"
#include <math.h>
#include "CCamera.h"
#include "CCollision.h"
#include "CPoolingObject.h"
#include "CEnemyEffect.h"
#include "CManageAudio.h"

CWallTurret::CWallTurret(void)
{
	this->Init();
}
	
CWallTurret::CWallTurret(const std::vector<int>& info)
{
	this->Init();
	if(!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
}

void CWallTurret::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 2;
	this->m_idType = 11; 
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 64.0f;
	this->m_height = 64.0f;
	this->m_pos = D3DXVECTOR2(1100.0f, 200.0f);
	this->m_left = false;

	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.35f;
	this->m_increase = 1;
	this->m_totalFrame = 42;
	this->m_column = 6;
	//
	this->m_isShoot = true;
	this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_START;
	//Test
	this->m_bulletCount = 0;
	this->m_timeDelay = 1.20f;
	this->m_waitForShoot = 0.0f;

	this->m_IsCre = false;
	this->m_direction = false;
	this->m_totalCurr = 0;
	this->m_oldangle = -1;

	this->m_allowShoot = true;
	this->m_HP = 7;
}

void CWallTurret::Update(float deltaTime)
{
	if (this->m_isALive)
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);
		this->OnCollision(deltaTime, nullptr);
	}
}

void CWallTurret::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame();
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);
		this->OnCollision(deltaTime, listObjectCollision);
	}
}
void CWallTurret::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
	{
		CBullet* obj = *it;
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
				this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_DIE;
				//Load sound die
				ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_DEAD_SFX);
				// Tang diem cua contra len
				CContra::GetInstance()->IncreateScore(500);
			}
		}
		else
			++it;
	}
}

void CWallTurret::BulletUpdate(float deltaTime)
{
#pragma region THIET LAP GOC BAN
	D3DXVECTOR2 posContra = CContra::GetInstance()->GetPos();
	double shootAngleNormal = PI / 6; //Goc Ban mac dinh
	double angleIncrease = PI / 12; //Goc tang khi kiem tra

	//Chuyen doi toa do Contra ve toa do theo vi tri cua WallTurret
	D3DXVECTOR2 posContraFlowWT = D3DXVECTOR2(posContra.x - this->m_pos.x, posContra.y - this->m_pos.y);
	double angle = GetShootAngle(posContraFlowWT, angleIncrease);

	//xet goc quy tu tu
	int temp = 0;
	this->m_space = abs(angle - this->m_oldangle);
	this->m_space = (this->m_space > PI) ? 2 * PI - this->m_space : this->m_space;
	if (this->m_oldangle == -1 || this->m_space == 0)
		this->m_oldangle = angle;
	else
	{
		if (angle < m_oldangle)
		{
			if (round2(m_oldangle) <= round2(PI))
				temp = -1;
			else
			{
				if (round2(m_oldangle - angle) >= round2(PI))
				{
					temp = 1;
					if (round2(m_oldangle) == round2(2 * PI))
						m_oldangle = 0;
				}
				else
					temp = -1;
			}
		}
		else
		{
			if (angle > m_oldangle)
			{
				if (round2(angle) >= round2(PI))
				{
					if (round2(angle - m_oldangle) >= round2(PI))
						temp = -1;
					else
						temp = 1;
				}
				else
					temp = 1;
			}
		}
		if (temp != 0)
		{
			this->m_timeDelay += deltaTime;
			if (this->m_timeDelay >	0.5f)
			{
				if (this->m_totalCurr < this->m_space)
				{
					if (temp > 0)
					{
						if (round2(m_oldangle) == round2(2 * PI))
							m_oldangle = 0;
					}
					else
					{
						if (m_oldangle == 0)
							m_oldangle = 2 * PI;
					}
					m_oldangle += temp*shootAngleNormal;
					this->m_totalCurr += shootAngleNormal;
				}
				else
				{
					this->m_oldangle = angle;
					this->m_totalCurr = 0;
				}
				this->m_timeDelay = 0;
			}
		}
	}

#pragma endregion

#pragma region THIET LAP TRANG THAI BAN
	if (this->m_isShoot)
	{
		double temp = m_oldangle;
		if (m_oldangle < 3 * PI / 2 && m_oldangle > PI / 2){
			this->m_direction = false;
		}
		else{
			this->m_direction = true;
		}
		if (m_oldangle < PI && m_oldangle > 0){
			this->m_IsCre = false;
		}
		else{
			this->m_IsCre = true;
		}

		temp = (temp < 0) ? 2 * PI + temp : temp;
		int tempdiv = int(temp / shootAngleNormal);
		tempdiv = ((temp - tempdiv*shootAngleNormal) > shootAngleNormal / 2) ? ++tempdiv : tempdiv;
		temp = (int(tempdiv)) * shootAngleNormal;

		switch (tempdiv)
		{
		case 0: case 6:
		{
					this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_NORMAL;
					break;
		}
		case 1: case 5:
		{
					this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_UP_X;
					break;
		}
		case 2: case 4:
		{
					this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_UP_2X;
					break;
		}
		case 3:
		{
				  this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_UP;
				  break;
		}
		case 7: case 11:
		{
					this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_DOWN_X;
					break;
		}
		case 8: case 10:
		{
					this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_DOWN_2X;
					break;
		}
		case 9:
		{
				  this->m_stateCurrent = WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DOWN;
				  break;
		}
		}
#pragma endregion

#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
		D3DXVECTOR2 offset;
		switch (this->m_stateCurrent)
		{
			case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_NORMAL:
			{
				if (this->m_direction){
					offset.x = this->m_width / 2;
					offset.y = 0.0f;
				}
				else{
					offset.x = -this->m_width / 2;
					offset.y = 0.0f;
				}
				break;
			}
			case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_UP:
			{
				if (this->m_direction){
					offset.x = 0;
					offset.y = this->m_height / 2;
				}
				else{
					offset.x = 0;
					offset.y = 0;
				}
				break;
			}
			case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_UP_X:
			{
				if (this->m_direction){
					offset.y = 15.0f;
					offset.x = this->m_width / 2;
				}
				else{
					offset.x = -this->m_width / 2;
					offset.y = this->m_height / 2 - 17.0f;
				}
				break;
			}
			case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_UP_2X:
			{
				if (this->m_direction){
					offset.y = 20.0f;
					offset.x = 10.0f;
				}
				else{
					offset.x = -10.0f;
					offset.y = 20.0f;
				}
				break;
			}
			case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DOWN:
			{
				if (this->m_direction){
					offset.x = 0.0f;
					offset.y = -this->m_height / 2;
				}
				else{
					offset.x = -this->m_width / 2;
					offset.y = 15.0f;
				}
				break;
			}
			case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_DOWN_X:
			{
				if (this->m_direction){
					offset.y = -10.0f;
					offset.x = this->m_width / 2;
				}
				else{
					offset.x = -this->m_width / 2;
					offset.y = -this->m_height / 2 + 10;
				}
				break;
			}
			case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_DOWN_2X:
			{
				if (this->m_direction){
					offset.y = -this->m_height / 2;
					offset.x = this->m_width / 2 - 15.0f;
				}
				else{
					offset.x = -this->m_width / 2 + 17.0f;
					offset.y = -this->m_height / 2 + 5;
				}
				break;
			}
			default:
			{
				break;
			}
		}
#pragma endregion

#pragma region THIET LAP TOC DO DAN
		if (m_oldangle == angle)
		{
			//Goc cua vien dan da duoc chinh san
			//Chuyen ve toa do goc phan tu 1 - 2
			if (m_bulletCount > 2)
			{
				this->m_bulletCount = 0;
				this->m_isShoot = true;
			}

			if (this->m_timeDelay > 1.2f)
			{
				temp = this->m_direction ? temp : PI - temp;
				CBullet_N* bullet = new CBullet_N(temp, this->m_pos, offset, !this->m_direction);
				bullet->SetLayer(LAYER::ENEMY);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				this->m_timeDelay = 0;
				m_bulletCount++;
			}
			this->m_timeDelay += deltaTime;
		}
	}
#pragma endregion

}

void CWallTurret::SetFrame()
{
	//Chuyen doi frame
	int currentFrame = this->m_currentFrame;
	switch (this->m_stateCurrent)
	{
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_START://ban ngang
	{
		this->m_startFrame = 41;
		this->m_endFrame = 36;
		break;
	}
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_NORMAL:
		{
			if (this->m_direction){
				this->m_startFrame = 12;
				this->m_endFrame = 14;
			}
			else{
				this->m_startFrame = 30;
				this->m_endFrame = 32;
			}
			break;
		}
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_UP:
	{
			this->m_startFrame = 3;
			this->m_endFrame = 5;
			break;
		}
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_UP_X:
		{
			if (this->m_direction){
				this->m_startFrame = 9;
				this->m_endFrame = 11;
			}
			else{
				this->m_startFrame = 33;
				this->m_endFrame = 35;
			}
			break;
		}
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_UP_2X:
		{
			if (this->m_direction){
				this->m_startFrame = 6;
				this->m_endFrame = 8;
			}
			else{
				this->m_startFrame = 0;
				this->m_endFrame = 2;
			}
			break;
		}
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DOWN:
		{
			this->m_startFrame = 21;
			this->m_endFrame = 23;
			break;
		}
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_DOWN_X:
		{
			if (this->m_direction){
				this->m_startFrame = 15;
				this->m_endFrame = 17;
			}
			else{
				this->m_startFrame = 27;
				this->m_endFrame = 29;
			}
			break;
		}
	case WALLTURRET_SHOOT_STATE::W_IS_SHOOTING_DIAGONAL_DOWN_2X:
		{
			if (this->m_direction){
				this->m_startFrame = 18;
				this->m_endFrame = 20;
			}
			else{
				this->m_startFrame = 24;
				this->m_endFrame = 26;
			}
			break;
		}
	case WALLTURRET_SHOOT_STATE::W_IS_DIE://Wallturret chet
	{
		CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
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

RECT* CWallTurret::GetBound()
{
	return nullptr;
}

RECT* CWallTurret::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CWallTurret::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 10, this->m_height - 10, 0, 0);
}

CWallTurret::~CWallTurret()
{

}

double CWallTurret::GetShootAngle(D3DXVECTOR2 posContraFlowWT, double angleIncrease)
{
	double angleTempl = checkAngleContraAndWallTurret(posContraFlowWT, angleIncrease);
	double angle = 0;
	if (round2(angleTempl) <= round2(angleIncrease) && round2(angleTempl) >= 0)//
	{
		//Goc phan tu II, III
		if (posContraFlowWT.x < 0)
			angle = 12 * angleIncrease;//180
		else//Goc phan tu I, IV
		if (posContraFlowWT.x > 0)
			angle = 0;//0
	}
	else{
		if (round2(angleTempl) <= round2(5 * angleIncrease) && round2(angleTempl) >= round2(3 * angleIncrease))//truong hop 2
		{
			//Goc phan u I
			angle = 4 * angleIncrease;//60
			//Goc phan tu II
			if (posContraFlowWT.x < 0 && posContraFlowWT.y > 0)
			{
				angle = 8 * angleIncrease;//120
			}
			else
			if (posContraFlowWT.x < 0 && posContraFlowWT.y < 0)
			{
				angle = 16 * angleIncrease;//240
			}
			else
			if (posContraFlowWT.x > 0 && posContraFlowWT.y < 0)
			{
				angle = 20 * angleIncrease;//300
			}

		}
		else
		if ((round2(angleTempl) < round2(3 * angleIncrease) && round2(angleTempl) > round2(angleIncrease)))
		{
			//Goc phan u I
			angle = 2 * angleIncrease;//30
			//Goc phan tu II
			if (posContraFlowWT.x < 0 && posContraFlowWT.y > 0)
				angle = 10 * angleIncrease;//150
			else
			if (posContraFlowWT.x < 0 && posContraFlowWT.y < 0)
				angle = 14 * angleIncrease;//210
			else
			if (posContraFlowWT.x > 0 && posContraFlowWT.y < 0)
				angle = 22 * angleIncrease;//330
		}
		else
		{
			//Goc phan tu I, II
			if (posContraFlowWT.y > 0)
				angle = angleTempl;//90
			else//Goc phan u III, IV
			if (posContraFlowWT.y < 0)
				angle = 18 * angleIncrease;//270
		}
	}
	return angle;
}

//Test location contra with walltime
double CWallTurret::checkAngleContraAndWallTurret(D3DXVECTOR2 contra_Pos, double angleIncrease)
{
	double tempAngle = angleIncrease;

	while (tempAngle != 6 * angleIncrease){
		if (round2(tempAngle) == round2(6 * angleIncrease))
			return tempAngle;
		else
		{
			if (abs(contra_Pos.y) <= abs(contra_Pos.x * tan(tempAngle)))
				return tempAngle;
			else
			{
				tempAngle += angleIncrease;
			}
		}
	}
}

double CWallTurret::round2(double a)
{
	if (((int)(a * 1000)) % 10 >= 5)
	{
		return ((double)((int)(a * 100 + 1))) / 100;
	}
	else
	{
		return ((double)((int)(a * 100))) / 100;
	}
}