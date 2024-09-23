#include "ChiecLa.h"
#include "GameInformation.h"

ChiecLa::~ChiecLa()
{
}
ChiecLa::ChiecLa(float _x, float _y, bool _Up) 
{
	SetXY(_x, _y);
	if (_Up)
		vy = VELLOCITY_Y_UP_EXIT;// cung c?p v?n t?c 
	else
		vy = -VELLOCITY_Y_UP_EXIT;
	originalX = _x;
	this->type = Type::ot_chiecla;
	currRect = new MyRectangle(64, 134, 16, 14, 1, 1, 200);
	currBox->SetBox(currRect->Width - 2, currRect->Height - 2);
	state = ChiecLaState::CLS_Up;
}
void ChiecLa::UpdatePosition()
{
	*preBox = *currBox;
	switch (state)
	{
	case ChiecLaState::CLS_Up:
		vy += GRAVITY; //tr?ng l?c kéo xuông
		if (vy <= 0)
		{
			state = ChiecLaState::CLS_DoiHuongPhai;
			originalX = x;
		}
		break;
	case ChiecLaState::CLS_DoiHuongPhai:
		vx = VELLOCTITY_X;
		effect = SpriteEffects::SE_right;

		if (x < originalX + DISTANCE_X_FOR_LITTLE_UP)
			vy = VELLOCITY_Y_DOWN;
		else
			vy = VELLOCITY_Y_UP;

		if (x >= (originalX + DISTANCE_X))
		{
			state = ChiecLaState::CLS_DoiHuongTrai;
			originalX += DISTANCE_X;
		}
		break;
	case ChiecLaState::CLS_DoiHuongTrai:
		vx = -VELLOCTITY_X;
		effect = SpriteEffects::SE_left;

		if (x > (originalX - DISTANCE_X_FOR_LITTLE_UP))
			vy = VELLOCITY_Y_DOWN;
		else
			vy = VELLOCITY_Y_UP;

		if (x <= (originalX - DISTANCE_X))
		{
			state = ChiecLaState::CLS_DoiHuongPhai;
			originalX -= DISTANCE_X;
		}
		break;
	}
	SetXY(x + vx * DeltaTime, y + vy * DeltaTime);
}
void ChiecLa::Render()
{
	if (!Hide)
	{
		if (effect == SpriteEffects::SE_left)
			LmarioSprite->Render(x, y, currRect->Rect);
		else
			marioSprite->Render(x, y, currRect->Rect);
	}
}
void ChiecLa::SetX(float _x)
{
	this->x = _x;
	this->currBox->x = x + 1;
}
void ChiecLa::SetY(float _y)
{
	this->y = _y;
	this->currBox->y = y - 1;
}
void ChiecLa::SetXY(float _x, float _y)
{
	SetX(_x);
	SetY(_y);
}
void ChiecLa::OnCollisionWithMario()
{
	Hide = true;
	this->IsRelease = true;
}