#include "EndBox.h"
#include "mario.h"
#include "GameInformation.h"


EndBox::EndBox(float _x, float _y)
{
	x = _x;
	y = _y;
	this->type = Type::ot_endbox;
	listMyRect.insert(pair<EndBoxStatus, MyRectangle*>(EndBoxStatus::random, new MyRectangle(270, 166, 16, 16, 3, 3, VELOCITY_RANDOM)));
	listMyRect.insert(pair<EndBoxStatus, MyRectangle*>(EndBoxStatus::nam, new MyRectangle(318, 166, 16, 16, 4, 4, 100)));
	listMyRect.insert(pair<EndBoxStatus, MyRectangle*>(EndBoxStatus::hoa, new MyRectangle(382, 166, 16, 16, 4, 4, 100)));
	listMyRect.insert(pair<EndBoxStatus, MyRectangle*>(EndBoxStatus::sao, new MyRectangle(446, 166, 16, 16, 4, 4, 100)));
	currStatus = EndBoxStatus::random;
	SetCurrRec(currStatus);
	cardNam = new MyRectangle(0, 150, 16, 16, 1, 1, 0);
	cardHoa = new MyRectangle(16, 150, 16, 16, 1, 1, 0);
	cardSao = new MyRectangle(32, 150, 16, 16, 1, 1, 0);
	Clear = new MyRectangle(48, 150, 146, 44 ,1 ,1, 0);
}

void EndBox::SetCurrRec(EndBoxStatus status)
{
	this->currStatus = status;
	this->currRect = listMyRect.find(currStatus)->second;
	this->currBox->SetBox(currRect->Width - 2, currRect->Height - 2);
}
void EndBox::SetPreRect()
{
	preStatus = currStatus;
	*preRect = *currRect;
	*preBox = *currBox;
}
void EndBox::SetX(float _x)
{
	this->x = _x;
	this->currBox->x = x + 1;
}
void EndBox::SetY(float _y)
{
	this->y = _y;
	this->currBox->y = y - 1;
}
void EndBox::SetXY(float _x, float _y)
{
	SetX(_x);
	SetY(_y);
}
void EndBox::Render()
{
	if (isClear)
	{
		marioSprite->Render(ORIGINAL_X, ORIGINAL_Y, Clear->Rect);
		if (Level == 1)
		{
			if (cardNum == 1)
			{
				cGameInformation->cardNumber1 = 1;
				marioSprite->Render(ORIGINAL_X + 127, ORIGINAL_Y - 23, cardNam->Rect);
			}
			if (cardNum == 2)
			{
				cGameInformation->cardNumber1 = 2;
				marioSprite->Render(ORIGINAL_X + 127, ORIGINAL_Y - 23, cardHoa->Rect);
			}
			if (cardNum == 3)
			{
				cGameInformation->cardNumber1 = 3;
				marioSprite->Render(ORIGINAL_X + 127, ORIGINAL_Y - 23, cardSao->Rect);
			}
		}
		if (Level == 3)
		{
			if (cardNum == 1)
			{
				cGameInformation->cardNumber2 = 1;
				marioSprite->Render(ORIGINAL_X + 127, ORIGINAL_Y - 23, cardNam->Rect);
			}
			if (cardNum == 2)
			{
				cGameInformation->cardNumber2 = 2;
				marioSprite->Render(ORIGINAL_X + 127, ORIGINAL_Y - 23, cardHoa->Rect);
			}
			if (cardNum == 3)
			{
				cGameInformation->cardNumber2 = 3;
				marioSprite->Render(ORIGINAL_X + 127, ORIGINAL_Y - 23, cardSao->Rect);
			}
		}
		cGameInformation->Render();
	}
	else
		marioSprite->Render(x, y, currRect->Rect);
}
void EndBox::UpdatePosition()
{
	SetPreRect();	// Luu MyRectange va Box o frame truoc
	SetCurrRec(currStatus);
	if (y > ViewPort->_Y)
		isClear = true;
	switch (currStatus)
	{ 
	case EndBoxStatus::nam: case EndBoxStatus::hoa: case EndBoxStatus::sao:
		vy = -GRAVITY;
		break;
	}
	SetXY(x + vx * DeltaTime, y - preRect->Height + currRect->Height + vy * DeltaTime);
}
void EndBox::UpdateCollision()
{
	if (preStatus != currStatus)
		preRect->SetIndex(0);
	currRect->Update();
}

void EndBox::OnCollisionWithMario()
{
	mario1->starMan = false;
	SoundManager::GetInst()->RemoveAllBGM();
	SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_end); //sound
	if (currRect->Index == 0)
	{
		cardNum = 1;
		currStatus = EndBoxStatus::nam;
	}
	if (currRect->Index == 1)
	{
		cardNum = 2;
		currStatus = EndBoxStatus::hoa;
	}
	if (currRect->Index == 2)
	{
		cardNum = 3;
		currStatus = EndBoxStatus::sao;
	}
}
EndBox::~EndBox()
{
}
