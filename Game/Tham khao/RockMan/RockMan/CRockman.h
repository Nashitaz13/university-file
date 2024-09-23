//-----------------------------------------------------------------------------
// File: CRockman.h
//
// Desc: Định nghĩa lớp CRockman có các dạng như Score, Mana, Power
//
//-----------------------------------------------------------------------------
#ifndef _CROCK_MAN_H_
#define _CROCK_MAN_H_

#include <math.h>

#include "CRock.h"
#include "CBullet.h"
#include "CDoor.h"
#include "CItem.h"
#include "CExplodingEffectManager.h"
#include "CExplodingEffectX.h"
#include "CBulletRockman.h"
#include "CCutManBullet.h"
#include "CGutsManBullet.h"
#include "CBoomManBullet.h"
#include "CGameObject.h"
#include "CInput.h"
#include "CGameTime.h"
#include "CGraphics.h"
#include "ResourceManager.h"
#include "CEnemy.h"
#include "CollisionInfo.h"
#include "CSprite.h"
#include "CGameInfo.h"
#include "SkillInfo.h"
#include <iostream>
#include <algorithm>
#include "Asset.h"
#include "CRockCutBullet.h"
#include "CGutsRockManBullet.h"
#include "CBoomRockManBullet.h"

using namespace std;

enum Behave
{
	START,
	STAND_FIRE,
	STAND,
	STAIR,
	STAIR_BEGIN_END,
	STAIR_FIRE,
	RUN,
	PREPARE_RUN,
	RUN_FIRE,
	JUMP,
	JUMP_FIRE,
	FALL,
	FALL_FIRE,
	REAL_DIE,
	DYING,
	HURT_ON_GROUND,
	HURT_IN_AIR
};

#define ROCKMAN_VERLOCITY_X		85.0f/1000.0f
#define ROCKMAN_VERLOCITY_Y		355.0f/1000.0f
#define ROCKMAN_ACCELERATE_X	0.00075f/1000.0f
#define ROCKMAN_ACCELERATE_Y	1.09f/1000.0f

class CPlayScreen;

class CRockman :public CMoveableObject
{
public:
	CRockman();
	~CRockman();
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
	// Cần kiểm tra va chạm với các đối tượng trước khi gọi hàm này, vì hàm này sẽ
	// dựa trên trạng thái khi đã va chạm với các đối tượng mà có những cập nhật riêng
	// vị trí cho rockman
	//	
	//	+ gameTime	: Thời gian cập nhật hệ thống
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime) override;

	void OnCollideWith(CGameObject* obj, CDirection normalX, CDirection normalY, float collideTime) override;

	//-----------------------------------------------------------------------------
	// Lấy box, nhằm xét va chạm đối tượng, tương ứng với từng sprite ID
	//-----------------------------------------------------------------------------
	void UpdateBox() override;

	//-----------------------------------------------------------------------------
	// Kiểm tra nếu Rockman chết thực sự hay không, vì khi rockman chết còn có 1 
	// khoảng thời gian chạy animation.
	//-----------------------------------------------------------------------------
	bool IsDied() override;

	bool IsInBossRoom();

	map<Skill, int> GetSkillInfo();
	
	int GetWeapons(Skill skill);

	void SetWeapons(Skill skill, int weapons);

	int GetLife();

	Skill GetCurrentSkill();

	vector<CBullet*> GetBullets();
	//-----------------------------------------------------------------------------
	// Tấn công Rockman bởi đạn hoặc enemy, tỉ lệ sát thương do enemy quy định
	//-----------------------------------------------------------------------------
	void Attack(int dame, bool isRealKill = false);

	void ThroughOverDoor(int doorID);

	bool IsOverDoor();

	bool IsGoingOverDoor();

	bool IsRequireOpenDoor();

	bool IsRequireStopScreen();

	void ChangeScreen(CDirection direction);

	void ReSetSKill();
	void ResetAll();
	void Return();					// Sau khi giết boss thì quay trở về Home;
	bool IsEndGame();

	friend class CPlayScreen;
	friend class CRockCutBullet;
	friend class CGutsRockmanBullet;
	friend class CBoomRockManBullet;

	bool	_canFire;						// Kiểm tra có hể bắn đạn hay không
