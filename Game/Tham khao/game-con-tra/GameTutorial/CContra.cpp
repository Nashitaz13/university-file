#include "CContra.h"
#include "CInput.h"
#include "CCamera.h"
#include "CCollision.h"
#include "CHidenObject.h"
#include "CSoldier.h"
#include "CSoldierShoot.h"
#include "CPoolingObject.h"
#include "CManageAudio.h"
#include "CMenuGameScense.h"
#include "CGameOverItem.h"
#include "CBridgeFire.h"
#include "CBridgeStone.h"
#include "CScenseManagement.h"
#include <cmath>
#include <random>

CContra::CContra()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_id = 0;
	this->m_idType = 10; 
	this->m_idImage = 0;
	this->m_isALive = true;
	this->m_isAnimatedSprite = true;
	this->m_width = 72;
	this->m_height = 92; 
	//Set vi tri contra theo map
	switch (CMenuGameScense::m_mapId)
	{
		case 10:
			this->m_pos = D3DXVECTOR2(100.0f, 400.0f);
			ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_1);
			break;
		case 11:
			this->m_pos = D3DXVECTOR2(120.0f, 300.0f);
			ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_3);
			break;
		case 12:
			this->m_pos = D3DXVECTOR2(100.0f, 450.0f);
			ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_5);
			break;
	}
	this->m_posStart = this->m_pos;
	//Khoi tao cac thong so di chuyen
	this->m_isJumping = false;
	this->m_isMoveLeft = false;
	this->m_a = -700.0f;
	this->m_canJump = true;
	this->m_jumpMax = 40.0f;
	//this->m_currentJump = 0.0f;
	this->m_vxDefault = 150.0f;
	this->m_vyDefault = 400.0f;
	this->m_vx = 0;//this->m_vxDefault;
	this->m_vy = -this->m_vyDefault;
	this->m_left = false;
	//Trang thai ban dau la dang dung yen
	this->m_stateCurrent = ON_GROUND::IS_FALL;
	//Tren mat dat
	this->m_isGameOver = false;
	this->m_isDie = false;
	this->m_isUnderWater = false;
	this->m_isShoot = false;
	this->m_isShooting = false;
	this->m_isStadingInStone = false;
	this->m_isDrawBoss = false;
	this->m_stateShoot = SHOOT::IS_DIAGONAL_UP;
	//Khoi tao cac thong so chuyen doi sprite
	this->m_currentTime = 0;
	this->m_currentFrame = 0;
	this->m_elapseTimeChangeFrame = 0.3f;
	this->m_increase = 1;
	this->m_totalFrame = 50;
	this->m_column = 6;
	//
	this->m_currentFall = 0;
	this->m_currentJump = 0;
	//
	this->m_waitForDie = 1.0f;
	this->m_waitForShoot = 0.4f;
	this->m_waitChangeSprite = 0.0f;
	//Hiding
	this->m_isHided = false;
	this->m_isHiding = true;
	this->m_timeHided = 0.0f;
	this->m_timeHiding = 0.0f;
	
	//this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_N;
	this->m_allowShoot = true;
	// TT
	this->m_waitForCreateEnemy = 0.5f;
	this->m_allowFall = true;
	///
	this->m_countAlive = __ALIVE_CONTRA_MAX__;
}

CContra::CContra(const std::vector<int>& info) : CDynamicObject(info)
{
	CContra();
}

CContra::~CContra()
{

}

void CContra::MoveUpdate(float deltaTime)
{
	#pragma region __XU_LY_CHUYEN_DONG__
	//Kiem tra doi tuong co nhay duoc hay ko
	if(this->m_stateCurrent == ON_GROUND::IS_DIE || 
		this->m_stateCurrent == UNDER_WATER::IS_DIE_UNDER_WATER)
	{
		this->m_pos.x += this->m_vx * deltaTime;
		this->m_vy += -900 * deltaTime;
		this->m_pos.y += this->m_vy * deltaTime;
	}
	else
	{
		if(this->m_canJump && this->m_isJumping)
		{
			if(this->m_stateCurrent == ON_GROUND::IS_FALL)
			{
				this->m_vy += this->m_a * deltaTime;
				this->m_pos.y += this->m_vy * deltaTime;
			}
			else
			{
				////Neu nhay den do cao cuc dai, gia toc doi chieu
				this->m_elapseTimeChangeFrame = 0.14f;
				//if(this->m_currentJump == 0)
				//	this->m_currentJump = m_pos.y;
				this->m_vy += this->m_a * deltaTime;
				this->m_pos.y += this->m_vy * deltaTime;
			}
		}
		else
		{
			//this->m_vy = -this->m_vyDefault;
			//this->m_vy += this->m_a * deltaTime;
			//this->m_pos.y += this->m_vy * deltaTime;
		}
		if(this->m_stateCurrent == ON_GROUND::IS_STANDING)
		{
			if (!this->m_isStadingInStone)
				this->m_vx = 0;
		}
		if(this->m_isMoveLeft)
		{
			if (this->m_vx < 0)
			{	
				this->m_pos.x += int(this->m_vx * deltaTime);
			}
		}
		else if (this->m_isMoveRight)
		{
			if (this->m_vx > 0)
			{
				this->m_pos.x += int(this->m_vx * deltaTime);
			}
		}
		float tempx = 0;

		#pragma region Thiet lap camera theo map
		switch (CMenuGameScense::m_mapId)
		{
			#pragma region THIET LAP CAMERA MAP 1
			case 10:
				if (this->m_pos.x > __SCREEN_WIDTH / 2)
				{
					if (this->m_pos.x >= 6090.0f)
					{
						this->m_isDrawBoss = true;
						CCamera::GetInstance()->Update(6130.0f, 0);
						if (!this->m_isBossCurrentDie)
						{
							if (this->m_pos.x > 6425.0f)
								this->m_pos.x = 6425.0f;
						}
						else
						{
							//Khi boss chet thi contra tu dong di den cuoi map
							//Sau khi den cuoi map  thi set bien kia StateGamePlay::GetIn()->m_isWinScenseShowed = true
							this->m_stateCurrent = ON_GROUND::IS_JOGGING;
							this->m_left = false;
							if (this->m_pos.x > 6600.0f)
							{
								this->m_isHiding = true;
								CScenseManagement::m_isWinScenseShowed = true;
								CMenuGameScense::m_mapId++;
								this->m_countAlive++;
								//CContra::GetInstance()->Reset();
								//CStateManagement::GetInstance()->ChangeState(new CStateGamePlay(CMenuGameScense::m_mapId));
								//CLoadGameObject::GetInstance()->ChangeMap(CMenuGameScense::m_mapId);
							}
							else
							{
								this->m_vx = this->m_vxDefault;
								this->m_pos.x += deltaTime*this->m_vx;
							}
						}
					}
					else
					{
						CCamera::GetInstance()->Update(this->m_pos.x - __SCREEN_WIDTH / 2, 0);
					}
				}
				break;
		#pragma endregion

			#pragma region THIET LAP CAMERA MAP 3
			case 11:
				if (this->m_pos.y > __SCREEN_HEIGHT/1.2)
				{
					if (this->m_pos.y >= 3960.0f)
					{
						this->m_isDrawBoss = true;
						CCamera::GetInstance()->Update(0.0f, 4332.0f);
						if (this->m_isBossCurrentDie)
						{
							//Khi boss chet thi contra tu dong di den cuoi map
							//Sau khi den cuoi map  thi set bien kia StateGamePlay::GetIn()->m_isWinScenseShowed = true
							this->m_stateCurrent = ON_GROUND::IS_JUMPING;
							this->m_left = false;
							if (this->m_pos.y > 4120.0f)
							{
								this->m_vy = 0;
								this->m_isHiding = true;
								CScenseManagement::m_isWinScenseShowed = true;
								CMenuGameScense::m_mapId++;
								this->m_countAlive++;
							}
							else
							{
								this->m_vy = this->m_vxDefault;
								this->m_pos.y += deltaTime*this->m_vy;
							}
						}
					}
					else
					{
						CCamera::GetInstance()->Update(0, __SCREEN_HEIGHT / 2 + this->m_pos.y);
					}
				}
				break;
		#pragma endregion

			#pragma region THIET LAP CAMERA MAP 5
			case 12:
				if (this->m_pos.x > __SCREEN_WIDTH / 2)
				{
					if (this->m_pos.x >= 9600.0f)
					{
						this->m_isDrawBoss = true;
						CCamera::GetInstance()->Update(9664.0f, 0);//MaxSizeMap
						if (!this->m_isBossCurrentDie)
						{
							if (this->m_pos.x > 10046.0f)
								this->m_pos.x = 10046.0f;
						}
						else
						{
							//Khi boss chet thi contra tu dong di den cuoi map
							//Sau khi den cuoi map  thi set bien kia StateGamePlay::GetIn()->m_isWinScenseShowed = true
							this->m_stateCurrent = ON_GROUND::IS_JUMPING;
							this->m_left = false;
							if (this->m_pos.x > 10046.0f && this->m_pos.y > 480)
							{
								this->m_vx = 0;
								this->m_vy = 0;
								this->m_isHiding = true;
								CScenseManagement::m_isWinScenseShowed = true;
								this->m_isBossCurrentDie = false;
								CMenuGameScense::m_mapId++;
								this->m_countAlive++;
							}
							else
							{
								this->m_vx = this->m_vxDefault;
								this->m_pos.x += deltaTime*this->m_vx;
								this->m_vy = this->m_vyDefault;
								this->m_pos.y += deltaTime*this->m_vy;
							}
						}
					}
					else
					{
						CCamera::GetInstance()->Update(this->m_pos.x - __SCREEN_WIDTH / 2, 0);
					}
				}
				break;
		#pragma endregion
		}
		#pragma endregion
	}
#pragma endregion
}

