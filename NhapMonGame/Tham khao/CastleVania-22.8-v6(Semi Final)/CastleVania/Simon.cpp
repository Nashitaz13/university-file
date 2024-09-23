#include "Simon.h"

#define SIMON_FIGHT_RATE 20
#define SIMON_RATE 10
#define HURT_STATE 25

#define SPEED_X 0.3f
#define SPEED_Y 0.4f
#define MAX_HEIGHT 70.0f

Simon::Simon(void): DynamicObject()
{
}

Simon::Simon(int _posX, int _posY): DynamicObject(_posX, _posY, 0, -SPEED_Y, EnumID::Simon_ID)
{
	hearts = 10;
	hp = 40;
	damage = 0;in
	_usingCross = false;
	_eatMagicalCrystal = false;
	_usingWatch = false;

	_hasFall = false;
	_action = Action::Idle;
	_allowPress = true;
	_simonDeath = false;
	_vLast = 0.2f;
	_hasJump = false;
	_hasSit = false;
	_heightJump = 0.0f;
	_isDraw = true;
	_weapon = new list<Weapon*>();;	
	_kindStair = EKindStair::None;
	_hasStair = false;
	_onStair = false;
	_heightJump = 0.0f;
	_colStair = false;
	_upStair = false;
	_downStair = false;
	_stopOnStair = false;
	_outStair = false;
	_weaponID = EnumID::None_ID;
	_movingByMovingPlatform = false;
	_usingWeapon = false;
	_colCastleGate = false;
	_colDoor = false;
	_directDoor = EDirectDoor::NoneDoor;
	_threeWater = NULL;
	_simonDeathSprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::SimonDeath_ID),0, 0, 100);
	simonJump = new CSprite(Singleton::getInstance()->getTexture(EnumID::Simon_ID), 4, 4, 300);
	_simonStair = new CSprite(Singleton::getInstance()->getTexture(EnumID::Simon_ID), 10, 13, 320);
	_simonFightingSprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::Simon_ID), 5, 8, 1000/SIMON_FIGHT_RATE);
	_simonFightingSittingSprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::Simon_ID), 15, 18, 1000/SIMON_FIGHT_RATE);
	_simonFightingDownStairSprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::Simon_ID), 18, 21, 1000/SIMON_FIGHT_RATE);
	_simonFightingUpStairSprite = new CSprite(Singleton::getInstance()->getTexture(EnumID::Simon_ID), 21, 24, 1000/SIMON_FIGHT_RATE);
	_morningStar = new MorningStar(_posX, _posY, 0, 0, EnumID::MorningStar_ID, 1000/SIMON_FIGHT_RATE);
	_stair = NULL;
	Initialize();
}

void Simon::Update(int deltaTime)
{
	list<Weapon*>::iterator it = _weapon->begin();
	while (it != _weapon->end())
	{
		if(!(*it)->active)
			_weapon->erase(it++);
		else
		{
			(*it)->Update(deltaTime);
			++it;
		}
	}
	if(_threeWater != NULL)
	{
		_threeWater->Update(deltaTime);
	}
	//return;
	switch(_action)
	{
	case Action::Run_Left:
		sprite->Update(deltaTime);
		break;
	case Action::Run_Right:
		sprite->Update(deltaTime);
		break;
	case Action::Fight:
		this->OnFight(deltaTime);
		break;
	}		
	if(_hasStair)
	{
		UpdateSimonStair(deltaTime);
	}
	else if(_colCastleGate)
	{
		UpdateGateCastle(deltaTime);
	}
	else
	{
		if(posX - GetBox().w <= G_MinSize && vX < 0)
		{
			vX = 0;
		}
		else if (posX + GetBox().w >= G_MaxSize && vX > 0)
		{
			vX = 0;
		}
		posX += vX *deltaTime;
		posY += vY *deltaTime;
		if(_hasJump)
		{
			_heightJump += vY * deltaTime;
			if( _heightJump >= MAX_HEIGHT)
			{			
				vY = -(SPEED_Y + 0.3f);
			}
		}
	}
}

