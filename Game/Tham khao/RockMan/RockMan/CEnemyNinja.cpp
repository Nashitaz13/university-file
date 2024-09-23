#include "CEnemyNinja.h"
CEnemyNinja::CEnemyNinja()
{
	_dame = DAME_ENEMY_NINJA;
	_static = STATICNINJA::NINJASTAND;
	_historyStatic = STATICNINJA::NINJASTAND;
	_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_NINJA_STAND);
	_blood = 1;
	_score = SCORE_DEFAULT;
	_fistJump = false;
	_timetestdefault = 2000;
}
CEnemyNinja::~CEnemyNinja()
{
	
}
int CEnemyNinja::Initlize()
{
	_v == Vector2(0.0f, 0.0f);
	_g = 0.4f / 1000.0f;
	_lMaxDefault = 40;
	_hMaxDefault = 60;
	_historyCollide = CDirection::NONE_DIRECT;
	_timeHistoryCollide = std::numeric_limits<float>::infinity();
	_timeFireDefault = 200;
	_timeProtectDefault = 1000;
	UpdateBox();
	return 1;
}
void CEnemyNinja::UpdateBox()
{
	_box._x = _position.x - 13;
	_box._y = _position.y +12;
	_box._vx = _v.x;
	_box._vy = _v.y;
	_box._width = 26;
	_box._height =24;
}
void CEnemyNinja::Update(CGameTime* gameTime, CRockman* rockman)
{
	// xử lý tiền va chạm 
	if (_historyCollide != CDirection::NONE_DIRECT)
	{
		switch (_historyCollide)
		{
		case CDirection::ON_UP:
			_position.y += _timeHistoryCollide*_v.y - 1;
			_v.y = 0;
			_v.x = 0;
			_static = STATICNINJA::NINJAFALL;
			break;
		case CDirection::ON_RIGHT:
			_position.x += _timeHistoryCollide*_v.x - 1;
			_v.y = 0;
			_v.x = 0;
			_static = STATICNINJA::NINJAFALL;
			break;
		case CDirection::ON_LEFT:
			_position.x += _timeHistoryCollide*_v.x + 1;
			_v.x = 0;
			_v.y = 0;
			_static = STATICNINJA::NINJAFALL;
			break;
		case CDirection::ON_DOWN:
			_position.y += _timeHistoryCollide*_v.y+1;
			_v.y = 0.0f;
			_v.x = 0.0f;
			_static = STATICNINJA::NINJAFIRE;// rớt xuống bắn ngay 
			break;
		default:
			break;
		}
	}
	// lần đầu tiên khi vào ninja sẽ nhảy đến rockman 
	if (!_fistJump)
	{
		_fistJump = true;
		Jump(rockman->_position,TYPEJUMP::NINJAJUMPTOROCKMAN);
	}
	// xử lý sau va chạm 
	switch (_static)
	{
	case STATICNINJA::NINJASTAND:
		// hết thời gian bảo vệ ninja sẽ bắn 
		if (_timeProtect <= 0)
		{
			Jump(rockman->_position, TYPEJUMP::NINJAJUMPSTAND);
			_timeProtect = _timeProtectDefault;
		}
		_timeProtect -= gameTime->GetDeltaTime();
		if ((rockman->_position.x > _position.x))
		{
			Jump(rockman->_position,TYPEJUMP::NINJAJUMPTOROCKMAN);
		}
		break;
	case STATICNINJA::NINJAJUMP:
		_position.x += _v.x*(gameTime->GetDeltaTime());
		_position.y += _v.y*(gameTime->GetDeltaTime());

		_v.y -= _g*(gameTime->GetDeltaTime()); 
		break;
	case STATICNINJA::NINJAFALL:
		_position.y += _v.y*(gameTime->GetDeltaTime());
		_v.y -= _g*(gameTime->GetDeltaTime());
		break;
	case STATICNINJA::NINJAFIRE:
		_timeFire -= gameTime->GetDeltaTime();
		if (_timeFire <= 0)
		{
			_timeFire = _timeFireDefault;
			_static = STATICNINJA::NINJASTAND;
			// thực hiện bắn đạn 
			{
				_lstBullet.clear();
				_lstBullet.push_back(new CBulletNinja(0, ID_BULLET_ENEMY_NINJA, ResourceManager::GetSprite(ID_SPRITE_BULLET_ENEMY_NINJA), DAME_BULLET_NINJA, 0, Vector2(0, 0), 0, _position.x, _position.y));
				ResourceManager::PlayASound(ID_EFFECT_ENEMY_FIRE);
			}
		}
		break;
	default:
		break;
	}
	
	_historyCollide = CDirection::NONE_DIRECT;
	_timeHistoryCollide = std::numeric_limits<float>::infinity();
	UpdateBox();
}
void CEnemyNinja::Update(CGameTime* gameTime)
{

}
void CEnemyNinja::Jump(Vector2 positionRockman,TYPEJUMP typeJump)
{
	
	_typeJump = typeJump;
	int hMax, lMax;
	float	anpha, v0;
	hMax = _hMaxDefault;
	if (typeJump == TYPEJUMP::NINJAJUMPTOROCKMAN)
		lMax = abs(_position.x - positionRockman.x - 70);
	else
		lMax = 1;
	if (lMax == 0)
	{
		lMax = 1;
	}
	anpha = atan((4 * hMax) / lMax);
	v0 = (float)sqrt((lMax*abs(_g)) / sin(2 * anpha));

	_v.x = v0*cosf(anpha);
	_v.y = v0*sinf(anpha);

	if (positionRockman.x > _position.x)

		_v.x = abs(_v.x);
	else
		_v.x = abs(_v.x)*-1;

	_static = STATICNINJA::NINJAJUMP;

	_positionXRockMan = positionRockman.x;
}

