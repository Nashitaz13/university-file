#include "CMenuItem.h"

CMenuItem::CMenuItem() :CControl()
{
	_background = NULL;
	_border = NULL;
	_name = "";
	_isFocused = false;
}

CMenuItem::~CMenuItem()
{
	SAFE_DELETE(_background);
	SAFE_DELETE(_border);
}

int CMenuItem::Initlize()
{
	_borderPosition = Vector2(_position.x + _size.x / 2, _position.y - _size.y / 2);

	_boundingRectBkg.left = 0;
	_boundingRectBkg.top = 0;
	_boundingRectBkg.right = _background->GetWidth();
	_boundingRectBkg.bottom = _background->GetHeight();

	_positionText.x = _position.x;
	_positionText.y = _position.y - _size.y;

	_replaceColor = _foreground;
	_timeAnimationText = _border->_timeFrameDefault;

	return 1;
}

void CMenuItem::Render(CGameTime* gameTime, CGraphics* graphics)
{
	// Vẽ background
	graphics->Draw(_background->GetTexture(), _boundingRectBkg, _borderPosition, true);
	// Vẽ border 
	graphics->Draw(_border->GetTexture(), _border->GetDestinationRectangle(), _borderPosition, true);
	// Vẽ đoạn text
	graphics->DrawString(_name, _positionText, _replaceColor, false);
}

void CMenuItem::Update(CGameTime* gameTime)
{
	if (_isFocused)
	{
		_border->SetAllowAnimate(_border->_timeFrameDefault);
		_border->Update(gameTime);
		_timeAnimationText -= gameTime->GetDeltaTime();

		if (_timeAnimationText <= 0)
		{
			if (_replaceColor == _foreground)
				_replaceColor = D3DCOLOR_XRGB(252, 252, 252);
			else
				_replaceColor = _foreground;
			_timeAnimationText = _border->_timeFrameDefault;
		}
	}
	else
	{
		_border->Reset();
		_replaceColor = _foreground;
		_timeAnimationText = _border->_timeFrameDefault;
	}
}

Color CMenuItem::GetAnimationColor()
{
	return _replaceColor;
}
