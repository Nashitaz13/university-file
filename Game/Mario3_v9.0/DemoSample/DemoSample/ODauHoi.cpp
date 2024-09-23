#include "ODauHoi.h"
#include "World.h"
#include "mario.h"


#define ODAUHOI_VELLOCITY_Y 0.2

ODauHoi::~ODauHoi()
{
}
ODauHoi::ODauHoi(float _x, float _y, int _Item, int _Loai) : MovableObject()
{
	this->x = _x;
	this->y = _y;
	this->originalY = y;
	this->type = Type::ot_odauhoi;
	this->item = (ODauHoiItem)_Item;
	Loai = _Loai;
	if (_Loai == 1)
		listRect.push_back(new MyRectangle(212, 134, 16, 16, 4, 4, 200));
	if (_Loai == 2)
		listRect.push_back(new MyRectangle(292, 134, 16, 16, 4, 4, 200));
	if (_Loai == 3)
		listRect.push_back(new MyRectangle(196, 150, 16, 16, 4, 4, 150));
	if (_Loai == 4)
		listRect.push_back(new MyRectangle(400, 74, 16, 16, 1, 1, 200));
	listRect.push_back(new MyRectangle(276, 134, 16, 16, 1, 1, 200));
	OMauXanh = new MyRectangle(400, 74, 16, 16, 1, 1, 200);
	currRect = listRect[0];
	currBox->SetBox(x, y, currRect->Width, currRect->Height);
	*preRect = *currRect;
	*preBox = *currBox;
}
void ODauHoi::Render()
{
	marioSprite->Render(x, originalY, OMauXanh->Rect);
	marioSprite->Render(x, y, currRect->Rect);
}
void ODauHoi::UpdatePosition()
{
	SetPreRect();
	switch (state)
	{
	case ODS_normal:
		SetCurrRect(0);
		break;
	case ODS_nhay:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_dunggach);
		if (Loai == 3)
			SetCurrRect(0);
		else
			SetCurrRect(1);
		vy += GRAVITY;
		SetY(y + vy * DeltaTime);
		if (y <= originalY)
		{
			if (Loai == 3)
				state = ODS_normal;
			else
				state = ODS_saukhinhay;
			SetY(originalY);
		}
		break;
	case ODS_xuong:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_dunggach);
		vy -= GRAVITY;
		SetY(y + vy * DeltaTime);
		if (y >= originalY)
		{
			state = ODS_normal;
			SetY(originalY);
		}
		break;
	case ODS_saukhinhay:
		SetCurrRect(1);
		break;
	}
	currRect->Update();
}

void ODauHoi::SetCurrRect(int index)
{
	currRect = listRect[index];
	currBox->SetBox(currRect->Width, currRect->Height);
}
void ODauHoi::SetY(float _y)
{
	this->y = _y;
	this->currBox->y = y;
}
void ODauHoi::SetPreRect()
{
	*preRect = *currRect;
	*preBox = *currBox;
}
void ODauHoi::VaCham(CollisionDirection cd)
{
	if (notnhacItem)
		return;
	MovableObject* temp = new MovableObject();
	switch (item)
	{
	case ODHT_DongTien:
		temp = new DongTien(x, y, false);
		((DongTien*)temp)->SetNhay();
		break;
	case ODHT_NamDo_La:
		if (mario1->marioType == MarioType::nho)
		{
			if (cd == cd_tren)
				temp = new NamItem(x, y, 1, 2);
			else
				temp = new NamItem(x, y, 1, 1);
			if (mario1->x < (x + currRect->Width / 2))
				temp->vx = NAMITEM_VELLOCITY_X;
			else
				temp->vx = -NAMITEM_VELLOCITY_X;
		}
		else
		{
			if (cd == cd_tren)
				temp = new ChiecLa(x, y, false);
			else
				temp = new ChiecLa(x, y, true);
		}
		break;
	case ODHT_NamXanh:
		if (cd == cd_tren)
			temp = new NamItem(x, y, 2, 2);
		else
			temp = new NamItem(x, y, 2, 1);
		if (mario1->x < (x + currRect->Width / 2))
			temp->vx = NAMITEM_VELLOCITY_X;
		else
			temp->vx = -NAMITEM_VELLOCITY_X;
		break;
	case ODHT_ChuP:
		// new Chu P
		temp = new ChuP(x, y + 16);
		break;
	case ODHT_Sao:
		if (cd == cd_tren)
			temp = new NamItem(x, y, 3, 2);
		else
			temp = new NamItem(x, y, 3, 1);
		if (mario1->x < (x + currRect->Width / 2))
			temp->vx = NAMITEM_VELLOCITY_X;
		else
			temp->vx = -NAMITEM_VELLOCITY_X;
		break;
	}

	quadtree->ThemObjectVaoQuadtree(temp, false);
}
void ODauHoi::OnCollisionWithMario(CollisionDirection cd)
{
	if (cd == CollisionDirection::cd_duoi ||
	((cd == CollisionDirection::cd_trai || cd == CollisionDirection::cd_phai) &&
	(mario1->marioAction == MarioAction::quayduoi || mario1->marioAction == MarioAction::nhayquayduoi)))
	{
		if (state == ODauHoiState::ODS_normal)
		{
			vy = ODAUHOI_VELLOCITY_Y;
			state = ODauHoiState::ODS_nhay;
			VaCham(cd);
			if (Loai == 3)
				notnhacItem = true;
		}
	}
	if (cd == CollisionDirection::cd_tren)
	{
		if (Loai == 3)
		{
			if (state == ODauHoiState::ODS_normal)
			{
				vy = -ODAUHOI_VELLOCITY_Y;
				state = ODauHoiState::ODS_xuong;
				VaCham(cd);
				notnhacItem = true;
			}
		}
	}
}
void ODauHoi::OnCollisionWithTurtle(Turtle* turtle, CollisionDirection cd)
{
	if (turtle->currAction != TurtleAction::rua_lan)
		return;
	if (cd != CollisionDirection::cd_trai && cd != CollisionDirection::cd_phai)
		return;
	if (state == ODauHoiState::ODS_normal)
	{
		vy = ODAUHOI_VELLOCITY_Y;
		state = ODauHoiState::ODS_nhay;
		VaCham(cd);
		if (Loai == 3)
			notnhacItem = true;
	}
}