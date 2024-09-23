#include "graphics.h"
#include <iostream>
#include <math.h>
using namespace std;

class DaGiac
{
private:
	int x,y;
public:
	void Nhap();
	void Xuat();
	void VTConTro();
	void VTConTro1(int,int,int,int,DaGiac [],float);
	void Quay(int , int, DaGiac []);
	void TinhTien(int,int,int,int,DaGiac []);
	void Zoom(int,int,int,int,DaGiac [],float);
	void Ve();
};
void main()
{
	int i,n,a,b,alpha;
	float z;
	DaGiac dg[100];
	do
	{
	cout<<"Nhap so dinh da giac (n>=3): "; cin>>n; cout<<endl;
	if (n<3) cout<<"Khong hop le! Nhap lai:"<<endl;
	}
	while (n<3);
	for (i=1;i<=n;i++)
	{
		cout<<"Nhap toa do diem "<<i<<":"<<endl;
		dg[i].Nhap();
	}
	cout<<endl;
	cout<<"Toa do cac dinh cua da giac:"<<endl;
	for (i=1;i<=n;i++)
	{
		cout<<"Toa do dinh "<<i<<": ";
		dg[i].Xuat();
	}
	initwindow(800,600);
	dg[1].VTConTro();
	for (i=1;i<=n;i++)
		dg[i].Ve();
	dg[1].Ve();
	cout<<"\nQuay da giac:"<<endl;
	cout<<"Nhap goc quay(do): "; cin>>alpha;
	cleardevice();
	dg[1].VTConTro1(0,0,n,alpha,dg,1);
	for (i=1;i<=n;i++)
		dg[i].Quay(n,alpha,dg);
	dg[1].Quay(n,alpha,dg);
	cout<<"\nTinh tien theo toa do: "<<endl;
	cout<<"Hoanh do: "; cin>>a;
	cout<<"Tung do: "; cin>>b;
	cleardevice();
	dg[1].VTConTro1(a,b,n,alpha,dg,1);
	for (i=1;i<=n;i++)
		dg[i].TinhTien(a,b,n,alpha,dg);
	dg[1].TinhTien(a,b,n,alpha,dg);
	cout<<"\nThay doi kich thuoc tam giac:"<<endl;
	do
	{
		cout<<"Nhap he so zoom(z) [0<z<1: thu nho! z>1:phong to]: ";cin>>z;
		if (z<=0) cout<<"Khong hop le. Nhap lai!"<<endl;
	}
	while (z<=0);
	cleardevice();
	dg[1].VTConTro1(a,b,n,alpha,dg,z);
	for (i=1;i<=n;i++)
		dg[i].Zoom(a,b,n,alpha,dg,z);
	dg[1].Zoom(a,b,n,alpha,dg,z);
	getch();
}
void DaGiac::VTConTro()
{
	moveto(x,y);
}
void DaGiac::VTConTro1(int a,int b,int n,int alpha, DaGiac p[],float z)
{
	int i,sx=0,sy=0;
	for (i=1;i<=n;i++)
	{
		sx=sx+p[i].x;
		sy=sy+p[i].y;
	}
	float ox=sx/n;
	float oy=sy/n;
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	moveto(z*(x1+ox+a)-(z-1)*(ox+a),z*(y1+oy+b)-(z-1)*(oy+b));
}
void DaGiac::Quay(int n,int alpha, DaGiac p[])
{
	int i,sx=0,sy=0;
	for (i=1;i<=n;i++)
	{
		sx=sx+p[i].x;
		sy=sy+p[i].y;
	}
	float ox=sx/n;
	float oy=sy/n;
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	lineto(x1+ox,y1+oy);
}
void DaGiac::TinhTien(int a,int b,int n,int alpha, DaGiac p[])
{
	int i,sx=0,sy=0;
	for (i=1;i<=n;i++)
	{
		sx=sx+p[i].x;
		sy=sy+p[i].y;
	}
	float ox=sx/n;
	float oy=sy/n;
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	lineto(x1+ox+a,y1+oy+b);
}
void DaGiac::Zoom(int a,int b,int n,int alpha, DaGiac p[],float z)
{
	int i,sx=0,sy=0;
	for (i=1;i<=n;i++)
	{
		sx=sx+p[i].x;
		sy=sy+p[i].y;
	}
	float ox=sx/n;
	float oy=sy/n;
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	lineto(z*(x1+ox+a)-(z-1)*(ox+a),z*(y1+oy+b)-(z-1)*(oy+b));
}
void DaGiac::Ve()
{
	lineto(x,y);
}
void DaGiac::Nhap()
{
	cout<<"Hoanh do: "; cin>>x;
	cout<<"Tung do: "; cin>>y;
}
void DaGiac::Xuat()
{
	cout<<"("<<x<<"/"<<y<<")"<<endl;
}