void Simon::UpdateSimonStair(int dt)
{
	if(_onStair)
	{
		if(_upStair)
		{
			if(_kindStair == EKindStair::UpRight)
			{
				_vLast = vX = 1;
				_timeSpawn += 1;
				if(_timeSpawn <= 10)
				{		

					posX += 1.6;
					posY += 1.6;
					if(_timeSpawn > 1 && _timeSpawn < 7)
						_simonStair->SelectIndex(13);
					else
					{
						_simonStair->SelectIndex(12);
					}
					if(_timeSpawn == 10)
					{
						_stopOnStair = true;
						_timeSpawn = 0;
						return;
					}
				}
			}
			else if(_kindStair == EKindStair::UpLeft)
			{
				_vLast = vX = -1;
				_timeSpawn += 1;
				if(_timeSpawn <= 10)
				{		

					posX -= 1.6;
					posY += 1.6;
					if(_timeSpawn > 1 && _timeSpawn < 7)
						_simonStair->SelectIndex(13);
					else
					{
						_simonStair->SelectIndex(12);
					}
					if(_timeSpawn == 10)
					{
						_stopOnStair = true;
						_timeSpawn = 0;
						return;
					}
				}
			}
		}
		else if(_downStair)
		{
			if(_kindStair == EKindStair::DownLeft)
			{
				_vLast = vX = -1;
				_timeSpawn += 1;
				if(_timeSpawn <= 10)
				{		
					posX -= 1.6;
					posY -= 1.6;
					if(_timeSpawn > 1 && _timeSpawn < 7)
						_simonStair->SelectIndex(11);
					else
					{
						_simonStair->SelectIndex(10);
					}
					if(_timeSpawn == 10)
					{
						_stopOnStair = true;
						_timeSpawn = 0;
						return;
					}
				}
			}
			else if(_kindStair==EKindStair::DownRight)
			{
				_vLast = vX = 1;
				_timeSpawn += 1;
				if(_timeSpawn <= 10)
				{		
					posX += 1.6;
					posY -= 1.6;
					if(_timeSpawn > 1 && _timeSpawn < 7)
						_simonStair->SelectIndex(11);
					else
					{
						_simonStair->SelectIndex(10);
					}
					if(_timeSpawn == 10)
					{
						_stopOnStair = true;
						_timeSpawn = 0;
						return;
					}
				}
			}
		}
	}
	else
	{
		if(_hasStair)
		{
			if(rangeStair < 0)
			{
				_vLast = vX = 1;
				posX += 1;
				rangeStair += 1;	
			}
			else if( rangeStair > 0)
			{
				_vLast = vX = - 1;
				posX -= 1;
				rangeStair -= 1;
			}
			if(rangeStair == 0)
			{	
				switch (_stair->id)
				{
				case EnumID::StairDownLeft_ID:
					_kindStair = EKindStair::DownLeft;
					break;
				case EnumID::StairDownRight_ID:
					_kindStair = EKindStair::DownRight;
					break;
				case EnumID::StairUpLeft_ID:
					_kindStair = EKindStair::UpLeft;
					break;
				case EnumID::StairUpRight_ID:
					_kindStair = EKindStair::UpRight;
					break;
				default:
					break;
				}


				//------------------Thay van toc
				if(_kindStair == EKindStair::UpRight || _kindStair == EKindStair::DownRight)
				{
					vX = _vLast = 1;
				}
				else if(_kindStair == EKindStair::UpLeft || _kindStair == EKindStair::DownLeft)
				{
					vX = _vLast = -1;
				}

				_onStair = true;
				_timeSpawn = 0;
				if(_kindStair == EKindStair::UpRight || _kindStair == EKindStair::UpLeft)
				{
					posY += 2;
					_simonStair->SelectIndex(12);
				}
				else if(_kindStair == EKindStair::DownLeft)
				{
					posY -= 16;
					_simonStair->SelectIndex(10);
				}
				else if( _kindStair == EKindStair::DownRight)
				{
					posY -= 16;
					_simonStair->SelectIndex(10);
				}
			}
			sprite->Update (dt);
		}
		else if(_outStair)
		{
			sprite->SelectIndex(0);
			_kindStair = EKindStair::None;
			_action = Action::Idle;
		}
	}
}

void Simon::UpdateGateCastle(int dt)
{

	if(_colCastleGate)
	{
		if(rangeGate < 0)
		{
			_vLast = vX = 1;
			posX += 1;
			rangeGate += 1;	
		}
		else if( rangeGate > 0)
		{
			_vLast = vX = - 1;
			posX -= 1;
			rangeGate -= 1;
		}
		if(rangeGate == 0)
		{	
			sprite->SelectIndex(9);
			_action = Action::IntoCastle;
			Stop();
			return;
		}
		sprite->Update (dt);
	}
}

Box Simon::GetBox()
{
	if ((_hasJump && _heightJump >= MAX_HEIGHT / 2) || _hasSit)
	{
		return Box(posX - width/2 + 14.5f, posY + height/2 - 3, width - 29, height - 22);
	}
	return Box(posX - width/2 + 14.5f, posY + height/2 - 3, width - 29, height - 6);
}

