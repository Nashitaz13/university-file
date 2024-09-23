#include "CWinScense.h"
#include "CInput.h"
#include "CCamera.h"
#include "CStateGamePlay.h"
#include "CStateManagement.h"
#include "CLoadGameObject.h"
#include "CDrawObject.h"

CWinScense::CWinScense()
{
	this->Init();
}

CWinScense::CWinScense(string message)
{
	this->m_Message = message;
	this->Init();
}
CWinScense::CWinScense(string title, string message)
{
	this->m_title = title;
	this->m_Message = message;
	this->Init();
}

CWinScense::CWinScense(const std::vector<int>& info)
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

void CWinScense::Init()
{
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
	D3DXVECTOR3 cameraPos = CCamera::GetInstance()->GetCameraPos();
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 1.3f;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.40f;
	this->m_increase = 1;
	this->m_totalFrame = 1;
	this->m_column = 1;
	this->m_startFrame = 0;
	this->m_endFrame = 0;
	//
	this->m_timeDelay = 0.0f;
	//
	this->lenghtTitleWord = this->m_title.size();
	//Khoi tao cho tieu de man hinh
	this->m_listTitleWord = new CWordItem*[this->lenghtTitleWord];
	for (int i = 0; i < this->lenghtTitleWord; i++)
	{
		int tempNum = this->InitWord(this->m_title.at(i));
		if (tempNum != -1)
		{
			this->m_listTitleWord[i] = new CWordItem(tempNum);
		}
	}
	//Khoi tao cho noi hien thi
	this->lenghtMessageWord = this->m_Message.size();
	//
	this->m_listMessageWord = new CWordItem*[this->lenghtMessageWord];
	for (int i = 0; i < this->lenghtMessageWord; i++)
	{
		int tempNum = this->InitWord(this->m_Message.at(i));
		if (tempNum != -1)
		{
			this->m_listMessageWord[i] = new CWordItem(tempNum);
		}
	}
	//
	this->m_isHided = false;
}

void CWinScense::Update(float deltaTime)
{
	//Update an hien noi dun
	if (this->m_timeDelay > 0.30f)
	{
		this->m_timeDelay = 0.0f;
		this->m_isHided = !this->m_isHided;
	}
	else
		this->m_timeDelay += deltaTime;

	//Update su kien ban phim
	if (CInput::GetInstance()->IsKeyDown(DIK_RETURN))
	{
		//Exit game
		std::exit(1);
	}
}

void CWinScense::Move(float deltaTime)
{

}

void CWinScense::Draw()
{
	CDrawObject::GetInstance()->Draw(this);
	if (this->m_isHided)
	{
		//hien thi noi dung tieu de
		if (this->lenghtTitleWord != 0)
		{
			for (int i = 0; i < this->lenghtTitleWord; i++)
			{
				this->m_listTitleWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 80 + i * 16, this->m_pos.y + 65));
				CDrawObject::GetInstance()->Draw(this->m_listTitleWord[i], D3DCOLOR_ARGB(127, 255, 255, 255));
			}
		}
		//hien thi noi dung message
		if (this->lenghtMessageWord != 0)
		{
			for (int i = 0; i < this->lenghtMessageWord; i++)
			{
				this->m_listMessageWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 100 + i * 16, this->m_pos.y));
				CDrawObject::GetInstance()->Draw(this->m_listMessageWord[i], D3DCOLOR_ARGB(255, 255, 255, 255));
			}
		}
	}
	else
	{
		//hien thi noi dung tieu de
		if (this->lenghtTitleWord != 0)
		{
			for (int i = 0; i < this->lenghtTitleWord; i++)
			{
				this->m_listTitleWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 80 + i * 16, this->m_pos.y + 65));
				CDrawObject::GetInstance()->Draw(this->m_listTitleWord[i], D3DCOLOR_ARGB(255, 255, 255, 255));
			}
		}
		//hien thi noi dung message
		if (this->lenghtMessageWord != 0)
		{
			for (int i = 0; i < this->lenghtMessageWord; i++)
			{
				this->m_listMessageWord[i]->SetPos(D3DXVECTOR2(this->m_pos.x - 100 + i * 16, this->m_pos.y));
				CDrawObject::GetInstance()->Draw(this->m_listMessageWord[i], D3DCOLOR_ARGB(127, 255, 255, 255));
			}
		}
	}
}

RECT* CWinScense::GetRectRS()
{
	return this->UpdateRectResource(this->m_height, this->m_width);
}