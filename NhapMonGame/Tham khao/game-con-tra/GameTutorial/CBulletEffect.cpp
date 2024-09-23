#include "CBulletEffect.h"

CBulletEffect::CBulletEffect() : CDynamicObject(){
	this->Init();
	this->m_pos = D3DXVECTOR2(0.0f, 0.0f);
}

CBulletEffect::CBulletEffect(D3DXVECTOR2 pos){
	this->m_pos = pos;
	this->Init();
}

void CBulletEffect::Init(){
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 2;
	this->m_idType = 18;
	this->m_idImage = 0;
	this->m_isALive = false;
	this->m_isAnimatedSprite = true;
	this->m_width = 14.0f;//56.0f; //78
	this->m_height = 14.0f; //88.0f; //84
	//Chuyen doi sprite
	this->m_totalFrame = 1;
	this->m_column = 1;
	this->m_elapseTimeChangeFrame = 0.3f;
	this->m_currentTime = 0;
	this->m_increase = 1;
	this->m_currentFrame = 0;
}

void CBulletEffect::ChangeFrame(float deltaTime)
{
	this->m_currentTime += deltaTime;
	if (this->m_currentTime > this->m_elapseTimeChangeFrame)
	{
		this->m_currentFrame += this->m_increase;
		if (this->m_currentFrame >= 0){
			this->m_currentFrame = 0;
			this->m_isALive = false;
		}
		if (this->m_currentFrame > 0 || this->m_currentFrame < 0)
		{
			this->m_currentFrame = 0;
		}
		this->m_currentTime -= this->m_elapseTimeChangeFrame;
	}

}

void CBulletEffect::Update(float deltaTime)
{
	this->ChangeFrame(deltaTime);
}

void CBulletEffect::Update(float deltaTime, std::vector<CGameObject*> _listObjectCollision){

}

RECT* CBulletEffect::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}

RECT* CBulletEffect::GetBound()
{
	return nullptr;
}

Box CBulletEffect::GetBox()
{
	return Box();
}

CBulletEffect::~CBulletEffect()
{

}