void Simon::Collision(list<GameObject*> &obj, float dt) 
{
	for (list<Weapon*>::iterator i = _weapon->begin(); i != _weapon->end(); i++)
	{
		if((*i)->active)
		{
			if((*i)->id == EnumID::Boomerang_ID)					
				(*i)->Collision(this->GetBox());
			(*i)->Collision(obj, dt);			
			point += (*i)->point;
			(*i)->point = 0;
		}
	}
	if(Action::Fight == _action)
	{
		if(!_usingWeapon)
			_morningStar->Collision(obj, dt);
		point += _morningStar->point;
		_morningStar->point = 0;
	}

	bool isListStatic = false;
	bool hasColWithBrick = false;
	for (list<GameObject*>::iterator _itBegin = obj.begin(); _itBegin != obj.end(); _itBegin++)
	{
		GameObject* other = (*_itBegin);
		if(!other->active)
		{
			if(other->type != ObjectType::Item_Type)
				other->SetActive(posX, posY);
		}
		else if((other->id == EnumID::BlackLeopard_ID && other->sprite->GetIndex() == 0)
			|| (other->id == EnumID::VampireBat_ID && other->sprite->GetIndex() == 0))
		{
			other->SetActive(posX, posY);
		}
		else
			if(other->id == EnumID::Candle_ID || other->id == EnumID::LargeCandle_ID
				/*|| other->id == EnumID::MovingPlatform_ID*/)
			{
			}
			else
			{
				float moveX;
				float moveY;
				float normalx;
				float normaly;

				Box boxSimon = this->GetBox();
				Box boxOther = other->GetBox();

				if(AABB(boxSimon, boxOther, moveX, moveY) == true)
				{
#pragma region
					if(other->type == ObjectType::Item_Type && other->id != EnumID::Fire_ID)
					{
						other->Remove();
						switch(other->id)
						{
						case EnumID::AxeItem_ID:
							_weaponID = EnumID::Axe_ID;
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectWeapon);
							break;
						case EnumID::WatchItem_ID:
							_weaponID = EnumID::Watch_ID;
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectWeapon);
							break;
						case EnumID::BoomerangItem_ID:
							_weaponID = EnumID::Boomerang_ID;
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectWeapon);
							break;
						case EnumID::DaggerItem_ID:
							_weaponID = EnumID::Dagger_ID;
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectWeapon);
							break;
						case EnumID::FireBombItem_ID:
							_weaponID = EnumID::FireBomb_ID;
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectWeapon);
							break;
						case EnumID::MorningStarItem_ID:
							this->UpgradeMorningStar();
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectWeapon);
							break;
						case EnumID::SmallHeartItem_ID:
						case EnumID::LargeHeartItem_ID:
							//cong tim
							hearts += other->hearts;
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectItem);
							break;
						case EnumID::MoneyBagBlueItem_ID:
						case EnumID::MoneyBagRedItem_ID:
						case EnumID::MoneyBagItem_ID:
						case EnumID::MoneyBagWhiteItem_ID:
							//cong tien
							point += other->point;
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_CollectItem);
							break;
						case EnumID::CrossItem_ID:
							//Xoa het enemy tren camera
							SetUsingCross(true);
							break;
						case EnumID::MagicalCrystal_ID:
							//Qua man
							_eatMagicalCrystal = true;
							SoundManager::GetInst()->RemoveAllBGM();
							SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_StageClear);
							break;
						}
