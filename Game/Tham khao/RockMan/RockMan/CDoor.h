//-----------------------------------------------------------------------------
// File: CBlock.h
//
// Desc: Định nghĩa lớp CBlock có tác dụng dựng tường giúp các đối tượng có thể đứng được
//
//-----------------------------------------------------------------------------
#ifndef _CDOOR_H_
#define _CDOOR_H_

#include "CGameObject.h"

enum DoorState
{
	WAITING,
	WAITING_FOR_THROUGH,
	OPENING,
	CLOSING
};

class CDoor :public CMoveableObject
{
public:
	CDoor(CSprite doorSprite);
	~CDoor();

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

	// Các hướng có thể di chuyển của cửa, tùy loại của mà có những hướng di chuyển nhất định
	bool CanGoUp();
	bool CanGoDown();
	bool CanGoLeft();
	bool CanGoRight();

	DoorState GetState();
	void OpenDoor();
	void CloseDoor();
private: 
	DoorState	_state;
	float		_tick;
};

#endif // !_CDOOR_H_
