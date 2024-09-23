#include "CControl.h"

CControl::CControl() :CObject()
{

}

CControl::~CControl()
{

}

int CControl::Initlize()
{
	_position = Vector2(0,0);
	_size = Vector2(0, 0);
	_origin = Vector2(_size.x / 2, _size.y / 2);

	return 1;
}

void CControl::Render(CGameTime* gameTime, CGraphics* graphics)
{

}

void CControl::Update(CGameTime* gameTime)
{

}