#pragma endregion Lay item
					}
					else 
					{
						switch(other->id)
						{
#pragma region
						case EnumID::Brick_ID:
							_onMovingPlatform = false;
							if(vY < 0 && moveY < 16)
							{
								//Neu dang rot ma chua cham dat thi rot tiep
								if(_action == Action::Fall)
								{
									if(moveY != 0)
									{
										posY += moveY;		
										vY = 0;
										_action = Action::Idle;
										_onLand = true;
										Stop();
									}
								}
								else
								{
									if(moveY > 0)
									{
										posY += moveY;
										if((_hasJump/* && _heightJump <= 0*/))
										{
											_hasJump = false;
											vY = 0;
											vX = 0;
											if(boxSimon.h < 60)
												posY += 16;
										}
										else 
											if(!_hasJump)
												vY = 0;
									}
								}
							}
							//Xu ly rot khoi cuc gach (new)
							if((!_onLand || _action != Action::Idle) && !_hasJump)
							{
								vY = -(SPEED_Y + 0.4f);
							}
							//--------------------
							if(_onLand && moveX != 0 && vX != 0 && !_onStair && !_hasJump && !_onMovingPlatform)
							{
								posX += moveX;
							}
							break;
#pragma endregion Va cham Gach
							//------------------------------------------------
#pragma region
						case EnumID::MovingPlatform_ID:
							{
								float _compareHeigh = abs((other->posY + other->height/2) - (posY - height/2) - moveY) ; 
								if(vY < 0 && _compareHeigh < 5)
								{
									_hasJump = false;
									vY = 0;
									posY += moveY;
									_onMovingPlatform = true;
								}
								else if(vY > 0 || _hasJump)
									return;
								if(_onMovingPlatform && _action == Action::Idle)
									vX = other->vX;
								else if(_onMovingPlatform && _hasJump && _action == Action::Run_Right)
								{
									vX = SPEED_X;
									vY = -SPEED_Y;
								}
								else if(_onMovingPlatform && _hasJump && _action == Action::Run_Left)
								{
									vX = -SPEED_X;
									vY = -SPEED_Y;
								}
								else if (_onMovingPlatform && !_hasJump)
								{
									vY = -SPEED_Y;
								}
							}
							break;


#pragma endregion Va cham Movingplatform
							//--------------------------------------
#pragma region
						case EnumID::Lake_ID:
							{
								_threeWater = new ThreeWater(posX, posY + 50);
								death = true;
								SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_FallInLake);
							}
							break;
#pragma endregion Rot xuong ho nuoc 

							//------------------------------------------------
#pragma region
						case EnumID::StairUpRight_ID:
							{
								if(_colStair == false)
									_colStair = true;
								if(!_hasStair)
									rangeStair = posX - (other->posX - 11);
								_stair = other;
								if(_upStair && _onStair)
								{
									_kindStair = EKindStair::UpRight;
								}
								float _compareHeigh = abs((other->posY - other->height/2) - (posY - height/2)) ; //so sanh do cao Simon co bang do cao box ko
								if(_compareHeigh < 2 && _kindStair == EKindStair::DownLeft)
								{
									_outStair = true;
									OutStair();
								}

							}
							break;
						case EnumID::StairUpLeft_ID:
							{
								if(_colStair == false)
									_colStair = true;
								if(!_hasStair)
									rangeStair = posX - (other->posX + 11);

								_stair = other;
								if(_upStair && _onStair)
								{
									_kindStair = EKindStair::UpLeft;
								}
								float _compareHeigh = abs((other->posY - other->height/2) - (posY - height/2)) ; //so sanh do cao Simon co bang do cao box ko
								if(_compareHeigh < 2 && _kindStair == EKindStair::DownRight)
								{
									_outStair = true;
									OutStair();
								}
							}
							break;
						case EnumID::StairDownLeft_ID:
							{
								if(_colStair == false)
									_colStair = true;	
								if(!_hasStair)
									rangeStair = posX - (other->posX - 32);

								_stair = other;

								if(_downStair && _onStair)
								{
									_kindStair = EKindStair::DownLeft;
								}
								float _compareHeigh = abs((other->posY - other->height/2) - (posY - height/2)) ; //so sanh do cao Simon co bang do cao box ko
								if(_compareHeigh < 2 && _kindStair == EKindStair::UpRight)
								{
									_outStair = true;
									OutStair();
								}
							}
							break;
						case EnumID::StairDownRight_ID:
							{
								if(_colStair == false)
									_colStair = true;
								if(!_hasStair)
									rangeStair = posX - (other->posX + 32);

								_stair = other;

								if(_downStair && _onStair)
								{
									_kindStair = EKindStair::DownRight;
								}
								float _compareHeigh = abs((other->posY - other->height/2) - (posY - height/2)) ; //so sanh do cao Simon co bang do cao box ko
								if(_compareHeigh < 2 && _kindStair == EKindStair::UpLeft)
								{
									_outStair = true;
									OutStair();
								}
							}
							break;
#pragma endregion Va cham cau thang
							//------------------------------------------------
#pragma region 
						case EnumID::CastleGate_ID:
							{
								rangeGate = posX - other->posX;
								float _compareHeigh = abs((other->posY - other->height/2) - (posY - height/2)); 
								if(_compareHeigh < 4)
								{
									_colCastleGate = true;
									OnGateCastle();
								}
							}
							break;
						case EnumID::DoorDown_ID:
							{
								float _compareHeigh = abs((other->posY) - (posY - height/2)) ; //so sanh do cao Simon co bang do cao box ko
								if(_compareHeigh <= 3 && _downStair)
								{
									_colDoor = true;
								}
								_door = other;

							}
							break;
						case EnumID::DoorUp_ID:
							{
								float _compareHeigh = abs((other->posY) - (posY - height/2)) ; //so sanh do cao Simon co bang do cao box ko
								if(_compareHeigh < 2 && _upStair)
								{
									_colDoor = true;
								}
								_door = other;
							}
							break;
						case EnumID::DoorLeft_ID:
							{
								_door = other;
								_allowPress = false;
								_colDoor = true;
							}
							break;
						case EnumID::DoorRight_ID:
							{
								_door = other;
								_allowPress = false;
								_colDoor = true;
							}
							break;
#pragma endregion Xu Ly Va Cham Voi Cac Loai Cong
							//------------------------------------------------
						case EnumID::StupidDoor_ID:
							hp = 0;
							break;
						default:
							switch(other->type)
							{
#pragma region
							case ObjectType::Enemy_Type:
								if(!bActiveHurt)
								{
									bActiveHurt = true;
									_localHurtTime = GetTickCount();
									if(hp > 0)
									{
										if(hp <= 3)
										{
											hp -= 1;
										}
										else
											hp -= other->damage;
									}

								}
								break;
							}
							break;
#pragma endregion Va cham Enemy 
						}
					}
				}
				else 
					if(other->type != ObjectType::Item_Type && (boxSimon, boxOther, moveX, moveY) == false)
					{
						if(other->canMove == true)
						{
							boxSimon.vx -= boxOther.vx;
							boxSimon.vy -= boxOther.vy;
							boxOther.vx = 0;
							boxOther.vy = 0;
						}
						Box broadphasebox = GetSweptBroadphaseBox(boxSimon, dt);
						if (AABBCheck(GetSweptBroadphaseBox(boxSimon, dt), boxOther) == true)
						{
							float collisiontime = SweptAABB(boxSimon, boxOther, normalx, normaly, dt);
							if (collisiontime > 0.0f && collisiontime < 1.0f)
							{
								ECollisionDirect colDirect = GetCollisionDirect(normalx, normaly);
								// perform response here
								switch(other->id)
								{
									//----------------------------------
								case EnumID::Brick_ID:
									switch (colDirect)
									{
									case Colls_Left:
										posX -= (boxOther.w * collisiontime * other->width + 1);
										break;
									case Colls_Right:
										posY += (boxOther.w * collisiontime * other->width + 1);
										break;
									case Colls_Bot:
										posY += boxOther.h * collisiontime;
										vY = 0;
										break;
									}
									break;
									//-----------------------------------
								}
							}
						}
					}
			}
	}
}

