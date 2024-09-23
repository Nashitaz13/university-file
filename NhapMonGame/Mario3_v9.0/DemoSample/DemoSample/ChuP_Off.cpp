#include "ChuP_Off.h"



ChuP_Off::~ChuP_Off()
{
}
ChuP_Off::ChuP_Off(float _x, float _y)
{
	this->x = _x;
	this->y = _y;
	this->type = Type::ot_chuP_off;
	currRect = new MyRectangle(196, 134, 16, 7, 1, 1, 200);
	currBox->SetBox(x, y, currRect->Width, currRect->Height);
}
void ChuP_Off::Render()
{
	marioSprite->Render(x, y, currRect->Rect);
}
