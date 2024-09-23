#include "FireBullet.h"
#include "mario.h"

#define DEF_SP_FIREBULLET 0.05
#define DEF_CS_FIREBULLET 0.1

FireBullet::FireBullet(float X, float Y, float tanAlpha)
{
	SetXY(X, Y);
	currRect = new MyRectangle(0, 134, 8, 8, 4, 4,75);
	_tanAlpha = tanAlpha;

	if (mario1->x < X)			//Fire in Left side
		vx = -DEF_SP_FIREBULLET;
	else							//Fire in Right side
		vx = DEF_SP_FIREBULLET;

	type = Type::ot_firebullet;
}
void FireBullet::Render()
{
	marioSprite->Render(x, y, currRect->Rect);
}

void FireBullet::UpdatePosition()
{
	SetX(x + vx * DeltaTime);
	SetY(y + vx * DeltaTime*_tanAlpha);
}
void FireBullet::UpdateCollision()
{
	currRect->Update();
}
void FireBullet::SetX(float _x)
{
	this->x = _x;
	this->currBox->x = x + 1;
}
void FireBullet::SetY(float _y)
{
	this->y = _y;
	this->currBox->y = y - 1;
}
void FireBullet::SetXY(float _x, float _y)
{
	SetX(_x);
	SetY(_y);
}

FireBullet::~FireBullet()
{
}

