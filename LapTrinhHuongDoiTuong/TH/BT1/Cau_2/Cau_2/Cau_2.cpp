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
int SoSanhPS(PHANSO x,PHANSO y);

int main()
{
	PHANSO x,y;
	{
		cout<<"Nhap Phan So Thu Nhat:"<<endl;
		Input_ps(x);
		cout<<"Nhap Phan So Thu Hai:"<<endl;
		Input_ps(y);
		cout<<"Phan So Lon Nhat La :";
		int kq = SoSanhPS(x,y);
		if(kq >= 0 )
			Print_ps(x);
		else
			Print_ps(y);
	}
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

int SoSanhPS(PhanSo x,PhanSo y)
{
	float a = (float)x.iTuSo/x.iMauSo;
	float b = (float)y.iTuSo/y.iMauSo;
	if(a>b)
		return 1;
	if(a<b)
		return -1;
	return 0;
}