void Simon::Draw(CCamera* camera)
{
	//-----Kiem tra simon co roi xuong vuc ko (simon death)-
	if(posY < (camera->viewport.y - G_ScreenHeight))
	{
		hp = 0;
	}
	if(_threeWater != NULL)
		_threeWater ->Draw(camera);
	//---------Ve simon------------
	if(death)
		return;
	D3DXVECTOR2 center = camera->Transform(posX, posY);
	if(_simonDeath)
	{
		_simonDeathSprite->DrawFlipX(center.x, center.y);
	}
	else
	{
		if(IsHurt())
		{
		}
		else
		{
			for (list<Weapon*>::iterator i = _weapon->begin(); i != _weapon->end(); i++)
			{
				if((*i)->active)
					(*i)->Draw(camera);
			}
			if(vX > 0||_vLast>0)
			{
				if(_action == Action::Fight)
				{
					if(!_usingWeapon)
						_morningStar->Draw(camera);
					if(_onStair)
					{
						if(_kindStair == EKindStair::DownLeft || _kindStair == EKindStair::DownRight)
							_simonFightingDownStairSprite->DrawFlipX(center.x, center.y);
						else
						{
							_simonFightingUpStairSprite->DrawFlipX(center.x, center.y);
						}
					}
					else
						if(!_hasSit)
							_simonFightingSprite->DrawFlipX(center.x, center.y);	
						else
						{
							_simonFightingSittingSprite->DrawFlipX(center.x, center.y);
						}
						return;
				}
				if(_action == Action::IntoCastle)
				{
					sprite->Draw(center.x, center.y);
					return;
				}
				if((_hasJump && vY > 0/*&& _heightJump >= MAX_HEIGHT / 2*/) || _hasSit)
				{
					simonJump->DrawFlipX(center.x, center.y);
					return;
				}
				if(_onStair)
				{
					if(_kindStair == EKindStair::UpRight || _kindStair == EKindStair::DownRight)
						_simonStair->DrawFlipX(center.x, center.y);
					return;
				}
				sprite->DrawFlipX(center.x, center.y);
			}
			else
			{	
				if(_action == Action::Fight)
				{
					if(!_usingWeapon)
						_morningStar->Draw(camera);
					if(_onStair)
					{
						if(_kindStair == EKindStair::DownLeft || _kindStair == EKindStair::DownRight)
							_simonFightingDownStairSprite->Draw(center.x, center.y);
						else
						{
							_simonFightingUpStairSprite->Draw(center.x, center.y);
						}
					}
					else
						if(!_hasSit)
							_simonFightingSprite->Draw(center.x, center.y);	
						else
						{
							_simonFightingSittingSprite->Draw(center.x, center.y);
						}
						return;
				}
				if(_action == Action::IntoCastle)
				{
					sprite->Draw(center.x, center.y);
					return;
				}
				if((_hasJump && vY > 0/*&& _heightJump >= MAX_HEIGHT / 2*/) || _hasSit)
				{
					simonJump->Draw(center.x, center.y);
					return;
				}
				if(_onStair)
				{
					if(_kindStair == EKindStair::DownLeft || _kindStair == EKindStair::UpLeft)
						_simonStair->Draw(center.x, center.y);
					return;
				}
				sprite->Draw(center.x, center.y);
			}
		}
	}
}

