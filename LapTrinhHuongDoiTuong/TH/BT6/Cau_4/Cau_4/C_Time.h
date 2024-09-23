#pragma once
#include <iostream>
using namespace std;
class C_Time
{
private:
	int gio,phut,giay;
public:
	C_Time(void);
	C_Time(int h,int m,int s);
	~C_Time(void);
	void Set(int h,int m,int s);
	int TimeToSecond(int h,int m,int s);
	C_Time SecondToTime(int s);
	void DongHo();
	void delay(int);
	friend C_Time operator + (C_Time a, int ss);
	friend C_Time operator - (C_Time a, int ss);
	friend C_Time operator - (C_Time a, C_Time b);
	friend C_Time operator ++ (C_Time a);
	friend C_Time operator -- (C_Time a);
	friend istream& operator >> (istream &is, C_Time &t);
	friend ostream& operator << (ostream &os, C_Time t);

};

