#pragma once
#include "Matrix.h"
#include <iostream>
using namespace std;

class CVector
{
private:
	int vt[100],x;
public:
	CVector(void);
	CVector(int a[100]);
	~CVector(void);
	friend CVector operator + (CVector a, CVector b);
	friend CVector operator - (CVector a, CVector b);
	CVector operator * (CMatrix a);
	friend istream& operator >> (istream &is, CVector &a);
	friend ostream& operator << (ostream &os, CVector a);
};