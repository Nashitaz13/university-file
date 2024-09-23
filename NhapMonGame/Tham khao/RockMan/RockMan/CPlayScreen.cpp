#include "CPlayScreen.h"

CPlayScreen::CPlayScreen() :CScreen()
{
	_rockman.Initlize();
	_changingScreen = 0;
	_pointAfterDoor = Vector2(0, 0);
	_pointBeforeDoor = Vector2(0, 0);
	_isBossDied = false;
	LoadMap();

	// Khởi động trạng thái
	_playState = PlayState::READY;
	_deltaClearPoint = 0;
	_strClearPoint = "";
	_strBonus = "";
	_deltaTime = 0;
	_typeID = ID_SCREEN_PLAY;
	_prepareForBoss = 0;
	_shakePointRand = Vector2(0.0f, 0.0f);
	_defaultStringColor = D3DCOLOR_XRGB(255, 255, 255);
}

CPlayScreen::~CPlayScreen()
{

}

void CPlayScreen::UpdateInput(CInput* input)
{
	if (_playState == PlayState::PLAYING&& _rockman._behave != Behave::DYING&&_rockman._behave != Behave::REAL_DIE&& !_rockman.IsRequireStopScreen() && _changingScreen == 0)
	{
		if (input->IsKeyDown(DIK_SPACE))
		{
			if (_isPause)
			{
				_isPause = false;
				_rockman.ReSetSKill();
				ResourceManager::ReplaySound();
			}
			else{
				ResourceManager::MuteSound();
				ResourceManager::PlayASound(ID_EFFECT_PAUSE);
				_isPause = true;
			}

		}
		if (input->IsKeyDown(DIK_RETURN))
		{
			if (!_isPause)
			{
				_rockman.ReSetSKill();
				_isChosingSkill = true;
				CScreenManager::GetInstance()->ShowPopupScreen(new CPopup(&_rockman));
				ResourceManager::PlayASound(ID_EFFECT_POPUP_APPEAR);
			}
		}
	}
}

