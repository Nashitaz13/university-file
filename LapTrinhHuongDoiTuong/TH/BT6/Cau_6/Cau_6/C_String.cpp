#include "C_String.h"

C_String::C_String(void)
{
	s=new char[100];
}
C_String::~C_String(void)
{
}
int C_String::ChieuDai()
{
	int d;
	d=0;
	for (int i=0;s[i]!='\0';i++)
		d++;
	return d;
}
C_String operator + (C_String a,C_String b)
{
	int j=0;
	C_String c;
	for (int i= a.ChieuDai();i<= a.ChieuDai() + b.ChieuDai();i++)
	{
		a.s[i] = b.s[j];
		j++;
	}
	return a;
}
C_String C_String::operator = (char *ss)
{
	this->s=ss;
	return *this;
}
bool operator == (C_String a,C_String b)
{
	return atof(a.s)==atof(b.s);
}
bool operator != (C_String a,C_String b)
{
	return atof(a.s)!=atof(b.s);
}
istream& operator >> (istream &is, C_String &str)
{
	is>>str.s;
	return is;
}
ostream& operator << (ostream &os, C_String str)
{
	os<<str.s;
	return os;
}
