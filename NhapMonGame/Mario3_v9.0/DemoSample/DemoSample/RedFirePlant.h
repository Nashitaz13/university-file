#pragma once
#ifndef __RedFirePlant_H__
#define __RedFirePlant_H__

#include "FireBullet.h"
#include "Input.h"
#include <map>
#include <fstream>
#include <string>
#include <sstream>

using namespace std;

enum RedFireRectangleID {len2, len1, xuong2, xuong1};
enum RedFire_Stage { GOINGDOWN, GOINGUP, SHOOTING, SLEEPING };

class RedFirePlant: public MovableObject
{
private:
	RedFireRectangleID currRectID, preRectID;
private:
	void SetCurrRectangle(RedFireRectangleID);
	void SetPreRectangle(RedFireRectangleID);
public:
	RedFirePlant( float X, float Y, bool, bool);
	~RedFirePlant();
	virtual void SetX(float x);				// Set x va currBox->x
	virtual void SetY(float y);				// Set y va currBox->y
	virtual void SetXY(float x, float y);	// Set x, y va currBox->x, currBox->y
	virtual void UpdatePosition();
	virtual void UpdateCollision();
	void Set_Alpha_Of_Attack();
	void Render();

	DWORD _TickSprite, _TickSleep, _TickShoot;
	map<RedFireRectangleID, MyRectangle*> listMyRect;
	MyRectangle* ongnuoc;
	RedFire_Stage _Stage;
	float _OriginalY;
	float _OriginalX;
	float _Alpha;
	int _Navigation;
	bool Ban;

	void OnCollisionWithMario(); 
	void OnCollisionWithTurtle(); 
};

#endif
