#pragma once
#include "Nguoi.h"
#include <iostream>
using namespace std;

class NhanVien:public Nguoi
{
protected:
	int manv,luong1,luong2,sosp,snlv;
public:
	NhanVien(void);
	~NhanVien(void);
	void Nhap(int);
	void Xuat();
};

