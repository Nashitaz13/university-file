#include "CStair.h"

CStair::CStair() :CStaticObject()
{

}

CStair::~CStair()
{

}

int CStair::Initlize()
{
	UpdateBox();
	return 0;
}

void CStair::Render(CGameTime* gameTime, CGraphics* graphics)
{
	CStaticObject::Render(gameTime, graphics);
}

void CStair::Update(CGameTime* gameTime)
{

}

void CStair::UpdateBox()
{
	_box._x = _position.x - _size.x / 2;
	_box._y = _position.y + _size.y / 2;
	_box._vx = 0;
	_box._vy = 0;
	_box._width = _size.x;
	_box._height = _size.y;
}