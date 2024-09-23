#include "Box.h"



CBox::CBox()
{
	x = y = width = height = 0;
}

CBox::CBox(float x, float y, float width, float height)
{
	SetBox(x, y, width, height);
}

void CBox::SetBox(float x, float y, float width, float height)
{
	this->x = x;
	this->y = y;
	this->width = width;
	this->height = height;
}

void CBox::SetBox(float width, float height)
{
	this->width = width;
	this->height = height;
}

CBox::~CBox()
{
}