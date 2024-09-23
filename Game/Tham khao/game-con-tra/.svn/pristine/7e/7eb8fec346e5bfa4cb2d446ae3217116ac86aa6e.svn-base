#include "CBigCapsule.h"
#include "CCollision.h"
#include "CContra.h"
#include "CCamera.h"
#include "CPoolingObject.h"
#include "CBulletCapsule.h"
#include "CStateGamePlay.h"
#include "CManageAudio.h"

CBigCapsule::CBigCapsule()
{
	this->Init();
}

CBigCapsule::CBigCapsule(const std::vector<int>& info)
{
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
	this->Init();//
}

void CBigCapsule::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 10;
	this->m_idType = 17;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 120.0f;
	this->m_height = 128.0f;
	//Khoi tao cac thong so di chuyens
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 13;
	this->m_column = 13;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	this->m_stateCurrent = BIG_CAPSULE_STATE::BIG_CAP_IS_HIDEN;
	//Khoi gan gia tri di chuyen
	this->m_vxDefault = 50.0f;
	this->m_vyDefault = 50.0f;
	this->m_vx = this->m_vxDefault;
	this->m_vy = this->m_vyDefault;
	this->m_left = true;
	//
	this->m_timeDelay = 0.40f;
	this->m_timeDelayWaitShoot = 1.20f;
	this->m_timeDelayWaitChangePos = 2.0f;
	this->m_timeDelayShootBullet = 0.90f;
	this->m_timeDelayShowWinner = 0.0f;
	this->m_HP = 30;
	//
	this->m_isShoot = false;
	this->m_allowShoot = true;
	this->m_isShowScenseScore = false;
	this->m_time = 0;
	this->m_bulletCount = 0;
	this->m_CapsuleCount = 0;
	this->m_countEffect = 0;
	this->m_spaceMoveCapsuleLeft = 150.0f;
	this->m_spaceMoveCapsuleRight = 150.0f;
}

void CBigCapsule::Update(float deltaTime)
{

}

void CBigCapsule::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->MoveUpdate(deltaTime);
		this->BulletUpdate(deltaTime, listObjectCollision);
		this->OnCollision(deltaTime, listObjectCollision);
	}
	else
	{
		this->BulletUpdate(deltaTime, listObjectCollision);
	}
}

void CBigCapsule::BulletUpdate(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	// Kiem tra, neu Gun alive thi tao dan, nguoc lai chi update ma thoi.
	if (this->IsAlive())
	{
	#pragma region KHOI TAO MOT VIEN DAN THEO HUONG
		D3DXVECTOR2 offset;
		offset.x = 0.0f;
		offset.y = 23.0f;
	#pragma endregion

#pragma region THIET LAP TOC DO DAN

		if (this->m_isShoot)
		{
			if (m_bulletCount > 0)
			{
				this->m_bulletCount = 0;
				this->m_isShoot = false;
			}

			if (this->m_timeDelayShootBullet >= 0.90f)
			{
				CBullet_Capsule* bullet = new CBullet_Capsule(-PI / 2, this->m_pos, offset, this->m_left);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				this->m_timeDelayShootBullet = 0;
				m_bulletCount++;
			}
			m_timeDelayShootBullet += deltaTime;
		}

	}
#pragma endregion
}

void CBigCapsule::MoveUpdate(float deltaTime)
{
#pragma region RamDom vi tri cua boss khi hiden
	this->resetPosOfBoss(deltaTime);
#pragma endregion
}

