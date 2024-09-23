//-----------------------------------------------------------------------------
// File: CBoomMan.h
//
// Desc: Định nghĩa lớp AI CCutMan dùng để tạo boss Boom Man
//
//-----------------------------------------------------------------------------
#ifndef _GUTS_MAN_H_
#define _GUTS_MAN_H_    

#include "CGameObject.h"
#include "CGameTime.h"
#include "CGraphics.h"
#include "ResourceManager.h"
#include "CEnemy.h"
#include "CRockman.h"
#include "CGutsManBullet.h"
#include <stdio.h>      
#include <stdlib.h>    
#include <time.h>
#include "Config.h"
#include "Asset.h"

class CGutsMan : public CEnemy
{
public:
	~CGutsMan();
	CGutsMan();

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
	//	+ boomMan	: đối tượng Guts Man
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime, CRockman* rockman) override; 
	//-----------------------------------------------------------------------------
	// 	Cập nhật khung bao bên ngoài của đối tượng
	//-----------------------------------------------------------------------------
	void UpdateBox() override;

	void OnCollideWith(CGameObject *gameObject, CDirection normalX, CDirection normalY, float deltaTime) override;
	//-----------------------------------------------------------------------------
	// Hành vi bán đạn của Guts Man
	//-----------------------------------------------------------------------------
	vector<CBullet*> Fire();

	void GetPositioRockMan(Vector2 pos);

	CGutsMan* ToValue() override;

	private:
	float _gravity; // gia tốc trọng trường.
	float _timeDelay;	// thời gian delay cut man đứng bắn
	float _dieDistance; // Khoảng cách giữa các hình hiệu ứng chết
	float _speed; // tốc độ của boss

	bool _isJump;  // trạng thái jump
	bool _isStartJump;
	bool _isLockRun; // dùng để khóa việc nhảy
	Vector2 _positionOld; 
	Vector2 _posRockMan;
	DIRECTIONACTION _previousDirec; // trạng thái trước đó
	DIRECTIONACTION _currentDirec; // trạng thái hiện tại

	float _timeHistoryCollideX; // thời gian ngắn nhất để tính quảng đường đi khi va chạm theo chieu ngang.
	float _timeHistoryCollideY; // thời gian ngắn nhất để tính quảng đường đi khi va chạm theo chieu doc.
	//Hướng xảy ra va chạm với vật gần nhất
	CDirection _collideNormalX, _collideNormalY;

	bool _isCollideBullet; // bật hiểu ứng trúng đạn
	float _timeHistoryCollideXBullet; // thời gian ngắn nhất để tính quảng đường đi đạn khi va chạm theo chieu ngang.
	float _timeHistoryCollideYBullet; // thời gian ngắn nhất để tính quảng đường đi đạn khi va chạm theo chieu doc.
	CDirection _collideNormalXBullet, _collideNormalYBullet; //Hướng xảy ra va chạm với đạn gần nhất
	CBullet* _bulletRockMan; // Lưu lại đạn va chạm vào cut man
	float _timeEffectCollide; // thời gian bật hiệu ứng va chạm đạn cho cut man

	CSprite _spEffectCollideBullet;

	CGutsManBullet* _bullet;
	bool _isFire; // trạng thái bắn và ko bắn của GutsMan
	bool _isSkillJump; // loại skill nhảy nếu = true là nhảy cong, false là nhảy thẳng đứng
	bool _isOneHit; //Mỗi viên đạn trúng vào boom man chỉ gây dame 1 lần.

	//-----------------------------------------------------------------------------
	// Kiểm tra các trạng thái Guts Man
	// gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	void CheckStatus(CGameTime* gameTime);

	//-----------------------------------------------------------------------------
	// Xử lý nhảy của Guts Man
	//-----------------------------------------------------------------------------
	void JumpAI();

};

#endif// _GUTS_MAN_H_