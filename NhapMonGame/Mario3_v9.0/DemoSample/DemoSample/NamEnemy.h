#pragma once
#ifndef __NamEnemy_H__
#define __NamEnemy_H__

#include <map>
#include "MyRectangle.h"
#include "MovableObject.h"
#include "Turtle.h"
#include "ImageEffect.h"
#include "BoxStair.h"

using namespace std;

#define NAMENEMY_VELOCITY_X 0.02f // v?n t?c x
#define NAMENEMY_VELOCITY_Y 0.05f // v?n t?c y

class ODauHoi;
class Gach;

enum NamEnemyAction
{
	nam_bay, nam_di, nam_chet, nam_nguoc,
};

class NamEnemy : public MovableObject
{
private:
	// L?u danh sách các hình t??ng ?ng các tr?ng thái
	// Tr?ng thái nào thì get hình tr?ng thái ?ó
	map<NamEnemyAction, MyRectangle*> listMyRect;
private:
	void SetCurrRec(NamEnemyAction);
	void SetPreRect();
	// Hàm s? d?ng chung khi va ch?m v?i: n?n, o d?u h?i, g?ch
	void VaChamNen(BasicObject*, CollisionDirection);
	bool TrenDoc = false;
	PhuongTrinhDuongThang d;
	CBoxStair* box;
public:
	NamEnemyAction currAction, preAction;
	DWORD _Tick, _Tick_Die, _Tick_Fly = 0;
	bool collidWithGround;
public:
	NamEnemy(float, float, bool);
	~NamEnemy();

	void Update();
	virtual void UpdatePosition();
	virtual void UpdateRootPosition();
	virtual void UpdateCollision();
	virtual void Render();					// Render object
	virtual void SetX(float);				// Set x va currBox->x
	virtual void SetY(float);
	virtual void SetXY(float, float);

	// Xu ly va cham voi nen
	void OnCollisionWithGround(BasicObject*, CollisionDirection);
	void OnCollisionWithMario(CollisionDirection);
	void OnCollisionWithTurtle(Turtle*, CollisionDirection);
	void OnCollisionWithODauHoi(ODauHoi*, CollisionDirection);
	void OnCollisionWithGach(Gach*, CollisionDirection);
	void OnCollisionWithNamEnemy(NamEnemy*, CollisionDirection);
	void OnCollisionWithBoxStair(CBoxStair*);
};

#endif
