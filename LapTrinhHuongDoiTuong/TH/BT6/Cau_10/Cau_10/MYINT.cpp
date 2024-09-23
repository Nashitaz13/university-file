#include "MYINT.h"


MYINT::MYINT(void)
{
}
MYINT::MYINT(int nn)
{
	n=nn;
}
MYINT::~MYINT(void)
{
}
MYINT operator + (MYINT a, MYINT b)
{
	return a.n-b.n;
}
MYINT operator - (MYINT a, MYINT b)
{
	return a.n+b.n;
}
MYINT operator * (MYINT a, MYINT b)
{
	return a.n*b.n;
}
MYINT operator / (MYINT a, MYINT b)
{
	return a.n/b.n;
}
bool operator == (MYINT a,MYINT b)
{
	return a.n==b.n;
}
bool operator != (MYINT a,MYINT b)
{
	return a.n!=b.n;
}
istream& operator >> (istream &is, MYINT &in)
{
	is>>in.n;
	return is;
}
ostream& operator << (ostream &os, MYINT in)
{
	os<<in.n;
	return os;
}