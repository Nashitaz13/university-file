#pragma once
#include "graphics.h"
#include <iostream>
using namespace std;

class Points
{
protected:
	int x,y;
public:
	Points(void);
	Points(int xx,int yy);
	~Points(void);
	void Nhap();
};

class HinhTron:public Points
{
protected:
	int r;
public:
	void Nhap();
	void Ve();
};

class Elip:public Points
{
protected:
	int xr,yr;
public:
	void Nhap();
	void Ve();
};