#include "CRockman.h"

struct TimeCollideGreater{
	bool operator()(CollisionInfo* lx, CollisionInfo* rx) const {
		return lx->_timeCollide < rx->_timeCollide;
	}
};

CRockman::CRockman() :CMoveableObject()
{
	_typeID = ID_ROCKMAN;
}

CRockman::~CRockman()
{

}

int CRockman::Initlize()
{
	// Cài đặt trạng thái Ready cho Rockman
	_v.x = 0.0f;
	_v.y = -ROCKMAN_VERLOCITY_Y;
	_a.x = 0.0f;
	_a.y = -ROCKMAN_ACCELERATE_Y;
	_behave = Behave::START;
	_life = LIFE_DEFAULT;
	_blood = BLOOD_DEFAULT;
	_isRequireEndGame = false;
	_isInBossRoom = false;
	_isRight = true;
	_canJump = true;
	_canJumpMore = true;
	_isRequireOverDoor = false;
	_isRequireStopScreen = false;
	_isOverDoor = false;
	_isGoingOverDoor = false;
	_canFire = true;
	_isTheFirstTime = true;
	_isInShield = false;
	_changeScreenDirection = CDirection::NONE_DIRECT;

	// Cài đặt một số biến thời gian cần thiết cho việc vẽ các đối tượng
	_deltaTime = 0;
	_timeDie = 5.0f * 1000;
	_jumpTime = 0.0f;
	_timeOverDoor = 0;
	_deltaTimeCanFire = 0;
	_typeID = ID_ROCKMAN;

	// Khởi động Rockman, lấy các skill từ CGameInfo
	vector<Skill> skills = CGameInfo::GetInstance()->GetSkills();
	for (int i = 0; i < skills.size(); i++)
	{
		_skillInfos.insert(pair<Skill, int>(skills[i], WEASPON_DEFAULT));
	}
	_currentSkill = Skill::NORMAL;

	// Cần phải lấy sprite tương ứng trước để thực hiện việc vẽ và cập nhật box va chạm
	// Vì thế giới thực hiện vẽ trước khi update
	UpdateAnimation();
	UpdateBox();

	// Xác định các đối tượng có va chạm
	_collidedObjectInside = new  CollisionInfo(NULL, CDirection::INSIDE, std::numeric_limits<float>::infinity());


	_collidedObjectGroundLeft = new  CollisionInfo(NULL, CDirection::ON_LEFT, std::numeric_limits<float>::infinity());
	_collidedObjectGroundRight = new  CollisionInfo(NULL, CDirection::ON_RIGHT, std::numeric_limits<float>::infinity());
	_collidedObjectGroundUp = new  CollisionInfo(NULL, CDirection::ON_UP, std::numeric_limits<float>::infinity());
	_collidedObjectGroundDown = new  CollisionInfo(NULL, CDirection::ON_DOWN, std::numeric_limits<float>::infinity());
	_collidedObjectGroundInside = new  CollisionInfo(NULL, CDirection::INSIDE, std::numeric_limits<float>::infinity());

	return 1;
}

void CRockman::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if ((_isRequireStopScreen ^ _behave != Behave::DYING) && _behave != Behave::REAL_DIE)
	{
		bool isDraw = true;
		if (_isInShield || _behave == Behave::HURT_IN_AIR || _behave == Behave::HURT_ON_GROUND)
		{
			if (_deltaTime >= 0.0f)
			{
				_deltaTime -= gameTime->GetDeltaTime();
				if (_deltaTime <= 0.0f)
					_deltaTime = -50;
			}
			else
			{
				_deltaTime += gameTime->GetDeltaTime();
				if (_deltaTime >= 0.0f)
					_deltaTime = 50.0f;
			}

			if (_deltaTime < 0.0f)
				isDraw = false;
		}
		if (_isRequireStopScreen)
			isDraw = true;
		if (isDraw)
			switch (_behave)
		{
			case STAIR:
				if (_v.y == 0.0f)
				{
					if (_isRight)
						_sprite.SetIndex(1);
					else
						_sprite.SetIndex(0);
				}
				graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
				break;
			case STAND_FIRE:
				if (_isRight)
					graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position + Vector2(5, 0), true);
				else
					graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position - Vector2(5, 0), true, SpriteEffects::FLIP_HORIZONTALLY);
				break;
			case STAIR_FIRE:
				if (_isRight)
					graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position + Vector2(5, 0), true);
				else
					graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position - Vector2(5, 0), true, SpriteEffects::FLIP_HORIZONTALLY);
				break;
			default:
				if (_isRight)
					graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
				else
					graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true, SpriteEffects::FLIP_HORIZONTALLY);
				break;
		}
		if ((_behave == Behave::HURT_IN_AIR || _behave == Behave::HURT_ON_GROUND || _isInShield) && _confuses.size() != 0)
		{
			graphics->Draw(_confuses[0].GetTexture(), _confuses[0].GetDestinationRectangle(), _position + Vector2(-GetBox()._width / 2 - 1, GetBox()._height / 2 + 3), true);
			graphics->Draw(_confuses[1].GetTexture(), _confuses[1].GetDestinationRectangle(), _position + Vector2(0, GetBox()._height / 2 + 5), true);
			graphics->Draw(_confuses[2].GetTexture(), _confuses[2].GetDestinationRectangle(), _position + Vector2(GetBox()._width / 2 + 1, GetBox()._height / 2 + 3), true);

			for (int i = 0; i < _confuses.size(); i++)
				_confuses[i].Update(gameTime);
			if (_confuses[0].GetIndex() == _confuses[0].GetCountFrame() - 1)
				_confuses.clear();
		}
		CMoveableObject::Render(gameTime, graphics);
	}
}

