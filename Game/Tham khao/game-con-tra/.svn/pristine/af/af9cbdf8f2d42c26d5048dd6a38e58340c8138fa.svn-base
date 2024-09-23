#include "CMechanicalAlien.h"
#include "CCollision.h"
#include "CContra.h"
#include "CPoolingObject.h"
#include "CStateGamePlay.h"
#include "CManageAudio.h"

CMechanicalAlien::CMechanicalAlien(void)
{
	this->Init();
}

CMechanicalAlien::CMechanicalAlien(const std::vector<int>& info)
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

void CMechanicalAlien::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 5;
	this->m_idType = 17;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 512.0f;
	this->m_height = 300.0f;
	//Khoi tao cac thong so di chuyens
	this->m_left = false;
	this->m_isDie = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 3;
	this->m_column = 3;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	this->m_stateCurrent = STATE_MECHANICAL_ALIEN::SMA_IS_START;
	//
	this->m_timeDelay = 0.40f;
	this->m_timeDelayStartBoss = 0.60f;
	this->m_timeDelayEffect = 1.0f;

	//Tao moi cac thanh phan boss
	this->m_Head = new CHeadBoss(this->m_pos);
	this->m_ArmLeft = new CBossArm(this->m_pos, true);
	this->m_ArmRight = new CBossArm(this->m_pos, false);
}

void CMechanicalAlien::Update(float deltaTime)
{
	this->SetFrame(deltaTime);
	this->ChangeFrame(deltaTime);
}

void CMechanicalAlien::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	if (this->m_isALive)
	{
		if (this->m_Head->IsAlive())
		{
			this->SetFrame(deltaTime);
			this->ChangeFrame(deltaTime);
			this->m_Head->Update(deltaTime, listObjectCollision);
			if (this->m_ArmLeft->IsAlive())
				this->m_ArmLeft->Update(deltaTime, listObjectCollision);
			if (this->m_ArmRight->IsAlive())
				this->m_ArmRight->Update(deltaTime, listObjectCollision);
		}
		else
		{
			this->m_ArmLeft->SetAlive(false);
			this->m_ArmRight->SetAlive(false);
			if (this->m_timeDelayEffect <= 0 && !this->m_isEffect)
			{
				this->m_stateCurrent = STATE_MECHANICAL_ALIEN::SMA_IS_DIE;
				this->m_isEffect = true;
				this->m_timeDelayEffect = 1.0f;
			}
			else
				this->m_timeDelayEffect -= deltaTime;
			this->SetFrame(deltaTime);
		}
	}
}

void CMechanicalAlien::SetFrame(float deltaTime)
{
	//Chuyen doi frame
	switch (this->m_stateCurrent)
	{
		case STATE_MECHANICAL_ALIEN::SMA_IS_START:
		{
											this->m_startFrame = 0;
											this->m_endFrame = 0;
											//Time delay 8 s rui ban dan
											if (this->m_timeDelayStartBoss <= 0.0f)
											{
												this->m_timeDelayStartBoss = 0.60f;
												this->m_stateCurrent = STATE_MECHANICAL_ALIEN::SMA_IS_NORMAL;
											}
											else
												this->m_timeDelayStartBoss -= deltaTime;
											break;
		}
		case STATE_MECHANICAL_ALIEN::SMA_IS_NORMAL:
		{
											this->m_startFrame = 1;
											this->m_endFrame = 1;
											break;
		}
		case  STATE_MECHANICAL_ALIEN::SMA_IS_DIE:
		{
											this->m_currentFrame = 2;
											this->m_startFrame = 2;
											this->m_endFrame = 2;
											//Load sound boss die
											ManageAudio::GetInstance()->playSound(TypeAudio::BOSS_DEAD_SFX);

											if (this->m_countEffect <= 14)
											{
												D3DXVECTOR2 posEffect;
												switch (this->m_countEffect)
												{
													//4 cai tren dau
												case 0:
													posEffect = D3DXVECTOR2(this->m_pos.x - 100, this->m_pos.y + 160);
													break;
												case 1:
													posEffect = D3DXVECTOR2(this->m_pos.x + 100, this->m_pos.y + 160);
													break;
												case 2:
													posEffect = D3DXVECTOR2(this->m_pos.x - 35, this->m_pos.y + 160);
													break;
												case 3:
													posEffect = D3DXVECTOR2(this->m_pos.x + 35, this->m_pos.y + 160);
													break;
													//10 cai tren dau
												case 4:
													posEffect = D3DXVECTOR2(this->m_pos.x - 35, this->m_pos.y + 110);
													break;
												case 5:
													posEffect = D3DXVECTOR2(this->m_pos.x + 35, this->m_pos.y + 110);
													break;
												case 6:
													posEffect = D3DXVECTOR2(this->m_pos.x - 35, this->m_pos.y + 60);
													break;
												case 7:
													posEffect = D3DXVECTOR2(this->m_pos.x + 35, this->m_pos.y + 60);
													break;
												case 8:
													posEffect = D3DXVECTOR2(this->m_pos.x - 35, this->m_pos.y + 10);
													break;
												case 9:
													posEffect = D3DXVECTOR2(this->m_pos.x + 35, this->m_pos.y + 10);
													break;
												case 10:
													posEffect = D3DXVECTOR2(this->m_pos.x - 35, this->m_pos.y - 40);
													break;
												case 11:
													posEffect = D3DXVECTOR2(this->m_pos.x + 35, this->m_pos.y - 40);
													break;
												case 12:
													posEffect = D3DXVECTOR2(this->m_pos.x - 35, this->m_pos.y - 80);
													break;
												case 13:
													posEffect = D3DXVECTOR2(this->m_pos.x + 35, this->m_pos.y - 80);
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
												//Cho 1 thoi gian
												if (this->m_timeDelay <= 0)
												{ 
													this->m_timeDelay = 0.40f;
													this->m_isDie = false;
													//Dung load sound boss die
													ManageAudio::GetInstance()->stopSound(TypeAudio::BOSS_DEAD_SFX);
													//
													//gan cho bien hien thi mann hinh diem qua man
													if (!CScenseManagement::m_isWinScenseShowed)
														CContra::GetInstance()->m_isBossCurrentDie = true;
													else
														this->m_isALive = false;
												}
												else
												{
													this->m_timeDelay -= deltaTime;
												}
											}
											}
											 break;
	}
}

RECT* CMechanicalAlien::GetBound()
{
	return nullptr;
}

RECT* CMechanicalAlien::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CMechanicalAlien::GetBox()
{
	return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height);
}

void CMechanicalAlien::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{

}


CMechanicalAlien::~CMechanicalAlien()
{

}