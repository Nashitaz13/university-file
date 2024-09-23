#pragma once
#include "graphics.h"
#include <iostream>
using namespace std;

class DaGiac
{
public:
	DaGiac(void);
	~DaGiac(void);
	virtual void Nhap()=0;
	virtual void Xuat()=0;
};

class TuGiac:public DaGiac
{
protected:
	float x1,x2,x3,x4,y1,y2,y3,y4,z;
	int x,y,alpha;
public:
	void Nhap();
	void Xuat();
	void Ve();
	void TinhTien();
	void Quay();
	void Zoom();
	float TrongTam(float,float,float,float);
};

class TamGiac:public DaGiac
{
protected:
	float x1,x2,x3,y1,y2,y3,z;
	int x,y,alpha;
public:
	void Nhap();
	void Xuat();
	void Ve();
	void TinhTien();
	void Quay();
	void Zoom();
	float Canh(int,int,int,int);
	float TrongTam(float,float,float);
};

class HinhBinhHanh:public DaGiac, TuGiac
{
public:
	void Nhap();
	void Xuat();
	int DieuKien(int,int,int,int,int,int);
};

class HinhChuNhat:public DaGiac, TuGiac
{
public:
	void Nhap();
	void Xuat();
};

class HinhVuong:public DaGiac, TuGiac
{
public:
	void Nhap();
	void Xuat();
};