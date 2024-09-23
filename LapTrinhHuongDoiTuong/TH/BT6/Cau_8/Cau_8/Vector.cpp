#include "Vector.h"

CVector::CVector(void)
{
}
CVector::CVector(int a[100])
{
	int i;
	for (i=0;i<x;i++)
			vt[i]=a[i];
}
CVector::~CVector(void)
{
}
CVector operator + (CVector a, CVector b)
{
	CVector c;
	int i;
	if (a.x==b.x)
	{
		c.x=a.x;
		for (i=0;i<a.x;i++)
			c.vt[i]=a.vt[i]+b.vt[i];
	}
	else
		cout<<"Khong tinh duoc ";
	return c;
}
CVector operator - (CVector a, CVector b)
{
	CVector c;
	int i;
	if (a.x==b.x)
	{
		c.x=a.x;
		for (i=0;i<a.x;i++)
			c.vt[i]=a.vt[i]-b.vt[i];
	}
	else
		cout<<"Khong tinh duoc ";
	return c;
}
CVector CVector::operator * (CMatrix a)
{
	CVector y;
	if(x==a.m&&x==a.n)
	{
		y.x=x;
		for(int i=0;i<x;i++)
		{
			y.vt[i]=0;
			for(int j=0;j<x;j++)
				y.vt[i]+=vt[j]*a.mt[j][i];
		}
	}
	else
	{
		cout<<"Khong tinh duoc ";
	}
	return y;
}
istream& operator >> (istream &is, CVector &a)
{
	int i;
	cout<<"Nhap so chieu: "; is>>a.x;
	for (i=0;i<a.x;i++)
	{
			cout<<"x"<<i+1<<": ";
			is>>a.vt[i];
	}
	return is;
}
ostream& operator << (ostream &os, CVector a)
{
	int i;
	for (i=0;i<a.x;i++)
	{
		if (i==0)
			os<<"("<<a.vt[i]<<",";
		if (i==a.x-1)
			os<<a.vt[i]<<")";
		if (i!=0 && i!=a.x-1)
			os<<a.vt[i]<<",";
	}
	return os;
}
