#include "stdafx.h"
#include <iostream>
#include <stdio.h>
#include <conio.h>
using namespace std;

typedef struct HocSinh
{
	char HoTen[25];
	float Van,Toan,DTB;
}hs;

void NhapThongTinHocSinh(hs &x);
void XuatDTB(hs x);
float TinhDTB(hs x);
int main()
{
	hs x;
	NhapThongTinHocSinh(x);
	x.DTB=TinhDTB(x);
	XuatDTB(x);
	getch();
	return 0;
}
void NhapThongTinHocSinh(hs &x)
{
	cout<<"Ho ten hoc sinh: ";
	cin.get(x.HoTen,30);
	cout<<"Diem toan: ";
	cin>>x.Toan;
	cout<<"Diem van: ";
	cin>>x.Van;
}
void XuatDTB(hs x)
{
	cout<<"Diem trung binh: "<<x.DTB<<endl;
}
float TinhDTB(hs x)
{
	x.DTB=(x.Toan+x.Van)/2;
	return x.DTB;
}
