
#include "FireBomb.h"



void FireBomb::_initialize()
{
	_localTime = 0;
	_gold = new D3DXVECTOR2(0,0);
	_eFireBombState = EFireBombState::Primary;
	_anpha = 0;
	_posX0 = posX;
	_posY0 = posY;
}

FireBomb::FireBomb(void)
{
}

FireBomb::FireBomb(float x_, float y_, float huong_): Weapon(x_, y_, huong_, EnumID::FireBomb_ID)
{
	_initialize();
	prepareFighting(x_, y_, huong_);
}

void FireBomb::Update(int deltaTime_)
{
	switch (_eFireBombState)
	{
	case Primary:
		break;
	case Secondary:
		_localTime += deltaTime_;
		this->sprite->Update(deltaTime_);
		if(_localTime >= 500)
			active =  false;
		break;
	default:
		break;
	}
	if(_localTime == 0)
	{
		vX = FIREBOMB_SPEED_X*cos(_anpha);
		vY = FIREBOMB_SPEED_X*sin(_anpha) - G*deltaTime_;
		posX += vX*deltaTime_;
		float deltaPosX = posX-_posX0;
		posY = _posY0 + vY*deltaPosX/vX-0.5*G*pow((deltaPosX/vX),2);
	}
}

void FireBomb::Collision(list<GameObject*> &obj, int dt)
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
				}
				else
				{
					posY += moveY;
					_localTime += dt;
				}
				sprite->_start = 1;
				_eFireBombState = EFireBombState::Secondary;
				SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_HolyWater);
				return;
			}
		}
	}
}

void FireBomb::prepareFighting(float simonX_, float simonY_, float direct_)
{
	if(direct_>0)
	{
		_anpha = FIREBOMB_ANPHA;
		_posX0 = posX = simonX_+20;
	    _gold->x = posX+100;
	}
	else
	{
		_anpha = 180-FIREBOMB_ANPHA;
		_posX0 = posX = simonX_-20;
	    _gold->x = posX-100;
	}	
	_anpha = _anpha*(3.14/180);
	 _posY0 = posY = simonY_+20;
}



FireBomb::~FireBomb(void)
{
}
