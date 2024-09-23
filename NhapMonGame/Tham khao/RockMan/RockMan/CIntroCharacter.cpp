 #include "CIntroCharacter.h"

CIntroCharacter::CIntroCharacter(CSprite spriteBoss, STAGE stage, int maxScore) :CScreen(){

	_timeFrame = 130;
	_isRunAnimation = 0;
	_timeBossStand = 1000;
	_numOfScoreAnimation = maxScore;
	_currentIndexScoreAnimation = 0;
	_isBossStand = false;
	_tick = 0;
	_state = INTRO_STAGE_STATE::RUNNING_ANIMATION;
	_spriteBoss = spriteBoss;

	while (_numOfScoreAnimation > 20)
	{
		_numOfScoreAnimation = _numOfScoreAnimation / 10;
		_strAddScoreAnimation += "0";
	}
	_strLine1 = "CUTMAN";
	_posBoss = Vector2(SCREEN_WIDTH / 2 - 30, (SCREEN_HEIGHT / 2) + 60);
	_vBoss = Vector2(0, 130.0f / 1000.0f);
	_spriteBoss.SetIndex(0);
	if (stage == STAGE::BOMBMAN)
	{
		_posBoss = Vector2(2 * SCREEN_WIDTH / 3+10, 1 * SCREEN_HEIGHT / 5);
		_strLine1 = "BOMBMAN";
		_vBoss = Vector2(-60.0f/1000.0f, 200.0f / 1000.0f);
	}
	else
		if (stage == STAGE::GUTSMAN)
		{
			_posBoss = Vector2(2 * SCREEN_WIDTH / 3, 3*SCREEN_HEIGHT/4);
			_strLine1 = "GUTSMAN";
			_spriteBoss.SetIndex(1);
			_vBoss = Vector2(-70.0f / 1000.0f, 60.0f / 1000.0f);
		}

	_strLine2 = "CLEAR POINTS";
	_maxScore = maxScore;

	_imgLine1._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT / 3.7f);
	_imgLine1._position = Vector2(0, 1 * (SCREEN_HEIGHT / 2) + _imgLine1._size.y / 2);
	_imgLine1._source = SPRITE_BACKGROUND_5;
	_imgLine1._transparentColor = D3DCOLOR_XRGB(0, 0, 0);
	_imgLine1.Initlize();

	_txtLine1._position = Vector2(SCREEN_WIDTH / 2 + 5, _imgLine1._position.y - _imgLine1._size.y/5.7);
	_txtLine1._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT/3);
	_txtLine1._text = "";
	_txtLine1._color = D3DCOLOR_XRGB(255, 255, 255);
	_txtLine1.Initlize();

	_txtLine2._position = Vector2(SCREEN_WIDTH / 2 + 5, _txtLine1._position.y - 14);
	_txtLine2._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT / 3);
	_txtLine2._text = "";
	_txtLine2._color = D3DCOLOR_XRGB(255, 255, 255);
	_txtLine2.Initlize();

	_txtScore._position = Vector2(SCREEN_WIDTH / 2 + 5, _txtLine2._position.y - 14);
	_txtScore._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT /3);
	_txtScore._text = "";
	_txtScore._color = D3DCOLOR_XRGB(255, 255, 255);
	_txtScore.Initlize();

	_imgBackground._position = Vector2(0, SCREEN_HEIGHT);
	_imgBackground._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_imgBackground._source = SPRITE_BACKGROUND_5;
	_imgBackground._transparentColor = D3DCOLOR_XRGB(0, 0, 0);
	_imgBackground.Initlize();

	_typeID = ID_SCREEN_GAME_START;
}

CIntroCharacter::~CIntroCharacter(){

}

void CIntroCharacter::UpdateInput(CInput* input)
{
}

