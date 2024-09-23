#include "C_Time.h"
#include <time.h>

C_Time::C_Time(void)
{
}
C_Time::C_Time(int h,int m,int s)
{
	Set(h,m,s);
}
C_Time::~C_Time(void)
{
}
void C_Time::Set(int h,int m,int s)
{
	gio=h;
	phut=m;
	giay=s;
}
int C_Time::TimeToSecond(int h,int m,int s)
{
	int TongGiay;
	TongGiay=h*3600+m*60+s;
	return TongGiay;
}
C_Time C_Time::SecondToTime(int s)
{
	this->gio = s/3600;
	this->phut = (s-(this->gio*3600))/60;
	this->giay = (s-(this->gio*3600))-(this->phut*60);
	return *this;
}
C_Time operator + (C_Time a, int ss)
{
	C_Time b;
	int Tong;
	Tong = b.TimeToSecond(a.gio,a.phut,a.giay) + ss;
	b.SecondToTime(Tong);
	return b;
}
C_Time operator - (C_Time a, int ss)
{
	C_Time b;
	int Hieu;
	Hieu = b.TimeToSecond(a.gio,a.phut,a.giay) - ss;
	b.SecondToTime(Hieu);
	return b;
}
C_Time operator - (C_Time a, C_Time b)
{
	C_Time c;
	int Hieu;
	int t1 = c.TimeToSecond(a.gio,a.phut,a.giay);
	int t2 = c.TimeToSecond(b.gio,b.phut,b.giay);
	if (t1>t2)
		Hieu = t1 - t2;
	else
		Hieu = t2 - t1;
	c.SecondToTime(Hieu);
	return c;
}
C_Time operator ++ (C_Time a)
{
	if (a.phut>=59)
	{
		a.gio++;
		a.phut=-1;
	}
	if (a.giay>=59)
	{
		a.phut++;
		a.giay=-1;
	}
	a.giay ++;
	return a;
}
C_Time operator -- (C_Time a)
{
	if (a.phut<=0)
	{
		a.gio--;
		a.phut=60;
	}
	if (a.giay<=0)
	{
		a.phut--;
		a.giay=60;
	}
	a.giay --;
	return a;
}
istream& operator >> (istream &is, C_Time &t)
{
	do
	{
		cout<<"Nhap gio: "; is>>t.gio;
		cout<<"Nhap phut: "; is>>t.phut;
		cout<<"Nhap giay: "; is>>t.giay;
		if (t.gio<0||t.gio>23||t.phut<0||t.phut>59||t.giay<0||t.giay>59)
			cout<<"Thoi gian khong hop le. Nhap lai!"<<endl;
	}
	while (t.gio<0||t.gio>23||t.phut<0||t.phut>59||t.giay<0||t.giay>59);
	return is;
}
ostream& operator << (ostream &os, C_Time t)
{
	os<<t.gio<<" gio "<<t.phut<<" phut "<<t.giay<<" giay ";
	return os;
}
void C_Time::DongHo()
{
	do
	{
	system("cls");
	*this=*this+1;
	cout<<this->gio<<":"<<this->phut<<":"<<this->giay;
	delay(1000);
	}
	while (true);
}
void C_Time::delay(int miliseconds)
{
     if(miliseconds <= 0)
     {
         return;
     }
     clock_t start, finish;
     start = clock();
     finish = start;
     while(finish - start < miliseconds)
     {
         finish = clock();
     }
}
