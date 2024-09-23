#include "CGutsManBullet.h"

CGutsManBullet::CGutsManBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition) : CBullet(id, typeID, sprite, dame, v, beginPosition)
{
	this->_idSprite = ID_SPRITE_GUSTMAN_ROCKFIRE;
	this->_sttRock = STTBOOM::NONE;
	this->_preIdSprite = _idSprite;
	this->_dieDistance = 100.0f/1000.0f;
	this->_timeaddspeed = 10.0f;
	this->_isfire = false;
	this->_flat = false;
	this->_timeExplosive = TIME_EXPLOSIVE_GUST;
	this->_isOneHitBullet = true;
}

int CGutsManBullet::Initlize()
{
	return 0;
}

CGutsManBullet::~CGutsManBullet()
{

}

void CGutsManBullet::Update(CGameTime* gameTime)
{
	float t = gameTime->GetDeltaTime();
	//Thây đổi trạng thái đạn boom.
	this->CheckStatus(t);	

	//bắt đầu làm rớt đạn để bắn
	if(this->_isfire)
	{
		this->_v.y = 20.0f / 1000.0f;
		this->_isfire = false;
		this->_sttRock = STTBOOM::DROPP;
		this->_idSprite = ID_SPRITE_GUSTMAN_ROCKFIRE;
	}

	//tính đường bắn.
	if(this->_flat)
	{
		this->Fire();
		this->_flat = false;
	}

	if(this->_sttRock == STTBOOM::DROPP) //rớt boom
	{
		this->_position.y -= this->_v.y * (t * this->_timeaddspeed);
	}
	 else if(this->_sttRock == STTBOOM::FIRE) // bắn boom 
	{
		this->_v.y -= GRAVITY*(t * this->_timeaddspeed);
		this->_position.x += this->_v.x * (t * this->_timeaddspeed);
		this->_position.y += this->_v.y * (t * this->_timeaddspeed) - 0.5f * GRAVITY * pow((t * this->_timeaddspeed), 2);
	}
	else if(this->_sttRock == STTBOOM::EXPLOSIVE) // boom nổ
	{
		this->_dieDistance += (0.09f)*gameTime->GetDeltaTime();
	}
	else //boom đứng yên
	{
		
	}
	
	this->_sprite.Update(gameTime);
	this->UpdateBox();
}

void CGutsManBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	switch (this->_sttRock)
	{
	case STTBOOM::EXPLOSIVE:
		{	
			for(int i = -1; i < 2; i++)
			{
				if((this->_posGutsMan.x - this->_posRockMan.x) > 0)
				{
					graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), Vector2(this->_dieDistance* cos(PI -i*( PI / 6.0f)) + this->_position.x, this->_dieDistance *sin(PI - i*(PI / 6.0f)) + this->_position.y), Vector2(1.5f, 1.5f));
				}
				else
				{
					graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), Vector2(this->_dieDistance* cos(i*( PI / 6.0f)) + this->_position.x, this->_dieDistance *sin(i*(PI / 6.0f)) + this->_position.y), Vector2(1.5f, 1.5f));
				}			 			
			}
			break;
		}
	default:
		{
			if(this->_sttRock != STTBOOM::NONE)
				graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true, SpriteEffects::FLIP_HORIZONTALLY);
		}
		break;
	}
	CGameObject::Render(gameTime, graphics);
}

void CGutsManBullet::Fire()
{
	float apha = 0.7f;
	float lenghtMax = abs(this->_posRockMan.x - this->_position.x);
	float heightMax = 0.0f;

	if(lenghtMax < 50.0f)
	    heightMax = lenghtMax;
	else
		heightMax = 60.0f;

	lenghtMax -= 50.0f; // fix vị trí ném trúng rock man.

	apha = atan((4 * heightMax) / lenghtMax);

	float v0 = (float)sqrt((lenghtMax* abs(GRAVITY)) / sin(2 * apha));

	this->_v.x = v0 * cos(apha);
	this->_v.y = v0 * sin(apha);

	if(this->_posRockMan.x > this->_position.x)
		this->_v.x = abs(this->_v.x);
	else
		this->_v.x =  abs(this->_v.x) * -1;

	this->_sttRock = STTBOOM::FIRE;
}

