#include "Matrix.h"

CMatrix::CMatrix(void)
{
}
CMatrix::CMatrix(int a[100][100])
{
	int i,j;
	for (i=0;i<m;i++)
		for (j=0;j<n;j++)
			mt[i][j]=a[i][j];

}
CMatrix::~CMatrix(void)
{
}
CMatrix operator + (CMatrix a, CMatrix b)
{
	CMatrix c;
	int i,j;
	if (a.m==b.m && a.n==b.n)
	{
		c.m=a.m;
		c.n=a.n;
		for (i=0;i<a.m;i++)
			for (j=0;j<a.n;j++)
				c.mt[i][j]=a.mt[i][j]+b.mt[i][j];
	}
	else
		cout<<"Khong tinh duoc ";
	return c;
}
CMatrix operator - (CMatrix a, CMatrix b)
{
	CMatrix c;
	int i,j;
	if (a.m==b.m && a.n==b.n)
	{
		c.m=a.m;
		c.n=a.n;
		for (i=0;i<a.m;i++)
			for (j=0;j<a.n;j++)
				c.mt[i][j]=a.mt[i][j]-b.mt[i][j];
	}
	else
		cout<<"Khong tinh duoc ";
	return c;
}
CMatrix operator * (CMatrix a, CMatrix b)
{
	CMatrix c;
	int i,j,p;
	if(a.n==b.m)
	{
		c.m=a.m;
		c.n=b.n;
		for(i=0;i<a.m;i++)
		{
			for(j=0;j<b.n;j++)
			{
				c.mt[i][j]=0;
				for(p=0;p<a.n;p++)
					c.mt[i][j]+=a.mt[i][p] * b.mt[p][j];
			}
		}
	}
	if(a.m==b.n)
	{
		c.m=b.m;
		c.n=a.n;
		for(i=0;i<b.m;i++)
		{
			for(j=0;j<a.n;j++)
			{
				c.mt[i][j]=0;
				for(p=0;p<b.n;p++)
					c.mt[i][j]+=b.mt[i][p] * a.mt[p][j];
			}
		}
	}
	if(a.m!=b.n && a.n!=b.m)
		cout<<"Khong tinh duoc ";
	return c;
}
istream& operator >> (istream &is, CMatrix &a)
{
	int i,j;
	cout<<"Nhap so dong: "; is>>a.m;
	cout<<"Nhap so cot: "; is>>a.n;
	for (i=0;i<a.m;i++)
		for (j=0;j<a.n;j++)
		{
			cout<<"a["<<i+1<<"]"<<"["<<j+1<<"]: ";
			is>>a.mt[i][j];
		}
	return is;
}
ostream& operator << (ostream &os, CMatrix a)
{
	int i,j;
	for (i=0;i<a.m;i++)
	{
		for (j=0;j<a.n;j++)
		{
			os<<a.mt[i][j]<<"\t";
		}
		os<<"\n";
	}
	return os;
}
