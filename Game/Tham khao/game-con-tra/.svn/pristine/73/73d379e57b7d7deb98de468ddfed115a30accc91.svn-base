#include <iostream> 
#include <fstream> 
#include <iostream> 
#include "CScoreScense.h"
#include "CInput.h"
#include "CStateGamePlay.h"
#include "CStateManagement.h"
#include "CDrawObject.h"
#include "CMenuGameScense.h"
#include "CLoadGameObject.h"
#include "CPoolingObject.h"
#include "CManageAudio.h"

CScoreScense::CScoreScense(bool isScenseGameOver)
{
	this->m_isScenseGameOver = isScenseGameOver;
	this->Init();
}

CScoreScense::CScoreScense(const std::vector<int>& info)
{
	if (!info.empty())
	{
		this->m_id = info.at(0) % 1000;
		this->m_idType = info.at(0) / 1000;
		this->m_pos = D3DXVECTOR2(info.at(1), info.at(2));
		this->m_width = info.at(3);
		this->m_height = info.at(4);
	}
	this->Init();//
}

void CScoreScense::Init()
{
	#pragma region KHOI TAO CHUNG 1
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 2;
	this->m_idType = 60;
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 512.0f;
	this->m_height = 448.0f;
	//Khoi tao cac thong so di chuyen
	this->m_left = false;
	//
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 2;
	this->m_column = 2;
	this->m_startFrame = 0;
	this->m_endFrame = 1;
	//
	this->m_timeDelay = 0.0f;
	this->m_isHided = false;
	//
	this->m_isPlaySoundGameOver = false;
	//
	this->lenghtlPWord = this->lenghtHIWord = 2;
	this->lenghtRestWord = 4;
	//
	string tempName = "LP";
	this->m_listLPWord = new CWordItem*[this->lenghtlPWord];
	for (int i = 0; i < this->lenghtlPWord; i++)
	{
		int tempNum = this->InitWord(tempName.at(i));
		if (tempNum != -1)
		{
			this->m_listLPWord[i] = new CWordItem(tempNum);
		}
	}
	//Tao moi rest
	tempName = "REST";
	this->m_listRestWord = new CWordItem*[this->lenghtRestWord];
	for (int i = 0; i < this->lenghtRestWord; i++)
	{
		int tempNum = this->InitWord(tempName.at(i));
		if (tempNum != -1)
		{
			this->m_listRestWord[i] = new CWordItem(tempNum);
		}
	}
	//Tao moi HI, hight score
	tempName = "HI";
	this->m_listHIWord = new CWordItem*[this->lenghtHIWord];
	for (int i = 0; i < this->lenghtHIWord; i++)
	{
		int tempNum = this->InitWord(tempName.at(i));
		if (tempNum != -1)
		{
			this->m_listHIWord[i] = new CWordItem(tempNum);
		}
	}
	#pragma endregion
	
	#pragma region KHOI TAO CHO GAME OVER
	//tao moi stage hoac game over
	if (this->m_isScenseGameOver)
	{
		//Khoi tao cac Lable
		tempName = "GAME OVER";
		this->lenghtStageWord = tempName.size();
		
		//tao moi lable Continue, End
		string tempContinue = "CONTINUE";
		this->lenghtContinueWord = tempContinue.size();
		this->m_listContinueWord = new CWordItem*[this->lenghtContinueWord];
		for (int i = 0; i < this->lenghtContinueWord; i++)
		{
			int tempNum = InitWord(tempContinue.at(i));
			if (tempNum != -1)
			{
				this->m_listContinueWord[i] = new CWordItem(tempNum);
			}
		}
		string tempEnd = "END";
		this->lenghtEndWord = tempEnd.size();
		this->m_listEndWord = new CWordItem*[this->lenghtEndWord];
		for (int i = 0; i < this->lenghtEndWord; i++)
		{
			int tempNum = InitWord(tempEnd.at(i));
			if (tempNum != -1)
			{
				this->m_listEndWord[i] = new CWordItem(tempNum);
			}
		}
		//Khoi tao doi tuong Choose Item
		this->m_itemChoose = new CChooseItem();
	}
	#pragma endregion
	
	#pragma region KHOI TAO CHO SCORE
	else
	{
		tempName = "STAGE";
		this->lenghtStageWord = 5;
	}
	#pragma endregion

	#pragma region KHOI TAO CHUNG 2
	this->m_listStageWord = new CWordItem*[this->lenghtStageWord];
	for (int i = 0; i < this->lenghtStageWord; i++)
	{
		int tempNum = InitWord(tempName.at(i));
		if (tempNum != -1)
		{
			this->m_listStageWord[i] = new CWordItem(tempNum);
		}
	}
	this->m_isReadFileHightScore = false;
	#pragma endregion

	//Sound
	//Dung sound background menu
	ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_MENU);
}

