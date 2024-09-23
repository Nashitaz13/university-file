#include "SoPhuc.h"
#include <iostream>
using namespace std;

SoPhuc::SoPhuc(void)
{
}
SoPhuc::SoPhuc(float t,float a)
{
	Set(t,a);
}
SoPhuc::SoPhuc(float t)
{
	Set(t,0);
}
SoPhuc::~SoPhuc(void)
{
}
void SoPhuc::Set(float t,float a)
{
	thuc=t;
	ao=a;
}
SoPhuc operator + (SoPhuc a,SoPhuc b)
{
	return SoPhuc(a.thuc+b.thuc,a.ao+b.ao);
}
SoPhuc operator - (SoPhuc a, SoPhuc b)
{
	return SoPhuc(a.thuc-b.thuc,a.ao-b.ao);
}
SoPhuc operator * (SoPhuc a, SoPhuc b)
{
	return SoPhuc(a.thuc*b.thuc-a.ao*b.ao,a.thuc*b.ao+a.ao*b.thuc);
}
SoPhuc operator / (SoPhuc a, SoPhuc b)
{
	SoPhuc c;
	float temp=(b.thuc*b.thuc+b.ao*b.ao);
	c.thuc=(a.thuc*b.thuc+a.ao*b.ao)/temp;
	c.ao=(b.thuc*a.ao-a.thuc*b.ao)/temp;
	return c;
}
bool operator == (SoPhuc a, SoPhuc b)
{
	return ((a.thuc==b.thuc)&&(a.ao==b.ao));
}
bool operator != (SoPhuc a, SoPhuc b)
{
	return ((a.thuc!=b.thuc)||(a.ao!=b.ao));
}
SoPhuc operator ! (SoPhuc a)
{
	return SoPhuc(-a.thuc,-a.ao);
}
istream& operator >> (istream &is, SoPhuc &p)
{
	cout<<"Nhap phan thuc: ";
	is>>p.thuc;
	cout<<"Nhap phan ao: ";
	is>>p.ao;
	return is;
}
ostream& operator << (ostream &os, SoPhuc p)
{
	if(p.thuc==0)
	{
		if(p.ao==1)
			os<<"(i)";
		if(p.ao==-1)
			os<<"(-i)";
		if(p.ao!=1&&p.ao!=-1)
			os<<"("<<p.ao<<"i)";
	}
	if(p.thuc!=0.0)
	{
		if((p.ao>0&&p.ao<1)||p.ao>1)
			os<<"("<<p.thuc<<"+"<<p.ao<<"i)";
		if(p.ao==1)
			os<<"("<<p.thuc<<"+"<<"i)";
		if(p.ao==0)
			os<<p.thuc;
		if(p.ao==-1)
			os<<"("<<p.thuc<<"-i)";
		if((p.ao>-1.0&&p.ao<0)||p.ao<-1)
			os<<"("<<p.thuc<<p.ao<<"i)";
	}
	return os;
}
