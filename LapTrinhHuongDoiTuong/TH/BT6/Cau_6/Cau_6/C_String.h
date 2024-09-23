#pragma once
#include <iostream>
using namespace std;

class C_String
{
private:
	char *s;
public:
	C_String(void);
	operator double();
	int ChieuDai();
	friend C_String operator + (C_String a,C_String b);
	C_String operator = (char *ss);
	friend bool operator == (C_String a,C_String b);
	friend bool operator != (C_String a,C_String b);
	friend istream& operator >> (istream &is, C_String &str); 
	friend ostream& operator << (ostream &os, C_String str); 
	~C_String(void);
};