void CPlayScreen::Update(CGameTime* gameTime)
{
	if (!_isPause)
	{
		if (_isChosingSkill)
		{
			_isChosingSkill = false;

			int countPowerEnegy = _powerEnegies.size();
			for (int i = 0; i < countPowerEnegy; i++)
				switch (_powerEnegies[i]->_typeID)
			{
				case ID_BAR_WEAPONS_BOOM:
				case ID_BAR_WEAPONS_CUT:
				case ID_BAR_WEAPONS_GUTS:
					_powerEnegies.erase(_powerEnegies.begin() + i);
					countPowerEnegy -= 1;
					i -= 1;
					break;
			}

			switch (_rockman.GetCurrentSkill())
			{
			case Skill::CUT:
				_powerEnegies.push_back(new CPowerEnergyX(ID_BAR_WEAPONS_CUT, &_rockman, ResourceManager::GetSprite(ID_SPRITE_BAR_CUT_VERTICAL), Vector2(19, -37), 0, WEASPON_DEFAULT, WEASPON_DEFAULT));
				break;
			case Skill::GUTS:
				_powerEnegies.push_back(new CPowerEnergyX(ID_BAR_WEAPONS_GUTS, &_rockman, ResourceManager::GetSprite(ID_SPRITE_BAR_GUTS_VERTICAL), Vector2(19, -37), 0, WEASPON_DEFAULT, WEASPON_DEFAULT));
				break;
			case Skill::BOOM:
				_powerEnegies.push_back(new CPowerEnergyX(ID_BAR_WEAPONS_BOOM, &_rockman, ResourceManager::GetSprite(ID_SPRITE_BAR_BOOM_VERTICAL), Vector2(19, -37), 0, WEASPON_DEFAULT, WEASPON_DEFAULT));
				break;
			}
		}
		if (_isStopScreen)
		{
			_deltaTimeStopScreen += gameTime->GetDeltaTime();
			if (_deltaTimeStopScreen >= 1000)
			{
				_isStopScreen = false;
				_rockman._isRequireStopScreen = false;
			}
			else return;
		}
		vector<CGameObject*>* objs = new vector<CGameObject*>();
		_quadNodeCollision.GetObjectsIn(_camera->GetViewport(), objs);
		_groundObjs.clear();
		for (int i = 0; i < objs->size(); i++)
		{
			switch ((*objs)[i]->_typeID)
			{
			case ID_ROCK_IN_GUT_STAGE:
			case ID_ROCK:
				if (((CRock*)(*objs)[i])->IsGot())
					break;
			case  ID_BLOCK_TROUBLE_OF_ELEVATOR:
			case ID_BLOCK:
			case ID_STAIR:
			case ID_FALLING_POINT:
			case ID_DIE_ARROW:
				_groundObjs.push_back((*objs)[i]);
				break;
			case ID_DOOR1_CUTMAN:
			case ID_DOOR2_CUTMAN:
			case ID_DOOR1_GUTSMAN:
			case ID_DOOR2_GUTSMAN:
			case ID_DOOR1_BOOMMAN:
			case ID_DOOR2_BOOMMAN:
				_door = ((CDoor*)(*objs)[i]);
				break;
			case ID_ITEM_BLOOD_BIG:
			case ID_ITEM_BLOOD_SMALL:
			case ID_ITEM_LIFE:
			case ID_ITEM_MANA_BIG:
			case ID_ITEM_MANA_SMALL:
				if (_changingScreen == 2 || (_changingScreen == 0 && !(*objs)[i]->GetBox().IntersecWith(_camera->GetViewport())) || _playState == PlayState::READY)
				{
					bool exited = false;

					for (int j = 0; j < _items.size(); j++)
						if ((*objs)[i]->_id == _items[j]->_id)
						{
							exited = true;
							break;
						}
					if (!exited)
						_items.push_back(((CItem*)(*objs)[i])->ToValue());
				}
				break;
			case ID_ELEVATOR_TROUBLE:
			case ID_ELEVATOR:
				if (_changingScreen == 2 || (_changingScreen == 0 && !(*objs)[i]->GetBox().IntersecWith(_camera->GetViewport())) || _playState == PlayState::READY)
				{
					bool exited = false;

					for (int j = 0; j < _elevators.size(); j++)
						if ((*objs)[i]->_id == _elevators[j]->_id)
						{
							exited = true;
							break;
						}
					if (!exited)
						_elevators.push_back((CElevator*)(*objs)[i]);
				}
				break;
			case ID_CUTMAN:
				if (_prepareForBoss == 0)
				{
					_prepareForBoss = 1;
					_deltaTime = 0;
					_spriteIntroBoss = ResourceManager::GetSprite(ID_SPRITE_ROOM_CUT_STAGE);
				}
			case ID_BOOMMAN:
				if (_prepareForBoss == 0)
				{
					_prepareForBoss = 1;
					_deltaTime = 0;
					_spriteIntroBoss = ResourceManager::GetSprite(ID_SPRITE_ROOM_BOOM_STAGE);
				}
			case ID_GUTSMAN:
				if (_prepareForBoss == 0)
				{
					_prepareForBoss = 1;
					_deltaTime = 0;
					_spriteIntroBoss = ResourceManager::GetSprite(ID_SPRITE_ROOM_GUTS_STAGE);
				}
				if (_isBossDied)
					break;
				if (_prepareForBoss == 2 && _rockman.IsOverDoor() && _rockman.IsInBossRoom())
				{
					bool exited = false;

					for (int j = 0; j < _enemies.size(); j++)
						if ((*objs)[i]->_id == _enemies[j]->_id)
						{
							exited = true;
							break;
						}
					if (!exited)
						_enemies.push_back(((CEnemy*)(*objs)[i])->ToValue());
				}
				break;
			default:
				if (_changingScreen == 2 || (_changingScreen == 0 && !(*objs)[i]->GetBox().IntersecWith(_camera->GetViewport())) || _playState == PlayState::READY)
				{
					bool exited = false;

					for (int j = 0; j < _enemies.size(); j++)
						if ((*objs)[i]->_id == _enemies[j]->_id)
						{
							exited = true;
							break;
						}
					if (!exited)
						_enemies.push_back(((CEnemy*)(*objs)[i])->ToValue());
				}
				break;
			}
		}

		if (_elevators.size() == 0)
			ResourceManager::StopSound(ID_EFFECT_ELEVATOR_RUNNING);
		else
			ResourceManager::PlayASound(ID_EFFECT_ELEVATOR_RUNNING);

		if (_changingScreen == 2)
			_changingScreen = 0;
		if (_playState == PlayState::READY)
		{
#pragma region Xử lý khởi động màn chơi PlayState::READY
			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 1000)
			{
				_rockman.Update(gameTime);

				CDirection normalX, normalY;
				float collideTime;

				for (int i = 0; i < _groundObjs.size(); i++)		// Kiểm tra va chạm với các khối tường, gạch đá
				{
					collideTime = CheckCollision(&_rockman, _groundObjs[i], normalX, normalY, gameTime->GetDeltaTime());
					if (collideTime < gameTime->GetDeltaTime())
						_rockman.OnCollideWith(_groundObjs[i], normalX, normalY, collideTime);
				}

				// Đảm bảo rockman đã chuyển sang chế độ play,
				if (!_rockman._isTheFirstTime)
				{
					_playState = PlayState::PLAYING;
					_powerEnegies.push_back(new CPowerEnergyX(ID_BAR_BLOOD_ROCKMAN, &_rockman, ResourceManager::GetSprite(ID_SPRITE_BAR_ROCKMAN_VERTICAL), Vector2(27, -37), 0, BLOOD_DEFAULT, BLOOD_DEFAULT));
					return;
				}
			}
#pragma endregion
		}
		else if (_playState == PlayState::PLAYING)
		{
#pragma region Xử lý khi vào phòng boss

			if (_prepareForBoss == 1)
			{
				_deltaTime += gameTime->GetDeltaTime();
				if (_deltaTime >= 3000)
				{
					_prepareForBoss = 2;
					_deltaTime = 0;
					_playState = PlayState::PLAYING;
				}
			}

#pragma endregion

#pragma region Xử lý chạy game
			if (_rockman.IsDied())
			{
				_playState = PlayState::GAMEOVER;
				_bulletsRockman.clear();
				ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_DIE);
				ResourceManager::StopSound(ID_SOUND_BOSS);
				switch (CGameInfo::GetInstance()->GetLevel())
				{
				case ID_LEVEL_BOOM:
					ResourceManager::StopSound(ID_SOUND_BOMBMAN_STAGE);
					break;
				case ID_LEVEL_CUT:
					ResourceManager::StopSound(ID_SOUND_CUTMAN_STAGE);
					break;
				case ID_LEVEL_GUTS:
					ResourceManager::StopSound(ID_EFFECT_ELEVATOR_RUNNING);
					ResourceManager::StopSound(ID_SOUND_GUTSMAN_STAGE);
					break;
				}
				_deltaTime = 0;						// Bắt đầu đếm thời gian chờ chuyển màn
				return;
			}

			if (_door != NULL)
			{
				if (_door->_typeID == ID_DOOR1_CUTMAN ||
					_door->_typeID == ID_DOOR2_CUTMAN ||
					_door->_typeID == ID_DOOR1_GUTSMAN ||
					_door->_typeID == ID_DOOR2_GUTSMAN ||
					_door->_typeID == ID_DOOR1_BOOMMAN ||
					_door->_typeID == ID_DOOR2_BOOMMAN)
				{
					switch (_door->_typeID)
					{
					case ID_DOOR1_CUTMAN:
					case ID_DOOR1_GUTSMAN:
					case ID_DOOR1_BOOMMAN:
						_pointBeforeDoor = _door->_position - Vector2(SCREEN_WIDTH / 2, 0);
						_pointAfterDoor = _door->_position + Vector2(SCREEN_WIDTH / 2 + _door->GetBox()._width / 2, 0);
						break;
					case ID_DOOR2_CUTMAN:
					case ID_DOOR2_GUTSMAN:
						_pointBeforeDoor = _door->_position - Vector2(SCREEN_WIDTH / 2, 0);
						_pointAfterDoor = _cameraPath->GetEndPoint();
						break;
					case ID_DOOR2_BOOMMAN:
						_pointBeforeDoor = _door->_position + Vector2(0, SCREEN_HEIGHT / 2);
						_pointAfterDoor = _cameraPath->GetEndPoint();
						break;
					}
					_pointDoor = _door->_position;

					if (_rockman.IsRequireOpenDoor())
					{
						if (_door->GetState() == DoorState::WAITING)
						{
							_doorState = -1;
							_door->OpenDoor();
							ResourceManager::PlayASound(ID_EFFECT_OPEN_THE_DOOR);
						}
						_door->Update(gameTime);

						if (_door->GetState() == DoorState::WAITING_FOR_THROUGH&&!_rockman.IsGoingOverDoor())
						{
							_doorState = 0;
							_rockman.ThroughOverDoor(_door->_typeID);
							_changingScreen = 1;

							_enemies.clear();
							_bulletsEnemy.clear();
							_bulletsRockman.clear();
							_items.clear();
							_rockman._canFire = true;

							if (_door->_typeID != ID_DOOR2_BOOMMAN)
							{
								_newScreenPosition = _pointAfterDoor;
								_changeScreenDirection = CDirection::ON_RIGHT;
							}
						}
					}
					else if (_rockman.IsOverDoor() && _door->GetState() == DoorState::WAITING_FOR_THROUGH)
					{
						_door->CloseDoor();
						ResourceManager::PlayASound(ID_EFFECT_OPEN_THE_DOOR);
						_door->Update(gameTime);
					}
				}

				_door->Update(gameTime);
			}
			// Chặn mọi hoạt động khi cửa hoạt động
			if (_doorState == -1)
				return;

			_rockman.Update(gameTime);

			vector<CBullet*> bullets = _rockman.GetBullets();
			for (int i = 0; i < bullets.size(); i++)
				_bulletsRockman.push_back(bullets[i]);

			// Duyệt va chạm giữa Rockman và các đối tượng trên màn hình
			CDirection normalX, normalY;
			float collideTime;

			for (int i = 0; i < _groundObjs.size(); i++)		// Kiểm tra va chạm với các khối tường, gạch đá
			{
				collideTime = CheckCollision(&_rockman, _groundObjs[i], normalX, normalY, gameTime->GetDeltaTime());
				if (collideTime < gameTime->GetDeltaTime())
					_rockman.OnCollideWith(_groundObjs[i], normalX, normalY, collideTime);
			}
			if (_door != NULL)
			{
				collideTime = CheckCollision(&_rockman, _door, normalX, normalY, gameTime->GetDeltaTime());
				if (collideTime < gameTime->GetDeltaTime())
					_rockman.OnCollideWith(_door, normalX, normalY, collideTime);
			}

			for (int i = 0; i < _items.size(); i++)		// Kiểm tra va chạm với các items
			{
				collideTime = CheckCollision(&_rockman, _items[i], normalX, normalY, gameTime->GetDeltaTime());
				if (collideTime < gameTime->GetDeltaTime())
					_rockman.OnCollideWith(_items[i], normalX, normalY, collideTime);
			}

			for (int i = 0; i < _elevators.size(); i++)		// Kiểm tra va chạm với các băng chuyền
			{
				_elevators[i]->Update(gameTime);

				// Kiểm tra va chạm với Rockman
				collideTime = CheckCollision(&_rockman, _elevators[i], normalX, normalY, gameTime->GetDeltaTime());
				if (collideTime < gameTime->GetDeltaTime())
					_rockman.OnCollideWith(_elevators[i], normalX, normalY, collideTime);

				collideTime = CheckCollision(_elevators[i], &_rockman, normalX, normalY, gameTime->GetDeltaTime());
				if (collideTime < gameTime->GetDeltaTime())
					_elevators[i]->OnCollideWith(&_rockman, normalX, normalY, gameTime->GetDeltaTime() - collideTime);

				for (int j = 0; j < _groundObjs.size(); j++)		// Kiểm tra va chạm với các khối tường, gạch đá
				{
					collideTime = CheckCollision(_elevators[i], _groundObjs[j], normalX, normalY, gameTime->GetDeltaTime());
					if (collideTime < gameTime->GetDeltaTime())
						_elevators[i]->OnCollideWith(_groundObjs[j], normalX, normalY, collideTime);
				}
				if (!_elevators[i]->GetCollideRegion().IntersecWith(_camera->GetViewport()))
				{
					_elevators.erase(_elevators.begin() + i);
					i -= 1;
				}
			}

			if (_rockman.IsInBossRoom() && _prepareForBoss == 2 && _changingScreen == 0)
			{
				for (int i = 0; i < _enemies.size(); i++)
				{
					switch (_enemies[i]->_typeID)
					{
					case ID_CUTMAN:
						_powerEnegies.push_back(new CPowerEnergyX(ID_BAR_BLOOD_CUTMAN, _enemies[i], ResourceManager::GetSprite(ID_SPRITE_BAR_CUT_VERTICAL), Vector2(43, -37), 0, BLOOD_CUTMAN, 0));
						ResourceManager::StopSound(ID_SOUND_CUTMAN_STAGE);
						ResourceManager::PlayASound(ID_SOUND_BOSS);
						_prepareForBoss = 3;
						return;
					case ID_BOOMMAN:
						_powerEnegies.push_back(new CPowerEnergyX(ID_BAR_BLOOD_BOOMMAN, _enemies[i], ResourceManager::GetSprite(ID_SPRITE_BAR_BOOM_VERTICAL), Vector2(43, -37), 0, BLOOD_BOOMMAN, 0));
						ResourceManager::StopSound(ID_SOUND_BOMBMAN_STAGE);
						ResourceManager::PlayASound(ID_SOUND_BOSS);
						_prepareForBoss = 3;
						return;
					case ID_GUTSMAN:
						_powerEnegies.push_back(new CPowerEnergyX(ID_BAR_BLOOD_GUTSMAN, _enemies[i], ResourceManager::GetSprite(ID_SPRITE_BAR_GUTS_VERTICAL), Vector2(43, -37), 0, BLOOD_GUTSMAN, 0));
						ResourceManager::StopSound(ID_SOUND_GUTSMAN_STAGE);
						ResourceManager::PlayASound(ID_SOUND_BOSS);
						_prepareForBoss = 3;
						return;
					}
				}
			}
			else if (_rockman.IsRequireStopScreen())
			{
				_isStopScreen = true;
				_deltaTimeStopScreen = 0.0f;
				return;
			}
			else if (_rockman.IsEndGame())
			{
				_deltaTimeStopScreen = 0.0f;
				_playState = PlayState::WIN;
				ResourceManager::StopSound(ID_SOUND_BOSS);
				ResourceManager::PlayASound(ID_EFFECT_VICTORY);
				return;
			}

			if (_changingScreen == 0)
			{
				int countRockmanBullet = _bulletsRockman.size();
				for (int i = 0; i < countRockmanBullet; i++)
				{
					for (int j = 0; j < _groundObjs.size(); j++)		// Kiểm tra va chạm với các khối tường, gạch đá
					{
						collideTime = CheckCollision(_bulletsRockman[i], _groundObjs[j], normalX, normalY, gameTime->GetDeltaTime());
						if (collideTime < gameTime->GetDeltaTime())
							((CBullet*)_bulletsRockman[i])->OnCollideWith(_groundObjs[j], normalX, normalY, collideTime);
					}
					for (int j = 0; j < _enemies.size(); j++)		// Kiểm tra va chạm với các khối tường, gạch đá
					{
						collideTime = CheckCollision(_bulletsRockman[i], _enemies[j], normalX, normalY, gameTime->GetDeltaTime());
						if (collideTime < gameTime->GetDeltaTime())
							((CBullet*)_bulletsRockman[i])->OnCollideWith(_enemies[j], normalX, normalY, collideTime);
					}
					if (_door != NULL)
					{
						collideTime = CheckCollision(_bulletsRockman[i], _door, normalX, normalY, gameTime->GetDeltaTime());
						if (collideTime < gameTime->GetDeltaTime())
							((CBullet*)_bulletsRockman[i])->OnCollideWith(_door, normalX, normalY, collideTime);
					}
					_bulletsRockman[i]->Update(gameTime);
					if (_bulletsRockman[i]->GetState() == BULLET_BASE_STATE::DIE || (!_bulletsRockman[i]->GetBox().IntersecWith(CBox(_camera->GetViewport())) && _bulletsRockman[i]->GetBox()._y - _camera->GetViewport().top < 0))
					{
						_bulletsRockman[i]->Destroy();
						_bulletsRockman.erase(_bulletsRockman.begin() + i);
						i -= 1;
						countRockmanBullet -= 1;
					}
				}

				for (int i = 0; i < _enemies.size(); i++)			// Kiểm tra va chạm với các đối tượng quái trên màn hình
				{
					collideTime = CheckCollision(&_rockman, _enemies[i], normalX, normalY, gameTime->GetDeltaTime());
					if (collideTime < gameTime->GetDeltaTime())
					{
						_rockman.OnCollideWith(_enemies[i], normalX, normalY, collideTime);
						((CEnemy*)_enemies[i])->OnCollideWith(&_rockman, normalX, normalY, collideTime);
					}
				}

				for (int i = 0; i < _bulletsEnemy.size(); i++)			// Kiểm tra va chạm với đạn của quái trên màn hình
				{
					if (((CBullet*)_bulletsEnemy[i])->GetState() == BULLET_BASE_STATE::FLYING)
					{
						collideTime = CheckCollision(&_rockman, _bulletsEnemy[i], normalX, normalY, gameTime->GetDeltaTime());
						if (collideTime < gameTime->GetDeltaTime())
						{
							_rockman.OnCollideWith(_bulletsEnemy[i], normalX, normalY, collideTime);
							((CBullet*)_bulletsEnemy[i])->OnCollideWith(&_rockman, normalX, normalY, collideTime);
						}
					}
				}
				//-----------------------------------------------------------------------------
				// Cập nhật quái và đạn của quái
				//
				//-----------------------------------------------------------------------------
				int countEnemies = _enemies.size();
				for (int i = 0; i < countEnemies; i++)
				{
					_enemies[i]->Update(gameTime);
					_enemies[i]->Update(gameTime, &_rockman);
					_enemies[i]->UpdateCamera(*_camera);
					if (_enemies[i]->IsDied() && !_rockman.IsDied())
					{
						if (_enemies[i]->_typeID == ID_CUTMAN)
						{
							CExplodingEffectX* explode = new CExplodingEffectX(_enemies[i]->_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), false);
							explode->SetSoundEffect(ID_EFFECT_BOSS_DIE);
							CExplodingEffectManager::Add(explode);
							_items.push_back(new CItem(ID_ITEM_BOSS_CUT, _cameraPath->GetEndPoint() + Vector2(0, SCREEN_HEIGHT / 2), true));
							_items[0]->Initlize();
							_isBossDied = true;
							_clearPoint = _enemies[i]->GetScore();
						}
						else if (_enemies[i]->_typeID == ID_BOOMMAN)
						{
							CExplodingEffectX* explode = new CExplodingEffectX(_enemies[i]->_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), false);
							explode->SetSoundEffect(ID_EFFECT_BOSS_DIE);
							CExplodingEffectManager::Add(explode);
							_items.push_back(new CItem(ID_ITEM_BOSS_BOOM, _cameraPath->GetEndPoint() + Vector2(0, SCREEN_HEIGHT / 2), true));
							_items[0]->Initlize();
							_isBossDied = true;
							_clearPoint = _enemies[i]->GetScore();
						}
						else if (_enemies[i]->_typeID == ID_GUTSMAN)
						{
							CExplodingEffectX* explode = new CExplodingEffectX(_enemies[i]->_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), false);
							explode->SetSoundEffect(ID_EFFECT_BOSS_DIE);
							CExplodingEffectManager::Add(explode);
							_items.push_back(new CItem(ID_ITEM_BOSS_GUTS, _cameraPath->GetEndPoint() + Vector2(0, SCREEN_HEIGHT / 2), true));
							_items[0]->Initlize();
							_isBossDied = true;
							_clearPoint = _enemies[i]->GetScore();
						}
						else
						{
							CExplodingEffectManager::Add(new CExplodingEffect(_enemies[i]->_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE)));

							srand(time(NULL));
							int rand = std::rand() % 7 + 1;
							if (rand == 1)
							{
								CItem *item = new CItem(ID_ITEM_BLOOD_SMALL, _enemies[i]->_position);
								item->Initlize();
								_items.push_back(item);
							}
							else if (rand == 2)
							{
								CItem *item = new CItem(ID_ITEM_BLOOD_BIG, _enemies[i]->_position);
								item->Initlize();
								_items.push_back(item);
							}
							else if (rand == 3)
							{
								CItem *item = new CItem(ID_ITEM_MANA_BIG, _enemies[i]->_position);
								item->Initlize();
								_items.push_back(item);
							}
							else if (rand == 4)
							{
								CItem *item = new  CItem(ID_ITEM_MANA_SMALL, _enemies[i]->_position);
								item->Initlize();
								_items.push_back(item);
							}
							else if (rand == 5)
							{
								CItem *item = new CItem(ID_ITEM_BONUS, _enemies[i]->_position);
								item->Initlize();
								_items.push_back(item);
							}
							else if (rand == 7)
							{
								CItem *item = new CItem(ID_ITEM_LIFE, _enemies[i]->_position);
								item->Initlize();
								_items.push_back(item);
							}
						}
						CGameInfo::GetInstance()->SetScore(CGameInfo::GetInstance()->GetScore() + _enemies[i]->GetScore());
						_enemies.erase(_enemies.begin() + i);
						i -= 1;
						countEnemies -= 1;
					}
					else if ((!_enemies[i]->GetBox().IntersecWith(CBox(_camera->GetViewport())) && _enemies[i]->IsInViewPort())
						|| (!_enemies[i]->GetCollideRegion().IntersecWith(CBox(_camera->GetViewport())) && !_enemies[i]->IsInViewPort()))
					{
						_enemies.erase(_enemies.begin() + i);
						i -= 1;
						countEnemies -= 1;
					}
					else
					{
						vector<CBullet*> bullets = _enemies[i]->Fire();
						for (int j = 0; j < bullets.size(); j++)
							_bulletsEnemy.push_back(bullets[j]);

						// Kiểm tra quái va chạm với đạn của rockman trên màn hình
						for (int j = 0; j < _bulletsRockman.size(); j++)
						{
							if (_bulletsRockman[j]->GetState() == BULLET_BASE_STATE::FLYING)
							{
								collideTime = CheckCollision(_enemies[i], _bulletsRockman[j], normalX, normalY, gameTime->GetDeltaTime());
								if (collideTime < gameTime->GetDeltaTime())
								{
									((CEnemy*)_enemies[i])->OnCollideWith(_bulletsRockman[j], normalX, normalY, collideTime);
								}
							}
						}
						// Kiểm tra quái va chạm với tường, gạch đá trên màn  hình

						for (int j = 0; j < _groundObjs.size(); j++)
						{
							collideTime = CheckCollision(_enemies[i], _groundObjs[j], normalX, normalY, gameTime->GetDeltaTime());
							if (collideTime < gameTime->GetDeltaTime())
								((CEnemy*)_enemies[i])->OnCollideWith(_groundObjs[j], normalX, normalY, collideTime);
						}

						if (_door != NULL)
						{
							collideTime = CheckCollision(_enemies[i], _door, normalX, normalY, gameTime->GetDeltaTime());
							if (collideTime < gameTime->GetDeltaTime())
								((CEnemy*)_enemies[i])->OnCollideWith(_door, normalX, normalY, collideTime);
						}
					}
				}

				// Cập nhật item
				int countItem = _items.size();
				for (int i = 0; i < countItem; i++)
				{
					if (_items[i]->IsGot() || !(_items[i]->GetCollideRegion().IntersecWith(_camera->GetViewport())))
					{
						_items.erase(_items.begin() + i);
						countItem -= 1;
						i -= 1;
					}
					else
					{
						_items[i]->Update(gameTime);
						for (int j = 0; j < _groundObjs.size(); j++)
						{
							collideTime = CheckCollision(_items[i], _groundObjs[j], normalX, normalY, gameTime->GetDeltaTime());
							if (collideTime < gameTime->GetDeltaTime())
								_items[i]->UpdateCollision(_groundObjs[j], normalX, normalY, collideTime, gameTime->GetDeltaTime() - collideTime);
						}
					}
				}

				// Cập nhật đạn của quái, xóa các đạn chuyển sang trạng thái DIE
				int countBulletEnemy = _bulletsEnemy.size();
				for (int i = 0; i < countBulletEnemy; i++)
				{
					if (_bulletsEnemy[i]->_typeID != ID_BULLET_CUTMAN)
					{
						_bulletsEnemy[i]->Update(gameTime);

						// Kiểm tra quái va chạm với tường, gạch đá trên màn  hình
						for (int j = 0; j < _groundObjs.size(); j++)
						{
							collideTime = CheckCollision(_bulletsEnemy[i], _groundObjs[j], normalX, normalY, gameTime->GetDeltaTime());
							if (collideTime < gameTime->GetDeltaTime())
								((CBullet*)_bulletsEnemy[i])->OnCollideWith(_groundObjs[j], normalX, normalY, collideTime);
						}
					}

					if (_bulletsEnemy[i]->GetState() == BULLET_BASE_STATE::DIE || !_bulletsEnemy[i]->GetBox().IntersecWith(CBox(_camera->GetViewport())))
					{
						_bulletsEnemy[i]->Destroy();
						_bulletsEnemy.erase(_bulletsEnemy.begin() + i);
						countBulletEnemy -= 1;
						i -= 1;
					}
				}

				//Kiểm tra và dời khung màn hình
				if (_cameraPath->IsHorizontalLine())
				{
					_screenPosition.x = _rockman._position.x;
					_screenPosition = _cameraPath->CalculatePointOnPathWith(_screenPosition);
				}
				if (_cameraPath->CanMoveLeft() || _cameraPath->CanMoveRight())
				{
					if (_pointAfterDoor.x != 0 && _rockman._position.x > _pointDoor.x)
					{
						if (_rockman.GetBox()._x < _pointAfterDoor.x)
							_screenPosition.x = _pointAfterDoor.x;
					}
					else
						_screenPosition.x = _rockman._position.x;

					if (_pointBeforeDoor.x != 0 && _screenPosition.x > _pointBeforeDoor.x&&_rockman._position.x<_pointDoor.x)
						_screenPosition.x = _pointBeforeDoor.x;

					_screenPosition = _cameraPath->CalculatePointOnPathWith(_screenPosition);
				}
				if (_cameraPath->CanMoveUp() && _rockman._position.y >= _screenPosition.y + SCREEN_HEIGHT / 2)
				{
					if (_rockman._behave == Behave::STAIR && (
						_rockman._position.y >= _cameraPath->GetNextPoint().y && _cameraPath->IsHorizontalLine()
						|| _rockman._position.y > __max(_cameraPath->GetEndPoint().y, _cameraPath->GetStartPoint().y) && _cameraPath->IsVerticalLine()))
					{
						if (_cameraPath->IsHorizontalLine())
						{
							if (_cameraPath->GetEndPoint() == _screenPosition)
							{
								_newScreenPosition = _cameraPath->GetNextPoint() + Vector2(0, SCREEN_HEIGHT / 2);
							}
							else if (_cameraPath->GetStartPoint() == _screenPosition)
							{
								_newScreenPosition = _cameraPath->GetPreviousPoint() + Vector2(0, SCREEN_HEIGHT / 2);
							}
						}
						else	if (_cameraPath->GetEndPoint().y > _cameraPath->GetStartPoint().y)
						{
							float distance = abs(_cameraPath->GetEndPoint().y - _cameraPath->GetNextPoint().y);
							_newScreenPosition = _cameraPath->GetEndPoint() + Vector2(0, distance > SCREEN_HEIGHT ? SCREEN_HEIGHT / 2 : distance);
						}
						else
						{
							float distance = abs(_cameraPath->GetPreviousPoint().y - _cameraPath->GetStartPoint().y);
							_newScreenPosition = _cameraPath->GetStartPoint() + Vector2(0, distance > SCREEN_HEIGHT ? SCREEN_HEIGHT / 2 : distance);
						}
						_enemies.clear();
						_bulletsEnemy.clear();
						_bulletsRockman.clear();
						_items.clear();
						_rockman._canFire = true;

						_changingScreen = 1;
						_changeScreenDirection = CDirection::ON_UP;
						_rockman.ChangeScreen(CDirection::ON_UP);
					}
				}
				if (_cameraPath->CanMoveDown() && _rockman._position.y <= _screenPosition.y - SCREEN_HEIGHT / 2)
				{
					if (((_cameraPath->IsHorizontalLine() && (_rockman._position.y <= _cameraPath->GetNextPoint().y || _rockman._position.y <= _cameraPath->GetPreviousPoint().y)))
						|| _cameraPath->IsVerticalLine() && _rockman._position.y < __min(_cameraPath->GetEndPoint().y, _cameraPath->GetStartPoint().y))
					{
						if (_cameraPath->IsHorizontalLine())
						{
							if (_cameraPath->GetEndPoint() == _screenPosition)
							{
								_newScreenPosition = _cameraPath->GetNextOfNextPoint() + Vector2(0, SCREEN_HEIGHT / 2);
							}
							else if (_cameraPath->GetStartPoint() == _screenPosition)
							{
								_newScreenPosition = _cameraPath->GetPrevOfPreviousPoint() + Vector2(0, SCREEN_HEIGHT / 2);
							}
						}
						else
						{
							if (_cameraPath->GetEndPoint().y > _cameraPath->GetStartPoint().y)
							{
								float distance = abs(_cameraPath->GetStartPoint().y - _cameraPath->GetPreviousPoint().y);
								if (abs(distance) < SCREEN_HEIGHT)
									_newScreenPosition = _cameraPath->GetPreviousPoint();
								else
									_newScreenPosition = _cameraPath->GetStartPoint() - Vector2(0, SCREEN_HEIGHT / 2);
							}
							else
							{
								float distance = abs(_cameraPath->GetNextPoint().y - _cameraPath->GetEndPoint().y);
								if (abs(distance) < SCREEN_HEIGHT)
									_newScreenPosition = _cameraPath->GetNextPoint();
								else
									_newScreenPosition = _cameraPath->GetNextPoint() + Vector2(0, SCREEN_HEIGHT / 2);
							}
						}
						_changingScreen = 1;

						_enemies.clear();
						_bulletsEnemy.clear();
						_bulletsRockman.clear();
						_items.clear();
						_rockman._canFire = true;

						_changeScreenDirection = CDirection::ON_DOWN;
						_rockman.ChangeScreen(CDirection::ON_DOWN);
					}
				}
				else
				{
					if (_rockman._position.y <= _screenPosition.y - SCREEN_HEIGHT / 2)
					{
						_rockman.Attack(0, true);
					}
				}

				_camera->SetPositionCamera(Vector2(_screenPosition.x - SCREEN_WIDTH / 2, _screenPosition.y + SCREEN_HEIGHT / 2));

				// Đảm bảo Rockman không chạy quá màn hình chiều ngang
				if (_rockman._position.x <= _camera->GetPositionCamera().x + _rockman.GetBox()._width / 2)
					_rockman._position.x = _camera->GetPositionCamera().x + _rockman.GetBox()._width / 2;
				if (_rockman._position.x >= _camera->GetPositionCamera().x + SCREEN_WIDTH - _rockman.GetBox()._width / 2)
					_rockman._position.x = _camera->GetPositionCamera().x + SCREEN_WIDTH - _rockman.GetBox()._width / 2;
				CExplodingEffectManager::Update(gameTime);
			}
			else
			{
				ChangeScreen(_changeScreenDirection);
				_screenPosition = _cameraPath->CalculatePointOnPathWith(_screenPosition);
				_camera->SetPositionCamera(Vector2(_screenPosition.x - SCREEN_WIDTH / 2, _screenPosition.y + SCREEN_HEIGHT / 2));
			}

			for (int i = 0; i < _powerEnegies.size(); i++)
			{
				_powerEnegies[i]->UpdateCamera(_camera);

				switch (_powerEnegies[i]->_typeID)
				{
				case ID_BAR_BLOOD_ROCKMAN:
					_powerEnegies[i]->SetValue(_rockman._blood);
					break;
				case ID_BAR_WEAPONS_CUT:
				case ID_BAR_WEAPONS_GUTS:
				case ID_BAR_WEAPONS_BOOM:
					_powerEnegies[i]->SetValue(_rockman.GetWeapons(_rockman.GetCurrentSkill()));
					break;
				case ID_BAR_BLOOD_CUTMAN:
				case ID_BAR_BLOOD_GUTSMAN:
				case ID_BAR_BLOOD_BOOMMAN:
					if (_prepareForBoss == 3)
						_powerEnegies[i]->SetValue(__max(0, _powerEnegies[i]->GetMaster()->_blood));
					break;
				}
				_powerEnegies[i]->Update(gameTime);

				if (!_powerEnegies[i]->IsCompleted())
				{
					_playState = PlayState::PAUSE;
				}
			}
