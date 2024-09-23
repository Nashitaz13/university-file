#pragma once
#ifndef __OngNuoc_H__
#define __OngNuoc_H__

#include "MovableObject.h"
#include "Input.h"
#include <map>
#include <fstream>
#include <string>
#include <sstream>
using namespace std;

#define ONGNUOC_RA_X1 128
#define ONGNUOC_RA_Y1 192
#define ONGNUOC_RA_X2 2336
#define ONGNUOC_RA_Y2 48

class OngNuoc : public MovableObject
{
public:
	OngNuoc(float, float, int, int, float, float, int ,int, bool);
	~OngNuoc();
	
	MyRectangle *ongvao, *ongra;
	bool down;
	float ongvaoX, ongvaoY, ongraX, ongraY;
	float x1, y1;
	int width1, height1;

	virtual void Render();
};
#endif

