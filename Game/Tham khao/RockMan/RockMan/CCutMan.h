//-----------------------------------------------------------------------------
// File: CCutMan.h
//
// Desc: Định nghĩa lớp AI CCutMan dùng để tạo boss Cut Man
//
//-----------------------------------------------------------------------------

#ifndef _CCUT_MAN_H_
#define _CCUT_MAN_H_                         

#include "CGameObject.h"
#include "CGameTime.h"                                    
#include "CGraphics.h"
#include "ResourceManager.h"
#include "CEnemy.h"
#include "CRockman.h"
#include "CCutManBullet.h"
#include <stdio.h>      
#include <stdlib.h>    
#include <time.h> 
#include "Config.h"

#define RANK_CUTMAN 50 // Khoảng cách giữa CUTMAN và ROCK MAN 
#define JUMP_HEIGHT  230.0f // độ cao để nhảy của cutman

class CCutman : public CEnemy
{
public:
	~CCutman();
	CCutman();

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
	void Render(CGameTime* gametime, CGraphics* graphics) override;

	//-----------------------------------------------------------------------------
	// 	Cập nhật tất cả các logic của 1 đối tượng
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//	+ rockman	: đối tượng rock main
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime, CRockman* rockman) override; 
	//-----------------------------------------------------------------------------
	// 	Cập nhật khung bao bên ngoài của đối tượng
	//-----------------------------------------------------------------------------
	void UpdateBox() override;

	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;

	//-----------------------------------------------------------------------------
	// Hành vi bán đạn của Cut Man
	//-----------------------------------------------------------------------------
	vector<CBullet*> Fire();

	void GetPositioRockMan(Vector2 pos);

	CCutman* ToValue() override;
private:
	string checkCon;
	float _dieDistance; // Khoảng cách giữa các hình hiệu ứng chết
	float _speed; // tốc độ của game.
	float _gravity; // gia tốc trọng trường.
	float _timeDelay;	// thời gian delay cut man đứng bắn
	float _timeStart; // Thời gian Start con boss cut
	float _timeHistoryCollideX; // thời gian ngắn nhất để tính quảng đường đi khi va chạm theo chieu ngang.
	float _timeHistoryCollideY; // thời gian ngắn nhất để tính quảng đường đi khi va chạm theo chieu doc.
	//Hướng xảy ra va chạm với vật gần nhất
	CDirection _collideNormalX, _collideNormalY;

	
	//CDirection _preHistoryCollide; // mô tả hướng lúc trước để xử lý va chạm.
	Vector2 _positionOld; 
	Vector2 _posRockMan;
	DIRECTIONACTION _previousDirec; // trạng thái trước đó
	DIRECTIONACTION _currentDirec; // trạng thái hiện tại
 	

	bool _isFire; // trạng thái bắn và ko bắn của CutMan
	bool _isWaepon; //Kiểm tra xem Cut Man còn kéo hay không. _isWaepon = true là vẫn còn or ngược lại
	bool _isRandom; //Tạo Ai cho Cut man
	bool _isFixPosition;// dùng để fix lại vị trí của hình boss
	bool _isRun;// dùng để cho phep run 
	bool _isStartJump;
	bool _isLockRun; // dùng để khóa việc nhảy
	bool _isOneHit; //Mỗi viên đạn trúng vào boom man chỉ gây dame 1 lần.

	bool _isCollideBullet; // bật hiểu ứng trúng đạn
	float _timeHistoryCollideXBullet; // thời gian ngắn nhất để tính quảng đường đi đạn khi va chạm theo chieu ngang.
	float _timeHistoryCollideYBullet; // thời gian ngắn nhất để tính quảng đường đi đạn khi va chạm theo chieu doc.
	CDirection _collideNormalXBullet, _collideNormalYBullet; //Hướng xảy ra va chạm với đạn gần nhất
	CCutManBullet* _bullet; // Lưu lại một viên đạn va chạm với cut man
	CBullet* _bulletRockMan; // Lưu lại đạn va chạm vào cut man
	float _timeEffectCollide; // thời gian bật hiệu ứng va chạm đạn cho cut man

	CSprite _spEffectCollideBullet;
	//-----------------------------------------------------------------------------
	// Kiểm tra các trạng thái Cut Man
	//+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	void CheckStatus(CGameTime* gameTime);

	//-----------------------------------------------------------------------------
	// Xử lý chạy của cut man
	//-----------------------------------------------------------------------------
	void RunAI();

	//-----------------------------------------------------------------------------
	// Xử lý nhảy của cut man
	//-----------------------------------------------------------------------------
	void JumpAI();
};
#endif// _CUT_MAN_H_