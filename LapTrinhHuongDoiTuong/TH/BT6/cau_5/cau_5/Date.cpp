#include "Date.h"


CDate::CDate(void)
{
}
CDate::CDate(int d,int m,int y)
{
	Set(d,m,y);
}
CDate::~CDate(void)
{
}
void CDate::Set(int d,int m,int y)
{
	ngay=d;
	thang=m;
	nam=y;
}
bool NamNhuan(int y)
{
	return ((y%4==0&&y%100!=0)||(y%400==0));
}
int CDate::KTNgay()
{
	int KT=1;
	if(ngay<=0)
		KT=0;
	if(thang<1 || thang>12)
		KT=0;
	if(thang==2 && NamNhuan(nam)==1 && ngay>29)
		KT=0;
	if(thang==2 && NamNhuan(nam)==0 && ngay>28)
		KT=0;
	if(ngay>31 && (thang==1 || thang==3 ||thang==5 ||thang==7 ||thang==8 ||thang==10||thang==12))
		KT=0;
	if(ngay>30 && (thang==4 ||thang==6||thang==9||thang==11))
		KT=0;
	return KT;
}
CDate operator + (CDate a,int d)
{
	CDate b;
	b.ngay=a.ngay+d;
	b.thang=a.thang;
	b.nam=a.nam;
	do
	{
		if(b.thang==1 || b.thang==3 || b.thang==5 || b.thang==7|| b.thang==8|| b.thang==10|| b.thang==12)
		{
			if(b.ngay>31)
			{
				b.ngay-=31;
				b.thang++;
			}
		}
		if(b.thang==4 || b.thang==6 || b.thang==9 || b.thang==11)
		{
			if(b.ngay>30)
			{
				b.ngay-=30;
				b.thang++;
			}
		}
		if(b.thang==2)
		{
			if(NamNhuan(b.nam))
			{
				if(b.ngay>29)
				{
					b.ngay-=29;
					b.thang++;
				}
			}
			else
			{
				if(b.ngay>28)
				{
					b.ngay-=28;
					b.thang++;
				}
			}
		}
		if(b.thang>12)
		{
			b.thang-=12;
			b.nam++;
		}
	}
	while(b.KTNgay()==0);
	return b;
}
CDate operator - (CDate a,int d)
{
	CDate b;
	b.ngay=a.ngay-d;
	b.thang=a.thang;
	b.nam=a.nam;
	do
	{
		if(b.thang==1 || b.thang==3 || b.thang==5 || b.thang==7|| b.thang==8|| b.thang==10|| b.thang==12)
		{
			if(b.ngay<=0)
			{
				b.ngay+=31;
				b.thang--;
			}
		}
		if(b.thang==4 || b.thang==6 || b.thang==9 || b.thang==11)
		{
			if(b.ngay<=0)
			{
				b.ngay+=30;
				b.thang--;
			}
		}
		if(b.thang==2)
		{
			if(NamNhuan(b.nam))
			{
				if(b.ngay<=0)
				{
					b.ngay+=29;
					b.thang--;
				}
			}
			else
			{
				if(b.ngay<=0)
				{
					b.ngay+=28;
					b.thang--;
				}
			}
		}
		if(b.thang<=0)
		{
			b.thang+=12;
			b.nam--;
		}
	}
	while(b.KTNgay()==0);
	return b;
}
CDate operator ++ (CDate a)
{
	CDate b;
	b.ngay=a.ngay;
	b.thang=a.thang;
	b.nam=a.nam;
	return b+1;
}
CDate operator -- (CDate a)
{
	CDate b;
	b.ngay=a.ngay;
	b.thang=a.thang;
	b.nam=a.nam;
	return b-1;
}
int operator - (CDate a, CDate b)
{
	int m,n,i,j,k,d=0;
	m=DateToDay(a.ngay,a.thang,a.nam);
	n=DateToDay(b.ngay,b.thang,b.nam);
	if (a.nam>b.nam)
	{
		i=a.nam;
		j=b.nam;
	}
	else
	{
		i=b.nam;
		j=a.nam;
	}
	for (k=i;k<=j;k++)
	{
		if (NamNhuan(k))
		{
			if(i==j)
				d=0;
			else
				d=d+1;
		}
	}
	if (m>n)
		return (m-n+d);
	else
		return (n-m+d);
}
int DateToDay(int d,int m,int y)
{
	int Tongngay;
	Tongngay = 365*y;
	if(NamNhuan(y))
	{
		if (m==1)
			Tongngay = Tongngay+31+d;
		if (m==2)
			Tongngay = Tongngay+31*2+d;
		if (m==3)
			Tongngay = Tongngay+31*2+29+d;
		if (m==4)
			Tongngay = Tongngay+31*3+29+d;
		if (m==5)
			Tongngay = Tongngay+31*3+30+29+d;
		if (m==6)
			Tongngay = Tongngay+31*4+30+29+d;
		if (m==7)
			Tongngay = Tongngay+31*4+30*2+29+d;
		if (m==8)
			Tongngay = Tongngay+31*5+30*2+29+d;
		if (m==9)
			Tongngay = Tongngay+31*6+30*2+29+d;
		if (m==10)
			Tongngay = Tongngay+31*6+30*3+29+d;
		if (m==11)
			Tongngay = Tongngay+31*7+30*3+29+d;
		if (m==12)
			Tongngay = Tongngay+31*7+30*4+29+d;
	}
	if (!NamNhuan(y))
	{
		if (m==1)
			Tongngay = Tongngay+31+d;
		if (m==2)
			Tongngay = Tongngay+31*2+d;
		if (m==3)
			Tongngay = Tongngay+31*2+28+d;
		if (m==4)
			Tongngay = Tongngay+31*3+28+d;
		if (m==5)
			Tongngay = Tongngay+31*3+30+28+d;
		if (m==6)
			Tongngay = Tongngay+31*4+30+28+d;
		if (m==7)
			Tongngay = Tongngay+31*4+30*2+28+d;
		if (m==8)
			Tongngay = Tongngay+31*5+30*2+28+d;
		if (m==9)
			Tongngay = Tongngay+31*6+30*2+28+d;
		if (m==10)
			Tongngay = Tongngay+31*6+30*3+28+d;
		if (m==11)
			Tongngay = Tongngay+31*7+30*3+28+d;
		if (m==12)
			Tongngay = Tongngay+31*7+30*4+28+d;
	}
	return Tongngay;
}
istream& operator >> (istream &is, CDate &date)
{
	do
	{
	cout<<"Nhap ngay: ";
	is>>date.ngay;
	cout<<"Nhap thang: ";
	is>>date.thang;
	cout<<"Nhap nam: ";
	is>>date.nam;
	if ((date.thang==2&&NamNhuan(date.nam)&&date.ngay>29)||(date.thang==2&&(!(NamNhuan(date.nam)))&&date.ngay>28)||((date.thang==1||date.thang==3||date.thang==5||date.thang==7||date.thang==8||date.thang==10||date.thang==12)&&date.ngay>31)||((date.thang==4||date.thang==6||date.thang==9||date.thang==11)&&date.ngay>30)||date.ngay<1)
		cout<<"Khong co ngay "<<date.ngay<<" thang "<<date.thang<<" nam "<<date.nam<<". Nhap lai!"<<endl;
	}
	while (((date.thang==2&&NamNhuan(date.nam)&&date.ngay>29)||(date.thang==2&&(!(NamNhuan(date.nam)))&&date.ngay>28))||((date.thang==1||date.thang==3||date.thang==5||date.thang==7||date.thang==8||date.thang==10||date.thang==12)&&date.ngay>31)||((date.thang==4||date.thang==6||date.thang==9||date.thang==11)&&date.ngay>30)||date.ngay<1);
	return is;
}
ostream& operator << (ostream &os, CDate date)
{
	os<<date.ngay<<"/"<<date.thang<<"/"<<date.nam;
	return os;
}