#pragma endregion
		}
		else if (_playState == PlayState::GAMEOVER)
		{
#pragma region Xử lý game over, có thể là Rockman mất mạng hoặc GameOver
			CInput::GetInstance()->Active();
			int startIndex = _cameraPath->GetStartIndex();
			LoadMap();

			if (_rockman.GetLife() == -1)
			{
				_isFinished = true;
				_nextScreen = new CGameOver(CGameInfo::GetInstance()->GetScore());
			}
			else
			{
				FindScene(startIndex);

				// Khởi động trạng thái
				_playState = PlayState::READY;
				_deltaTime = 0;
				_rockman._behave = Behave::START;
				_prepareForBoss = 0;
				_isBossDied = false;

				_enemies.clear();
				_bulletsRockman.clear();
				_bulletsEnemy.clear();
				_powerEnegies.clear();
				_items.clear();

				_pointAfterDoor = Vector2(0, 0);
				_pointBeforeDoor = Vector2(0, 0);
				_shakePointRand = Vector2(0.0f, 0.0f);
				CInput::GetInstance()->Active();

				switch (CGameInfo::GetInstance()->GetLevel())
				{
				case ID_LEVEL_BOOM:
					ResourceManager::PlayASound(ID_SOUND_BOMBMAN_STAGE);
					break;
				case ID_LEVEL_CUT:
					ResourceManager::PlayASound(ID_SOUND_CUTMAN_STAGE);
					break;
				case ID_LEVEL_GUTS:
					ResourceManager::PlayASound(ID_SOUND_GUTSMAN_STAGE);
					break;
				}
			}
#pragma endregion
		}
		else if (_playState == PlayState::PAUSE)
		{
#pragma region Xử lý dừng game
			bool isCompleted = true;
			for (int i = 0; i < _powerEnegies.size(); i++)
			{
				_powerEnegies[i]->Update(gameTime);
				if (!_powerEnegies[i]->IsCompleted())
					isCompleted = false;
			}
			if (isCompleted)
			{
				CInput::GetInstance()->Active();
				_playState = PlayState::PLAYING;
			}
#pragma endregion

		}
		else if (_playState == PlayState::WIN)
		{
#pragma region Xử lý chiến thắng game

			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 6000)
			{

				// Vẽ clear point
				if (_deltaTime >= 6000 && _deltaTime < 10000)
				{
					_strClearPoint = CGameInfo::GetInstance()->to_string(1000, 6);
					if (_deltaTime > 7000)
						_deltaTime = 10000;
				}

				// Vẽ điểm tăng dần
				if (_deltaTime >= 10000 && _deltaTime < 20000)
				{
					_deltaClearPoint += 200;
					ResourceManager::PlayASound(ID_EFFECT_ANIMATION_SCORE);
					CGameInfo::GetInstance()->SetScore(CGameInfo::GetInstance()->GetScore() + 200);
					if (_deltaClearPoint > _clearPoint)
					{
						_deltaClearPoint = _clearPoint;
						CGameInfo::GetInstance()->SetScore(CGameInfo::GetInstance()->GetScore() - 200);
						_totalScore = CGameInfo::GetInstance()->GetScore();
						_deltaTime = 20000;
					}
					_strClearPoint = CGameInfo::GetInstance()->to_string(_deltaClearPoint, 6);
				}

				// Vẽ bonus, dừng khoảng 1s
				if (_deltaTime >= 20000 && _deltaTime < 30000)
				{
					ResourceManager::StopSound(ID_EFFECT_ANIMATION_SCORE);
					_strBonus = std::to_string(CGameInfo::GetInstance()->GetBonusValue()) + "X00";
					_strTotalBonusScore = CGameInfo::GetInstance()->to_string(0, 6);
					if (_deltaTime > 20100)
						_deltaTime = 30000;
				}

				// Vẽ bonus tăng dần
				if (_deltaTime >= 30000 && _deltaTime < 50000)
				{
					_strBonus = std::to_string(CGameInfo::GetInstance()->GetBonusValue()) + "X" + std::to_string(CGameInfo::GetInstance()->GetTotalBonus());
					_strTotalBonusScore = CGameInfo::GetInstance()->to_string(CGameInfo::GetInstance()->GetBonusValue()*CGameInfo::GetInstance()->GetTotalBonus(), 6);

					CGameInfo::GetInstance()->SetScore(_totalScore + CGameInfo::GetInstance()->GetTotalBonus()* CGameInfo::GetInstance()->GetBonusValue());

					if (_deltaTime > 35000)
					{
						_isFinished = true;
						_nextScreen = new CGameMenu();
						ResourceManager::StopSound(ID_SOUND_BOSS);
						switch (CGameInfo::GetInstance()->GetLevel())
						{
						case ID_LEVEL_CUT:
							CGameInfo::GetInstance()->AddSkill(Skill::CUT);
							break;
						case ID_LEVEL_GUTS:
							CGameInfo::GetInstance()->AddSkill(Skill::GUTS);
							break;
						case ID_LEVEL_BOOM:
							CGameInfo::GetInstance()->AddSkill(Skill::BOOM);
							break;

						}
						CGameInfo::GetInstance()->SetBonus(0);
						CGameInfo::GetInstance()->Save();
						CGameInfo::GetInstance()->Load();
					}
				}

#pragma endregion
			}
		}
	}
}

