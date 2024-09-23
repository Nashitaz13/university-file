#include "Medusa.h"


Medusa::Medusa(void): DynamicObject()
{
}

Medusa::Medusa(float _x, float _y): DynamicObject(_x, _y, 0.08f, 0, EnumID::Medusa_ID)
{
	type = ObjectType::Enemy_Type;
	point = 300;
}

Medusa::~Medusa(void)
{
}

void Medusa::MoveSinPath(int deltaTime)
{
	float nextX = vX * deltaTime + posX;
	float nextY = 10 * sin(nextX/10);
	vY = nextY;
	posX += vX * deltaTime;
	posY += vY;
}

void Medusa::Draw(CCamera* camera)
{
	if(sprite == NULL || !active)
		return;
	if(posX + width / 2 <= camera->viewport.x || posX - width / 2 >= camera->viewport.x +G_ScreenWidth)
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

void Medusa::Collision(list<GameObject*> obj, int dt) {}

void Medusa::Update(int deltaTime)
{
	//posY += vY*deltaTime;
	MoveSinPath(deltaTime);
	sprite->Update(deltaTime);
}