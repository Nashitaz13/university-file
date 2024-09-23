#include "MorningStar.h"

MorningStar::MorningStar(void):GameObject()
{
}

MorningStar::MorningStar(int posX_, int posY_, float vx_, float vy_, EnumID id_, int timeAnimation_):GameObject(posX_,posY_,id_)
{
	vX = vx_;
	vY = vy_;
	_morningStarSprite = new MorningStarSprite(Singleton::getInstance()->getTexture(EnumID::MorningStar_ID),0,2,timeAnimation_);
}

void MorningStar::reset()
{
	_morningStarSprite->Reset();
}

void MorningStar::Update(int deltaTime_)
{
	_morningStarSprite->Update(deltaTime_);
}

void MorningStar::Draw(CCamera* camera_)
{
	D3DXVECTOR2 center = camera_->Transform(posX, posY);
	if(vX > 0)
	{
		_morningStarSprite->DrawFlipX(center.x, center.y);
		
	}
	else
	{
		_morningStarSprite->Draw(center.x, center.y);
	}

}

Box MorningStar::GetBox()
{
	int currentState = _morningStarSprite->GetIndex();
	if(currentState < 0||currentState > 8)
		return Box(0,0,0,0);
	LKRect* morningStarSize = this->_morningStarSprite->getMorningStarSize().at(currentState);
	return Box(posX-morningStarSize->width/2,posY+morningStarSize->height/2,morningStarSize->width,morningStarSize->height);
}

void MorningStar::updateXY(int posX_, int posY_)
{
	float morningStarX = 0;
	float morningStarY = 0;
	int morningState = this->_morningStarSprite->GetIndex();
	posX = posX_;
	posY = posY_;


	switch (morningState%3)
	{
	case 0:
		morningStarX = posX-30;
		morningStarY = posY-5;
		break;
	case 1:
		morningStarX = posX-30;
		morningStarY = posY+2;
		break;
	case 2:
		morningStarX = posX+50;
		morningStarY = posY+8;   
		break;
	default:
		int i = 0;
		break;
	}
	if(vX > 0)
	{
	}
	else
	{
		switch (morningState%3)
		{
		case 0:
			morningStarX = (posX+60) + (posX-morningStarX-16 -40);
			break;
		case 1:
			morningStarX = (posX+60) + (posX-morningStarX-32 -30);
			break;
		case 2:
			morningStarX = (posX+60) + (posX-morningStarX-56 -5);
			break;
		default:
			break;
		}
	}
	this->posX = morningStarX;
	this->posY = morningStarY;
}

void MorningStar::updateVx(float vx_)
{
	vX = vx_;
}
void MorningStar::updateLevel()
{
	this->_morningStarSprite->updateLevel();
}
	
void MorningStar::Collision(list<GameObject*> &obj, int dt)
{
	list<GameObject*>::reverse_iterator _itBegin;
	for (_itBegin = obj.rbegin(); _itBegin != obj.rend(); _itBegin++)
	{		
		GameObject* other = (*_itBegin);
		if(other->type == ObjectType::Item_Type
			|| other->id == EnumID::MagicalCrystal_ID || other->id == EnumID::StairDownLeft_ID
			|| other->id == EnumID::StairDownRight_ID || other->id == EnumID::StairUpLeft_ID
			|| other->id == EnumID::StairUpRight_ID || other->id == EnumID::MovingPlatform_ID
			|| other->id == EnumID::DoorDown_ID || other->id == EnumID::DoorUp_ID
			|| other->id == EnumID::DoorLeft_ID || other->id == EnumID::DoorRight_ID
			|| other->id == EnumID::CastleGate_ID || other->id == EnumID::StupidDoor_ID)
		{
		}
		else
		{
			float moveX;
			float moveY;

			Box box = this->GetBox();
			Box boxOther = other->GetBox();

			if(AABB(box, boxOther, moveX, moveY) == true)
			{
				if(other->id != EnumID::Brick_ID)
				{
					if(other->id == EnumID::QueenMedusa_ID)
					{
						QueenMedusa* qm = (QueenMedusa*)other;
						if(qm->_hasGetUp)
						{
							other->ReceiveDamage(damage);
							if(other->hp <= 0)
							{
								point += other->point;
							}
						}
						else
							qm->getUp();
					}
					else if(other->id == EnumID::PhantomBat_ID)
					{
						other->ReceiveDamage(damage);
						if(other->hp <= 0)
						{
							point += other->point;
						}
					}
					else
					{
						other->ReceiveDamage(damage);
						if(other->hp <= 0)
						{
							point += other->point;
							(*_itBegin) = new FireDie(other->posX, other->posY);
						}
					}
					SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_HitByWeapon);		
				}
				return;
			}
		}
	}
}


MorningStar::~MorningStar(void)
{
}

MorningStarSprite* MorningStar::getSprite()
{
	return this->_morningStarSprite;
}
