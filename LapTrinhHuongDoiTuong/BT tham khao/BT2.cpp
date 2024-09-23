#include <iostream>
#include <conio.h>
#include <math.h>
using namespace std;

class Complex
{
	int Thuc,Ao;
public:
	void InPut();
	void OutPut();
	Complex Cong(Complex a);
	Complex Tru(Complex a);
	Complex Nhan(Complex a);
	void Chia(Complex a);
	int Modul();
};

class PhanSo
{
public:
	int TuSo,MauSo;
	void RutGon();
	PhanSo Cong(PhanSo a);
};

int main()
{
	Complex a,b;
	cout<<"Nhap so phuc thu nhat: "<<endl;
	a.InPut();
	a.OutPut();
	cout<<"Modul: "<<a.Modul()<<endl;
	cout<<endl;
	cout<<"Nhap so phuc thu hai: "<<endl;
	b.InPut();
	b.OutPut();
	cout<<"Modul: "<<b.Modul()<<endl;
	cout<<endl;
	cout<<"Tong: ";
	a.Cong(b).OutPut();
	cout<<"Modul: "<<a.Cong(b).Modul()<<endl<<endl;
	cout<<"Hieu: ";
	a.Tru(b).OutPut();
	cout<<"Modul: "<<a.Tru(b).Modul()<<endl<<endl;
	cout<<"Tich: ";
	a.Nhan(b).OutPut();
	cout<<"Modul: "<<a.Nhan(b).Modul()<<endl<<endl;
	a.Chia(b);
	getch();
	return 0;
}

void Complex::InPut()
{
	cout<<"Nhap phan thuc: "<<endl;
	cin>>Thuc;
	cout<<"Nhap Phan ao: "<<endl;
	cin>>Ao;
}

void Complex::OutPut()
{
	cout<<"("<<Thuc<<" , "<<Ao<<")"<<endl;
}

Complex Complex::Cong(Complex a)
{
	Complex kq;
	kq.Thuc=Thuc+a.Thuc;
	kq.Ao=Ao+a.Ao;
	return kq;
}

Complex Complex::Tru(Complex a)
{
	Complex kq;
	kq.Thuc=Thuc-a.Thuc;
	kq.Ao=Ao-a.Ao;
	return kq;
}

Complex Complex::Nhan(Complex a)
{
	Complex kq;
	kq.Thuc=Thuc*a.Thuc - Ao*a.Ao;
	kq.Ao=Thuc*a.Ao + Ao*a.Thuc;
	return kq;
}

void Complex::Chia(Complex a)
{
	hanSo p1,p2;
	p1.TuSo=Thuc*a.Thuc+Ao*a.Ao;
	p2.MauSo=p1.MauSo=pow(a.Ao,2)+pow(a.Thuc,2);
	p2.TuSo=a.Thuc*Ao-Thuc*a.Ao;
	cout<<"Thuong: ";
	cout<<"(";
	p1.RutGon();
	cout<<" , ";
	p2.RutGon();
	cout<<")"<<endl;
	cout<<"Modul: ";
	PhanSo kq;
	kq.TuSo = pow(p1.TuSo,2) * pow(p2.MauSo,2) + pow(p2.TuSo,2) * pow(p1.MauSo,2) ;
	kq.MauSo = pow(p1.MauSo,2) * pow(p2.MauSo,2);
	kq.RutGon();P
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
		cout<<TuSo;
	else
		cout<<TuSo<<"/"<<MauSo;
}

int Complex::Modul()
{
	return pow(Thuc,2) + pow(Ao,2);
}

PhanSo PhanSo::Cong(PhanSo a)
{
	PhanSo kq;
	kq.TuSo= TuSo*a.MauSo+MauSo*a.TuSo;
	kq.MauSo=MauSo*a.MauSo;
	return kq;
}