void CBigCapsule::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;

	if (this->m_currentFrame != 0)
	{
		for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin(); it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
		{
			CGameObject* obj = *it;
			if (obj->GetLayer() == LAYER::PLAYER)
			{
				timeCollision = CCollision::GetInstance()->Collision(obj, this, normalX, normalY, moveX, moveY, deltaTime);
				if ((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
				{
					if (obj->IsAlive())
					{
						this->m_HP--;

						CBulletEffect* effect = CPoolingObject::GetInstance()->GetBulletEffect();
						effect->SetAlive(true);
						effect->SetPos(obj->GetPos());

						it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
					}
					else
						++it;

					if (this->m_HP == 0)
					{
						// Gan trang thai die cho doi tuong
						this->m_stateCurrent = BIG_CAPSULE_STATE::BIG_CAP_IS_DIE;
						//Cho cac capsule chet theo
						for (std::vector<CCapsuleBoss*>::iterator it = CPoolingObject::GetInstance()->m_listCapsuleBoss.begin();
							it != CPoolingObject::GetInstance()->m_listCapsuleBoss.end();
							++it)
						{
							CCapsuleBoss* obj = *it;
							if (obj != NULL && obj->IsAlive())
							{
								obj->SetAlive(false);
								obj->m_stateCurrent = CAPSULE_STATE::CAP_IS_DIE;
								//obj->SetFrame(deltaTime);
							}

						}
						// Tang diem cua contra len
						CContra::GetInstance()->IncreateScore(15000);
					}
				}
				else
				{
					++it;
				}
			}
			else
				++it;
		}
	}
}

void CBigCapsule::SetFrame(float deltaTime)
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
		case BIG_CAPSULE_STATE::BIG_CAP_IS_START:
		{
			this->m_increase = 1;
			//
			this->m_startFrame = 1;
			this->m_endFrame = 6;
			//Time delay 2 s rui ban dan
			if (this->m_timeDelayWaitShoot <= 0.0f)
			{
				this->m_timeDelayWaitShoot = 1.20f;
				this->m_stateCurrent = BIG_CAPSULE_STATE::BIG_CAP_IS_NORMAL;
			}
			else
				this->m_timeDelayWaitShoot -= deltaTime;
			break;
		}
		case BIG_CAPSULE_STATE::BIG_CAP_IS_NORMAL:
		{
			this->m_increase = 1;
			this->m_startFrame = 6;
			this->m_endFrame = 12;
			if (this->m_currentFrame == 12)
			{
				this->m_increase = 0;
				this->m_isShoot = true;
				if (this->m_CapsuleCount == 8)
				{
					this->m_increase = 1;
					this->m_CapsuleCount = 0;
					this->m_stateCurrent = BIG_CAPSULE_STATE::BIG_CAP_IS_HIDEN;
				}

				//Time delay 2 s sinh ra capsule
				if (this->m_timeDelay <= 0.0f)
				{
					//Load sound
					ManageAudio::GetInstance()->playSound(TypeAudio::ENEMY_ATTACKED_SFX);
					this->m_timeDelay = 0.40f;
					CCapsuleBoss* capsule = CPoolingObject::GetInstance()->GetCapsuleBoss();
					capsule->Init();
					if (this->m_CapsuleCount % 2 != 0)
					{
						capsule->SetLeft(true);
						capsule->SetPos(D3DXVECTOR2(this->m_pos.x + 40, this->m_pos.y + 24));
						capsule->m_space = this->m_spaceMoveCapsuleRight;
					}
					else
					{
						capsule->SetLeft(false);
						capsule->SetPos(D3DXVECTOR2(this->m_pos.x - 40, this->m_pos.y + 24));
						capsule->m_space = this->m_spaceMoveCapsuleLeft;
					}
					capsule->SetAlive(true);
					capsule->m_spaceCurrent = 0;
					capsule->m_isCollisonWithGround = false;
					this->m_CapsuleCount++;
				}
				else
					this->m_timeDelay -= deltaTime;
			}
			break;
		}
		case BIG_CAPSULE_STATE::BIG_CAP_IS_BACK:
		{
			this->m_increase = -1;
			this->m_startFrame = 6;
			this->m_endFrame = 12;
			this->m_isShoot = false;
			break;
		}
		case BIG_CAPSULE_STATE::BIG_CAP_IS_HIDEN:
		{
			this->m_increase = 1;
			this->m_startFrame = 0;
			this->m_endFrame = 0;
			this->m_isShoot = false;
			break;
		}
		case BIG_CAPSULE_STATE::BIG_CAP_IS_DIE:
		{
			CCapsuleBoss* capsule = CPoolingObject::GetInstance()->GetCapsuleBoss();
			capsule->m_stateCurrent = CAPSULE_STATE::CAP_IS_DIE;
			capsule->SetFrame();

			if (this->m_countEffect <= 5)
			{
				D3DXVECTOR2 posEffect;
				switch (this->m_countEffect)
				{
				case 0:
					posEffect = this->m_pos;
					break;
				case 1:
					posEffect = D3DXVECTOR2(this->m_pos.x - 25, this->m_pos.y - 20);
					break;
				case 2:
					posEffect = D3DXVECTOR2(this->m_pos.x + 25, this->m_pos.y - 20);
					break;
				case 3:
					posEffect = D3DXVECTOR2(this->m_pos.x - 25, this->m_pos.y + 20);
					break;
				case 4:
					posEffect = D3DXVECTOR2(this->m_pos.x + 25, this->m_pos.y + 20);
					break;
				}

				// Lay doi tuong ra
				CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
				effect->SetAlive(true);
				effect->SetPos(posEffect);
				this->m_countEffect++;
			}
			else
			{
				if (!CScenseManagement::m_isWinScenseShowed)
				{
					//gan cho bien hien thi mann hinh diem qua man
					//CContra::GetInstance()->m_isBossCurrentDie = true;
					CScenseManagement::m_isWinScenseShowed = true;
					CScenseManagement::m_isGameWinner = true;
				}
				else
					this->m_isALive = false;
			}
			break;
		}
	}
}

