//-----------------------------------------------------------------------------"
// File: CPlayScreen.h
//
// Desc: Định nghĩa lớp CPlayScreen thực hiện tất cả các thao tác chính của Game
//
//-----------------------------------------------------------------------------
#ifndef _CPLAY_SCREEN_H_
#define _CPLAY_SCREEN_H_

#include <vector>
#include <fstream>
#include <sstream>
#include <map>
#include <cmath>

#include "CSceneInfo.h"
#include "ResourceManager.h"
#include "resource.h"
#include "CTexture.h"
#include "CSprite.h"
#include "CRock.h"
#include "PowerEnergyX.h"
#include "CExplodingEffectManager.h"
#include "CItem.h"
#include "CScreen.h"
#include "CInput.h"
#include "CGameTime.h"
#include "CGameOver.h"
#include "CGraphics.h"
#include "DSUtil.h"
#include "CGlobal.h"
#include "CRockman.h"
#include "CQuadNode.h"
#include "CBoomMan.h"
#include "CCutMan.h"
#include "CGutsMan.h"
#include "CBullet.h"
#include "CDieArrow.h"
#include "CDoor.h"
#include "CEnemy.h"
#include "CEnemyBall.h"
#include "CEnemyBoom.h"
#include "CEnemyBubble.h"
#include "CEnemyCut.h"
#include "CEnemyEye.h"
#include "CEnemyFish.h"
#include "CEnemyHat.h"
#include "CEnemyInk.h"
#include "CEnemyMachineAuto.h"
#include "CEnemyWallShooter.h"
#include "CEnemyNinja.h"
#include "CEnemyRobot.h"
#include "CEnemyWorker.h"
#include "CEnemyTank.h"
#include "CElevator.h"
#include "CStair.h"
#include "CBlock.h"
#include "CBullet.h"
#include "CEnemyInk.h"
#include "CEnemyEye.h"
#include "CPopup.h"
#include "CScreenManager.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "CEnemySnapper.h"
#include "CElevator.h"
#include "CEnemyMachine.h"
#include "CGameInfo.h"
#include "Asset.h"

enum PlayState
{
	READY,
	PLAYING,
	PAUSE,
	GAMEOVER,
	WIN
};

class CPlayScreen :public CScreen
{
public:
	//-----------------------------------------------------------------------------
	// Phương thức khởi tạo màn hình PlayScreen với số màn tương ứng
	//-----------------------------------------------------------------------------
	CPlayScreen();
	~CPlayScreen();

	//-----------------------------------------------------------------------------
	// Phương thức cập nhật sự kiện bàn phím, chuột
	//-----------------------------------------------------------------------------
	void UpdateInput(CInput* input) override;

	//-----------------------------------------------------------------------------
	// Phương thức cập nhật màn hình theo thời gian thực
	//-----------------------------------------------------------------------------
	void Update(CGameTime* gameTime) override;

	//-----------------------------------------------------------------------------
	// Phương thức vẽ màn hình và các thành phần con bên trong
	//-----------------------------------------------------------------------------
	void Render(CGameTime* gameTime, CGraphics* graphics) override;

	friend class CRockman;

private:
	//-----------------------------------------------------------------------------
	// Phương thức vẽ bacground lên màn hình dựa theo khung camera di chuyển
	//-----------------------------------------------------------------------------
	void RenderBackground(CGraphics* graphics, Rect viewport);

	void LoadMap();

	//-----------------------------------------------------------------------------
	// Cập nhật va chạm của đối tượng với các đối tượng khác trong game
	//
	// + obj1: đối tượng cần để kiểm tra va chạm
	// + obj2: đối tượng cần để kiểm tra va chạm
	// + normalX: Hướng va chạm theo chiều x
	// + normalY: Hướng va chạm theo chiều y
	// + frameTime: Khoảng thời gian chuyển khung hình
	//
	//-----------------------------------------------------------------------------
	float CheckCollision(CGameObject* obj1, CGameObject* obj2, CDirection &normalX, CDirection &normalY, float frameTime);

	void ChangeScreen(CDirection direction);

	void FindScene(unsigned int startIndex);

	vector<vector<int>>		_tileMatrix;	// Ma trận lưu các tile background
	int						_countRow;		// Số lượng dòng của ma trận
	int						_countColumn;	// Số lượng cột của ma trận
	int						_totalTile;		// Tổng số tile được cắt
	CTexture				_textureBkg;	// Đối tượng nắm giữ ảnh nền
	
	CRockman				_rockman;		// Đối tượng Rockman
	vector<CBullet*>		_bulletsEnemy;	// Danh sách các đối tượng đạn của quái
	vector<CBullet*>		_bulletsRockman;// Danh sách các đối tượng đạn của Rockman
	vector<CGameObject*>	_groundObjs;	// Danh sách các đối tượng nằm không thể phá hủy bởi bất kì hình thức gì, bao gồm cầu thang, nền, tường, cửa qua màn, gai chết người
	vector<CElevator*>		_elevators;		// Danh sách băng chuyền trong game
	vector<CEnemy*>			_enemies;		// Danh sách các quái nằm trong vùng va chạm
	vector<CItem*>			_items;			// Danh sách các item nằm trong vùng va chạm
	vector<CPowerEnergyX*>	_powerEnegies;	// Danh sách ống năng lượng

	CQuadNode	_quadNodeCollision;			// Cây tứ phân lưu các đối tượng va chạm trên màn hình
	int			_changingScreen;			// Kiếm tra có đang chuyển frame màn hình hay không
	int			_prepareForBoss;			// Kiểm tra có đang chuẩn bị giết boss hay không
	int			_doorState;					// Kiểm tra có đang mở cửa giết trùm hay chưa, -1 là đang mở cửa, 0 là đã mở cửa, 1 là đang đóng cửa

	Vector2		_screenPosition, _newScreenPosition, _pointDoor, _pointAfterDoor, _pointBeforeDoor;
	CDirection	_changeScreenDirection;

	CSceneInfo	_sceneInfo;
	PlayState	_playState;					// Trạng thái màn chơi
	int			_deltaTime;					// Biến đếm thời gian theo tick
	bool		_isStopScreen;
	bool		_isChosingSkill;			// Xác nhận cửa sổ popup có hiện hay không
	bool		_isPause;					// Dừng toàn màn hình
	bool		_isBossDied;				// Kiểm tra boss có chết hay chưa
	int			_deltaTimeStopScreen;
	CSprite		_spriteIntroBoss;

	int			_deltatTimeShakingScreen;
	Vector2		_shakePointRand;
	CDoor*		_door;

	// Các biến điều khiển việc tính điểm màn hình
	int			_deltaClearPoint, _clearPoint, _totalScore;			// Biến tăng giá trị để tính điểm trên màn hình
	string		_strClearPoint;
	string		_strBonus, _strTotalBonusScore;
	Color		_defaultStringColor;
};

#endif //!_CPLAY_SCREEN_H_