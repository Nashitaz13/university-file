#pragma once
#include <iostream>
#include <string>
using namespace std;

class Sach
{
public:
	Sach(void);
	~Sach(void);
	virtual void Nhap()=0;
	virtual void Xuat()=0;
};

class SachGiaoKhoa:public Sach
{
protected:
	string ten,tacgia;
	int sl,namxb,khoi;
public:
	void Nhap();
	void Xuat();
};

class TieuThuyet:public Sach
{
protected:
	string ten,tacgia,theloai;
	int sl,namxb,khoi;
public:
	void Nhap();
	void Xuat();
};

class TapChi:public Sach
{
protected:
	string ten,tacgia,detai;
	int sl,namxb,khoi;
public:
	void Nhap();
	void Xuat();
};
