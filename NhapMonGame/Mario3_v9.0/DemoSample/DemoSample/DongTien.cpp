#include "DongTien.h"
#include "GameInformation.h"

#define DONGTIEN_VELLOCITY_Y 0.5

DongTien::~DongTien()
{

}
DongTien::DongTien(float _x, float _y, bool _IsStatic) : MovableObject()
{
	this->x = _x;
	this->y = _y;
	this->originalY = y;
	this->type = Type::ot_dongtien;
	if (_IsStatic)
	{
		currRect = new MyRectangle(122, 134, 14, 16, 1, 1, 200);
	}
	else
	{
		currRect = new MyRectangle(80, 134, 14, 16, 6, 6, 100);
	}
	this->currBox->SetBox(this->x + 1, y - 1, currRect->Width - 2, currRect->Height - 2);
	*preBox = *currBox;
}

void DongTien::Render()
{
	marioSprite->Render(x, y, currRect->Rect);
}

void DongTien::UpdatePosition()
{
	if (isNhay)
	{
		vy += GRAVITY;
		y += vy * DeltaTime;
		if (y <= originalY)
		{
			this->IsRelease = true;
		}
	}
	currRect->Update();
}

void DongTien::OnCollisionWithMario()
{
	if (!isNhay)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_dongtien);
		cGameInformation->SetMoney(1, x, y); // Phuong --- Set tien
		cGameInformation->SetScore(50, x, y); // Phuong --- Set diem
		this->IsRelease = true;
	}
}

void DongTien::SetNhay()
{
	SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_dongtien);
	isNhay = true;
	vy = DONGTIEN_VELLOCITY_Y;
	cGameInformation->SetMoney(1, x, y); // Phuong --- Set tien
	cGameInformation->SetScore(100, x, y); // Phuong --- Set diem
}