void CScoreScense::Update(float deltaTime)
{
	#pragma region Am thanh
	switch (CMenuGameScense::m_mapId)
	{
		case 10:
			//Dung sound background map 1
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_1);
			break;
		case 11: 
			//Dung sound background map 3
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_3);
			break;
		case 12: 
			//Dung sound background map 5
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_5);
			break;
		default:
			break;
	}
	#pragma endregion
	//
	#pragma region SU KIEN BAN PHIM
	if (this->m_isScenseGameOver)
	{
		//Sound
		if (!this->m_isPlaySoundGameOver)
		{
			ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_GAMEOVER);
			this->m_isPlaySoundGameOver = true;
		}
		//
		if (CInput::GetInstance()->IsKeyDown(DIK_RETURN))
		{
			if (this->m_itemChoose->m_SelectedId == 0)
			{
				CContra::GetInstance()->Reset();
				CPoolingObject::GetInstance()->Reset();
				CLoadGameObject::GetInstance()->Reset(CMenuGameScense::m_mapId);
				CLoadGameObject::GetInstance()->ChangeMap(CMenuGameScense::m_mapId);

				//Dung am thanh man hinh Game Over
				switch (CMenuGameScense::m_mapId)
				{
				case 10:
					//Dung sound background map 1
					ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_1);
					break;
				case 11:
					//Dung sound background map 3
					ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_3);
					break;
				case 12:
					//Dung sound background map 5
					ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_5);
					break;
				default:
					break;
				}
				ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_GAMEOVER);
				this->m_isPlaySoundGameOver = false;
			}
			else
			{
				ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_GAMEOVER);
				//Exit game
				std::exit(1);
			}
		}
		else
		if (CInput::GetInstance()->IsKeyDown(DIK_UP))
		{
			this->m_itemChoose->m_SelectedId--;
			if (this->m_itemChoose->m_SelectedId < 0)
			{
				this->m_itemChoose->m_SelectedId = 0;
			}

		}
		else
		if (CInput::GetInstance()->IsKeyDown(DIK_DOWN))
		{
			this->m_itemChoose->m_SelectedId++;
			if (this->m_itemChoose->m_SelectedId > 0)
			{
				this->m_itemChoose->m_SelectedId = 1;
			}
		}
	}
	#pragma endregion 

	#pragma region UPDATE CHO CAC CHU
	//Update cho chu nhap nhay
	if (this->m_timeDelay > 0.2f)
	{
		this->m_timeDelay = 0.0f;
		this->m_isHided = !this->m_isHided;
	}
	else
		this->m_timeDelay += deltaTime;
	#pragma endregion 
}

void CScoreScense::Move(float deltaTime)
{
	if (this->m_pos.x > this->m_width / 2)
	{
		this->m_pos.x -= 2;
	}
}

