#pragma once
#include "graphics.h"
#include <iostream>
using namespace std;

class HinhThang
{
protected:
	int x1daylon,x2daylon,x1daybe,x2daybe,ydaylon,ydaybe;
public:
	HinhThang(void);
	~HinhThang(void);
	int DieuKien();
	void Nhap();
	void Ve();
};

class HinhBinhHanh:public HinhThang
{
public:
	void Nhap();
	void Ve();
};

class HinhChuNhat:public HinhThang
{
public:
	void Nhap();
	void Ve();
};

class HinhVuong:public HinhThang
{
public:
	void Nhap();
	void Ve();
};