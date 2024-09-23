//-----------------------------------------------------------------------------
// File: CEnemyInk.h
//
// Desc: Định nghĩa lớp CEnemyInk
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_INK_H_
#define _CENEMY_INK_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "Config.h"
#include "CRockMan.h"
#include <iostream>
#include <string.h>
using namespace std;
class CEnemyInk :public CEnemy
{
public:

	CEnemyInk(int kindInk);
	~CEnemyInk();
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
	// Lấy box, nhằm xét va chạm đối tượng, tương ứng với từng sprite ID
	//-----------------------------------------------------------------------------
	void UpdateBox() override;
	void Update(CGameTime* gameTime, CRockman* rockman) override;
	
	void Jump(Vector2 positionRockman);
	void TestJump();
	void AnalyseParabol(Vector2 point1, Vector2 point2, Vector2 point3);
	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	CEnemyInk* ToValue() override;
	
private:
	int _kindInk;
	int _timeJump; // thời gian mực sẽ bắt đầu reset lại khoảng nhảy, tức thời gian mực nhảy tới rockman 
	
	int _heightInk; // chiều cao mực sẽ nhảy cao so với rockman
	Vector2 _positionRockMan; //tọa độ rockman 
	int _between;              // điểm giữa
	int _timeStand; // thời gian kiểm tra để có thực hiện việc nhảy không (<=0 sẽ thự hiện nhảy)
	float _deltaV;
	int _timeStandDefault;// thời gian nó sẽ nghỉ thật sự 

	Vector2 _PositionRockMan;
	
	
	
	float _V0;
	float _g;
	float _lenghtMax;
	float _anpha;
	float _timeaddspeed;
	float _vFall;

	float _testpositiony;
	enum StaticEnemyInk
	{
		JUMP,
		STAND, 
		FALL
	};
	StaticEnemyInk _static;
	int _testbug;
	CDirection _historyCollide;
	float _timeHistoryCollide;
};

#endif // !_CENEMY_INK_H_