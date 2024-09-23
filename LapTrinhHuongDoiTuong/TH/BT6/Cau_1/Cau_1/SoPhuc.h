#pragma once
#include <iostream>
using namespace std;
class SoPhuc
{
private:
	float thuc, ao;
public:
	SoPhuc(void);
	SoPhuc(float t,float a);
	SoPhuc(float t);
	~SoPhuc(void);
	void Set(float t,float a);
	friend SoPhuc operator + (SoPhuc a, SoPhuc b);
	friend SoPhuc operator - (SoPhuc a, SoPhuc b);
	friend SoPhuc operator * (SoPhuc a, SoPhuc b);
	friend SoPhuc operator / (SoPhuc a, SoPhuc b);
	friend bool operator == (SoPhuc a, SoPhuc b);
	friend bool operator != (SoPhuc a, SoPhuc b);
	friend SoPhuc operator ! (SoPhuc a);
	friend istream& operator >> (istream &is, SoPhuc &p);
	friend ostream& operator << (ostream &os, SoPhuc p);
};

