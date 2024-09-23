#include "FishMan.h"

#define SPEED_X 0.3f
#define SPEED_Y 0.45f
#define MAX_HEIGHT 250.0f

FishMan::FishMan(void): DynamicObject()
{
}

FishMan::FishMan(float x, float y) : DynamicObject(x, y, 0, 0, EnumID::FishMan_ID)
{
	_hasJump = false;
	_heightJump = 0;
	fireBall = new list<FireBall*>();	
	type = ObjectType::Enemy_Type;
	point = 300;
}

void FishMan::Update(int dt)
{
	list<Water*>::iterator it = w->begin();
	while (it != w->end())
	{
		if(!(*it)->active)
			w->erase(it++);
		else
		{
			(*it)->Update(dt);
			++it;
		}
	}
	list<FireBall*>::iterator i = fireBall->begin();
	while (i != fireBall->end())
	{
		if(!(*i)->active)
		{
			fireBall->erase(i++);
			fireBall->push_back(new FireBall(posX, posY + 20, vX, EnumID::FireBall_ID));
		}
		else
		{
			(*i)->Update(dt);
			++i;
		}
	}
	if(!_hasJump)
		posX += vX*dt;
	posY += vY*dt;
	if(!_hasJump)
		sprite->Update(dt);
	if(_hasJump)
	{
		_heightJump += vY * dt;
		if( _heightJump >= MAX_HEIGHT)
		{			
			vY = -(SPEED_Y + 0.3f);
		}
	}
}
	
void FishMan::Collision(list<GameObject*> obj, int dt)
{
	list<GameObject*>::iterator _itBegin;
	for (_itBegin = obj.begin(); _itBegin != obj.end(); _itBegin++)
	{
		float moveX;
		float moveY;
		float normalx;
		float normaly;
		GameObject* other = (*_itBegin);
		if(other->id == EnumID::Brick_ID)
		{
			Box box = this->GetBox();
			Box boxOther = other->GetBox();

			if(AABB(box, boxOther, moveX, moveY) == true)
			{	
				if(moveX == 0)
				{
					if(vY < 0)
					{
						posY += moveY;
						if(_hasJump && _heightJump <= 0)
						{
							_hasJump = false;
							sprite->_start = 1;
							vY = 0;
							fireBall->push_back(new FireBall(posX, posY + 20, vX, EnumID::FireBall_ID));
						}
						return;
					}
					if((posX - width/2 + 10) - (other->posX - other->width/2) <= 0
						|| (posX + width/2 - 10) - (other->posX + other->width/2) >= 0)
						vX = -vX;
				}
			}

			if(AABB(box, boxOther, moveX, moveY) == false)
			{
				if(other->canMove == true)
				{
					box.vx -= boxOther.vx;
					box.vy -= boxOther.vy;
					boxOther.vx = 0;
					boxOther.vy = 0;
				}
				Box broadphasebox = GetSweptBroadphaseBox(box, dt);
				if (AABBCheck(GetSweptBroadphaseBox(box, dt), boxOther) == true)
				{
					float collisiontime = SweptAABB(box, boxOther, normalx, normaly, dt);
					if (collisiontime > 0.0f && collisiontime < 1.0f)
					{
						ECollisionDirect colDirect = GetCollisionDirect(normalx, normaly);
						// perform response here
						switch (colDirect)
						{
						case Colls_Bot:
							posY += vY * collisiontime;
							vY = 0;
							break;
						}
					}
				}
			}
		}
	}
}

void FishMan::Draw(CCamera* camera)
{
	for (list<Water*>::iterator i = w->begin(); i != w->end(); i++)
	{
		if((*i)->active)
			(*i)->Draw(camera);
	}
	for (list<FireBall*>::iterator i = fireBall->begin(); i != fireBall->end(); i++)
	{
		if((*i)->active)
			(*i)->Draw(camera);
	}
	D3DXVECTOR2 center = camera->Transform(posX, posY);
	if(vX > 0)
		sprite->DrawFlipX(center.x, center.y);
	else
		sprite->Draw(center.x, center.y);

}
	
void FishMan::SetActive(float x, float y)
{
	if(abs(posX - x) <= 50 && abs(posY - y) <= 200)
	{
		if(posX - x > 0)
			vX = -SPEED_X;
		else vX = SPEED_X;
		active = true;
		Jump();
	}
}
	
void FishMan::Jump()
{
	vY = SPEED_Y;
	_hasJump = true;
	_heightJump = 0.0f;
	w = new list<Water*>();
	w->push_back(new Water(posX, posY, -0.01));
	w->push_back(new Water(posX, posY, -0.2));
	w->push_back(new Water(posX, posY, 0.2));
	SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_SplashWater);
}

FishMan::~FishMan(void)
{
}
