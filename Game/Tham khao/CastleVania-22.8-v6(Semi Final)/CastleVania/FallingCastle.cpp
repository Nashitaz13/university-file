#include "FallingCastle.h"


FallingCastle::FallingCastle(void)
{
}

FallingCastle::FallingCastle(float posX_, float posY_, float vX_, float vY_):DynamicObject(posX_,posY_,vX_,vY_,EnumID::FallingCastle_ID)
{
	_sprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::FallingCastle_ID),0,2,1);
	_simonInCastleSprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::SimonInCastle_ID),0,1,1000/SIMON_IN_CASTLE_RATE);
	_posX0 = posX;
	_posY0 = posY;
	_localTime = 0;
	_isFalled = false;
}

void FallingCastle::Draw(CCamera* camera_)
{
	// draw castle falling down 1
	D3DXVECTOR2 center = camera_->Transform(_posX0,_posY0);
	this->_sprite->DrawIndex(0,center.x,center.y);

	// draw castle falling down 2
	center = camera_->Transform(posX,posY);
	this->_sprite->DrawIndex(1,center.x,center.y);

	// draw simon in castle
	center = camera_->Transform(posX+134,posY+105);
	this->_simonInCastleSprite->Draw(center.x, center.y);

	// draw castle falling down 3
	center = camera_->Transform(_posX0,_posY0);
	this->_sprite->DrawIndex(2,center.x,center.y);


}

bool FallingCastle::isFalled()
{
	return _isFalled;
}

void FallingCastle::Update(int deltaTime_)
{
	if(_isFalled)
		return;
	_localTime+= deltaTime_;
	if(_localTime >= 1000/FALLING_CASTLE_RATE)
	{
		this->posX += vX*deltaTime_;
		vX = - vX;
		this->posY -= vY*deltaTime_;
		float deltaY = -(posY-_posY0);
		if(deltaY>= FALLING_CASTLE_DELTA_Y_MAX)
			_isFalled = true;
		SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_FallingCastle);
	}
	_simonInCastleSprite->Update(deltaTime_);
}


FallingCastle::~FallingCastle(void)
{
}
