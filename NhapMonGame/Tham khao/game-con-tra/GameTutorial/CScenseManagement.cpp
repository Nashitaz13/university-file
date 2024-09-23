#include "CScenseManagement.h"	
#include <iostream>
#include "CDrawObject.h"
#include "CContra.h"
#include "CCamera.h"
#include "CPoolingObject.h"
#include "CLoadBackGround.h"
#include "CLoadGameObject.h"

bool CScenseManagement::m_isGameWinner = false;
bool CScenseManagement::m_isGameOverred = false;
bool CScenseManagement::m_isWinScenseShowed = false;

CScenseManagement::CScenseManagement()
{
}

CScenseManagement::CScenseManagement(int mapId)
{
	this->m_mapId = mapId;
}

CScenseManagement::~CScenseManagement()
{

}

void CScenseManagement::Init()
{
	//Tinh--> gameover item
	this->m_gameOverItem = new CGameOverItem();
	//Tinh --> man hinh game over = true
	this->m_scoreGameOver = new CScoreScense(true);
	//Tinh--> neu boss map hien tai chet vs contra con song thi goi man hinh diem = false
	this->m_scoreWin = new CScoreScense(false);
	//
	this->m_thankScense = new CWinScense(_STRING_GAME_OVER_, _STRING_THANKS_PLAY);
	//
	this->m_timeDelay = 0.80f;
	this->m_timeDelayLoadMapNew = 1.50f;
	this->m_isLoadScenseGameComplete = false;
}

void CScenseManagement::Update(float deltaTime)
{
#pragma region UPDATE MAN HINH SCORE CHO GAME OVER
	if (CContra::GetInstance()->m_isGameOver)
	{
		//Sau do cho 1 thoi gian roi update man hinh diem do het mang - t = 0.8s
		if (this->m_gameOverItem->m_timeDelay <= 0 && !this->m_isGameOverred)
		{
			this->m_gameOverItem->m_timeDelay = 0.80f;
			//Load man hinh diem so len
			this->m_isGameOverred = true;
		}
		else
			this->m_gameOverItem->m_timeDelay -= deltaTime;
		//Update cho man hinh Game over
		if (this->m_isGameOverred)
		{
			this->m_scoreGameOver->Update(deltaTime);
		}
	}
#pragma endregion

#pragma region UPDATE CHO MAN HINH WIN MAP
	//Update cho man hinh Win map
	if (CContra::GetInstance()->m_countAlive != 0 && this->m_isWinScenseShowed)//CContra::GetInstance()->m_isBossCurrentDie)
	{
		this->m_scoreWin->Update(deltaTime);
		//Cho 1 thoi gian moi cho thang nay chay
		if (this->m_timeDelayLoadMapNew <= 0)
		{
			this->m_timeDelayLoadMapNew = 1.50f;
			if (this->m_isGameWinner)
			{
				this->m_isLoadScenseGameComplete = true;
			}
			else
			{
				if (CMenuGameScense::m_mapId > 12)
					CMenuGameScense::m_mapId = 10;
				CContra::GetInstance()->Reset();
				CPoolingObject::GetInstance()->Reset();
				CLoadGameObject::GetInstance()->Reset(CMenuGameScense::m_mapId);
				CLoadGameObject::GetInstance()->ChangeMap(CMenuGameScense::m_mapId);
				CLoadBackGround::GetInstance()->ChangeBackGround(CMenuGameScense::m_mapId);
				CContra::GetInstance()->m_isBossCurrentDie = false;
			}
		}
		else
			this->m_timeDelayLoadMapNew -= deltaTime;
	}
#pragma endregion

#pragma region UPDATE CHO MAN HINH THANKS PLAYING
	if (this->m_isLoadScenseGameComplete)
	{
		this->m_thankScense->Update(deltaTime);
	}
#pragma endregion
}

void CScenseManagement::Render()
{
	if (CContra::GetInstance()->m_isGameOver)//Tinh test 14/1
	{
		//Game Over
		if (this->m_isGameOverred)
		{
			#pragma region VE MAN HINH DIEM CHO GAME OVER
			D3DXVECTOR3 cameraPos = CCamera::GetInstance()->GetCameraPos();
			this->m_scoreGameOver->SetPos(D3DXVECTOR2(cameraPos.x + this->m_scoreGameOver->GetWidth() / 2, cameraPos.y - this->m_scoreGameOver->GetHeight() / 2));
			//
			this->m_scoreGameOver->InitScore(CContra::GetInstance()->GetScoreGame());
			this->m_scoreGameOver->InitHightScore(CContra::GetInstance()->GetScoreGame());//doc len tu file
			if (!this->m_scoreGameOver->IsScenseGameOver())//neu la man hinh diem thi hien thi
			{
				this->m_scoreGameOver->InitNameStage(CMenuGameScense::m_mapId);
				this->m_scoreGameOver->InitCountAlive(CContra::GetInstance()->m_countAlive);
				this->m_scoreGameOver->InitStageNumber(CMenuGameScense::m_mapId);
			}
			this->m_scoreGameOver->Draw();
		#pragma endregion
		}
		else
		{
			//Tinh-> ve game over item neu chua cho ve man hinh diem
			this->m_gameOverItem->Draw();
		}
	}

#pragma region VE MAN HINH WIN MAP
	//Update cho man hinh Win map
	if (CContra::GetInstance()->m_countAlive != 0 && this->m_isWinScenseShowed)//CContra::GetInstance()->m_isBossCurrentDie)
	{
		///Ve man hinh diem sau khi thang mancc
		D3DXVECTOR3 cameraPos = CCamera::GetInstance()->GetCameraPos();
		this->m_scoreWin->SetPos(D3DXVECTOR2(cameraPos.x + this->m_scoreGameOver->GetWidth() / 2, cameraPos.y - this->m_scoreGameOver->GetHeight() / 2));
		//
		this->m_scoreWin->InitScore(CContra::GetInstance()->GetScoreGame());
		this->m_scoreWin->InitHightScore(CContra::GetInstance()->GetScoreGame());//doc len tu file
		if (!this->m_scoreWin->IsScenseGameOver())//neu la man hinh diem thi hien thi
		{
			this->m_scoreWin->InitNameStage(CMenuGameScense::m_mapId);
			this->m_scoreWin->InitCountAlive(CContra::GetInstance()->m_countAlive);
			this->m_scoreWin->InitStageNumber(CMenuGameScense::m_mapId);
		}
		this->m_scoreWin->Draw();
	}
#pragma endregion

#pragma region VE MAN HINH THANKS PLAYING
	if (this->m_isLoadScenseGameComplete)
	{
		if (this->m_isWinScenseShowed)
		{
			D3DXVECTOR3 cameraPos = CCamera::GetInstance()->GetCameraPos();
			this->m_thankScense->SetPos(D3DXVECTOR2(cameraPos.x + this->m_scoreGameOver->GetWidth() / 2, cameraPos.y - this->m_scoreGameOver->GetHeight() / 2));

			this->m_thankScense->Draw();
			//
			this->m_isWinScenseShowed = true;
		}
	}
#pragma endregion
}

void CScenseManagement::Destroy()
{
}