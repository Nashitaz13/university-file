#include "PowerEnergyX.h"

CPowerEnergyX::CPowerEnergyX(int typeID, CMoveableObject* master,CTexture textureContent, Vector2 positionStickOnScreen, unsigned int minValue, unsigned int  maxValue, unsigned int value, unsigned int speed) :CGameObject()
{
	_textureBkg = ResourceManager::GetSprite(ID_SPRITE_BAR_BACKGROUND_VERTICAL);
	_textureContent = textureContent;
	_minValue = minValue;
	_maxValue = maxValue;
	_speed = speed;
	_positionStickOnScreen = positionStickOnScreen;
	_value = value;
	_typeID = typeID;
	_master = master;

	// ràng buộc giá trị truyền vào nằm trong đoạn [_minValue,_maxValue]
	_expectedValue = value;
	_expectedValue = __max(value, _minValue);
	_expectedValue = __min(value, _maxValue);
}

CPowerEnergyX::~CPowerEnergyX()
{

}

void CPowerEnergyX::Update(CGameTime* gameTime)
{
	_isCompleted = false;

	if (_expectedValue > _value)
	{
		_value += 1;
		if (_value != _expectedValue)
			ResourceManager::PlayASound(ID_SOUND_BEAM_IN);		// Chạy âm thanh tăng giá trị
	}
	else if (_expectedValue < _value)
		_value = _expectedValue;

	if (_value == _expectedValue)
		_isCompleted = true;
}

void CPowerEnergyX::UpdateCamera(CCamera * camera)
{
	_position = camera->GetPositionCamera() + _positionStickOnScreen;
}

void CPowerEnergyX::Render(CGameTime* gameTime, CGraphics* graphics)
{
	// Vẽ ảnh nền
	Rect destinationRect;
	destinationRect.left = 0;
	destinationRect.top = 0;
	destinationRect.right = _textureBkg.GetWidth();
	destinationRect.bottom =_textureBkg.GetHeight();

	graphics->Draw(_textureBkg.GetTexture(), destinationRect, _position, true, Vector2(1.0f, 1.0f), SpriteEffects::NONE);

	// Vẽ ảnh nội dung
	int h = (float)_textureContent.GetHeight()*(float)_value / (float)_maxValue;
	destinationRect.left =0;
	destinationRect.top = _textureContent.GetHeight()- h;
	destinationRect.right =  destinationRect.left + _textureContent.GetWidth();
	destinationRect.bottom = _textureContent.GetHeight();

	graphics->Draw(_textureContent.GetTexture(), destinationRect, _position - Vector2(0, (_textureContent.GetHeight()- h) / 2), true, Vector2(1.0f, 1.0f), SpriteEffects::NONE);

}

void CPowerEnergyX::SetValue(unsigned int value)
{
	_expectedValue = value;
	_expectedValue = __max(value, _minValue);
	_expectedValue = __min(value, _maxValue);
}

bool CPowerEnergyX::IsCompleted()
{
	return _isCompleted;
}

CMoveableObject* CPowerEnergyX::GetMaster()
{
	return _master;
}