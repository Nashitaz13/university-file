#include "ExplodingEffect.h"
#include <iostream>
#include <string.h>
#include <string>
using namespace std;

CExplodingEffect::CExplodingEffect(Vector2 position, CSprite sprite, int idSoundExplodingEffect) : CGameObject()
{
	_sprite = sprite;
	_position = position;
	_state = EXPLODING_EFFECT_STATE::EXPLODING;
	_isPlaySoundEffect = false;
	_idSoundEffect = idSoundExplodingEffect;
}

CExplodingEffect::~CExplodingEffect()
{
}

int CExplodingEffect::Initlize()
{
	_size = Vector2(0, 0);
	_origin = Vector2(_size.x / 2, _size.y / 2);
	this->UpdateBox();

	return 1;
}

void CExplodingEffect::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
}

void CExplodingEffect::Update(CGameTime* gameTime)
{
	_sprite.Update(gameTime);
	if (!_isPlaySoundEffect)
	{
		//Play sound effect here
		ResourceManager::PlayASound(_idSoundEffect);
		_isPlaySoundEffect = true;
	}


	if (_sprite.GetIndex() == _sprite.GetCountFrame() - 1)
		_state = EXPLODING_EFFECT_STATE::DONE;
	this->UpdateBox();
}

bool CExplodingEffect::IsDone()
{
	if (_state == EXPLODING_EFFECT_STATE::DONE)
	{
		_state = EXPLODING_EFFECT_STATE::EXPLODING;
		return true;
	}
	else 
		return false;
}

void CExplodingEffect::UpdateBox()
{
	_box._x = _position.x - _sprite.GetFrameWidth() / 2.0f;
	_box._y = _position.y + _sprite.GetFrameHeight() / 2.0f;
	_box._vx = 0;
	_box._vy = 0;
	_box._width = _sprite.GetFrameWidth();
	_box._height = _sprite.GetFrameHeight();
}

CExplodingEffect* CExplodingEffect::GetThis()
{
	return this;
}

void CExplodingEffect::SetSoundEffect(int idSoundExplodingEffect)
{
	_idSoundEffect = idSoundExplodingEffect;
}