void Simon::TurnLeft()
{	
	if(_allowPress)
	{
		if(_usingWeapon)
			_usingWeapon = false;
		if(_action == Action::Fall)
			return;
		if(_action == Action::Fight)
			return;
		if(_hasJump || _hasSit)
			return;	
		if(_hasStair)
			return;
		if(_colCastleGate)
			return;
		ResetStair();
		vX = -SPEED_X;
		_vLast = vX;
		_hasSit = false;
		_action = Action::Run_Left;
	}
}

void Simon::TurnRight()
{		
	if(_allowPress)
	{
		if(_usingWeapon)
			_usingWeapon = false;
		if(_action == Action::Fall)
			return;
		if(_action == Action::Fight)
			return;
		if(_hasJump || _hasSit)
			return;	
		if(_hasStair)
			return;
		if(_colCastleGate)
			return;
		ResetStair();
		vX = SPEED_X;
		_vLast = vX;
		_hasSit = false;
		_action = Action::Run_Right;

	}
}

void Simon::Jump()
{
	if(_allowPress)
	{
		if(_action == Action::Fall)
			return;
		if(_action == Action::Fight)
			return;
		if(_hasSit)
			return;
		if(_onStair)
			return;
		if(_colCastleGate)
			return;
		if(!_hasJump)
		{
			vY = SPEED_Y;
			_heightJump = 0;
			sprite->SelectIndex(0);
			_action = Action::Jump;
			_hasJump = true;
		}
	}
}

void Simon::Fall()
{
	_action = Action::Fall;
	vX = 0;
	vY = -(SPEED_Y + 0.4f);
}

void Simon::Sit()
{
	if(_allowPress)
	{
		if(_action == Action::Fall)
			return;
		if(_action == Action::Fight)
			return;
		if(_hasSit)
			return;
		if(_colCastleGate)
			return;
		if(!_hasJump)
		{
			vX = 0;
			vY = -(SPEED_Y + 0.3f);
			_hasSit = true;
			_action = Action::Sit;
		}
	}
}

void Simon::Initialize()
{
	bActiveHurt = false;
	_localHurtTime = 0;
	_bHurt = false;
}

bool Simon::IsHurt()
{
	if(!bActiveHurt)
		return false;
	bool result = _bHurt;
	DWORD now = GetTickCount();
	DWORD deltaTime = now - _localHurtTime;
	if(deltaTime >= 1000)
	{
		bActiveHurt = false;
	}
	if(deltaTime % (int)(1000/HURT_STATE) < 15)
	{
		_bHurt = !_bHurt;
	}
	return result;
}

void Simon::UpStair()
{
	if(!_downStair )
	{
		_upStair = true;
		if(_onStair)
		{
			if(_kindStair == EKindStair::DownLeft)
			{
				vX = _vLast = -1;
				_kindStair = EKindStair::UpRight;
			}
			if(_kindStair == EKindStair::DownRight)
			{
				vX = _vLast = 1;
				_kindStair = EKindStair::UpLeft;
			}
		}
	}
	if(_hasJump)
		return;
	if(_action == Action::Fight)
		return;
	if(_hasStair)
		return;
	if(abs(rangeStair) < 40)
	{
		if(_colStair && (_stair->id == EnumID::StairUpLeft_ID || _stair->id == EnumID::StairUpRight_ID))
		{
			if(!_hasStair)
				_hasStair = true;
			else
			{
				_onStair = true;
				_timeSpawn=0;
			}
			if(rangeStair != 0)
			{
				_onStair = false;
			}
			else
			{
				_onStair = true;
				if(_kindStair == EKindStair::DownLeft)
				{
					vX = _vLast = -1;
					_kindStair = EKindStair::UpRight;
				}
				if(_kindStair == EKindStair::DownRight)
				{
					vX = _vLast = 1;
					_kindStair = EKindStair::UpLeft;
				}
				_simonStair->SelectIndex(13);
				_timeSpawn = 0;

			}
		}
	}

}