void CRockman::Update(CGameTime* gameTime)
{
	if (IsDied())
		return;

	if (_behave != Behave::DYING)
	{
#pragma region Xử lý tiền va chạm, các đối tượng được dự đoán là va chạm trong frame trước được xử lý tương ứng ở đây

		// Giả định rockman không vạ chạm với bất kì đối tượng nào trong frame này
		bool isFalled = true;

		// Sắp xếp danh sách các đối tượng va chạm
		vector<CollisionInfo*> collidedLst;
		if (_behave != Behave::HURT_IN_AIR&&_behave != Behave::HURT_ON_GROUND&&_collidedObjectInside->_object != NULL)
			collidedLst.push_back(_collidedObjectInside);

		vector<CollisionInfo*> collidedGroundLst;
		if (_collidedObjectGroundLeft->_object != NULL)
			collidedGroundLst.push_back(_collidedObjectGroundLeft);
		if (_collidedObjectGroundRight->_object != NULL)
			collidedGroundLst.push_back(_collidedObjectGroundRight);
		if (_collidedObjectGroundUp->_object != NULL)
			collidedGroundLst.push_back(_collidedObjectGroundUp);
		if (_collidedObjectGroundDown->_object != NULL)
			collidedGroundLst.push_back(_collidedObjectGroundDown);
		if (_collidedObjectGroundInside->_object != NULL)
			collidedGroundLst.push_back(_collidedObjectGroundInside);

		std::sort(collidedLst.begin(), collidedLst.end(), TimeCollideGreater());
		std::sort(collidedGroundLst.begin(), collidedGroundLst.end(), TimeCollideGreater());

		// Đảm bảo cập các đối tượng va cham khiến rockman bị thương trước khi xử lý va chạm nền
		for (int i = 0; i < collidedGroundLst.size(); i++)
			collidedLst.push_back(collidedGroundLst[i]);

		for (int i = 0; i < collidedLst.size(); i++)
		{
			if (collidedLst[i]->_direction == CDirection::INSIDE)
			{
				switch (collidedLst[i]->_object->_typeID)
				{
				case  ID_BLOCK_TROUBLE_OF_ELEVATOR:
				case ID_ELEVATOR_TROUBLE:
					break;
				case ID_STAIR:
					if (!_hasRockOnHead)
					{
						// Mặc định đối tượng được phép va chạm trong là cầu thang
						switch (_behave)
						{
						case STAIR_FIRE:
						case STAIR:
							if (collidedLst[i]->_object->GetBox()._y - _position.y <= 5.0f&&_position.y <= collidedLst[i]->_object->GetBox()._y)
							{
								_behave = Behave::STAIR_BEGIN_END;
								_v.x = 0.0f;
								_a.y = 0.0f;
								_v.y = 0.0f;
								_a.y = 0.0f;
							}
							isFalled = false;
							break;
						case STAIR_BEGIN_END:
							isFalled = false;
							break;
						case START:
							break;
						case STAND:
						case RUN:
						case JUMP:
						case FALL:
							if (CInput::GetInstance()->IsKeyPress(ID_KEY_CODE_UP))
							{
								_behave = Behave::STAIR;
								_a.x = 0.0f;
								_a.y = 0.0f;
								_v.x = 0.0f;
								_v.y = 0.0f;
								_position.x = collidedLst[i]->_object->_position.x;
								isFalled = false;
							}
							else if (_collidedObjectGroundDown->_object == NULL)
								isFalled = true;

							break;
						}
					}
					break;
				case  ID_ITEM_LIFE:
					_life += 1;
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BLOOD_BIG:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_BLOOD_SMALL:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_MANA_BIG:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_MANA_SMALL:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_SMALL);

					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BONUS:
					CGameInfo::GetInstance()->SetBonus(CGameInfo::GetInstance()->GetTotalBonus());
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case ID_ITEM_BOSS_CUT:
				case ID_ITEM_BOSS_BOOM:
				case ID_ITEM_BOSS_GUTS:
					((CItem*)collidedLst[i]->_object)->GotIt();
					_isRequireEndGame = true;
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					break;
				case ID_FALLING_POINT:
				case ID_DOOR2_CUTMAN:
				case ID_DOOR2_GUTSMAN:
				case ID_DOOR2_BOOMMAN:
				case ID_DOOR1_CUTMAN:
				case ID_DOOR1_GUTSMAN:
				case ID_DOOR1_BOOMMAN:
				case ID_ELEVATOR:
				case ID_ROCK_IN_GUT_STAGE:
				case  ID_ROCK:
				case  ID_BLOCK:
					break;
				case  ID_DIE_ARROW:
					_position += _v*collidedLst[i]->_timeCollide;
					Attack(0, true);
					if (_behave == Behave::DYING)
						return;
					break;
				default:
					if (_behave != Behave::HURT_IN_AIR&&_behave != Behave::HURT_ON_GROUND&& !_isInShield)
					{
						_position += _v*collidedLst[i]->_timeCollide;
						_isRight = false;
						_isInShield = false;
						_actionPosition = Vector2(_box._x + _box._width / 2, _box._y + 8);
						_isChangingState = true;

						switch (_behave)
						{
						case STAND_FIRE:
						case STAND:
						case PREPARE_RUN:
							_behave = Behave::HURT_ON_GROUND;
							_timeHurted = 0.0f;
							_deltaTime = 0;
							if (_position.x > collidedLst[i]->_object->_position.x)
								_isRight = false;
							else if (_position.x < collidedLst[i]->_object->_position.x)
								_isRight = true;

							_v.x = _isRight ? -ROCKMAN_VERLOCITY_X / 3 : ROCKMAN_VERLOCITY_X / 3;
							_a.x = _isRight ? -ROCKMAN_ACCELERATE_X / 3 : ROCKMAN_ACCELERATE_X / 3;

							if (_v.x<0.0f&&_collidedObjectGroundLeft->_object != NULL ||
								_v.x>0.0f&&_collidedObjectGroundRight->_object != NULL)
							{
								_v.x = 0.0f;
								_a.x = 0.0f;
							}
							break;
						case RUN:
						case RUN_FIRE:
							_deltaTime = 0;
							_behave = Behave::HURT_ON_GROUND;
							_timeHurted = 0.0f;
							if (_position.x > collidedLst[i]->_object->_position.x)
								_isRight = false;
							else if (_position.x < collidedLst[i]->_object->_position.x)
								_isRight = true;
							_v.x *= (-1);
							_a.x *= (-1);

							if (_v.x<0.0f&&_collidedObjectGroundLeft->_object != NULL ||
								_v.x>0.0f&&_collidedObjectGroundRight->_object != NULL)
							{
								_v.x = 0.0f;
								_a.x = 0.0f;
							}
							break;
						default:
							_behave = Behave::HURT_IN_AIR;
							_deltaTime = 0;
							_timeHurted = 0.0f;
							_a.y = -ROCKMAN_ACCELERATE_Y;
							if (_position.x > collidedLst[i]->_object->_position.x)
								_isRight = false;
							else if (_position.x < collidedLst[i]->_object->_position.x)
								_isRight = true;
							_v.x *= (-1);
							_a.x *= (-1);
							_v.y = 0.0f;
							if (_v.x<0.0f&&_collidedObjectGroundLeft->_object != NULL ||
								_v.x>0.0f&&_collidedObjectGroundRight->_object != NULL)
							{
								_v.x = 0.0f;
								_a.x = 0.0f;
							}
							break;
						}
						Attack(((CMoveableObject*)collidedLst[i]->_object)->GetDame());
						if (_behave == Behave::DYING)
							return;
					}
					break;
				}
			}
			if (collidedLst[i]->_direction == CDirection::ON_LEFT)
			{
				switch (collidedLst[i]->_object->_typeID)
				{

				case  ID_BLOCK_TROUBLE_OF_ELEVATOR:
				case ID_ELEVATOR_TROUBLE:
					break;
				case  ID_ITEM_LIFE:
					_life += 1;
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BLOOD_BIG:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_BLOOD_SMALL:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_MANA_BIG:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_MANA_SMALL:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BONUS:
					CGameInfo::GetInstance()->SetBonus(CGameInfo::GetInstance()->GetTotalBonus());
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case ID_ITEM_BOSS_CUT:
				case ID_ITEM_BOSS_BOOM:
				case ID_ITEM_BOSS_GUTS:
					((CItem*)collidedLst[i]->_object)->GotIt();
					_isRequireEndGame = true;
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					break;
				case ID_DOOR2_CUTMAN:
				case ID_DOOR2_GUTSMAN:
				case ID_DOOR2_BOOMMAN:
					_isInBossRoom = true;
				case ID_DOOR1_CUTMAN:
				case ID_DOOR1_GUTSMAN:
				case ID_DOOR1_BOOMMAN:
					if (((CDoor*)collidedLst[i]->_object)->CanGoLeft() && _v.x < 0.0f)
					{
						_isRequireOverDoor = true;
					}
					else
					{
						if (_v.x < 0)
						{
							_position.x = collidedLst[i]->_object->GetBox()._x + collidedLst[i]->_object->GetBox()._width + _box._width / 2;
							_v.x = 0.0f;
							_a.x = 0.0f;
						}
					}
					break;
				case ID_ELEVATOR:
				case ID_ROCK_IN_GUT_STAGE:
				case  ID_ROCK:
				case  ID_BLOCK:
					if (_v.x < 0.0f)
					{
						_position.x = collidedLst[i]->_object->GetBox()._x + collidedLst[i]->_object->GetBox()._width + _box._width / 2;
						_v.x = 0.0f;
						_a.x = 0.0f;
					}
					break;
				case ID_STAIR:
				case ID_FALLING_POINT:
					break;
				}
			}
			if (collidedLst[i]->_direction == CDirection::ON_RIGHT)
			{
				switch (collidedLst[i]->_object->_typeID)
				{
				case  ID_BLOCK_TROUBLE_OF_ELEVATOR:
				case ID_ELEVATOR_TROUBLE:
					break;
				case  ID_ITEM_LIFE:
					_life += 1;
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BLOOD_BIG:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_BLOOD_SMALL:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_MANA_BIG:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_MANA_SMALL:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BONUS:
					CGameInfo::GetInstance()->SetBonus(CGameInfo::GetInstance()->GetTotalBonus());
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case ID_ITEM_BOSS_CUT:
				case ID_ITEM_BOSS_BOOM:
				case ID_ITEM_BOSS_GUTS:
					((CItem*)collidedLst[i]->_object)->GotIt();
					_isRequireEndGame = true;
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					break;
				case ID_DOOR2_CUTMAN:
				case ID_DOOR2_GUTSMAN:
				case ID_DOOR2_BOOMMAN:
					_isInBossRoom = true;
				case ID_DOOR1_CUTMAN:
				case ID_DOOR1_GUTSMAN:
				case ID_DOOR1_BOOMMAN:
					if (((CDoor*)collidedLst[i]->_object)->CanGoRight() && _v.x > 0.0f)
					{

						_isRequireOverDoor = true;
					}
					else
					{
						if (_v.x > 0)
						{
							_position.x = collidedLst[i]->_object->GetBox()._x + collidedLst[i]->_object->GetBox()._width + _box._width / 2;
							_v.x = 0.0f;
							_a.x = 0.0f;
						}
					}
					break;
				case ID_ELEVATOR:
				case ID_ROCK_IN_GUT_STAGE:
				case  ID_ROCK:
				case  ID_BLOCK:
					if (_v.x > 0.0f)
					{
						_position.x = collidedLst[i]->_object->GetBox()._x - _box._width / 2;
						_v.x = 0.0f;
						_a.x = 0.0f;
					}
					break;
				case ID_STAIR:
				case ID_FALLING_POINT:
					break;
				}
			}
			if (collidedLst[i]->_direction == CDirection::ON_UP)
			{
				switch (collidedLst[i]->_object->_typeID)
				{

				case  ID_BLOCK_TROUBLE_OF_ELEVATOR:
				case ID_ELEVATOR_TROUBLE:
					break;
				case  ID_ITEM_LIFE:
					_life += 1;
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BLOOD_SMALL:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_BLOOD_BIG:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_MANA_BIG:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_MANA_SMALL:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BONUS:
					CGameInfo::GetInstance()->SetBonus(CGameInfo::GetInstance()->GetTotalBonus());
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case ID_ITEM_BOSS_CUT:
				case ID_ITEM_BOSS_BOOM:
				case ID_ITEM_BOSS_GUTS:
					((CItem*)collidedLst[i]->_object)->GotIt();
					_isRequireEndGame = true;
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					break;
				case ID_DOOR2_CUTMAN:
				case ID_DOOR2_GUTSMAN:
				case ID_DOOR2_BOOMMAN:
					_isInBossRoom = true;
				case ID_DOOR1_CUTMAN:
				case ID_DOOR1_GUTSMAN:
				case ID_DOOR1_BOOMMAN:
					if (((CDoor*)collidedLst[i]->_object)->CanGoDown() && _v.y < 0.0f)
						_isRequireOverDoor = true;
					break;
				case ID_STAIR:
					if (_input->IsKeyPress(ID_KEY_CODE_UP))
					{
						_behave = Behave::STAIR;
						_a.x = 0.0f;
						_a.y = 0.0f;
						_v.x = 0.0f;
						_v.y = 50.0f / 1000.0f;
						_position.x = collidedLst[i]->_object->_position.x;
						_position.y += collidedLst[i]->_timeCollide*_v.y + 5;
					}
					break;
				case ID_ELEVATOR:
				case ID_ROCK_IN_GUT_STAGE:
				case  ID_ROCK:
				case  ID_BLOCK:
					if (_v.y >= 0.0f&&_behave != Behave::STAIR&&_behave != Behave::STAIR_FIRE&&_behave != Behave::STAIR_BEGIN_END)
					{
						_position.y += collidedLst[i]->_timeCollide*_v.y;
						_v.y = 0.0f;
						_a.y = -ROCKMAN_VERLOCITY_Y;
						_behave = Behave::FALL;
					}
					break;
				case ID_FALLING_POINT:
					break;
				}
			}
			if (collidedLst[i]->_direction == CDirection::ON_DOWN)
			{
				switch (collidedLst[i]->_object->_typeID)
				{
				case  ID_BLOCK_TROUBLE_OF_ELEVATOR:
				case ID_ELEVATOR_TROUBLE:
					break;
				case  ID_ITEM_LIFE:
					_life += 1;
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BLOOD_BIG:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_BLOOD_SMALL:
					_blood = __min(BLOOD_DEFAULT, _blood + VALUE_ITEM_BLOOD_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					ResourceManager::PlayASound(ID_EFFECT_GET_BLOOD);
					break;
				case  ID_ITEM_MANA_BIG:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_BIG);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_MANA_SMALL:
					if (_currentSkill != Skill::NORMAL)
						SetWeapons(_currentSkill, GetWeapons(_currentSkill) + VALUE_ITEM_MANA_SMALL);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case  ID_ITEM_BONUS:
					CGameInfo::GetInstance()->SetBonus(CGameInfo::GetInstance()->GetTotalBonus());
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					((CItem*)collidedLst[i]->_object)->GotIt();
					break;
				case ID_ITEM_BOSS_CUT:
				case ID_ITEM_BOSS_BOOM:
				case ID_ITEM_BOSS_GUTS:
					((CItem*)collidedLst[i]->_object)->GotIt();
					_isRequireEndGame = true;
					ResourceManager::PlayASound(ID_EFFECT_GET_ITEM);
					break;
				case  ID_FALLING_POINT:
					switch (_behave)
					{
					case START:
						if (!_isChangingState)
						{
							if (_v.y < 0)
							{
								_position.y += collidedLst[i]->_timeCollide*_v.y;
								_v.x = 0.0f;
								_v.y = 0.0f;
								_a.y = 0.0f;
								_a.y = 0.0f;
								_isChangingState = true;
								isFalled = false;
							}
						}
						break;
					}
					break;
				case ID_DOOR2_CUTMAN:
				case ID_DOOR2_GUTSMAN:
				case ID_DOOR2_BOOMMAN:
					_isInBossRoom = true;
				case ID_DOOR1_CUTMAN:
				case ID_DOOR1_GUTSMAN:
				case ID_DOOR1_BOOMMAN:
					if (((CDoor*)collidedLst[i]->_object)->CanGoDown() && _v.y < 0.0f)
					{
						_isRequireOverDoor = true;
					}
					break;
				case ID_ELEVATOR:
				case ID_STAIR:
					if (_input->IsKeyPress(ID_KEY_CODE_DOWN) && !_hasRockOnHead)
					{
						_behave = Behave::STAIR_BEGIN_END;
						_position.x = collidedLst[i]->_object->_position.x;
						_position.y -= _box._height - 3;
						_v.x = 0.0f;
						_v.y = 0.0f;
						_a.y = 0.0f;
						_a.x = 0.0f;
					}
				case  ID_ROCK:
				case ID_ROCK_IN_GUT_STAGE:
				case  ID_BLOCK:
					switch (_behave)
					{
					case HURT_IN_AIR:
						_isInShield = true;
						_timeHurted = 0;
						_deltaTimeInShield = 0;
					case STAIR:
					case STAIR_FIRE:
					case FALL_FIRE:
					case FALL:
						if (_v.y < 0)
						{
							_position.y = collidedLst[i]->_object->GetBox()._y + _box._height / 2;
							_v.y = 0.0f;
							_a.y = 0.0f;
							_jumpTime = 0.0f;
							_isChangingState = true;
							_canJump = true;
							if (_behave == Behave::FALL || _behave == Behave::FALL_FIRE)
								ResourceManager::PlayASound(ID_SOUND_LAND);
							if (!_isRequireOverDoor)
							{
								if (_behave != Behave::START)
									ResourceManager::PlayASound(ID_EFFECT_LAND);
								_behave = Behave::STAND;
							}
							else
								_behave = Behave::RUN;

							if (Asset::GetInstance()->__is_require_shake_screen)
							{
								_behave = Behave::HURT_ON_GROUND;
								_timeHurted = 0.0f;
								_deltaTime = 0;
								if (_position.x > collidedLst[i]->_object->_position.x)
									_isRight = false;
								else if (_position.x < collidedLst[i]->_object->_position.x)
									_isRight = true;

								_v.x = _isRight ? -ROCKMAN_VERLOCITY_X / 3 : ROCKMAN_VERLOCITY_X / 3;
								_a.x = _isRight ? -ROCKMAN_ACCELERATE_X / 3 : ROCKMAN_ACCELERATE_X / 3;

								if (_v.x<0.0f&&_collidedObjectGroundLeft->_object != NULL ||
									_v.x>0.0f&&_collidedObjectGroundRight->_object != NULL)
								{
									_v.x = 0.0f;
									_a.x = 0.0f;
								}
							}
						}
						break;
					}
					isFalled = false;
					break;
				}
			}
		}

		if (isFalled)
		{
			if (_behave != Behave::START &&_behave != Behave::JUMP&&_behave != Behave::JUMP_FIRE&&_behave != Behave::HURT_IN_AIR&&_behave != Behave::HURT_ON_GROUND&&_v.y >= 0.0f)
			{
				if (!_isRequireOverDoor)
				{
					if (_behave == Behave::HURT_IN_AIR)
					{
						_isInShield = true;
						_timeHurted = 0;
						_deltaTimeInShield = 0;
					}
					_v.y = 0.0f;
					_a.y = -ROCKMAN_ACCELERATE_Y;
					if (_changeScreenDirection == CDirection::ON_DOWN)
					{
						_v.y = 0.0f;
						_a.y = 0.0F;
					}
					_behave = Behave::FALL;
				}
				else
				{
					_v.y = 0.0f;
					_a.y = -ROCKMAN_ACCELERATE_Y / 5;
					if (_changeScreenDirection == CDirection::ON_DOWN)
					{
						_v.y = 0.0f;
						_a.y = 0.0F;
					}
					_behave = Behave::FALL;
				}
			}
		}

#pragma endregion

#pragma region Hoàn tất hành vi của trạng thái cũ hoặc trạng thái chuyển tiếp trong khi va chạm. Nhận dữ liệu bàn phím và điều hướng trạng thái tiếp theo

		_input = CInput::GetInstance();

		_position += _v*gameTime->GetDeltaTime();
		_v += _a*gameTime->GetDeltaTime();

		// Việc ràng ở đây chỉ áp dụng cho loại đạn thường. Còn cái đạn kỹ năng khác bị ảnh hưởng bởi luồng xử lý khác
		if (!_canFire&&_currentSkill == Skill::NORMAL)
		{
			_deltaTimeCanFire += gameTime->GetDeltaTime();
			if (_deltaTimeCanFire >= 300)
			{
				_deltaTimeCanFire = 0;
				_canFire = true;
			}
		}
		if (_isInShield)
		{
			_deltaTimeInShield += gameTime->GetDeltaTime();
			if (_deltaTimeInShield >= 2000)
			{
				_deltaTimeInShield = 0;
				_isInShield = false;
			}
		}
		if (_isRequireOverDoor&&_timeOverDoor != 0)
		{
			_timeOverDoor += gameTime->GetDeltaTime();
			if (_timeOverDoor >= 2500)
			{
				_isRequireOverDoor = false;
				_isGoingOverDoor = false;
				_isOverDoor = true;
				_timeOverDoor = 0;
				CInput::GetInstance()->Deactive();
				_behave = Behave::STAND;
				_v.x = _v.y = _a.x = _a.y = 0.0f;
			}
		}
		switch (_behave)
		{
		case START:
			if (_isChangingState)
			{
				_deltaTime += gameTime->GetDeltaTime();
				if (_deltaTime >= 75)
				{
					_deltaTime = 0;
					_sprite.NextSprite();
					if (_sprite.GetIndex() == 0)
					{
						_behave = Behave::STAND;
						ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_APPEAR);
						_a.x = _a.y = _v.x = _v.y = 0.0f;

						if (_isTheFirstTime)
							_isTheFirstTime = false;
					}
				}
			}
			break;
		case STAND_FIRE:
			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 300)
			{
				_behave = Behave::STAND;
				_deltaTime = 0;
			}
		case STAND:
			if (_v.x > 0.0)
			{
				_a.x -= ROCKMAN_ACCELERATE_X / 3.0f;
				_v.x -= ROCKMAN_VERLOCITY_X / 3.0f;
				if (_v.x < 0.0f)
				{
					_a.x = 0.0f;
					_v.x = 0.0f;
				}
			}
			else if (_v.x<0.0f)
			{
				_a.x += ROCKMAN_ACCELERATE_X / 3.0f;
				_v.x += ROCKMAN_VERLOCITY_X / 3.0f;

				if (_v.x > 0.0f)
				{
					_a.x = 0.0f;
					_v.x = 0.0f;
				}
			}
			if (_input->IsKeyPress(ID_KEY_CODE_LEFT) && _input->IsKeyPress(ID_KEY_CODE_RIGHT))
			{
				_v.x = 0.0f;
				_a.x = 0.0f;
			}
			else if (_input->IsKeyPress(ID_KEY_CODE_LEFT))
			{
				_isRight = false;
				_behave = Behave::PREPARE_RUN;
				_deltaTime = 0;
			}
			else if (_input->IsKeyPress(ID_KEY_CODE_RIGHT))
			{
				_isRight = true;
				_behave = Behave::PREPARE_RUN;
				_deltaTime = 0;
			}

			if (_isChangingState)
			{
				_jumpTime += gameTime->GetDeltaTime();
				if (_jumpTime >= 100.0f)
				{
					_jumpTime = 0.0f;
					_canJump = true;
					_isChangingState = false;
				}
			}
			if (_input->IsKeyDown(ID_KEY_CODE_JUMP) && _canJump)
			{
				_v.y = 2.0f* ROCKMAN_VERLOCITY_Y / 3.0f;
				_deltaTimeJump = 0.0f;
				_a.y = -ROCKMAN_ACCELERATE_Y;
				_behave = Behave::JUMP;
				_canJump = false;
				_canJumpMore = true;
			}
			if (_input->IsKeyDown(ID_KEY_CODE_FIRE) && (_canFire || _hasRockOnHead) && GetWeapons(_currentSkill) > 0)
			{
				if (_currentSkill != Skill::GUTS&& _canFire)
				{
					_behave = Behave::STAND_FIRE;
					_deltaTime = 0;
					_canFire = false;

					Fire();
				}
				else
				{
					if (!_hasRockOnHead)
					{
						if (_isRight&&_collidedObjectGroundRight->_object != NULL && (_collidedObjectGroundRight->_object->_typeID == ID_ROCK || _collidedObjectGroundRight->_object->_typeID == ID_ROCK_IN_GUT_STAGE))
						{
							((CRock*)_collidedObjectGroundRight->_object)->GotIt();
							_canFire = false;
							_hasRockOnHead = true;
							_isThrowRock = false;
							_deltaTime = 0;
							SetWeapons(_currentSkill, GetWeapons(_currentSkill) - 2);
							_bullets.push_back(new CGutsRockmanBullet(this, _collidedObjectGroundRight->_object->_typeID));
						}
						else if (!_isRight&& _collidedObjectGroundLeft->_object != NULL && (_collidedObjectGroundLeft->_object->_typeID == ID_ROCK || _collidedObjectGroundLeft->_object->_typeID == ID_ROCK_IN_GUT_STAGE))
						{
							((CRock*)_collidedObjectGroundLeft->_object)->GotIt();
							_canFire = false;
							_hasRockOnHead = true;
							_isThrowRock = false;
							_deltaTime = 0;
							SetWeapons(_currentSkill, GetWeapons(_currentSkill) - 2);
							_bullets.push_back(new CGutsRockmanBullet(this, _collidedObjectGroundLeft->_object->_typeID));
						}
						else if (_collidedObjectGroundUp->_object != NULL && (_collidedObjectGroundUp->_object->_typeID == ID_ROCK || _collidedObjectGroundUp->_object->_typeID == ID_ROCK_IN_GUT_STAGE))
						{
							((CRock*)_collidedObjectGroundLeft->_object)->GotIt();
							_canFire = false;
							_hasRockOnHead = true;
							_isThrowRock = false;
							_deltaTime = 0;
							SetWeapons(_currentSkill, GetWeapons(_currentSkill) - 2);
							_bullets.push_back(new CGutsRockmanBullet(this, _collidedObjectGroundUp->_object->_typeID));
						}
					}
					else
					{
						_behave = Behave::STAND_FIRE;
						_deltaTime = 0;
						_hasRockOnHead = false;
						_isThrowRock = true;
						ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_GUTS);
					}
				}
			}
			break;
		case STAIR_FIRE:
			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 300)
			{
				_behave = Behave::STAIR;
				_deltaTime = 0;
			}
		case STAIR:
			if (_input->IsKeyPress(ID_KEY_CODE_UP) && _v.y <= 0.0f)

			{
				_v.x = 0.0f;
				_v.y = 50.0f / 1000.0f;
				_a.x = 0.0f;
				_a.y = 0.0f;
				_sprite.SetAllowAnimate(120);
			}
			else	if (_input->IsKeyUp(ID_KEY_CODE_UP) && _v.y > 0.0f)
			{
				_v.y = 0.0f;
				_a.y = 0.0f;
				_a.x = 0.0f;
				_v.x = 0.0f;
				_sprite.SetAllowAnimate(0);
			}
			else	if (_input->IsKeyPress(ID_KEY_CODE_DOWN) && _v.y >= 0.0f)
			{
				_v.y = -50.0f / 1000.0f;
				_a.y = 0.0f;
				_a.x = 0.0f;
				_v.x = 0.0f;
				_sprite.SetAllowAnimate(120);
			}
			else if (_input->IsKeyUp(ID_KEY_CODE_DOWN) && _v.y < 0.0f)
			{
				_v.y = 0.0f;
				_a.y = 0.0f;
				_a.x = 0.0f;
				_v.x = 0.0f;
				_sprite.SetAllowAnimate(0);
			}
			if (_input->IsKeyDown(ID_KEY_CODE_LEFT))
			{
				_isRight = false;
			}
			else if (_input->IsKeyDown(ID_KEY_CODE_RIGHT))
			{
				_isRight = true;
			}
			if (_input->IsKeyDown(ID_KEY_CODE_JUMP) || isFalled)
			{
				_behave = Behave::FALL;
				_v.x = 0.0f;
				_v.y = 0.0f;
				_a.y = -ROCKMAN_VERLOCITY_Y;
				_a.x = 0.0f;
				_sprite.SetAllowAnimate(0);
			}
			if (_input->IsKeyDown(ID_KEY_CODE_FIRE) && _canFire&&GetWeapons(_currentSkill) > 0 && _currentSkill != Skill::GUTS)
			{
				_behave = Behave::STAIR_FIRE;
				_deltaTime = 0;
				_canFire = false;
				Fire();
			}
			break;
		case STAIR_BEGIN_END:
			if (_input->IsKeyPress(ID_KEY_CODE_DOWN))
			{
				_behave = Behave::STAIR;
				if (_collidedObjectGroundInside->_object != NULL)
					_position.y -= _collidedObjectGroundInside->_object->GetBox()._y - _position.y + _box._height / 2 + 1;
			}
			else if (_input->IsKeyPress(ID_KEY_CODE_UP))
			{
				_behave = Behave::STAND;
				_canJump = true;
				_position.y = _collidedObjectGroundInside->_object->GetBox()._y + 12;
			}
			break;
		case HURT_IN_AIR:
		case HURT_ON_GROUND:
			if (_isChangingState)
				_isChangingState = false;

			_timeHurted += gameTime->GetDeltaTime();
			if (_timeHurted >= 300)
			{
				if (_behave == Behave::HURT_ON_GROUND)
					_behave = Behave::STAND;

				_timeHurted = 0.0f;
				_isInShield = true;
				_deltaTimeInShield = 0.0f;
			}
			break;
		case PREPARE_RUN:
			_deltaTime += gameTime->GetDeltaTime();
			if (_input->IsKeyPress(ID_KEY_CODE_LEFT))
			{
				_a.x += -ROCKMAN_ACCELERATE_X / 3.0f;
				_v.x += -ROCKMAN_VERLOCITY_X / 3.0f;

				if (_v.x <= -ROCKMAN_VERLOCITY_X)
				{
					_isRight = false;
					_behave = Behave::RUN;
					_deltaTime = 0;
				}
				else if (_deltaTime >= 600)
				{
					_isRight = false;
					_behave = Behave::RUN;
					_v.x = -ROCKMAN_VERLOCITY_X;
					_v.x = -ROCKMAN_ACCELERATE_X;
					_deltaTime = 0;
				}
			}
			else if (_input->IsKeyPress(ID_KEY_CODE_RIGHT))
			{
				_a.x += ROCKMAN_ACCELERATE_X / 3.0f;
				_v.x += ROCKMAN_VERLOCITY_X / 3.0f;

				if (_v.x >= ROCKMAN_VERLOCITY_X)
				{
					_isRight = true;
					_behave = Behave::RUN;
				}
				else if (_deltaTime >= 600)
				{
					_isRight = true;
					_behave = Behave::RUN;
					_v.x = ROCKMAN_VERLOCITY_X;
					_v.x = ROCKMAN_ACCELERATE_X;
					_deltaTime = 0;
				}
			}
			if (_input->IsKeyUp(ID_KEY_CODE_LEFT) || _input->IsKeyUp(ID_KEY_CODE_RIGHT))
			{
				_behave = Behave::STAND;
				_v.x = 0.0f;
				_a.x = _isRight ? ROCKMAN_ACCELERATE_X : -ROCKMAN_ACCELERATE_X;
			}
			if (_input->IsKeyDown(ID_KEY_CODE_JUMP))
			{
				_v.y = 2.0f* ROCKMAN_VERLOCITY_Y / 3.0f;
				_deltaTimeJump = 0.0f;
				_a.y = -ROCKMAN_ACCELERATE_Y;
				_behave = Behave::JUMP;
				_canJump = false;
				_canJumpMore = true;
			}
			break;
		case RUN_FIRE:
			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 300)
			{
				_behave = Behave::RUN;
				_deltaTime = 0;
			}

		case RUN:
			if (!_isRequireOverDoor)
			{
				if (_input->IsKeyPress(ID_KEY_CODE_RIGHT) && _input->IsKeyPress(ID_KEY_CODE_LEFT)
					|| _input->IsKeyRelease(ID_KEY_CODE_LEFT) && _input->IsKeyRelease(ID_KEY_CODE_RIGHT))
				{
					_behave = Behave::STAND;
				}
				else
				{
					if (_input->IsKeyPress(ID_KEY_CODE_RIGHT) && _v.x <= 0)
					{
						_a.x = ROCKMAN_ACCELERATE_X;
						_v.x = ROCKMAN_VERLOCITY_X;
						_isRight = true;
					}
					else if (_input->IsKeyPress(ID_KEY_CODE_LEFT) && _v.x >= 0)
					{
						_a.x = -ROCKMAN_ACCELERATE_X;
						_v.x = -ROCKMAN_VERLOCITY_X;
						_isRight = false;
					}
				}

				if (_isChangingState)
				{
					_jumpTime += gameTime->GetDeltaTime();
					if (_jumpTime >= 100.0f)
					{
						_jumpTime = 0.0f;
						_canJump = true;
						_isChangingState = false;
					}
				}

				if (_input->IsKeyDown(ID_KEY_CODE_JUMP) && _canJump)
				{
					_v.y = 2.0f* ROCKMAN_VERLOCITY_Y / 3.0f;
					_deltaTimeJump = 0.0f;
					_a.y = -ROCKMAN_ACCELERATE_Y;
					_behave = Behave::JUMP;
					_canJump = false;
					_canJumpMore = true;
				}

				if (_input->IsKeyDown(ID_KEY_CODE_FIRE) && (_canFire || _hasRockOnHead) && GetWeapons(_currentSkill) > 0)
				{
					if (_currentSkill != Skill::GUTS&& _canFire)
					{
						_behave = Behave::RUN_FIRE;
						_deltaTime = 0;
						_canFire = false;
						Fire();
					}
					else
					{
						if (!_hasRockOnHead)
						{
							if (_isRight&&_collidedObjectGroundRight->_object != NULL && (_collidedObjectGroundRight->_object->_typeID == ID_ROCK || _collidedObjectGroundRight->_object->_typeID == ID_ROCK_IN_GUT_STAGE))
							{
								((CRock*)_collidedObjectGroundRight->_object)->GotIt();
								_canFire = false;
								_hasRockOnHead = true;
								_isThrowRock = false;
								_deltaTime = 0;
								SetWeapons(_currentSkill, GetWeapons(_currentSkill) - 2);
								_bullets.push_back(new CGutsRockmanBullet(this, _collidedObjectGroundRight->_object->_typeID));
							}
							else if (!_isRight&& _collidedObjectGroundLeft->_object != NULL && (_collidedObjectGroundLeft->_object->_typeID == ID_ROCK || _collidedObjectGroundLeft->_object->_typeID == ID_ROCK_IN_GUT_STAGE))
							{
								((CRock*)_collidedObjectGroundLeft->_object)->GotIt();
								_canFire = false;
								_hasRockOnHead = true;
								_isThrowRock = false;
								_deltaTime = 0;
								SetWeapons(_currentSkill, GetWeapons(_currentSkill) - 2);
								_bullets.push_back(new CGutsRockmanBullet(this, _collidedObjectGroundLeft->_object->_typeID));
							}
							else if (_collidedObjectGroundUp->_object != NULL && (_collidedObjectGroundUp->_object->_typeID == ID_ROCK || _collidedObjectGroundUp->_object->_typeID == ID_ROCK_IN_GUT_STAGE))
							{
								((CRock*)_collidedObjectGroundLeft->_object)->GotIt();
								_canFire = false;
								_hasRockOnHead = true;
								_isThrowRock = false;
								_deltaTime = 0;
								SetWeapons(_currentSkill, GetWeapons(_currentSkill) - 2);
								_bullets.push_back(new CGutsRockmanBullet(this, _collidedObjectGroundUp->_object->_typeID));
							}
						}
						else
						{
							_behave = Behave::RUN_FIRE;
							_deltaTime = 0;
							_hasRockOnHead = false;
							_isThrowRock = true;
							ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_GUTS);
						}
					}
				}
			}
			break;
		case JUMP_FIRE:
			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 300)
			{
				_behave = Behave::JUMP;
				_deltaTime = 0;
			}
		case JUMP:
			if (_input->IsKeyPress(ID_KEY_CODE_RIGHT) && _input->IsKeyPress(ID_KEY_CODE_LEFT))
			{
				_v.x = 0.0f;
				_a.x = 0.0f;
			}
			else
			{
				if (_input->IsKeyPress(ID_KEY_CODE_LEFT) && _v.x >= 0)
				{
					_v.x = -ROCKMAN_VERLOCITY_X;
					_a.x = -ROCKMAN_ACCELERATE_X;
					_isRight = false;
				}
				else if (_input->IsKeyPress(ID_KEY_CODE_RIGHT) && _v.x <= 0)
				{
					_v.x = ROCKMAN_VERLOCITY_X;
					_a.x = ROCKMAN_ACCELERATE_X;
					_isRight = true;
				}
			}

			if (_input->IsKeyPress(ID_KEY_CODE_JUMP) && _canJumpMore)
			{
				_deltaTimeJump += gameTime->GetDeltaTime();
				if (_deltaTimeJump >= 50)
				{
					_v.y += ROCKMAN_VERLOCITY_Y / 3.0f;
					_canJumpMore = false;
					_deltaTimeJump = 0.0f;
				}
			}

			if (_input->IsKeyDown(ID_KEY_CODE_FIRE) && (_canFire || _hasRockOnHead) && GetWeapons(_currentSkill) > 0)
			{
				if (_currentSkill != Skill::GUTS&& _canFire)
				{
					_behave = Behave::JUMP_FIRE;
					_deltaTime = 0;
					_canFire = false;
					Fire();
				}
				else if (_hasRockOnHead)
				{
					_behave = Behave::JUMP_FIRE;
					_deltaTime = 0;
					_hasRockOnHead = false;
					_isThrowRock = true;
					ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_GUTS);
				}
			}
			if (_v.y < 0)
			{
				_behave = Behave::FALL;
			}
			break;
		case FALL_FIRE:
			_deltaTime += gameTime->GetDeltaTime();
			if (_deltaTime >= 300)
			{
				_behave = Behave::JUMP_FIRE;
				_deltaTime = 0;
			}
		case FALL:
			if (!_isRequireOverDoor)
			{
				if (_input->IsKeyPress(ID_KEY_CODE_RIGHT) && _input->IsKeyPress(ID_KEY_CODE_LEFT))
				{
					_a.x = 0.0f;
					_v.x = 0.0f;
				}
				else
				{
					if (_input->IsKeyDown(ID_KEY_CODE_LEFT) && _v.x >= 0.0f)
					{
						_a.x = -ROCKMAN_ACCELERATE_X;
						_v.x = -ROCKMAN_VERLOCITY_X;
						_isRight = false;
					}
					else if (_input->IsKeyDown(ID_KEY_CODE_RIGHT) && _v.x <= 0.0f)
					{
						_a.x = ROCKMAN_ACCELERATE_X;
						_v.x = ROCKMAN_VERLOCITY_X;
						_isRight = true;
					}
				}
				if (_input->IsKeyDown(ID_KEY_CODE_FIRE) && (_canFire || _hasRockOnHead) && GetWeapons(_currentSkill) > 0)
				{
					if (_currentSkill != Skill::GUTS&& _canFire)
					{
						_behave = Behave::FALL_FIRE;
						_deltaTime = 0;
						_canFire = false;
						Fire();
					}
					else if (_hasRockOnHead)
					{
						_behave = Behave::FALL_FIRE;
						_deltaTime = 0;
						_hasRockOnHead = false;
						_isThrowRock = true;
					}
				}
			}
			break;
		}
