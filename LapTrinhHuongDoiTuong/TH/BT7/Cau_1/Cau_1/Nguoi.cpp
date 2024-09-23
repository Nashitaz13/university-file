#include "Nguoi.h"

Nguoi::Nguoi(void)
{
	HoTen = "";
	ngaysinh=0;
	thangsinh=0;
	namsinh=0;
}
Nguoi::~Nguoi(void)
{
}
void Nguoi::Nhap()
{
	fflush(stdin);
	cout<<"Ho ten: "; getline(cin,HoTen);
	cout<<"Ngay sinh: "; cin>>ngaysinh;
	cout<<"Thang sinh: "; cin>>thangsinh;
	cout<<"Nam sinh: "; cin>>namsinh;
}
void Nguoi::Xuat()
{
	cout<<"Ho ten: "<<HoTen<<endl;
	cout<<"Ngay sinh: "<<ngaysinh<<"/"<<thangsinh<<"/"<<namsinh<<endl;
}

