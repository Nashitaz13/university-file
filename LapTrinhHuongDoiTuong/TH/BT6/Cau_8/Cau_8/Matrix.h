#pragma once
#include <iostream>
using namespace std;

class CMatrix
{
private:
	int mt[100][100],m,n;
public:
	CMatrix(void);
	CMatrix(int a[100][100]);
	~CMatrix(void);
	friend CMatrix operator + (CMatrix a, CMatrix b);
	friend CMatrix operator - (CMatrix a, CMatrix b);
	friend CMatrix operator * (CMatrix a, CMatrix b); 
	friend istream& operator >> (istream &is, CMatrix &a);
	friend ostream& operator << (ostream &os, CMatrix a);
	friend class CVector;
};

