#include "stdafx.h"
#include <iostream>
#include <conio.h>
using namespace std;
class PhanSo
{
private:
	int tu,mau;
public:
	void Set(int t,int m);
	void Nhap();
	void Xuat();
	int UCLN(int a,int b);
	void RutGon();
	PhanSo Cong(PhanSo p);
	PhanSo Tru(PhanSo p);
	PhanSo Nhan(PhanSo p);
	PhanSo Chia(PhanSo p);
};
int main()
{
	PhanSo p1,p2;
	cout<<"Nhap Phan So thu nhat: "<<endl;
	p1.Nhap();
	cout<<"Nhap Phan So thu hai: "<<endl;
	p2.Nhap();
	PhanSo kq1=p1.Cong(p2);
	PhanSo kq2=p1.Tru(p2);
	PhanSo kq3=p1.Nhan(p2);
	PhanSo kq4=p1.Chia(p2);
	cout<<"Phep Cong: "; p1.Xuat(); cout<<" + "; p2.Xuat(); cout<<" = "; kq1.RutGon(); cout<<endl;
	cout<<"Phep Tru : "; p1.Xuat(); cout<<" - "; p2.Xuat(); cout<<" = "; kq2.RutGon(); cout<<endl;
	cout<<"Phep Nhan: "; p1.Xuat(); cout<<" * "; p2.Xuat(); cout<<" = "; kq3.RutGon(); cout<<endl;
	cout<<"Phep Chia: "; p1.Xuat(); cout<<" : "; p2.Xuat(); cout<<" = "; kq4.RutGon(); cout<<endl;
	getch();

}
void PhanSo::Set(int t,int m)
{
	tu=t;
	mau=m;
}
void PhanSo::Nhap()
{
	do
	{
	cout<<"Nhap tu so : "<<endl;
	cin >> tu;
	cout<<"Nhap mau so : "<<endl;
	cin>> mau;
	if (mau == 0) 
		cout<<"Phan so khong ton tai, nhap lai phan so"<<endl;
	}
	while (mau == 0);
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
void PhanSo::Xuat()
{
	cout<<tu<<"/"<<mau;
}
void PhanSo::RutGon()
{
	int UocChung=UCLN(tu,mau);
	tu /= UocChung;
	mau /= UocChung;
	if (mau==1) cout<<tu;
	else Xuat();
}
PhanSo PhanSo::Cong(PhanSo p)
{
	PhanSo kq1;
	int t=tu*p.mau+mau*p.tu;
	int m=mau*p.mau;
	kq1.Set(t,m);
	return kq1;
}
PhanSo PhanSo::Tru(PhanSo p)
{
	PhanSo kq2;
	int t=tu*p.mau-mau*p.tu;
	int m=mau*p.mau;
	kq2.Set(t,m);
	return kq2;
}
PhanSo PhanSo::Nhan(PhanSo p)
{
	PhanSo kq3;
	int t=tu*p.tu;
	int m=mau*p.mau;
	kq3.Set(t,m);
	return kq3;
}
PhanSo PhanSo::Chia(PhanSo p)
{
	PhanSo kq4;
	int t=tu*p.mau;
	int m=mau*p.tu;
	kq4.Set(t,m);
	return kq4;
}