void CGutsManBullet::reset()
{
	this->_state = BULLET_BASE_STATE::DIE; // xóa khỏi list đạn screenPLay
	this->_sttRock = STTBOOM::FIRE;
	this->_idSprite = ID_SPRITE_GUSTMAN_ROCKFIRE;
	this->_position = Vector2(this->_posGutsMan.x, this->_posGutsMan.y + 150.0f);
	this->_sttRock = STTBOOM::NONE;

	this->_isfire = false;
	this->_isOneHitBullet = true;

	this->_dieDistance = 50.0f/1000.0f;
	this->_timeExplosive = TIME_EXPLOSIVE_GUST;	
}

void CGutsManBullet::UpdateBox()
{
	if(this->_sttRock == STTBOOM::EXPLOSIVE)
	{
		//Box va chạm sẽ lơn lên khi đá bị vỡ 
		if((this->_posGutsMan.x - this->_posRockMan.x) > 0)
		{
			this->_box._width = 31.0f * 3;
			this->_box._height = 31.0f * 2;
			this->_box._x = this->_position.x - this->_box._width;
			this->_box._y = this->_position.y + this->_box._height/2;
		}
		else
		{
			this->_box._width = 31.0f * 3;
			this->_box._height = 31.0f * 2;
			this->_box._x = this->_position.x - this->_box._width/5;
			this->_box._y = this->_position.y + this->_box._height;
		}
	
		this->_box._vx = this->_v.x;
		this->_box._vy = this->_v.y;
	}
	else
	{
		this->_box._width = 31.0f;
		this->_box._height = 31.0f;
		this->_box._x = this->_position.x - this->_box._width/2;
		this->_box._y = this->_position.y + this->_box._height / 2;
		this->_box._vx = this->_v.x;
		this->_box._vy = this->_v.y;
	}
	
}

void CGutsManBullet::CheckStatus(float t)
{
	// khoảng cách giữa bullet và ROCK man
	double sp = sqrt((this->_position.x - this->_posRockMan.x) * (this->_position.x - this->_posRockMan.x) 
		+ (this->_position.y - this->_posRockMan.y) * (this->_position.y - this->_posRockMan.y));

	// khoảng cách giữa bullet và posGutsMan
	double spGust = sqrt((this->_position.x - this->_posGutsMan.x) * (this->_position.x - this->_posGutsMan.x) 
		+ (this->_position.y - this->_posGutsMan.y) * (this->_position.y - this->_posGutsMan.y));

	//Boom va cham với boom man thì dừng lại
	if(spGust <= 30.0f && this->_sttRock == STTBOOM::DROPP)// Chuyển sang trạng thái ném boom
	{	
		this->_flat = true;
	}

	// nổ xong thì reset lại trái boom
	this->_timeExplosive -= t;
	if(this->_timeExplosive <= 0 && this->_sttRock == STTBOOM::EXPLOSIVE)
	{
		this->reset();
	}

	//Thay đổi sprite
	if(this->_preIdSprite != _idSprite)
	{
		this->_sprite = ResourceManager::GetSprite(_idSprite);
		this->_sprite.SetIndex(0);
		this->_preIdSprite = _idSprite;
	}	
}

void CGutsManBullet::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
	// Nếu va chạm với .......
	switch (gameObject->_typeID)
	{
	case ID_ROCK:
	case ID_BLOCK:
	case ID_ROCKMAN:
	{
					   if (this->_sttRock != STTBOOM::NONE && this->_sttRock != STTBOOM::DROPP &&
						   this->_sttRock != STTBOOM::EXPLOSIVE && normalY != CDirection::ON_UP
						   || 
							((normalX == CDirection::ON_LEFT || normalX == CDirection::ON_RIGHT || normalX == CDirection::INSIDE) && deltaTime < 0.0f)
						   )
					   {
						   this->_sttRock = STTBOOM::EXPLOSIVE;
						   this->_idSprite = ID_SPRITE_WEAPON_GUTS_PART;
						   this->_timeExplosive = TIME_EXPLOSIVE_GUST;
					   }
			
		break;
		}
	}
}

void CGutsManBullet::SetStatus()
{
	this->_state = BULLET_BASE_STATE::FLYING; // làm cho  viên đạn sống lại
}