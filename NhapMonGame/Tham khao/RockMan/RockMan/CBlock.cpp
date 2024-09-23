#include "CBlock.h"

CBlock::CBlock() :CStaticObject()
{
	
}

CBlock::~CBlock()
{

}

int CBlock::Initlize()
{
	UpdateBox();
	return 0;
}

void CBlock::Render(CGameTime* gameTime, CGraphics* graphics)
{
	CGameObject::Render(gameTime, graphics);
}

void CBlock::Update(CGameTime* gameTime)
{

}

void CBlock::UpdateBox()
{
	_box._x = _position.x - _size.x / 2;
	_box._y = _position.y + _size.y/ 2;
	_box._vx = 0;
	_box._vy = 0;
	_box._width = _size.x;
	_box._height =_size.y;
}