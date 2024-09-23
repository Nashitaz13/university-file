//-----------------------------------------------------------------------------
// File: CDieArrow.h
//
// Desc: Định nghĩa lớp CRock có tác dụng dựng tường giúp các đối tượng có thể đứng được
//
//-----------------------------------------------------------------------------
#ifndef _CDIE_ARROW_H_
#define _CDIE_ARROW_H_

#include "CGameObject.h"

class CDieArrow :public CStaticObject
{
public:
	CDieArrow();
	~CDieArrow();

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

	void UpdateBox() override;
};

#endif // !_CDIE_ARROW_H_