void CContra::SetFrame(float deltaTime)
{
#pragma region __XU_LY_CHUYEN_SPRITE_KHI_BAN
	if(this->m_isShooting) //dang ban
	{
		this->m_waitChangeSprite += deltaTime;
		if(this->m_waitChangeSprite > 0.3)
		{
			this->m_isShooting = false;
			this->m_waitChangeSprite = 0.0f;
		}
	}
#pragma endregion

#pragma region __XU_LY_CHUYEN_DOI_FRAME__
	//Neu dan duoc ban ra thi tang toc do chuyen frame	
	if(!this->m_isUnderWater)
	{
		switch (this->m_stateCurrent)
		{
		case ON_GROUND::IS_FALL:
			{
				this->m_startFrame = 19;
				this->m_endFrame = 19;
				break;
			}
		case ON_GROUND::IS_JOGGING://Chay bo
			{
				this->m_startFrame = 18;
				this->m_endFrame = 23;
				break;
			}
		case ON_GROUND::IS_JUMPING:
			{
				this->m_startFrame = 32;
				this->m_endFrame = 35;
				break;
			}
		case ON_GROUND::IS_LYING:
			{
				if(this->m_isShooting)
				{
					this->m_startFrame = 52;
					this->m_endFrame = 53;
				}
				else
				{
					this->m_startFrame = 52;
					this->m_endFrame = 52;
				}
				break;
			}
		case ON_GROUND::IS_SHOOTING_DIAGONAL_DOWN:
			{
				this->m_startFrame = 12;
				this->m_endFrame = 17;
				break;
			}
		case ON_GROUND::IS_SHOOTING_DIAGONAL_UP:
			{
				this->m_startFrame = 6;
				this->m_endFrame = 11;
				break;
			}
		case ON_GROUND::IS_SHOOTING_NORMAL:
			{

				if(this->m_currentFrame > 17 && this->m_currentFrame < 24)
				{
						this->m_currentFrame -= 18;
				}
				this->m_startFrame = 0;
				this->m_endFrame = 5;
				break;
			}
		case ON_GROUND::IS_SHOOTING_UP:
			{
				//Kiem tra co ban hay la khong
				if(this->m_isShooting)
				{
					//this->m_currentFrame = 31;
					this->m_startFrame = 30;
					this->m_endFrame = 31;
				}
				else
				{
					this->m_startFrame = 30;
					this->m_endFrame = 30;
				}
				break;
			}
		case ON_GROUND::IS_STANDING:
			{
				if(this->m_isShooting)
				{
					//this->m_currentFrame = 3;
					this->m_startFrame = 0;
					this->m_endFrame = 3;
					this->m_increase = 3;
				}
				else
				{
					this->m_startFrame = 0;
					this->m_endFrame = 0;
				}
				break;
			}
		case ON_GROUND::IS_UP_GROUND:
			{
				this->m_startFrame = 19;
				this->m_endFrame = 41;
				this->m_increase = 22;
				break;
			}
		case ON_GROUND::IS_DIE:
			{
				this->m_startFrame = 36;
				this->m_endFrame = 40;
				this->m_increase = 1;
				break;
			}
		default:
			{
				break;
			}
		}
	}
	else
	{
		switch (this->m_stateCurrent)
		{
		case UNDER_WATER::IS_JOGGING_UNDER_WATER:
			{
				this->m_startFrame = 49;
				this->m_endFrame = 50;
				break;
			}
		case UNDER_WATER::IS_LYING_UNDER_WATER:
			{
				this->m_startFrame = 48;
				this->m_endFrame = 48;
				break;
			}
		case UNDER_WATER::IS_STANDING_UNDER_WATER:
			{
				if(this->m_isShooting)
				{
					this->m_stateCurrent =  UNDER_WATER::IS_SHOOTING_UNDER_WATER_NORMAL;
					/*this->m_startFrame = 42;
					this->m_endFrame = 45;
					this->m_increase = 3;*/
				}
				else
				{
					this->m_startFrame = 49;
					this->m_endFrame = 50;
				}
				break;
			}
		case UNDER_WATER::IS_SHOOTING_UNDER_WATER_NORMAL:
			{
				if(this->m_isShooting)
				{
					this->m_startFrame = 42;
					this->m_endFrame = 45;
					this->m_increase = 3;
				}
				else
				{
					this->m_startFrame = 42;
					this->m_endFrame = 42;
					this->m_increase = 0;
				}
				break;
			}
		case UNDER_WATER::IS_SHOOTING_UNDER_WATER_UP:
			{
				if(this->m_isShooting)
				{
					this->m_startFrame = 43;
					this->m_endFrame = 46;
					this->m_increase = 3;
				}
				else
				{
					this->m_startFrame = 43;
					this->m_endFrame = 43;
					this->m_increase = 0;
				}
				break;
			}
		case UNDER_WATER::IS_SHOOTING_UNDER_WATER_DIAGONAL_UP:
			{
				if(this->m_isShooting)
				{
					this->m_startFrame = 44;
					this->m_endFrame = 47;
					this->m_increase = 3;
				}
				else
				{
					this->m_startFrame = 44;
					this->m_endFrame = 44;
					this->m_increase = 0;
				}
				break;
			}
		case UNDER_WATER::IS_DIE_UNDER_WATER:
			{
				this->m_startFrame = 36;
				this->m_endFrame = 40;
				this->m_increase = 1;
				break;
			}
		default:
			break;
		}
	}
#pragma endregion
}

