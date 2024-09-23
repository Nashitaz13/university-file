//-----------------------------------------------------------------------------
// File: CEnemyEye.h
//
// Desc: Định nghĩa lớp CEnemyEye
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_EYE_H_
#define _CENEMY_EYE_H_

#include "DSUtil.h"
#include "CGameObject.h"
#include "CEnemy.h"
#include "Config.h"
#include "ResourceManager.h"

class CEnemyEye :public CEnemy
{
public:
	enum Status
	{
		Stand, Run
	};
	//-----------------------------------------------------------------------------
	// 	Khởi tạo đối tượng 
	//	
	//	0 là di chuyển ngang 1 là di chuyển dọc 
	//-----------------------------------------------------------------------------
	CEnemyEye(int kindEye);
	~CEnemyEye();
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

	//-----------------------------------------------------------------------------
	// xét va chạm 
	//-----------------------------------------------------------------------------
	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	
	void Slide();

   CEnemyEye::Status GetStatus();
   CEnemyEye* ToValue() override;
	
private: 
	
	int _kindEye; //Loai mắt chạy dọc hay ngang 0 là ngang 1 là doc 
	Vector2 _positionRockMan; //tọa độ rockman 
	int _timeStand;// thời gian giản cách giữa các lần nhảy
	int _timeStandSet;// đây là thời gian dừng cố định
	int _testminx, _testmaxx, _testminy, _testmaxy;
	Status _status;
	float _timeCollide;
	CDirection _normalHistory;
	float _vEyeDefault;
};

#endif // !_CENEMY_EYE_H_