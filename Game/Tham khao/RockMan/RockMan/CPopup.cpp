#include "CPopup.h"


CPopup::CPopup(CRockman* rockman) :CScreen()
{
	_textureBG =  CTexture(L"Resources//Sprites//Others//popup.png", D3DCOLOR_XRGB(255, 40, 162));
	
	_textureLifeRockMan = CTexture(L"Resources//Sprites//Others//Item_life.png", D3DCOLOR_XRGB(0, 102, 102));
	_rockman = rockman;
}

void CPopup::Initilize()

{
	// lấy thông tin skill
	skillsInfo = _rockman->GetSkillInfo();
	Vector2 temp;
	for (map<Skill, int>::iterator it = skillsInfo.begin(); it != skillsInfo.end(); it++)
		skills.push_back(it->first);

	int currentSkill = _rockman->GetCurrentSkill();

	for (int i = 0; i < skills.size(); i++)
		if (skills[i] == currentSkill)
		{
		_RockManChoose = i;
		break;
		}
	_valueManaBoomman = 0;
	_valueManaCutman = 0;
	_valueManaGutman = 0;



	_timeDrawDefault = 500;
	_timeDraw = _timeDrawDefault;
	
	//_life = 3;
	_life = _rockman->GetLife();
	_position.x = _camera->GetViewport().left + 129;// 145
	_position.y = _camera->GetViewport().top - 24;// 55

	_boundingBG.left = 0;
	_boundingBG.top = 0;
	_boundingBG.right =_textureBG.GetWidth();
	_boundingBG.bottom =_textureBG.GetHeight();

	_boundingLR.left = 0;
	_boundingLR.top = 0;
	_boundingLR.right = _boundingLR.left + _textureLifeRockMan.GetWidth();
	_boundingLR.bottom = _boundingLR.top + _textureLifeRockMan.GetHeight();
	for (int i = 0; i < skills.size(); i++)
	{
		switch (skills[i])
		{
		case Skill::CUT:
			_valueManaCutman = skillsInfo.find(Skill::CUT)->second;
			
			
			temp.x = _position.x + 10;
			temp.y = _position.y - 30 *(skills.size()- i);
			_barManaCut = CBarMana(temp, "C");
			_barManaCut.Initlize();
			_barManaCut.SetMana(_valueManaCutman);
			break;
		case Skill::BOOM:
			_valueManaBoomman = skillsInfo.find(Skill::BOOM)->second;
			
			temp.x = _position.x + 10;
			temp.y = _position.y - 30 * (skills.size() - i);
			_barManaBoom = CBarMana( temp, "B");
			_barManaBoom.Initlize();
			_barManaBoom.SetMana(_valueManaBoomman);
			break;
		case Skill::GUTS:
			_valueManaGutman = skillsInfo.find(Skill::GUTS)->second;

			
			temp.x = _position.x + 10;
			temp.y = _position.y - 30 * (skills.size() - i);
			_barManaGut = CBarMana( temp, "G");
			_barManaGut.Initlize();
			_barManaGut.SetMana(_valueManaGutman);
			break;
		case Skill::NORMAL:
			_textP = CTextblock();
			_textP._position.x = _position.x + 10;
			_textP._position.y = _position.y - 129;// 110
			_textP._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT / 28);
			_textP._text = "P";
			_textP._color = D3DCOLOR_XRGB(255, 255, 255);
			_textP.Initlize();

			_positionLife.x = _position.x + 30;
			_positionLife.y = _position.y - 124;//105

			_textLife = CTextblock();
			_textLife._position.x = _position.x + 50;
			_textLife._position.y = _position.y - 129;//110
			_textLife._size = Vector2(SCREEN_WIDTH, SCREEN_HEIGHT / 28);
			_textLife._text = "X " + std::to_string(_life);
			_textLife._color = D3DCOLOR_XRGB(255, 255, 255);
			_textLife.Initlize();
			break;
		default:
			break;
		}
	}
	

	

	

	


	
}

void CPopup::Update(CGameTime* gameTime)
{
	if (_timeDraw > 0)
		_timeDraw -= gameTime->GetDeltaTime();
}
void CPopup::UpdateInput(CInput* input)
{
	if (input->IsKeyDown(DIK_RETURN))
	{
		_rockman->SetWeapons(skills[_RockManChoose], skillsInfo.find(skills[_RockManChoose])->second);
		CScreenManager::GetInstance()->ShowPopupScreen(NULL);
	}
	if (input->IsKeyDown(ID_KEY_CODE_DOWN))
	{
		_RockManChoose=__max(_RockManChoose-1,0);
	}
	if (input->IsKeyDown(ID_KEY_CODE_UP))
	{
		_RockManChoose = __min(_RockManChoose+1, skills.size()-1);
		
	}
	
}
void CPopup::Render(CGameTime* gameTime, CGraphics* graphics)
{
	graphics->Draw(_textureBG.GetTexture(), _boundingBG,_position, false);
	_textLife.Render(gameTime, graphics);
	graphics->Draw(_textureLifeRockMan.GetTexture(), _boundingLR, _positionLife, false);

	//khởi tạo để tất cả đều được vẽ
	_barManaBoom.IsDraw(true);
	_barManaCut.IsDraw(true);
	_barManaGut.IsDraw(true);

	//kiem tra de ve nếu nó đang là rockman chọn thì có hiệu ứng chớp
	for (int i = 0; i < skills.size(); i++)
	{
			switch (skills[i])
			{
			case Skill::NORMAL:
				if (skills[i] != skills[_RockManChoose])
				{
					_textP.Render(gameTime, graphics);
					
				}
				else
				{
					if (_timeDraw < 0)
					{
						_textP.Render(gameTime, graphics);
						_timeDraw = _timeDrawDefault;
					}
				}
					break;
			case Skill::BOOM:
				if (skills[i] != skills[_RockManChoose])
				_barManaBoom.Render(gameTime, graphics);
				else
				{
					_barManaBoom.IsDraw(false);
					if (_timeDraw < 0)
					{
						_barManaBoom.IsDraw(true);
						_timeDraw = _timeDrawDefault;
					}
					
					_barManaBoom.Render(gameTime, graphics);
				}
				break;
			case Skill::CUT:
				if (skills[i] != skills[_RockManChoose])
				_barManaCut.Render(gameTime, graphics);
				else
				{
					_barManaCut.IsDraw(false);
					if (_timeDraw < 0)
					{
						_barManaCut.IsDraw(true);
						_timeDraw = _timeDrawDefault;
					}
					_barManaCut.Render(gameTime, graphics);
				}
				break;
			case Skill::GUTS:
				if (skills[i] != skills[_RockManChoose])
				_barManaGut.Render(gameTime, graphics);
				else
				{
					_barManaGut.IsDraw(false);
					if (_timeDraw < 0)
					{
						_barManaGut.IsDraw(true);
						_timeDraw = _timeDrawDefault;
					}
					
					_barManaGut.Render(gameTime, graphics);
				}
				break;
			default:
				break;
			}
		
	}
}
CPopup::~CPopup()
{
}

