
#include "DragonSkullCannon.h"


DragonSkullCannon::DragonSkullCannon(void): DynamicObject()
{
}

DragonSkullCannon::DragonSkullCannon(float x, float y):DynamicObject(x, y, 0, 0, EnumID::DragonSkullCannon_ID)
{	
	fireBall = new list<FireBall*>();	
	type = ObjectType::Enemy_Type;
	point = 400;
	hp = 4;
}

void DragonSkullCannon::Update(int dt)
{
	list<FireBall*>::iterator i = fireBall->begin();
	while (i != fireBall->end())
	{
		if(!(*i)->active)
		{
			if((*i)->vX > 0)
			{
				fireBall->push_back(new FireBall(posX, posY - 16, 1, EnumID::FireBall_ID));
			}
			else fireBall->push_back(new FireBall(posX, posY + 16, -1, EnumID::FireBall_ID));
			fireBall->erase(i++);			
		}
		else
		{
			(*i)->Update(dt);
			++i;
		}
	}
}

void DragonSkullCannon::Draw(CCamera* camera)
{
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

void DragonSkullCannon::SetActive(float x, float y)
{
	if(abs(posX - x) <= 260)
	{
		fireBall->push_back(new FireBall(posX, posY + 16, -1, EnumID::FireBall_ID));
		fireBall->push_back(new FireBall(posX, posY - 16, 1, EnumID::FireBall_ID));
		active = true;
	}
}

DragonSkullCannon::~DragonSkullCannon(void)
{
}
