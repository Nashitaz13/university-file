#include "Nguoi.h"

Nguoi::Nguoi(void)
{
	HoTen="";
	GioiTinh="";
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
	fflush(stdin);
	cout<<"Gioi tinh: "; getline(cin,GioiTinh);
}
void Nguoi::Xuat()
{
	cout<<"Ho ten: "<<HoTen<<endl;
	cout<<"Ngay sinh: "<<ngaysinh<<"/"<<thangsinh<<"/"<<namsinh<<endl;
	cout<<"Gioi tinh: "<<GioiTinh<<endl;
}

void SinhVien::Nhap()
{
	Nguoi::Nhap();
	cout<<"Ma so sinh vien: "; cin>>mssv;
	fflush(stdin);
	cout<<"Truong: "; getline(cin,truong);
}
void SinhVien::Xuat()
{
	Nguoi::Xuat();
	cout<<"Nghe nghiep: Sinh vien"<<endl;
	cout<<"Ma so sinh vien: "<<mssv<<endl;
	cout<<"Truong: "<<truong<<endl;
}

void HocSinh::Nhap()
{
	Nguoi::Nhap();
	cout<<"Ma so hoc sinh: "; cin>>mshs;
	fflush(stdin);
	cout<<"Truong: "; getline(cin,truong);
}
void HocSinh::Xuat()
{
	Nguoi::Xuat();
	cout<<"Nghe nghiep: Hoc sinh"<<endl;
	cout<<"Ma so hoc sinh: "<<mshs<<endl;
	cout<<"Truong: "<<truong<<endl;
}

void CongNhan::Nhap()
{
	Nguoi::Nhap();
}
void CongNhan::Xuat()
{
	Nguoi::Xuat();
	cout<<"Nghe nghiep: Cong nhan"<<endl;
}

void NgheSi::Nhap()
{
	Nguoi::Nhap();
}
void NgheSi::Xuat()
{
	Nguoi::Xuat();
	cout<<"Nghe nghiep: Nghe si"<<endl;
}

void CaSi::Nhap()
{
	Nguoi::Nhap();
}
void CaSi::Xuat()
{
	Nguoi::Xuat();
	cout<<"Nghe nghiep: Ca si"<<endl;
}