#include "Sprite.h"



CSprite::CSprite(LPCSTR FilePath)
{
	D3DXIMAGE_INFO info;
	D3DXGetImageInfoFromFile(FilePath, &info);
	LPDIRECT3DDEVICE9 d3ddv;
	SpriteHandler->GetDevice(&d3ddv);

	D3DXCreateTextureFromFileEx(
		d3ddv,
		FilePath,
		info.Width,
		info.Height,
		1,
		D3DUSAGE_DYNAMIC,
		D3DFMT_UNKNOWN,
		D3DPOOL_DEFAULT,
		D3DX_DEFAULT,
		D3DX_DEFAULT,
		D3DCOLOR_XRGB(0, 63, 63),
		&info,
		NULL,
		&Texture);
}


void CSprite::Render(int x, int y, RECT rect)
{
	D3DXVECTOR3 position((float)x, (float)y, 0);
	D3DXMATRIX mt;
	D3DXMatrixIdentity(&mt);
	mt._22 = -1.0f;
	mt._41 = -ViewPort->_X;
	mt._42 = ViewPort->_Y;

	D3DXVECTOR4 vp_pos;
	D3DXVec3Transform(&vp_pos, &position, &mt);
	D3DXVECTOR3 p(vp_pos.x, vp_pos.y, 0);

	SpriteHandler->Begin(D3DXSPRITE_ALPHABLEND);
	SpriteHandler->Draw(
		Texture,
		&rect,
		NULL,
		&p,
		D3DCOLOR_XRGB(255, 255, 255)
		);
	SpriteHandler->End();
}
void CSprite::DrawItem(int x, int y, RECT rect)
{
	D3DXVECTOR3 position((float)x, (float)y, 0);

	SpriteHandler->Begin(D3DXSPRITE_ALPHABLEND);
	SpriteHandler->Draw(
		Texture,
		&rect,
		NULL,
		&position,
		D3DCOLOR_XRGB(255, 255, 255)
		);
	SpriteHandler->End();
}


CSprite::~CSprite()
{
}
