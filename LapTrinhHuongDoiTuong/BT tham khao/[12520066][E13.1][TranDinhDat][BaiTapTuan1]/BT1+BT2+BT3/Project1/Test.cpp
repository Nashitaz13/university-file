#include <iostream>
#include <stdio.h>
#include <conio.h>
#define ESC 27
using namespace std;

typedef struct phanso
{
	int TuSo,MauSo;
}ps;

void RutGon(ps a);
void NhapPhanSo(ps x[],int n);
void Nhap1PhanSo(ps &x);
ps TinhTong(ps a,ps b);
ps TinhHieu(ps a,ps b);
ps TinhTich(ps a,ps b);
ps TinhThuong(ps a,ps b);
int TimPhanSoLonNhat(ps x[],int n);
void InMenu()
{
	cout<<"1. Tinh Tong phan so"<<endl
		<<"2. Tinh Hieu phan so"<<endl
		<<"3. Tinh Tich phan so"<<endl
		<<"4. Tinh Thuong phan so"<<endl
		<<"5. Tim phan so lon nhat trong tat ca cac phan so da nhap"<<endl
		<<"ESC. Thoat khoi chuong trinh"<<endl;
}

int main()
{
	float ss,ssmax;
	ps x[50],Tong,Hieu,Tich,Thuong;
	int n,a,b,nho,j;
	char ch;
	cout<<"Nhap so luong phan so can tinh"<<endl;
	cin>>n;
	NhapPhanSo(x,n);
	do
	{
		InMenu();
		ch=getch();
		switch(ch)
		{
			case '1':
				cout<<"Nhap thu tu cac phan so can tinh Tong"<<endl;
				cin>>a>>b;
				Tong=TinhTong(x[a],x[b]);
				RutGon(Tong);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '2':
				cout<<"Nhap thu tu cac phan so can tinh Hieu"<<endl;
				cin>>a>>b;
				Hieu=TinhHieu(x[a],x[b]);
				RutGon(Hieu);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '3':
				cout<<"Nhap thu tu cac phan so can tinh Tich"<<endl;
				cin>>a>>b;
				Tich=TinhTich(x[a],x[b]);
				RutGon(Tich);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '4':
				cout<<"Nhap thu tu cac phan so can tinh Thuong"<<endl;
				cin>>a>>b;
				Thuong=TinhThuong(x[a],x[b]);
				RutGon(Thuong);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '5':
				nho=TimPhanSoLonNhat(x,n);
				cout<<"Phan so lon nhat la:"<<endl;
				RutGon(x[nho]);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
		}
	}
	while(ch!=ESC);
	getch();
	return 0;
}

void RutGon(ps a)
{
	if(a.TuSo%a.MauSo==0) cout<<a.TuSo/a.MauSo<<endl;
	else 
	{
		for(int i=2;i<=a.TuSo;i++)
		{
			if(a.TuSo%i==0&&a.MauSo%i==0)
				cout<<a.TuSo/i<<"/"<<a.MauSo/i<<endl;
		}
		cout<<a.TuSo<<"/"<<a.MauSo<<endl;
	}
}
void Nhap1PhanSo(ps &x)
{
	do
	{
		cout<<"Nhap tu so: "<<endl;
		cin>>x.TuSo;
		cout<<"Nhap mau so: "<<endl;
		cin>>x.MauSo;
		if(x.MauSo==0)
		{
			cout<<"Mau cua phan so phai khac 0"<<endl;
			cout<<"Nhap lai! "<<endl;
		}		
	}
	while(x.MauSo==0);
}
void NhapPhanSo(ps x[], int n)
{
	
	for(int i=0;i<n;i++)
	{
		cout<<"Nhap tu va mau cho phan so "<<i<<endl;
		Nhap1PhanSo(x[i]);
	}
}
ps TinhTong(ps a,ps b)
{
	ps c;
	for(int i=a.MauSo*b.MauSo;i>=1;i--)
		{
			if(i%a.MauSo==0&&i%b.MauSo==0)
			{
				c.MauSo=i;
				c.TuSo=(((i/a.MauSo)*a.TuSo)+((i/b.MauSo)*b.TuSo));
				break;
			}
		}
	return c;
}
ps TinhHieu(ps a,ps b)
{
	ps c;
	for(int i=a.MauSo*b.MauSo;i>=1;i--)
		{
			if(i%a.MauSo==0&&i%b.MauSo==0)
			{
				c.MauSo=i;
				c.TuSo=(((i/a.MauSo)*a.TuSo)-((i/b.MauSo)*b.TuSo));
				break;
			}
		}
	return c;
}
ps TinhTich(ps a,ps b)
{ 
	ps Tich;
	Tich.TuSo=a.TuSo*b.TuSo;
	Tich.MauSo=a.MauSo*b.MauSo;
	return Tich;
}
ps TinhThuong(ps a,ps b)
{
	ps Thuong;
	Thuong.TuSo=a.TuSo*b.MauSo;
	Thuong.MauSo=b.TuSo*a.MauSo;
	return Thuong;
}
int TimPhanSoLonNhat(ps x[],int n)
{
	float ssmax,ss;
	int nho;
	ssmax=float(x[0].TuSo)/float(x[0].MauSo);
	for(int i=0;i<n;i++)
		{
			ss=float(x[i].TuSo)/float(x[i].MauSo);
			if(ss>ssmax)
			{
				ssmax=ss;
				nho=i;
			}
		}
	return nho;
}