void CEnemyNinja::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	switch (gameObject->_typeID)
	{
	case ID_BLOCK:
	case ID_ROCK:
		
		if (deltaTime < _timeHistoryCollide)
		{
			_timeHistoryCollide = deltaTime;
			if (normalX != CDirection::NONE_DIRECT)
				_historyCollide = normalX;
			if (normalY != CDirection::NONE_DIRECT)
				_historyCollide = normalY;
		}
		break;
	case ID_BULLET_ROCKMAN_NORMAL: 
		if (_static == STATICNINJA::NINJAFIRE)
		      _blood--;
		else
		{
			ResourceManager::PlayASound(ID_EFFECT_BULLET_HIT_ENEMY_WITH_SHIELD);
			_timeProtect = _timeProtectDefault;
			//((CBullet*)gameObject)->Die();
			//CExplodingEffectManager::Add(new CExplodingEffect(gameObject->));
		}
		break;
	case ID_BULLET_ROCKMAN_CUT: case ID_BULLET_ROCKMAN_GUTS: case ID_BULLET_ROCKMAN_BOOM:
		if (_static == STATICNINJA::NINJAFIRE)
			_blood--;
		break;

	default:
		break;
	}
}
void CEnemyNinja::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (_historyStatic != _static)
	{
		_historyStatic = _static;
		switch (_historyStatic)
		{
		case STATICNINJA::NINJAFALL: case STATICNINJA::NINJAJUMP:
			_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_NINJA_JUMP);
			break;
		case STATICNINJA::NINJASTAND:
			_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_NINJA_STAND);
			break;
		case STATICNINJA::NINJAFIRE:
			_sprite = ResourceManager::GetSprite(ID_SPRITE_ENEMY_NINJA_FIRE);
			break;
		default:
			break;
		}
	}
	// đổi hướng vẽ khi ninja qua mặt rockman
	if (_static==STATICNINJA::NINJAJUMP&&_typeJump==TYPEJUMP::NINJAJUMPTOROCKMAN&&(_position.x<_positionXRockMan))
	graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true,Vector2(1,1),SpriteEffects::FLIP_HORIZONTALLY);
	else
	{
		graphics->Draw(_sprite.GetTexture(), _sprite.GetDestinationRectangle(), _position, true);
	}
	CGameObject::Render(gameTime, graphics);
}
CEnemyNinja* CEnemyNinja::ToValue()
{
	return new CEnemyNinja(*this);
}
vector<CBullet*> CEnemyNinja::Fire()
{
	vector<CBullet*> result = _lstBullet;
	//Xóa hết đạn trong danh sách vì bên ngoài đã nhận rồi
	_lstBullet.clear();
	return result;
}