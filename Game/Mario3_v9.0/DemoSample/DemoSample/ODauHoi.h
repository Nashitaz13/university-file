#pragma once
#ifndef __ODauHoi_H__
#define __ODauHoi_H__

#include "MovableObject.h"
#include "Resource.h"
#include "DongTien.h"
#include "ChiecLa.h"
#include "ChuP.h"
#include "Turtle.h"
#include <vector>

using namespace std;

enum ODauHoiItem
{
	ODHT_DongTien, ODHT_NamDo_La, ODHT_NamXanh, ODHT_ChuP, ODHT_Sao,
};

enum ODauHoiState
{
	ODS_normal,
	ODS_nhay,
	ODS_xuong,
	ODS_saukhinhay,
};

class ODauHoi : public MovableObject
{
private:
	float originalY;
	vector<MyRectangle*> listRect;
	MyRectangle* OMauXanh;
	ODauHoiItem item;
	void VaCham(CollisionDirection);
	bool notnhacItem;
public:
	ODauHoiState state;
private:
	void SetCurrRect(int index);
	void SetPreRect();
public:
	ODauHoi(float, float, int, int);
	~ODauHoi();

	int Loai;

	virtual void UpdatePosition();
	virtual void Render();
	virtual void SetY(float);

	void OnCollisionWithMario(CollisionDirection);
	void OnCollisionWithTurtle(Turtle*, CollisionDirection);
};

#endif

