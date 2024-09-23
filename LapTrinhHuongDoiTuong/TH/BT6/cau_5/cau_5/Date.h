#pragma once
#include <iostream>
using namespace std;

class CDate
{
private:
	int ngay,thang,nam;
public:
	CDate(void);
	CDate(int d,int m,int y);
	~CDate(void);
	void Set(int d,int m,int y);
	friend bool NamNhuan(int y);
	int KTNgay();
	friend int DateToDay(int d,int m,int y);
	CDate DayToDate(int d);
	friend CDate operator + (CDate a, int d);
	friend CDate operator - (CDate a, int d);
	friend int operator - (CDate a, CDate b);
	friend CDate operator ++ (CDate a);
	friend CDate operator -- (CDate a);
	friend istream& operator >> (istream &is, CDate &date);
	friend ostream& operator << (ostream &os, CDate date);
};

