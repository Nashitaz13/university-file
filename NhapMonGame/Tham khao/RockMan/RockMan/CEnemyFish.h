//-----------------------------------------------------------------------------
// File: CEnemyFish.h
//
// Desc: Định nghĩa lớp CEnemyFish
//
//-----------------------------------------------------------------------------
#ifndef _CENEMY_FISH_H_
#define _CENEMY_FISH_H_

#include "CGameObject.h"
#include "CEnemy.h"
#include "ResourceManager.h"
#include "CEnemyFishBullet.h"
#include "CCameraPath.h"

enum StaticFish
{
	Fly, Efforts, Die
};
class CEnemyFish :public CEnemy
{

public: 
	CEnemyFish(int positionYStart,CCameraPath* cameraPath);
	~CEnemyFish();

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
	vector<CBullet*> Fire() override;
	StaticFish GetStaticFish();
	CEnemyFish* ToValue() override;
private: 
	int _positionYStart;// lấy giá trị y ban đầu 
	StaticFish _static;
	float _g;
	int _spacePositionYChange;// khoảng y để thay đổi chiều di chuyển
	//CEnemyFishBullet* _enemyFishBullet;
	vector<CBullet*> _lstBullet;
	//int timetest;
	CCameraPath* _cameraPath;

};

#endif // !_CENEMY_FISH_H_