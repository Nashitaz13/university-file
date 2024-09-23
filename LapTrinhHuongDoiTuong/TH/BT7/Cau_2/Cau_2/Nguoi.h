#pragma once
#include <string>
#include <iostream>
using namespace std;

class Nguoi
{
protected:
	string HoTen,GioiTinh;
	int ngaysinh,thangsinh,namsinh;
public:
	Nguoi(void);
	~Nguoi(void);
	void Nhap();
	void Xuat();
};

class SinhVien:public Nguoi
{
protected:
	int mssv;
	string truong;
public:
	void Nhap();
	void Xuat();
};

class HocSinh:public Nguoi
{
protected:
	int mshs;
	string truong;
public:
	void Nhap();
	void Xuat();
};

class CongNhan:public Nguoi
{
public:
	void Nhap();
	void Xuat();
};

class NgheSi:public Nguoi
{
public:
	void Nhap();
	void Xuat();
};

class CaSi:public Nguoi
{
public:
	void Nhap();
	void Xuat();
};