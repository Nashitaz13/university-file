#pragma once
#ifndef __ChiecLa_H__
#define __ChiecLa_H__

#include "MovableObject.h"
#include "Resource.h"
#include <vector>

using namespace std;

#define DISTANCE_X 35
#define DISTANCE_X_FOR_LITTLE_UP DISTANCE_X * 0.7
#define VELLOCTITY_X 0.04
#define VELLOCITY_Y_UP_EXIT 0.4
#define VELLOCITY_Y_UP 0.015
#define VELLOCITY_Y_DOWN GRAVITY * 0.4

enum ChiecLaState
{
	CLS_Up, CLS_DoiHuongPhai, CLS_DoiHuongTrai,
};

class ChiecLa : public MovableObject
{
private:
	ChiecLaState state;
	float originalX; // l?u l?i t?a ?? ban ??u c?a X trc khi nó chuy?n h??ng
	bool Hide;
public:
	ChiecLa(float, float, bool);
	~ChiecLa();

	void UpdatePosition();
	void Render();
	void SetX(float);
	void SetY(float);
	void SetXY(float, float);

	void OnCollisionWithMario(); //8.4.3
};

#endif
