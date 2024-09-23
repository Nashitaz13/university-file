//-----------------------------------------------------------------------------
// File: CEnemyNinja.h
//
// Desc: Định nghĩa lớp CEnemyNinja
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_NINJA_H_
#define _CENEMY_NINJA_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "CRockman.h"
#include "CBulletNinja.h"
enum  STATICNINJA
{
	NINJASTAND,NINJAJUMP,NINJAFALL,NINJAFIRE
};
enum TYPEJUMP
{
	NINJAJUMPSTAND,NINJAJUMPTOROCKMAN
};
class CEnemyNinja :public CEnemy
{
public: 
	CEnemyNinja();
	~CEnemyNinja();
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
	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	CEnemyNinja* ToValue() override;
	vector<CBullet*> Fire() override;
private:
	vector<CBullet*> _lstBullet;
	void Jump(Vector2 positionRockman,TYPEJUMP typeJump); 

	STATICNINJA _static;
	STATICNINJA _historyStatic;
	float _g;
	int _lMaxDefault, _hMaxDefault;
	float _timeHistoryCollide;
	CDirection _historyCollide;
	boolean _fistJump;
	int _timetest;
	int _timetestdefault;
	int _timeFire;
	int _timeFireDefault;
	int _timeProtect;// thời gian ninja chờ để bắn, nếu rockman bắn trúng ninja sẽ tiếp tục trạng thái phòng thủ và reset time nay
	int _timeProtectDefault;
	TYPEJUMP _typeJump;
	float _positionXRockMan;

};

#endif // !_CENEMY_NINJA_H_