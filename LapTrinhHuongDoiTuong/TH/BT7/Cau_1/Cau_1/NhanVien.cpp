#include "NhanVien.h"

NhanVien::NhanVien(void)
{
}
NhanVien::~NhanVien(void)
{
}
void NhanVien::Nhap(int luongcb)
{
	Nguoi::Nhap();
	do
	{
		cout<<"Ma nhan vien [Nhan vien san xuat(0), Nhan vien van phong(1)]: "; cin>>manv;
		if (manv==0)
		{
			cout<<"So san pham: "; cin>>sosp;
			luong1=luongcb+sosp*5000;
		}
		if (manv==1)
		{
			cout<<"So ngay lam viec: "; cin>>snlv;
			luong2=snlv*100000;
		}
		if (manv!=0&&manv!=1)
			cout<<"Khong hop le. Nhap lai!"<<endl;
	}
	while (manv!=0&&manv!=1);
}
void NhanVien::Xuat()
{
	//cout<<"Ho Ten: "<<HoTen<<endl;
	//cout<<"Ngay sinh: "<<ngaysinh<<"/"<<thangsinh<<"/"<<namsinh<<endl;
	Nguoi::Xuat();
	if (manv==0)
	{
		cout<<"Loai nhan vien: Nhan vien san xuat."<<endl;
		cout<<"Luong: "<<luong1<<endl;
	}
	if (manv==1)
	{
		cout<<"Loai nhan vien: Nhan vien van phong."<<endl;
		cout<<"Luong: "<<luong2<<endl;
	}
}
