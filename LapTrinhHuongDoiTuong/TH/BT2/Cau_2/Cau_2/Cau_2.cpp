#include "stdafx.h"
#include <iostream>
#include <conio.h>
using namespace std;
class SoPhuc
{
private:
	float thuc,ao;
public:
	void Set(float t,float a);
	void Nhap();
	void Xuat();
	SoPhuc Cong(SoPhuc p);
	SoPhuc Tru(SoPhuc p);
	SoPhuc Nhan(SoPhuc p);
	SoPhuc Chia(SoPhuc p);
};
int main()
{
	SoPhuc p1,p2;
	cout<<"Nhap So Phuc A: "<<endl;
	p1.Nhap();
	cout<<"Nhap So Phuc B: "<<endl;
	p2.Nhap();
	SoPhuc kq1=p1.Cong(p2);
	SoPhuc kq2=p1.Tru(p2);
	SoPhuc kq3=p1.Nhan(p2);
	SoPhuc kq4=p1.Chia(p2);
	cout<<"Phep Cong: "; p1.Xuat(); cout<<" + "; p2.Xuat(); cout<<" = "; kq1.Xuat(); cout<<endl;
	cout<<"Phep Tru : "; p1.Xuat(); cout<<" - "; p2.Xuat(); cout<<" = "; kq2.Xuat(); cout<<endl;
	cout<<"Phep Nhan: "; p1.Xuat(); cout<<" * "; p2.Xuat(); cout<<" = "; kq3.Xuat(); cout<<endl;
	cout<<"Phep Chia: "; p1.Xuat(); cout<<" / "; p2.Xuat(); cout<<" = "; kq4.Xuat(); cout<<endl;
	getch();
}
void SoPhuc::Set(float t,float a)
{
	thuc=t;
	ao=a;
}
void SoPhuc::Nhap()
{
	cout<<"Nhap phan thuc : "<<endl;
	cin >> thuc;
	cout<<"Nhap phan ao : "<<endl;
	cin>> ao;
}
void SoPhuc::Xuat()
{
	cout<<"("<<thuc<<","<<ao<<")";
}
SoPhuc SoPhuc::Cong(SoPhuc p)
{
	SoPhuc kq1;
	float t=thuc+p.thuc;
	float a=ao+p.ao;
	kq1.Set(t,a);
	return kq1;
}
SoPhuc SoPhuc::Tru(SoPhuc p)
{
	SoPhuc kq2;
	float t=thuc-p.thuc;
	float a=ao-p.ao;
	kq2.Set(t,a);
	return kq2;
}
SoPhuc SoPhuc::Nhan(SoPhuc p)
{
	SoPhuc kq3;
	float t=thuc*p.thuc-ao*p.ao;
	float a=thuc*p.ao+ao*p.thuc;
	kq3.Set(t,a);
	return kq3;
}
SoPhuc SoPhuc::Chia(SoPhuc p)
{
	SoPhuc kq4;
	float t=(thuc*p.thuc+ao*p.ao)/(p.thuc*p.thuc+p.ao*p.ao);
	float a=(p.thuc*ao-thuc*p.ao)/(p.thuc*p.thuc+p.ao*p.ao);
	kq4.Set(t,a);
	return kq4;
}
