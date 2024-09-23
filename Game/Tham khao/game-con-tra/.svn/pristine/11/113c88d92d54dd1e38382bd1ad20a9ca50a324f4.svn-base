#include "CBridge.h"
#include "CCollision.h"
#include "CContra.h"
#include "CPoolingObject.h"
#include "CManageAudio.h"

CBridge::CBridge(void)
{
	this->Init();
}

CBridge::CBridge(const std::vector<int>& info)
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

void CBridge::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 1;
	this->m_idType = 16;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 256.0f;//56.0f; //78
	this->m_height = 64.0f; //88.0f; //84
	this->m_pos = D3DXVECTOR2(1663.0f, 223.0f);
	//Khoi tao cac thong so di chuyen
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 1.3f;
	this->m_increase = 1;
	this->m_totalFrame = 5;
	this->m_column = 1;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	//
	this->m_timeDelay = 1.3f;
	
	this->m_stateCurrent = STATE_BRIDGE::X4;

}

void CBridge::Update(float deltaTime)
{
	//if(CContra::GetInstance()->m_bridgeEffect)
	//{
	//	this->SetFrame(deltaTime); //Cai ham nay bo vao cho changeFrame, tuc la sau moi lan Frame thay doi thi set lai frame
	//	this->ChangeFrame(deltaTime);
	//}
}

void CBridge::Update(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
	float m_distance = this->m_pos.x - CContra::GetInstance()->GetPos().x - this->m_width/2;

	if(CContra::GetInstance()->m_bridgeEffect && m_distance <= 10.0f)
	{
		this->SetFrame(deltaTime); //Cai ham nay bo vao cho changeFrame, tuc la sau moi lan Frame thay doi thi set lai frame
		this->ChangeFrame(deltaTime);
	}
}

void CBridge::SetFrame(float deltaTime)
{
	this->m_timeDelay += deltaTime;
	if(m_timeDelay > 1.0f)
	{
		this->m_timeDelay = 0.0f;
		this->m_currentFrame += this->m_increase;
		if(this->m_currentFrame < 5)
		{
			this->m_startFrame = this->m_currentFrame;
			this->m_endFrame = this->m_currentFrame;
			if(this->m_isALive)
			{
				//Load am thanh no
				ManageAudio::GetInstance()->playSound(TypeAudio::BRIDGE_BURN_SFX);
				//
				D3DXVECTOR2 posEff(this->GetBox().x - 5*this->GetBox().w/8, this->GetBox().y);
				CExplosionEffect* effect = CPoolingObject::GetInstance()->GetExplosionEffect();
				effect->SetPos(D3DXVECTOR2(posEff.x /*+ this->m_width / 4*/, posEff.y));
				effect->SetAlive(true);
				//
				CExplosionEffect* effect1 = CPoolingObject::GetInstance()->GetExplosionEffect();
				effect1->SetPos(D3DXVECTOR2(posEff.x + 20 /*+ this->m_width / 4*/, posEff.y + 25));
				effect1->SetAlive(true);

				//
				CExplosionEffect* effect2 = CPoolingObject::GetInstance()->GetExplosionEffect();
				effect2->SetPos(D3DXVECTOR2(posEff.x - 20 /*+ this->m_width / 4*/, posEff.y + 25));
				effect2->SetAlive(true);
			}
		}
		else
		{
			this->m_isALive = false;
			ManageAudio::GetInstance()->stopSound(TypeAudio::BRIDGE_BURN_SFX);
		}
	}
}

RECT* CBridge::GetBound()
{
	return nullptr;
}

RECT* CBridge::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

Box CBridge::GetBox()
{
	switch (this->m_currentFrame)
	{
		case 0:
			return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height);
		case 1:
			return Box(this->m_pos.x+32, this->m_pos.y, this->m_width-64, this->m_height);
		case 2:
			return Box(this->m_pos.x+32*2, this->m_pos.y, this->m_width-64*2, this->m_height);
		case 3:			
			return Box(this->m_pos.x+32*3, this->m_pos.y, this->m_width-64*3, this->m_height);
	}
	return Box(this->m_pos.x+32*4 - 20, this->m_pos.y, 0, 0);
}

void CBridge::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
}


CBridge::~CBridge()
{

}