void CContra::InputUpdate(float deltaTime)
{
#pragma region __KHONG_CO_SU_KIEN_PHIM__
	////Khong duoc phep ban
	this->m_isShoot = false;
	this->m_keyDown = CInput::GetInstance()->GetKeyDown();
	this->m_keyUp = CInput::GetInstance()->GetKeyUp();
	if(!(m_isUnderWater && this->m_isShooting))
		this->m_increase = 1;
	if(!this->m_isJumping)
	{
		this->m_vx = 0;
		this->m_isMoveLeft = false;
		this->m_isMoveRight = false;
		this->m_stateShoot = SHOOT::IS_NORMAL;
		if(this->m_stateCurrent == ON_GROUND::IS_JUMPING)
		{
			this->m_elapseTimeChangeFrame = 0.00f;
		}
		else
		{
			this->m_elapseTimeChangeFrame = 0.14f;
		}
		//Neu dang nam va phim down duoc giu
		//if(!(this->m_stateCurrent == ON_GROUND::IS_LYING && CInput::GetInstance()->IsKeyDown(DIK_DOWN)) && this->m_stateCurrent != ON_GROUND::IS_FALL)
		//{
			if(!this->m_isUnderWater)
			{
				//if(this->m_stateCurrent == ON_GROUND::IS_LYING && !CInput::GetInstance()->IsKeyDown(DIK_DOWN))
				//{
				//	//this->m_pos.y += 20;
				//	this->m_elapseTimeChangeFrame = 0.0f;
				//}
				this->m_stateCurrent = ON_GROUND::IS_STANDING;
			}
			else
			{
				if(!this->m_isShooting)
					this->m_stateCurrent = UNDER_WATER::IS_STANDING_UNDER_WATER;
			}
		//}
	}
#pragma endregion

#pragma region __XU_LY_PHIM_BAN__
	this->m_waitForShoot += deltaTime;
	if(m_keyDown == DIK_C)
	{
		if (this->m_currentFrame != 48)
		{
			if (this->m_waitForShoot > 0.1f)
			{
				switch (this->m_typeBullet)
				{
				case STATE_BULLET_ITEM::BULLET_ITEM_N:
					ManageAudio::GetInstance()->playSound(TypeAudio::BULLET_N);
					break;
				case STATE_BULLET_ITEM::BULLET_ITEM_M:
					ManageAudio::GetInstance()->playSound(TypeAudio::BULLET_M_SFX);
					break;
				case STATE_BULLET_ITEM::BULLET_ITEM_F:
					ManageAudio::GetInstance()->playSound(TypeAudio::BULLET_M_SFX);
					break;
				case STATE_BULLET_ITEM::BULLET_ITEM_L:
					ManageAudio::GetInstance()->playSound(TypeAudio::BULLET_L_SFX);
					break;
				case STATE_BULLET_ITEM::BULLET_ITEM_S:
					ManageAudio::GetInstance()->playSound(TypeAudio::BULLET_S);
					break;
				default:
					ManageAudio::GetInstance()->playSound(TypeAudio::BULLET_N);
					break;
				}
				this->m_isShoot = true;
				this->m_isShooting = true;
				this->m_waitForShoot = 0.0f;
			}
		}
	}
#pragma endregion

#pragma region __XU_LY_PHIM_NHAY__
	if(m_keyDown == DIK_X)
	{
		if(this->m_stateCurrent != ON_GROUND::IS_FALL)
		{
			if(!this->m_isUnderWater)
			{
				if(!CInput::GetInstance()->IsKeyDown(DIK_DOWN) || this->m_stateCurrent == ON_GROUND::IS_JUMPING)
				{
					this->m_stateCurrent = ON_GROUND::IS_JUMPING;
					//Duoc phep nhay
					if(!this->m_isJumping)
					{
						this->m_isJumping = true;
						this->m_vy = this->m_vyDefault;
					}
				}
				else
				{
					if(this->m_allowFall)
					{
						//this->m_elapseTimeChangeFrame = 0.0f;
						this->m_stateCurrent = ON_GROUND::IS_FALL;
						//Duoc phep nhay, kiem tra them va cham voi doi tuong nen dat cho phep nhay
						if(!this->m_isJumping)
						{
							this->m_pos.y -= 20; //Vuot qua va cham voi mat dat
							this->m_isJumping = true;
							this->m_vy = 0;
						}
					}
				}
			}
		}
	}
#pragma endregion

#pragma region __XU_LY_PHIM_DI_LEN__

	if(CInput::GetInstance()->IsKeyDown(DIK_UP))
	{
		this->m_stateShoot = SHOOT::IS_UP;
		if(this->m_isUnderWater)
		{
			if(this->m_isShoot) //Day vi tri cua box len
			{
				this->m_stateCurrent = UNDER_WATER::IS_SHOOTING_UNDER_WATER_UP;
			}
		}
		else
		{
			if(this->m_keyDown == DIK_X || this->m_isJumping)
			{
				//Chuyen sang trang thai nhay
				if(this->m_stateCurrent != ON_GROUND::IS_FALL)
				{
					this->m_stateCurrent = ON_GROUND::IS_JUMPING;
				}
				else
				{
					this->m_stateCurrent = ON_GROUND::IS_FALL;
				}
			}
			else
			{
				this->m_stateCurrent = ON_GROUND::IS_SHOOTING_UP;
			}
		}
	}
#pragma endregion

#pragma region __XU_LY_PHIM_DI_XUONG__
	if(CInput::GetInstance()->IsKeyDown(DIK_DOWN))
	{
		this->m_stateShoot = SHOOT::IS_NORMAL;
		if(this->m_isUnderWater)
		{
			this->m_stateCurrent = UNDER_WATER::IS_LYING_UNDER_WATER;
		}
		else
		{
			if(this->m_stateCurrent == ON_GROUND::IS_FALL)
			{
				//Chuyen sang trang thai roi
				this->m_stateCurrent = ON_GROUND::IS_FALL;
			}else if(this->m_isJumping)
			{
				this->m_stateCurrent = ON_GROUND::IS_JUMPING;
				this->m_stateShoot = SHOOT::IS_DOWN;
			}else
			{
				this->m_stateCurrent = ON_GROUND::IS_LYING;
			}
		}
	}
#pragma endregion

#pragma region __XU_LY_PHIM_DI_QUA_TRAI_HOAC_PHAI__
	if((CInput::GetInstance()->IsKeyDown(DIK_LEFT) || CInput::GetInstance()->IsKeyDown(DIK_RIGHT)))
	{
		if(CInput::GetInstance()->IsKeyDown(DIK_RIGHT))
		{
			this->m_left = false;
			this->m_isMoveRight = true;
			this->m_isMoveLeft = false;
			this->m_vx = this->m_vxDefault;
		}
		else
		{
			this->m_left = true;
			this->m_isMoveRight = false;
			this->m_isMoveLeft = true;
			this->m_vx = -this->m_vxDefault;
		}
		this->m_stateShoot = SHOOT::IS_NORMAL;
		if(this->m_isJumping)
		{
			//this->m_stateCurrent = ON_GROUND::IS_JUMPING;
			if(CInput::GetInstance()->IsKeyDown(DIK_UP))
			{
				this->m_stateShoot = SHOOT::IS_DIAGONAL_UP;
			}
			else if(CInput::GetInstance()->IsKeyDown(DIK_DOWN))
			{
				this->m_stateShoot = SHOOT::IS_DIAGONAL_DOWN;
			}
		}else{
			//Kiem tra contra co nam duoi nuoc hay ko
			if(!this->m_isUnderWater)
			{
				//Kiem tra neu phim di len duoc nhan
				if(CInput::GetInstance()->IsKeyDown(DIK_UP))
				{
					//Ban cheo len
					this->m_stateShoot = SHOOT::IS_DIAGONAL_UP;
					this->m_stateCurrent = ON_GROUND::IS_SHOOTING_DIAGONAL_UP;
				}
				else if(CInput::GetInstance()->IsKeyDown(DIK_DOWN))
				{
					//Ban cheo xuong
					//Neu trang thai truoc do la nhay pos.y +=22
					//if(this->m_stateCurrent == ON_GROUND::IS_LYING && (this->m_keyDown == DIK_LEFT || this->m_keyDown == DIK_RIGHT))
					//{
					//	//this->m_elapseTimeChangeFrame = 0.0f;
					//	//this->m_pos.y += 22;
					//}
					this->m_stateShoot = SHOOT::IS_DIAGONAL_DOWN;
					this->m_stateCurrent = ON_GROUND::IS_SHOOTING_DIAGONAL_DOWN;
				}
				else if(this->m_keyDown == DIK_X)
				{
					//Nhay
					this->m_stateCurrent = ON_GROUND::IS_JUMPING;
				}else if(this->m_keyDown == DIK_C || this->m_isShooting)
				{
					//Ban binh thuong
					this->m_stateCurrent = ON_GROUND::IS_SHOOTING_NORMAL;
				}else
				{
					//Chuyen sprite
					this->m_stateCurrent = ON_GROUND::IS_JOGGING;
				}
			}
			else //Dang nam duoi nuoc
			{
				if(this->m_isShooting) //Neu la dang ban
				{
					if(CInput::GetInstance()->IsKeyDown(DIK_UP))
					{
						//Ban cheo len
						this->m_stateShoot = SHOOT::IS_DIAGONAL_UP;
						//this->m_elapseTimeChangeFrame = 0.0f;
						//this->m_pos.y += 26;
						this->m_stateCurrent = UNDER_WATER::IS_SHOOTING_UNDER_WATER_DIAGONAL_UP;
					}
					else if(this->m_keyDown == DIK_C)
					{
						if (this->m_currentFrame != 48)//Tinh them zo bo ban luc contra lan
							this->m_stateCurrent = UNDER_WATER::IS_SHOOTING_UNDER_WATER_NORMAL;
					}
				}
				else if(CInput::GetInstance()->IsKeyDown(DIK_DOWN))
					{
						//Chuyen sang trang thai lan, khong di chuyen
						this->m_stateCurrent = UNDER_WATER::IS_LYING_UNDER_WATER;
						this->m_vx = 0;
					}
				else
				{
					this->m_stateCurrent = UNDER_WATER::IS_JOGGING_UNDER_WATER;
				}
			}
		}
	}
	#pragma endregion

	#pragma region NHAN NUT_DAU_DAN
		if (CInput::GetInstance()->IsKeyDown(DIK_N))
		{
			this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_N;
		}
		else if (CInput::GetInstance()->IsKeyDown(DIK_M))
		{
			this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_M;
		}
		else if (CInput::GetInstance()->IsKeyDown(DIK_S))
		{
			this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_S;
		}
		else if (CInput::GetInstance()->IsKeyDown(DIK_F))
		{
			this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_F;
		}
		else if (CInput::GetInstance()->IsKeyDown(DIK_L))
		{
			this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_L;
		}
		else if (CInput::GetInstance()->IsKeyDown(DIK_R))
		{
			//Tang toc do dan len
			CPoolingObject::m_isContraHaveBulletItemR = true;
		}
		else if (CInput::GetInstance()->IsKeyDown(DIK_B))
		{
			this->m_isHiding = true;
		}
	#pragma endregion
}
//Kiem tra co tao ra dan hay ko, sau nay add vao quadtree no se tu dong di chuyen

