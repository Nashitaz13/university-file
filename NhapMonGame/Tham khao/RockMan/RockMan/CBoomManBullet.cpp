#include "CBoomManBullet.h"

CBoomManBullet::CBoomManBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition) : CBullet(id, typeID, sprite, dame, v, beginPosition)
{
	this->_idSprite = ID_SPRITE_BULLET_BOSS_BOOM;
	this->_sttBoom = STTBOOM::START;
	this->_preIdSprite = _idSprite;
	this->_dieDistance = 50.0f/1000.0f;
	this->_timeaddspeed = 8.5f;
	this->_timerPush = 0.0f;
	this->_isfire = false;
	this->_isOneHitBullet = true;
	this->_v = Vector2(28.0f / 1000.0f, 30.0f / 1000.0f);
	this->_posRockManStand = Vector2(0,0);
	this->_isBoomManDie = false;
	this->_gravity = -9.8f/1000.0f;
	this->_timeExplosive = TIME_EXPLOSIVE;
}

int CBoomManBullet::Initlize()
{
	
	return 0;
}

CBoomManBullet::~CBoomManBullet()
{

}

void CBoomManBullet::Update(CGameTime* gameTime)
{
	// boom man die thì reset lại thuộc tính
	if(this->_isBoomManDie)
	{
		this->_idSprite = ID_SPRITE_BULLET_BOSS_BOOM;
		this->_position = Vector2(this->_posBoomMan.x - 8.0f, this->_posBoomMan.y + 18.5f);
		this->_sttBoom = STTBOOM::START;
		this->_isBoomManDie = false;
		this->_timerPush = 0.0f;
		this->_v = Vector2(28.0f / 1000.0f, 60.0f / 1000.0f);
		this->_timeExplosive = TIME_EXPLOSIVE;
	}

	float t = gameTime->GetDeltaTime();
	//Thây đổi trạng thái đạn boom.
	if(this->_sttBoom != STTBOOM::START)
		this->CheckStatus(t);
	
	
	if(this->_isfire)
	{
		this->Fire();
		this->_isfire = false;
	}

	if(this->_sttBoom == STTBOOM::START)
	{
		
		if (this->_timerPush >=300.0f)
		{
			this->_v.y = this->_v.y * (-1.0f);
			this->_timerPush = 0.0f;
		}

		this->_timerPush += t;
		//this->_v.y += _gravity;

		this->_position.y += this->_v.y * 130.0f;
	}
	else if(this->_sttBoom == STTBOOM::FIRE) // boom bắn
	{
		this->_v.y -= GRAVITY*(t * this->_timeaddspeed);
		this->_position.x += this->_v.x * (t * this->_timeaddspeed);
		this->_position.y += this->_v.y * (t * this->_timeaddspeed) - 0.5f * GRAVITY * pow((t * this->_timeaddspeed), 2);
	}
	else if(this->_sttBoom == STTBOOM::EXPLOSIVE) // boom nổ
	{
		this->_dieDistance += (0.05f)*gameTime->GetDeltaTime();
	}
	else //boom đứng yên
	{
		
	}

	this->_sprite.Update(gameTime);
	this->UpdateBox();
}

void CBoomManBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	switch (this->_sttBoom)
	{
	case STTBOOM::EXPLOSIVE:
		{
			//CExplodingEffectManager::Add(new  CExplodingEffectX(_position, ResourceManager::GetSprite(ID_SPRITE_BOOMMAN_BOOM_BURST), false));
			for (int i = 1; i < 7; i++)
			{
				graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), Vector2(this->_dieDistance* cos(i*PI / 3.0f) + this->_position.x, this->_dieDistance *sin(i*PI / 3.0f) + this->_position.y), Vector2(1.0f, 1.0f));
				graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), Vector2((this->_dieDistance + 5.0f)* cos(i*PI / 3.0f) + this->_position.x, (this->_dieDistance + 2.0f) *sin(i*PI / 3.0f) + this->_position.y), Vector2(1.0f, 1.0f));
			}
			break;
		}
	default:
		{
			if(this->_v.x > 0)
				graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true, SpriteEffects::FLIP_HORIZONTALLY);
			else
				graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true);
		}
		break;
	}

	CGameObject::Render(gameTime, graphics);
  	
}

