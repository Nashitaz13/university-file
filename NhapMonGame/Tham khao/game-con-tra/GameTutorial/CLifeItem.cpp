#include "CLifeItem.h"
#include "CCamera.h"
#include "CContra.h"

CLifeItem::CLifeItem(void)
{
	this->Init();
}

CLifeItem::~CLifeItem()
{

}

void CLifeItem::Init()
{
	//Khoi tao cac thong so cua doi tuong
	this->m_imageCurr = new CTexture();
	this->m_imageCurr->LoadImageFromFile(__Life_Item__, NULL);
	this->m_drawImg = new CSprite();
}

void CLifeItem::Draw()
{
	for (int i = 0; i < CContra::GetInstance()->m_countAlive; i++)
	{
		RECT rectRS;
		D3DXVECTOR3 posObj(20.0f + (i * 25), 10.0f, 0);

		rectRS.left = 0;
		rectRS.right = rectRS.left + 16;
		rectRS.top = 0;
		rectRS.bottom = rectRS.top + 32;

		this->m_drawImg->draw(this->m_imageCurr, &rectRS, posObj, D3DCOLOR_XRGB(255, 255, 225), false);
	}
}

D3DXVECTOR3 CLifeItem::GetPos()
{
	return this->m_pos;
}

void CLifeItem::SetPos(D3DXVECTOR3 pos)
{
	this->m_pos.x = pos.x;
	this->m_pos.y = pos.y;
	this->m_pos.z = pos.z;
}

void CLifeItem::SetAlive(bool isAlive)
{
	this->m_isAlive = isAlive;
}

void CLifeItem::Update(float deltaTime)
{
	D3DXVECTOR3 cameraPos = CCamera::GetInstance()->GetCameraPos();
	this->m_pos.x = cameraPos.x + 10;
	this->m_pos.y = cameraPos.y - 20;
	this->m_pos.z = 0;
}