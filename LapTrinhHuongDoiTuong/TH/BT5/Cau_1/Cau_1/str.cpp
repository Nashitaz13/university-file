#include "str.h"
#include <iostream>
#include <conio.h>
using namespace std;

str::str(void)
{
}
str::~str(void)
{
}
void str::Nhap()
{
	cin.getline(s,100);
}
char str::Xuat()
{
	for (int i=0;s[i]!='\0';i++)
		cout<<s[i];
	return s[100];
}
int str::ChieuDai()
{
	int d;
	d=0;
	for (int i=0;s[i]!='\0';i++)
		d++;
	return d;
}
void str::NoiChuoi(str s2)
{
	int j=0;
	for (int i= this->ChieuDai();i<= this->ChieuDai() + s2.ChieuDai();i++)
	{
		s[i] = s2.s[j];
		j++;
	}
	this->Xuat();
}
void str::DaoChuoi()
{
	int d=0,j=0,i=0;
	for (i=0;s[i]!='\0';i++)
		d++;
	j=d-1;
	for (i=0;s[i]!='\0';i++)
		{
			if(j<=i)
				break;
			DoiCho(s[i],s[j]);
			j--;
		}
	this->Xuat();
}
void str::DoiCho(char &a,char &b)
{
	char temp;
	temp=a;
	a=b;
	b=temp;
}
