#include <iostream>
#include <conio.h>
using namespace std;

class Time
{
private:
	int h,m,s;
public:
	void Nhap();
	void Xuat();
};

void main()
{
	Time tg;
	tg.Nhap();
	tg.Xuat();
	getch();
}

void Time::Nhap()
{
	do
	{
	cout<<"Nhap thoi gian:"<<endl;
	cout<<"Gio: "; cin>>h;
	cout<<"Phut: "; cin>>m;
	cout<<"Giay: "; cin>>s;
	if (h<0||h>=24||m<0||m>=60||s<0||s>=60)
		cout<<"Thoi gian khong hop le. Nhap lai!"<<endl;
	}
	while (h<0||h>=24||m<0||m>=60||s<0||s>=60);
}
void Time::Xuat()
{
	cout<<"Time: "<<h<<":"<<m<<":"<<s;
}

