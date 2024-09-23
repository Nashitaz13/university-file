#pragma once
#ifndef __mario_H__
#define __mario_H__

#include "Input.h"
#include <map>
#include <fstream>
#include <string>
#include <sstream>
#include "Time.h"
#include "World.h"

using namespace std;

#define STAGE1_WIDTH 2816

#define MARIO_VELOCITY_X 0.085f
#define MARIO_VELOCITY_Y 0.4f
#define MARIO_ACCELERATION_Y 0.032f
#define MARIO_ACCELERATION_X 0.02f
#define OFFSET 6
#define START_X 50//2272 340
#define START_Y 100

#define START_X1 2000
#define START_Y1 100

#define GROUND_Y 16
#define MARIO_MAX_JUMP_DISTANCE 70

#define MARIO_TIME_STARMAN 10000

enum MarioRectangeID
{
	mario_nho_dung,
	mario_nho_di,
	mario_nho_chay,
	mario_nho_doihuong,
	mario_nho_nhay,
	mario_nho_darua,
	mario_nho_omrua,
	mario_nho_omruachay,
	mario_nho_omruanhay,
	mario_nho_chuiong,
	mario_nho_chet,
	mario_nho_nhaycao,
	mario_nho_truotdoc,

	mario_lon_dung,
	mario_lon_di,
	mario_lon_chay,
	mario_lon_doihuong,
	mario_lon_nhay,
	mario_lon_roi,
	mario_lon_ngoi,
	mario_lon_darua,
	mario_lon_omrua,
	mario_lon_omruachay,
	mario_lon_omruanhay,
	mario_lon_chuiong,
	mario_lon_nhaycao,
	mario_lon_nhaysao,
	mario_lon_truotdoc,

	mario_duoi_dung,
	mario_duoi_di,
	mario_duoi_chay,
	mario_duoi_doihuong,
	mario_duoi_nhay,
	mario_duoi_ngoi,
	mario_duoi_darua,
	mario_duoi_omrua,
	mario_duoi_omruachay,
	mario_duoi_omruanhay,
	mario_duoi_chuiong,
	mario_duoi_chuanbibay,
	mario_duoi_baylen,
	mario_duoi_roitudo,
	mario_duoi_bayxuong,
	mario_duoi_quayduoi,
	mario_duoi_nhayquayduoi,
	mario_duoi_nhaysao,
	mario_duoi_truotdoc,
};

enum MarioType
{
	nho,
	lon,
	duoi,
};

enum MarioAction
{
	dung,
	di,
	chamdan,
	doihuong,
	nhay,
	roi,
	darua,
	baylen,
	bayxuong,
	quayduoi,
	nhayquayduoi,
	chuiong,
	truotdoc,
	chet,
};

enum MarioEffects
{
	left,
	right,
	none,
};

class mario : public MovableObject
{
private:
	int right = 0;
	float start = 0;
	float start_run = 0;
	int muc_doihuong = 0;

	int test_collision_wall = 0;
	float startJumpY;			// Luu vi tri bat dau nhay
	bool isJumpIncrease = true;	// Chi tra co duoc tang gia toc khi nhay hay khong
	bool maxSpeed = false;
	clock_t t0 = 0, t1 = 0;
	DWORD _Tick_Darua, _Tick_Die, _Tick, _Tick_NhoLon, _Tick_NhapNhay, _Tick_Sao; //8.4.3
	bool bienLon, isSmall, isNhapNhay; //8.4.3
	bool TrenDoc = false, TruotDoc = false;
	PhuongTrinhDuongThang d;
	CBoxStair* box;
	OngNuoc* ongNuoc;
	
private:
	void LoadListMyRectange();
	MarioRectangeID ConvertStringToState(string state);
	void XuLyVaCham();
	void SetCurrRectangle(MarioRectangeID);
	void SetPreRectangle(MarioRectangeID);
	void RunLeft(int type);
	void RunRight(int type);
	void DropDown();
	void Slow();
	void ChangeDirection(float &k);
	void JumpUp();					// Xu ly nhay - trong action nhay
	void PreProcessingForJump();	// Tien xu ly truoc khi den trang thai nhay
	void KeepTurtle(int marioType, int actionType);
	void VaChamNen(BasicObject*, CollisionDirection);
	void ChangeSmallBig(MarioType);
	void ChangeBigTail();
	void ChuiOng();
	void Sound();

public:
	map<MarioRectangeID, MyRectangle*> listMyRect;
	MarioRectangeID marioRectangeID, preMarioRectangeID;
	MarioAction marioAction;
	MarioType marioType;
	bool OmRua;
	bool bienLonDuoi;
	bool bienNhoLon;
	bool indexLonDuoi;
	bool isRender;
	bool chuiOng;
	int die = 0;
	bool starMan;
	bool stageClear;
public:
	mario();
	void KhoiTao();
	void ProcessInput();
	void Update();
	virtual void Render();
	virtual void UpdatePosition() {};
	virtual void UpdateCollision() {};

	virtual void SetX(float);
	virtual void SetY(float);			
	virtual void SetXY(float, float);	

	// Xu ly va cham voi duong di, ong nuoc, cac vien gach co dinh
	void OnCollidWithGround(BasicObject*, CollisionDirection);
	// Xu ly va cham voi rua 
	void OnCollisionWithTurtle(Turtle*, CollisionDirection);
	// Xu ly Va cham voi enemy nam
	void OnCollisionWithNamEnemy(NamEnemy*, CollisionDirection);
	// Xu ly va cham voi o dau hoi
	void OnCollisionWithODauHoi(ODauHoi*, CollisionDirection);
	// Xu ly va cham voi gach
	void OnCollisionWithGach(Gach*, CollisionDirection);
	void OnCollisionWithChiecLa(ChiecLa*); 
	void OnCollisionWithNamItem(NamItem*); 
	void OnCollisionWithFireBullet();
	void OnCollisionWithRedFirePlant();
	void OnCollisionWithOngNuoc(OngNuoc*, CollisionDirection);
	void OnCollisionWithEndBox();
	void OnCollisionWithBoxStair(CBoxStair*, CollisionDirection);

	~mario();
};

extern mario* mario1;

#endif