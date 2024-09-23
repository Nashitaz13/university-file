//-----------------------------------------------------------------------------
// File: CRock.h
//
// Desc: Định nghĩa lớp CRock có tác dụng dựng tường giúp các đối tượng có thể đứng được
//
//-----------------------------------------------------------------------------
#ifndef _CROCK_H_
#define _CROCK_H_

#include "CGameObject.h"

class CRock :public CStaticObject
{
public:
	CRock();
	~CRock();

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

	bool IsGot();
	void GotIt();
	void Reset();
private:
	bool _isGot;
};

#endif // !_CROCK_H_

