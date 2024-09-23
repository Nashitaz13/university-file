#include "CGameMenu.h"

CGameMenu::CGameMenu() :CScreen(){

	_title._position = Vector2(0, SCREEN_HEIGHT);
	_title._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_title._text = "SELECT\nSTAGE\n\nPRESS\nSTART";
	_title._verticalAlignment = Alignment::CENTER;
	_title._horizontalAlignment = Alignment::CENTER;
	_title._color = D3DCOLOR_XRGB(156, 252, 240);
	_title.Initlize();

	_background._position = Vector2(0, SCREEN_HEIGHT);
	_background._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT);
	_background._source = L"Resources//sprites//background_2.png";
	_background._transparentColor = D3DCOLOR_XRGB(255, 255, 255);
	_background.Initlize();

	// Màn CutMan
	_stage[0]._border = new CSprite(L"Resources//sprites//button_menu_state.png", 1, 2, 2, 500, D3DCOLOR_XRGB(0, 255, 0));
	if (CGameInfo::GetInstance()->HasSkill(Skill::CUT))
		_stage[0]._background = new CTexture(L"Resources//sprites//icon_master_cut_man_done.png", D3DCOLOR_XRGB(0, 255, 0));
	else
		_stage[0]._background = new CTexture(L"Resources//sprites//icon_master_cut_man.png", D3DCOLOR_XRGB(0, 255, 0));
	_stage[0]._size = Vector2(50, 50);
	_stage[0]._position = Vector2(SCREEN_WIDTH / 2 - 60, SCREEN_HEIGHT / 2 + 100);
	_stage[0]._name = "CUTMAN";
	_stage[0]._foreground = D3DCOLOR_XRGB(156, 252, 240);
	_stage[0]._isFocused = true;
	_stage[0].Initlize();

	// Màn GutsMan
	_stage[1]._border = new CSprite(L"Resources//sprites//button_menu_state.png", 1, 2, 2, 500, D3DCOLOR_XRGB(0, 255, 0));
	if (CGameInfo::GetInstance()->HasSkill(Skill::GUTS))
		_stage[1]._background = new CTexture(L"Resources//sprites//icon_master_guts_man_done.png", D3DCOLOR_XRGB(0, 255, 0));
	else
		_stage[1]._background = new CTexture(L"Resources//sprites//icon_master_guts_man.png", D3DCOLOR_XRGB(0, 255, 0));
	_stage[1]._size = Vector2(50, 50);
	_stage[1]._position = Vector2(SCREEN_WIDTH / 2 + 15, SCREEN_HEIGHT / 2 + 100);
	_stage[1]._name = "GutsMan";
	_stage[1]._foreground = D3DCOLOR_XRGB(156, 252, 240);
	_stage[1].Initlize();

	// Màn IceMan
	_stage[2]._border = new CSprite(L"Resources//sprites//button_menu_state.png", 1, 2, 2, 500, D3DCOLOR_XRGB(0, 255, 0));
	if (CGameInfo::GetInstance()->HasSkill(Skill::ICE))
		_stage[2]._background = new CTexture(L"Resources//sprites//icon_master_Ice_man_done.png", D3DCOLOR_XRGB(0, 255, 0));
	else
		_stage[2]._background = new CTexture(L"Resources//sprites//icon_master_Ice_man.png", D3DCOLOR_XRGB(0, 255, 0));
	_stage[2]._size = Vector2(50, 50);
	_stage[2]._position = Vector2(SCREEN_WIDTH / 2 + 44, SCREEN_HEIGHT / 2 + 32);
	_stage[2]._name = "IceMan";
	_stage[2]._foreground = D3DCOLOR_XRGB(156, 252, 240);
	_stage[2].Initlize();

	// Màn BoomMan
	_stage[3]._border = new CSprite(L"Resources//sprites//button_menu_state.png", 1, 2, 2, 500, D3DCOLOR_XRGB(0, 255, 0));
	if (CGameInfo::GetInstance()->HasSkill(Skill::BOOM))
		_stage[3]._background = new CTexture(L"Resources//sprites//icon_master_Boom_man_done.png", D3DCOLOR_XRGB(0, 255, 0));
	else
		_stage[3]._background = new CTexture(L"Resources//sprites//icon_master_Boom_man.png", D3DCOLOR_XRGB(0, 255, 0));
	_stage[3]._size = Vector2(50, 50);
	_stage[3]._position = Vector2(SCREEN_WIDTH / 2 + 15, SCREEN_HEIGHT / 2 - 35);
	_stage[3]._name = "BoomMan";
	_stage[3]._foreground = D3DCOLOR_XRGB(156, 252, 240);
	_stage[3].Initlize();

	// Màn FireMan
	_stage[4]._border = new CSprite(L"Resources//sprites//button_menu_state.png", 1, 2, 2, 500, D3DCOLOR_XRGB(0, 255, 0));
	if (CGameInfo::GetInstance()->HasSkill(Skill::FIRE))
		_stage[4]._background = new CTexture(L"Resources//sprites//icon_master_Fire_man_done.png", D3DCOLOR_XRGB(0, 255, 0));
	else
		_stage[4]._background = new CTexture(L"Resources//sprites//icon_master_Fire_man.png", D3DCOLOR_XRGB(0, 255, 0));
	_stage[4]._size = Vector2(50, 50);
	_stage[4]._position = Vector2(SCREEN_WIDTH / 2 - 60, SCREEN_HEIGHT / 2 - 35);
	_stage[4]._name = "FireMan";
	_stage[4]._foreground = D3DCOLOR_XRGB(156, 252, 240);
	_stage[4].Initlize();

	// Màn ElecMan
	_stage[5]._border = new CSprite(L"Resources//sprites//button_menu_state.png", 1, 2, 2, 500, D3DCOLOR_XRGB(0, 255, 0));
	if (CGameInfo::GetInstance()->HasSkill(Skill::ELECTRIC))
		_stage[5]._background = new CTexture(L"Resources//sprites//icon_master_Electric_man_done.png", D3DCOLOR_XRGB(0, 255, 0));
	else
		_stage[5]._background = new CTexture(L"Resources//sprites//icon_master_Electric_man.png", D3DCOLOR_XRGB(0, 255, 0));
	_stage[5]._size = Vector2(50, 50);
	_stage[5]._position = Vector2(SCREEN_WIDTH / 2 - 90, SCREEN_HEIGHT / 2 + 32);
	_stage[5]._name = "ElecMan";
	_stage[5]._foreground = D3DCOLOR_XRGB(156, 252, 240);
	_stage[5].Initlize();

	_stageIndex = 0;
	_isJustPlaySound = false;
	_typeID = ID_SCREEN_MENU;
}

