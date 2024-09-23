#pragma once
#include <iostream>
using namespace std;

class DaThuc
{
private:
	double F[100];
	int bac;
public:
	DaThuc(void);
	DaThuc(double G[100]);
	~DaThuc(void);
	int operator () (int x);
	friend DaThuc operator + (DaThuc a,DaThuc b);
	friend DaThuc operator - (DaThuc a,DaThuc b);
	friend istream& operator >> (istream &is, DaThuc &a);
	friend ostream& operator << (ostream &os, DaThuc a);
};

