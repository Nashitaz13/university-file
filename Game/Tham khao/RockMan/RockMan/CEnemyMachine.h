//-----------------------------------------------------------------------------
// File: CEnemyMachine.h
//
// Desc: Định nghĩa lớp CEnemyMachine
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_MACHINE_H_
#define _CENEMY_MACHINE_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "CRockman.h"

enum STATICMACHINE
{
	StandMachine,RunSlowMachine,RunFastMachine
};
enum TIMEFRAME
{
	TimeStand = 0 , TimeSlow = 200, TimeFast = 150
};
class CEnemyMachine :public CEnemy
{

public:
	CEnemyMachine();
	~CEnemyMachine();

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
	// Update đối tượng có liên quang đến rockman, những enemy khi hoạt động cần logic của rockman
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime, CRockman* rockman) override;
	//-----------------------------------------------------------------------------
	// Lấy ra va chạm của đối tượng 
	//-----------------------------------------------------------------------------
	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	//-----------------------------------------------------------------------------
	// hàm xử lý bắn đạn  
	//-----------------------------------------------------------------------------
	void UpdateBox() override;
	CEnemyMachine* ToValue() override;
	
private:
	STATICMACHINE _static;
	int _timeFrame;
	int _timeStand;
	int _timeStandDefault;


};

#endif // !_CENEMY_FISH_H_