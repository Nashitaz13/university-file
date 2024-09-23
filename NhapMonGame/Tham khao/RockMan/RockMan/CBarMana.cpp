#include "CBarMana.h"
CBarMana::CBarMana()
{
}

CBarMana::CBarMana( Vector2 position,string name)
{
	_isDraw = true;
	_textureMana = CTexture(L"Resources//Sprites//Others//bar_rockman.png", D3DCOLOR_XRGB(0, 102, 102));;
	_position = position;
	_maxMana = 27;
	_textureBG =  CTexture(L"Resources//Sprites//Others//bar_background.png", D3DCOLOR_XRGB(0, 102, 102));

	_text =  CTextblock();
	_text._position = _position;
	_text._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT / 28);
	_text._text = name;
	_text._color = D3DCOLOR_XRGB(255, 255, 255);
	_text.Initlize();
	_position.x += 15;//5


	_boundingBG.left = 0;
	_boundingBG.top = 0;
	_boundingBG.right = _boundingBG.left + _textureBG.GetWidth();
	_boundingBG.bottom = _boundingBG.top + _textureBG.GetHeight();
}
int CBarMana::Initlize()
{
	_mana = 0;
	return 1;
}

CBarMana::~CBarMana()
{
	
}
void CBarMana::Update(CGameTime* gameTime)
{

}
void CBarMana::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_textureBG.GetTexture(), _boundingBG, _position, false);

	_boundingMana.left = 0;
	_boundingMana.top = 0;
	_boundingMana.right = _boundingMana.left + (_textureMana.GetWidth()) / _maxMana * _mana;
	_boundingMana.bottom = _boundingMana.top + _textureMana.GetHeight();
	graphics->Draw(_textureMana.GetTexture(), _boundingMana, _position, false);
	if (_isDraw)
	_text.Render(gameTime, graphics);
}
void CBarMana::SetMana(int mana)
{
	_mana = mana;
}
void CBarMana::IsDraw(boolean isdraw)
{
	_isDraw = isdraw;
}