void CIntroCharacter::Update(CGameTime* gameTime)
{
	if (_isRunAnimation == 0)
		ResourceManager::PlayASound(ID_EFFECT_INTRO_STAGE); 
	
	_spriteBoss.Update(gameTime);
	if (_state==INTRO_STAGE_STATE::RUNNING_ANIMATION)//Nháy Animation hình nền và show Boss
	{
		#pragma region Vẽ Animation của Background
		if (_isRunAnimation < 11)// Vẽ 5 lần chớp background
		{
			_tick += gameTime->GetDeltaTime();
			if (_tick >= _timeFrame)
			{
				_tick = 0;
				_isRunAnimation++;
				if (_imgBackground._source == SPRITE_BACKGROUND_5)
				{
					_imgBackground._source = SPRITE_BACKGROUND_2;
					_imgBackground._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
					_imgBackground.Initlize();
					_imgLine1._source = SPRITE_BACKGROUND_1;
					_imgLine1._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
					_imgLine1.Initlize();
				}
				else
				{
					_imgBackground._source = SPRITE_BACKGROUND_5;
					_imgBackground._transparentColor = D3DCOLOR_XRGB(0, 0, 0);
					_imgBackground.Initlize();
					_imgLine1._source = SPRITE_BACKGROUND_5;
					_imgLine1._transparentColor = D3DCOLOR_XRGB(0, 0, 0);
					_imgLine1.Initlize();
				}
			}
		}
		else
		{
		}
		#pragma endregion	

		#pragma region Vùng vẽ Animation của Enemy Boss

		if (_strLine1 == "CUTMAN")
		{
			this->RunAnimationBossCutMan(gameTime->GetDeltaTime());
		}
		else
			if (_strLine1 == "GUTSMAN")
			{
				this->RunAnimationBossGutsMan(gameTime->GetDeltaTime());
			}
			else
			{
				this->RunAnimationBossBombMan(gameTime->GetDeltaTime());
			}
		#pragma endregion
	}
	else
		if (_state == INTRO_STAGE_STATE::RUNNING_TEXT)
		{
			_tick += gameTime->GetDeltaTime();
			if (_tick >= _timeFrame)
			{
				_tick = 0;
				if (_txtLine1._text.length() < _strLine1.length())
					_txtLine1._text += _strLine1.at(_txtLine1._text.length());
				else
					if (_txtLine2._text.length() < _strLine2.length())
						_txtLine2._text += _strLine2.at(_txtLine2._text.length());
					else
					{
						if (!_isPlaySoundScore)
						{
							_isPlaySoundScore = true;
							ResourceManager::PlayASound(ID_EFFECT_ANIMATION_SCORE);
							_timeFrame = 20;//Set thời gian nhảy số là 50 tick/ 1 lần nhảy
						}

						//Nhảy điểm ở đây
						if (_numOfScoreAnimation < 30)
						{
							_numOfScoreAnimation++;
							if (++_currentIndexScoreAnimation == 9)
								_currentIndexScoreAnimation = 0;
							_txtScore._text = std::to_string(_currentIndexScoreAnimation) + _strAddScoreAnimation;
						}
						else
						{
							ResourceManager::StopSound(ID_EFFECT_ANIMATION_SCORE);
							_txtScore._text = std::to_string(_maxScore);
							_timeFrame = 1000;
							_state = INTRO_STAGE_STATE::DELAY;
							_tick = 0;
						}
					}
			}
		}
		else
		{
			_tick += gameTime->GetDeltaTime();
			if (_tick >= _timeFrame)//hết thời gian delay thì chuyển sang màn hình PlayScreen
			{
				_nextScreen = new CPlayScreen();
				_isFinished = true;
			}
		}
}

void CIntroCharacter::Render(CGameTime* gameTime, CGraphics* graphics)
{
	_imgBackground.Render(gameTime, graphics);
	_imgLine1.Render(gameTime, graphics);
	if (_state != INTRO_STAGE_STATE::RUNNING_ANIMATION)
	{
		_txtLine1.Render(gameTime, graphics);
		_txtLine2.Render(gameTime, graphics);
		_txtScore.Render(gameTime, graphics);
	}
	graphics->Draw(_spriteBoss.GetTexture(), _spriteBoss.GetDestinationRectangle(), _posBoss, true);
}

void CIntroCharacter::RunAnimationBossCutMan(float deltaTime)
{
	if (_posBoss.y > (SCREEN_HEIGHT / 2))
	{
		_vBoss.y -= GRAVITY*deltaTime * 18;
		_posBoss.y += deltaTime*_vBoss.y;
	}
	else
	{
		_posBoss.y = (SCREEN_HEIGHT / 2);
		if (!_isBossStand)
		{
			_isBossStand = true;
			_tick = 0;
			_spriteBoss.SetFrame(1, 2);
		}
	}
	if (_isBossStand)
	{
		_tick += deltaTime;
		if (_tick >= _timeBossStand)
		{
			if (_spriteBoss.GetIndex() == 1)
			{
				_spriteBoss.SetIndex(1);
				this->GoToAnimationText();
			}
		}
	}
}

void CIntroCharacter::RunAnimationBossGutsMan(float deltaTime)
{
	if (_posBoss.y > (SCREEN_HEIGHT / 2))
	{
		_vBoss.y -= GRAVITY*deltaTime * 18;
		_posBoss.y += deltaTime*_vBoss.y;
		_posBoss.x += deltaTime*_vBoss.x;
	}
	else
	{
		_posBoss.y = (SCREEN_HEIGHT / 2);
		if (!_isBossStand)
		{
			_isBossStand = true;
			_tick = 0;
			_spriteBoss.SetFrame(1, 2);
		}
		else
		{
			if (_spriteBoss.GetIndex() == 1)
			{
				_spriteBoss.SetFrame(3, 4);
			}

			_tick += deltaTime;
			if (_tick >= _timeBossStand)
			{
				if (_spriteBoss.GetIndex() == 4)
				{
					_spriteBoss.SetIndex(4);
					this->GoToAnimationText();
				}
			}
		}
	}
}

void CIntroCharacter::RunAnimationBossBombMan(float deltaTime)
{
	if (_posBoss.x > (SCREEN_WIDTH / 3))
	{
		_vBoss.y -= GRAVITY*deltaTime * 18;
		_posBoss.y += deltaTime*_vBoss.y;
		_posBoss.x += deltaTime*_vBoss.x;
	}
	else
	{
		_posBoss.y = (SCREEN_HEIGHT / 2) +12;
		if (!_isBossStand)
		{
			_isBossStand = true;
			_tick = 0;
			_spriteBoss.SetFrame(1, 9);
		}
		else
		{
			if (_spriteBoss.GetIndex() == 9)
			{
				_spriteBoss.SetFrame(9, 2);
			}

			_tick += deltaTime;
			if (_tick >= _timeBossStand)
			{
				if (_spriteBoss.GetIndex() == 2)
				{
					_spriteBoss.SetIndex(2);
					this->GoToAnimationText();
				}
			}
		}
	}
}

void CIntroCharacter::GoToAnimationText()
{
	_state = INTRO_STAGE_STATE::RUNNING_TEXT;
	_tick = 0;
	_timeFrame = 50;
	ResourceManager::PlayASound(ID_EFFECT_ANIMATION_TEXT);
}