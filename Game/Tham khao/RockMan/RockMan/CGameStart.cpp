 #include "CGameStart.h"

CGameStart::CGameStart() :CScreen(){

	_timeFrame = 100;
	_isNextFrame = 0;

	_txtPressStart._position = Vector2(0, SCREEN_HEIGHT/3);
	_txtPressStart._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT/3);
	_txtPressStart._text = "PRESS START";
	_txtPressStart._verticalAlignment = Alignment::CENTER;
	_txtPressStart._horizontalAlignment = Alignment::CENTER;
	_txtPressStart._color = D3DCOLOR_XRGB(255, 255, 255);
	_txtPressStart.SetAnimation(600, AnimationMode::FOREVER);
	_txtPressStart.Initlize();

	_txtCopyright._position = Vector2(0, SCREEN_HEIGHT / 6);
	_txtCopyright._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT / 6);
	_txtCopyright._text = " © HTUV 2015";
	_txtCopyright._verticalAlignment = Alignment::CENTER;
	_txtCopyright._horizontalAlignment = Alignment::CENTER;
	_txtCopyright._color = D3DCOLOR_XRGB(255, 255, 255);
	_txtCopyright.Initlize();

	_txtTM._position = Vector2( 7 * SCREEN_WIDTH/9, 6*SCREEN_HEIGHT / 8);
	_txtTM._size = Vector2(SCREEN_WIDTH/9, SCREEN_HEIGHT / 8);
	_txtTM._text = "TM";
	_txtTM._verticalAlignment = Alignment::BOTTOM;
	_txtTM._horizontalAlignment = Alignment::CENTER;
	_txtTM._color = D3DCOLOR_XRGB(255, 255, 255);
	_txtTM.Initlize();

	_imgBackground._position = Vector2(0, SCREEN_HEIGHT);
	_imgBackground._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_imgBackground._source = SPRITE_BACKGROUND_3;
	_imgBackground._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgBackground.Initlize();

	_imgTitleGame._position = Vector2(SCREEN_WIDTH/9, 5*SCREEN_HEIGHT / 6);
	_imgTitleGame._source = SPRITE_GAME_TITLE_1;
	_imgTitleGame._transparentColor = D3DCOLOR_XRGB(0, 255, 0);
	_imgTitleGame.Initlize();

	_imgRockman._position = Vector2(1 * SCREEN_WIDTH / 3, 4 * SCREEN_HEIGHT / 7);
	_imgRockman._source = SPRITE_ICON_ROCK_MAN;
	_imgRockman._transparentColor = D3DCOLOR_XRGB(0, 255, 0);
	_imgRockman.Initlize();

	_imgRockmanGray._position = Vector2(1 * SCREEN_WIDTH / 3, 4 * SCREEN_HEIGHT / 7);
	_imgRockmanGray._source = SPRITE_ICON_ROCK_MAN_GRAY;
	_imgRockmanGray._transparentColor = D3DCOLOR_XRGB(0, 255, 0);
	_imgRockmanGray.Initlize();

	_imgLine1._position = Vector2(0, 3 * (SCREEN_HEIGHT / 7));
	_imgLine1._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine1._source = SPRITE_BACKGROUND_4;
	_imgLine1._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine1.Initlize();

	_imgLine2._position = Vector2(0, 3 * (SCREEN_HEIGHT / 7) - (SCREEN_HEIGHT / 30));
	_imgLine2._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine2._source = SPRITE_BACKGROUND_2;
	_imgLine2._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine2.Initlize();

	_imgLine3._position = Vector2(2 * SCREEN_WIDTH / 3, 3 * (SCREEN_HEIGHT / 7));
	_imgLine3._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine3._source = SPRITE_BACKGROUND_4;
	_imgLine3._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine3.Initlize();

	_imgLine4._position = Vector2(2 * SCREEN_WIDTH / 3, 3 * (SCREEN_HEIGHT / 7) - (SCREEN_HEIGHT / 30));
	_imgLine4._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine4._source = SPRITE_BACKGROUND_2;
	_imgLine4._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine4.Initlize();

	_imgLine1_1._position = Vector2(0, 3 * (SCREEN_HEIGHT / 7));
	_imgLine1_1._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine1_1._source = SPRITE_BACKGROUND_4_1;
	_imgLine1_1._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine1_1.Initlize();

	_imgLine2_1._position = Vector2(0, 3 * (SCREEN_HEIGHT / 7) - (SCREEN_HEIGHT / 30));
	_imgLine2_1._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine2_1._source = SPRITE_BACKGROUND_2_1;
	_imgLine2_1._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine2_1.Initlize();

	_imgLine3_1._position = Vector2(2 * SCREEN_WIDTH / 3, 3 * (SCREEN_HEIGHT / 7));
	_imgLine3_1._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine3_1._source = SPRITE_BACKGROUND_4_1;
	_imgLine3_1._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine3_1.Initlize();

	_imgLine4_1._position = Vector2(2 * SCREEN_WIDTH / 3, 3 * (SCREEN_HEIGHT / 7) - (SCREEN_HEIGHT / 30));
	_imgLine4_1._size = Vector2(SCREEN_WIDTH / 3, SCREEN_HEIGHT / 30);
	_imgLine4_1._source = SPRITE_BACKGROUND_2_1;
	_imgLine4_1._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_imgLine4_1.Initlize();

	_typeID = ID_SCREEN_GAME_START;
}

CGameStart::~CGameStart(){

}

void CGameStart::UpdateInput(CInput* input)
{
	if (input->IsKeyUp(DIK_RETURN)&& _isNextFrame==0)
	{
		_isNextFrame++;
		ResourceManager::PlayASound(ID_SOUND_GAME_START);
	}
}

void CGameStart::Update(CGameTime* gameTime)
{
	if (_isNextFrame>0)
	{
		_tick += gameTime->GetDeltaTime(); 
		if (_tick >= _timeFrame)
		{
			_tick = 0;
			_isNextFrame++;
		}
		
		//Tự động nháy animation 5 lần rồi chuyển màn hình GameMenu
		if (_isNextFrame >= 10)
		{
			_nextScreen = new CGameMenu();
			_isFinished = true;
		}
	}
}

void CGameStart::Render(CGameTime* gameTime, CGraphics* graphics)
{
	_imgBackground.Render(gameTime, graphics);
	_imgTitleGame.Render(gameTime, graphics);
	_txtCopyright.Render(gameTime, graphics);
	_txtTM.Render(gameTime, graphics);

	if (_isNextFrame>0)
	{//Bắt đầu vẽ animation
		_txtPressStart.StopAnimation();//Dừng animation của chữ PressStart
		if (_isNextFrame%2==0)//Vẽ màu xám
		{
			_imgLine1_1.Render(gameTime, graphics);
			_imgLine2_1.Render(gameTime, graphics);
			_imgLine3_1.Render(gameTime, graphics);
			_imgLine4_1.Render(gameTime, graphics);
			_imgRockmanGray.Render(gameTime, graphics);
		}
		else//Vẽ màu xanh
		{
			_imgLine1.Render(gameTime, graphics);
			_imgLine2.Render(gameTime, graphics);
			_imgLine3.Render(gameTime, graphics);
			_imgLine4.Render(gameTime, graphics);
			_imgRockman.Render(gameTime, graphics);
		}
	}
	else
	{
		_imgLine1.Render(gameTime, graphics);
		_imgLine2.Render(gameTime, graphics);
		_imgLine3.Render(gameTime, graphics);
		_imgLine4.Render(gameTime, graphics);
		_imgRockman.Render(gameTime, graphics);
	}
	_txtPressStart.Render(gameTime, graphics);

}