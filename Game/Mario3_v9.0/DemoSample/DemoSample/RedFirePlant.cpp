#include <list>
#include "RedFirePlant.h"
#include "mario.h"
#include "World.h"
#include "GameInformation.h"

#define DEF_ALPHA_01 1        //tan(pi/4)
#define DEF_ALPHA_02 0.5    //tan(pi/8)
#define DEF_ALPHA_03 -1		  //tan(3pi/4)
#define DEF_ALPHA_04 -0.414   //tan(7pi/8)


#define DEF_CS_REDFIREPLANT 0.2
#define DEF_SMY_FIREPLANT 0.02
#define DEF_SLEEPING_TIME 2
#define DEF_SHOOTING_TIME 1.2

RedFirePlant::~RedFirePlant()
{
}
RedFirePlant::RedFirePlant(float X, float Y, bool Do, bool Ban)
{
	this->Ban = Ban;
	if (Do && Ban)
	{
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::len1, new MyRectangle(176, 74, 16, 32, 1, 1, 200)));
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::len2, new MyRectangle(176, 74, 16, 32, 2, 2, 200)));
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::xuong1, new MyRectangle(208, 74, 16, 32, 1, 1, 200)));
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::xuong2, new MyRectangle(208, 74, 16, 32, 2, 2, 200)));
		ongnuoc = new MyRectangle(368, 74, 32, 48, 1, 1, 0);
	}
	else
	if (!Do && Ban)
	{
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::len1, new MyRectangle(240, 74, 16, 24, 1, 1, 200)));
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::len2, new MyRectangle(240, 74, 16, 24, 2, 2, 200)));
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::xuong1, new MyRectangle(272, 74, 16, 24, 1, 1, 200)));
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::xuong2, new MyRectangle(272, 74, 16, 24, 2, 2, 200)));
		ongnuoc = new MyRectangle(368, 74, 32, 32, 1, 1, 0);
	}
	else
	if (!Do && !Ban)
	{
		listMyRect.insert(pair<RedFireRectangleID, MyRectangle*>(RedFireRectangleID::len2, new MyRectangle(304, 74, 16, 25, 2, 2, 200)));
		ongnuoc = new MyRectangle(368, 74, 32, 32, 1, 1, 0);
	}

	SetCurrRectangle(RedFireRectangleID::len2);
	SetPreRectangle(RedFireRectangleID::len2);
	this->x = X;
	this->y = Y;
	_OriginalY = Y;
	_OriginalX = X - this->currRect->Width / 2;
	_TickSprite = _TickSleep = _TickShoot = GetTickCount();
	_Stage = GOINGUP;
	type = Type::ot_redfireplant;
	effect = SpriteEffects::SE_left;
}
inline bool TimeOver(DWORD &dMark, float dTime)
{
	DWORD now = GetTickCount();
	if (((now - dMark) / (float)1000) >= dTime)
	{
		dMark = now;
		return true;
	}
	return false;
}
void RedFirePlant::Render()
{
	if (effect == SpriteEffects::SE_right)
		marioSprite->Render(x, y, currRect->Rect);
	else
		LmarioSprite->Render(x, y, currRect->Rect);
	marioSprite->Render(_OriginalX, _OriginalY, ongnuoc->Rect);
}
//Call stage's Red Fire plant is Shooting ONLY
void RedFirePlant::Set_Alpha_Of_Attack()
{
	float _Ox = x  + 4;
	float _Oy = y - 4.5;

	float dX, dY;

	dX = abs(_Ox - mario1->x);
	dY = abs(_Oy - mario1->y);

	if (y > mario1->y)
	{
		if (x > mario1->x)
		{
			if (dX < dY)
			{
				_Alpha = -DEF_ALPHA_03;
			}
			else
			{
				_Alpha = DEF_ALPHA_02;
			}
		}
		else
		{
			if (dX < dY)
			{
				_Alpha = DEF_ALPHA_03;
			}
			else
			{
				_Alpha = -DEF_ALPHA_02;
			}
		}
	}
	else
	{
		if (x > mario1->x)
		{
			if (dX > dY)
			{
				_Alpha = -DEF_ALPHA_02;
			}
			else
			{
				_Alpha = -DEF_ALPHA_01;
			}
		}
		else
		{
			if (dX > dY)
			{
				_Alpha = DEF_ALPHA_02;
			}
			else
			{
				_Alpha = DEF_ALPHA_01;
			}
		}
	}
}
void RedFirePlant::SetCurrRectangle(RedFireRectangleID id)
{
	currRectID = id;
	currRect = listMyRect.find(currRectID)->second;
	currBox->SetBox(currRect->Width - 2, currRect->Height - 2);// Update CurrBox
}
void RedFirePlant::SetPreRectangle(RedFireRectangleID id)
{
	preRectID = id;
	preRect = listMyRect.find(preRectID)->second;
	*preBox = *currBox;
}
void RedFirePlant::SetX(float x)
{
	this->x = x;
	currBox->x = this->x + 1;
}
void RedFirePlant::SetY(float y)
{
	this->y = y;
	currBox->y = this->y - 1;
}
void RedFirePlant::SetXY(float x, float y)
{
	SetX(x);
	SetY(y);
}

