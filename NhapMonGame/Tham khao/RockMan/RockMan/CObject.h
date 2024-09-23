//-----------------------------------------------------------------------------
// File: CObject.h
//
// Desc: Định nghĩa lớp CObject, đây là lớp căn bản cho tất cả các đối tượng
//		 trong game
//
//-----------------------------------------------------------------------------
#ifndef _COBJECT_H_
#define _COBJECT_H_

#include <string.h>
#include <iostream>
#include "CCollision.h"
#include "DSUtil.h"
#include "CGlobal.h"
#include "CGameTime.h"
#include "CGraphics.h"
#include "CCamera.h"
#include "CTexture.h"

using namespace std;

class CObject
{
public:
	CObject();
	virtual ~CObject();
	
	//-----------------------------------------------------------------------------
	// 	Khởi tạo tất cả các thành phần của 1 đối tượng với các giá trí đã có
	//	
	//	Trả về 0 nếu lối hoặc 1 nếu thành công
	//-----------------------------------------------------------------------------
	virtual int Initlize() = 0;

	//-----------------------------------------------------------------------------
	// 	Vẽ tất cả các thành phần của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ graphics	: cọ vẽ đối tượng
	//-----------------------------------------------------------------------------
	virtual void Render(CGameTime* gameTime, CGraphics* graphics) = 0;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	virtual void Update(CGameTime* gameTime) = 0;
	
	//-----------------------------------------------------------------------------
	// Lấy box, nhằm xét va chạm đối tượng
	//-----------------------------------------------------------------------------
	virtual void UpdateBox();

	//-----------------------------------------------------------------------------
	// Lấy khung hình chữ nhật bao đối tượng
	//-----------------------------------------------------------------------------
	Rect GetBoundingRectangle();

	//Lấy vị trí của đối tượng tính tại tâm
	Vector2 GetPositionCenter();

	CBox GetBox();

	Vector2 _position;	// Vị trí vẽ đối tượng
	
	Vector2	_origin;	// Vị trí tâm vẽ đối tượng

	Vector2	_size;		// Kích thước đối tượng

protected:
	CBox _box;
};

#endif //_COBJECT_H_