#pragma endregion
	}
	else
	{
		_deltaTime += gameTime->GetDeltaTime();

		if (_deltaTime >= 5000.0f)
			_behave = Behave::REAL_DIE;
	}
#pragma region Cập nhật box của trạng thái mới

	UpdateAnimation();
	UpdateBox();
	_sprite.Update(gameTime);


	// Xác định các đối tượng có va chạm
	_collidedObjectInside = new  CollisionInfo(NULL, CDirection::INSIDE, std::numeric_limits<float>::infinity());

	_collidedObjectGroundLeft = new  CollisionInfo(NULL, CDirection::ON_LEFT, std::numeric_limits<float>::infinity());
	_collidedObjectGroundRight = new  CollisionInfo(NULL, CDirection::ON_RIGHT, std::numeric_limits<float>::infinity());
	_collidedObjectGroundUp = new  CollisionInfo(NULL, CDirection::ON_UP, std::numeric_limits<float>::infinity());
	_collidedObjectGroundDown = new  CollisionInfo(NULL, CDirection::ON_DOWN, std::numeric_limits<float>::infinity());
	_collidedObjectGroundInside = new  CollisionInfo(NULL, CDirection::INSIDE, std::numeric_limits<float>::infinity());
#pragma endregion
}

void CRockman::OnCollideWith(CGameObject* obj, CDirection normalX, CDirection normalY, float collideTime)
{
	if (!_isTheFirstTime)
	{
		switch (obj->_typeID)
		{
		case ID_DOOR1_BOOMMAN:
		case ID_DOOR1_CUTMAN:
		case ID_DOOR1_GUTSMAN:
		case ID_DOOR2_BOOMMAN:
		case ID_DOOR2_CUTMAN:
		case ID_DOOR2_GUTSMAN:
		case ID_STAIR:
		case ID_BLOCK:
		case ID_ROCK_IN_GUT_STAGE:
		case ID_ROCK:
		case ID_ELEVATOR:
			if (normalX == CDirection::ON_LEFT&& collideTime < _collidedObjectGroundLeft->_timeCollide&&obj->_typeID != ID_STAIR)
			{
				_collidedObjectGroundLeft->_timeCollide = collideTime;
				_collidedObjectGroundLeft->_object = obj;
			}
			else if (normalX == CDirection::ON_RIGHT&& collideTime < _collidedObjectGroundRight->_timeCollide&&obj->_typeID != ID_STAIR)
			{
				_collidedObjectGroundRight->_timeCollide = collideTime;
				_collidedObjectGroundRight->_object = obj;
			}
			if (normalY == CDirection::ON_UP)
			{
				if (obj->_typeID != ID_STAIR && collideTime < _collidedObjectGroundUp->_timeCollide)
				{
					_collidedObjectGroundUp->_timeCollide = collideTime;
					_collidedObjectGroundUp->_object = obj;
				}

				if (obj->_typeID == ID_STAIR &&collideTime <= _collidedObjectGroundUp->_timeCollide && _position.x>=obj->GetBox()._x&& _position.x<=obj->GetBox()._x+obj->GetBox()._width)
				{
					_collidedObjectGroundUp->_timeCollide = collideTime;
					_collidedObjectGroundUp->_object = obj;
				}
			}
			else if (normalY == CDirection::ON_DOWN)
			{
				if (obj->_typeID != ID_STAIR && collideTime < _collidedObjectGroundDown->_timeCollide)
				{
					_collidedObjectGroundDown->_timeCollide = collideTime;
					_collidedObjectGroundDown->_object = obj;
				}
				if (obj->_typeID == ID_STAIR &&collideTime <= _collidedObjectGroundDown->_timeCollide && _position.x >= obj->GetBox()._x&& _position.x <= obj->GetBox()._x + obj->GetBox()._width)
				{
					_collidedObjectGroundDown->_timeCollide = collideTime;
					_collidedObjectGroundDown->_object = obj;
				} 
			}
			else if (normalX == CDirection::INSIDE&& normalY == CDirection::INSIDE&& obj->_typeID == ID_STAIR)
			{
				if (!(_box._x > obj->GetBox()._x + obj->GetBox()._width - 3 || _box._x + _box._width < obj->GetBox()._x + 3))
				{
					_collidedObjectGroundInside->_timeCollide = collideTime;
					_collidedObjectGroundInside->_object = obj;
				}
			}
			break;
		default:
			if (normalX == CDirection::INSIDE &&normalY == CDirection::INSIDE)
			{
				_collidedObjectInside->_timeCollide = collideTime;
				_collidedObjectInside->_object = obj;
			}
			break;
		}
	}
	else
	{
		if (normalY == CDirection::ON_DOWN&&obj->_typeID == ID_FALLING_POINT)
		{
			_collidedObjectGroundDown->_timeCollide = collideTime;
			_collidedObjectGroundDown->_object = obj;
		}
	}
}

