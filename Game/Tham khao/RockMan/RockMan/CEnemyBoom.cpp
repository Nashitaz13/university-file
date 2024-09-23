#include "CEnemyBoom.h"

CEnemyBoom::CEnemyBoom(int id, int typeID, CSprite sprite, CSprite spriteExplodingEffect, float vy, Vector2 positionBegin, int dame, int blood, int score) :CEnemy()
{
	_id = id;
	_typeID = typeID;
	_sprite = sprite;
	_v = Vector2(0,vy);
	_vBegin = Vector2(0, vy);
	_dame = dame;
	_position = positionBegin;
	_positionBegin = positionBegin;
	_lstBullet = vector<CBullet*>();
	_blood = blood;
	_score = score;
	_timeDelayAttackRemain = TIME_DELAY_ATTACK_OF_BOOM_ENEMY;
	_state = ENEMYBOOM_STATE::FLYING;
	_explodingEffect = new CExplodingEffect(_position, spriteExplodingEffect);
	_explodingEffect->Initlize();

}

CEnemyBoom::~CEnemyBoom()
{
	SAFE_DELETE(_explodingEffect);
}

int CEnemyBoom::Initlize()
{
	_origin = Vector2(_size.x / 2, _size.y / 2);
	UpdateBox();
	return 1;
}

void CEnemyBoom::Update(CGameTime* gameTime, CRockman* rockman)
{
	_sprite.Update(gameTime);

	//Nếu hết thời gian nghỉ tấn công thì tiến hành tấn công
	if (_timeDelayAttackRemain <= 0)
	{
		_state = ENEMYBOOM_STATE::FLYING;
		_v = _vBegin;
		//Cấp phát lại thời gian NGHỈ để nó không chạy vào hàm if này nữa và để cho tới khi nổ xong thì không cần phải cấp phát lại nữa
		_timeDelayAttackRemain = TIME_DELAY_ATTACK_OF_BOOM_ENEMY;
	}

	if (_state == ENEMYBOOM_STATE::FLYING)
	{
		AttackRockman(gameTime->GetDeltaTime());
		//Tăng vận tốc 1 chút để có cảm giác nhanh dần đều
		_v.y=_v.y*1.075;
	}
	else
		if (_state == ENEMYBOOM_STATE::EXPLODING)
		{
			_explodingEffect->Update(gameTime);
			if (_explodingEffect->IsDone() == true)
			{
				_state = ENEMYBOOM_STATE::DELAY;
				_position = _positionBegin;
			}
		}
		else
			_timeDelayAttackRemain -= gameTime->GetDeltaTime();

	this->UpdateBox();
}

void CEnemyBoom::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_state == ENEMYBOOM_STATE::FLYING)
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	else
		if (_state == ENEMYBOOM_STATE::EXPLODING)
			_explodingEffect->Render(gameTime, graphics);

	CGameObject::Render(gameTime, graphics);
	CMoveableObject::Render(gameTime, graphics);	
}

void CEnemyBoom::UpdateBox()
{
	if (_state == ENEMYBOOM_STATE::FLYING)
	{
		_box._x = _position.x - _sprite.GetFrameWidth() / 2;
		_box._y = _position.y + _sprite.GetFrameHeight() / 2;
		_box._vx = _v.x;
		_box._vy = _v.y;
		_box._width = _sprite.GetFrameWidth();
		_box._height = _sprite.GetFrameHeight();
	}
	else
		if (_state == ENEMYBOOM_STATE::EXPLODING)
		{
			_box = _explodingEffect->GetBox();
		}
		else
		{
			_box._vx = 0;
			_box._vy = 0;
			_box._y = _position.y - 30;
			_box._width = 0;
			_box._height = 0;
		}
}

void CEnemyBoom::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	/*switch (gameObject->_typeID)
	{
	case ID_BULLET_ROCKMAN_GUTS:
	case ID_BULLET_ROCKMAN_NORMAL:
		if (normalX == CDirection::ON_LEFT || normalX == CDirection::ON_RIGHT)
		{
			_blood -= ((CBullet*)gameObject)->GetDame();
			if (_blood <= 0)
			{
				_explodingEffect->_position.x = _position.x;
				_explodingEffect->_position.y = _position.y;
				_state = ENEMYBOOM_STATE::EXPLODING;
			}
		}
		break;
	}*/
}

CEnemyBoom* CEnemyBoom::ToValue()
{
	return new CEnemyBoom(*this);
}

void CEnemyBoom::AttackRockman(float deltaTime)
{
	//Nếu chiều cao bay của EnemyBoom chưa đạt đến tới hạn
	if (abs(_positionBegin.y - _position.y) < HMAX_FLY_OF_BOOM_ENEMY)
	{
		_position.x += deltaTime*_v.x;
		_position.y += deltaTime*_v.y;
	}
	else//Nếu đã đến tới hạn rồi thì tiến hành kích hoạt nổ
	{
		_explodingEffect->_position.x = _position.x;
		_explodingEffect->_position.y = _positionBegin.y + HMAX_FLY_OF_BOOM_ENEMY;
		
		#pragma region Bắn đạn
		//Để chắc ăn là đạn không còn trước khi được add vào thì tiến hành clear() trước
		_lstBullet.clear();
		CBullet*  bullet1 = new CEnemyBoomBullet(0, ID_BULLET_BOOM,
			ResourceManager::GetSprite(ID_SPRITE_BULLET_BOOM),
			ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
			DAME_BULLET_BOOM, _explodingEffect->_position,
			230,
			6.0f * PI / 24.0f);
		bullet1->Initlize();

		CBullet*  bullet2 = new CEnemyBoomBullet(0, ID_BULLET_BOOM,
			ResourceManager::GetSprite(ID_SPRITE_BULLET_BOOM),
			ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
			DAME_BULLET_BOOM, _explodingEffect->_position,
			230,
			PI-(6.0f * PI / 24.0f));//Sử dụng công thức lượng giác 2 cung bù nhau.
		bullet2->Initlize();

		CBullet*  bullet3 = new CEnemyBoomBullet(0, ID_BULLET_BOOM,
			ResourceManager::GetSprite(ID_SPRITE_BULLET_BOOM),
			ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
			DAME_BULLET_BOOM, _explodingEffect->_position,
			410,
			4.5f * PI / 24.0f);
		bullet3->Initlize();

		CBullet*  bullet4 = new CEnemyBoomBullet(0, ID_BULLET_BOOM,
			ResourceManager::GetSprite(ID_SPRITE_BULLET_BOOM),
			ResourceManager::GetSprite(ID_SPRITE_EXPLODING_EFFECT_BASE),
			DAME_BULLET_BOOM, _explodingEffect->_position,
			410,
			PI-(4.5f * PI / 24.0f));//Sử dụng công thức lượng giác 2 cung bù nhau.
		bullet4->Initlize();

		_lstBullet.push_back(bullet1);
		_lstBullet.push_back(bullet2);
		_lstBullet.push_back(bullet3);
		_lstBullet.push_back(bullet4);
		#pragma endregion
		
		_state = ENEMYBOOM_STATE::EXPLODING;
		_explodingEffect->SetSoundEffect(-1);
	}
}

vector<CBullet*> CEnemyBoom::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	//result.clear();//testing
	return result;
}