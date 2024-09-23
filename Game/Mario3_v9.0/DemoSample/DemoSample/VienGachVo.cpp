#include "VienGachVo.h"
#include "Input.h"
#include "mario.h"


VienGachVo::~VienGachVo()
{
}
VienGachVo::VienGachVo(float _x, float _y)
{
	xLeft = xRight = _x;
	x = _x;
	y = _y;
	this->type = Type::ot_viengachvo;
	_Vector1 = ReturnParabol(_x - DISTANCE_X1, _y + DISTANCE_Y1, _x, _y);
	_Vector2 = ReturnParabol(_x - DISTANCE_X2, _y + DISTANCE_Y2, _x, _y);
	currRect = new MyRectangle(356, 134, 8, 8, 1, 1, 200);
	currBox->SetBox(x, y, currRect->Width, currRect->Height);
}
void VienGachVo::Render()
{
	marioSprite->Render(xLeft, y1, currRect->Rect);
	marioSprite->Render(xLeft, y2, currRect->Rect);
	marioSprite->Render(xRight, y1, currRect->Rect);
	marioSprite->Render(xRight, y2, currRect->Rect);
}
void VienGachVo::UpdatePosition()
{
	xLeft -= VIENGACHVO_VELLOCITY_X * DeltaTime;
	xRight += VIENGACHVO_VELLOCITY_X * DeltaTime;
	y1= CalculateY(*_Vector1, xLeft);
	y2 = CalculateY(*_Vector2, xLeft);
	currRect->Update();
}
float VienGachVo::CalculateY(D3DXVECTOR3 vector, float _x)
{
	return vector.x * _x * _x + vector.y * _x + vector.z;
}