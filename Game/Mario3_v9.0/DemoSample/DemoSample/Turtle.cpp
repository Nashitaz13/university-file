#include "Turtle.h"
#include "mario.h"
#include "ODauHoi.h"
#include "Gach.h"
#include "NamEnemy.h"
#include "GameInformation.h"

Turtle::~Turtle()
{
}
Turtle::Turtle(float _x, float _y, bool _RuaXanh, bool _RuaBay, float _Bien)
{
	SetX(_x);
	SetY(_y);
	this->root_x = _x;
	this->root_y = _y;
	vx = -TURTLE_VELOCITY_X;
	type = Type::ot_turtle;
	RuaXanh = _RuaXanh;
	effect = SpriteEffects::SE_right;
	collidWithGround = false;
	biOm = false;
	Chet = false;
	originalX = x;
	originalY = y;
	bien = _Bien;
	if (_RuaXanh)
	{
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_di, new MyRectangle(116, 106, 16, 27, 2, 2, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_mai, new MyRectangle(148, 106, 16, 16, 1, 1, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_hoisinh, new MyRectangle(196, 106, 18, 16, 2, 2, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_lan, new MyRectangle(148, 106, 16, 16, 3, 3, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_bay, new MyRectangle(232, 106, 16, 28, 4, 4, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_biom, new MyRectangle(148, 106, 16, 16, 1, 1, 60)));
		if (_RuaBay)
		{
			currAction = TurtleAction::rua_bay;
			SetCurrRec(currAction);
		}
		else
		{
			currAction = TurtleAction::rua_di;
			SetCurrRec(currAction);
		}
	}
	else
	{
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_di, new MyRectangle(0, 106, 16, 27, 2, 2, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_mai, new MyRectangle(32, 106, 16, 16, 1, 1, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_hoisinh, new MyRectangle(80, 106, 18, 16, 2, 2, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_lan, new MyRectangle(32, 106, 16, 16, 3, 3, 60)));
		listMyRect.insert(pair<TurtleAction, MyRectangle*>(TurtleAction::rua_biom, new MyRectangle(32, 106, 16, 16, 1, 1, 60)));
		currAction = TurtleAction::rua_di;
		SetCurrRec(currAction);
	}
}
void Turtle::SetCurrRec(TurtleAction action)
{
	this->currAction = action;
	this->currRect = listMyRect.find(currAction)->second;
	this->currBox->SetBox(currRect->Width - 4, currRect->Height - 2);
}
void Turtle::SetPreRect()
{
	preAction = currAction;
	*preRect = *currRect;
	*preBox = *currBox;
}
void Turtle::SetX(float _x)
{
	this->x = _x;
	this->currBox->x = x + 2;
}
void Turtle::SetY(float _y)
{
	this->y = _y;
	this->currBox->y = y - 1;
}
void Turtle::SetXY(float _x, float _y)
{
	SetX(_x);
	SetY(_y);
}
void Turtle::Render()
{
	if (effect == SpriteEffects::SE_right)
		marioSprite->Render(x, y, currRect->Rect);
	if (effect == SpriteEffects::SE_left)
		LmarioSprite->Render(x, y, currRect->Rect);
}
void Turtle::UpdateRootPosition()
{
	if (currAction != TurtleAction::rua_lan)
	{
		if (ViewPort->_X > this->root_x && ViewPort->_X > this->x)
		{
			this->x = this->root_x;
			this->y = this->root_y;
		}
	}
}
void Turtle::UpdateCollision()
{
	if (preAction != currAction)
		preRect->SetIndex(0);	// neu mario bi thay doi sprite, sprite truoc se reset
	currRect->Update();
}
void Turtle::UpdatePosition()
{
	SetPreRect();	// Luu MyRectange va Box o frame truoc
	vy += GRAVITY;



	if (currAction != TurtleAction::rua_rung)
		SetCurrRec(currAction);

	switch (currAction)
	{
	case TurtleAction::rua_bay:
		if (collidWithGround)
			vy = TURTLE_VELOCITY_Y;
		if (GetTickCount() - _Tick_Fly >= 1000)
			vy = GRAVITY;

		if (vx > 0)
			effect = SpriteEffects::SE_right;
		else
			if (vx < 0)
				effect = SpriteEffects::SE_left;
		break;
	case TurtleAction::rua_di:
		if (y == originalY && bien > 0)
		{
			if (x <= (originalX - bien))
				vx = TURTLE_VELOCITY_X;
			else
				if (x + currRect->Width >= originalX + bien)
					vx = -TURTLE_VELOCITY_X;
		}
		if (vx > 0)
			effect = SpriteEffects::SE_right;
		else
			if (vx < 0)
				effect = SpriteEffects::SE_left;

		biOm = false; //8.4.3
		break;
	case rua_mai:
		if ((GetTickCount() - _Tick_Rung) > 3000)
		{
			currAction = TurtleAction::rua_rung;
			_Tick_HoiSinh = GetTickCount();
		}
		if (biOm && !mario1->OmRua)
			SetThaRua();
		if (mario1->OmRua)
			SetOmRua(); // 8.4.3
		break;
	case rua_rung:
		vx = 0;
		if ((GetTickCount() - _Tick_Rung) / (float)1000 > 0.017)
		{
			if (rungTrai)
			{
				x -= 1;
				rungTrai = false;
			}
			else
			{
				x += 1;
				rungTrai = true;
			}
			_Tick_Rung = GetTickCount();
		}

		if ((GetTickCount() - _Tick_HoiSinh) > 1000)
		{
			currAction = TurtleAction::rua_hoisinh;
			_Tick = GetTickCount();
		}
		if (biOm && !mario1->OmRua)
			SetThaRua();
		if (mario1->OmRua)
			SetOmRua();
		break;
	case rua_hoisinh:
		vx = 0;
		if ((GetTickCount() - _Tick_Rung) / (float)1000 > 0.017)
		{
			if (rungTrai)
			{
				x -= 1;
				rungTrai = false;
			}
			else
			{
				x += 1;
				rungTrai = true;
			}
			_Tick_Rung = GetTickCount();
		}
		if (GetTickCount() - _Tick > 2000)
		{
			currAction = TurtleAction::rua_di;
			if (mario1->x < x)
				vx = -TURTLE_VELOCITY_X;
			else
				vx = TURTLE_VELOCITY_X; //8.4.3
		}
		if (biOm && !mario1->OmRua)
			SetThaRua();
		if (mario1->OmRua)
			SetOmRua();
		break;
	case rua_lan:
		break;
	case rua_biom:
		SetOmRua();
		if (biOm && !mario1->OmRua)
			SetThaRua(); //8.4.3 (Xóa SetOmRua)
		if ((GetTickCount() - _Tick_Rung) > 3000)
		{
			currAction = TurtleAction::rua_rung;
			_Tick_HoiSinh = GetTickCount();
		}
		break;
	}

	if (mario1->marioAction == MarioAction::quayduoi || mario1->marioAction == MarioAction::nhayquayduoi)
		SetBiQuayDuoi(); //8.4.3 (Xóa trong hàm va chạm mario phai, trai)

	// Cap nhat lai vi tri, kich thuoc rua xanh truoc khi xu ly va cham
	SetXY(x + vx * DeltaTime, y - preRect->Height + currRect->Height + vy * DeltaTime);
}
//Set toa do rua khi bi om
void Turtle::SetOmRua()
{
	if (mario1->effect == SpriteEffects::SE_right)
		SetX(mario1->x + mario1->currRect->Width - 5);
	else
		SetX(mario1->x - currRect->Width + 5);
	vy = 0;

	if (mario1->marioType == MarioType::nho)
		SetY(mario1->y);
	else
	if (mario1->marioType == MarioType::lon || mario1->marioType == MarioType::duoi)
		SetY(mario1->y - 8);
}
//Set toa do rua khi tha
void Turtle::SetThaRua()
{
	currAction = TurtleAction::rua_lan;
	if (mario1->effect == SpriteEffects::SE_right)
		vx = ROLL_VELOCITY;
	else
		vx = -ROLL_VELOCITY;
	biOm = false;
}
//8.4.3
void Turtle::SetBiQuayDuoi()
{
	if (mario1->y - 18 > y - currRect->Height && mario1->y - 18 < y)
	{
		if (mario1->effect == SpriteEffects::SE_right)
		{
			if (mario1->x < x)
			{
				if (mario1->x + mario1->currRect->Width > x && mario1->x + mario1->currRect->Width < x + currRect->Width)
				{
					SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
					ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
					quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
					effect = SpriteEffects::SE_left;
					currAction = TurtleAction::rua_mai;
					_Tick_Rung = GetTickCount();
					vy = 10 * TURTLE_VELOCITY_Y;
					vx = 3 * TURTLE_VELOCITY_X;
				}
			}
			else
			{
				if (mario1->x > x && mario1->x < x + currRect->Width)
				{
					SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
					ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
					quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
					effect = SpriteEffects::SE_left;
					currAction = TurtleAction::rua_mai;
					_Tick_Rung = GetTickCount();
					vy = 10 * TURTLE_VELOCITY_Y;
					vx = -3 * TURTLE_VELOCITY_X;
				}
			}
		}
		else
		{
			if (mario1->x < x)
			{
				if (mario1->x - 9 + mario1->currRect->Width > x && mario1->x + mario1->currRect->Width < x + currRect->Width)
				{
					SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
					ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
					quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
					effect = SpriteEffects::SE_left;
					currAction = TurtleAction::rua_mai;
					_Tick_Rung = GetTickCount();
					vy = 10 * TURTLE_VELOCITY_Y;
					vx = 3 * TURTLE_VELOCITY_X;
				}
			}
			else
			{
				if (mario1->x - 9 > x && mario1->x < x + currRect->Width)
				{
					SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
					ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
					quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
					effect = SpriteEffects::SE_left;
					currAction = TurtleAction::rua_mai;
					_Tick_Rung = GetTickCount();
					vy = 10 * TURTLE_VELOCITY_Y;
					vx = -3 * TURTLE_VELOCITY_X;
				}
			}
		}

	}
} 
void Turtle::RuaChet(CollisionDirection cd) //8.4.3
{
	Chet = true;
	mario1->OmRua = false; 
	biOm = false;
	if (cd == CollisionDirection::cd_phai)
	{
		effect = SpriteEffects::SE_left;
		currAction = TurtleAction::rua_mai;
		_Tick_Rung = GetTickCount();
		vy = 10 * TURTLE_VELOCITY_Y;
		vx = -3 * TURTLE_VELOCITY_X;
	}
	if (cd == CollisionDirection::cd_trai)
	{
		effect = SpriteEffects::SE_left;
		currAction = TurtleAction::rua_mai;
		_Tick_Rung = GetTickCount();
		vy = 10 * TURTLE_VELOCITY_Y;
		vx = 3 * TURTLE_VELOCITY_X;
	}
}
void Turtle::VaChamNen(BasicObject* obj, CollisionDirection cd)
{
	if (biOm || Chet) // 8.4.3 (Xóa collis with ground, gach, o dau hoi)
		return;
	switch (cd)
	{
	case cd_tren:
		SetY(obj->y + currRect->Height);
		if (currAction == TurtleAction::rua_mai)
			vx = 0;
		vy = 0;
		collidWithGround = true;
		_Tick_Fly = GetTickCount(); //luu thoi gian bat dau bay
		break;
	case cd_phai:
		SetX(obj->x + obj->currBox->width);
		if (currAction == TurtleAction::rua_lan)
			vx = ROLL_VELOCITY;
		else
			vx = TURTLE_VELOCITY_X;
		break;
	case cd_trai:
		SetX(obj->x - currRect->Width);
		if (currAction == TurtleAction::rua_lan)
			vx = -ROLL_VELOCITY;
		else
			vx = -TURTLE_VELOCITY_X;
		break;
	case cd_duoi: //8.4.3
		if (obj->currBox->height == 0)
			break;
		vy *= -1;
		break;
	}
}
void Turtle::OnCollisionWithGround(BasicObject* ground, CollisionDirection cd)
{
	VaChamNen(ground, cd);
}
void Turtle::OnCollisionWithODauHoi(ODauHoi* odauhoi, CollisionDirection cd)
{
	VaChamNen(odauhoi, cd);
}
void Turtle::OnCollisionWithGach(Gach* gach, CollisionDirection cd)
{
	VaChamNen(gach, cd);
}
void Turtle::OnCollisionWithMario(CollisionDirection cd)
{
	if (Chet)
		return;
	if (mario1->starMan)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
		ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
		quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
		Chet = true;
		effect = SpriteEffects::SE_left;
		currAction = TurtleAction::rua_mai;
		vy = 10 * TURTLE_VELOCITY_Y;
		cGameInformation->SetScore(100, x, y); // Phuong --- Set diem mario
	}
	else
	switch (cd)
	{
	case cd_tren:
		switch (currAction)
		{
		case rua_bay:
			//dam rua bay
			currAction = TurtleAction::rua_di;
			cGameInformation->SetScore(100,x,y); // Phuong --- Set diem
			break;
			//dam rua di + lan
		case rua_di:
			effect = SpriteEffects::SE_right;
			currAction = TurtleAction::rua_mai;
			_Tick_Rung = GetTickCount();
			cGameInformation->SetScore(100,x,y); // Phuong --- Set diem
			break;
		case rua_lan:
			currAction = TurtleAction::rua_mai;
			_Tick_Rung = GetTickCount();
			cGameInformation->SetScore(100,x,y); // Phuong --- Set diem
			break;
			//da rua tren
		case rua_mai: case rua_rung: case rua_hoisinh:
			currAction = TurtleAction::rua_lan;
			if ((mario1->x + mario1->currRect->Width/2) < (x + currRect->Width / 2))
			{
				vx = ROLL_VELOCITY;
			}
			else
			if ((mario1->x + mario1->currRect->Width / 2) >= (x + currRect->Width / 2))
			{
				vx = -ROLL_VELOCITY;
			}
			break;
		}
		break;
	case cd_phai:
		switch (currAction)
		{
		case rua_bay: case rua_di: 
			break;
		case rua_mai: case rua_rung: case rua_hoisinh:
			if (mario1->OmRua)
			{
				currAction = TurtleAction::rua_biom;
				biOm = true;
			}
			else
			{
				if (mario1->marioAction == MarioAction::darua)
				{
					currAction = TurtleAction::rua_lan;
					vx = -ROLL_VELOCITY;
				}
			}
			break;
		}
		break;
	case cd_trai:
		switch (currAction)
		{
		case rua_bay: case rua_di:
			break;
		case rua_mai: case rua_rung: case rua_hoisinh:
			if (mario1->OmRua)
			{
				currAction = TurtleAction::rua_biom;
				biOm = true;
			}
			else
			{
				if (mario1->marioAction == MarioAction::darua)
				{
					currAction = TurtleAction::rua_lan;
					vx = ROLL_VELOCITY;
				}
			}
			break;
		}
		break;
	}
}
void Turtle::OnCollisionWithNamEnemy(NamEnemy* namenemy, CollisionDirection cd)
{
	if (mario1->OmRua) //8.4.3
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
		RuaChet(cd);
	}
	else
	{
		if (currAction != TurtleAction::rua_lan)
		{
			if (cd == CollisionDirection::cd_phai)
				vx = TURTLE_VELOCITY_X;
			if (cd == CollisionDirection::cd_trai)
				vx = -TURTLE_VELOCITY_X;
		}
	}
}
void Turtle::OnCollisionWithTurtle(Turtle* turtle, CollisionDirection cd)
{
	if (Chet)
		return;
	switch (cd)
	{
	case cd_phai:
		if (currAction == TurtleAction::rua_lan || mario1->OmRua)
		{
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
			ImageEffect* _imageeffect = new ImageEffect(turtle->x, turtle->y, 1);
			quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
			turtle->Chet = true;
			turtle->effect = SpriteEffects::SE_left;
			turtle->currAction = TurtleAction::rua_mai;
			turtle->vy = 10 * TURTLE_VELOCITY_Y;
			turtle->vx = -3 * TURTLE_VELOCITY_X;
			if (currAction == TurtleAction::rua_lan)
				vx = -ROLL_VELOCITY;
			if (mario1->OmRua)
				RuaChet(CollisionDirection::cd_phai);
			cGameInformation->SetScore(100, x, y); // Phuong --- Set diem mario
		}
		else
		{
			vx = TURTLE_VELOCITY_X;
			turtle->vx = -TURTLE_VELOCITY_X;
		}
		break;
	case cd_trai:
		if (currAction == TurtleAction::rua_lan || mario1->OmRua)
		{
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
			ImageEffect* _imageeffect = new ImageEffect(turtle->x, turtle->y, 1);
			quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
			turtle->Chet = true;
			turtle->effect = SpriteEffects::SE_left;
			turtle->currAction = TurtleAction::rua_mai;
			turtle->vy = 10 * TURTLE_VELOCITY_Y;
			turtle->vx = 3 * TURTLE_VELOCITY_X;
			if (currAction == TurtleAction::rua_lan)
				vx = ROLL_VELOCITY;
			if (mario1->OmRua)
				RuaChet(CollisionDirection::cd_trai);
			cGameInformation->SetScore(100, x, y); // Phuong --- Set diem mario
		}
		else
		{
			vx = -TURTLE_VELOCITY_X;
			turtle->vx = TURTLE_VELOCITY_X;
		}
		break;
	}
}
