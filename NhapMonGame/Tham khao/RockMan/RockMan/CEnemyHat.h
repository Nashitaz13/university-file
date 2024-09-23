//-----------------------------------------------------------------------------
// File: CEnemyHat.h
//
// Desc: Định nghĩa lớp CEnemyHat
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_HAT_H_
#define _CENEMY_HAT_H_

#include "CGameObject.h"
#include "CGraphics.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "CRockman.h"
#include "CEnemyMachineAutoBullet.h"

using namespace std;

enum StaTusEnemyHat{
	Fire, Stand
};
class CEnemyHat :public CEnemy
{
	
public: 

	CEnemyHat();
	~CEnemyHat();
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
	vector<CBullet*> Fire() override;

	void UpdateBox() override;
	CEnemyHat* ToValue() override;
private:
	// hàm bắn đạn 
	void FireRockMan(float deltatime);
	
	// thời gian giản cách giữa hai lần bắn 
	int _timeDistant;
	int _timeChangeFrame;

	int TIMEDISTANTDEFAULT ;
	int TIMECHANGEFRAME ;
	
	// khoảng cách rockman với enemy để enemy thực hiện bắn 
	int _spaceFire;
	
	// Danh sách đạn bắn ra
	vector<CBullet*> _lstBullet;
	
	// trạng thái của nón 
	StaTusEnemyHat _statusEnemyHat;
	//STATUS_HAT _statusHat;

	boolean _isChangeDirection;

};

#endif // !_CENEMY_HAT_H_