//-----------------------------------------------------------------------------
// File: CControl.h
//
// Desc: Định nghĩa lớp CControl, lớp này là lớp cha của tất cả các control Game
//
//-----------------------------------------------------------------------------
#ifndef _CCONTROL_H_
#define _CCONTROL_H_

#include "CGlobal.h"
#include "CObject.h"
#include "CInput.h"
#include "CCamera.h"

class CControl :public CObject
{
public:
	CControl();
	~CControl();

	//-----------------------------------------------------------------------------
	// 	Khởi tạo tất cả các thành phần của 1 đối tượng với các giá trí đã có
	//	
	//	Trả về 0 nếu lối hoặc 1 nếu thành công
	//-----------------------------------------------------------------------------
	virtual	int Initlize() override;

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	virtual void Render(CGameTime* gameTime, CGraphics* graphics) override;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	virtual void Update(CGameTime* gameTime) override;
};

#endif