void CRockman::UpdateBox()
{
	_box._width = 16.0f;
	_box._height = 24.0f;
	_box._x = _position.x - _box._width / 2.0f;
	_box._y = _position.y + _box._height / 2.0f;
	_box._vx = _v.x;
	_box._vy = _v.y;
}

void CRockman::Attack(int dame, bool isRealKill)
{
//	_blood -= dame;

	if (isRealKill || _blood <= 0)
	{
		if (_behave != Behave::DYING&& _behave != Behave::REAL_DIE)
		{
			_life -= 1;
			_blood = 0;
			_behave = Behave::DYING;
			_deltaTime = 0;
			_v.x = ROCKMAN_VERLOCITY_X;
			_isRequireStopScreen = true;
			switch (_currentSkill)
			{
			case NORMAL:
				CExplodingEffectManager::Add(new CExplodingEffectX(_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_ROCKMAN)));
				break;
			case CUT:
				CExplodingEffectManager::Add(new CExplodingEffectX(_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_CUTMAN)));
				break;
			case GUTS:
				CExplodingEffectManager::Add(new CExplodingEffectX(_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_GUTSMAN)));
				break;
			case BOOM:
				CExplodingEffectManager::Add(new CExplodingEffectX(_position, ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BOOMMAN)));
				break;
			}
			switch (CGameInfo::GetInstance()->GetLevel())
			{
			case ID_LEVEL_CUT:
				ResourceManager::StopSound(ID_SOUND_CUTMAN_STAGE);
				break;
			case ID_LEVEL_GUTS:
				ResourceManager::StopSound(ID_SOUND_GUTSMAN_STAGE);
				break;
			case ID_LEVEL_BOOM:
				ResourceManager::StopSound(ID_SOUND_BOMBMAN_STAGE);
				break;
			}
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_DIE);
		}
	}
	else
	{
		ResourceManager::PlayASound(ID_SOUND_HURT);

		_confuses.push_back(ResourceManager::GetSprite(ID_SPRITE_ROCKMAN_CONFUSE));
		_confuses.push_back(ResourceManager::GetSprite(ID_SPRITE_ROCKMAN_CONFUSE));
		_confuses.push_back(ResourceManager::GetSprite(ID_SPRITE_ROCKMAN_CONFUSE));
	}
}

