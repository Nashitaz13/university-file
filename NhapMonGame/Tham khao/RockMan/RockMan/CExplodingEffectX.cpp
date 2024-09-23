#include "CExplodingEffectX.h"

CExplodingEffectX::CExplodingEffectX(Vector2 position, CSprite sprite, bool explodeBig) :CExplodingEffect(position, sprite)
{
	_isExplodeBig = explodeBig;
		_v = Vector2(65.0f / 1000.0f, 0.0f);
		_a = Vector2(0.0075f / 1000.0f, 0.0f);
	_distance1 = _distance2 = 0.0f;
	UpdateBox();
}

CExplodingEffectX::~CExplodingEffectX()
{

}

void CExplodingEffectX::Update(CGameTime* gameTime)
{
	_v += _a*gameTime->GetDeltaTime();
	_distance1 += _v.x*gameTime->GetDeltaTime();
	_distance2 += 2.0f*_v.x*gameTime->GetDeltaTime();

	if (_isExplodeBig)
	{
		if (_distance1 >= 300)
			_state = EXPLODING_EFFECT_STATE::DONE;
	}
	else
	if (_distance1 >= 20)
		_state = EXPLODING_EFFECT_STATE::DONE;
	_sprite.Update(gameTime);
	UpdateBox();
}

void CExplodingEffectX::Render(CGameTime* gameTime, CGraphics* graphics)
{
	for (int i = 1; i < 5; i++)
	{
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), Vector2(_distance1* cos(i*PI / 2.0f) + _position.x, _distance1*sin(i*PI / 2.0f) + _position.y), Vector2(1.0f, 1.0f));
	}
	for (int i = 1; i < 9; i++)
	{
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), Vector2(_distance2* cos(i*PI / 4.0f) + _position.x, _distance2*sin(i*PI / 4.0f) + _position.y), Vector2(1.0f, 1.0f));
	}
}