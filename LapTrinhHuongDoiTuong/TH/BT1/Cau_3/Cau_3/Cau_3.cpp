#include "StdAfx.h"
#include <conio.h>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
using namespace std;

typedef struct PhanSo
{
	int iTuSo;
	int iMauSo;
};
typedef struct PhanSo PHANSO;

void Input_ps(PHANSO &x);
void Print_ps(PHANSO x); 
PHANSO TongPS(PHANSO x, PHANSO y);
PHANSO HieuPS(PHANSO x, PHANSO y);
PHANSO TichPS(PHANSO x, PHANSO y);
PHANSO ThuongPS(PHANSO x,PHANSO y);
void RutGonPS(PHANSO &x);

int main()
{
	PHANSO x,y;
	cout<<"Nhap Phan So Thu Nhat:"<<endl;
	Input_ps(x);
	cout<<"Nhap Phan So Thu Hai:"<<endl;
	Input_ps(y);
	PHANSO kq1 = TongPS(x,y);
	PHANSO kq2 = HieuPS(x,y);
	PHANSO kq3 = TichPS(x,y);
	PHANSO kq4 = ThuongPS(x,y);
	cout<<"Tong 2 phan so la :";
	RutGonPS(kq1);
	cout<<"Hieu 2 phan so la : ";
	RutGonPS(kq2);
	cout<<"Tich 2 phan so la : ";
	RutGonPS(kq3);
	cout<<"Thuong 2 phan so la : ";
	RutGonPS(kq4);
	getch();
}				

void Input_ps(PHANSO &x)
{
	do
	{
	cout<<"Nhap tu so : "<<endl;
	cin >> x.iTuSo;
	cout<<"Nhap mau so : "<<endl;
	cin>> x.iMauSo;
	if (x.iMauSo == 0) 
		cout<<"Phan so khong ton tai, nhap lai phan so"<<endl;
	}
	while (x.iMauSo == 0);
}

void Print_ps (PHANSO x)
{
	cout<<x.iTuSo<<"/"<<x.iMauSo<<endl;
}

void RutGonPS(PHANSO &x)
{
	int a = abs(x.iTuSo);
	int b = abs(x.iMauSo);
	//tim ucln
	while(a * b != 0)
	{
		if(a > b)
			a -= b;
		else
			b -= a;
	}

	x.iTuSo = x.iTuSo / (a + b);
	x.iMauSo = x.iMauSo / (a + b);
	Print_ps (x);
}

PHANSO TongPS(PHANSO x,PHANSO y)
{
	PHANSO temp;
	temp.iTuSo = x.iTuSo * y.iMauSo + x.iMauSo * y.iTuSo;
	temp.iMauSo = x.iMauSo * y.iMauSo;
	return temp;
}

PHANSO HieuPS(PHANSO x, PHANSO y)
{
	PhanSo temp;
	temp.iTuSo = y.iMauSo * x.iTuSo - x.iMauSo * y.iTuSo;
	temp.iMauSo = x.iMauSo * y.iMauSo;
	return temp;
}

PHANSO TichPS(PHANSO x, PHANSO y)
{
	PhanSo temp;
	temp.iTuSo = x.iTuSo * y.iTuSo;
	temp.iMauSo = x.iMauSo * y.iMauSo;
	return temp;
}

PHANSO ThuongPS(PHANSO x , PHANSO y)
{
	PhanSo temp;
	temp.iTuSo = x.iTuSo * y.iMauSo;
	temp.iMauSo = x.iMauSo * y.iTuSo;
	return temp;
}