void CRockman::ChangeScreen(CDirection direction)
{
	switch (direction)
	{
	case ON_UP:
		_changeScreenDirection = direction;
	case ON_DOWN:
		_v.x *= 0.01f;
		_v.y *= 0.01f;
		_a.x *= 0.01f;
		_a.y *= 0.01f;
		_changeScreenDirection = direction;
		break;
	default:
		if (_behave == Behave::FALL)
		{
			_v.y = -ROCKMAN_VERLOCITY_Y;
			_a.y = -ROCKMAN_ACCELERATE_Y;
		}
		else if (_behave == Behave::HURT_IN_AIR)
		{
			_behave == Behave::FALL;
			_isInShield = true;
			_timeHurted = 0.0f;
			_deltaTimeInShield = 0.0f;
			_a.y = -ROCKMAN_ACCELERATE_Y;
		}
		else
		{
			_v.x = _v.y = _a.x = _a.y = 0.0f;
		}
		_changeScreenDirection = direction;
		break;
	}
}

bool CRockman::IsDied()
{
	if (_behave == Behave::REAL_DIE)
		return true;
	else return false;
}

bool CRockman::IsInBossRoom()
{
	return _isInBossRoom&&_isOverDoor;
}

void CRockman::Fire()
{
	if (_currentSkill != Skill::NORMAL)
		SetWeapons(_currentSkill, GetWeapons(_currentSkill) - 1);
	switch (_behave)
	{
	case STAND_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			if (_isRight)
				_bullets.push_back(new CBulletRockman(Vector2(2 * ROCKMAN_VERLOCITY_X, 0), _position + Vector2(12, 0)));
			else
				_bullets.push_back(new CBulletRockman(Vector2(-2 * ROCKMAN_VERLOCITY_X, 0), _position - Vector2(12, 0)));
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_NORMAL);
			break;
		case CUT:
			_bullets.push_back(new CRockCutBullet(this));
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_CUT);
			break;
		case BOOM:
			_bullets.push_back(new CBoomRockManBullet(this));
			break;
		}
		break;
	case STAIR_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			if (_isRight)
				_bullets.push_back(new CBulletRockman(Vector2(2 * ROCKMAN_VERLOCITY_X, 0), _position + Vector2(12, 0)));
			else
				_bullets.push_back(new CBulletRockman(Vector2(-2 * ROCKMAN_VERLOCITY_X, 0), _position - Vector2(12, 0)));
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_NORMAL);
			break;
		case CUT:
			_bullets.push_back(new CRockCutBullet(this));
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_CUT);
			break;
		case BOOM:
			_bullets.push_back(new CBoomRockManBullet(this));
		}
		break;
	case RUN_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			if (_isRight)
				_bullets.push_back(new CBulletRockman(Vector2(2 * ROCKMAN_VERLOCITY_X, 0), _position + Vector2(12, 0)));
			else
				_bullets.push_back(new CBulletRockman(Vector2(-2 * ROCKMAN_VERLOCITY_X, 0), _position - Vector2(12, 0)));
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_NORMAL);
			break;
		case CUT:
			_bullets.push_back(new CRockCutBullet(this));
			break;
		case BOOM:
			_bullets.push_back(new CBoomRockManBullet(this));
		}
		break;
	case JUMP_FIRE:
	case FALL_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			if (_isRight)
				_bullets.push_back(new CBulletRockman(Vector2(2 * ROCKMAN_VERLOCITY_X, 0), _position + Vector2(12, 0)));
			else
				_bullets.push_back(new CBulletRockman(Vector2(-2 * ROCKMAN_VERLOCITY_X, 0), _position - Vector2(12, 0)));
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_NORMAL);
			break;
		case CUT:
			_bullets.push_back(new CRockCutBullet(this));
			ResourceManager::PlayASound(ID_EFFECT_ROCKMAN_FIRE_BULLET_CUT);
			break;
			break;
		case BOOM:
			_bullets.push_back(new CBoomRockManBullet(this));
			break;
		}
		break;
	}
}