void CScoreScense::Draw()
{
	#pragma region VE NHUNG CAI CHUNG
	CDrawObject::GetInstance()->Draw(this);
	//La man hinh game over vs diemdeu hien len
	//hien thi chu LP len
	for (int i = 0; i < this->lenghtlPWord; i++)
	{
		this->m_listLPWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 200 + i * 16, this->m_pos.y + 160));
		CDrawObject::GetInstance()->Draw(this->m_listLPWord[i]);
	}
	//hien thi diem len(LP)
	if (this->m_isHided)
	{
		for (int i = 0; i < this->lenghtNumberScore; i++)
		{
			CDrawObject::GetInstance()->Draw(this->m_listNumberScore[i], D3DCOLOR_ARGB(255, 255, 255, 255));
		}
		//hien thi chu  noi dung HI len
		for (int i = 0; i < this->lenghtNumberHightScore; i++)
		{
			CDrawObject::GetInstance()->Draw(this->m_listHightScoreNumber[i], D3DCOLOR_ARGB(255, 255, 255, 255));
		}
	}
	//hien thi chu HI len
	for (int i = 0; i < this->lenghtHIWord; i++)
	{
		this->m_listHIWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 70 + i * 16, this->m_pos.y + 60));
		CDrawObject::GetInstance()->Draw(this->m_listHIWord[i]);
	}
	//Luon hien vi thay doi dc
	//hien thi chu STAGE len
	for (int i = 0; i < this->lenghtStageWord; i++)
	{
		this->m_listStageWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 40 + i * 16, this->m_pos.y - 40));
		CDrawObject::GetInstance()->Draw(this->m_listStageWord[i]);
	}
	#pragma endregion

	#pragma region VE CHO MAN HINH SCORE
	//
	//Man hinh diem moi hien con game over ko hien
	if (!this->m_isScenseGameOver)
	{
		//hien thi chu REST len
		for (int i = 0; i < this->lenghtRestWord; i++)
		{
			this->m_listRestWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 205 + i * 16, this->m_pos.y + 125));
			CDrawObject::GetInstance()->Draw(this->m_listRestWord[i]);
		}
		//hien thi chu noi dung REST len
		for (int i = 0; i < this->lenghtCountAliveNumber; i++)
		{
			CDrawObject::GetInstance()->Draw(this->m_listCountAliveNumber[i]);
		}
		//hien thi chu noi dung STAGE len
		for (int i = 0; i < this->lenghtStageNumber; i++)
		{
			CDrawObject::GetInstance()->Draw(this->m_listStageNumber[i]);
		}
		
		//hien thi ten man len
		for (int j = 0; j < this->lenghtWordStateName; j++)
		{
			CDrawObject::GetInstance()->Draw(this->m_listWordStageName[j]);
		}
	}
	#pragma endregion
	
	#pragma region VE CHO MAN HINH GAME OVER
	else//Man hinh game over ve them 2 lable 'CONTINUE', 'END'
	{
		//hien thi chu noi dung CONTINUE
		for (int i = 0; i < this->lenghtContinueWord; i++)
		{
			this->m_listContinueWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 10 + i * 16, this->m_pos.y - 90));
			CDrawObject::GetInstance()->Draw(this->m_listContinueWord[i]);
		}

		//hien thi END len
		for (int j = 0; j < this->lenghtEndWord; j++)
		{
			this->m_listEndWord[j]->SetPos(D3DXVECTOR2(this->m_pos.x - 10 + j * 16, this->m_pos.y - 120));
			CDrawObject::GetInstance()->Draw(this->m_listEndWord[j]);
		}

		//
		D3DXVECTOR2 pos;
		if (this->m_itemChoose->m_SelectedId == 0)
			pos = D3DXVECTOR2(this->m_listContinueWord[0]->GetPos().x - 35, this->m_listContinueWord[0]->GetPos().y);
		else
			pos = D3DXVECTOR2(this->m_listEndWord[0]->GetPos().x - 35, this->m_listEndWord[0]->GetPos().y);
		this->m_itemChoose->SetPos(pos);
		CDrawObject::GetInstance()->Draw(this->m_itemChoose);
	}
	#pragma endregion
}

void CScoreScense::InitScore(int score)
{
	this->m_ScoreMap = score;
	//Tinh toan ra so diem va so word
	stringstream ss;
	ss << this->m_ScoreMap;
	string tempScore = ss.str();
	//
	this->lenghtNumberScore = tempScore.size();
	//Khoi tao cac doi tuong chu so
	this->m_listNumberScore = new CWordItem*[tempScore.size()];
	
	string temp;
	for (int i = 0; i < tempScore.size(); i++)
	{
		temp = tempScore.at(i);
		this->m_listNumberScore[i] = new CWordItem(atoi(temp.c_str()));
		this->m_listNumberScore[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 100 + i * 16, this->m_pos.y + 160));
	}
}