void CPlayScreen::Render(CGameTime* gameTime, CGraphics* graphics)
{
	Vector2 oldCameraPoint = _camera->GetPositionCamera();

	if (Asset::GetInstance()->__is_require_shake_screen)
	{
		_deltatTimeShakingScreen += gameTime->GetDeltaTime();
		if (_deltatTimeShakingScreen > 50)
		{
			_deltatTimeShakingScreen = 0;
			_shakePointRand.x = rand() % 7 + 1;
			_shakePointRand.y = rand() % 3 + 1;

			_camera->SetPositionCamera(oldCameraPoint + _shakePointRand);
		}
	}
	RenderBackground(graphics, _camera->GetViewport());

	if (_prepareForBoss == 1)
	{
		graphics->Draw(_spriteIntroBoss.GetTexture(), _spriteIntroBoss.GetDestinationRectangle(), _cameraPath->GetEndPoint(), true, Vector2(1.0f, 1.0f), SpriteEffects::NONE);
		_spriteIntroBoss.Update(gameTime);
	}

	for (int i = 0; i < _groundObjs.size(); i++)
		_groundObjs[i]->Render(gameTime, graphics);
	if (_door != NULL)
		_door->Render(gameTime, graphics);

	_camera->SetPositionCamera(oldCameraPoint);

	for (int i = 0; i < _bulletsRockman.size(); i++)
		_bulletsRockman[i]->Render(gameTime, graphics);
	for (int i = 0; i < _bulletsEnemy.size(); i++)
		_bulletsEnemy[i]->Render(gameTime, graphics);
	for (int i = 0; i < _enemies.size(); i++)
		_enemies[i]->Render(gameTime, graphics);
	for (int i = 0; i < _items.size(); i++)
		_items[i]->Render(gameTime, graphics);
	for (int i = 0; i < _elevators.size(); i++)
		_elevators[i]->Render(gameTime, graphics);
	if (_playState != PlayState::WIN)
		for (int i = 0; i < _powerEnegies.size(); i++)
			_powerEnegies[i]->Render(gameTime, graphics);
	_rockman.Render(gameTime, graphics);

	// Vẽ điểm màn chơi
	if (_playState == PlayState::READY)
		graphics->DrawString("READY", Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2, _camera->GetPositionCamera().y - SCREEN_HEIGHT / 2), _defaultStringColor, true);
	else
		graphics->DrawString(CGameInfo::GetInstance()->to_string(CGameInfo::GetInstance()->GetScore(), 7), Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2, _camera->GetPositionCamera().y - FONT_SIZE), _defaultStringColor, true);

	// Vẽ điểm khi WIN GAME
	if (_playState == PlayState::WIN)
	{
		graphics->DrawString("CLEAR", Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2 - FONT_SIZE * 2, _camera->GetPositionCamera().y - FONT_SIZE * 6), _defaultStringColor, true);
		graphics->DrawString("POINTS", Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2 + FONT_SIZE, _camera->GetPositionCamera().y - FONT_SIZE * 7), _defaultStringColor, true);
		graphics->DrawString(_strClearPoint, Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2, _camera->GetPositionCamera().y - FONT_SIZE * 9), _defaultStringColor, true);
		if (_strBonus != "")
		{
			graphics->DrawString(_strBonus, Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2 + FONT_SIZE, _camera->GetPositionCamera().y - FONT_SIZE * 11), _defaultStringColor, true);
			graphics->DrawString("BONUS", Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2 + FONT_SIZE, _camera->GetPositionCamera().y - FONT_SIZE * 12), _defaultStringColor, true);
			graphics->DrawString(_strTotalBonusScore, Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2 + FONT_SIZE, _camera->GetPositionCamera().y - FONT_SIZE * 14), _defaultStringColor, true);
			graphics->Draw(ResourceManager::GetSprite(ID_SPRITE_ITEM_BONUS_RED).GetTexture(), ResourceManager::GetSprite(ID_SPRITE_ITEM_BONUS_RED).GetDestinationRectangle(), Vector2(_camera->GetPositionCamera().x + SCREEN_WIDTH / 2 - 4 * FONT_SIZE, _camera->GetPositionCamera().y - FONT_SIZE * 12), true);
		}
	}

	if (!_isStopScreen)
		CExplodingEffectManager::Render(gameTime, graphics);

}

