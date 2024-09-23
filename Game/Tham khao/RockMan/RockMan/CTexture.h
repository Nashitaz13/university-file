#ifndef _CTEXTURE_H_
#define _CTEXTURE_H_
#include <d3dx9.h>
#include "CGlobal.h"
#include "CCamera.h"
#include "CGraphics.h"
#include "Trace.h"
class CTexture
{
protected:
	Texture _texture;// texture chính của hàm 
	int _height;// chiều cao của bức ảnh
	int _width;// chiều rộng của bức ảnh
	wchar_t* _pNamePath;// tên đường dẫn file
	void LoadImageFromFile(wchar_t* pNamePath, Color color);//load texture 
public:
	
	CTexture();
	CTexture(wchar_t* pNamePath, Color color);
	~CTexture();
	Texture GetTexture();
	int GetHeight();
	int GetWidth();
};
#endif