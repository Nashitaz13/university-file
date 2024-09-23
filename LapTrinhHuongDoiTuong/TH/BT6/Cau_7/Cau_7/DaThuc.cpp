#include "DaThuc.h"
#include <math.h>

DaThuc::DaThuc(void)
{
	int i;
	for (i=0;i<=bac;i++)
		F[i]=0;
}
DaThuc::DaThuc(double G[])
{
	int i;
	for (i=0;i<=bac;i++)
		F[i]=G[i];
}
DaThuc::~DaThuc(void)
{
}
DaThuc operator + (DaThuc a,DaThuc b)
{
	int i=0,aa=0,bb=0;
	DaThuc c;
	if (a.bac>b.bac)
		c.bac=a.bac;
	else
		c.bac=b.bac;
	while (i<=c.bac)
	{
		{
			if (a.bac==b.bac)
			{
				c.F[i]=a.F[i-bb]+b.F[i-aa];
				a.bac--;
				b.bac--;
			}
			if (a.bac>b.bac)
			{
				c.F[i]=a.F[i];
				aa++;
				a.bac--;
			}
			if (b.bac>a.bac)
			{
				c.F[i]=b.F[i];
				bb++;
				b.bac--;
			}
		}
		i++;
	}
	return c;
}
DaThuc operator - (DaThuc a,DaThuc b)
{
	int i=0,aa=0,bb=0;
	DaThuc c;
	if (a.bac>b.bac)
		c.bac=a.bac;
	else
		c.bac=b.bac;
	while (i<=c.bac)
	{
		{
			if (a.bac==b.bac)
			{
				c.F[i]=a.F[i-bb]-b.F[i-aa];
				a.bac--;
				b.bac--;
			}
			if (a.bac>b.bac)
			{
				c.F[i]=a.F[i];
				aa++;
				a.bac--;
			}
			if (b.bac>a.bac)
			{
				c.F[i]=b.F[i];
				bb++;
				b.bac--;
			}
		}
		i++;
	}
	return c;
}
int DaThuc::operator () (int x)
{
	double j,s=0;
	int i=0;
	for (i=0;i<=this->bac;i++)
	{
		j=this->bac-i;
		s=s+this->F[i]*(pow(x,j));
	}
	return s;
}
istream& operator >> (istream &is, DaThuc &a)
{
	int i;
	cout<<"Nhap bac cua da thuc: "; is>>a.bac;
	for (i=0;i<a.bac-1;i++)
	{
		cout<<"Nhap he so x^"<<a.bac-i<<": ";
		is>>a.F[i];
	}
	cout<<"Nhap he so x: "; is>>a.F[a.bac-1];
	cout<<"Nhap he so tu do: "; is>>a.F[a.bac];
	return is;
}
ostream& operator << (ostream &os, DaThuc a)
{
	int i;
	for (i=0;i<=a.bac;i++)
	{
		if (i==0)
			os<<a.F[i]<<"x^"<<a.bac-i;
		if (i==a.bac-1)
		{
			if (a.F[i] == 1)
				os<<"+x";
			if (a.F[i]>0&&a.F[i]!=1)
				os<<"+"<<a.F[i]<<"x";
			if (a.F[i] == -1)
				os<<"-x";
			if (a.F[i]<0&&a.F[i]!=-1)
				os<<a.F[i]<<"x";
		}
		if (i==a.bac)
		{
			if (a.F[i]>0)
				os<<"+"<<a.F[i];
			if (a.F[i]<0)
				os<<a.F[i];
		}
		if (a.F[i]==0)
			os<<"";
		else if((i!=a.bac-1)&&(i!=a.bac)&&(i!=0))
		{
			if (a.F[i]==1)
				os<<"+";
			if (a.F[i]==-1)
				os<<"-";
			if (a.F[i]!=1&&a.F[i]!=-1)
			{
				if (a.F[i]>0)
					os<<"+"<<a.F[i];
				else
					os<<a.F[i];
			}
			os<<"x^"<<a.bac-i;
		}
	}
	return os;
}