void Simon::DownStair()
{

	if(!_upStair)		
	{
		_downStair = true;
		if(_onStair)
		{
			if(_kindStair == EKindStair::UpRight)
			{
				_kindStair = EKindStair::DownLeft;
				vX = _vLast = -1;
			}
			if(_kindStair == EKindStair::UpLeft)
			{
				vX = _vLast = 1;
				_kindStair = EKindStair::DownRight;
			}
		}
	}
	if(_hasJump)
		return;
	if(_action == Action::Fight)
		return;
	if(_hasStair)
		return;
	if(abs(rangeStair ) < 40)
	{
		if(_colStair && (_stair->id == EnumID::StairDownLeft_ID || _stair->id == EnumID::StairDownRight_ID))
		{
			if(!_hasStair) _hasStair = true;
			else
			{
				_onStair = true;
				_timeSpawn=0;
			}
			if(rangeStair != 0)
			{
				_onStair = false;
			}
			else
			{
				if(_kindStair == EKindStair::UpRight)
				{
					_kindStair = EKindStair::DownLeft;
					vX = _vLast = -1;
				}
				if(_kindStair == EKindStair::UpLeft)
				{
					vX = _vLast = 1;
					_kindStair = EKindStair::DownRight;
				}
				_onStair = true;
				_simonStair->SelectIndex(11);
				_timeSpawn = 0;
			}
		}
	}
}

void Simon::OutStair()
{
	if(_upStair || _downStair)
	{
		_upStair = false;
		_downStair = false;
		_hasStair = false;
		_onStair = false;
		vY = -SPEED_Y;
		vX = 0;
		sprite->SelectIndex(0);
		switch (_stair->id)
		{
		case EnumID::StairDownLeft_ID:
			_kindStair = EKindStair::DownLeft;
			break;
		case EnumID::StairDownRight_ID:
			_kindStair = EKindStair::DownRight;
			break;
		case EnumID::StairUpLeft_ID:
			_kindStair = EKindStair::UpLeft;
			break;
		case EnumID::StairUpRight_ID:
			_kindStair = EKindStair::UpRight;
			break;
		default:
			break;
		}
	}
}

bool Simon::OnStair()
{
	if((_colStair && (_stair->id == EnumID::StairDownLeft_ID || _stair->id == EnumID::StairDownRight_ID)) || _onStair)
		return true;
	return false;
}

void Simon::ResetStair()
{
	if(_upStair || _downStair)
		_upStair = _downStair = false;
	//_kindStair = EKindStair::None;
	_colStair = false;
}

void Simon::OnGateCastle()
{
	if(_colCastleGate)
	{
		ResetStair();
		_hasJump = false;
		_hasSit = false;
		_hasWeapon = false;

	}
}

void Simon::Stop()
{	
	if(_usingWeapon)
		_usingWeapon = false;
	if(_stopOnStair && _timeSpawn == 0)
	{
		_upStair = false;
		_downStair = false;
		_stopOnStair = false;
		return;
	}
	switch (_action)
	{
	case Action::Idle:
	case Action::Fight:
	case Action::Fall:
		return;	
	}
	if(_hasSit)
	{
		_hasSit = false;
		posY += 16;
	}	
	if(_action == Action::IntoCastle)
	{
		vX = 0;
		return;
	}
	if(!_hasJump && !_movingByMovingPlatform) vX = 0;
	_action = Action::Idle;
	sprite->SelectIndex(0);
}

void Simon::UseWeapon()
{
	if(_weaponID != EnumID::None_ID)
	{
		if(!_usingWeapon)
		{
			_usingWeapon = true;
		}
	}
}

void Simon::SetWeapon()
{
	switch(_weaponID)
	{
	case EnumID::FireBomb_ID:
		_weapon->push_back(new FireBomb(posX, posY, _vLast));
		break;
	case EnumID::Dagger_ID:
		_weapon->push_back(new Dagger(posX, posY, _vLast));
		break;
	case EnumID::Boomerang_ID:
		_weapon->push_back(new Boomerang(posX, posY, _vLast));
		break;
	case EnumID::Axe_ID:
		_weapon->push_back(new Axe(posX, posY, _vLast));
		break;
	case EnumID::Watch_ID:
		_usingWatch = true;
		SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_StopTimer);
		break;
	}
	_hasWeapon = false;
}

void Simon::ChangeWeapon(EnumID idWeapon)
{
	_weaponID = idWeapon;
}

