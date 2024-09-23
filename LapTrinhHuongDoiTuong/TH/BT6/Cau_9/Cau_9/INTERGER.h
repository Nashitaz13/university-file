#pragma once
#include <iostream>
using namespace std;

class INTERGER
{
private:
	int n;
public:
	INTERGER(void);
	INTERGER(int nn);
	~INTERGER(void);
	friend INTERGER operator + (INTERGER a, INTERGER b);
	friend INTERGER operator - (INTERGER a, INTERGER b);
	friend INTERGER operator * (INTERGER a, INTERGER b);
	friend INTERGER operator / (INTERGER a, INTERGER b);
	friend bool operator == (INTERGER a, INTERGER b);
	friend bool operator != (INTERGER a, INTERGER b);
	friend istream& operator >> (istream &is, INTERGER &in);
	friend ostream& operator << (ostream &os, INTERGER in);
};

