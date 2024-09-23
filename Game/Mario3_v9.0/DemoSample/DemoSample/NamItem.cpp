#include "NamItem.h"
#include "ODauHoi.h"
#include "Gach.h"
#include "GameInformation.h"

NamItem::~NamItem()
{
}
NamItem::NamItem(float _x, float _y, int _Loai, int _Up)
{
	SetXY(_x, _y);
	originalY = _y;
	this->type = Type::ot_namitem;
	Loai = _Loai;
	Up = _Up;
	if (_Loai == 1)
		currRect = new MyRectangle(32, 134, 16, 16, 1, 1, 200);
	if (_Loai == 2)
		currRect = new MyRectangle(48, 134, 16, 16, 1, 1, 200);
	if (_Loai == 3)
		currRect = new MyRectangle(196, 166, 16, 16, 3, 3, 60);
	currBox->SetBox(currRect->Width - 2, currRect->Height - 2);
}
void NamItem::SetX(float _x)
{
	this->x = _x;
	this->currBox->x = x + 1;
}
void NamItem::SetY(float _y)
{
	this->y = _y;
	this->currBox->y = _y - 1;
}
void NamItem::SetXY(float _x, float _y)
{
	SetX(_x);
	SetY(_y);
}
void NamItem::Render()
{
	if (!Hide)
	{
		marioSprite->Render(x, y, currRect->Rect);
	}
}
void NamItem::UpdatePosition()
{
	*preBox = *currBox;

	if (Up == 1)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_namitem);
		SetY(y + 1);
		if (y > originalY + currRect->Height)
		{
			Up = 0;
			_Tick_Star = GetTickCount();
		}
	}
	if (Up == 2)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_namitem);
		SetY(y - 1);
		if (y < originalY + currRect->Height)
		{
			Up = 0;
			_Tick_Star = GetTickCount();
		}
	}

	if (Up == 0)
	{
		if (Loai == 3)
		{
			if (GetTickCount() - _Tick_Star >= 500)
				vy = GRAVITY;
			else
				vy = NAMITEM_VELLOCITY_X;
		}
		else
			vy += GRAVITY;
		SetXY(x + vx * DeltaTime, y + vy * DeltaTime);
	}

}
void NamItem::VaChamNen(BasicObject* obj, CollisionDirection cd)
{
	switch (cd)
	{
	case cd_tren:
		_Tick_Star = GetTickCount();
		SetY(obj->y + currRect->Height);
		vy = 0;
		break;
	case cd_phai:
		SetX(obj->x + obj->currBox->width);
		vx = NAMITEM_VELLOCITY_X;
		break;
	case cd_trai:
		SetX(obj->x - currRect->Width);
		vx = -NAMITEM_VELLOCITY_X;
		break;
	}
}
void NamItem::OnCollisionWithGround(BasicObject* ground, CollisionDirection cd)
{
	VaChamNen(ground, cd);
}
void NamItem::OnCollisionWithODauHoi(ODauHoi* odauhoi, CollisionDirection cd)
{
	VaChamNen(odauhoi, cd);
}
void NamItem::OnCollisionWithGach(Gach* gach, CollisionDirection cd)
{
	VaChamNen(gach, cd);
}
//8.4.3
void NamItem::OnCollisionWithMario()
{
	Hide = true;
	this->IsRelease = true;
}