void CPlayScreen::LoadMap()
{
#pragma region Chọn màn chơi

	wchar_t* mapData;
	wchar_t* mapImage;

	switch (CGameInfo::GetInstance()->GetLevel())
	{
	case ID_LEVEL_CUT:
		mapData = MAP_DATA_CUT_MAN;
		mapImage = MAP_IMAGE_CUT_MAN;
		break;
	case ID_LEVEL_GUTS:
		mapData = MAP_DATA_GUTS_MAN;
		mapImage = MAP_IMAGE_GUTS_MAN;
		break;
	case ID_LEVEL_BOOM:
		mapData = MAP_DATA_BOOM_MAN;
		mapImage = MAP_IMAGE_BOOM_MAN;
		break;
	default:return;
	}
	_textureBkg = CTexture(mapImage, D3DCOLOR_XRGB(255, 255, 255));

#pragma endregion

#pragma region Chuẩn bị một số biến cần thiết cho việc đọc dữ liệu từ file .txt

	ifstream fs;		// Luồng đọc file map
	string line;		// Chuỗi đọc file map

	// Mở file và đọc, nếu không được thì out
	fs.open(mapData, ios::in);
	if (!fs.is_open())
	{
		OutputDebugString(L"Can not open map file");
		return;
	}

	istringstream iss;								// Luồng string đọc từ file
	int countObj, countNode = 0;					// Số lượng phần tử đối tượng trên màn hình
	map<int, CGameObject*> objects;						// Danh sách các đối tượng trên màn hình
	map<int, CQuadNode*> lstNodes;
	vector<int> objectIDs;							// Danh sách các objectID
	// Các biến lưu giá trị được lưu trữ của một CObject
	int nodeID, objID, typeID, posX, posY, width, height, posXCollide, posYCollide, widthCollide, heightCollide;

#pragma endregion

#pragma region Tiến hành đọc dữ liệu từ file .txt

#pragma region Lấy thông tin ma trận tile

	getline(fs, line);
	if (line.compare("#Tile_Matrix") == 0)
	{
		getline(fs, line);								// Bỏ qua dòng "Total_Row	Total_Column	Total_Tile"
		getline(fs, line);
		iss.clear();
		iss.str(line);
		iss >> _countRow >> _countColumn >> _totalTile;	// Đẩy giá trị tổng số dòng, cột, tổng số tile vào biến
		getline(fs, line);								// Bỏ qua dòng "#Tile_Matrix_Value"

		// Tạo mảng hai chiều lưu ma trận tile
		for (int i = 0; i < _countRow; i++)
		{
			vector<int> row;
			row.resize(_countColumn);
			_tileMatrix.push_back(row);
		}

		// Tiến hành đọc dữ liệu
		for (int i = 0; i < _countRow; i++)
		{
			getline(fs, line);
			iss.clear();
			iss.str(line);
			for (int j = 0; j < _countColumn; j++)
				iss >> _tileMatrix[i][j];
		}
		getline(fs, line);					// Bỏ qua dòng "#Tile_Matrix_End"
	}

#pragma endregion

#pragma region Lấy danh sách các đối tượng

	vector<Vector2> fallingPoints;

	getline(fs, line);
	if (line.compare("#Objects") == 0)
	{
		getline(fs, line);					// Bỏ quan dòng "ObjCount"
		getline(fs, line);
		iss.clear();
		iss.str(line);
		iss >> countObj;
		getline(fs, line);					// Bỏ qua dòng "ObjID	TypeID	PosX	PosY	Width	Height PosXCollide	PosYCollide	WidthCollide	HeightCollide"

		// Đọc danh sách các đối tượng
		for (int i = 0; i < countObj; i++)
		{
			getline(fs, line);
			iss.clear();
			iss.str(line);
			iss >> objID >> typeID >> posX >> posY >> width >> height >> posXCollide >> posYCollide >> widthCollide >> heightCollide;
			CGameObject* obj;
			switch (typeID)
			{
			case ID_ENEMY_BALL:
				obj = new  CEnemyBall(objID, typeID,
					ResourceManager::GetSprite(ID_SPRITE_ENEMY_BALL),
					ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
					50.f / 1000.0f,
					Vector2((float)posX, (float)posY), DAME_ENEMY_BALL, BLOOD_ENEMY_BALL, 4 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_BOOM_BLUE:
				obj = new  CEnemyBoom(objID, typeID,
					ResourceManager::GetSprite(ID_SPRITE_ENEMY_BOOM_BLUE),
					ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
					100.f / 1000.0f,
					Vector2((float)posX, (float)posY), DAME_ENEMY_BOOM, BLOOD_ENEMY_BOOM, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;

			case ID_ENEMY_EYE_RED_UP:
				obj = new  CEnemyEye(1);
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_EYE_RED_RIGHT:
				obj = new  CEnemyEye(0);
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_FISH_ORANGE:
				obj = new  CEnemyFish(posY, _cameraPath);
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_INK_RED:
				obj = new  CEnemyInk(0);
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_MACHINE_AUTO_BLUE_TOP:
				obj = new  CEnemyMachineAuto(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_MACHINE_AUTO_BLUE), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), ID_SPRITE_BULLET_BLUE_COLOR, ENEMYMACHINEAUTO_ORIENTATION::TOP,
					Vector2(0 / 1000.0f, 0),
					Vector2((float)posX, (float)posY), DAME_ENEMY_MACHINE_AUTO, BLOOD_ENEMY_MACHINE_AUTO, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_MACHINE_AUTO_BLUE_BOTTOM:
				obj = new  CEnemyMachineAuto(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_MACHINE_AUTO_BLUE), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), ID_SPRITE_BULLET_BLUE_COLOR, ENEMYMACHINEAUTO_ORIENTATION::BOTTOM,
					Vector2(0 / 1000.0f, 0),
					Vector2((float)posX, (float)posY), DAME_ENEMY_MACHINE_AUTO, BLOOD_ENEMY_MACHINE_AUTO, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_MACHINE_ORANGE:
				obj = new  CEnemyMachine();
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_NINJA_GREEN:
				obj = new  CEnemyNinja();
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_CUT:

				break;
			case ID_ENEMY_INK_BLUE:
				obj = new  CEnemyInk(1);
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_MACHINE_AUTO_ORGANGE_TOP:
				obj = new  CEnemyMachineAuto(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_MACHINE_AUTO_ORGANGE), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), ID_SPRITE_BULLET_ORANGE_COLOR, ENEMYMACHINEAUTO_ORIENTATION::TOP,
					Vector2(0 / 1000.0f, 0),
					Vector2((float)posX, (float)posY), DAME_ENEMY_MACHINE_AUTO, BLOOD_ENEMY_MACHINE_AUTO, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_MACHINE_AUTO_ORGANGE_BOTTOM:
				obj = new  CEnemyMachineAuto(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_MACHINE_AUTO_ORGANGE), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), ID_SPRITE_BULLET_ORANGE_COLOR, ENEMYMACHINEAUTO_ORIENTATION::BOTTOM,
					Vector2(0 / 1000.0f, 0),
					Vector2((float)posX, (float)posY), DAME_ENEMY_MACHINE_AUTO, BLOOD_ENEMY_MACHINE_AUTO, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_WALL_SHOOTER_LEFT:
				obj = new  CEnemyWallShooter(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_WALL_SHOOTER), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), ENEMYWALLSHOOTER_ORIENTATION::LEFT,
					Vector2(0 / 1000.0f, 0),
					Vector2((float)posX, (float)posY), DAME_ENEMY_WALL_SHOOTER, BLOOD_ENEMY_WALL_SHOOTER, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_WALL_SHOOTER_RIGHT:
				obj = new  CEnemyWallShooter(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_WALL_SHOOTER), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE), ENEMYWALLSHOOTER_ORIENTATION::RIGHT,
					Vector2(0 / 1000.0f, 0),
					Vector2((float)posX, (float)posY), DAME_ENEMY_WALL_SHOOTER, BLOOD_ENEMY_WALL_SHOOTER, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_ROBOT_RED:
				obj = new  CEnemyRobot(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_ROBOT_RED), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
					Vector2((float)posX, (float)posY), DAME_ENEMY_ROBOT, BLOOD_ENEMY_ROBOT, 7.5 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));

				break;
			case ID_ENEMY_BUBBLE_BLUE:
				obj = new  CEnemyBubble(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_BUBBLE_BLUE), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
					Vector2(50.f / 1000.0f, 0.0f / 1000.0f),
					Vector2((float)posX, (float)posY), DAME_ENEMY_BUBBLE, BLOOD_ENEMY_BUBBLE, 2.5* SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_BUBBLE_GREEN:
				obj = new  CEnemyBubble(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_BUBBLE_GREEN), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
					Vector2(50.f / 1000.0f, 0.0f / 1000.0f),
					Vector2((float)posX, (float)posY), DAME_ENEMY_BUBBLE, BLOOD_ENEMY_BUBBLE, 2.5 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ELEVATOR:
				obj = new  CElevator(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ELEVATOR),
					50.0f / 1000.0f,
					Vector2((float)posX, (float)posY));
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));

				break;
			case ID_BLOCK_TROUBLE_OF_ELEVATOR:
				obj = new  CBlock();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_HAT:
				obj = new  CEnemyHat();
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_ROBOT_BLUE:
				obj = new  CEnemyRobot(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_ROBOT_BLUE), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
					Vector2((float)posX, (float)posY), DAME_ENEMY_ROBOT, BLOOD_ENEMY_ROBOT, 7.5 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ENEMY_WORKER:
				obj = new  CEnemyWorker(objID, typeID, ResourceManager::GetSprite(ID_SPRITE_ENEMY_WORKER), ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
					50.0f / 1000.0f,
					Vector2((float)posX, (float)posY), DAME_ENEMY_WORKER, BLOOD_ENEMY_WORKER, 1 * SCORE_DEFAULT);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_BLOCK:
				obj = new  CBlock();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_STAIR:
				obj = new  CStair();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_DOOR1_CUTMAN:
			case ID_DOOR2_CUTMAN:
				obj = new  CDoor(ResourceManager::GetSprite(ID_SPRITE_DOOR_CUTMAN));
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_DOOR1_GUTSMAN:
			case ID_DOOR2_GUTSMAN:
				obj = new  CDoor(ResourceManager::GetSprite(ID_SPRITE_DOOR_GUTSMAN));
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_DOOR1_BOOMMAN:
				obj = new  CDoor(ResourceManager::GetSprite(ID_SPRITE_DOOR1_BOOMMAN));
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_DOOR2_BOOMMAN:
				obj = new  CDoor(ResourceManager::GetSprite(ID_SPRITE_DOOR2_BOOMMAN));
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ITEM_LIFE:
			case ID_ITEM_BLOOD_BIG:
			case ID_ITEM_BLOOD_SMALL:
			case ID_ITEM_MANA_BIG:
			case ID_ITEM_MANA_SMALL:
				obj = new  CItem(typeID, Vector2((float)posX, (float)posY), false, true);
				obj->_id = objID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_ROCK_IN_GUT_STAGE:
			case ID_ROCK:
				obj = new  CRock();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_DIE_ARROW:
				obj = new  CDieArrow();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_CUTMAN:
				obj = new  CCutman();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_GUTSMAN:
				obj = new  CGutsMan();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->Initlize();
				obj->_size = Vector2((float)width, (float)height);
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_BOOMMAN:
				obj = new  CBoomMan();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->Initlize();
				obj->_size = Vector2((float)width, (float)height);
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			case ID_FALLING_POINT:
				obj = new  CBlock();
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));

				// Lọc lấy danh sách các điểm rơi
				fallingPoints.push_back(obj->_position);
				break;
			case ID_ENEMY_SNAPPER:
				obj = new  CEnemySnapper();
				obj->_position = Vector2((float)posX, (float)posY);
				obj->_id = objID;
				obj->_typeID = typeID;
				obj->_size = Vector2((float)width, (float)height);
				obj->Initlize();
				obj->SetCollideRegion(posXCollide, posYCollide, widthCollide, heightCollide);
				objects.insert(pair<int, CGameObject*>(objID, obj));
				break;
			}
		}
		getline(fs, line);					// Bỏ qua dòng "#Objects_End"
	}

