#pragma once
#ifndef __CSPRITE_H__
#define __CSPRITE_H__

#include "CGlobal.h"
#include "Texture.h"
#include "Include.h"
class CSprite
{
public:
	CSprite();
	~CSprite();
	//ve texture tai vi tri mac dinh la chinh giua
	void draw(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DCOLOR transcolor = 0xFFFFFFFF, bool isCenter = true);

	//ve texture tai vi tri mac dinh la chinh giua voi scale
	void draw(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DXVECTOR2 scale, D3DCOLOR transcolor = 0xFFFFFFFF, bool isCenter = true);

	//ve texture tai vi tri mac dinh la chinh giua.
	//va lap theo chieu ngang
	void drawFlipX(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DCOLOR transcolor = 0xFFFFFFFF, bool isCenter = true);

	//ve texture tai vi tri mac dinh la chinh giua.
	//va lap theo chieu doc
	void drawFlipY(CTexture* image, RECT *RectRS, D3DXVECTOR3 pos, D3DCOLOR transcolor = 0xFFFFFFFF, bool isCenter = true);
};
#endif // !__CSPRITE_H__