void CContra::BulletUpdate(float deltaTime)
{
	if(this->m_isShoot)
	{
		//Cap nhat goc quay
		float rotation = 0;
		switch (this->m_stateShoot)
		{
		case SHOOT::IS_NORMAL:
			{
				rotation = 0; //Goc ban bang 0
				break;
			}
		case SHOOT::IS_UP:
			{
				rotation = (float)PI/2; //Goc ban bang 90
				break;
			}
		case SHOOT::IS_DOWN:
			{
				rotation = -(float)PI / 2;
				break;
			}
		case SHOOT::IS_DIAGONAL_UP:
			{ 
				rotation = (float)PI / 4; //Goc ban bang 45
				break;
			}
		case SHOOT::IS_DIAGONAL_DOWN:
			{
				rotation = -(float)PI / 4;// //Goc ban bang -45
				break;
			}
		default:
			{
				rotation = 0;
				break;
			}
		}

	//Thiet lap vi tri cua dau dan .../pos = posContra + Offset 
	//Neu con tra o tren bo
	#pragma region _BAN DAN TREN BO
		D3DXVECTOR2 offset;
		if (!this->m_isUnderWater)
		{
			switch (this->m_stateCurrent)
			{
			case ON_GROUND::IS_LYING:
			{
				switch (this->m_typeBullet)
				{
					case STATE_BULLET_ITEM::BULLET_ITEM_M:
						if (!this->m_left){
							offset.x = 25.0f;
							offset.y = -27.0f;
						}
						else{
							offset.x = -25.0f;
							offset.y = -27.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_F:
						if (!this->m_left){
							offset.x = 60.0f;
							offset.y = -30.0f;
						}
						else{
							offset.x = -60.0f;
							offset.y = -30.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_L:
						if (!this->m_left){
							offset.x = 15.0f;
							offset.y = -25.0f;
						}
						else{
							offset.x = -15.0f;
							offset.y = -25.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_S:
						if (!this->m_left){
							offset.x = 30.0f;
							offset.y = -25.0f;
						}
						else{
							offset.x = -30.0f;
							offset.y = -25.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_B:
						this->m_isHiding = true;
						break;
					default:
					{
						if (!this->m_left){
							offset.x = 30.0f;
							offset.y = -25.0f;
						}
						else{
							offset.x = -30.0f;
							offset.y = -25.0f;
						}
						break;
					}
				}
				break;
			}
			case ON_GROUND::IS_FALL: case ON_GROUND::IS_JOGGING: case ON_GROUND::IS_SHOOTING_NORMAL: case ON_GROUND::IS_STANDING:
			{
				switch (this->m_typeBullet)
				{
					case STATE_BULLET_ITEM::BULLET_ITEM_M:
						if (!this->m_left){
							offset.x = 20.0f;
							offset.y = 0.0f;
						}
						else{
							offset.x = -20.0f;
							offset.y = 0.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_F:
						if (!this->m_left){
							offset.x = 50.0f;
							offset.y = -15.0f;
						}
						else{
							offset.x = -50.0f;
							offset.y = -15.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_L:
						if (!this->m_left){
							offset.x = 85.0f;
							offset.y = 0.0f;
						}
						else{
							offset.x = -85.0f;
							offset.y = 0.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_S:
						if (!this->m_left){
							offset.x = 28.0f;
							offset.y = 2.0f;
						}
						else{
							offset.x = -28.0f;
							offset.y = 2.0f;
						}

						CPoolingObject::m_isContraHaveBulletItemR = false;
						break;
					default:
					{
					if (!this->m_left){
						offset.x = 25.0f;
						offset.y = -0.0f;
					}
					else{
						offset.x = -25.0f;
						offset.y = -0.0f;
					}
					break;
					}
				}
				break;
			}
			case ON_GROUND::IS_SHOOTING_UP:
			{
				switch (this->m_typeBullet)
				{
					case STATE_BULLET_ITEM::BULLET_ITEM_M:
						if (!this->m_left){
							offset.x = -3.0f;
							offset.y = 50.0f;
						}
						else{
							offset.x = 3.0f;
							offset.y = 50.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_F:
						if (!this->m_left){
							offset.x = 0.0f;
							offset.y = 50.0f;
						}
						else{
							offset.x = 0.0f;
							offset.y = 50.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_L:
						if (!this->m_left){
							offset.x = 5.0f;
							offset.y = 70.0f;
						}
						else{
							offset.x = -7.0f;
							offset.y = 70.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_S:
						if (!this->m_left){
							offset.x = 0.0f;
							offset.y = 40.0f;
						}
						else{
							offset.x = 0.0f;
							offset.y = 40.0f;
						}
						break;
					default:
					{
					if (!this->m_left){
						offset.x = 3.0f;
						offset.y = 50.0f;
					}
					else{
						offset.x = -3.0f;
						offset.y = 50.0f;
					}
					break;
					}
				}
				break;
			}
			case ON_GROUND::IS_SHOOTING_DIAGONAL_DOWN:
			{
				switch (this->m_typeBullet)
				{
					case STATE_BULLET_ITEM::BULLET_ITEM_M:
						if (!this->m_left){
							offset.x = 25.0f;
							offset.y = -15.0f;
						}
						else{
							offset.x = -25.0f;
							offset.y = -15.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_F:
						if (!this->m_left){
							offset.x = 40.0f;
							offset.y = -35.0f;
						}
						else{
							offset.x = -80.0f;
							offset.y = 0.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_L:
						if (!this->m_left){
							offset.x = 55.0f;
							offset.y = -45.0f;
						}
						else{
							offset.x = -55.0f;
							offset.y = -45.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_S:
						if (!this->m_left){
							offset.x = 25.0f;
							offset.y = -15.0f;
						}
						else{
							offset.x = -25.0f;
							offset.y = -15.0f;
						}
						break;
					default:
					{
							if (!this->m_left){
								offset.x = 25.0f;
								offset.y = -15.0f;
							}
							else{
								offset.x = -25.0f;
								offset.y = -15.0f;
							}
							break;
					}
				}
				break;
			}
			case ON_GROUND::IS_SHOOTING_DIAGONAL_UP:
			{
				switch (this->m_typeBullet)
				{
					case STATE_BULLET_ITEM::BULLET_ITEM_M:
						if (!this->m_left){
							offset.x = 20.0f;
							offset.y = 25.0f;
						}
						else{
							offset.x = -20.0f;
							offset.y = 25.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_F:
						if (!this->m_left){
							offset.x = 50.0f;
							offset.y = 30.0f;
						}
						else{
							offset.x = -50.0f;
							offset.y = 20.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_L:
						if (!this->m_left){
							offset.x = 55.0f;
							offset.y = 50.0f;
						}
						else{
							offset.x = -55.0f;
							offset.y = 50.0f;
						}
						break;
					case STATE_BULLET_ITEM::BULLET_ITEM_S:
						if (!this->m_left){
							offset.x = 25.0f;
							offset.y = 30.0f;
						}
						else{
							offset.x = -25.0f;
							offset.y = 30.0f;
						}
						break;
					default:
					{
						if (!this->m_left){
							offset.x = 25.0f;
							offset.y = 25.0f;
						}
						else{
							offset.x = -25.0f;
							offset.y = 25.0f;
						}
						break;
					}
				}

				break;
			}
			case ON_GROUND::IS_JUMPING:
			{
										  switch (this->m_typeBullet)
										  {
										  case STATE_BULLET_ITEM::BULLET_ITEM_M:
											  if (!this->m_left){
												  offset.x = -10.0f;
												  offset.y = 10.0f;
											  }
											  else{
												  offset.x = 10.0f;
												  offset.y = 10.0f;
											  }
											  break;
										  case STATE_BULLET_ITEM::BULLET_ITEM_F:
											  if (!this->m_left){
												  offset.x = 25.0f;
												  offset.y = -15.0f;
											  }
											  else{
												  offset.x = -25.0f;
												  offset.y = -15.0f;
											  }
											  break;
										  case STATE_BULLET_ITEM::BULLET_ITEM_L:
											  if (!this->m_left){
												  offset.x = 25.0f;
												  offset.y = -15.0f;
											  }
											  else{
												  offset.x = -25.0f;
												  offset.y = -15.0f;
											  }
											  break;
										  case STATE_BULLET_ITEM::BULLET_ITEM_S:
											  if (!this->m_left){
												  offset.x = 25.0f;
												  offset.y = -15.0f;
											  }
											  else{
												  offset.x = -25.0f;
												  offset.y = -15.0f;
											  }
											  break;
										  default:
										  {
													 if (!this->m_left){
														 offset.x = 25.0f;
														 offset.y = -15.0f;
													 }
													 else{
														 offset.x = -25.0f;
														 offset.y = -15.0f;
													 }
													 break;
										  }
										  }
										  break;
			}
			}
		}
		#pragma endregion
	
	#pragma region _BAN DAN DUOI NUOC
		//Trung them cho nay
		else
		{
			switch (this->m_stateCurrent)
			{
				case UNDER_WATER::IS_SHOOTING_UNDER_WATER_NORMAL:
				{
					if (!this->m_left){
						offset.x = 20.0f;
						offset.y = -35.0f;
					}
					else{
						offset.x = -20.0f;
						offset.y = -35.0f;
					}
					break;
				}
				case UNDER_WATER::IS_SHOOTING_UNDER_WATER_UP:
				{
					if (!this->m_left){
						offset.x = 10.0f;
						offset.y = 5.0f;
					}
					else{
						offset.x = -10.0f;
						offset.y = 5.0f;
					}
					break;
				}
				case UNDER_WATER::IS_SHOOTING_UNDER_WATER_DIAGONAL_UP:
				{
					if (!this->m_left){
						offset.x = 17.0f;
						offset.y = -10.0f;
					}
					else{
						offset.x = -17.0f;
						offset.y = -10.0f;
					}
					break;
				}
			}
		}
#pragma endregion

		CBullet* bullet;
		switch (this->m_typeBullet)
		{
			case STATE_BULLET_ITEM::BULLET_ITEM_M:
				bullet = new CBullet_M(rotation, this->m_pos, offset, this->m_left);
				bullet->SetLayer(LAYER::PLAYER);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				break;
			case STATE_BULLET_ITEM::BULLET_ITEM_F:
				bullet = new CBullet_F(rotation, this->m_pos, offset, this->m_left);
				bullet->SetLayer(LAYER::PLAYER);
				CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
				break;
			case STATE_BULLET_ITEM::BULLET_ITEM_L:
				{
					//Cho nay t chinh lai nay, neu tren man hinh ma co vien dan L, thi t cap nhat lai vi tri cua no
					for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin();
						it != CPoolingObject::GetInstance()->m_listBulletOfObject.end(); ++it)
					{
						if((*it)->ClassName() == __CLASS_NAME__(CBullet_L))
						{
							CBullet_L* bulletL = ((CBullet_L*)(*it));
							bulletL->SetPos(this->m_pos);
							bulletL->SetOffset(offset);
							bulletL->SetRotation(rotation);
							bulletL->SetDirection(this->m_left);
							bulletL->Init();
							return;
						}
					}
					bullet = new CBullet_L(rotation, this->m_pos, offset, this->m_left);
					bullet->SetLayer(LAYER::PLAYER);
					CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
					break;
				}
			case STATE_BULLET_ITEM::BULLET_ITEM_S:
				{
					//Them dan S.
					CBullet_S* bulletS = new CBullet_S(rotation, this->m_pos, offset, this->m_left);
					bulletS->SetLayer(LAYER::PLAYER);
					CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bulletS->m_bullet_1);
					CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bulletS->m_bullet_2);
					CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bulletS->m_bullet_3);
					CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bulletS->m_bullet_4);
					CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bulletS->m_bullet_5);
					break;
				}
			case STATE_BULLET_ITEM::BULLET_ITEM_B:
				this->m_isHiding = true;
				break;
			default:
				{
					if (this->m_isShoot)
					{
						/*if (m_bulletCount > 0)
						{
							this->m_bulletCount = 0;
							this->m_isShoot = false;
						}
						else{*/
							bullet = new CBullet_N(rotation, this->m_pos, offset, this->m_left);
							bullet->SetLayer(LAYER::PLAYER);
							CPoolingObject::GetInstance()->m_listBulletOfObject.push_back(bullet);
							m_bulletCount++;
					//
					}
					break;
				}
		}

	}
}

void CContra::Update(float deltaTime)
{
#pragma region Thiet lap ko cho contra di ra khoi man hinh o map waterfall
	//Tinh//Xet ko cho contra di ra khoi man hinh chi voi map 3
	switch (CMenuGameScense::m_mapId)
	{
	case 10: case 12:
		if (this->m_pos.x - this->GetWidth() / 2 < CCamera::GetInstance()->GetCameraPos().x)
		{
			this->m_pos = D3DXVECTOR2(CCamera::GetInstance()->GetCameraPos().x + this->GetWidth() / 2, this->m_pos.y);
		}
		break;
	case 11:
		if (this->m_pos.x + this->GetWidth() / 4 > __SCREEN_WIDTH)
		{
			this->m_pos = D3DXVECTOR2(__SCREEN_WIDTH - this->GetWidth() / 4, this->m_pos.y);
		}
		else
		{
			if (this->m_pos.x - this->GetWidth() / 4 < 0)
			{
				this->m_pos = D3DXVECTOR2(this->GetWidth() / 4, this->m_pos.y);
			}
		}
		break;
	}
#pragma endregion

#pragma region Cap nhat luc contra co ALive = true
	if(this->m_isALive)
	{
		this->MoveUpdate(deltaTime);//Tinh moi chuyen MoveUpdate(...) len truoc SetFrame(...) 
		this->SetFrame(deltaTime);
		this->ChangeFrame(deltaTime);
		this->BulletUpdate(deltaTime);

		if (this->m_isHiding)
		{
			this->m_timeHided += deltaTime;
			this->m_timeHiding += deltaTime;
			if (this->m_timeHided > 0.09)
			{
				this->m_timeHided = 0.0f;
				this->m_isHided = !this->m_isHided;
			}
			if (this->m_timeHiding > 2.0f)
			{
				this->m_timeHiding = 0.0f;
				this->m_isHiding = false;
				this->m_isHided = false;
			}
		}
	}
#pragma endregion
#pragma region Cap nhat luc contra chet
	else
	{
		if (this->m_currentFrame == 40){
			//kiem tra mang
			if (this->m_countAlive == 0)
			{
				this->m_isGameOver = true;//Game Over Screen
				this->m_isALive = false;
				this->m_isDie = true;
			}
			else
			{
				//Cho 2s set trang thai contra lai 
				if (this->m_waitForDie <= 0)
				{
					this->m_isALive = true;
					this->m_isDie = false;
					this->m_currentFrame = 0;
					this->m_isStadingInStone = false;
					this->m_isUnderWater = false;
					this->m_stateCurrent = ON_GROUND::IS_JOGGING;
					//set lai vi tri contra
					switch (CMenuGameScense::m_mapId)
					{
					case 10: case 12:
						this->m_pos = D3DXVECTOR2(CCamera::GetInstance()->GetCameraPos().x + 100, CCamera::GetInstance()->GetCameraPos().y - 100);
						break;
					case 11:
						this->m_pos = D3DXVECTOR2(CCamera::GetInstance()->GetCameraPos().x + 140, CCamera::GetInstance()->GetCameraPos().y - 180);
						break;
					}
					this->m_waitForDie = 1.0f;
					//Xet lai dan cua contra la Normal(Bullet N)
					this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_N;
					//Cho no hidding
					this->m_isHiding = true;
					//Load sound contra up
					ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_1UP_SFX);
				}
				this->m_waitForDie -= deltaTime;
			}
		}
	}
	if(this->m_stateCurrent != ON_GROUND::IS_DIE && this->m_stateCurrent != UNDER_WATER::IS_DIE_UNDER_WATER)
		this->InputUpdate(deltaTime);
#pragma endregion
}

void CContra::Update(float deltaTime, std::vector<CGameObject*> listObjectCollision)
{

}

void CContra::OnCollision(float deltaTime, std::vector<CGameObject*>* listObjectCollision)
{
#pragma region XU_LY_VA_CHAM
	float normalX = 0;
	float normalY = 0;
	float moveX = 0.0f;
	float moveY = 0.0f;
	float timeCollision;
	//Kiem tra va cham voi ground
	bool checkColWithGround = false;
	//Kiem tra va cham voi water
	bool checkColWithWater = false;

	//Kiem tra xem contra khi chet co bi roi xuong duoi camera ko 
	if (this->m_isDie && this->m_pos.y < 0)
	{
		this->m_currentFrame = this->m_endFrame;
		this->m_isALive = false;
		return;
	}
	//Neu trang thai la die, khong xet va cham nua
	if (!this->m_isDie && !this->m_isHiding)//Neu da chet hoac dang o trang thai hiden thi ko xet va cham
	{
		#pragma region Va cham voi canh duoi camera
		if (!checkColWithWater)
		{
			if (CMenuGameScense::m_mapId == 11 || CMenuGameScense::m_mapId == 12 || CMenuGameScense::m_mapId == 10)
			{
				if ((this->m_pos.y - this->m_height) <= (CCamera::GetInstance()->GetCameraPos().y - 1.13f*__SCREEN_HEIGHT))
				{
					this->m_stateCurrent = ON_GROUND::IS_DIE;
					if (!this->m_isDie)
					{
						this->m_countAlive--;
						//
						if (this->m_left)
							this->m_vx = this->m_vxDefault;
						else
							this->m_vx = -this->m_vxDefault;
						this->m_vy = this->m_vyDefault;
						this->m_isDie = true;
						//
						this->m_elapseTimeChangeFrame = 0.23f;
						//Load sound contra die
						ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
					}
				}
			}
		}
		else
		{
			int temp = 0;
		}
		#pragma endregion

		#pragma region Va cham dan enemy voi contra
				for (std::vector<CBullet*>::iterator it = CPoolingObject::GetInstance()->m_listBulletOfObject.begin();
					it != CPoolingObject::GetInstance()->m_listBulletOfObject.end();)
				{
					CBullet* bullet = *it;
					if (bullet->IsAlive() && bullet->GetLayer() == LAYER::ENEMY)
					{
						if (CCollision::GetInstance()->Collision(this, bullet))
						{
							if (m_isUnderWater)
							{
								if (this->m_currentFrame != 48)//Tinh them zo de ko cho va cham voi dan enemy luc lan
								{
									//Load sound contra die
									ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
									this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;

									if (!this->m_isDie)
									{
										this->m_countAlive--;
										//
										if (this->m_left)
											this->m_vx = this->m_vxDefault;
										else
											this->m_vx = -this->m_vxDefault;
										this->m_vy = this->m_vyDefault;
										this->m_isDie = true;
										this->m_elapseTimeChangeFrame = 0.23f;

									}
									it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
								}
								else
									++it;
							}
							else
							{
								//Load sound contra die
								ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
								this->m_stateCurrent = ON_GROUND::IS_DIE;

								if (!this->m_isDie)
								{
									this->m_countAlive--;
									//
									if (this->m_left)
										this->m_vx = this->m_vxDefault;
									else
										this->m_vx = -this->m_vxDefault;
									this->m_vy = this->m_vyDefault;
									this->m_isDie = true;
									this->m_elapseTimeChangeFrame = 0.23f;

								}
								it = CPoolingObject::GetInstance()->m_listBulletOfObject.erase(it);
							}
							
						}
						else
							++it;
					}
					else
						++it;
				}
		#pragma endregion

		#pragma region _va cham voi laze_
				for (std::vector<CBulletLaze*>::iterator itLaze = CPoolingObject::GetInstance()->m_listBulletLaze.begin();
					itLaze != CPoolingObject::GetInstance()->m_listBulletLaze.end();)
				{
					CBulletLaze* bullet = *itLaze;
					if (bullet->IsAlive())
					{
						if (CCollision::GetInstance()->Collision(this, bullet))
						{
							//Load sound contra die
							ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
							//
							if (m_isUnderWater)
							{
								this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;
							}
							else
							{
								this->m_stateCurrent = ON_GROUND::IS_DIE;
							}
							if (!this->m_isDie)
							{
								this->m_countAlive--;
								//
								if (this->m_left)
									this->m_vx = this->m_vxDefault;
								else
									this->m_vx = -this->m_vxDefault;
								this->m_vy = this->m_vyDefault;
								this->m_isDie = true;
								this->m_elapseTimeChangeFrame = 0.23f;
							}

							CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
							effect->SetAlive(true);
							effect->SetPos(bullet->GetPos());
							itLaze = CPoolingObject::GetInstance()->m_listBulletLaze.erase(itLaze);
						}
						else
							++itLaze;
					}
					else
						++itLaze;
				}
		#pragma endregion

		#pragma region _va cham voi Solider_
				for (std::vector<CSoldier*>::iterator itLaze = CPoolingObject::GetInstance()->m_listSolider.begin();
					itLaze != CPoolingObject::GetInstance()->m_listSolider.end();)
				{
					CSoldier* soldier = *itLaze;
					if (soldier->IsAlive())
					{
						if (CCollision::GetInstance()->Collision(this, soldier))
						{
							//Load sound contra die
							ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
							//
							if (m_isUnderWater)
							{
								this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;
							}
							else
							{
								this->m_stateCurrent = ON_GROUND::IS_DIE;
							}
							if (!this->m_isDie)
							{
								this->m_countAlive--;
								//
								if (this->m_left)
									this->m_vx = this->m_vxDefault;
								else
									this->m_vx = -this->m_vxDefault;
								this->m_vy = this->m_vyDefault;
								this->m_isDie = true;
								this->m_elapseTimeChangeFrame = 0.23f;
							}
							else
								++itLaze;
						}
						else
							++itLaze;
					}
					else
						++itLaze;
				}
		#pragma endregion

		#pragma region _va cham voi Solider Shoot_
				for (std::vector<CSoldierShoot*>::iterator itLaze = CPoolingObject::GetInstance()->m_listSoliderShoot.begin();
					itLaze != CPoolingObject::GetInstance()->m_listSoliderShoot.end();)
				{
					CSoldierShoot* soldierS = *itLaze;
					if (soldierS->IsAlive())
					{
						if (CCollision::GetInstance()->Collision(this, soldierS))
						{
							//Load sound contra die
							ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
							//
							if (m_isUnderWater)
							{
								this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;
							}
							else
							{
								this->m_stateCurrent = ON_GROUND::IS_DIE;
							}
							if (!this->m_isDie)
							{
								this->m_countAlive--;
								//
								if (this->m_left)
									this->m_vx = this->m_vxDefault;
								else
									this->m_vx = -this->m_vxDefault;
								this->m_vy = this->m_vyDefault;
								this->m_isDie = true;
								this->m_elapseTimeChangeFrame = 0.23f;
							}
							else
								++itLaze;
						}
						else
							++itLaze;
					}
					else
						++itLaze;
				}
		#pragma endregion

		#pragma region Xet va cham voi Scuba bullet
				for (std::vector<CBullet_ScubaSolider*>::iterator itScuba = CPoolingObject::GetInstance()->m_listBulletScubaSolider.begin();
					itScuba != CPoolingObject::GetInstance()->m_listBulletScubaSolider.end();)
				{
					CBullet_ScubaSolider* bullet = *itScuba;
					if (bullet->IsAlive())
					{
						if (CCollision::GetInstance()->Collision(this, bullet))
						{
							//Load sound contra die
							ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
							//
							if (m_isUnderWater)
							{
								this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;
							}
							else
							{
								this->m_stateCurrent = ON_GROUND::IS_DIE;
							}
							if (!this->m_isDie)
							{
								this->m_countAlive--;
								//
								if (this->m_left)
									this->m_vx = this->m_vxDefault;
								else
									this->m_vx = -this->m_vxDefault;
								this->m_vy = this->m_vyDefault;
								this->m_isDie = true;
								this->m_elapseTimeChangeFrame = 0.23f;
							}

							CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
							effect->SetAlive(true);
							effect->SetPos(bullet->GetPos());
							itScuba = CPoolingObject::GetInstance()->m_listBulletScubaSolider.erase(itScuba);
						}
						else
							++itScuba;
					}
					else
						++itScuba;
				}
		#pragma endregion

		#pragma region Va cham voi Big Stone
				for (std::vector<CBigStone*>::iterator itStone = CPoolingObject::GetInstance()->m_listBigStone.begin();
					itStone != CPoolingObject::GetInstance()->m_listBigStone.end();)
				{
					CBigStone* stone = *itStone;
					if (stone->IsAlive())
					{
						if (CCollision::GetInstance()->Collision(this, stone))
						{
							//Load sound contra die
							ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
							//
							if (m_isUnderWater)
							{
								this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;
							}
							else
							{
								this->m_stateCurrent = ON_GROUND::IS_DIE;
							}
							if (!this->m_isDie)
							{
								this->m_countAlive--;
								//
								if (this->m_left)
									this->m_vx = this->m_vxDefault;
								else
									this->m_vx = -this->m_vxDefault;
								this->m_vy = this->m_vyDefault;
								this->m_isDie = true;
								this->m_elapseTimeChangeFrame = 0.23f;
							}

							CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
							effect->SetAlive(true);
							effect->SetPos(stone->GetPos());
							itStone = CPoolingObject::GetInstance()->m_listBigStone.erase(itStone);
						}
						else
							++itStone;
					}
					else
						++itStone;
				}
		#pragma endregion

		#pragma region Va cham voi Capsule cua boss map 5
				for (std::vector<CCapsuleBoss*>::iterator itCapsule = CPoolingObject::GetInstance()->m_listCapsuleBoss.begin();
					itCapsule != CPoolingObject::GetInstance()->m_listCapsuleBoss.end();)
				{
					CCapsuleBoss* capsule = *itCapsule;
					if (capsule->IsAlive())
					{
						if (CCollision::GetInstance()->Collision(this, capsule))
						{
							//Load sound contra die
							ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
							//
							if (m_isUnderWater)
							{
								this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;
							}
							else
							{
								this->m_stateCurrent = ON_GROUND::IS_DIE;
							}
							if (!this->m_isDie)
							{
								this->m_countAlive--;
								//
								if (this->m_left)
									this->m_vx = this->m_vxDefault;
								else
									this->m_vx = -this->m_vxDefault;
								this->m_vy = this->m_vyDefault;
								this->m_isDie = true;
								this->m_elapseTimeChangeFrame = 0.23f;
							}
							CEnemyEffect* effect = CPoolingObject::GetInstance()->GetEnemyEffect();
							effect->SetAlive(true);
							effect->SetPos(capsule->GetPos());
						
							itCapsule = CPoolingObject::GetInstance()->m_listCapsuleBoss.erase(itCapsule);
						}
						else
							++itCapsule;
					}
					else
						++itCapsule;
				}
		#pragma endregion
	}
	////
	for (std::vector<CGameObject*>::iterator it = listObjectCollision->begin(); it != listObjectCollision->end(); it++)
	{
		CGameObject* obj = *it;
		//Lay thoi gian va cham
		//Neu doi tuong la ground va dang va cham
		if(obj->GetIDType() == 15 || obj->GetIDType() == 16)
		{
			timeCollision = CCollision::GetInstance()->Collision(CContra::GetInstance(), obj, normalX, normalY, moveX, moveY, deltaTime);
			if((timeCollision > 0.0f && timeCollision < 1.0f) || timeCollision == 2.0f)
			{
				if (normalY > 0)
				{
					if (this->m_vy<=0){
						#pragma region VA CHAM VS CAY CAU DA
						if (obj->GetIDType() == 16 && obj->GetID() == 3 && !checkColWithGround)
						{

							this->m_isStadingInStone = true;
							CBridgeStone* objBridgeStone = (CBridgeStone*)obj;
							checkColWithGround = true;
							this->m_isUnderWater = false;
							this->m_allowFall = false;
							this->m_vx = this->m_vx + objBridgeStone->GetVx();
							if (objBridgeStone->GetVx() > 0)
							{
								this->m_isMoveRight = true;
								this->m_isMoveLeft = false;
							}
							else
							{
								this->m_isMoveRight = false;
								this->m_isMoveLeft = true;
							}

							if (timeCollision == 2.0f)
							{
								if (this->m_vy <= 0)
								{
									if ((this->m_stateCurrent == ON_GROUND::IS_DIE))
									{
										if (this->m_isDie && this->m_vy < -165)
										{
											this->m_currentFrame = this->m_endFrame;
											this->m_isALive = false;
											return;
										}
									}
									else if (this->m_stateCurrent == ON_GROUND::IS_JUMPING)
									{
										if (this->m_vy < -165)
										{
											this->m_elapseTimeChangeFrame = 0.0f;
											this->m_isJumping = false;
											this->m_currentFrame = 0;
											this->m_stateCurrent = ON_GROUND::IS_STANDING;
										}
									}
									else
									{
										this->m_isJumping = false;
										this->m_pos.y += moveY;
										this->m_vy = 0;
									}
								}
								if (this->m_stateCurrent == ON_GROUND::IS_FALL)
								{
									this->m_stateCurrent = ON_GROUND::IS_STANDING;
									this->m_isJumping = false;
								}

							}
							else{
								if (this->m_stateCurrent == ON_GROUND::IS_JUMPING && this->m_vy < 0)
								{
									this->m_pos.y += (this->m_vy /** timeCollision*/) * deltaTime;
									this->m_elapseTimeChangeFrame = 0.0f;
									this->m_currentFrame = 0;
									if (this->m_keyDown != DIK_DOWN)
										this->m_stateCurrent = ON_GROUND::IS_STANDING;
									else
										this->m_stateCurrent = ON_GROUND::IS_LYING;
									this->m_isJumping = false;
								}
							}
						}
						#pragma endregion
					}
					#pragma region VA CHAM MAT DAT && CAY CAU(Cau lua va cau thuong)
					if ((obj->GetID() == 1 || obj->GetID() == 8 || (obj->GetID() == 1 || obj->GetID() == 2 && obj->GetIDType() == 16)) && !checkColWithGround)
					{
						//
						this->m_isStadingInStone = false;

						#pragma region Va cham voi Cuc lua cua cay cau lua map 3
						if (CMenuGameScense::m_mapId == 11)
						{
							if (obj->GetIDType() == 16 && obj->GetID() == 2)
							{
								CBridgeFire* objBridgeFire = (CBridgeFire*)obj;

								if (CCollision::GetInstance()->Collision(this, objBridgeFire->fireLeft) ||
									CCollision::GetInstance()->Collision(this, objBridgeFire->fireRight))
								{
									this->m_stateCurrent = ON_GROUND::IS_DIE;
									if (!this->m_isDie)
									{
										this->m_countAlive--;
										//
										if (this->m_left)
											this->m_vx = this->m_vxDefault;
										else
											this->m_vx = -this->m_vxDefault;
										this->m_vy = this->m_vyDefault;
										this->m_isDie = true;
										this->m_elapseTimeChangeFrame = 0.23f;
									}
								}
							}
						}
						#pragma endregion

						#pragma region VA CHAM VOI MAT DAT MA KO THE ROI
						if(obj->GetID() == 8 && obj->GetIDType() == 15)
							this->m_allowFall = false;
						else
							this->m_allowFall = true;
						#pragma endregion

						checkColWithGround = true;
						this->m_isUnderWater = false;
						if( timeCollision == 2.0f)
						{
							if(this->m_vy <= 0)
							{
								if((this->m_stateCurrent == ON_GROUND::IS_DIE || this->m_stateCurrent == UNDER_WATER::IS_DIE_UNDER_WATER))
								{
									if(this->m_isDie && this->m_vy < -165)
									{
										this->m_currentFrame = this->m_endFrame;
										this->m_isALive = false;
										return;
									}
								}
								else if(this->m_stateCurrent == ON_GROUND::IS_JUMPING)
								{
									if(this->m_vy < -165)
									{
										//this->m_pos.y += 20;
										this->m_elapseTimeChangeFrame = 0.0f;
										this->m_isJumping = false;
										this->m_currentFrame = 0;
										this->m_stateCurrent = ON_GROUND::IS_STANDING;
									}
								}
								else
								{
									this->m_isJumping = false;
									this->m_pos.y += moveY;
									this->m_vy = 0;
								}
							}
							if(this->m_stateCurrent == ON_GROUND::IS_FALL)
							{
								this->m_stateCurrent = ON_GROUND::IS_STANDING;
								this->m_isJumping = false;
							}

						}else{
							//if(this->m_vy != 0)
							//{
							if(this->m_stateCurrent == ON_GROUND::IS_JUMPING && this->m_vy < 0)
							{

								//this->m_pos.y += 22;
								this->m_pos.y += (this->m_vy /** timeCollision*/) * deltaTime;
								this->m_elapseTimeChangeFrame = 0.0f;
								this->m_currentFrame = 0;
								if(this->m_keyDown != DIK_DOWN)
									this->m_stateCurrent = ON_GROUND::IS_STANDING;
								else
									this->m_stateCurrent = ON_GROUND::IS_LYING;
								this->m_isJumping = false;
							}
						
							//	this->m_isJumping = false;
							//	this->m_pos.y += (this->m_vy /** timeCollision*/) * deltaTime;
							//	this->m_vy = 0;
							//}
						}
					}
					#pragma endregion

					#pragma region VA CHAM MAT NUOC
									if(!checkColWithWater && obj->GetID() == 2 && !checkColWithGround)
									{
										//O duoi nuoc khong the nhay
										checkColWithWater = true;
										if(this->m_stateCurrent == ON_GROUND::IS_FALL)
										{
											this->m_stateCurrent = UNDER_WATER::IS_LYING_UNDER_WATER;
										}
										this->m_isUnderWater = true;
										this->m_isJumping = false;
										if( timeCollision == 2.0f)
										{
											if(this->m_vy <= 0)
											{
												if((this->m_stateCurrent == ON_GROUND::IS_DIE || this->m_stateCurrent == UNDER_WATER::IS_DIE_UNDER_WATER))
												{
													if(this->m_isDie && this->m_vy < -165)
													{
														//this->m_currentFrame = this->m_endFrame;
														//this->m_isALive = false;
														return;
													}
												}
												//if(this->m_stateCurrent == UNDER_WATER::IS_LYING_UNDER_WATER)
												//{
												//	//this->m_pos.y += 20;
												//	this->m_pos.y += moveY;
												//	this->m_vy = 0;
												//	//this->m_elapseTimeChangeFrame = 0.0f;
												//}
												else
												{
													this->m_pos.y += moveY;
													this->m_vy = 0;
												}
											}
										}
										else
										{
											this->m_pos.y += -1;
										}
									}
				#pragma endregion 

					#pragma region DANG VA CHAM VOI NUOC VA CHUYEN LEN MAT DAT
									if((checkColWithWater || this->m_stateCurrent > 20) && checkColWithGround) //Neu dang va cham voi mat nuoc
									{
										this->m_isUnderWater = false;
										//this->m_pos.y += 10;
										if(this->m_left)
										{
											this->m_pos.x -= 0;
										}
										else
										{
											this->m_pos.x += 0;
										}
										this->m_elapseTimeChangeFrame = 0.3f;
										this->m_stateCurrent = ON_GROUND::IS_UP_GROUND;
									}
									continue;
					#pragma endregion
					//TT
				}
				#pragma region VA CHAM VOI BE THANG DUNG CUA DA O MAP 5
					if ((obj->GetID() == 15 && obj->GetIDType() == 15) && !checkColWithGround)
					{
						this->m_allowFall = false;
						checkColWithGround = true;
						this->m_isUnderWater = false;
						this->m_vx = 0;
						if (this->m_left)
							this->m_pos.x = obj->GetPos().x + (obj->GetWidth() / 3);
						else
							this->m_pos.x = obj->GetPos().x - (obj->GetWidth() / 3);
					}
				#pragma endregion

				#pragma region VA CHAM VS CAY CAU NO
							else if (obj->GetIDType() == 15 && obj->GetID() == 5)
							{
								this->m_bridgeEffect = true;
							}
				#pragma endregion
	
				#pragma region VA CHAM DOI TUONG SINH WEAPON
								else if(obj->GetIDType() == 14 
									&& (this->m_stateCurrent != ON_GROUND::IS_DIE && this->m_stateCurrent != UNDER_WATER::IS_DIE_UNDER_WATER))
								{
									if(obj->GetID() != 8)
									{
										D3DXVECTOR2 pos = CCamera::GetInstance()->GetPointTransform(obj->GetPos().x, obj->GetPos().y);
										pos.x = __SCREEN_WIDTH - pos.x + obj->GetPos().x;
										pos.y = 300;
										CWeapon* weapon = new CWeapon(pos, obj->GetID());
										/*CPoolingObject::GetInstance()->m_listWeapon.push_back(new CSoldier(obj->*/
									}
									else
									{
										if(((CBulletItem*)(obj))->m_stateItem != STATE_BULLET_ITEM::BULLET_ITEM_B && 
											((CBulletItem*)(obj))->m_stateItem != STATE_BULLET_ITEM::BULLET_ITEM_R)
										{
											this->m_typeBullet = ((CBulletItem*)(obj))->m_stateItem;
										}
									}
								}
				#pragma endregion
			}
		}
		if (!this->m_isDie && !this->m_isHiding)//Neu da chet hoac dang o trang thai hiden thi ko xet va cham
		{
			#pragma region VA CHAM VOI ENEMY
			if (obj->GetLayer() == LAYER::ENEMY && obj->IsAlive()
				&& (this->m_stateCurrent != ON_GROUND::IS_DIE && this->m_stateCurrent != UNDER_WATER::IS_DIE_UNDER_WATER))
			{
				if (CCollision::GetInstance()->Collision(CContra::GetInstance(), obj))//va cham tru 2 obj là ground cannon vs wallturet//set Layer cho 2 no 
				{
					//Load sound contra die
					ManageAudio::GetInstance()->playSound(TypeAudio::RAMBO_DEAD_SFX);
					//
					if (m_isUnderWater)
					{
						this->m_stateCurrent = UNDER_WATER::IS_DIE_UNDER_WATER;
					}
					else
					{
						this->m_stateCurrent = ON_GROUND::IS_DIE;
					}
					if (!this->m_isDie)
					{
						this->m_countAlive--;
						//
						if (this->m_left)
							this->m_vx = this->m_vxDefault;
						else
							this->m_vx = -this->m_vxDefault;
						this->m_vy = this->m_vyDefault;
						this->m_isDie = true;
						this->m_elapseTimeChangeFrame = 0.23f;
					}
				}
			}
			#pragma endregion
		}
	}
	if(!checkColWithGround && !checkColWithWater && this->m_stateCurrent != UNDER_WATER::IS_DIE_UNDER_WATER && this->m_stateCurrent != ON_GROUND::IS_DIE)
	{
		if(this->m_isUnderWater)
		{
			//this->m_isUnderWater = false;
			this->m_pos.y -= 10;
		}
		else
		{
			if(this->m_stateCurrent != ON_GROUND::IS_JUMPING)
			{
				if(this->m_stateCurrent == ON_GROUND::IS_LYING)
				{
					//this->m_pos.y -= 15;
					this->m_currentFrame = 52;
					//this->m_stateCurrent = ON_GROUND::IS_STANDING;
					this->m_isJumping = false;
				}
				else
				{
					this->m_stateCurrent = ON_GROUND::IS_FALL;
					this->m_isJumping = true;
				}										
			}
		}
	}
}
	
RECT* CContra::GetRectRS()
{
	return this->UpdateRectResource(m_height, m_width);
}

RECT* CContra::GetBound()
{
	return nullptr;
}

Box CContra::GetBox()
{
	//return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height, this->m_vx, this->m_vy);
	if(!this->m_isUnderWater)
	{
		switch (this->m_stateCurrent)
		{
		case ON_GROUND::IS_FALL:
		case ON_GROUND::IS_JOGGING:
		case ON_GROUND::IS_SHOOTING_DIAGONAL_DOWN:
		case ON_GROUND::IS_SHOOTING_NORMAL:
		case ON_GROUND::IS_SHOOTING_DIAGONAL_UP:
		case ON_GROUND::IS_STANDING:
		case ON_GROUND::IS_SHOOTING_UP:
			{
				return Box(this->m_pos.x, this->m_pos.y - 10.0f, this->m_width - 45, this->m_height - 22, this->m_vx, this->m_vy);
			}
		case ON_GROUND::IS_JUMPING:
			{
				return Box(this->m_pos.x, this->m_pos.y - 28.0f, this->m_width - 40, this->m_height - 55, this->m_vx, this->m_vy);
			}
		case ON_GROUND::IS_LYING:
			{
				return Box(this->m_pos.x, this->m_pos.y - 34.0f, this->m_width - 20, this->m_height - 65, this->m_vx, this->m_vy);
			}
		case ON_GROUND::IS_UP_GROUND:
			{
				return Box(this->m_pos.x, this->m_pos.y - 28, this->m_width - 40, this->m_height - 62, this->m_vx, this->m_vy);
			}
		case ON_GROUND::IS_DIE:
			{
				return Box(this->m_pos.x, this->m_pos.y - 34.0f, this->m_width, this->m_height - 65, this->m_vx, this->m_vy);
			}
		default:
			{
				break;
			}
		}
	}
	else
	{
		//return Box(this->m_pos.x, this->m_pos.y, this->m_width, this->m_height, this->m_vx, this->m_vy);
		switch (this->m_stateCurrent)
		{
		case UNDER_WATER::IS_JOGGING_UNDER_WATER:
		case UNDER_WATER::IS_LYING_UNDER_WATER:
		case UNDER_WATER::IS_STANDING_UNDER_WATER:
			{
				return Box(this->m_pos.x, this->m_pos.y - 26, this->m_width - 40, this->m_height - 60, this->m_vx, this->m_vy);
			}
		case UNDER_WATER::IS_SHOOTING_UNDER_WATER_DIAGONAL_UP:
		case UNDER_WATER::IS_SHOOTING_UNDER_WATER_UP:
			{
				return Box(this->m_pos.x, this->m_pos.y - 28, this->m_width - 40, this->m_height - 64, this->m_vx, this->m_vy);
			}
		case UNDER_WATER::IS_SHOOTING_UNDER_WATER_NORMAL:
			{
				return Box(this->m_pos.x, this->m_pos.y - 28, this->m_width - 40, this->m_height - 62, this->m_vx, this->m_vy);
			}
		case UNDER_WATER::IS_DIE_UNDER_WATER:
			{
				return Box(this->m_pos.x, this->m_pos.y - 34, this->m_width, this->m_height - 65, this->m_vx, this->m_vy);
			}
		default:
			return Box(this->m_pos.x, this->m_pos.y, this->m_width - 40, this->m_height - 50, this->m_vx, this->m_vy);
			break;
		}
	}
}

void CContra::Reset()
{
	//Xet lai vi tri camera
	CCamera::GetInstance()->SetPos(D3DXVECTOR3(0, __SCREEN_HEIGHT, 0));
	this->m_isBossCurrentDie = false;
	this->m_left = false;
	this->m_isALive = true;
	this->m_isDie = false;
	this->m_isDrawBoss = false;
	this->m_stateCurrent = ON_GROUND::IS_JOGGING;
	//Cho no hidding
	this->m_isHiding = true;
	if (this->m_isGameOver)
	{
		CScenseManagement::m_isGameOverred = false;
		this->m_pos = this->m_posStart;
		this->m_isGameOver = false;
		this->m_countAlive = __ALIVE_CONTRA_MAX__;
		this->m_scoreGame = 0;
		//Xet lai dan cua contra la Normal(Bullet N)
		this->m_typeBullet = STATE_BULLET_ITEM::BULLET_ITEM_N;
	}
	else
	{
		CScenseManagement::m_isWinScenseShowed = false;
		this->m_vx = 0;
		this->m_vy = -this->m_vyDefault;
		//Set vi tri contra theo map
		switch (CMenuGameScense::m_mapId)
		{
		case 10:
			this->m_pos = D3DXVECTOR2(100.0f, 400.0f);
			ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_1);
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_3);
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_5);
			break;
		case 11:
			this->m_pos = D3DXVECTOR2(120.0f, 300.0f);
			ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_3);
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_1);
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_5);
			break;
		case 12:
			this->m_pos = D3DXVECTOR2(100.0f, 450.0f);
			ManageAudio::GetInstance()->playSound(TypeAudio::AUDIO_BACKGROUND_STATE_5);
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_3);
			ManageAudio::GetInstance()->stopSound(TypeAudio::AUDIO_BACKGROUND_STATE_1);
			break;
		}
		this->m_posStart = this->m_pos;
	}
}

void CContra::SetScoreGame(int score)
{
	this->m_scoreGame = score;
}

int CContra::GetScoreGame()
{
	return this->m_scoreGame;
}

void CContra::IncreateScore(int score)
{
	this->m_scoreGame += score;
}