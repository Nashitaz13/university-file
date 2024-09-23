#include "CTexture.h"

CTexture::CTexture()
{

}

CTexture::CTexture(wchar_t* pNamePath, Color color)
{
	this->_pNamePath = pNamePath;
	LoadImageFromFile(_pNamePath, color);
}
CTexture::~CTexture()
{

}
void CTexture::LoadImageFromFile(wchar_t* pNamePath, Color color)
{
	HRESULT result;
	ImageInfo info;

	// Lấy thông tin từ file ảnh
	result = D3DXGetImageInfoFromFile(pNamePath, &info);
	if (result != D3D_OK)
	{
		// hiển thị một thông báo lỗi 
		Trace(L"RROR] Failed to get info from inage file!!! File path: %s. Error code: %d", pNamePath, result);
		return;
	}

	_width = info.Width;
	_height = info.Height;

	// Lấy thiết bị 
	Device pd3ddev = CGraphics::GetInstance()->GetDevice();
	if (pd3ddev)
		result = D3DXCreateTextureFromFileEx( // Tạo texture từ file ảnh
		pd3ddev,
		pNamePath,
		info.Width,
		info.Height,
		1,
		D3DPOOL_DEFAULT,
		D3DFMT_A8R8G8B8,
		D3DPOOL_DEFAULT,// bộ nhớ chổ nào còn thì lưu texture tại đó
		D3DX_DEFAULT,
		D3DX_DEFAULT,
		color,
		&info,
		NULL,
		&_texture);
	if (result != D3D_OK)
	{
		Trace(L"[ERROR] Failed to create texture from file!!! File path: %s. Error code: %d.", pNamePath, result);
		return;
	}
}
Texture CTexture::GetTexture()
{

	return _texture;
}
int CTexture::GetHeight()
{
	return _height;
}
int CTexture::GetWidth()
{
	return _width;
}