void CScoreScense::InitNameStage(int mapId)
{
	string tempName;
	switch (mapId)
	{
	case 10:
		tempName = __NAME_MAP_1__;
		break;
	case 11:
		tempName = __NAME_MAP_3__;
		break;
	case 12:
		tempName = __NAME_MAP_5__;
		break;
	}
	this->lenghtWordStateName = tempName.size();
	this->m_listWordStageName = new CWordItem*[tempName.size()];
	for (int i = 0; i < tempName.size(); i++)
	{
		int tempNum = InitWord(tempName.at(i));
		if (tempNum != -1)
		{
			this->m_listWordStageName[i] = new CWordItem(tempNum);
			this->m_listWordStageName[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 55 + i * 16, this->m_pos.y - 80));
		}
	}
}

void CScoreScense::InitHightScore(int hightScore)
{
	#pragma region DOC/GHI FILE HIGHT SCORE
	//Kiem tra neu nhu hightScore truyen vao ma nho hon hight score trogn file
	//thi hight score la trogn file nguoc lai ghi hight score moi xuong file
	if (!this->m_isReadFileHightScore)
	{
		this->m_hightScore = hightScore;
		//
		int hightScoreFile = 0;
		//Doc file HightScore len
		ifstream readFileHightScore(__HightScore_Path__);
		if (readFileHightScore.is_open())
		{
			readFileHightScore >> hightScoreFile;
		}
		//Doc xong file
		if (hightScore > hightScoreFile)
		{
			hightScoreFile = hightScore;
			//Ghi file xuong HighScore
			ofstream writeFileHightScore(__HightScore_Path__);
			writeFileHightScore << hightScoreFile;
			writeFileHightScore.close();
			//Ghi xong file
		}
		else
		{
			this->m_hightScore = hightScoreFile;
		}

		this->m_isReadFileHightScore = true;
	}
	#pragma endregion

	#pragma region Tinh toan ra hight Score(string) va so word
	stringstream ss;
	ss << this->m_hightScore;
	string tempHightScore = ss.str();
	//
	this->lenghtNumberHightScore = tempHightScore.size();
	//Khoi tao cac doi tuong chu so
	this->m_listHightScoreNumber = new CWordItem*[tempHightScore.size()];

	string temp;
	for (int i = 0; i < tempHightScore.size(); i++)
	{
		temp = tempHightScore.at(i);
		this->m_listHightScoreNumber[i] = new CWordItem(atoi(temp.c_str()));
		this->m_listHightScoreNumber[i]->SetPos(D3DXVECTOR2(this->m_pos.x + 20 + i * 16, this->m_pos.y + 60));
	}
	#pragma endregion
}

void CScoreScense::InitCountAlive(int countAlive)
{
	//Tinh toan ra so mang va so word
	stringstream ss;
	ss << countAlive;
	string tempCountAlive = ss.str();
	//
	this->lenghtCountAliveNumber = tempCountAlive.size();
	//Khoi tao cac doi tuong chu so
	this->m_listCountAliveNumber = new CWordItem*[tempCountAlive.size()];

	string temp;
	for (int i = 0; i < tempCountAlive.size(); i++)
	{
		temp = tempCountAlive.at(i);
		this->m_listCountAliveNumber[i] = new CWordItem(atoi(temp.c_str()));
		this->m_listCountAliveNumber[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 100 + i * 16, this->m_pos.y + 125));
	}
}

void CScoreScense::InitStageNumber(int stageNumberCurrent)
{
	switch (stageNumberCurrent)
	{
		case 10:
			stageNumberCurrent = 1;
			break;
		case 11:
			stageNumberCurrent = 3;
			break;
		case 12:
			stageNumberCurrent = 5;
			break;
	}
	//Tinh toan ra man hien tai va so word
	stringstream ss;
	ss << stageNumberCurrent;
	string tempStageNumber = ss.str();
	//
	this->lenghtStageNumber = tempStageNumber.size();
	//Khoi tao cac doi tuong chu so
	this->m_listStageNumber = new CWordItem*[tempStageNumber.size()];

	string temp;
	for (int i = 0; i < tempStageNumber.size(); i++)
	{
		temp = tempStageNumber.at(i);
		this->m_listStageNumber[i] = new CWordItem(atoi(temp.c_str()));
		this->m_listStageNumber[i]->SetPos(D3DXVECTOR2(this->m_pos.x + 60 + i * 16, this->m_pos.y - 40));
	}
}

RECT* CScoreScense::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}