void Simon::Fight()
{
	if(_allowPress)
	{
		if(_action == Action::Fight)
			return;
		if(_onStair && (_upStair || _downStair))
			return;
		if(!_hasJump) vX = 0;
		if(_usingWeapon && !_hasWeapon && hearts > 0)
		{
			_hasWeapon = true;
			hearts -= 1;
		}
		SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_UsingMorningStar);
		_action = Action::Fight;
	}
}

void Simon::UpgradeMorningStar()
{
	_morningStar->updateLevel();
}

void Simon::OnFight(int t)
{
	if(_hasSit)
		_simonFightingSittingSprite->Update(t);
	else
		if(_onStair)
		{
			if(_kindStair == EKindStair::DownLeft || _kindStair == EKindStair::DownRight)
				_simonFightingDownStairSprite->Update(t);
			else _simonFightingUpStairSprite->Update(t);
		}
		else
			_simonFightingSprite->Update(t);

	if(_usingWeapon && _hasWeapon)
	{
		if(_simonFightingSittingSprite->GetIndex() == 17 
			|| _simonFightingSprite->GetIndex() == 7
			|| _simonFightingDownStairSprite->GetIndex() >= 21 
			|| _simonFightingUpStairSprite->GetIndex() >= 24)
		{
			this->SetWeapon();
		}
	}
	//else
	{
		// Update the moringStar index
		_morningStar->Update(t);

		// Update the Vx of morningStar
		float morningStarVx = -1;
		if(vX > 0 || _vLast > 0)
			morningStarVx = -morningStarVx;
		_morningStar->updateVx(morningStarVx);


		// Update the pos of morningStar
		_morningStar->updateXY(posX, posY);///////==============================================>> fishing

	}
	if(_onStair)
	{
		if((_kindStair == EKindStair::DownLeft || _kindStair == EKindStair::DownRight) 
			&& _simonFightingDownStairSprite->GetIndex() >= 21)
		{
			_action = Action::Idle;
			_simonFightingDownStairSprite->Reset();
			_morningStar->reset();
		}
		else if(_simonFightingUpStairSprite->GetIndex() >= 24)
		{
			_action = Action::Idle;
			_simonFightingUpStairSprite->Reset();
			_morningStar->reset();
		}
	}
	else
		if(!_hasSit && _simonFightingSprite->GetIndex()>=8)
		{
			_action = Action::Idle;
			_simonFightingSprite->Reset();
			_morningStar->reset();
		}
		else
			if(_hasSit && _simonFightingSittingSprite->GetIndex() >= 18)
			{
				_action = Action::Sit;
				_simonFightingSittingSprite->Reset();
				_morningStar->reset();
			}
}

Simon::~Simon(void)
{
}

D3DXVECTOR2* Simon::getPos()
{
	return new D3DXVECTOR2(this->posX,this->posY);
}

void Simon::SetDirectDoor(EDirectDoor _direct)
{
	_directDoor = _direct;
	_colDoor = false;
}

EDirectDoor Simon::GetDirectDoor()
{
	if(_colDoor)
	{
		switch (_door->id)
		{
		case DoorDown_ID:
			_directDoor = EDirectDoor::DoorDown;
			break;
		case DoorUp_ID:
			_directDoor = EDirectDoor::DoorUp;
			break;
		case DoorLeft_ID:
			_directDoor = EDirectDoor::DoorLeft;
			break;
		case DoorRight_ID:
			_directDoor = EDirectDoor::DoorRight;
			break;
		default:
			break;
		}
	}
	_colDoor = false;
	return _directDoor;
}

bool Simon::AutoMove(int &range, int dt)
{
	if(range == 0)
		return true;
	if(range > 0)
	{
		range -= 4;
		posX += 4;
	}
	else
	{
		range += 4;
		posX -=4;
	}
	sprite->Update(dt);
	return false;
}

void Simon::SimonDeath(int &_timeCount)
{
	if(_simonDeath)
	{
		_allowPress = false;
		_timeCount -= 1;
		_simonDeathSprite->SelectIndex(0);
		if(_timeCount == 0)
		{
			//_simonDeath = false;
			_allowPress = true;
			_isReset = true;
		}
	}
}

int Simon::GetHPSimon()
{
	return hp;
}


bool Simon::GetUsingCross()
{
	return _usingCross;
}

void Simon::SetUsingCross(bool value)
{
	if(!value)
	{
		_usingCross = false;
	}
	else if(!_usingCross)
	{
		_usingCross = true;
		SoundManager::GetInst()->PlaySoundEffect(ESoundEffect::ES_HolyCross);
	}
}

bool Simon::GetUsingWatch()
{
	return _usingWatch;
}

void Simon::SetUsingWatch(bool value)
{
	_usingWatch = value;
}