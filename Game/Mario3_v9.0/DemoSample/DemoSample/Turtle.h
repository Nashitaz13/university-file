#pragma once
#ifndef __Turtle_H__
#define __Turtle_H__

#include <map>
#include "MyRectangle.h"
#include "MovableObject.h"


#define TURTLE_VELOCITY_X 0.02f
#define TURTLE_VELOCITY_Y 0.05f
#define ROLL_VELOCITY TURTLE_VELOCITY_X * 6

class ODauHoi;
class Gach;
class NamEnemy;

using namespace std;

enum TurtleAction
{
	rua_di, rua_mai, rua_rung, rua_hoisinh, rua_lan, rua_bay, rua_biom,
};

class Turtle : public MovableObject
{
private:
	map<TurtleAction, MyRectangle*> listMyRect;
	bool rungTrai;
	bool RuaXanh;
	bool collidWithGround;
	bool biOm;
	bool Chet;

	float originalX, originalY;
	float bien;
	DWORD _Tick, _Tick_HoiSinh, _Tick_Rung, _Tick_Fly;
private:
	void SetCurrRec(TurtleAction);
	void SetPreRect();
	void SetOmRua();
	void SetThaRua();
	void SetBiQuayDuoi(); //8.4.3
	void RuaChet(CollisionDirection); //8.4.3
	void VaChamNen(BasicObject*, CollisionDirection);
public:
	TurtleAction currAction, preAction;
public:
	Turtle(float, float, bool, bool, float);
	~Turtle();

	virtual void UpdatePosition();
	virtual void UpdateCollision();
	virtual void UpdateRootPosition();
	virtual void Render();					// Render object
	virtual void SetX(float);				// Set x va currBox->x
	virtual void SetY(float);
	virtual void SetXY(float, float);

	// Xu ly va cham voi ground
	void OnCollisionWithGround(BasicObject*, CollisionDirection);
	// Xu ly va cham voi Mario
	void OnCollisionWithMario(CollisionDirection);
	void OnCollisionWithNamEnemy(NamEnemy*,CollisionDirection);
	void OnCollisionWithODauHoi(ODauHoi*, CollisionDirection);
	void OnCollisionWithGach(Gach*, CollisionDirection);
	void OnCollisionWithTurtle(Turtle*, CollisionDirection);
};

#endif