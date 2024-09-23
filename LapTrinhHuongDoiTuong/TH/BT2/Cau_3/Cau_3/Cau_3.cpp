#include "stdafx.h"
#include <iostream>
#include <conio.h>
using namespace std;
class Candidate
{
protected:
	int MSSV,ngay,thang,nam;
	float toan,van,anh,t;
	char hoten[30];
public:
	float Tong (float);
	void Nhap();
	void Xuat();
};
class TestCandidate:public Candidate
{
protected:
	int i,n,d;
public:
	void Test();
};
void main()
{
	TestCandidate testsv;
	testsv.Test();
}
float Candidate::Tong(float t)
{
	t=toan+van+anh;
	return t;
}
void TestCandidate::Test()
{
	Candidate sv[100];
	d=0;
	cout<<"Nhap so sinh vien: "; cin>>n;
	for (i=1;i<=n;i++)
	{
		cout<<"\nSTT: "<<i<<endl;
		sv[i].Nhap();
	}
	cout<<"\nCac thi sinh co tong diem tren 15: "<<endl;
	for (i=1;i<=n;i++)
	{
		if (sv[i].Tong(t) > 15)
		{
			sv[i].Xuat();
			d+=1;
		}
	}
	if (d==0) cout<<"Khong co thi sinh nao!";
	getch();
}
void Candidate::Nhap()
{
	cout<<"\nMSSV: "; cin>>MSSV;
	cout<<"Ho va Ten: "; cin.ignore(); cin.getline (hoten,30);
	cout<<"Ngay sinh: "; cin>>ngay;
	cout<<"Thang sinh: "; cin>>thang;
	cout<<"Nam sinh: "; cin>>nam;
	cout<<"Diem Toan: "; cin>>toan;
	cout<<"Diem Van: "; cin>>van;
	cout<<"Diem Anh: "; cin>>anh;
}
void Candidate::Xuat()
{
	cout<<"\nMSSV: "<<MSSV<<endl;
	cout<<"Ho va Ten: "<<hoten<<endl;
	cout<<"Ngay thang nam sinh: "<<ngay<<"/"<<thang<<"/"<<nam<<endl;
	cout<<"Diem Toan: "<<toan<<endl;
	cout<<"Diem Van: "<<van<<endl;
	cout<<"Diem Anh: "<<anh<<endl;
	cout<<"Diem Tong: "<<Tong(t)<<endl;
}


