#include <iostream>
#include <stdio.h>
#include <conio.h>
using namespace std;

typedef struct HocSinh
{
	char HoTen[25];
	float Van,Toan,DiemTrungBinh;
}hs;

void NhapThongTinHocSinh(hs x);
void XuatThongTinHocSinh(hs x);
float tinhdiemtrungbinh(hs x);
int main()
{
	hs x;
	NhapThongTinHocSinh(x);
	x.DiemTrungBinh=TinhDiemTrungBinh(x);
	XuatThongTinHocSinh(x);
	getch();
	return 0;
}
void NhapThongTinHocSinh(hs x)
{
	cout<<"Nhap ho ten cua hoc sinh"<<endl;
	cin.get(x.HoTen,30);
	cout<<"Nhap diem mon toan va van cho hoc sinh "<<x.HoTen<<endl;
	cin>>x.Toan>>x.Van;
}
void XuatThongTinHocSinh(hs x)
{
	cout<<x.HoTen <<":" <<endl
		<<"Diem toan: "<<x.Toan<<endl
		<<"Diem van: "<<x.Toan<<endl
		<<"Diem trung binh: "<<x.DiemTrungBinh<<endl;
}
float TinhDiemTrungBinh(hs x)
{
	x.DiemTrungBinh=(x.Toan+x.Van)/2;
	return x.DiemTrungBinh;
}
