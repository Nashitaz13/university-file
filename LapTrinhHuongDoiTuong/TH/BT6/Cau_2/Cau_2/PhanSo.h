#pragma once
#include <iostream>
using namespace std;
class PhanSo
{
private:
	int tu, mau;
public:
	PhanSo(void);
	PhanSo(int t,int m);
	PhanSo(int t);
	~PhanSo(void);
	void Set(int t,int m);
	int UCLN(int, int);
	void RutGon();
	friend PhanSo operator + (PhanSo a, PhanSo b);
	friend PhanSo operator - (PhanSo a, PhanSo b);
	friend PhanSo operator * (PhanSo a, PhanSo b);
	friend PhanSo operator / (PhanSo a, PhanSo b);
	friend bool operator == (PhanSo a, PhanSo b);
	friend bool operator != (PhanSo a, PhanSo b);
	friend PhanSo operator ! (PhanSo a);
	friend istream& operator >> (istream &is, PhanSo &p);
	friend ostream& operator << (ostream &os, PhanSo p);
};

