#pragma once
#ifndef __EndBox_H__
#define __EndBox_H__

#include <map>
#include "MyRectangle.h"
#include "MovableObject.h"

using namespace std;

#define VELOCITY_RANDOM 300
#define ORIGINAL_X 2640
#define ORIGINAL_Y 150

enum EndBoxStatus
{
	random, nam, hoa, sao,
};

class EndBox : public MovableObject
{
private:
	map<EndBoxStatus, MyRectangle*> listMyRect;
	MyRectangle* cardNam, *cardHoa, *cardSao, *Clear, *GameOver;
	bool isClear;
	void SetCurrRec(EndBoxStatus);
	void SetPreRect();
public:
	EndBox(float, float);
	~EndBox();

	int cardNum;
	EndBoxStatus currStatus, preStatus;

	virtual void Render();
	virtual void UpdatePosition();
	virtual void UpdateCollision();
	virtual void SetX(float);				// Set x va currBox->x
	virtual void SetY(float);
	virtual void SetXY(float, float);

	void OnCollisionWithMario();
};
#endif
