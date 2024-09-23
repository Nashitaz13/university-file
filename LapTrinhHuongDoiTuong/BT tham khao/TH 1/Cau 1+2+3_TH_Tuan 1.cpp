/*
Ho ten : Nguyen Van Canh
MSSV : 12520034
Lop : IT002.E13
BAI TAP THUC HANH TUAN 1
1. Viết chương trình nhập vào một phân số, rút gọn phân số và xuất kết quả.
2. Viết chương trình nhập vào hai phân số, tìm phân số lớn nhất và xuất kết quả.
3. Viết chương trình nhập vào hai phân số. Tính tổng, hiệu, tích, thương giữa chúng và xuất kết quả.
*/
#include "stdafx.h"

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

void menu();
void Input_ps(PHANSO &x);
void Print_ps(PHANSO x);
// phan loai phan so am , duong , = 0
int Classification_ps(PHANSO x); 
// so sanh 2 phan so
int Compare_ps(PHANSO x,PHANSO y);
//tinh tong hai phan so
PHANSO Total_ps(PHANSO x, PHANSO y);
//tinh hieu 2 phan so
PHANSO Subtraction_ps(PHANSO x, PHANSO y);
//tinh tich 2 phan so
PHANSO Multiplication_ps(PHANSO x, PHANSO y);
//chia 2 phan so
PHANSO Division_ps(PHANSO x,PHANSO y);
// rut gon phan so
void Reduced_ps(PHANSO &x);

int main()
{
	PHANSO x,y;

	int c;
	menu();
	do
	{
		cout<<"NHAP LUA CHON !!!"<<endl;
		cin>>c;
		switch(c)
		{
		case 0:
			{
				exit(1);
				break;
			}
		case 1:
			{
				cout<<"Nhap Phan So :"<<endl;
				Input_ps(x);
				Reduced_ps(x);
				break;
			}
		case 2:
			{
				cout<<"Nhap Phan So Thu Nhat:"<<endl;
				Input_ps(x);
				cout<<"Nhap Phan So Thu Hai:"<<endl;
				Input_ps(y);
				cout<<"PHAN SO LON NHAT LA :";
				int kq = Compare_ps(x,y);
				if(kq >= 0 )
					Print_ps(x);
				else
					Print_ps(y);
				break;
			}
		case 3:
			{
				cout<<"Nhap Phan So Thu Nhat:"<<endl;
				Input_ps(x);
				cout<<"Nhap Phan So Thu Hai:"<<endl;
				Input_ps(y);
				PHANSO kq1 = Total_ps(x,y);
				PHANSO kq2 = Subtraction_ps(x,y);
				PHANSO kq3 = Multiplication_ps(x,y);
				cout<<"Tong 2 phan so la :";
				Reduced_ps(kq1);
				cout<<"Hieu 2 phan so la : ";
				Reduced_ps (kq2);
				cout<<"Tich cua 2 phan so la : ";
				Reduced_ps(kq3);
				PHANSO kq4 = Division_ps (x,y);
				cout<<"Thuong cua 2 phan so la : ";
				Reduced_ps(kq4);
				break;
			}
		default:
			cout<<"SAI CHUC NANG !!!";
			break;
		}
	}
	while(1);
	system("cls");
	return 0;
}

void menu()
{
	cout<<"\nCHUONG TRINH PHAN SO!!!";
	cout<<"\n0:EXIT";
	cout<<"\n1:Rut Gon Phan So";
	cout<<"\n2:So sanh 2 phan so";
	cout<<"\n3:Tinh tong_hieu_tich_thuong 2 phan so";
	cout<<"\n";
}

void Input_ps(PHANSO &x)
{
	cout<<"Nhap tu so : "<<endl;
	cin >> x.iTuSo;
	cout<<"Nhap mau so : "<<endl;
	cin>> x.iMauSo;
}

void Print_ps (PHANSO x)
{
	cout<<x.iTuSo<<"/"<<x.iMauSo<<endl;
}

//rut gon phan so
void Reduced_ps(PHANSO &x)
{
	int a = abs(x.iTuSo);
	int b = abs(x.iMauSo);
	//tim ucln cua tu va mau
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

//Phan loai phan so
int Classification_ps(PHANSO x)
{
	if(x.iTuSo * x.iMauSo < 0)return -1;
	else
		if(x.iTuSo * x.iMauSo > 0)return 1;
	return 0;
}
 // So Sanh 2 phan so
int Compare_ps(PhanSo x,PhanSo y)
{
	float a = (float)x.iTuSo/x.iMauSo;
	float b = (float)y.iTuSo/y.iMauSo;
	if(a>b)
		return 1;
	if(a<b)
		return -1;
	return 0;
}

//tinh tong 2 phan so
PHANSO Total_ps(PHANSO x,PHANSO y)
{
	PHANSO temp;
	temp.iTuSo = x.iTuSo * y.iMauSo + x.iMauSo * y.iTuSo;
	temp.iMauSo = x.iMauSo * y.iMauSo;
	return temp;
}

//tinh hieu 2 phan so
PHANSO Subtraction_ps(PHANSO x, PHANSO y)
{
	PhanSo temp;
	temp.iTuSo = x.iMauSo * y.iMauSo - x.iMauSo * y.iTuSo;
	temp.iMauSo = x.iMauSo * y.iMauSo;
	return temp;
}

//tinh tich 2 phan so
PHANSO Multiplication_ps(PHANSO x, PHANSO y)
{
	PhanSo temp;
	temp.iTuSo = x.iTuSo * y.iTuSo;
	temp.iMauSo = x.iMauSo * y.iMauSo;
	return temp;
}

//chia 2 phan so
PHANSO Division_ps(PHANSO x , PHANSO y)
{
	PhanSo temp;
	temp.iTuSo = x.iTuSo * y.iMauSo;
	temp.iMauSo = x.iMauSo * y.iTuSo;
	return temp;
}