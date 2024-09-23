#include "MovableObject.h"

MovableObject::~MovableObject()
{
}
MovableObject::MovableObject() : BasicObject()
{
	this->vx = this->vy = 0;
	this->currRect = new MyRectangle();
	this->preRect = new MyRectangle(*currRect);
	this->effect = SpriteEffects::SE_left;
}
MovableObject::MovableObject(float x, float y, float width, float height)
	: BasicObject(x, y, width, height)
{
	this->vx = this->vy = 0;
	this->currRect = new MyRectangle();
	this->preRect = new MyRectangle(*currRect);
	this->effect = SpriteEffects::SE_left;
}
void MovableObject::SetX(float x)
{
	this->x = x;
	this->currBox->x = this->x;
}
void MovableObject::SetY(float y)
{
	this->y = y;
	this->currBox->y = this->y;
}
void MovableObject::SetXY(float x, float y)
{
	SetX(x);
	SetY(y);
}