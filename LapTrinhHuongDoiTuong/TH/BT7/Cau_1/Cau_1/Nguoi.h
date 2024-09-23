#pragma once
#include <string>
#include <iostream>
using namespace std;

class Nguoi
{
protected:
	string HoTen;
	int ngaysinh,thangsinh,namsinh;
public:
	Nguoi(void);
	~Nguoi(void);
	void Nhap();
	void Xuat();
};

