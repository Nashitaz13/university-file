#include "CRock.h"

CRock::CRock() :CStaticObject()
{
	
}

CRock::~CRock()
{

}

int CRock::Initlize()
{
	_texture = CTexture(L"Resources//Sprites//Others//rock.png", D3DCOLOR_XRGB(255, 0, 195));
	if (_typeID == ID_ROCK_IN_GUT_STAGE)
		_texture = CTexture(L"Resources//Sprites//Others//rock_in_gut_stage.png", D3DCOLOR_XRGB(0, 255, 0));
	UpdateBox();
	return 0;
}

void CRock::Render(CGameTime* gameTime, CGraphics* graphics)
{
	Rect rectBorder;
	rectBorder.left = _box._x;
	rectBorder.top = _box._y;
	rectBorder.right = _box._x + _texture.GetWidth();
	rectBorder.bottom = _box._y + _texture.GetHeight();

	graphics->Draw(_texture.GetTexture(), rectBorder, false, Vector2(_box._width / _texture.GetWidth(), _box._height / _texture.GetHeight()));

	CStaticObject::Render(gameTime, graphics);
}

void CRock::Update(CGameTime* gameTime)
{

}

void CRock::UpdateBox()
{
	_box._x = _position.x - _size.x / 2;
	_box._y = _position.y + _size.y / 2;
	_box._vx = 0;
	_box._vy = 0;
	_box._width = _size.x;
	_box._height = _size.y;
}
bool CRock::IsGot()
{
	return _isGot;
}

void CRock::GotIt()
{
	_isGot = true;
}

void CRock::Reset()
{
	_isGot = false;
}