#pragma endregion

#pragma region Đọc thông tin ma trận ma chạm

	getline(fs, line);
	if (line.compare("#Quadtree_Collision") == 0)
	{
		getline(fs, line);						// Bỏ qua dòng "NodeCount"
		getline(fs, line);
		iss.clear();
		iss.str(line);
		iss >> countNode;

		getline(fs, line);						// Bỏ qua dòng "NodeID	PosX	PosY	Width	Height	ObjectCount	ObjectIDs"
		for (int i = 0; i < countNode; i++)
		{
			getline(fs, line);
			iss.clear();
			iss.str(line);
			iss >> nodeID >> posX >> posY >> width >> height >> countObj;
			for (int j = 0; j < countObj; j++)
			{
				iss >> objID;
				objectIDs.push_back(objID);
			}
			CQuadNode *tmpNode = new CQuadNode(nodeID, Vector2(posX, posY), Vector2(width, height), objectIDs, objects);
			lstNodes.insert(pair<int, CQuadNode*>(nodeID, tmpNode));
			objectIDs.clear();
		}
	}
	getline(fs, line);							// Bỏ qua dòng "#Quadtree_Collision_End"

#pragma endregion

#pragma region Đọc thông tin Camera Paths

	getline(fs, line);
	if (line.compare("#Camera_Path_Point") == 0)
	{
		getline(fs, line);
		iss.clear();
		iss.str(line);
		iss >> countNode;		// Đếm số lượng camera path node
		vector<Vector2> cameraPaths;
		for (int i = 0; i < countNode; i++)
		{
			getline(fs, line);
			iss.clear();
			iss.str(line);
			iss >> posX >> posY;
			cameraPaths.push_back(Vector2(posX, posY));
		}
		if (cameraPaths.size()>0)
			_cameraPath->SetPaths(cameraPaths);

		getline(fs, line);	// Bỏ qua dòng #Camera_Path_Point_End

		// Dựng cảnh màn chơi
		_sceneInfo.BuildScene(fallingPoints, cameraPaths);

		FindScene(19);
	}

