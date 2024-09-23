
#include "GameObject.h"
#include <d3d9.h>

GameObject::GameObject(void)
{
	posX = 0;
	posY = 0;
	width = 0;
	height = 0;
	canMove = false;
}

void GameObject::SetActive(float x, float y){}
void GameObject::SetActive()
{
	if(!active)
		active = true;
}

GameObject::GameObject(float _posX, float _posY, EnumID _id)
{
	posX = _posX;
	posY = _posY;
	vX = 0;
	vY = 0;
	id = _id;
	hearts = 0;
	hp = 1;
	damage = 1;
	point = 0;
	type = ObjectType::None_Type;
	canMove = false;
	active = true;
	death = false;
	CreateSprite();
	if(sprite != NULL)
	{
		width = sprite->_texture->FrameWidth;
		height = sprite->_texture->FrameHeight;
	}
}

void GameObject::CreateSprite()
{
	switch(id)
	{
	case EnumID::Simon_ID:		
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 0, 3, 100);
		break;
	case EnumID::Brick_ID:
	case EnumID::StairUpRight_ID: 
	case EnumID::StairUpLeft_ID: 
	case EnumID::StairDownLeft_ID: 
	case EnumID::StairDownRight_ID:
	case EnumID::CastleGate_ID:
	case EnumID::DoorDown_ID:
	case EnumID::DoorLeft_ID:
	case EnumID::DoorRight_ID:
	case EnumID::DoorUp_ID:
	case EnumID::Lake_ID:
		sprite = NULL;
		break;
	case EnumID::VampireBat_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 0, 3, 100);
		break;
	case EnumID::BlackLeopard_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 0, 0, 1000);
		break;
	case EnumID::FireBomb_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 50);
		break;
	case EnumID::FishMan_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 150);
		break;
	case EnumID::Boomerang_ID:
	case EnumID::Axe_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 10);
		break;
	case EnumID::OpenDoor_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id),0 , 0, 10);
		break;
	case EnumID::IntroScene_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 10);
		break;
	case EnumID::Helicopter_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 10);
		break;
	case EnumID::Bat_ID:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 0, 1, 50);
		break;
	default:
		sprite = new CSprite(Singleton::getInstance()->getTexture(id), 100);
		break;
	}
}

void GameObject::Collision(list<GameObject*> obj, int dt)
{
}

void GameObject::Update(int deltaTime)
{
	if(sprite != NULL)
		sprite->Update(deltaTime);
}

void GameObject::Draw(CCamera* camera)
{
	if(sprite != NULL)
	{
		D3DXVECTOR2 center = camera->Transform(posX, posY);
		sprite->Draw(center.x, center.y);
	}
}

ECollisionDirect GameObject::GetCollisionDirect(float normalx, float normaly)
{
	if(normalx == 0 && normaly == 1)
	{
		return ECollisionDirect::Colls_Bot;
	}
	if(normalx == 0 && normaly == -1)
	{
		return ECollisionDirect::Colls_Top;
	}
	if(normalx == 1 && normaly == 0)
	{
		return ECollisionDirect::Colls_Left;
	}
	if(normalx == -1 && normaly == 0)
	{
		return ECollisionDirect::Colls_Right;
	}
	return ECollisionDirect::Colls_None;
}

void GameObject::Remove()
{
	active = false;
	death = true;
}

void GameObject::ReceiveDamage (int damagePoint)
{
	if(hp <= 0)
		return;
	hp -= damagePoint;
	if(hp == 0)
		death = true;
}

Box GameObject::GetBox()
{
	Box result(posX - width/2 , posY + height/2, width , height);
	return result;
}

void GameObject::ProcessInput(LPDIRECT3DDEVICE9 d3ddv, int t) {}
void GameObject::OnKeyDown(int KeyCode) {}
GameObject::~GameObject(void){}