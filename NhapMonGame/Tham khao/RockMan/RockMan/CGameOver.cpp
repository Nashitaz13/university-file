#include "CGameOver.h"

CGameOver::CGameOver(int score) :CScreen()
{
	_score = score;
	string stringScore = std::to_string(_score);
	string stringZero = GetStringZero(stringScore.length());

	_textGameOver = new CTextblock();
	_textGameOver->_position = Vector2(0, SCREEN_HEIGHT);//1.4
	_textGameOver->_size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT / 4);
	_textGameOver->_text = "GAME OVER";
	_textGameOver->_color = D3DCOLOR_XRGB(255, 255, 255);
	_textGameOver->_horizontalAlignment = Alignment::CENTER;
	_textGameOver->_verticalAlignment = Alignment::BOTTOM;
	_textGameOver->Initlize();

	_textScore = new CTextblock();
	_textScore->_position = Vector2(0, SCREEN_HEIGHT - _textGameOver->_size.y - 40);
	_textScore->_size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_textScore->_text = stringZero + stringScore;
	_textScore->_color = D3DCOLOR_XRGB(255, 255, 255);
	_textScore->_horizontalAlignment = Alignment::CENTER;
	_textScore->_verticalAlignment = Alignment::TOP;
	_textScore->Initlize();

	_textContinue = new CTextblock();
	_textContinue->_position = Vector2(0, SCREEN_HEIGHT / 2);
	_textContinue->_size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_textContinue->_text = "CONTINUE";
	_textContinue->_color = D3DCOLOR_XRGB(255, 255, 255);
	_textContinue->_horizontalAlignment = Alignment::CENTER;
	_textContinue->_verticalAlignment = Alignment::TOP;
	_textContinue->Initlize();

	_textStageSelect = new CTextblock();
	_textStageSelect->_position = Vector2(0, _textContinue->_position.y - 40);
	_textStageSelect->_size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_textStageSelect->_text = "STAGE SELECT";
	_textStageSelect->_color = D3DCOLOR_XRGB(255, 255, 255);
	_textStageSelect->_horizontalAlignment = Alignment::CENTER;
	_textStageSelect->_verticalAlignment = Alignment::TOP;
	_textStageSelect->Initlize();

	_background = new CImage();
	_background->_position = Vector2(0, SCREEN_HEIGHT);
	_background->_size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_background->_source = L"Resources//sprites//background_3.png";
	_background->_transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_background->Initlize();

	_arrow = new CImage();
	_arrow->_position = Vector2(SCREEN_WIDTH / 3 - 40, _textContinue->_position.y);
	_arrow->_source = L"Resources//sprites//arrow.png";
	_arrow->_transparentColor = D3DCOLOR_XRGB(24, 93, 214);
	_arrow->Initlize();
	_statusKey = 1;
	_typeID = ID_SCREEN_GAME_OVER;
}

void CGameOver::UpdateInput(CInput* input)
{
	if (input->IsKeyDown(DIK_SPACE))
	{
		if (_statusKey == 0)
		{
			_arrow->_position = Vector2(_arrow->_position.x, _textContinue->_position.y);
			_statusKey = 1;
		}
		else
		{
			_arrow->_position = Vector2(_arrow->_position.x, _textStageSelect->_position.y);
			_statusKey = 0;
		}
	}

	if (input->IsKeyDown(DIK_RETURN))
	{
		if (_statusKey == 1)
		{
			_isFinished = true;
			_nextScreen = new CPlayScreen();
		}
		else{
			_isFinished = true;
			CGameInfo::GetInstance()->SetBonusValue(0);
			
			_nextScreen = new CGameMenu();
		}
	}
}
CGameOver::~CGameOver()
{
	SAFE_DELETE(_textGameOver);
}
void CGameOver::Update(CGameTime* gameTime)
{
	_arrow->Update(gameTime);
}

void CGameOver::Render(CGameTime* gameTime, CGraphics* graphics)
{
	_background->Render(gameTime, graphics);
	_arrow->Render(gameTime, graphics);
	_textGameOver->Render(gameTime, graphics);
	_textScore->Render(gameTime, graphics);
	_textContinue->Render(gameTime, graphics);
	_textStageSelect->Render(gameTime, graphics);
}
string CGameOver::GetStringZero(int countScore)
{
	string temp = "";
	for (size_t i = 0; i < 7 - countScore; i++)
	{
		temp += "0";
	}
	return temp;
}
void CGameOver::SetScore(int score)
{
	_score = score;
	string stringScore = std::to_string(_score);
	string stringZero = GetStringZero(stringScore.length());
	_textScore->_text = stringZero + stringScore;
}