#pragma endregion

	fs.close();

#pragma region Dựng lại cây tứ phân va chạm

	map<int, CQuadNode*>::iterator it;

	for (it = lstNodes.begin(); it != lstNodes.end(); it++)
	{
		if (it == lstNodes.begin())
			_quadNodeCollision = *it->second;
		else if (it != lstNodes.end())
			_quadNodeCollision.AddNode(it->second);
	}
#pragma endregion

#pragma endregion

	switch (CGameInfo::GetInstance()->GetLevel())
	{
	case ID_LEVEL_CUT:
		ResourceManager::StopSound(ID_SOUND_STAGE_SELECT);
		ResourceManager::PlayASound(ID_SOUND_CUTMAN_STAGE);
		break;
	case ID_LEVEL_GUTS:
		ResourceManager::StopSound(ID_SOUND_STAGE_SELECT);
		ResourceManager::PlayASound(ID_SOUND_GUTSMAN_STAGE);
		break;
	case ID_LEVEL_BOOM:
		ResourceManager::StopSound(ID_SOUND_STAGE_SELECT);
		ResourceManager::PlayASound(ID_SOUND_BOMBMAN_STAGE);
		break;
	default:return;
	}
}

void CPlayScreen::RenderBackground(CGraphics* graphics, Rect viewport)
{
	int startRow = floor(viewport.bottom / TILE_SIZE);
	int endRow = floor(viewport.top / TILE_SIZE) + 1;
	int startColumn = floor(viewport.left / TILE_SIZE);
	int endColumn = floor(viewport.right / TILE_SIZE) + 1;

	int bitmapColumn = (int)sqrt((double)_totalTile) + 1;

	if (startColumn < 0)
		startColumn = 0;
	if (startRow < 0)
		startRow = 0;
	if (endColumn > _countColumn)
		endColumn = _countColumn;
	if (endRow > _countRow)
		endRow = _countRow;
	Vector2 startDrawPos = Vector2(startColumn*TILE_SIZE + TILE_SIZE / 2, endRow*TILE_SIZE - TILE_SIZE / 2) + _shakePointRand;
	for (int i = endRow; i > startRow; i--)
	{
		for (int j = startColumn; j < endColumn; j++)
		{
			Rect desRect;
			desRect.top = (_tileMatrix[_countRow - i][j] / bitmapColumn)* TILE_SIZE;
			desRect.left = (_tileMatrix[_countRow - i][j] % bitmapColumn)*TILE_SIZE;
			desRect.right = desRect.left + TILE_SIZE;
			desRect.bottom = desRect.top + TILE_SIZE;

			graphics->Draw(_textureBkg.GetTexture(), desRect, startDrawPos, true, Vector2(1.0f, 1.0f), SpriteEffects::NONE);

			startDrawPos.x += TILE_SIZE;
		}
		startDrawPos.y -= TILE_SIZE;
		startDrawPos.x -= TILE_SIZE*abs(startColumn - endColumn);
	}
}

