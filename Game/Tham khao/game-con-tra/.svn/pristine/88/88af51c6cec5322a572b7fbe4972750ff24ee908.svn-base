#include "CExplosionEffect.h"


CExplosionEffect::CExplosionEffect() : CDynamicObject(){
	this->Init();
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
	this->Init();
}

CExplosionEffect::CExplosionEffect(D3DXVECTOR2 pos){
	this->m_pos = pos;
	this->Init();
}

void CExplosionEffect::Init(){
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 1;
	this->m_idType = 18;
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 60.0f;//56.0f; //78
	this->m_height = 60.0f; //88.0f; //84
	//Chuyen doi sprite
	this->m_totalFrame = 4;
	this->m_column = 4;
	this->m_startFrame = 0;
	this->m_endFrame = 3;
	this->m_elapseTimeChangeFrame = 0.35f;
	this->m_currentTime = 0;
	this->m_increase = 1;
	this->m_currentFrame = 0;
}

void CExplosionEffect::ChangeFrame(float deltaTime)
{
	this->m_currentTime += deltaTime;
	if (this->m_currentTime > this->m_elapseTimeChangeFrame)
	{
		this->m_currentFrame += this->m_increase;
		if (this->m_currentFrame > this->m_endFrame){
			this->m_currentFrame = 0;
			this->m_isALive = false;
			this->m_currentFrame = this->m_startFrame;
		}
		if (this->m_currentFrame > this->m_endFrame || this->m_currentFrame < this->m_startFrame)
		{
			this->m_currentFrame = this->m_startFrame;
		}
		this->m_currentTime -= this->m_elapseTimeChangeFrame;
	}
}

void CExplosionEffect::Update(float deltaTime)
{
	this->ChangeFrame(deltaTime);
}

void CExplosionEffect::Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision){

}

RECT* CExplosionEffect::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

RECT* CExplosionEffect::GetBound()
{
	return nullptr;
}

Box CExplosionEffect::GetBox()
{
	return Box();
}

CExplosionEffect::~CExplosionEffect()
{

}