void CRockman::UpdateAnimation()
{
	if (IsDied())
		return;

	int previousSpriteStatus = _spriteStatus;
	switch (_behave)
	{
	case START:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_START;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_START_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_START_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_START_BOOM;
			break;
		}
		break;
	case STAND_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND_FIRE;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND_FIRE_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND_FIRE_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND_FIRE_BOOM;
			break;
		}
		break;
	case STAND:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND_GUTS;
			if (_hasRockOnHead)
				_spriteStatus = ID_SPRITE_ROCKMAN_STAND_GUTS_ROCK;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAND_BOOM;
			break;
		}
		break;
	case STAIR_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_FIRE;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_FIRE_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_FIRE_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_FIRE_BOOM;
			break;
		}
		break;
	case STAIR:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_BOOM;
			break;
		}
		break;
	case STAIR_BEGIN_END:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_END;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_END_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_END_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_STAIR_END_BOOM;
			break;
		}
		break;
	case RUN_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN_FIRE;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN_FIRE_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN_FIRE_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN_FIRE_BOOM;
			break;
		}
		break;
	case RUN:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN_GUTS;
			if (_hasRockOnHead)
				_spriteStatus = ID_SPRITE_ROCKMAN_RUN_GUTS_ROCK;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_RUN_BOOM;
			break;
		}
		break;
	case PREPARE_RUN:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_PREPARE_RUN;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_PREPARE_RUN_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_PREPARE_RUN_GUTS;
			if (_hasRockOnHead)
				_spriteStatus = ID_SPRITE_ROCKMAN_PREPARE_RUN_GUTS_ROCK;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_PREPARE_RUN_BOOM;
			break;
		}
		break;
	case JUMP:
	case FALL:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_FALL;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_FALL_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_FALL_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_FALL_BOOM;
			break;
		}
		break;
	case JUMP_FIRE:
	case FALL_FIRE:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_JUMP_FIRE;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_JUMP_FIRE_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_JUMP_FIRE_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_JUMP_FIRE_BOOM;
			break;
		}
		break;
	case HURT_IN_AIR:
	case HURT_ON_GROUND:
		switch (_currentSkill)
		{
		case NORMAL:
			_spriteStatus = ID_SPRITE_ROCKMAN_HURT;
			break;
		case CUT:
			_spriteStatus = ID_SPRITE_ROCKMAN_HURT_CUT;
			break;
		case GUTS:
			_spriteStatus = ID_SPRITE_ROCKMAN_HURT_GUTS;
			break;
		case BOOM:
			_spriteStatus = ID_SPRITE_ROCKMAN_HURT_BOOM;
			break;
		}
		break;
	}
	if (previousSpriteStatus != _spriteStatus)
		_sprite = ResourceManager::GetSprite(_spriteStatus);
}