RECT* CBigCapsule::GetBound()
{
	return nullptr;
}

RECT* CBigCapsule::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CBigCapsule::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width - 20, this->m_height - 56);
}
CBigCapsule::~CBigCapsule()
{

}
//tinh
void CBigCapsule::resetPosOfBoss(float deltaTime)
{
	//Khoi tao danh sach cac vi tri cua boss
	D3DXVECTOR2 listOffSet[3][4] = { { D3DXVECTOR2(9779, 266), D3DXVECTOR2(9774, 346), D3DXVECTOR2(9782, 299), D3DXVECTOR2(9827, 291) },
									{ D3DXVECTOR2(9881, 303), D3DXVECTOR2(9883, 270), D3DXVECTOR2(9941, 295), D3DXVECTOR2(9880, 350) },
									{ D3DXVECTOR2(10046, 349), D3DXVECTOR2(9986, 307), D3DXVECTOR2(9993, 275), D3DXVECTOR2(9999, 351)} };

	switch (this->m_stateCurrent)
	{
		case BIG_CAPSULE_STATE::BIG_CAP_IS_HIDEN:
		{
		if (this->m_currentFrame == 0)
		{
			//Time delay 2 s rui ban dan
			if (this->m_timeDelayWaitChangePos <= 0.0f)
			{
				this->m_timeDelayWaitChangePos = 2.0f;
				//vi tri
				int tempX = rand() % 3;
				int tempY = rand() % 4;
				D3DXVECTOR2 pos = listOffSet[tempX][tempY];
				//Thiet lap
				if (this->m_pos != pos)
					this->m_pos = pos;
				else
					pos = listOffSet[0][0];

				//Vung di chuyen cua may con boss nho
				switch (tempX)
				{
				case 0:
					this->m_spaceMoveCapsuleRight = 200;
					this->m_spaceMoveCapsuleLeft = 40;
					break;
				case 1:
					this->m_spaceMoveCapsuleRight = 150;
					this->m_spaceMoveCapsuleLeft = 140;
					break;
				case 2:
					this->m_spaceMoveCapsuleRight = 50;
					this->m_spaceMoveCapsuleLeft = 200;
					break;
				default:
					break;
				}

				this->m_stateCurrent = BIG_CAPSULE_STATE::BIG_CAP_IS_START;
			}
			else
				this->m_timeDelayWaitChangePos -= deltaTime;
		}
		break;
		}
		default:
			break;
	}
}