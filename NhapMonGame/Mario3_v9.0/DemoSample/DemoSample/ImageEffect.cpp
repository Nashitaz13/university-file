#include "ImageEffect.h"
#include "mario.h"

ImageEffect::~ImageEffect()
{
}
ImageEffect::ImageEffect(float _x, float _y, int _Type) : MovableObject()
{
	SetXY(_x, _y);
	this->Type = _Type;
	this->type = Type::ot_imageeffect;
	if (_Type == 1)
		currRect = new MyRectangle(366, 150, 16, 16, 7, 7, 1);
	if (_Type == 2)
		currRect = new MyRectangle(270, 150, 16, 16, 6, 6, 20);
	currBox->SetBox(x, y, currRect->Width, currRect->Height);
}
void ImageEffect::SetX(float _x)
{
	this->x = _x;
}
void ImageEffect::SetY(float _y)
{
	this->y = _y;
}
void ImageEffect::SetXY(float _x, float _y)
{
	SetX(_x);
	SetY(_y);
}
void ImageEffect::Render()
{
	currRect->Update();
	marioSprite->Render(x, y, currRect->Rect);
	if (currRect->Index == currRect->Total - 1)
	{
		this->IsRelease = true;
		if (Type == 2)
			mario1->indexLonDuoi = true;
	}
}