vector<CBullet*> CRockman::GetBullets()
{
	vector<CBullet*> bullets = _bullets;
	_bullets.clear();

	return bullets;
}

void CRockman::ThroughOverDoor(int doorID){
	switch (doorID)
	{
	case ID_DOOR1_CUTMAN:
	case ID_DOOR1_GUTSMAN:
	case ID_DOOR2_CUTMAN:
	case ID_DOOR2_GUTSMAN:
	case ID_DOOR1_BOOMMAN:
		switch (_behave)
		{
		case STAND_FIRE:
		case STAND:
		case RUN:
		case PREPARE_RUN:
		case RUN_FIRE:
		case JUMP:
		case HURT_ON_GROUND:
			_behave = Behave::RUN;
			_v.x = ROCKMAN_VERLOCITY_X / 2;
			_a.x = ROCKMAN_ACCELERATE_X;
			_timeOverDoor = 1;
			_isGoingOverDoor = true;
			break;
		case JUMP_FIRE:
		case FALL:
		case FALL_FIRE:
		case HURT_IN_AIR:
			_behave = Behave::FALL;
			_v.x = ROCKMAN_VERLOCITY_X / 2;
			_a.x = ROCKMAN_ACCELERATE_X;
			_a.y /= 5;
			_timeOverDoor = 1;
			_isGoingOverDoor = true;
			break;
		}
		break;
	case ID_DOOR2_BOOMMAN:
		_behave = Behave::FALL;
		_v.x = 0.0f;
		_v.y = 0.0f;
		_a.y = -ROCKMAN_VERLOCITY_Y;
		_timeOverDoor = 1;
		_isGoingOverDoor = true;
		break;
	}
}

