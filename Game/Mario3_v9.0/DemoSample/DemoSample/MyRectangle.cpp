#include "MyRectangle.h"



MyRectangle::MyRectangle(float x, float y, float width, float height, int total, int spritePerRow, int frameTime)
{
	this->X = x;
	this->Y = y;
	this->Width = width;
	this->Height = height;
	this->Total = total;
	this->SpritePerRow = spritePerRow;
	this->Index = 0;
	this->FrameTime = frameTime;
	this->Tick = 0;
	UpdateRect();
}


MyRectangle::MyRectangle()
{
	this->X = 0;
	this->Y = 0;
	this->Width = 0;
	this->Height = 0;
	this->Total = 0;
	this->SpritePerRow = 0;
	this->Index = 0;
	Rect.bottom = Rect.left = Rect.right = Rect.top = 0;
	this->Tick = 0;
	this->FrameTime = DefaultFrameTime;
}


MyRectangle::~MyRectangle()
{

}

void MyRectangle::Next()
{
	Index = (Index + 1) % Total;
	UpdateRect();
}

void MyRectangle::UpdateRect()
{
	Rect.left = X + (Index % SpritePerRow)*(Width);
	Rect.top = Y + (Index / SpritePerRow)*(Height);
	Rect.right = Rect.left + Width;
	Rect.bottom = Rect.top + Height;
}

void MyRectangle::Update()
{
	if (FrameTime != 0)
	{
		Tick += DeltaTime;
		if (Tick >= FrameTime)
		{
			Next();
			Tick = 0;
			NextFrame = true;
		}
		else
			NextFrame = false;
	}
}

void MyRectangle::SetIndex(int index)
{
	Index = index;
	UpdateRect();
	Tick = 0;
	NextFrame = false;
}