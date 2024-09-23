#include "NamEnemy.h"
#include "mario.h"
#include "ODauHoi.h"
#include "Gach.h"
#include "GameInformation.h"

NamEnemy::~NamEnemy()
{
}
NamEnemy::NamEnemy(float _x, float _y, bool Bay)
{
	SetX(_x);
	SetY(_y);
	this->root_x = _x;
	this->root_y = _y;
	vx = -NAMENEMY_VELOCITY_X;
	this->type = Type::ot_namenemy;
	if (Bay)
	{
		listMyRect.insert(pair<NamEnemyAction, MyRectangle*>(NamEnemyAction::nam_bay, new MyRectangle(48, 74, 20, 24, 4, 4, 60)));
		listMyRect.insert(pair<NamEnemyAction, MyRectangle*>(NamEnemyAction::nam_chet, new MyRectangle(160,	74,	16,	9, 1, 1, 60)));
		listMyRect.insert(pair<NamEnemyAction, MyRectangle*>(NamEnemyAction::nam_di, new MyRectangle(128, 74, 16, 16, 2, 2, 60)));
		listMyRect.insert(pair<NamEnemyAction, MyRectangle*>(NamEnemyAction::nam_nguoc, new MyRectangle(352, 74, 16, 16, 1,	1, 60)));
		currAction = NamEnemyAction::nam_bay;
	}
	else
	{
		listMyRect.insert(pair<NamEnemyAction, MyRectangle*>(NamEnemyAction::nam_chet, new MyRectangle(32,	74,	16,	9,	1,	1, 60)));
		listMyRect.insert(pair<NamEnemyAction, MyRectangle*>(NamEnemyAction::nam_di, new MyRectangle(0,	74,	16,	16,	2,	2, 60)));
		listMyRect.insert(pair<NamEnemyAction, MyRectangle*>(NamEnemyAction::nam_nguoc, new MyRectangle(336, 74, 16, 16, 1,	1, 60)));
		currAction = NamEnemyAction::nam_di;
	}
	SetCurrRec(currAction);
}
void NamEnemy::SetCurrRec(NamEnemyAction action)
{
	this->currAction = action;
	this->currRect = listMyRect.find(currAction)->second;
	this->currBox->SetBox(currRect->Width - 2, currRect->Height - 2);
}
void NamEnemy::SetPreRect()
{
	preAction = currAction;
	*preRect = *currRect;
	*preBox = *currBox;
}
void NamEnemy::SetX(float _x)
{
	this->x = _x;
	this->currBox->x = x + 1;
}
void NamEnemy::SetY(float _y)
{
	this->y = _y;
	this->currBox->y = y - 1;
}
void NamEnemy::SetXY(float _x, float _y)
{
	SetX(_x);
	SetY(_y);
}
void NamEnemy::UpdateRootPosition()
{
	if (ViewPort->_X > this->root_x && ViewPort->_X> this->x)
	{
		this->x = this->root_x;
		this->y = this->root_y;
	}
}
void NamEnemy::Update()
{
	SetPreRect();	// Luu MyRectange va Box o frame truoc
	vy += GRAVITY;
	SetCurrRec(currAction);
	switch (currAction)
	{
	case NamEnemyAction::nam_bay:
		this->currRect->FrameTime = 120;
		// Xu ly huong theo mario
		if (x < mario1->x)
			vx = NAMENEMY_VELOCITY_X;
		else
			vx = -NAMENEMY_VELOCITY_X;

		// Xu ly nam bay
		if (GetTickCount() - _Tick_Fly >= 2200)
		{
			_Tick_Fly = GetTickCount();
		}
		else
		if (GetTickCount() - _Tick_Fly >= 1600)
		{
			this->currRect->FrameTime = 50;
			if (collidWithGround)
				vy = NAMENEMY_VELOCITY_Y;
			if (GetTickCount() - _Tick >= 600)
				vy = GRAVITY;
		}
		else
		if (GetTickCount() - _Tick_Fly >= 800)
		{
			if (collidWithGround)
				vy = NAMENEMY_VELOCITY_Y;
			if (GetTickCount() - _Tick >= 200)
				vy = GRAVITY;
		}
		else
			vy = GRAVITY;
		break;
	case NamEnemyAction::nam_chet:		// Sau khi bi mario d?m thì 0.25s s? ???c gi?i phóng
		vx = 0;
		if (GetTickCount() - _Tick_Die >= 250)
			IsRelease = true;
		break;
	case NamEnemyAction::nam_nguoc:		// Khi b? mario qu?y ?uôi trúng, r?t ra kh?i màn hình s? gi?i phóng
		TrenDoc = false;
		if (y < ViewPort->_Y - ViewPort->_Height)
			IsRelease = true;
		break;
	}
	// Cap nhat lai vi tri, kich thuoc rua xanh truoc khi xu ly va cham
	SetXY(x + vx * DeltaTime, y - preRect->Height + currRect->Height + vy * DeltaTime);
	
}
void NamEnemy::UpdatePosition()
{

	Update();
	if (TrenDoc)
	{
		float toadoy = d.TinhY(x);
		if (box->UpLeft)
		{
			if (y >= toadoy + currRect->Height + 2)
			{
				//y = y;
				SetY(y);
			}
			else
			{
				//y = toadoy + currRect->Height;
				SetY(toadoy + currRect->Height + 2);
			}
		}
		else
		{
			if (y >= toadoy + currRect->Height )
			{
				//y = y;
				SetY(y);
			}
			else
			{
				//y = toadoy + currRect->Height;
				SetY(toadoy + currRect->Height);
			}
		}


	}

	if (box != NULL)
	{
		if (x >= box->currBox->x + box->currBox->width || x <= box->currBox->x)
		{
			TrenDoc = false;
		}
	}


}
void NamEnemy::UpdateCollision()
{
	if (preAction != currAction)
		preRect->SetIndex(0);
	// Update rectangle ?ê có animation
	currRect->Update();
}
void NamEnemy::Render()
{
	marioSprite->Render(x, y, currRect->Rect);
}
void NamEnemy::VaChamNen(BasicObject* obj, CollisionDirection cd)
{
	if (currAction == NamEnemyAction::nam_nguoc)
		return;
	switch (cd)
	{
	case cd_tren:
		if (!TrenDoc)
			SetY(obj->y + currRect->Height);
		collidWithGround = true;
		_Tick = GetTickCount();
		vy = 0;
		break;
	case cd_phai:
		SetX(obj->x + obj->currBox->width);
		vx = NAMENEMY_VELOCITY_X;
		break;
	case cd_trai:
		SetX(obj->x - currRect->Width);
		vx = -NAMENEMY_VELOCITY_X;
		break;
	case cd_duoi: //8.4.3
		if (obj->currBox->height == 0)
			break;
		vy *= -1;
		break;
	}
}
void NamEnemy::OnCollisionWithGround(BasicObject* ground, CollisionDirection cd)
{
	VaChamNen(ground, cd);
}
void NamEnemy::OnCollisionWithODauHoi(ODauHoi* odauhoi, CollisionDirection cd)
{
	VaChamNen(odauhoi, cd);
}
void NamEnemy::OnCollisionWithGach(Gach* gach, CollisionDirection cd)
{
	VaChamNen(gach, cd);
}
void NamEnemy::OnCollisionWithMario(CollisionDirection cd)
{
	if (currAction == NamEnemyAction::nam_nguoc)
		return; 
	if (mario1->starMan)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
		ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
		quadtree->ThemObjectVaoQuadtree(_imageeffect, true);
		currAction = NamEnemyAction::nam_nguoc;
		vy = 10 * NAMENEMY_VELOCITY_Y;
	}
	else
	switch (cd)
	{
	case cd_tren:
		switch (currAction)
		{
		case nam_bay:
			currAction = NamEnemyAction::nam_di;
			cGameInformation->SetScore(100,x,y); // Phuong --- Set diem mario
			
			break;
		case nam_di:
			_Tick_Die = GetTickCount();
			currAction = NamEnemyAction::nam_chet;
			cGameInformation->SetScore(100,x,y); // Phuong --- Set diem mario

			break;
		}
		break;
	case cd_phai:
		if (mario1->marioAction == MarioAction::quayduoi || mario1->marioAction == MarioAction::nhayquayduoi)
		{
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
			ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
			quadtree->ThemObjectVaoQuadtree(_imageeffect,true);
			currAction = NamEnemyAction::nam_nguoc;
			vy = 10 * NAMENEMY_VELOCITY_Y;
			vx = -3 * NAMENEMY_VELOCITY_X;
		}
		break;
	case cd_trai:
		if (mario1->marioAction == MarioAction::quayduoi || mario1->marioAction == MarioAction::nhayquayduoi)
		{
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
			ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
			quadtree->ThemObjectVaoQuadtree(_imageeffect, true);
			currAction = NamEnemyAction::nam_nguoc;
			vy = 10 * NAMENEMY_VELOCITY_Y;
			vx = 3 * NAMENEMY_VELOCITY_X;
		}
		break;
	}
}
void NamEnemy::OnCollisionWithTurtle(Turtle* turtle, CollisionDirection cd)
{
	if (currAction == NamEnemyAction::nam_nguoc)
		return; //8.4.3
	if (turtle->currAction == TurtleAction::rua_lan || mario1->OmRua) //8.4.3
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
		ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
		quadtree->ThemObjectVaoQuadtree(_imageeffect, true);
		currAction = NamEnemyAction::nam_nguoc;
		vy = 10 * NAMENEMY_VELOCITY_Y;
		if (cd == CollisionDirection::cd_phai)
			vx = -3 * NAMENEMY_VELOCITY_X;
		if (cd == CollisionDirection::cd_trai)
			vx = 3 * NAMENEMY_VELOCITY_X;
		cGameInformation->SetScore(200, x, y); // Phuong --- Set diem
	}
	else
	{
		if (cd == CollisionDirection::cd_phai)
			vx = -NAMENEMY_VELOCITY_X;
		if (cd == CollisionDirection::cd_trai)
			vx = NAMENEMY_VELOCITY_X;
	}
}
void NamEnemy::OnCollisionWithNamEnemy(NamEnemy* namenemy, CollisionDirection cd)
{
	switch (cd)
	{
	case cd_phai:
		vx = NAMENEMY_VELOCITY_X;
		namenemy->vx = -NAMENEMY_VELOCITY_X;
		break;
	case cd_trai:
		vx = -NAMENEMY_VELOCITY_X;
		namenemy->vx = NAMENEMY_VELOCITY_X;
		break;
	}
}
void NamEnemy::OnCollisionWithBoxStair(CBoxStair* boxStair)
{
	TrenDoc = true;
	d = boxStair->d;
	box = boxStair;
}