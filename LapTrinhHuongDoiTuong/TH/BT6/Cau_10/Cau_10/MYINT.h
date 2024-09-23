#pragma once
#include <iostream>
using namespace std;

class MYINT
{
private:
	int n;
public:
	MYINT(void);
	MYINT(int nn);
	~MYINT(void);
	friend MYINT operator + (MYINT a, MYINT b);
	friend MYINT operator - (MYINT a, MYINT b);
	friend MYINT operator * (MYINT a, MYINT b);
	friend MYINT operator / (MYINT a, MYINT b);
	friend bool operator == (MYINT a, MYINT b);
	friend bool operator != (MYINT a, MYINT b);
	friend istream& operator >> (istream &is, MYINT &in);
	friend ostream& operator << (ostream &os, MYINT in);
};