void CBoomManBullet::Fire()
{
	float apha = 0.7f;
	float lenghtMax = abs(this->_posRockMan.x - this->_position.x);
	float heightMax = 0.0f;

	if(lenghtMax < 50.0f)
	    heightMax = lenghtMax;
	else
		heightMax = 60.0f;

	lenghtMax -= 10.0f; // fix vị trí ném trúng rock man.

	apha = atan((4 * heightMax) / lenghtMax);

	float v0 = (float)sqrt((lenghtMax* abs(GRAVITY)) / sin(2 * apha));

	this->_v.x = v0 * cos(apha);
	this->_v.y = v0 * sin(apha);

	if(this->_posRockMan.x > this->_position.x)
		this->_v.x = abs(this->_v.x);
	else
		this->_v.x =  abs(this->_v.x) * -1;

	this->_sttBoom = STTBOOM::FIRE;
}

void CBoomManBullet::Reset()
{
	this->_isOneHitBullet = true;
	this->_state = BULLET_BASE_STATE::DIE; // xóa khỏi list đạn screenPLay
	this->_idSprite = ID_SPRITE_BULLET_BOSS_BOOM;

	if(!this->_isBoomManDie && this->_sttBoom != STTBOOM::START)
	{
		this->_position = this->_posBoomMan;
		this->_sttBoom = STTBOOM::NONE;
	}

	// boom man die thì reset lại thuộc tính
	if(this->_isBoomManDie)
	{
		this->_position = Vector2(this->_posBoomMan.x - 8.0f, this->_posBoomMan.y + 18.5f);
		this->_sttBoom = STTBOOM::START;
		this->_isBoomManDie = false;
	}
	this->_isfire = false;
	this->_dieDistance = 50.0f/1000.0f;
	this->_timeExplosive = TIME_EXPLOSIVE;
}

void CBoomManBullet::UpdateBox()
{
	if(this->_sttBoom == STTBOOM::EXPLOSIVE)
	{
		this->_box._width = this->_sprite.GetFrameWidth() * 3;
		this->_box._height = this->_sprite.GetFrameHeight() * 3;
		this->_box._x = this->_position.x - this->_box._width / 2;
		this->_box._y = this->_position.y + this->_box._height / 2;
		this->_box._vx = this->_v.x;
		this->_box._vy = this->_v.y;
	}
	else
	{
		this->_box._x = this->_position.x - this->_sprite.GetFrameWidth() / 2;
		this->_box._y = this->_position.y + this->_sprite.GetFrameHeight() / 2;
		this->_box._vx = this->_v.x;
		this->_box._vy = this->_v.y;
		this->_box._width = this->_sprite.GetFrameWidth();
		this->_box._height = this->_sprite.GetFrameHeight();
	}
}

void CBoomManBullet::CheckStatus(float t)
{
	// khoảng cách giữa bullet và cut man
	double sp = sqrt((this->_position.x - this->_posRockMan.x) * (this->_position.x - this->_posRockMan.x) 
		+ (this->_position.y - this->_posRockMan.y) * (this->_position.y - this->_posRockMan.y));

	//Boom va cham với rock man or chạm đất thì nổ
	if((sp <= 1.0f || this->_position.y - this->_posRockManStand.y <= 0) && this->_sttBoom == STTBOOM::FIRE)// Chuyển sang trạng thái nổ boom
	{
		this->_sttBoom = STTBOOM::EXPLOSIVE;	
		this->_idSprite = ID_SPRITE_BOOMMAN_BOOM_BURST;
		this->_timeExplosive = TIME_EXPLOSIVE;
	}
	
	this->_timeExplosive -= t;
	// nổ xong thì reset lại trái boom
	if (this->_sttBoom == STTBOOM::EXPLOSIVE && this->_timeExplosive <=0)
	{
		this->Reset();
	}

	//Thay đổi sprite
	if(this->_preIdSprite != _idSprite)
	{
		this->_sprite = ResourceManager::GetSprite(_idSprite);
		this->_sprite.SetIndex(0);
		this->_preIdSprite = _idSprite;
	}	
}

void CBoomManBullet::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	// Nếu va chạm với .......
	switch (gameObject->_typeID)
	{	
	case ID_BLOCK:
	case ID_ROCKMAN: // xử lý va chạm với rockman
		if (normalY == CDirection::ON_DOWN)
		{ 
			this->_timeExplosive = TIME_EXPLOSIVE;
			this->_sttBoom = STTBOOM::EXPLOSIVE;
			this->_idSprite = ID_SPRITE_BOOMMAN_BOOM_BURST;
		}		
		break;
	default:	
		break;
	}	
}

void CBoomManBullet::SetStatus(bool i)
{
	if (i)
		this->_state = BULLET_BASE_STATE::FLYING; // làm cho  viên đạn sống lại
	else
		this->_state = BULLET_BASE_STATE::DIE; // làm cho  viên đạn hủy
}