void RedFirePlant::UpdatePosition()
{
	if (abs(mario1->x - x) < 30 && y <= _OriginalY - 4)
		return;
	SetPreRectangle(currRectID);
	//Kiem tra trang thai cua RedFirePlant
	switch (_Stage)
	{
	case GOINGDOWN: //Dang di xuong
		if (y > _OriginalY - 4)
			vy = -DEF_SMY_FIREPLANT;
		else
		{
			_TickSleep = GetTickCount();
			_Stage = SLEEPING;
			vy = 0;
		}
		break;
	case GOINGUP: //Dang di len
		if (y < _OriginalY + currRect->Height)
			vy = DEF_SMY_FIREPLANT;
		else
		{
			if (Ban)
			{
				_TickSleep = GetTickCount();
				_TickShoot = GetTickCount();
				_Stage = SHOOTING;
				vy = 0;
			}
			else
			{
				_Stage = GOINGDOWN;
			}
		}
		break;
	case SHOOTING:
		if (TimeOver(_TickSleep, DEF_SLEEPING_TIME))
			_Stage = GOINGDOWN;
		else
		{
			if (TimeOver(_TickShoot, DEF_SHOOTING_TIME))
			{
				Set_Alpha_Of_Attack();
				quadtree->ThemObjectVaoQuadtree(new FireBullet(x + 4, y - 4.5, _Alpha),true);
			}
		}
		break;
	case SLEEPING: //Ngu
		if (TimeOver(_TickSleep, DEF_SLEEPING_TIME))
			_Stage = GOINGUP;
		break;
	}

	//Kiem tra toa do hien tai cua Mario va chuyen huong Sprite cua RedFirePlant
	if (Ban)
	{
		if (mario1->y < y) //Neu Mario thap hon
		{
			switch (_Stage)
			{
			case GOINGDOWN: case GOINGUP:
				SetCurrRectangle(RedFireRectangleID::xuong2);
				break;
			case SHOOTING:
				SetCurrRectangle(RedFireRectangleID::xuong1);
				break;
			}
		}
		else //Neu Mario cao hon
		{
			switch (_Stage)
			{
			case GOINGDOWN: case GOINGUP:
				SetCurrRectangle(RedFireRectangleID::len2);
				break;
			case SHOOTING:
				SetCurrRectangle(RedFireRectangleID::len1);
				break;
			}
		}
		if (mario1->x < x)
			effect = SpriteEffects::SE_left;
		else
			effect = SpriteEffects::SE_right;
	}
	// Cap nhat lai vi tri, kich thuoc rua xanh truoc khi xu ly va cham
	SetXY(x + vx * DeltaTime,
		y - preRect->Height + currRect->Height + vy * DeltaTime);
}
void RedFirePlant::UpdateCollision() 
{
	if (preRectID != currRectID)
		preRect->SetIndex(0);			// neu mario bi thay doi sprite, sprite truoc se reset
	currRect->Update();					// Chuyen den frame tiep theo
}
void RedFirePlant::OnCollisionWithMario()
{
	if (mario1->marioAction == MarioAction::quayduoi || mario1->marioAction == MarioAction::nhayquayduoi || mario1->starMan)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
		cGameInformation->SetScore(100, x, y); // Phuong --- Set diem mario
		ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
		quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
		IsRelease = true;
	}
}
void RedFirePlant::OnCollisionWithTurtle()
{
	SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
	cGameInformation->SetScore(100, x, y); // Phuong --- Set diem mario
	ImageEffect* _imageeffect = new ImageEffect(x, y, 1);
	quadtree->ThemObjectVaoQuadtree(_imageeffect, false);
	IsRelease = true;
}