bool CRockman::IsGoingOverDoor(){
	return _isGoingOverDoor;
}

bool CRockman::IsOverDoor(){
	return _isOverDoor;
}

bool CRockman::IsRequireOpenDoor()
{
	return _isRequireOverDoor;
}

bool CRockman::IsRequireStopScreen()
{
	return _isRequireStopScreen;
}

map<Skill, int> CRockman::GetSkillInfo()
{
	return _skillInfos;
}

int CRockman::GetWeapons(Skill skill)
{
	return _skillInfos.find(skill)->second;
}

void CRockman::SetWeapons(Skill skill, int weapons)
{
	_skillInfos.erase(skill);
	_skillInfos.insert(pair<Skill, int>(skill, __min(BLOOD_DEFAULT, weapons)));
	_currentSkill = skill;
}

int CRockman::GetLife()
{
	return _life;
}

Skill CRockman::GetCurrentSkill()
{
	return _currentSkill;
}

void CRockman::ReSetSKill()
{
	_canFire = true;
	_behave = Behave::START;
	_v.x = _v.y = _a.x = _a.y = 0.0f;
	_isChangingState = true;

}

void CRockman::ResetAll()
{
	// Cài đặt trạng thái Ready cho Rockman
	_v.x = 0.0f;
	_v.y = -ROCKMAN_VERLOCITY_Y;
	_a.x = 0.0f;
	_a.y = -ROCKMAN_ACCELERATE_Y;
	_behave = Behave::START;
	_blood = BLOOD_DEFAULT;
	_isRequireEndGame = false;
	_isRight = true;
	_canJump = true;
	_canJumpMore = true;
	_isInBossRoom = false;
	_isRequireOverDoor = false;
	_isRequireStopScreen = false;
	_isOverDoor = false;
	_isGoingOverDoor = false;
	_canFire = true;
	_isTheFirstTime = true;
	_isChangingState = false;
	_isInShield = false;
	_changeScreenDirection = CDirection::NONE_DIRECT;

	// Cài đặt một số biến thời gian cần thiết cho việc vẽ các đối tượng
	_deltaTime = 0;
	_timeDie = 5.0f * 1000.0f;
	_jumpTime = 0.0f;
	_timeOverDoor = 0.0f;
	_deltaTimeCanFire = 0.0f;

	// Khởi động Rockman, lấy các skill từ CGameInfo
	vector<Skill> skills = CGameInfo::GetInstance()->GetSkills();
	_skillInfos.clear();
	for (int i = 0; i < skills.size(); i++)
		_skillInfos.insert(pair<Skill, int>(skills[i], WEASPON_DEFAULT));

	_currentSkill = Skill::NORMAL;

	// Cần phải lấy sprite tương ứng trước để thực hiện việc vẽ và cập nhật box va chạm
	// Vì thế giới thực hiện vẽ trước khi update
	UpdateAnimation();
	UpdateBox();

	// Xác định các đối tượng có va chạm
	_collidedObjectInside = new  CollisionInfo(NULL, CDirection::INSIDE, std::numeric_limits<float>::infinity());


	_collidedObjectGroundLeft = new  CollisionInfo(NULL, CDirection::ON_LEFT, std::numeric_limits<float>::infinity());
	_collidedObjectGroundRight = new  CollisionInfo(NULL, CDirection::ON_RIGHT, std::numeric_limits<float>::infinity());
	_collidedObjectGroundUp = new  CollisionInfo(NULL, CDirection::ON_UP, std::numeric_limits<float>::infinity());
	_collidedObjectGroundDown = new  CollisionInfo(NULL, CDirection::ON_DOWN, std::numeric_limits<float>::infinity());
	_collidedObjectGroundInside = new  CollisionInfo(NULL, CDirection::INSIDE, std::numeric_limits<float>::infinity());

}

bool CRockman::IsEndGame()
{
	return _isRequireEndGame;
}