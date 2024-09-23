#include "CCutManBullet.h"

CCutManBullet::CCutManBullet(int id, int typeID, CSprite sprite, int dame, Vector2 v, Vector2 beginPosition):CBullet(id, typeID, sprite, dame, v, beginPosition)
{
	this->_posRockMan = Vector2(0, 0);
	this->_posCutMan = beginPosition;
	this->_isReverse = false;
	this->_speed = 1.5f;
	this->_isHide = true;
}

int CCutManBullet::Initlize()
{
	return 0;
}

CCutManBullet::~CCutManBullet()
{

}

void CCutManBullet::Update(CGameTime* gameTime)
{
	float t = gameTime->GetDeltaTime();
	
	this->CheckDirectionBullet();

	this->_sprite.Update(gameTime);

	this->UpdateBox();
}

void CCutManBullet::CheckDirectionBullet()
{
	// khoảng cách giữa bullet và cut man
	 this->_spBulletAndCutMan = sqrt((this->_position.x - this->_posCutMan.x) * (this->_position.x - this->_posCutMan.x) 
		+ (this->_position.y - this->_posCutMan.y) * (this->_position.y - this->_posCutMan.y));
	// khảng cách giữa cut và rock man
	double spCutAndRock = sqrt((this->_posRockMan.x - this->_posCutMan.x) * (this->_posRockMan.x - this->_posCutMan.x) 
		+ (this->_posRockMan.y - this->_posCutMan.y) * (this->_posRockMan.y - this->_posCutMan.y));

	double result = this->_spBulletAndCutMan - spCutAndRock;
	if( result < 70.0f && !this->_isReverse)
	{
		this->Fire((result/result) * -1);		
	}
	else
	{
		this->Fire(result/result);
		this->_isReverse = true;
	}

}

void CCutManBullet::Hide()
{
	this->_isHide = false;
	this->_isReverse = false;

	// thu box lại = 0;
	this->_box._width = 0.0f;
	this->_box._height = 0.0f;
}

void CCutManBullet::Fire(double d)
{
	int x = 0;
	int y = 0;	
	// xậy dựng pt đường thẳng
	Vector2 u;
	if(!this->_isReverse)
	{
		u = Vector2(this->_posCutMan.x - this->_posRockMan.x, this->_posCutMan.y - this->_posRockMan.y);
		this->_v.x = 55.0f;

	}
	else
	{
   		u = Vector2(this->_posCutMan.x - this->_position.x, this->_posCutMan.y - this->_position.y);
		this->_v.x += 50.0f;	

		if(this->_v.x > 1000.0f)
			this->_v.x = 200.0f;
	}

	if (abs(this->_posCutMan.x - this->_posRockMan.x) > 50) // fix tốc độ đạn
	{
		x = this->_posCutMan.x / 100 + u.x * this->_v.x;
		y = this->_posCutMan.y / 100 + u.y * this->_v.x;
	}
	else
	{
		x = this->_posCutMan.x / 100 + u.x * this->_v.x * 4.5f;
		y = this->_posCutMan.y / 100 + u.y * this->_v.x * 4.5f; 
	}
		

	this->_position.x += ((x / 1000.0f * d) * this->_speed);
	this->_position.y += ((y / 1000.0f * d) * this->_speed);	


}

void CCutManBullet::Render(CGameTime* gameTime, CGraphics* graphics)
{
	if (this->_isHide)
	{
		if (this->_v.x > 0)
			graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true, SpriteEffects::FLIP_HORIZONTALLY);
		else
			graphics->Draw(this->_sprite.GetTexture(), this->_sprite.GetDestinationRectangle(), this->_position, true);
	}
	

	CGameObject::Render(gameTime, graphics);
}

void CCutManBullet::UpdateBox()
{
	this->_box._width = 14.0f;
	this->_box._height = 14.0f;
	this->_box._x = this->_position.x - _box._width / 2;
	this->_box._y = this->_position.y + _box._height / 2;
	this->_box._vx = this->_v.x;
	this->_box._vy = this->_v.y;
	
}

void CCutManBullet::OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime)
{
}

void CCutManBullet::setState()
{
	this->_state = BULLET_BASE_STATE::DIE; // làm cho  viên đạn sống lại
}