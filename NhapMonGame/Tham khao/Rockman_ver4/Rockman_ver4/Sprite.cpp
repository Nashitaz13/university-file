#include "Sprite.h"
#include "Device.h"

CSprite::CSprite()
{
}


CSprite::~CSprite()
{
}

void CSprite::draw(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DCOLOR transcolor, bool isCenter)
{
	if (isCenter)
	{
		D3DXVECTOR3* center = NULL;
		if (RectRS == NULL)
		{
			center = NULL;
		}
		else
		{
			center = new D3DXVECTOR3(
				(RectRS->right - RectRS->left) / 2.0f,
				(RectRS->bottom - RectRS->top) / 2.0f,
				0);
		}
		CDevice::s_spriteHandle->Draw(image->GetTexture(), RectRS, center, &pos, transcolor);
		delete center;
	}
	else {

		CDevice::s_spriteHandle->Draw(image->GetTexture(), RectRS, NULL, &pos, transcolor);
	}


}

void CSprite::draw(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DXVECTOR2 scale, D3DCOLOR transcolor /* = 0xFFFFFFFF */, bool isCenter /* = true */)
{
	HRESULT result;

	//Lay ma tran transform hien tai
	D3DXMATRIX currMatrix;

	//tim ra vi tri moi trong he toa do sau khi scale
	D3DXVECTOR3 newPos = D3DXVECTOR3(pos.x / scale.x, pos.y / scale.y, pos.z);

	result = CDevice::s_spriteHandle->GetTransform(&currMatrix);
	if (result != D3D_OK)
	{
		return;
	}

	// Tạo ma trận transform mới
	D3DXMATRIX newMatrix;

	D3DXMatrixIdentity(&newMatrix);
	newMatrix._11 = scale.x;
	newMatrix._22 = scale.y;

	//ap dung ma tran transform moi de ve
	result = CDevice::s_spriteHandle->SetTransform(&newMatrix);
	if (result != D3D_OK)
	{
		return;
	}

	//doi nguoc truc z lai
	//newPos.z = -newPos.z;

	this->draw(image, RectRS, newPos, transcolor, isCenter);

	result = CDevice::s_spriteHandle->SetTransform(&currMatrix);
	if (result != D3D_OK)
	{
		return;
	}
}

//ve texture theo lat ngang
void CSprite::drawFlipX(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DCOLOR transcolor, bool isCenter)
{
	D3DXVECTOR2 scaling = D3DXVECTOR2(-1, 1);
	this->draw(image, RectRS, pos, scaling, transcolor, isCenter);
}

//ve texture theo lap doc
void CSprite::drawFlipY(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DCOLOR transcolor, bool isCenter)
{
	D3DXVECTOR2 scaling = D3DXVECTOR2(1, -1);
	this->draw(image, RectRS, pos, scaling, transcolor, isCenter);
}
