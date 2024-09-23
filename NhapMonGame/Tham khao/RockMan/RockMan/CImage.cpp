#include "CImage.h"

CImage::CImage() :CControl()
{
	_texture = NULL;
	_transparentColor = D3DCOLOR_XRGB(0, 0, 0);
}

CImage::~CImage()
{
	SAFE_DELETE(_texture);
}

int CImage::Initlize()
{
	_texture = new CTexture(_source, _transparentColor);

	_origin = Vector2(_size.x / 2, _size.y / 2);

	if (_size.x != 0 && _size.y != 0)
	{
		_boundingRect.left = _position.x;
		_boundingRect.top = _position.y;
		_boundingRect.right = _boundingRect.left + _size.x;
		_boundingRect.bottom = _boundingRect.top + _size.y;
	}
	else
	{
		_boundingRect.left = _position.x;
		_boundingRect.top = _position.y;
		_boundingRect.right = _boundingRect.left + _texture->GetWidth();
		_boundingRect.bottom = _boundingRect.top + _texture->GetHeight();
	}
	return 1;
}

void CImage::Update(CGameTime* gameTime)
{
	if (_size.x != 0 && _size.y != 0)
	{
		_boundingRect.left = _position.x;
		_boundingRect.top = _position.y;
		_boundingRect.right = _boundingRect.left + _size.x;
		_boundingRect.bottom = _boundingRect.top + _size.y;
	}
	else
	{
		_boundingRect.left = _position.x;
		_boundingRect.top = _position.y;
		_boundingRect.right = _boundingRect.left + _texture->GetWidth();
		_boundingRect.bottom = _boundingRect.top + _texture->GetHeight();
	}
}

void CImage::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_texture->GetTexture(), _boundingRect, false);
}