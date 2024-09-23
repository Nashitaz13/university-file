#include "Gach.h"
#include "mario.h"

#define GACH_VELLOCITY_Y 0.2

Gach::~Gach()
{
}
Gach::Gach(float _x, float _y)
{
	SetXY(_x, _y);
	originalY = y;
	this->type = Type::ot_gach;
	_Nhay = false;
	currRect = new MyRectangle(292, 134, 16, 16, 4, 4, 200);
	this->currBox->SetBox(currRect->Width, currRect->Height);
	*preBox = *currBox;
}
void Gach::Render()
{
	marioSprite->Render(x, y, currRect->Rect);
}
void Gach::UpdatePosition()
{
	*preBox = *currBox;
	if (_Nhay)
	{
		vy += GRAVITY;
		SetY(y + vy * DeltaTime);
		if (y <= originalY)
		{
			_Nhay = false;
			SetY(originalY);
		}
	}
	else
	{
		vy = 0;
	}
	currRect->Update();
}
void Gach::OnCollisionWithMario(CollisionDirection cd)
{
	if (cd == CollisionDirection::cd_duoi)
	{
		if (mario1->marioType == MarioType::nho)	// Set nhay
		{
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_dunggach);
			vy = GACH_VELLOCITY_Y;
			_Nhay = true;
		}
		else
		{
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_vogach);
			VienGachVo*	temp = new VienGachVo(x + currRect->Width / 2, y - currRect->Height / 2);
			quadtree->ThemObjectVaoQuadtree(temp, true);
			this->IsRelease = true;
		}
	}
	if (cd == CollisionDirection::cd_phai || cd == CollisionDirection::cd_trai || cd == CollisionDirection::cd_none)
	{
		if (mario1->marioAction == MarioAction::quayduoi)
		{
			{
				SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_vogach);
				VienGachVo*	temp = new VienGachVo(x + currRect->Width / 2, y - currRect->Height / 2);
				quadtree->ThemObjectVaoQuadtree(temp, true);
				this->IsRelease = true;
			}
		}
	}
}
void Gach::OnCollisionWithTurtle(Turtle* turtle, CollisionDirection cd)
{
	if (cd == CollisionDirection::cd_phai || cd == CollisionDirection::cd_trai)
	{
		if (turtle->currAction == TurtleAction::rua_lan)
		{
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_vogach);
			VienGachVo*	temp = new VienGachVo(x + currRect->Width / 2, y - currRect->Height / 2);
			quadtree->ThemObjectVaoQuadtree(temp, false);
			this->IsRelease = true;
		}
	}

}
void Gach::XuatHienDongTien()
{
	quadtree->ThemObjectVaoQuadtree(new DongTien(x, y, true), false);
	this->IsRelease = true;
}