#include "graphics.h"
#include <iostream>
using namespace std;
class TamGiac
{
private:
	float a,b,c;
public:
	void TG();
};
class Point:public TamGiac
{
private:
	int x,y;
public:
	void Nhap();
	void VTConTro();
	void VTConTro1(int, int ,float,Point,Point,Point,int);
	void Xuat();
	void Ve();
	void Quay(Point A,Point B,Point C,int);
	void TinhTien(int, int,Point,Point,Point,int);
	void Zoom(int, int, float,Point,Point,Point,int);
	void PrintTG(Point A,Point B,Point C);
	float Canh(Point P);
	float Tongx(Point, Point);
	float Tongy(Point, Point);
};
void main()
{
	TamGiac tg;
	tg.TG();
	getch();
}
void TamGiac::TG()
{
	float z;
	Point A,B,C,Z;
	do
	{
	cout<<"Nhap toa do diem A:"<<endl; A.Nhap();
	cout<<"Nhap toa do diem B:"<<endl; B.Nhap();
	cout<<"Nhap toa do diem C:"<<endl; C.Nhap();
	cout<<"\nToa do cua 3 dinh:"<<endl;
	a=B.Canh(C);
	b=A.Canh(C);
	c=A.Canh(B);
	if (a+b<=c||a+c<=b||b+c<=a||a==0||b==0|c==0)
		cout<<"\nA,B,C khong phai la 3 dinh cua tam giac! Nhap lai:"<<endl<<"\n";
	}
	while (a+b<=c||a+c<=b||b+c<=a||a==0||b==0|c==0);
	if (a+b>c&&a+c>b&&b+c>a&&a!=0&&b!=0&&c!=0)
	{
		cout<<"A"; A.Xuat(); cout<<"B"; B.Xuat(); cout<<"C"; C.Xuat();
		initwindow(800,600, "Tam Giac");
		Z.PrintTG(A,B,C);
	}
}
void Point::PrintTG(Point A,Point B,Point C)
{
	int a,b;
	float z;
	int alpha;
	A.VTConTro();
	A.Ve(); B.Ve(); C.Ve(); A.Ve();
	cout<<"\nQuay tam giac: "<<endl<<"Nhap goc quay (do): ";
	cin>>alpha;
	cleardevice();
	A.VTConTro1(0,0,1,A,B,C,alpha);
	A.Quay(A,B,C,alpha); B.Quay(A,B,C,alpha); C.Quay(A,B,C,alpha); A.Quay(A,B,C,alpha);
	cout<<"\nTinh tien tam giac theo toa do: "<<endl;
	cout<<"Hoanh do: "; cin>>a;
	cout<<"Tung do: "; cin>>b;
	cleardevice();
	A.VTConTro1(a,b,1,A,B,C,alpha);
	A.TinhTien(a,b,A,B,C,alpha); B.TinhTien(a,b,A,B,C,alpha); C.TinhTien(a,b,A,B,C,alpha); A.TinhTien(a,b,A,B,C,alpha);
	cout<<"\nThay doi kich thuoc tam giac:"<<endl;
	do
	{
		cout<<"Nhap he so zoom(z) [0<z<1: thu nho! z>1:phong to]: ";cin>>z;
		if (z<=0) cout<<"Khong hop le. Nhap lai!"<<endl;
	}
	while (z<=0);
	cleardevice();
	A.VTConTro1(a,b,z,A,B,C,alpha);
	A.Zoom(a,b,z,A,B,C,alpha); B.Zoom(a,b,z,A,B,C,alpha); C.Zoom(a,b,z,A,B,C,alpha); A.Zoom(a,b,z,A,B,C,alpha);
}
void Point::Quay(Point A,Point B,Point C,int alpha)
{
	float ox,oy;
	ox=A.Tongx(B,C);
	oy=A.Tongy(B,C);
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	lineto(x1+ox,y1+oy);
}
void Point::TinhTien(int a,int b,Point A,Point B,Point C,int alpha)
{
	float ox,oy;
	ox=A.Tongx(B,C);
	oy=A.Tongy(B,C);
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	lineto(x1+ox+a,y1+oy+b);
}
void Point::Zoom(int a,int b,float z,Point A,Point B,Point C,int alpha)
{
	float ox,oy;
	ox=A.Tongx(B,C);
	oy=A.Tongy(B,C);
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	lineto(z*(x1+ox+a)-(z-1)*(ox+a),z*(y1+oy+b)-(z-1)*(oy+b));
}
void Point::Ve()
{
	lineto(x,y);
}
void Point::Nhap()
{
	cout<<"Hoanh do: "; cin>>x;
	cout<<"Tung do: "; cin>>y;
}
void Point::VTConTro()
{
	moveto(x,y);
}
void Point::VTConTro1(int a,int b,float z,Point A,Point B,Point C,int alpha)
{
	float ox,oy;
	ox=A.Tongx(B,C);
	oy=A.Tongy(B,C);
	float PI=3.14;
	double rad=(alpha*PI/180);
	float x1=(x-ox)*cos(rad)-(y-oy)*sin(rad);
	float y1=(x-ox)*sin(rad)+(y-oy)*cos(rad);
	moveto(z*(x1+ox+a)-(z-1)*(ox+a),z*(y1+oy+b)-(z-1)*(oy+b));
}
void Point::Xuat()
{
	cout<<"("<<x<<"/"<<y<<")"<<endl;
}
float Point::Canh(Point p)
{
	float d=pow(((p.x-x)*(p.x-x)+(p.y-y)*(p.y-y)),0.5);
	return d;
}
float Point::Tongx(Point B,Point C)
{
	float xx1=(x+B.x+C.x)/3;
	return xx1;
}
float Point::Tongy(Point B,Point C)
{
	float yy1=(y+B.y+C.y)/3;
	return yy1;
}