#include "StdAfx.h"
#include <conio.h>
#include <stdio.h>
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
void RutGonPS(PHANSO &x);

int main()
{
	PHANSO x;
	cout<<"Nhap Phan So :"<<endl;
	Input_ps(x);
	RutGonPS(x);
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
	cout<<"Phan so rut gon la: "<<endl;
	Print_ps (x);
}

