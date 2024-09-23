#include <iostream>
#include <conio.h>
#include <stdio.h>
using namespace std;
#define ESC 27

class PhanSo
{
private: 
	int TuSo,MauSo;
public:
	void InPut();
	PhanSo Cong(PhanSo a);
	PhanSo Tru(PhanSo a);
	PhanSo Nhan(PhanSo a);
	PhanSo Chia(PhanSo a);
	void RutGon();
};

void InMenu()
{
	cout<<"1.Cong hai phan so"<<endl
		<<"2.Tru hai phan so" <<endl
		<<"3.Nhan hai phan so"<<endl
		<<"4.Chia hai phan so"<<endl
		<<"ESC.Thoat khoi chuong trinh"<<endl;
}

int main()
{
	char h;
	PhanSo a,b,kq;
	cout<<"Nhap phan so thu nhat: "<<endl;
	a.InPut();
	cout<<"Nhap phan so thu hai: "<<endl;
	b.InPut();
	do
	{
		InMenu();
		h=getch();
		switch(h)
		{
		case '1':
			kq=a.Cong(b);
			cout<<"Tong 2 phan so la: "<<endl;
			kq.RutGon();
			cout<<"Nhan ENTER de quay lai MENU"<<endl;
			getch();
			break;
		case '2':
			kq=a.Tru(b);
			cout<<"Hieu 2 phan so la: "<<endl;
			kq.RutGon();
			cout<<"Nhan ENTER de quay lai MENU"<<endl;
			getch();
			break;
		case '3':
			kq=a.Nhan(b);
			cout<<"Tich 2 phan so la: "<<endl;
			kq.RutGon();
			cout<<"Nhan ENTER de quay lai MENU"<<endl;
			getch();
			break;
		case '4':
			kq=a.Chia(b);
			cout<<"Thuong 2 phan so la: "<<endl;
			kq.RutGon();
			cout<<"Nhan ENTER de quay lai MENU"<<endl;
			getch();
			break;
		}

	}
	while(h!= ESC);
	getch();
	return 0;
}

void PhanSo::InPut()
{
	do
	{
		cout<<"Nhap tu so: "<<endl;
		cin>>TuSo;
		cout<<"Nhap mau so: "<<endl;
		cin>>MauSo;
		if(MauSo==0)
		{
			cout<<"Mau so phai khac 0!"<<endl
				<<"Nhap lai!"<<endl;
		}
	}
	while(MauSo==0);
}


void PhanSo::RutGon()
{
	
	int a = abs(TuSo);
	int b = abs(MauSo);
	while(a*b != 0)
	{
		if(a > b)
			a-=b;
		else
			b-=a;
	}
	TuSo=TuSo / (a + b);
	MauSo=MauSo / (a + b);
	if(MauSo==1)
		cout<<TuSo<<endl;
	else
		cout<<TuSo<<"/"<<MauSo<<endl;
}

PhanSo PhanSo::Cong(PhanSo a)
{
	PhanSo kq;
	kq.TuSo= TuSo*a.MauSo+MauSo*a.TuSo;
	kq.MauSo=MauSo*a.MauSo;
	return kq;
}

PhanSo PhanSo::Tru(PhanSo a)
{
	PhanSo kq;
	kq.TuSo= TuSo*a.MauSo-MauSo*a.TuSo;
	kq.MauSo=MauSo*a.MauSo;
	return kq;
}

PhanSo PhanSo::Nhan(PhanSo a)
{
	PhanSo kq;
	kq.TuSo=TuSo*a.TuSo;
	kq.MauSo=MauSo*a.MauSo;
	return kq;
}

PhanSo PhanSo::Chia(PhanSo a)
{
	PhanSo kq;
	kq.TuSo=TuSo*a.MauSo;
	kq.MauSo=MauSo*a.TuSo;
	return kq;
}

