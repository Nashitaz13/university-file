//-----------------------------------------------------------------------------
// File: CImage.h
//
// Desc: Định nghĩa lớp CImage, lớp này giúp hiển thị một bức ảnh lên màn hình
//
//-----------------------------------------------------------------------------
#ifndef _CIMAGE_H_
#define _CIMAGE_H_

#include "CControl.h"
#include "CGlobal.h"
#include "CGraphics.h"
#include "CTexture.h"

class CImage :public CControl
{
public:
	CImage();
	~CImage();

	//-----------------------------------------------------------------------------
	// 	Khởi tạo tất cả các thành phần của 1 đối tượng với các giá trí đã có
	//	
	//	Trả về 0 nếu lối hoặc 1 nếu thành công
	//-----------------------------------------------------------------------------
	int Initlize() override;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime) override;

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	//-----------------------------------------------------------------------------
	// source của bức ảnh
	//-----------------------------------------------------------------------------
	wchar_t* _source;	

	Color _transparentColor;

private:
	Rect _boundingRect;  // Khung hình chữ nhật bao background
	CTexture* _texture;
};

#endif //!_CIMAGE_H_