#include "mario.h"
#include "GameInformation.h"

mario::~mario()
{
}
void mario::LoadListMyRectange()
{
	ifstream fileText("Image\\MyRectangle.txt");
	string line;
	getline(fileText, line);
	string state;
	int x, y, rong, cao, so_frame, framePerRow;
	while (!fileText.eof())
	{
		getline(fileText, line);
		istringstream iss(line);
		iss >> state >> x >> y >> rong >> cao >> so_frame >> framePerRow;
		listMyRect.insert(pair<MarioRectangeID, MyRectangle*>(ConvertStringToState(state), new MyRectangle(x, y, rong, cao, so_frame, framePerRow, 60)));
	}
	fileText.close();
}
MarioRectangeID mario::ConvertStringToState(string state)
{
	//MyRectangle nho
	if (state == "mario_nho_dung")
		return MarioRectangeID::mario_nho_dung;
	if (state == "mario_nho_di")
		return MarioRectangeID::mario_nho_di;
	if (state == "mario_nho_chay")
		return MarioRectangeID::mario_nho_chay;
	if (state == "mario_nho_doihuong")
		return MarioRectangeID::mario_nho_doihuong;
	if (state == "mario_nho_nhay")
		return MarioRectangeID::mario_nho_nhay;
	if (state == "mario_nho_darua")
		return MarioRectangeID::mario_nho_darua;
	if (state == "mario_nho_omrua")
		return MarioRectangeID::mario_nho_omrua;
	if (state == "mario_nho_omruachay")
		return MarioRectangeID::mario_nho_omruachay;
	if (state == "mario_nho_omruanhay")
		return MarioRectangeID::mario_nho_omruanhay;
	if (state == "mario_nho_chuiong")
		return MarioRectangeID::mario_nho_chuiong;
	if (state == "mario_nho_chet")
		return MarioRectangeID::mario_nho_chet;
	if (state == "mario_nho_nhaycao")
		return MarioRectangeID::mario_nho_nhaycao;
	if (state == "mario_nho_truotdoc")
		return MarioRectangeID::mario_nho_truotdoc;

	//MyRectangle lon
	if (state == "mario_lon_dung")
		return MarioRectangeID::mario_lon_dung;
	if (state == "mario_lon_di")
		return MarioRectangeID::mario_lon_di;
	if (state == "mario_lon_chay")
		return MarioRectangeID::mario_lon_chay;
	if (state == "mario_lon_doihuong")
		return MarioRectangeID::mario_lon_doihuong;
	if (state == "mario_lon_nhay")
		return MarioRectangeID::mario_lon_nhay;
	if (state == "mario_lon_roi")
		return MarioRectangeID::mario_lon_roi;
	if (state == "mario_lon_ngoi")
		return MarioRectangeID::mario_lon_ngoi;
	if (state == "mario_lon_darua")
		return MarioRectangeID::mario_lon_darua;
	if (state == "mario_lon_omrua")
		return MarioRectangeID::mario_lon_omrua;
	if (state == "mario_lon_omruachay")
		return MarioRectangeID::mario_lon_omruachay;
	if (state == "mario_lon_omruanhay")
		return MarioRectangeID::mario_lon_omruanhay;
	if (state == "mario_lon_chuiong")
		return MarioRectangeID::mario_lon_chuiong;
	if (state == "mario_lon_nhaycao")
		return MarioRectangeID::mario_lon_nhaycao;
	if (state == "mario_lon_nhaysao")
		return MarioRectangeID::mario_lon_nhaysao;
	if (state == "mario_lon_truotdoc")
		return MarioRectangeID::mario_lon_truotdoc;

	//MyRectangle duoi
	if (state == "mario_duoi_dung")
		return MarioRectangeID::mario_duoi_dung;
	if (state == "mario_duoi_di")
		return MarioRectangeID::mario_duoi_di;
	if (state == "mario_duoi_chay")
		return MarioRectangeID::mario_duoi_chay;
	if (state == "mario_duoi_doihuong")
		return MarioRectangeID::mario_duoi_doihuong;
	if (state == "mario_duoi_nhay")
		return MarioRectangeID::mario_duoi_nhay;
	if (state == "mario_duoi_ngoi")
		return MarioRectangeID::mario_duoi_ngoi;
	if (state == "mario_duoi_darua")
		return MarioRectangeID::mario_duoi_darua;
	if (state == "mario_duoi_omrua")
		return MarioRectangeID::mario_duoi_omrua;
	if (state == "mario_duoi_omruachay")
		return MarioRectangeID::mario_duoi_omruachay;
	if (state == "mario_duoi_omruanhay")
		return MarioRectangeID::mario_duoi_omruanhay;
	if (state == "mario_duoi_chuiong")
		return MarioRectangeID::mario_duoi_chuiong;
	if (state == "mario_duoi_chuanbibay")
		return MarioRectangeID::mario_duoi_chuanbibay;
	if (state == "mario_duoi_baylen")
		return MarioRectangeID::mario_duoi_baylen;
	if (state == "mario_duoi_roitudo")
		return MarioRectangeID::mario_duoi_roitudo;
	if (state == "mario_duoi_bayxuong")
		return MarioRectangeID::mario_duoi_bayxuong;
	if (state == "mario_duoi_quayduoi")
		return MarioRectangeID::mario_duoi_quayduoi;
	if (state == "mario_duoi_nhayquayduoi")
		return MarioRectangeID::mario_duoi_nhayquayduoi;
	if (state == "mario_duoi_nhaysao")
		return MarioRectangeID::mario_duoi_nhaysao;
	if (state == "mario_duoi_truotdoc")
		return MarioRectangeID::mario_duoi_truotdoc;
}
void mario::KhoiTao()
{
	SetX(START_X);
	SetY(START_Y);
	startJumpY = START_Y;
	vx = 0;
	vy = GRAVITY;
	LoadListMyRectange();
	SetCurrRectangle(MarioRectangeID::mario_nho_dung);
	SetPreRectangle(MarioRectangeID::mario_nho_dung);
	marioType = MarioType::nho;
	marioAction = MarioAction::dung;
	effect = SpriteEffects::SE_right;
	type = Type::ot_mario;
	OmRua = false;
	isRender = true; //8.4.3
}
mario::mario() : MovableObject()
{
	KhoiTao();
}
void mario::SetCurrRectangle(MarioRectangeID id)
{
	marioRectangeID = id;
	currRect = listMyRect.find(marioRectangeID)->second;
	if (marioType == MarioType::duoi)
	{
		currBox->SetBox(currRect->Width - 12, currRect->Height - 2);// Update CurrBox
	}
	else
		currBox->SetBox(currRect->Width - 6, currRect->Height - 2);// Update CurrBox
	//currBox->SetBox(currRect->Width - 2, currRect->Height - 2);
	//switch (marioType)
	//{
	//case nho:
	//	currBox->SetBox(13, 13);
	//	break;
	//case lon:
	//	currBox->SetBox(15, 26);
	//	break;
	//case duoi:
	//	currBox->SetBox(14, 28);
	//	break;
	//}
}
void mario::SetPreRectangle(MarioRectangeID id)
{
	preMarioRectangeID = id;
	preRect = listMyRect.find(preMarioRectangeID)->second;
	*preBox = *currBox;
}
void mario::DropDown()
{
	if (y <= -60)
	{
		SoundManager::GetInst()->RemoveAllBGM();
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chet);
		starMan = false;
		Sleep(2000);
		cGameInformation->SetLive(-1, x, y);
		die = 1;
	}
}
void mario::RunLeft(int type)
{
	if (start_run == 0)	start_run = x; //dem lan dau

	if (x - start_run >= -21)
	{
		vx = -(MARIO_VELOCITY_X + 0.02 * 1); //0.105
		this->currRect->FrameTime = 50;
		muc_doihuong = 4;
	}
	else
		if (x - start_run >= -46)
		{
			vx = -(MARIO_VELOCITY_X + 0.02 * 2);
			this->currRect->FrameTime = 45;
			muc_doihuong = 5;
		}
		else
			if (x - start_run >= -75)
			{
				vx = -(MARIO_VELOCITY_X + 0.02 * 3);
				this->currRect->FrameTime = 40;
				muc_doihuong = 6;
			}
			else
				if (x - start_run >= -108)
				{
					vx = -(MARIO_VELOCITY_X + 0.02 * 4);
					this->currRect->FrameTime = 35;
					muc_doihuong = 7;
				}
				else
					if (x - start_run >= -145)
					{
						vx = -(MARIO_VELOCITY_X + 0.02 * 5);
						this->currRect->FrameTime = 30;
						muc_doihuong = 8;
					}
					else
						if (x - start_run >= -186)
						{
							vx = -(MARIO_VELOCITY_X + 0.02 * 6);
							this->currRect->FrameTime = 25;
							muc_doihuong = 9;
						}
						else
						{
							SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chay);
							vx = -(MARIO_VELOCITY_X + 0.02 * 7);
							if (type == 1)
							{
								if (OmRua)
									SetCurrRectangle(MarioRectangeID::mario_nho_omruachay);
								else
									SetCurrRectangle(MarioRectangeID::mario_nho_chay);
							}
							if (type == 2)
							{
								if (OmRua)
									SetCurrRectangle(MarioRectangeID::mario_lon_omruachay);
								else
									SetCurrRectangle(MarioRectangeID::mario_lon_chay);
							}
							if (type == 3)
							{
								if (OmRua)
									SetCurrRectangle(MarioRectangeID::mario_duoi_omruachay);
								else
									SetCurrRectangle(MarioRectangeID::mario_duoi_chay);
							}
							this->currRect->FrameTime = 20;
							maxSpeed = true;
							muc_doihuong = 10;
						
						}
}
void mario::RunRight(int type)
{
	if (start_run == 0)	start_run = x; //dem lan dau
	if (x - start_run <= 21)
	{
		vx = MARIO_VELOCITY_X + 0.02 * 1;
		this->currRect->FrameTime = 50;
		muc_doihuong = 4;
	}
	else
		if (x - start_run <= 46)
		{
			vx = MARIO_VELOCITY_X + 0.02 * 2;
			this->currRect->FrameTime = 45;
			muc_doihuong = 5;
		}
		else
			if (x - start_run <= 75)
			{
				vx = MARIO_VELOCITY_X + 0.02 * 3;
				this->currRect->FrameTime = 40;
				muc_doihuong = 6;
			}
			else
				if (x - start_run <= 108)
				{
					vx = MARIO_VELOCITY_X + 0.02 * 4;
					this->currRect->FrameTime = 35;
					muc_doihuong = 7;
				}
				else
					if (x - start_run <= 145)
					{
						vx = MARIO_VELOCITY_X + 0.02 * 5;
						this->currRect->FrameTime = 30;
						muc_doihuong = 8;
					}
					else
						if (x - start_run <= 186)
						{
							vx = MARIO_VELOCITY_X + 0.02 * 6;
							this->currRect->FrameTime = 25;
							muc_doihuong = 9;
						}
						else
						{
							SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chay);
							vx = MARIO_VELOCITY_X + 0.02 * 7;
							if (type == 1)
							{
								if (OmRua)
									SetCurrRectangle(MarioRectangeID::mario_nho_omruachay);
								else
									SetCurrRectangle(MarioRectangeID::mario_nho_chay);
							}
							if (type == 2)
							{
								if (OmRua)
									SetCurrRectangle(MarioRectangeID::mario_lon_omruachay);
								else
									SetCurrRectangle(MarioRectangeID::mario_lon_chay);
							}
							if (type == 3)
							{
								if (OmRua)
									SetCurrRectangle(MarioRectangeID::mario_duoi_omruachay);
								else
									SetCurrRectangle(MarioRectangeID::mario_duoi_chay);
							}
							this->currRect->FrameTime = 20;
							maxSpeed = true;
							muc_doihuong = 10;
						}
}
void mario::Slow()
{
	SoundManager::GetInst()->StopSoundEffect(SoundEffect::SE_chay);
	maxSpeed = false;
	//muc cham dan cua chay 
	if (muc_doihuong > 3)
	{
		if (start == 0) start = x;
		if (right == 1)
		{
			if (x - start <= 12)
			{						//van max khi chay la vx=0.245 giam phan nua la 0.12, r?i gi?m theo m?c là 0.02
				vx = 0.12;			//voi van toc 0.12 di dc 12px nen thoi gian se la 100ms
				if (input->IsKeyPress(DIK_LEFT)) {
					start = 0;
					marioAction = MarioAction::doihuong;
					effect = SpriteEffects::SE_right;
					return;
				}
				if (input->IsKeyPress(DIK_RIGHT))
				{
					marioAction = MarioAction::di;
					return;
				}
			}
			else
				if (x - start <= (12+10))
				{
					vx = 0.1;
					if (input->IsKeyPress(DIK_LEFT)) {
			//			muc_doihuong = 4;
						start = 0;
						marioAction = MarioAction::doihuong;
						effect = SpriteEffects::SE_right;
						return;
					}
					if (input->IsKeyPress(DIK_RIGHT))
					{
						marioAction = MarioAction::di;
						return;
					}
				}
				else
					if (x - start <= (12+10+8))
					{
						vx = 0.08;
						if (input->IsKeyPress(DIK_LEFT)) {
		//					muc_doihuong = 4;
							start = 0;
							marioAction = MarioAction::doihuong;
							effect = SpriteEffects::SE_right;
							return;
						}
						if (input->IsKeyPress(DIK_RIGHT))
						{
							marioAction = MarioAction::di;
							return;
						}
					}
					else
					{
						start = 0;
						muc_doihuong = 1;
					}
		}
		else
		{
			if (x - start >= -12)
			{
				vx = -0.12;
				if (input->IsKeyPress(DIK_RIGHT)) {
					start = 0;
					marioAction = MarioAction::doihuong;
					effect = SpriteEffects::SE_left;
					return;
				}
				if (input->IsKeyPress(DIK_LEFT))
				{
					marioAction = MarioAction::di;
					return;
				}
			}
			else
				if (x - start >= -(12+10))
				{
					vx = -0.1;
					if (input->IsKeyPress(DIK_RIGHT)) {
			//			muc_doihuong = 4;
						start = 0;
						marioAction = MarioAction::doihuong;
						effect = SpriteEffects::SE_left;
						return;
					}
					if (input->IsKeyPress(DIK_LEFT))
					{
						marioAction = MarioAction::di;
						return;
					}
				}
				else
					if (x - start >= -(12+10+8))
					{
						vx = -0.08;
						if (input->IsKeyPress(DIK_RIGHT)) {
		//					muc_doihuong = 4;
							start = 0;
							marioAction = MarioAction::doihuong;
							effect = SpriteEffects::SE_left;
							return;
						}
						if (input->IsKeyPress(DIK_LEFT))
						{
							marioAction = MarioAction::di;
							return;
						}
					}
					else
					{
						start = 0;
						muc_doihuong = 1;
					}
		}
	}
	//muc cham dan cua di bo.
	//neu o muc cham dan cua chay ma khong chuyen qua doi huong se tiep tuc cham dan o muc di bo
	else
	{
		if (start == 0) start = x;
		if (right == 1)
		{
			if (x - start <= 7.1)
			{
				vx = MARIO_VELOCITY_X - 0.014 * 1;				//van toc di bo vx=0.085
				if (input->IsKeyPress(DIK_LEFT)) {
					muc_doihuong = 3;
					start = 0;
					marioAction = MarioAction::doihuong;
					effect = SpriteEffects::SE_right;
					return;
				}
				if (input->IsKeyPress(DIK_RIGHT))
				{
					marioAction = MarioAction::di;
					return;
				}
			}
			else
				if (x - start <= (7.1+5.7))
				{
					vx = MARIO_VELOCITY_X - 0.014 * 2;
					if (input->IsKeyPress(DIK_LEFT)) {
						muc_doihuong = 3;
						start = 0;
						marioAction = MarioAction::doihuong;
						effect = SpriteEffects::SE_right;
						return;
					}
					if (input->IsKeyPress(DIK_RIGHT))
					{
						marioAction = MarioAction::di;
						return;
					}
				}
				else
					if (x - start <= (7.1+5.7+4.3))
					{
						vx = MARIO_VELOCITY_X - 0.014 * 3;
						if (input->IsKeyPress(DIK_LEFT)) {
							muc_doihuong = 2;
							start = 0;
							marioAction = MarioAction::doihuong;
							effect = SpriteEffects::SE_right;
							return;
						}
						if (input->IsKeyPress(DIK_RIGHT))
						{
							marioAction = MarioAction::di;
							return;
						}
					}

					else
						if (x - start <= (7.1 + 5.7 + 4.3+2.9))
						{
							vx = MARIO_VELOCITY_X - 0.014 * 4;
							if (input->IsKeyPress(DIK_LEFT)) {
								muc_doihuong = 2;
								start = 0;
								marioAction = MarioAction::doihuong;
								effect = SpriteEffects::SE_right;
								return;
							}
							if (input->IsKeyPress(DIK_RIGHT))
							{
								marioAction = MarioAction::di;
								return;
							}
						}
						else
							if (x - start <= (7.1 + 5.7 + 4.3 + 2.9 + 1.5))
							{
								vx = MARIO_VELOCITY_X - 0.014 * 5;
								if (input->IsKeyPress(DIK_LEFT)) {
									muc_doihuong = 1;
									start = 0;
									marioAction = MarioAction::doihuong;
									effect = SpriteEffects::SE_right;
									return;
								}
								if (input->IsKeyPress(DIK_RIGHT))
								{
									marioAction = MarioAction::di;
									return;
								}
							}
							else
							{
								vx = 0;
								marioAction = MarioAction::dung;
								right = 0;
								start = 0;
							}
		}
		else
		{
			if (x - start >= -7.1)
			{
				vx = -(MARIO_VELOCITY_X - 0.014 * 1);
				if (input->IsKeyPress(DIK_RIGHT)) {
					muc_doihuong = 3;
					marioAction = MarioAction::doihuong;
					effect = SpriteEffects::SE_left;
					start = 0;
					return;
				}
				if (input->IsKeyPress(DIK_LEFT))
				{
					marioAction = MarioAction::di;
					return;
				}
			}
			else
				if (x - start >= -12.8)
				{
					vx = -(MARIO_VELOCITY_X - 0.014 * 2);
					if (input->IsKeyPress(DIK_RIGHT)) {
						muc_doihuong = 3;
						marioAction = MarioAction::doihuong;
						effect = SpriteEffects::SE_left;
						start = 0;
						return;
					}
					if (input->IsKeyPress(DIK_LEFT))
					{
						marioAction = MarioAction::di;
						return;
					}
				}
				else
					if (x - start >= -17.1)
					{
						vx = -(MARIO_VELOCITY_X - 0.014 * 3);
						if (input->IsKeyPress(DIK_RIGHT)) {
							muc_doihuong = 2;
							marioAction = MarioAction::doihuong;
							effect = SpriteEffects::SE_left;
							start = 0;
							return;
						}
						if (input->IsKeyPress(DIK_LEFT))
						{
							marioAction = MarioAction::di;
							return;
						}
					}

					else
						if (x - start >= -20)
						{
							vx = -(MARIO_VELOCITY_X - 0.014 * 4);
							if (input->IsKeyPress(DIK_RIGHT)) {
								muc_doihuong = 2;
								marioAction = MarioAction::doihuong;
								effect = SpriteEffects::SE_left;
								start = 0;
								return;
							}
							if (input->IsKeyPress(DIK_LEFT))
							{
								marioAction = MarioAction::di;
								return;
							}
						}
						else
							if (x - start >= -21.5)
							{
								vx = -(MARIO_VELOCITY_X - 0.014 * 5);
								if (input->IsKeyPress(DIK_RIGHT)) {
									muc_doihuong = 1;
									marioAction = MarioAction::doihuong;
									effect = SpriteEffects::SE_left;
									start = 0;
									return;
								}
								if (input->IsKeyPress(DIK_LEFT))
								{
									marioAction = MarioAction::di;
									return;
								}
							}
							else
							{
								vx = 0;
								marioAction = MarioAction::dung;
								right = 0;
								start = 0;
							}
		}
	}
}
void mario::ChangeDirection(float &k)
{
	if (start == 0)	 start = x;
	if (right == 1)
	{

		if (muc_doihuong >= 9)
		{
			k = k + 16;
			if (x - start <= k)	vx = 0.16;		//van toc max vx=0.24 doi huong giam 0.08, toi 0.06, toi 0.04, toi 0.02
			else muc_doihuong = 8;
		}
		else
			if (muc_doihuong >= 7)
			{
				k = k + 10;
				if (x - start <= k)	vx = 0.10; //van toc giam 0.06
				else muc_doihuong = 6;
			}
			else
				if (muc_doihuong >= 5)
				{
					k = k + 12;
					if (x - start <= k)	vx = 0.06; //van toc giam 0.04
					else muc_doihuong = 4;
				}
				else
					if (muc_doihuong >= 3)    //muc doi huong 3 va 4 la khi tha nut cham dan ma doi huong
					{
						k = k + 8;
						if (x - start <= k)	vx = 0.04; // van toc giam 0.02
						else muc_doihuong = 2;
					}
					else
						if (muc_doihuong == 2)
						{
							k = k + 4;
							if (x - start <= k)	vx = 0.02;
							else muc_doihuong = 1;
						}
						else
							if (muc_doihuong == 1)
							{
								vx = 0;
								marioAction = MarioAction::di;
								right = 0;
								k = 0;
							}
	}
	else
	{

		if (muc_doihuong >= 9)
		{
			k = k - 16;
			if (x - start >= k)	vx = -0.16;
			else muc_doihuong = 8;
		}
		else
			if (muc_doihuong >= 7)
			{
				k = k - 10;
				if (x - start >= k)	vx = -0.10;
				else muc_doihuong = 6;
			}
			else
				if (muc_doihuong >= 5)
				{
					k = k - 12;
					if (x - start >= k)	vx = -0.06;
					else muc_doihuong = 4;
				}
				else
					if (muc_doihuong >= 3)
					{
						k = k - 8;
						if (x - start >= k)	vx = -0.04;
						else muc_doihuong = 2;
					}
					else
						if (muc_doihuong == 2)
						{
							k = k - 4;
							if (x - start >= k)	vx = -0.02;
							else muc_doihuong = 1;
						}
						else
							if (muc_doihuong == 1)
							{
								vx = 0;
								marioAction = MarioAction::di;
								right = 0;
								k = 0;
							}
	}
}
//Trang thai om rua (dung, di, chamdan, !doihuong, !ngoi, nhay, roi, bay )
void mario::KeepTurtle(int marioType, int actionType)
{
	if (marioType == 1)
	{
		if (actionType == 1)	SetCurrRectangle(MarioRectangeID::mario_nho_omrua);
		if (actionType == 2)	SetCurrRectangle(MarioRectangeID::mario_nho_omruachay);
		if (actionType == 3)	SetCurrRectangle(MarioRectangeID::mario_nho_omruanhay);
	}
	if (marioType == 2)
	{
		if (actionType == 1)	SetCurrRectangle(MarioRectangeID::mario_lon_omrua);
		if (actionType == 2)	SetCurrRectangle(MarioRectangeID::mario_lon_omruachay);
		if (actionType == 3)	SetCurrRectangle(MarioRectangeID::mario_lon_omruanhay);
	}
	if (marioType == 3)
	{
		if (actionType == 1)	SetCurrRectangle(MarioRectangeID::mario_duoi_omrua);
		if (actionType == 2)	SetCurrRectangle(MarioRectangeID::mario_duoi_omruachay);
		if (actionType == 3)	SetCurrRectangle(MarioRectangeID::mario_duoi_omruanhay);
	}
	if (input->IsKeyRelease(DIK_C))
	{
		OmRua = false;
		marioAction = MarioAction::darua;
		_Tick_Darua = GetTickCount();
	}
}
void mario::VaChamNen(BasicObject* obj, CollisionDirection cd)
{
	switch (cd)
	{
	case cd_tren:
		SetY(obj->y + currRect->Height);
		vy = 0;
		switch (marioAction)
		{
		case roi:
			marioAction = MarioAction::di;
			vy = 0;
			maxSpeed = false;
		case nhay: case baylen:
			marioAction = MarioAction::di;
			vy = 0;
		case bayxuong:
			marioAction = MarioAction::di;
			vy = 0;
			t0 = 0;
			t1 = 0;
			maxSpeed = false;
		}
		break;
	case cd_phai:
		if (obj->currBox->height == 0)
			break;
		if (muc_doihuong >= 4)
		{
			if (marioRectangeID == MarioRectangeID::mario_nho_chay)
				SetCurrRectangle(MarioRectangeID::mario_nho_di);
			if (marioRectangeID == MarioRectangeID::mario_lon_chay)
				SetCurrRectangle(MarioRectangeID::mario_lon_di);
			if (marioRectangeID == MarioRectangeID::mario_duoi_chay)
				SetCurrRectangle(MarioRectangeID::mario_duoi_di);
			if (muc_doihuong >= 9) maxSpeed = false;
			start_run = 0;
		}
		SetX(obj->x + obj->currBox->width);
		if (marioAction == MarioAction::chamdan)
			marioAction = MarioAction::dung;
		if (marioAction == MarioAction::doihuong)
		{
			marioAction = MarioAction::dung;
			if (effect == SpriteEffects::SE_right)
				effect = SpriteEffects::SE_left;
			else
				effect = SpriteEffects::SE_right;
		} //8.4.3
		break;
	case cd_trai:
		if (obj->currBox->height == 0)
			break;
		if (TrenDoc)
			return;
		SetX(obj->x - currRect->Width);
		if (muc_doihuong >= 4)
		{
			if (marioRectangeID == MarioRectangeID::mario_nho_chay)
				SetCurrRectangle(MarioRectangeID::mario_nho_di);
			if (marioRectangeID == MarioRectangeID::mario_lon_chay)
				SetCurrRectangle(MarioRectangeID::mario_lon_di);
			if (marioRectangeID == MarioRectangeID::mario_duoi_chay)
				SetCurrRectangle(MarioRectangeID::mario_duoi_di);
			if (muc_doihuong >= 9) 
				maxSpeed = false;
			start_run = 0;
		}
		if (marioAction == MarioAction::chamdan)
			marioAction = MarioAction::dung;
		if (marioAction == MarioAction::doihuong)
		{
			marioAction = MarioAction::dung;
			if (effect == SpriteEffects::SE_right)
				effect = SpriteEffects::SE_left;
			else
				effect = SpriteEffects::SE_right;
		}
		break;
	case cd_duoi:
		if (obj->currBox->height == 0 || obj->currBox->height == 1)
			break;
		vy *= -1;
		y = obj->y - obj->currBox->height;
		break;
	}
}
void mario::ProcessInput()
{
	if (stageClear)
	{
		effect = SpriteEffects::SE_right;
		marioAction = MarioAction::di;
		SetX(x + 0.5 * MARIO_VELOCITY_X * DeltaTime);
	}
	if (Level == 3)
	{
		if (input->IsKeyDown(DIK_1) || x >= STAGE1_WIDTH)
		{
			Level = 1;
			stageClear = false;
		}
	}
	if (Level == 1)
	{
		if (input->IsKeyDown(DIK_2) || x >= STAGE1_WIDTH)
		{
			Level = 3;
			stageClear = false;
		}
	}

	Sound();
	float k = 0;
	switch (marioType)
	{
#pragma region
	case nho:
		//Biến đuôi
		if (input->IsKeyDown(DIK_D))
			marioType = MarioType::duoi;
		if (input->IsKeyDown(DIK_L))
			marioType = MarioType::lon;
		//Biến lớn
		if (isNhapNhay)
		{
			if (GetTickCount() - _Tick_NhapNhay > 25)
			{
				if (isRender)
					isRender = false;
				else
					isRender = true;
				_Tick_NhapNhay = GetTickCount();
			}
			if (GetTickCount() - _Tick > 2500)
			{
				isNhapNhay = false;
				isRender = true;
			}
		}

		if (bienNhoLon)
		{
			if (isSmall)
			{
				vx = 0;
				vy = 0;
				marioAction = MarioAction::dung;
				if (GetTickCount() - _Tick_NhoLon > 25)
				{
					marioType = MarioType::lon;
					isSmall = false;
					_Tick_NhoLon = GetTickCount();
				}
			}
			if (bienLon)
			{
				if (GetTickCount() - _Tick >= 1000)
				{
					marioType = MarioType::lon;
					bienNhoLon = false;
					input->Active();
				}
			}
		}
		switch (marioAction)
		{
		case dung:
			//Om rua
			if (OmRua)
				KeepTurtle(1, 1);
			else
				SetCurrRectangle(MarioRectangeID::mario_nho_dung);
			//
			vx = 0;
			if (input->IsKeyDown(DIK_LEFT) || (input->IsKeyDown(DIK_RIGHT)))
			{
				marioAction = MarioAction::di;
			}
			PreProcessingForJump();
			break;
		case di:
			//Om rua di
			if (OmRua)
				KeepTurtle(1, 2);
			else
				SetCurrRectangle(MarioRectangeID::mario_nho_di);
			//
			if (input->IsKeyPress(DIK_LEFT))
			{
				if (start == 0) start = x;
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;


				if (input->IsKeyPress(DIK_C))
					RunLeft(1);
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				if (start == 0) start = x;
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
				if (input->IsKeyPress(DIK_C))
					RunRight(1);
			}

			if (input->IsKeyUp(DIK_LEFT) || input->IsKeyUp(DIK_RIGHT) || input->IsKeyUp(DIK_C))
			{
				this->currRect->FrameTime = 60;
				start_run = 0;
				if (test_collision_wall == 1)
				{
					if (!input->IsKeyUp(DIK_C))
					{
						if ((input->IsKeyUp(DIK_RIGHT) && input->IsKeyPress(DIK_LEFT)) || (input->IsKeyUp(DIK_LEFT) && input->IsKeyPress(DIK_RIGHT)))
							marioAction = MarioAction::di;
						else marioAction = MarioAction::dung;
						test_collision_wall = 0;
					}
				}
				else
				{
					float finish = x;
					if (abs(finish - start) > 48) //di dc hon 48 px moi co the doi huong
					{
						start = 0;
						if (input->IsKeyUp(DIK_RIGHT)) {

							right = 1;
							marioAction = MarioAction::chamdan;
							break;
						}
						if (input->IsKeyUp(DIK_LEFT)) {
							right = 0;
							marioAction = MarioAction::chamdan;
							break;
						}
					}
				}
				start = 0;
			}

			PreProcessingForJump();

			if (!input->IsKeyPress(DIK_LEFT) && !input->IsKeyPress(DIK_RIGHT) && !input->IsKeyDown(DIK_X))
			{
				vx = 0;
				marioAction = MarioAction::dung;
			}
			break;
		case chamdan:
			Slow();
			if (OmRua)
				KeepTurtle(1, 2);
			PreProcessingForJump();
			break;
		case doihuong:
			if (!OmRua)
				SetCurrRectangle(MarioRectangeID::mario_nho_doihuong);
			ChangeDirection(k);
			PreProcessingForJump();
			break;
		case nhay:
			JumpUp();
			if (OmRua)
				KeepTurtle(1, 3);
			else
			{
				if (maxSpeed)
					SetCurrRectangle(MarioRectangeID::mario_nho_nhaycao);
				else
				{
					SetCurrRectangle(MarioRectangeID::mario_nho_nhay);
					start_run = 0;
				}
			}
			break;
		case roi:
			if (OmRua)
				KeepTurtle(1, 3);
			else
				if (maxSpeed)
					SetCurrRectangle(MarioRectangeID::mario_nho_nhaycao);
			if (input->IsKeyPress(DIK_LEFT))
			{
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
			}
			break;
		case darua:
			SetCurrRectangle(MarioRectangeID::mario_nho_darua);
			if (GetTickCount() - _Tick_Darua >= 100)
				marioAction = MarioAction::di;
			break;
		case chuiong:
			SetCurrRectangle(MarioRectangeID::mario_nho_chuiong);
			ChuiOng();
			break;
		case truotdoc:
			SetCurrRectangle(MarioRectangeID::mario_nho_truotdoc);
			if (!TruotDoc)
				marioAction = MarioAction::di;
			break;
		case chet:
			SetCurrRectangle(MarioRectangeID::mario_nho_chet);
			vx = 0;

			if (GetTickCount() - _Tick_Die >= 1000)
				vy = 3 * GRAVITY;
			else
				if (GetTickCount() - _Tick_Die >= 800)
					vy = MARIO_VELOCITY_Y;
				else
					vy = 0;
				if (y < ViewPort->_Y - ViewPort->_Height)
				{
					die = 1;
					cGameInformation->SetLive(-1, x, y);
				}
			break;
		}
		break;
#pragma endregion nho
#pragma region lớn
	case lon:
		//Biến nhỏ
		if (input->IsKeyDown(DIK_N))
			marioType = MarioType::nho;
		if (isNhapNhay)
		{
			if (GetTickCount() - _Tick_NhapNhay > 25)
			{
				if (isRender)
					isRender = false;
				else
					isRender = true;
				_Tick_NhapNhay = GetTickCount();
			}
			if (GetTickCount() - _Tick > 2500)
			{
				isNhapNhay = false;
				isRender = true;
			}
		}

		if (bienNhoLon)
		{
			if (!isSmall)
			{
				vx = 0;
				vy = 0;
				marioAction = MarioAction::dung;
				if (GetTickCount() - _Tick_NhoLon > 25)
				{
					marioType = MarioType::nho;
					isSmall = true;
					_Tick_NhoLon = GetTickCount();
				}
			}
			if (!bienLon)
			{
				if (GetTickCount() - _Tick >= 1000)
				{
					marioType = MarioType::nho;
					bienNhoLon = false;
					isNhapNhay = true;
					input->Active();
				}
			}
		}
		//Biến đuôi
		// 8.4.3
		if (indexLonDuoi)
		{
			isRender = true;
			indexLonDuoi = false;
			bienLonDuoi = false;
			marioType = MarioType::duoi;
			input->Active();
		}
		switch (marioAction)
		{
		case dung:
			if (OmRua)
				KeepTurtle(2, 1);
			else
				SetCurrRectangle(MarioRectangeID::mario_lon_dung);
			vx = 0;
			if (input->IsKeyDown(DIK_LEFT) || (input->IsKeyDown(DIK_RIGHT)))
			{
				marioAction = MarioAction::di;
			}
			if (input->IsKeyPress(DIK_DOWN))
				if (!OmRua)
					SetCurrRectangle(MarioRectangeID::mario_lon_ngoi);
			PreProcessingForJump();
			break;
		case di:
			if (OmRua)
				KeepTurtle(2, 2);
			else
				SetCurrRectangle(MarioRectangeID::mario_lon_di);
			if (input->IsKeyPress(DIK_LEFT))
			{
				if (start == 0) start = x;
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;
				if (input->IsKeyPress(DIK_C))
					RunLeft(2);
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				if (start == 0) start = x;
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
				if (input->IsKeyPress(DIK_C)) RunRight(2);
			}
			if (input->IsKeyUp(DIK_LEFT) || input->IsKeyUp(DIK_RIGHT) || input->IsKeyUp(DIK_C))
			{
				this->currRect->FrameTime = 60;
				start_run = 0;
				float finish = x;
				if (abs(finish - start) > 48) //di dc hon 48 px moi co the doi huong
				{
					start = 0;
					if (input->IsKeyUp(DIK_RIGHT)) {

						right = 1;
						marioAction = MarioAction::chamdan;
						break;
					}
					if (input->IsKeyUp(DIK_LEFT)) {
						right = 0;
						marioAction = MarioAction::chamdan;
						break;

					}
				}
				start = 0;
			}
			if (!input->IsKeyPress(DIK_LEFT) && !input->IsKeyPress(DIK_RIGHT) && !input->IsKeyDown(DIK_X))
			{
				vx = 0;
				marioAction = MarioAction::dung;
			}
			PreProcessingForJump();
			break;
		case chamdan:
			Slow();
			if (OmRua)
				KeepTurtle(2, 2);
			if (input->IsKeyDown(DIK_DOWN))
				if (!OmRua)
					SetCurrRectangle(MarioRectangeID::mario_lon_ngoi);
			PreProcessingForJump();
			break;
		case doihuong:
			if (!OmRua)
				SetCurrRectangle(MarioRectangeID::mario_lon_doihuong);
			ChangeDirection(k);
			PreProcessingForJump();
			break;
		case nhay:
			JumpUp();
			if (OmRua)
				KeepTurtle(2, 3);
			else
			{
				if (starMan)
					SetCurrRectangle(MarioRectangeID::mario_lon_nhaysao);
				else
				{
					if (maxSpeed)
						SetCurrRectangle(MarioRectangeID::mario_lon_nhaycao);
					else
						SetCurrRectangle(MarioRectangeID::mario_lon_nhay);
				}
			}
			break;
		case roi:
			if (OmRua)
				KeepTurtle(2, 3);
			else
			{
				if (maxSpeed)
					SetCurrRectangle(MarioRectangeID::mario_lon_nhaycao);
				else
					SetCurrRectangle(MarioRectangeID::mario_lon_roi);
			}
			if (input->IsKeyPress(DIK_LEFT))
			{
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
			}
			break;
		case darua:
			SetCurrRectangle(MarioRectangeID::mario_lon_darua);
			if (GetTickCount() - _Tick_Darua >= 100)
				marioAction = MarioAction::di;
			break;
		case chuiong:
			SetCurrRectangle(MarioRectangeID::mario_lon_chuiong);
			ChuiOng();
			break;
		case truotdoc:
			SetCurrRectangle(MarioRectangeID::mario_lon_truotdoc);
			if (!TruotDoc)
				marioAction = MarioAction::di;
			break;
		}
		break;
#pragma endregion
#pragma region đuôi
	case duoi:
		//Biến nhỏ
		if (input->IsKeyDown(DIK_N))
			marioType = MarioType::nho;
		//Biển lớn
		if (indexLonDuoi)
		{
			isRender = true;
			bienLonDuoi = false;
			indexLonDuoi = false;
			isNhapNhay = true;
			marioType = MarioType::lon;
			input->Active();
		}
		switch (marioAction)
		{
		case dung:
			if (OmRua)
				KeepTurtle(3, 1);
			else
				SetCurrRectangle(MarioRectangeID::mario_duoi_dung);
			vx = 0;
			if (input->IsKeyDown(DIK_LEFT) || (input->IsKeyDown(DIK_RIGHT)))
			{
				marioAction = MarioAction::di;
			}
			if (input->IsKeyPress(DIK_DOWN))
				if (!OmRua)
					SetCurrRectangle(MarioRectangeID::mario_duoi_ngoi);
			if (input->IsKeyDown(DIK_C))
			{
				marioAction = MarioAction::quayduoi;
			}
			PreProcessingForJump();
			break;
		case di:
			if (OmRua)
				KeepTurtle(3, 2);
			else
				SetCurrRectangle(MarioRectangeID::mario_duoi_di);
			if (input->IsKeyPress(DIK_LEFT))
			{
				if (start == 0) start = x;
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;
				if (input->IsKeyPress(DIK_C))
				{
					RunLeft(3);
				}
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				if (start == 0) start = x;
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
				if (input->IsKeyPress(DIK_C))
				{
					RunRight(3);
				}
			}
			if (input->IsKeyUp(DIK_LEFT) || input->IsKeyUp(DIK_RIGHT) || input->IsKeyUp(DIK_C))
			{
				this->currRect->FrameTime = 60;
				start_run = 0;
				float finish = x;
				if (abs(finish - start) > 48) //di dc hon 48 px moi co the doi huong
				{
					start = 0;
					if (input->IsKeyUp(DIK_RIGHT)) {

						right = 1;
						marioAction = MarioAction::chamdan;
						break;
					}
					if (input->IsKeyUp(DIK_LEFT)) {
						right = 0;
						marioAction = MarioAction::chamdan;
						break;
					}
				}
				start = 0;
			}
			if (!input->IsKeyPress(DIK_LEFT) && !input->IsKeyPress(DIK_RIGHT) && !input->IsKeyDown(DIK_X))
			{
				vx = 0;
				marioAction = MarioAction::dung;
			}
			if (input->IsKeyDown(DIK_C))
				marioAction = MarioAction::quayduoi;
			PreProcessingForJump();
			break;
		case chamdan:
			Slow();
			if (OmRua)
				KeepTurtle(3, 2);
			if (input->IsKeyDown(DIK_DOWN))
				if (!OmRua)
					SetCurrRectangle(MarioRectangeID::mario_duoi_ngoi);

			if (input->IsKeyDown(DIK_C))
				marioAction = MarioAction::quayduoi;
			PreProcessingForJump();
			break;
		case doihuong:
			if (!OmRua)
				SetCurrRectangle(MarioRectangeID::mario_duoi_doihuong);
			ChangeDirection(k);
			PreProcessingForJump();
			break;
		case nhay:
			if (input->IsKeyDown(DIK_C))
				marioAction = MarioAction::nhayquayduoi;
			if (maxSpeed)
			{
				if (input->IsKeyPress(DIK_X))
				{
					JumpUp();
					if (OmRua)
						KeepTurtle(3, 3);
					else
						SetCurrRectangle(MarioRectangeID::mario_duoi_chuanbibay);
				}
				else
					if (input->IsKeyDown(DIK_X))
						marioAction = MarioAction::baylen;
			}
			else
			{
				JumpUp();
				if (starMan)
					SetCurrRectangle(MarioRectangeID::mario_duoi_nhaysao);
				else
				{
					if (OmRua)
						KeepTurtle(3, 3);
					else
						SetCurrRectangle(MarioRectangeID::mario_duoi_nhay);
				}
			}
			break;
		case roi:
			if (input->IsKeyDown(DIK_C))
				marioAction = MarioAction::nhayquayduoi;
			if (maxSpeed && input->IsKeyPress(DIK_X))
			{
				if (OmRua)
					KeepTurtle(3, 3);
				else
					SetCurrRectangle(MarioRectangeID::mario_duoi_chuanbibay);
			}
			else
			{
				if (OmRua)
					KeepTurtle(3, 3);
				else
					SetCurrRectangle(MarioRectangeID::mario_duoi_roitudo);
			}
			if (input->IsKeyDown(DIK_X))
			{
				marioAction = MarioAction::bayxuong;
			}
			if (input->IsKeyPress(DIK_LEFT))
			{
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
			}
			break;
		case baylen:
			if (input->IsKeyDown(DIK_C))
				marioAction = MarioAction::nhayquayduoi;
			if (t0 == 0) t0 = clock();
			if (input->IsKeyDown(DIK_X))
			{
				t1 = clock();
				if (OmRua)
					KeepTurtle(3, 3);
				else
					SetCurrRectangle(MarioRectangeID::mario_duoi_baylen);
				vy = MARIO_VELOCITY_Y;
			}
			if (input->IsKeyUp(DIK_X))
			{
				if (OmRua)
					KeepTurtle(3, 3);
				else
					SetCurrRectangle(MarioRectangeID::mario_duoi_chuanbibay);
			}
			if (t1 - t0 >= 4000)
			{
				SoundManager::GetInst()->StopSoundEffect(SoundEffect::SE_chay);
				marioAction = MarioAction::roi;
			}
			if (input->IsKeyPress(DIK_LEFT))
			{
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
			}
			break;
		case bayxuong:
			SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_quayduoi);
			if (input->IsKeyDown(DIK_C))
				marioAction = MarioAction::nhayquayduoi;
			if (OmRua)
				KeepTurtle(3, 3);
			else
				SetCurrRectangle(MarioRectangeID::mario_duoi_bayxuong);
			vy = GRAVITY * 0.6;
			if (input->IsKeyUp(DIK_X))
				marioAction = MarioAction::roi;
			if (input->IsKeyPress(DIK_LEFT))
			{
				vx = -MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_left;
			}
			if (input->IsKeyPress(DIK_RIGHT))
			{
				vx = MARIO_VELOCITY_X;
				effect = SpriteEffects::SE_right;
			}
			break;
		case darua:
			SetCurrRectangle(MarioRectangeID::mario_duoi_darua);
			if (GetTickCount() - _Tick_Darua >= 100)
				marioAction = MarioAction::di;
			break;
		case quayduoi:
			this->currRect->FrameTime = 50;
			SetCurrRectangle(MarioRectangeID::mario_duoi_quayduoi);
			if (currRect->Index == currRect->Total - 1)
				marioAction = MarioAction::di;
			break;
		case nhayquayduoi:
			this->currRect->FrameTime = 50;
			SetCurrRectangle(MarioRectangeID::mario_duoi_nhayquayduoi);
			if (currRect->Index == currRect->Total - 1)
				marioAction = MarioAction::roi;
			break;
		case chuiong:
			SetCurrRectangle(MarioRectangeID::mario_duoi_chuiong);
			ChuiOng();
			break;
		case truotdoc:
			SetCurrRectangle(MarioRectangeID::mario_duoi_truotdoc);
			if (!TruotDoc)
				marioAction = MarioAction::di;
			break;
		}
		break;
#pragma endregion duoi
	}
	if (bienLonDuoi)
	{
		vx = 0;
		vy = 0;
	}
	// Cap nhat lai vi tri, kich thuoc mario truoc khi xu ly va cham
	SetXY(x + vx * DeltaTime, y - preRect->Height + currRect->Height + vy * DeltaTime);
}
void mario::Update()
{
	if (GetTickCount() - _Tick_Sao > MARIO_TIME_STARMAN)
		starMan = false;
	SetPreRectangle(marioRectangeID);	// Luu MyRectange o frame truoc
	vy += GRAVITY;
	DropDown();
	ProcessInput();						// Xu ly su kien phim
	if (marioAction != MarioAction::chet && !chuiOng)
		XuLyVaCham();
	if (preMarioRectangeID != marioRectangeID)
		preRect->SetIndex(0);			// neu mario bi thay doi sprite, sprite truoc se reset
	currRect->Update();					// Chuyen den frame tiep theo
	if (box != NULL)
	{
		if ((x >= box->currBox->x + box->currBox->width) || (x + currRect->Width <= box->currBox->x))
		{
			TrenDoc = false;
			TruotDoc = false;
		}
	}
	if (TrenDoc)
	{
		if (input->IsKeyDown(DIK_DOWN))
		{
			TruotDoc = true;
		}
		float toadoy = d.TinhY(x);
		if (box->UpLeft)
		{
			if (y >= toadoy + currRect->Height + 5)
				y = y;
			else
				y = toadoy + currRect->Height + 5;
		}
		else
		{
			if (y >= toadoy + currRect->Height - 5)
				y = y;
			else
				y = toadoy + currRect->Height - 5;
		}
		if (TruotDoc)
		{
			marioAction = MarioAction::truotdoc;
			if (box->UpLeft)
				SetX(x - 1.5 * MARIO_VELOCITY_X * DeltaTime);
			else
				SetX(x + 1.5 * MARIO_VELOCITY_X * DeltaTime);
		}
	}
}
void mario::Render()
{
	if (isRender)
	{
		if (effect == SpriteEffects::SE_right)
		{
			if (starMan)
				marioStarSprite->Render(x, y, currRect->Rect);
			else
				marioSprite->Render(x, y, currRect->Rect);
		}
		else
		{
			if (marioAction == MarioAction::quayduoi)
			{
				if (starMan)
					LmarioStarSprite->Render(x - 9, y, currRect->Rect);
				else
					LmarioSprite->Render(x - 9, y, currRect->Rect);
			}
			else
			{
				if (starMan)
					LmarioStarSprite->Render(x, y, currRect->Rect);
				else
					LmarioSprite->Render(x, y, currRect->Rect);
			}
		}
	}
	cGameInformation->DrawIntString(10, 10, x);
	cGameInformation->DrawIntString(10, 30, y);
}
void mario::XuLyVaCham()
{
	CollisionDirection cd;
	vector<BasicObject*>::iterator it = listObject.begin();
	for (; it != listObject.end(); it++)
	{
		BasicObject* ob = *it;
		if (CheckCollision(ob, cd) != 1)
		{
			switch (ob->type)
			{
			case Type::ot_ground:
				OnCollidWithGround(ob, cd);
				if (cd == CollisionDirection::cd_phai || cd == CollisionDirection::cd_trai)
				{
					test_collision_wall = 1;
					this->currRect->FrameTime = 60;
				}
				break;
			case Type::ot_turtle:
				OnCollisionWithTurtle((Turtle*)ob, cd);
				((Turtle*)ob)->OnCollisionWithMario(cd);
				break;
			case Type::ot_dongtien:
				((DongTien*)ob)->OnCollisionWithMario();
				break;
			case Type::ot_namenemy:
				if (((NamEnemy*)ob)->currAction == NamEnemyAction::nam_chet) continue;
				OnCollisionWithNamEnemy((NamEnemy*)ob, cd);
				((NamEnemy*)ob)->OnCollisionWithMario(cd);
				break;
			case Type::ot_chuP:
				((ChuP*)ob)->OnCollisionWithMario();
				it = world->FindIterator(ob);
				break;
				//8.4.3
			case Type::ot_chiecla:
				OnCollisionWithChiecLa((ChiecLa*)ob);
				((ChiecLa*)ob)->OnCollisionWithMario();
				it = world->FindIterator(ob);
				break;
				//8.4.3
			case Type::ot_namitem:
				OnCollisionWithNamItem((NamItem*)ob);
				((NamItem*)ob)->OnCollisionWithMario();
				break;
			case Type::ot_firebullet:
				OnCollisionWithFireBullet();
				it = world->FindIterator(ob);
				break;
				//8.4.4
			case Type::ot_redfireplant:
				OnCollisionWithRedFirePlant();
				((RedFirePlant*)ob)->OnCollisionWithMario();
				break;
			case Type::ot_ongnuoc:
				OnCollisionWithOngNuoc((OngNuoc*)ob, cd);
				break;
			case Type::ot_endbox:
				((EndBox*)ob)->OnCollisionWithMario();
				OnCollisionWithEndBox();
				break;
			case Type::ot_boxstair:
				OnCollisionWithBoxStair((CBoxStair*)ob, cd);
				break;
			}
		}
	}
	// Kiem tra va cham voi o dau hoi
	for (vector<ODauHoi*>::iterator it = listODauHoi.begin();
	it != listODauHoi.end(); it++)
	{
		int i = 0;
		if (CheckCollision(*it, cd) != 1)
		{
			if ((*it)->state == ODauHoiState::ODS_normal)
			{
				if(++i == 1)
					((*it))->OnCollisionWithMario(cd);
			}
			OnCollisionWithODauHoi(*it, cd);
			break;
		}
	}
	// Kiem tra va cham voi gach
	for (vector<Gach*>::iterator it = listGach.begin();
	it != listGach.end(); it++)
	{
		if (CheckCollision(*it, cd) != 1)
		{
			((*it))->OnCollisionWithMario(cd);
			OnCollisionWithGach(*it, cd);
			break;
		}
	}
}
void mario::JumpUp()
{
	if (input->IsKeyPress(DIK_LEFT))
	{
		if(vx == 0) vx = -MARIO_VELOCITY_X;
		effect = SpriteEffects::SE_left;
	}
	if (input->IsKeyPress(DIK_RIGHT))
	{
		if (vx == 0) vx = MARIO_VELOCITY_X;
		effect = SpriteEffects::SE_right;
	}
	if (input->IsKeyUp(DIK_X) || (y - startJumpY >= MARIO_MAX_JUMP_DISTANCE))
	{
		isJumpIncrease = false;
	}
	if (input->IsKeyPress(DIK_X) && isJumpIncrease)
	{
		vy += MARIO_ACCELERATION_Y;
	}
	if (vy <= 0)
	{
		marioAction = MarioAction::roi;
	}
}
void mario::PreProcessingForJump()
{
	if (input->IsKeyDown(DIK_X))
	{
		marioAction = MarioAction::nhay;
		vy = MARIO_VELOCITY_Y;
		startJumpY = y;
		isJumpIncrease = true;
	}
}
void mario::SetX(float x)
{
	this->x = x;
	if (marioType == MarioType::duoi && effect == SpriteEffects::SE_right)
	{
		currBox->x = this->x + 9;
	}
	else
	{
		if (marioRectangeID == MarioRectangeID::mario_duoi_quayduoi
			|| marioRectangeID == MarioRectangeID::mario_duoi_nhayquayduoi)
		{
			currBox->x = this->x + 9;
			if (effect == SpriteEffects::SE_right)
			{
				if (currRect->Index == 0 || currRect->Index == 4)
				{

				}
				else
				{

				}
			}
		}
		else
		{
			currBox->x = this->x + 1;
		}
	}
}
void mario::SetY(float y)
{
	this->y = y;
	currBox->y = this->y - 1;
}
void mario::SetXY(float x, float y)
{
	SetX(x);
	SetY(y);
}
void mario::ChangeSmallBig(MarioType mariotype)
{
	input->Deactive();
	bienNhoLon = true;
	_Tick = GetTickCount();
	_Tick_NhoLon = GetTickCount();
	if (mariotype == MarioType::nho)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_nholon);
		isSmall = true;
		bienLon = true;
	}
	if (mariotype == MarioType::lon)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chuiong);
		isSmall = false;
		bienLon = false;
	}
}
void mario::ChangeBigTail()
{
	SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_londuoi);
	input->Deactive();
	bienLonDuoi = true;
	_Tick = GetTickCount();
	isRender = false;
	ImageEffect* _imageeffect = new ImageEffect(x + currRect->Width / 2, y - currRect->Height / 2, 2);
	quadtree->ThemObjectVaoQuadtree(_imageeffect, true);
}
void mario::ChuiOng()
{
	vx = 0;
	vy = 0;
	if (Level == 1)
	{
		if (ongNuoc->down)
		{
			vy = GRAVITY;
			SetX(ongNuoc->x + ongNuoc->currBox->width / 2 - currRect->Width / 2);
			if (y <= ongNuoc->y - 4)
			{
				Level = 2;
				SetX(ongNuoc->x1 + ongNuoc->width1 / 2 - currRect->Width / 2);
				SetY(ongNuoc->y1 - ongNuoc->height1 + currRect->Height + 4);
			}
		}
		else
		{
			vy = -GRAVITY;
			if (y >= ongNuoc->y1 + currRect->Height)
			{
				chuiOng = false;
				marioAction = MarioAction::di;
			}
		}
	}
	if (Level == 2)
	{
		if (ongNuoc->down)
		{
			vy = GRAVITY;
			if (y <= ongNuoc->y1 - ongNuoc->height1)
			{
				chuiOng = false;
				marioAction = MarioAction::di;
			}
		}
		else
		{
			vy = -GRAVITY;
			SetX(ongNuoc->x + ongNuoc->currBox->width / 2 - currRect->Width / 2);
			if (y >= ongNuoc->y - ongNuoc->currBox->height + currRect->Height + 4)
			{
				Level = 1;
				SetX(ongNuoc->x1 + ongNuoc->width1 / 2 - currRect->Width / 2);
				SetY(ongNuoc->y1 - 4);
			}
		}
	}

	if (Level == 3)
	{
		if (ongNuoc->down)
		{
			vy = GRAVITY;
			SetX(ongNuoc->x + ongNuoc->currBox->width / 2 - currRect->Width / 2);
			if (y <= ongNuoc->y - 4)
			{
				Level = 4;
				SetX(ongNuoc->x1 + ongNuoc->width1 / 2 - currRect->Width / 2);
				SetY(ongNuoc->y1 - ongNuoc->height1 + currRect->Height + 4);
			}
		}
		else
		{
			vy = -GRAVITY;
			if (y >= ongNuoc->y1 + currRect->Height)
			{
				chuiOng = false;
				marioAction = MarioAction::di;
			}
		}
	}
	if (Level == 4)
	{
		if (ongNuoc->down)
		{
			vy = GRAVITY;
			if (y <= ongNuoc->y1 - ongNuoc->height1)
			{
				chuiOng = false;
				marioAction = MarioAction::di;
			}
		}
		else
		{
			vx = -MARIO_VELOCITY_X;
			SetY(ongNuoc->y - ongNuoc->currBox->height + currRect->Height);
			if (x <= ongNuoc->x + ongNuoc->currBox->width - currRect->Width - 4)
			{
				Level = 3;
				SetX(ongNuoc->x1 + ongNuoc->width1 / 2 - currRect->Width / 2);
				SetY(ongNuoc->y1 - 4);
			}
		}
	}
}
void mario::OnCollidWithGround(BasicObject* ground, CollisionDirection cd)
{
	VaChamNen(ground, cd);
}
void mario::OnCollisionWithODauHoi(ODauHoi* odauhoi, CollisionDirection cd)
{
	if (cd == CollisionDirection::cd_tren)
	{
		if (odauhoi->Loai == 3)
			vy = MARIO_VELOCITY_Y;
		else 
			VaChamNen(odauhoi, cd);
	}
	else
		VaChamNen(odauhoi, cd);
}
void mario::OnCollisionWithGach(Gach* gach, CollisionDirection cd)
{
	if (cd == CollisionDirection::cd_none)
	{
		if (vx < 0)
		{
			SetXY(gach->x + 16, gach->y - 16 + currRect->Height);
			cd = CollisionDirection::cd_phai;
		}
		else
		{
			SetXY(gach->x - currRect->Width, gach->y - 16 + currRect->Height);
			cd = CollisionDirection::cd_trai;
		}
	}
		VaChamNen(gach, cd);
}
void mario::OnCollisionWithTurtle(Turtle* turtle, CollisionDirection cd)
{
	if (bienNhoLon || bienLonDuoi || starMan)
		return;
	switch (cd)
	{
	case cd_tren:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_damenemy);
		switch (turtle->currAction)
		{
		case TurtleAction::rua_bay: case TurtleAction::rua_di: case TurtleAction::rua_lan:
			vy = MARIO_VELOCITY_Y;
			break;
		case TurtleAction::rua_mai:
			if ((x + currRect->Width / 2) < (turtle->x + currRect->Width / 2))
			{
				effect = SpriteEffects::SE_right;
			}
			else
				if ((x + currRect->Width / 2) >= (turtle->x + currRect->Width / 2))
				{
					effect = SpriteEffects::SE_left;
				}
			marioAction = MarioAction::darua;
			_Tick_Darua = GetTickCount();
			break;
		}
		break;
	case cd_phai: case cd_trai:
			switch (turtle->currAction)
			{
			case TurtleAction::rua_bay: case TurtleAction::rua_di: case TurtleAction::rua_lan: //8.4.3
				if (marioType == MarioType::nho)
				{
					if (marioAction != MarioAction::darua && !isNhapNhay)
					{
						_Tick_Die = GetTickCount();
						marioAction = MarioAction::chet;
					}
				}
				if (marioType == MarioType::lon)
				{
					if (marioAction != MarioAction::darua && !isNhapNhay)
						ChangeSmallBig(MarioType::lon);
				}
				if (marioType == MarioType::duoi)
				{
					if (marioAction != MarioAction::darua)
						ChangeBigTail();
				}
				break;
			case TurtleAction::rua_mai: case TurtleAction::rua_rung: case TurtleAction::rua_hoisinh:
				if (marioAction != MarioAction::quayduoi && marioAction != MarioAction::nhayquayduoi)
				{
					if (input->IsKeyPress(DIK_C)) //8.4.3
							OmRua = true;
					else
					{
						marioAction = MarioAction::darua;
						_Tick_Darua = GetTickCount();
					}
				}
				break;
			}
		break;
	case cd_duoi:
		switch (turtle->currAction)
		{
		case TurtleAction::rua_bay: case TurtleAction::rua_di: case TurtleAction::rua_lan: //8.4.3
			if (marioType == MarioType::nho)
			{
				if (!isNhapNhay)
				{
					_Tick_Die = GetTickCount();
					marioAction = MarioAction::chet;
				}
			}
			if (marioType == MarioType::lon)
			{
				if (!isNhapNhay)
					ChangeSmallBig(MarioType::lon);
			}
			if (marioType == MarioType::duoi)
				ChangeBigTail();
			break;
		}
		break;
	}
}
void mario::OnCollisionWithNamEnemy(NamEnemy* namenemy, CollisionDirection cd)
{
	if (bienNhoLon || bienLonDuoi || starMan)
		return;
	switch (cd)
	{
	case cd_tren:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_damenemy);
		switch (namenemy->currAction)
		{
		case NamEnemyAction::nam_bay: case NamEnemyAction::nam_di:
			vy = MARIO_VELOCITY_Y;
			break;
		}
		break;
	case cd_phai: case cd_trai:
		switch (namenemy->currAction)
		{
		case NamEnemyAction::nam_bay: case NamEnemyAction::nam_di: //8.4.3
			if (marioType == MarioType::nho)
			{
				if (!isNhapNhay)
				{
					_Tick_Die = GetTickCount();
					marioAction = MarioAction::chet;
				}
			}
			if (marioType == MarioType::lon)
			{
				if (!isNhapNhay)
					ChangeSmallBig(MarioType::lon);
			}
			if (marioType == MarioType::duoi)
			{
				if (marioAction != MarioAction::quayduoi && marioAction != MarioAction::nhayquayduoi)
					ChangeBigTail();
			}
			break;
		}
		break;
	}
}
void mario::OnCollisionWithFireBullet()
{
	if (bienNhoLon || bienLonDuoi || isNhapNhay || starMan)
		return;
	if (marioType == MarioType::nho)
	{
		_Tick_Die = GetTickCount();
		marioAction = MarioAction::chet;
	}
	if (marioType == MarioType::lon)
		ChangeSmallBig(MarioType::lon);
	if (marioType == MarioType::duoi)
		ChangeBigTail();
}
void mario::OnCollisionWithRedFirePlant()
{
	if (bienNhoLon || bienLonDuoi || isNhapNhay || starMan)
		return;
	if (marioType == MarioType::nho)
	{
		_Tick_Die = GetTickCount();
		marioAction = MarioAction::chet;
	}
	if (marioType == MarioType::lon)
		ChangeSmallBig(MarioType::lon);
	if (marioType == MarioType::duoi)
	{
		if (mario1->marioAction != MarioAction::quayduoi && mario1->marioAction != MarioAction::nhayquayduoi)
			ChangeBigTail();
	}
}
void mario::OnCollisionWithChiecLa(ChiecLa* chiecla)
{
	if (bienNhoLon || bienLonDuoi)
		return;
	cGameInformation->SetScore(1000, chiecla->x, chiecla->y); // 8.5.3 -- Xóa trong ChiecLa.cpp
	if (marioType == MarioType::nho)
		ChangeSmallBig(MarioType::nho); // 8.5.
	else
	if (marioType == MarioType::lon)
		ChangeBigTail();
}
void mario::OnCollisionWithNamItem(NamItem* namitem)
{
	if (bienNhoLon)
		return;
	if (namitem->Loai == 3)
	{
		_Tick_Sao = GetTickCount();
		starMan = true;
	}
	if (namitem->Loai == 2)
	{
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_1up);
		cGameInformation->SetLive(1, namitem->x, namitem->y);
	}
	if (marioType == MarioType::nho) // 8.5.3
	{
		if (namitem->Loai == 1)
		{
			ChangeSmallBig(MarioType::nho);
			cGameInformation->SetScore(1000, namitem->x, namitem->y);
		}
	}
}
void mario::OnCollisionWithOngNuoc(OngNuoc* ongnuoc, CollisionDirection cd)
{
	VaChamNen(ongnuoc, cd);
	ongNuoc = ongnuoc;
	if (ongNuoc->down)
	{
		if (cd == CollisionDirection::cd_tren)
		{
			if (input->IsKeyDown(DIK_DOWN))
			{
				chuiOng = true;
				marioAction = MarioAction::chuiong;
			}
		}
	}
	else
	{
		if (Level == 2)
		{
			if (cd == CollisionDirection::cd_duoi)
			{
				if (input->IsKeyDown(DIK_UP))
				{
					chuiOng = true;
					marioAction = MarioAction::chuiong;
				}
			}
		}
		if (Level == 4)
		{
			if (cd == CollisionDirection::cd_phai)
			{
				chuiOng = true;
				marioAction = MarioAction::chuiong;
			}
		}
	}
}
void mario::Sound()
{
	if (starMan)
	{
		SoundManager::GetInst()->StopAllBGSound();
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_starman);
	}
	else
	{
		SoundManager::GetInst()->ResumeBGM();
		SoundManager::GetInst()->StopSoundEffect(SoundEffect::SE_starman);
	}
	//if (die == 1)
	//{
		//SoundManager::GetInst()->RemoveAllBGM();
		//SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chet);
	//}
	//if (cGameInformation->_Lives < 0)
	//{
	//	SoundManager::GetInst()->StopAllBGSound();
	//	SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_gameover);
	//}
	switch (marioAction)
	{
	case doihuong:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_doihuong);
		break;
	case nhay:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_nhay);
		break;
	case baylen:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chay);
		break;
	case darua:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_tancong);
		break;
	case quayduoi: case nhayquayduoi:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_quayduoi);
		break;
	case chuiong:
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chuiong);
		break;
	case chet:
		SoundManager::GetInst()->RemoveAllBGM();
		SoundManager::GetInst()->PlaySoundEffect(SoundEffect::SE_chet);
		break;
	}
}
void mario::OnCollisionWithBoxStair(CBoxStair* boxStair, CollisionDirection cd)
{
	marioAction = MarioAction::di;
	TrenDoc = true;
	d = boxStair->d;
	box = boxStair;
}
void mario::OnCollisionWithEndBox()
{ 
	stageClear = true;
}
mario* mario1 = new mario();