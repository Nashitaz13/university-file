#include <iostream>
#include <stdio.h>
#include <conio.h>
#define ESC 27
using namespace std;

typedef struct
{
	int tu,mau;
}ps;

void rutgon(ps a);
void inmenu()
{
	cout<<"1. Tinh tong phan so"<<endl
		<<"2. Tinh hieu phan so"<<endl
		<<"3. Tinh tich phan so"<<endl
		<<"4. Tinh thuong phan so"<<endl
		<<"5. Tim phan so lon nhat trong tat ca cac phan so da nhap"<<endl
		<<"ESC. Thoat khoi chuong trinh"<<endl;
}

int main()
{
	float ss,ssmax;
	ps x[50],tong,hieu,tich,thuong;
	int n,a,b;
	char ch;
	cout<<"Nhap so luong phan so can tinh"<<endl;
	cin>>n;
	for(int i=0;i<n;i++)
	{
		cout<<"Nhap tu va mau cho phan so "<<i<<endl;
		do
		{
			if(x[i].mau==0)
				cout<<"Mau cua phan so phai khac 0"<<endl;
			else
				cin>>x[i].tu>>x[i].mau;
		}
		while(x[i].mau==0);
	}
	do
	{
		inmenu();
		ch=getch();

		switch(ch)
		{
			case '1':
				cout<<"Nhap thu tu cac phan so can tinh tong"<<endl;
				cin>>a>>b;
				for(int i=1;i<=x[a].mau*x[b].mau;i++)
				{
					if(i%x[a].mau==0&&i%x[b].mau==0)
					{
						tong.mau=i;
						tong.tu=(((i/x[a].mau)*x[a].tu)+((i/x[b].mau)*x[b].tu));
						break;
					}
				}
				rutgon(tong);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '2':
				cout<<"Nhap thu tu cac phan so can tinh hieu"<<endl;
				cin>>a>>b;
				for(int i=1;i<=x[a].mau*x[b].mau;i++)
				{
					if(i%x[a].mau==0&&i%x[b].mau==0)
					{
						hieu.mau=i;
						hieu.tu=(((i/x[a].mau)*x[a].tu)-((i/x[b].mau)*x[b].tu));
						break;
					}
				}
				rutgon(hieu);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '3':
				cout<<"Nhap thu tu cac phan so can tinh tich"<<endl;
				cin>>a>>b;
				tich.mau=x[a].mau*x[b].mau;
				tich.tu=x[a].tu*x[b].tu;
				rutgon(tich);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '4':
				cout<<"Nhap thu tu cac phan so can tinh thuong"<<endl;
				cin>>a>>b;
				thuong.tu=x[a].tu*x[b].mau;
				thuong.mau=x[b].tu*x[a].mau;
				rutgon(thuong);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
			case '5':
				int nho;
				ssmax=float(x[0].tu)/float(x[0].mau);
				for(int i=0;i<n;i++)
				{
					ss=float(x[i].tu)/float(x[i].mau);
					if(ss>ssmax)
					{
						ssmax=ss;
						nho=i;
					}
				}
				cout<<"Phan so lon nhat la:"<<endl;
				rutgon(x[nho]);
				cout<<"Nhan ENTER de tro ve menu chinh"<<endl;
				getch();
				break;
		}
	}
	while(ch!=ESC);
	getch();
	return 0;
}

void rutgon(ps a)
{
	if(a.tu%a.mau==0) cout<<a.tu/a.mau<<endl;
	else 
	{
		for(int i=2;i<=a.tu;i++)
		{
			if(a.tu%i==0&&a.mau%i==0)
				cout<<a.tu/i<<"/"<<a.mau/i<<endl;
		}
		cout<<a.tu<<"/"<<a.mau<<endl;
	}
}