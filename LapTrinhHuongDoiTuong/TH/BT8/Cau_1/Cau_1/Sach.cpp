#include "Sach.h"

Sach::Sach(void)
{
}
Sach::~Sach(void)
{
}

void SachGiaoKhoa::Nhap()
{
	int i;
	cout<<"\nNhap danh sach sach giao khoa:"<<endl;
	cout<<"Nhap so luong: "; cin>>sl;
	for(i=0;i<sl;i++)
	{
		cout<<"STT:"<<i+1<<endl;
		fflush(stdin);
		cout<<"Nhap ten sach: "; getline(cin,ten);
		fflush(stdin);
		cout<<"Nhap ten tac gia: "; getline(cin,tacgia);
		cout<<"Nhap nam xuat ban: "; cin>>namxb;
		cout<<"Nhap khoi: "; cin>>khoi;
	}
}
void SachGiaoKhoa::Xuat()
{
	int i;
	cout<<"\nSo luong sach giao khoa: "<<sl<<endl;
	for(i=0;i<sl;i++)
	{
		cout<<"STT:"<<i+1<<endl;
		cout<<"Ten sach: "<<ten<<endl;
		cout<<"Tac gia: "<<tacgia<<endl;
		cout<<"Nam xuat ban: "<<namxb<<endl;
		cout<<"Khoi: "<<khoi<<endl;
	}
}

void TieuThuyet::Nhap()
{
	int i;
	cout<<"\nNhap danh sach tieu thuyet:"<<endl;
	cout<<"Nhap so luong: "; cin>>sl;
	for(i=0;i<sl;i++)
	{
		cout<<"STT:"<<i+1<<endl;
		fflush(stdin);
		cout<<"Nhap ten tieu thuyet: "; getline(cin,ten);
		fflush(stdin);
		cout<<"Nhap ten tac gia: "; getline(cin,tacgia);
		cout<<"Nhap nam xuat ban: "; cin>>namxb;
		fflush(stdin);
		cout<<"Nhap the loai: "; getline(cin,theloai);
	}
}
void TieuThuyet::Xuat()
{
	int i;
	cout<<"\nSo luong tieu thuyet: "<<sl<<endl;
	for(i=0;i<sl;i++)
	{
		cout<<"STT:"<<i+1<<endl;
		cout<<"Ten tieu thuyet: "<<ten<<endl;
		cout<<"Tac gia: "<<tacgia<<endl;
		cout<<"Nam xuat ban: "<<namxb<<endl;
		cout<<"The loai: "<<theloai<<endl;
	}
}

void TapChi::Nhap()
{
	int i;
	cout<<"\nNhap danh sach tap chi:"<<endl;
	cout<<"Nhap so luong: "; cin>>sl;
	for(i=0;i<sl;i++)
	{
		cout<<"STT:"<<i+1<<endl;
		fflush(stdin);
		cout<<"Nhap ten tap chi: "; getline(cin,ten);
		fflush(stdin);
		cout<<"Nhap ten tac gia: "; getline(cin,tacgia);
		cout<<"Nhap nam xuat ban: "; cin>>namxb;
		fflush(stdin);
		cout<<"Nhap de tai: "; getline(cin,detai);
	}
}
void TapChi::Xuat()
{
	int i;
	cout<<"\nSo luong tap chi: "<<sl<<endl;
	for(i=0;i<sl;i++)
	{
		cout<<"STT:"<<i+1<<endl;
		cout<<"Ten tap chi: "<<ten<<endl;
		cout<<"Tac gia: "<<tacgia<<endl;
		cout<<"Nam xuat ban: "<<namxb<<endl;
		cout<<"De tai: "<<detai<<endl;
	}
}