#include "PhanSo.h"
#include <iostream>
using namespace std;

PhanSo::PhanSo(void)
{
}
PhanSo::PhanSo(int t,int m)
{
	Set(t,m);
}
PhanSo::PhanSo(int t)
{
	Set(t,1);
}
PhanSo::~PhanSo(void)
{
}
void PhanSo::Set(int t,int m)
{
	tu=t;
	mau=m;
	RutGon();
}
PhanSo operator + (PhanSo a,PhanSo b)
{
	return PhanSo(a.tu*b.mau+b.tu*a.mau,a.mau*b.mau);
}
PhanSo operator - (PhanSo a, PhanSo b)
{
	return PhanSo(a.tu*b.mau-b.tu*a.mau,a.mau*b.mau);
}
PhanSo operator * (PhanSo a, PhanSo b)
{
	return PhanSo(a.tu*b.tu,a.mau*b.mau);
}
PhanSo operator / (PhanSo a, PhanSo b)
{
	return PhanSo(a.tu*b.mau,a.mau*b.tu);
}
bool operator == (PhanSo a, PhanSo b)
{
	return (a.tu*b.mau==a.mau*b.tu);
}
bool operator != (PhanSo a, PhanSo b)
{
	return (a.tu*b.mau!=a.mau*b.tu);
}
PhanSo operator ! (PhanSo a)
{
	return PhanSo(-a.tu,a.mau);
}
istream& operator >> (istream &is, PhanSo &p)
{
	do
	{
		cout<<"Nhap phan tu: ";
		is>>p.tu;
		cout<<"Nhap phan mau: ";
		is>>p.mau;
		if (p.mau==0)
			cout<<"Khong hop le. Nhap lai!"<<endl;
	}
	while (p.mau==0);
	return is;
}
ostream& operator << (ostream &os, PhanSo p)
{
	if(p.tu==0)
		os<<p.tu;
	if(p.tu!=0)
	{
		if(p.mau>1)
			os<<p.tu<<"/"<<p.mau;
		if(p.mau==1)
			os<<p.tu;
		if(p.mau==-1)
			os<<-p.tu;
		if(p.mau<-1)
			os<<-p.tu<<"/"<<-p.mau;
	}
	return os;
}
int PhanSo::UCLN(int a,int b)
{
	int r;
	if (a<0) 
		a = -a;
	if (b<0)
		b = -b;
	while(a * b != 0)
	{
		if(a > b)
			a -= b;
		else 
			b -= a;
	}
	r = a + b;
	return r;
}
void PhanSo::RutGon()
{
	int UocChung=UCLN(tu,mau);
	tu /= UocChung;
	mau /= UocChung;
}

