#include "INTERGER.h"


INTERGER::INTERGER(void)
{
}
INTERGER::INTERGER(int nn)
{
	n=nn;
}
INTERGER::~INTERGER(void)
{
}
INTERGER operator + (INTERGER a, INTERGER b)
{
	return a.n+b.n;
}
INTERGER operator - (INTERGER a, INTERGER b)
{
	return a.n-b.n;
}
INTERGER operator * (INTERGER a, INTERGER b)
{
	return a.n*b.n;
}
INTERGER operator / (INTERGER a, INTERGER b)
{
	return a.n/b.n;
}
bool operator == (INTERGER a,INTERGER b)
{
	return a.n==b.n;
}
bool operator != (INTERGER a,INTERGER b)
{
	return a.n!=b.n;
}
istream& operator >> (istream &is, INTERGER &in)
{
	is>>in.n;
	return is;
}
ostream& operator << (ostream &os, INTERGER in)
{
	os<<in.n;
	return os;
}