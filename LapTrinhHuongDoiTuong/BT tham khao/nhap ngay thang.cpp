#include "StdAfx.h"
#include <iostream>
#include <stdio.h>
#include <conio.h>
using namespace std;

int main()
{
	int a,b,c;
	do
	{
		cout<<"Nhap thang"<<endl;
		cin>>b;
		if(b>12||b<1)
			cout<<"Nhap lai"<<endl;
	}
	while(b>12||b<1);
	do
	{
		cout<<"Nhap ngay"<<endl;
		cin>>a;
		if(b==2)
		{
			if(a>29||a<1)
			cout<<"Nhap lai"<<endl;
		}
		if(b!=2)
		{
			if(a>31||a<1)
				cout<<"Nhap lai"<<endl;
		}
	}
	while(b==2&&a>29||a>31||a<1);
	cout<<"Nhap nam"<<endl;
	cin>>c;
	switch(b)
	{
		case 2:
			if(a<28)
				cout<<"Ngay ke tiep la: "<<a+1<<"/"<<b<<"/"<<c<<endl;
			if(a==28)
			{
				if(c%4==0)
					cout<<"Ngay ke tiep la: "<<a+1<<"/"<<b<<"/"<<c<<endl;
				else
					cout<<"Ngay ke tiep la: "<<1<<"/"<<b+1<<"/"<<c<<endl;
			}
			if(a==29)
			{
				if(c%4==0)
					cout<<"Ngay ke tiep la: "<<1<<"/"<<b+1<<"/"<<c<<endl;
				else
					cout<<"Nam nay thang 2 khong co ngay 29"<<endl;
			}
			break;
		case 1: case 3: case 5: case 7: case 8: case 10:
			if(a<31)
				cout<<"Ngay ke tiep la: "<<a+1<<"/"<<b<<"/"<<c<<endl;
			if(a=31)
				cout<<"Ngay ke tiep la: "<<1<<"/"<<b+1<<"/"<<c<<endl;
			break;
		case 4: case 6: case 9: case 11:
			if(a<30)
				cout<<"Ngay ke tiep la: "<<a+1<<"/"<<b<<"/"<<c<<endl;
			if(a=30)
				cout<<"Ngay ke tiep la: "<<1<<"/"<<b+1<<"/"<<c<<endl;
			break;
		case 12:
			{
				if(a<31)
					cout<<"Ngay ke tiep la: "<<a+1<<"/"<<b<<"/"<<c<<endl;
				if(a=31)
					cout<<"Ngay ke tiep la: "<<1<<"/"<<1<<"/"<<c+1<<endl;
			}
			break;
	}
	getch();
	return 0;
}
