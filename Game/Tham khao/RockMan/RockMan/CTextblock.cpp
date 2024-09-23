#include "CTextblock.h"

CTextblock::CTextblock() :CControl(){
	_text = "";
	_color = D3DCOLOR_XRGB(255, 255, 255);
	_scale = Vector2(1, 1);

	_horizontalAlignment = Alignment::LEFT;
	_verticalAlignment = Alignment::TOP;

	_isAnimation = false;
	_animationMode = AnimationMode::ONCE;
	_animationTime = 0.0f;

}

CTextblock::~CTextblock(){

}

int CTextblock::Initlize()
{
	// Tìm chiều rộng tối đa và chiều cao đối đa của đoạn text
	float maxHeight, characCount, maxCharacter;
	maxHeight = 0;
	maxCharacter = 0;
	characCount = 0;

	if (_text.compare(""))
		maxHeight = 1;

	for (int i = 0; i < _text.length(); i++)
	{
		if (_text[i] == '\n')
		{
			maxHeight += 1;
			if (maxCharacter <= characCount)
				maxCharacter = characCount;
			characCount = 0;
		}
		else
		{
			characCount += 1;
		}
	}
	if (maxCharacter <= characCount)
		maxCharacter = characCount;

	// Nếu như _size được set giá trị thì kiểm tra để lấy giá trị nhỏ nhất hiển thị, lấy giá trị đó để cài đặt hiển thị
	float minWidth, minHeight;
	if (_size.x != 0 && _size.y != 0){
		minWidth = __min(FONT_SIZE*maxCharacter, _size.x);
		minHeight = __min(FONT_SIZE*maxHeight, _size.y);
	}
	else
	{
		_size.x = FONT_SIZE*maxCharacter;
		_size.y = FONT_SIZE*maxHeight;
	}
	switch (_horizontalAlignment)
	{
	case Alignment::LEFT:
		_boundingRectText.left = _position.x;
		break;
	case Alignment::RIGHT:
		_boundingRectText.left = _position.x + _size.x - minWidth;
		break;
	case Alignment::CENTER:
		_boundingRectText.left = _position.x + _size.x / 2 - minWidth / 2;
		break;
	}

	switch (_verticalAlignment)
	{
	case Alignment::TOP:
		_boundingRectText.top = _position.y;
		break;
	case Alignment::BOTTOM:
		_boundingRectText.top = _position.y - _size.y + minHeight;
		break;
	case Alignment::CENTER:
		_boundingRectText.top = _position.y - _size.y / 2 + minHeight / 2;
		break;
	}

	_boundingRectText.right = _boundingRectText.left + SCREEN_WIDTH;
	_boundingRectText.bottom = _boundingRectText.top + SCREEN_HEIGHT;

	return 1;
}

void CTextblock::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_isAnimation)
	{
		_tick += gameTime->GetDeltaTime();
		_tickAnimation += gameTime->GetDeltaTime();

		if (_tick >= _animationTime&&_animationMode == AnimationMode::ONCE)
			_isAnimation = false;

		if (_tickAnimation >= 300)
		{
			_tickAnimation = 0;
			graphics->DrawString(_text, _boundingRectText, _color, _scale, false);
		}
	}
	else{

		if (_text.compare(""))
			graphics->DrawString(_text, _boundingRectText, _color, _scale, false);
	}
}

void CTextblock::SetAnimation(float animationTime, AnimationMode animationMode)
{
	_isAnimation = true;
	_animationTime = animationTime;
	_animationMode = animationMode;
}

void CTextblock::StopAnimation()
{
	_isAnimation = false;
}