//-----------------------------------------------------------------------------
// File: CMenuItem.h
//
// Desc: Định nghĩa lớp CMenuItem, lớp này dùng để giúp người chơi chọn màn
//
//-----------------------------------------------------------------------------
#ifndef _CMENU_ITEM_H_
#define _CMENU_ITEM_H_

#include "CControl.h"
#include "CGlobal.h"
#include "CGraphics.h"
#include "CSprite.h"
#include "CTexture.h"
#include "CInput.h"

class CMenuItem :public CControl
{
public:
	CMenuItem();
	~CMenuItem();

	//-----------------------------------------------------------------------------
	// 	Khởi tạo tất cả các thành phần của 1 đối tượng với các giá trí đã có
	//	
	//	Trả về 0 nếu lối hoặc 1 nếu thành công
	//-----------------------------------------------------------------------------
	int Initlize() override;

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime) override;

	//-----------------------------------------------------------------------------
	// 	Lấy ra màu hiển thị của chữ, vì khi kích hoạt animation thì màu chữ sẽ đổi
	//-----------------------------------------------------------------------------
	Color GetAnimationColor();

	//-----------------------------------------------------------------------------
	// Tên của MenuItem, nó sẽ hiển thị ngay bên dưới border 
	//-----------------------------------------------------------------------------
	string	_name;

	//-----------------------------------------------------------------------------
	// Background nền của lable
	//-----------------------------------------------------------------------------
	CTexture* _background;

	//-----------------------------------------------------------------------------
	// Border của MenuItem
	//-----------------------------------------------------------------------------
	CSprite * _border;

	//-----------------------------------------------------------------------------
	// Màu chữ
	//-----------------------------------------------------------------------------
	Color _foreground;

	//-----------------------------------------------------------------------------
	// Chỉ định MenuItem có được focus hay không
	//-----------------------------------------------------------------------------
	bool _isFocused;

private:
	Vector2 _borderPosition;
	Vector2 _positionText;
	Rect    _boundingRectBkg;
	Color _replaceColor;	// Biến hỗ trợ chạy hiệu ứng chữ
	float _timeAnimationText;//Thời gian vẽ của 1 màu của Text
};

#endif //!_CMENU_ITEM_H_