private:
	//-----------------------------------------------------------------------------
	// Hành vi bán đạn của Rockman
	//-----------------------------------------------------------------------------
	void Fire();
	//-----------------------------------------------------------------------------
	// Cập nhật sprite ảnh động của Rockman
	//-----------------------------------------------------------------------------
	void UpdateAnimation();
	//-----------------------------------------------------------------------------
	// Cập nhật Input
	//-----------------------------------------------------------------------------
	void UpdateInput();
	//-----------------------------------------------------------------------------
	// Kỹ năng hiện tại của rockman
	//-----------------------------------------------------------------------------
	Skill	_currentSkill;
	//-----------------------------------------------------------------------------
	// Số lượng weapons của từng SKill
	//-----------------------------------------------------------------------------
	map<Skill, int> _skillInfos;
	//-----------------------------------------------------------------------------
	// Hành vi của Rockman, hành vi xuất hiện khi người chơi nhấn phím hoặc chịu sự 
	// tác động. Do vậy giá trị cuối cùng sau khi gọi hàm Update là hành vi cuối cùng 
	// đã qua xử lý
	//-----------------------------------------------------------------------------
	Behave _behave;

	int	_deltaTime, _timeDie, _timeHurted, _deltaTimeCanFire, _deltaTimeInShield, _deltaTimeJump;	// Biến đếm thời gian dự phòng, dùng cho việc đếm các khoảng thời gian như thời gian chết của Rockman
	int	_jumpTime;							// Biến đếm thời gian hỗ trợ đảm bảo thời gian nhảy giữa hai lần là ngắn nhất
	int	_timeOverDoor;						// Thời gian qua cửa

	Vector2 _actionPosition;					// Ví trí bắt đầu nhảy, nhằm đảm bảo Rockman không nhảy vượt quá 1 khoảng chiều cao nhất định nào đó

	CInput* _input;

	int		_life;							// Số mạng sống còn lại của Rockman
	
	bool	_canJump, _canJumpMore;			// Xác định Rockman có thể nhảy hay không

	bool	_isRight;						// Giá trị hướng quay mặt của rockman
	bool	_isUndying;						// Chỉ định có bật chế độ bất tử hay không
	bool	_isChangingState;				// Có đang chuyển trạng thái hay không
	bool	_isOverDoor;					// Đã qua cửa hay chưa
	bool	_isRequireOverDoor;				// Có đang yêu cầu qua cửa hay không
	bool	_isRequireStopScreen;
	bool	_isInBossRoom;
	bool	_isRequireEndGame;
	
	bool	_isGoingOverDoor;				// Kiểm tra rockman có đang đi qua cửa hay không
	
	bool	_isInShield;					// Khi Rockman va chạm v\ới quái, rockman bị thương biến được bật để đảm bảo rockman không bị thương trong một khoảng thơi gian nhất định

	bool	_isTheFirstTime;				// Kiểm tra rockman xuất phát điểm ban đầu. Biến này trừ trường hợp màn hình nhấn pause hay enter
	bool	_hasRockOnHead, _isThrowRock;					// Kiểm tra xem có gạch trên đầu hay chưa

	// Danh sách các đối tượng xét va chạm sớm nhất, dùng cho các đối tượng không phải tường gạch
	CollisionInfo*		_collidedObjectInside;


	// Danh sách các đối tượng xét va chạm sớm nhất, dùng cho các đối tượng không phải tường gạch
	CollisionInfo*		_collidedObjectGroundLeft;
	CollisionInfo*		_collidedObjectGroundRight;
	CollisionInfo*		_collidedObjectGroundUp;
	CollisionInfo*		_collidedObjectGroundDown;
	CollisionInfo*		_collidedObjectGroundInside;

	vector<CBullet*>	_bullets;
	vector<CSprite>		_confuses;

	CDirection			_changeScreenDirection;
};

#endif // !_CROCK_MAN_H_