CGameMenu::~CGameMenu(){

}

void CGameMenu::UpdateInput(CInput* input){

	if (input->IsKeyDown(ID_KEY_CODE_LEFT))
	{
		_stageIndex = (_stageIndex + 5) % 6;
		_stage[_stageIndex]._isFocused = true;
		for (int i = 0; i < 6; i++)
		{
			if (i != _stageIndex)
				_stage[i]._isFocused = false;
		}
		ResourceManager::PlayASound(ID_EFFECT_FOCUS_STAGE);
	}
	if (input->IsKeyDown(ID_KEY_CODE_RIGHT)){
		_stageIndex = (_stageIndex + 1) % 6;
		_stage[_stageIndex]._isFocused = true;
		for (int i = 0; i < 6; i++)
		{
			if (i != _stageIndex)
				_stage[i]._isFocused = false;
		}
		ResourceManager::PlayASound(ID_EFFECT_FOCUS_STAGE);
	}
	if (input->IsKeyDown(DIK_RETURN)){
		ResourceManager::PlayASound(ID_EFFECT_SELECT_STAGE);
		switch (_stageIndex + 1)
		{
		case 1:
			CGameInfo::GetInstance()->SetLevel(ID_LEVEL_CUT);
			_nextScreen = new CIntroCharacter(CSprite(SPRITE_INTRO_BOSS_CUTMAN, 1, 3, 3, 200, D3DCOLOR_XRGB(34, 177, 76)), STAGE::CUTMAN, 100000);
			_isFinished = true;
			ResourceManager::StopSound(ID_SOUND_STAGE_SELECT);
			break;
		case 2:
			CGameInfo::GetInstance()->SetLevel(ID_LEVEL_GUTS);
			_nextScreen = new CIntroCharacter(CSprite(SPRITE_INTRO_BOSS_GUTSMAN, 1, 5, 5, 100, D3DCOLOR_XRGB(34, 177, 76)), STAGE::GUTSMAN, 60000);
			_isFinished = true;
			ResourceManager::StopSound(ID_SOUND_STAGE_SELECT);

			break;
		case 4:
			CGameInfo::GetInstance()->SetLevel(ID_LEVEL_BOOM);
			_nextScreen = new CIntroCharacter(CSprite(SPRITE_INTRO_BOSS_BOMBMAN, 1, 10, 10, 70, D3DCOLOR_XRGB(34, 177, 76)), STAGE::BOMBMAN, 60000);
			_isFinished = true;
			ResourceManager::StopSound(ID_SOUND_STAGE_SELECT);
			break;
		}
	}
}

void CGameMenu::Update(CGameTime* gameTime)
{
	if (!_isJustPlaySound)
	{
		ResourceManager::StopSound(ID_SOUND_GAME_START);
		ResourceManager::PlayASound(ID_SOUND_STAGE_SELECT);
		_isJustPlaySound = true;
	}
	for (int i = 0; i < 6; i++)
	{
		_stage[i].Update(gameTime);
	}
}

void CGameMenu::Render(CGameTime* gameTime, CGraphics* graphics)
{

	_background.Render(gameTime, graphics);
	_title._color = _stage[_stageIndex].GetAnimationColor();
	_title.Render(gameTime, graphics);

	for (int i = 0; i < 6; i++)
		_stage[i].Render(gameTime, graphics);
}