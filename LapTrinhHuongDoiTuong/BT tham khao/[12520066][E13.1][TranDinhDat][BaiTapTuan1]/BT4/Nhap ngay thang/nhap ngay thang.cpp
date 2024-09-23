#include <iostream>
#include <stdio.h>
#include <conio.h>
using namespace std;

int nhapngay(int Month);
int nhapthang();
int nhapnam();
void tinhngaytieptheo(int Day,int Month,int Year);
int main()
{
	int Day,Month,Year;
	Month=nhapthang();
	Day=nhapngay(Month);
	Year=nhapnam();
	tinhngaytieptheo(Day,Month,Year);
	getch();
	return 0;
}
int nhapthang()
{
	int Month;
	do
	{
		cout<<"Nhap thang"<<endl;
		cin>>Month;
		if(Month>12||Month<1)
			cout<<"Nhap lai"<<endl;
	}
	while(Month>12||Month<1);
	return Month;
}
int nhapngay(int Month)
{
	int Day;
	do
	{
		cout<<"Nhap ngay"<<endl;
		cin>>Day;
		if(Month==2)
		{
			if(Day>29||Day<1)
			cout<<"Nhap lai"<<endl;
		}
		if(Month!=2)
		{
			if(Day>31||Day<1)
				cout<<"Nhap lai"<<endl;
		}
	}
	while(Month==2&&Day>29||Day>31||Day<1);
	return Day;
}
int nhapnam()
{
	int Year;
	cout<<"Nhap nam"<<endl;
	cin>>Year;
	return Year;
}
void tinhngaytieptheo(int Day,int Month,int Year)
{
	switch(Month)
	{
		case 2:
			if(Day<28)
				cout<<"Ngay ke tiep la: "<<Day+1<<"/"<<Month<<"/"<<Year<<endl;
			if(Day==28)
			{
				if(Year%400==0||Year%4==0&&Year%100!=0)
					cout<<"Ngay ke tiep la: "<<Day+1<<"/"<<Month<<"/"<<Year<<endl;
				else
					cout<<"Ngay ke tiep la: "<<1<<"/"<<Month+1<<"/"<<Year<<endl;
			}
			if(Day==29)
			{
				if(Year%4==0)
					cout<<"Ngay ke tiep la: "<<1<<"/"<<Month+1<<"/"<<Year<<endl;
				else
					cout<<"Nam nay thang 2 khong co ngay 29"<<endl;
			}
			break;
		case 1: case 3: case 5: case 7: case 8: case 10:
			if(Day<31)
			{
				cout<<"Ngay ke tiep la: "<<Day+1<<"/"<<Month<<"/"<<Year<<endl;
				break;
			}
			if(Day=31)
				cout<<"Ngay ke tiep la: "<<1<<"/"<<Month+1<<"/"<<Year<<endl;
			break;
		case 4: case 6: case 9: case 11:
			if(Day<30)
			{
				cout<<"Ngay ke tiep la: "<<Day+1<<"/"<<Month<<"/"<<Year<<endl;
				break;
			}
			if(Day=30)
				cout<<"Ngay ke tiep la: "<<1<<"/"<<Month+1<<"/"<<Year<<endl;
			break;
		case 12:
			{
				if(Day<31)
					cout<<"Ngay ke tiep la: "<<Day+1<<"/"<<Month<<"/"<<Year<<endl;
				if(Day=31)
					cout<<"Ngay ke tiep la: "<<1<<"/"<<1<<"/"<<Year+1<<endl;
			}
			break;
	}
}