float CPlayScreen::CheckCollision(CGameObject* obj1, CGameObject* obj2, CDirection &normalX, CDirection &normalY, float frameTime)
{
	float timeCollision = frameTime;
	CBox moveBox = obj1->GetBox();
	CBox staticBox = obj2->GetBox();

	// Cố định lại box của object và tính lại vận tốc của box nội tại
	moveBox._vx -= staticBox._vx;
	moveBox._vy -= staticBox._vy;
	staticBox._vx = 0;
	staticBox._vy = 0;


	// tạo broad phase box để kiểm tra tổng quát với đối tượng đứng yên obj
	// Nếu có xảy ra va chạm, thì tiến hành kiểm tra bằng AABBSweep và đưa ra thời gian va chạm
	CBox broadBox = CCollision::GetSweptBox(moveBox, frameTime);
	if (CCollision::AABBCheck(staticBox, broadBox))
		timeCollision = CCollision::SweepAABB(moveBox, staticBox, normalX, normalY, frameTime);

	return timeCollision;
}

void CPlayScreen::ChangeScreen(CDirection direction)
{
	if (_changingScreen == 1)
	{
		switch (direction)
		{
		case ON_UP:
			_screenPosition.y += 10;
			if (_screenPosition.y >= _newScreenPosition.y)
			{
				_changingScreen = 2;
				_screenPosition.y = _newScreenPosition.y + 1;
				_rockman.ChangeScreen(CDirection::NONE_DIRECT);
			}
			break;
		case ON_DOWN:_screenPosition.y -= 10;
			if (_screenPosition.y <= _newScreenPosition.y)
			{
				_changingScreen = 2;
				_screenPosition.y = _newScreenPosition.y;
				_rockman.ChangeScreen(CDirection::NONE_DIRECT);
				if (_screenPosition != _cameraPath->GetPaths()[_cameraPath->GetPaths().size() - 1])
					CInput::GetInstance()->Active();
			}
			break;
		case ON_RIGHT:
			_screenPosition.x += 5;
			if (_screenPosition.x >= _newScreenPosition.x)
			{
				_changingScreen = 2;
				_screenPosition.x = _newScreenPosition.x;
				_pointBeforeDoor = Vector2(0, 0);
				if (_screenPosition != _cameraPath->GetPaths()[_cameraPath->GetPaths().size() - 1])
					CInput::GetInstance()->Active();
			}
			break;
		case ON_LEFT:
			break;
		case INSIDE:
			break;
		}
	}
}

void CPlayScreen::FindScene(unsigned int startIndex)
{
	// Build lại camera path và lấy điêm rơi thích hợp
	map<int, Vector2> sceneInfo = _sceneInfo.GetScene(startIndex);
	_cameraPath->SetStartIndex(sceneInfo.begin()->first);
	_cameraPath->SetEndIndex(sceneInfo.begin()->first + 1);

	// Chọn điểm đặt màn hình và rockman
	int distanceY = _cameraPath->GetStartPoint().y - _cameraPath->GetEndPoint().y;
	if (distanceY == 0)
	{
		_cameraPath->SetCameraPointOnPath(_cameraPath->GetPaths()[sceneInfo.begin()->first]);

		_rockman.ResetAll();
		_rockman._position = sceneInfo.begin()->second;
		_rockman._position.y += SCREEN_HEIGHT / 2;

		_screenPosition = _rockman._position;
		_screenPosition = _cameraPath->CalculatePointOnPathWith(_screenPosition);
		_camera->SetPositionCamera(Vector2(_screenPosition.x - SCREEN_WIDTH / 2, _screenPosition.y + SCREEN_HEIGHT / 2));
	}
	else if (distanceY > 0)
	{
		Vector2 pointOnPath = _cameraPath->GetEndPoint();
		pointOnPath.y += SCREEN_HEIGHT / 2;
		_cameraPath->SetCameraPointOnPath(pointOnPath);

		_rockman.ResetAll();
		_rockman._position = sceneInfo.begin()->second;
		_rockman._position.y += SCREEN_HEIGHT;

		_screenPosition = pointOnPath;
		_camera->SetPositionCamera(Vector2(_screenPosition.x - SCREEN_WIDTH / 2, _screenPosition.y + SCREEN_HEIGHT / 2));
	}
	else {
		Vector2 pointOnPath = _cameraPath->GetStartPoint();
		pointOnPath.y += SCREEN_HEIGHT / 2;
		_cameraPath->SetCameraPointOnPath(pointOnPath);

		_rockman.ResetAll();
		_rockman._position = sceneInfo.begin()->second;
		_rockman._position.y += SCREEN_HEIGHT;

		_screenPosition = pointOnPath;
		_camera->SetPositionCamera(Vector2(_screenPosition.x - SCREEN_WIDTH / 2, _screenPosition.y + SCREEN_HEIGHT / 2));
	}
}