#include "VampireBat.h"


VampireBat::VampireBat(void): DynamicObject()
{
}

VampireBat::VampireBat(float x, float y): DynamicObject(x, y, 0.2f, 0, EnumID::VampireBat_ID)
{	
	type = ObjectType::Enemy_Type;
	point = 200;
	active = true;
	getUp = false;
}

VampireBat::~VampireBat(void)
{
}

void VampireBat::MoveSinPath(int deltaTime)
{
	float nextX = vX * deltaTime + posX;
	float nextY = 4 * sin(nextX/10);
	vY = nextY;
	posX += vX * deltaTime;
	posY += vY;
}

void VampireBat::Draw(CCamera* camera)
{
	if(sprite == NULL || !active)
		return;
	if(posX + width / 2 <= camera->viewport.x || posX - width / 2 >= camera->viewport.x + G_ScreenWidth)
	{
		active = false;
		return;
	}
	D3DXVECTOR2 center = camera->Transform(posX, posY);
	if(vX > 0)
		sprite->DrawFlipX(center.x, center.y);
	else
		sprite->Draw(center.x, center.y);
}

void VampireBat::Update(int deltaTime)
{
	if(getUp)
	{
		MoveSinPath(deltaTime);
		sprite->Update(deltaTime);
	}
}

void VampireBat::Collision(list<GameObject*> obj, int dt) {}

void VampireBat::SetActive(float x, float y)
{
	if(abs(posX - x) <= 300 && abs(posY - y) <= 300)
	{
		if(posX - x > 0)
		{
			vX = -0.2f;
		}
		else vX = 0.2f;
		getUp = true;
		sprite->_start = 1;
	}
}