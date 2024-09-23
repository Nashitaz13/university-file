#include "DaGiac.h"


DaGiac::DaGiac(void)
{
}
DaGiac::~DaGiac(void)
{
}

void TuGiac::Nhap()
{
	cout<<"Nhap toa do diem 1:"<<endl;
	cout<<"Hoanh do: "; cin>>x1;
	cout<<"Tung do: "; cin>>y1;
	cout<<"Nhap toa do diem 2:"<<endl;
	cout<<"Hoanh do: "; cin>>x2;
	cout<<"Tung do: "; cin>>y2;
	cout<<"Nhap toa do diem 3:"<<endl;
	cout<<"Hoanh do: "; cin>>x3;
	cout<<"Tung do: "; cin>>y3;
	cout<<"Nhap toa do diem 4:"<<endl;
	cout<<"Hoanh do: "; cin>>x4;
	cout<<"Tung do: "; cin>>y4;
}
void TuGiac::Xuat()
{
	Ve();
	TinhTien();
	Quay();
	Zoom();
}
void TuGiac::Ve()
{
	line(x1,y1,x2,y2);
	line(x2,y2,x3,y3);
	line(x3,y3,x4,y4);
	line(x4,y4,x1,y1);
}
void TuGiac::TinhTien()
{
	cout<<"\nNhap toa do tinh tien:"<<endl;
	cout<<"Hoanh do: "; cin>>x;
	cout<<"Tung do: "; cin>>y;
	x1=x1+x; y1=y1+y;
	x2=x2+x; y2=y2+y;
	x3=x3+x; y3=y3+y;
	x4=x4+x; y4=y4+y;
	cleardevice();
	Ve();
}
void TuGiac::Quay()
{	
	cout<<"\nNhap goc quay: "; cin>>alpha;
	float gx,gy,PI=3.14;
	double rad=(alpha*PI/180);
	int x11,x22,x33,x44;
	gx=TrongTam(x1,x2,x3,x4);
	gy=TrongTam(y1,y2,y3,y4);
	x11=x1; x22=x2; x33=x3; x44=x4;
	x1=((x1-gx)*cos(rad)-(y1-gy)*sin(rad))+gx;
	x2=((x2-gx)*cos(rad)-(y2-gy)*sin(rad))+gx;
	x3=((x3-gx)*cos(rad)-(y3-gy)*sin(rad))+gx;
	x4=((x4-gx)*cos(rad)-(y4-gy)*sin(rad))+gx;
	y1=((x11-gx)*sin(rad)+(y1-gy)*cos(rad))+gy;
	y2=((x22-gx)*sin(rad)+(y2-gy)*cos(rad))+gy;
	y3=((x33-gx)*sin(rad)+(y3-gy)*cos(rad))+gy;
	y4=((x44-gx)*sin(rad)+(y4-gy)*cos(rad))+gy;
	cleardevice();
	Ve();
}
void TuGiac::Zoom()
{
	cout<<"\nNhap he so zoom: "; cin>>z;
	float gx,gy,PI=3.14;
	double rad=(alpha*PI/180);
	gx=TrongTam(x1,x2,x3,x4);
	gy=TrongTam(y1,y2,y3,y4);
	x1=z*(x1)-(z-1)*gx;
	x2=z*(x2)-(z-1)*gx;
	x3=z*(x3)-(z-1)*gx;
	x4=z*(x4)-(z-1)*gx;
	y1=z*(y1)-(z-1)*gy;
	y2=z*(y2)-(z-1)*gy;
	y3=z*(y3)-(z-1)*gy;
	y4=z*(y4)-(z-1)*gy;
	cleardevice();
	Ve();
}
float TuGiac::TrongTam(float x1,float x2,float x3,float x4)
{
	float g;
	g=(x1+x2+x3+x4)/4;
	return g;
}

void TamGiac::Nhap()
{
	float c1,c2,c3;
	do
	{
		cout<<"Nhap toa do diem 1:"<<endl;
		cout<<"Hoanh do: "; cin>>x1;
		cout<<"Tung do: "; cin>>y1;
		cout<<"Nhap toa do diem 2:"<<endl;
		cout<<"Hoanh do: "; cin>>x2;
		cout<<"Tung do: "; cin>>y2;
		cout<<"Nhap toa do diem 3:"<<endl;
		cout<<"Hoanh do: "; cin>>x3;
		cout<<"Tung do: "; cin>>y3;
		c1=Canh(x1,x2,y1,y2);
		c2=Canh(x2,x3,y2,y3);
		c3=Canh(x3,x1,y3,y1);
		if (c1+c2<=c3||c1+c3<=c2||c2+c3<=c1||c1==0||c2==0|c3==0)
			cout<<"Khong ve duoc tam giac. Nhap lai:"<<endl;
	}
	while (c1+c2<=c3||c1+c3<=c2||c2+c3<=c1||c1==0||c2==0|c3==0);
}
void TamGiac::Xuat()
{
	Ve();
	TinhTien();
	Quay();
	Zoom();
}
void TamGiac::Ve()
{
	line(x1,y1,x2,y2);
	line(x2,y2,x3,y3);
	line(x3,y3,x1,y1);
}
void TamGiac::TinhTien()
{
	cout<<"\nNhap toa do tinh tien:"<<endl;
	cout<<"Hoanh do: "; cin>>x;
	cout<<"Tung do: "; cin>>y;
	x1=x1+x; y1=y1+y;
	x2=x2+x; y2=y2+y;
	x3=x3+x; y3=y3+y;
	cleardevice();
	Ve();
}
void TamGiac::Quay()
{	
	cout<<"\nNhap goc quay: "; cin>>alpha;
	float gx,gy,PI=3.14;
	double rad=(alpha*PI/180);
	int x11,x22,x33;
	gx=TrongTam(x1,x2,x3);
	gy=TrongTam(y1,y2,y3);
	x11=x1; x22=x2; x33=x3;
	x1=((x1-gx)*cos(rad)-(y1-gy)*sin(rad))+gx;
	x2=((x2-gx)*cos(rad)-(y2-gy)*sin(rad))+gx;
	x3=((x3-gx)*cos(rad)-(y3-gy)*sin(rad))+gx;
	y1=((x11-gx)*sin(rad)+(y1-gy)*cos(rad))+gy;
	y2=((x22-gx)*sin(rad)+(y2-gy)*cos(rad))+gy;
	y3=((x33-gx)*sin(rad)+(y3-gy)*cos(rad))+gy;
	cleardevice();
	Ve();
}
void TamGiac::Zoom()
{
	cout<<"\nNhap he so zoom: "; cin>>z;
	float gx,gy,PI=3.14;
	double rad=(alpha*PI/180);
	gx=TrongTam(x1,x2,x3);
	gy=TrongTam(y1,y2,y3);
	x1=z*(x1)-(z-1)*gx;
	x2=z*(x2)-(z-1)*gx;
	x3=z*(x3)-(z-1)*gx;
	y1=z*(y1)-(z-1)*gy;
	y2=z*(y2)-(z-1)*gy;
	y3=z*(y3)-(z-1)*gy;
	cleardevice();
	Ve();
}
float TamGiac::TrongTam(float x1,float x2,float x3)
{
	float g;
	g=(x1+x2+x3)/3;
	return g;
}
float TamGiac::Canh(int x1,int x2,int y1,int y2)
{
	float d=pow(((x1-x2)*(x1-x2)+(y1-y2)*(y1-y2)),0.5);
	return d;
}

void HinhBinhHanh::Nhap()
{
	int dx,dy;
	do
	{
		cout<<"Nhap toa do diem 1:"<<endl;
		cout<<"Hoanh do: "; cin>>x1;
		cout<<"Tung do: "; cin>>y1;
		cout<<"Nhap toa do diem 2:"<<endl;
		cout<<"Hoanh do: "; cin>>x2;
		cout<<"Tung do: "; cin>>y2;
		cout<<"Nhap toa do diem 3:"<<endl;
		cout<<"Hoanh do: "; cin>>x4;
		cout<<"Tung do: "; cin>>y4;
		if (x2>x4)
		{
			if (x2>x1)
				dx=x2-x1;
			else 
				dx=x1-x2;
			x3=dx+x4;
			if (y2>y1)
				dy=y2-y1;
			else
				dy=y1-y2;
			y3=dy+y4;
		}
		else
		{
			if (x4>x1)
				dx=x4-x1;
			else 
				dx=x1-x4;
			x3=dx+x2;
			if (y4>y1)
				dy=y4-y1;
			else
				dy=y1-y4;
			y3=dy+y2;
		}
		if (!DieuKien(x1,y1,x2,y2,x4,y4))
			cout<<"Khong ve duoc hinh binh hanh.Nhap lai:"<<endl;
	}
	while (!DieuKien(x1,y1,x2,y2,x4,y4));
}
void HinhBinhHanh::Xuat()
{
	TuGiac::Xuat();
}
int HinhBinhHanh::DieuKien(int x1,int y1,int x2,int y2,int x3,int y3)
{
	float a,b,c;
	a=pow(((x1-x2)*(x1-x2)+(y1-y2)*(y1-y2)),0.5);
	b=pow(((x2-x3)*(x2-x3)+(y2-y3)*(y2-y3)),0.5);
	c=pow(((x1-x3)*(x1-x3)+(y1-y3)*(y1-y3)),0.5);
	if (a+b<=c||a+c<=b||b+c<=a||a==0||b==0|c==0)
		return 0;
	else 
		return 1;
}

void HinhChuNhat::Nhap()
{
	do
	{
		cout<<"Nhap toa do diem 1:"<<endl;
		cout<<"Hoanh do: "; cin>>x1;
		cout<<"Tung do: "; cin>>y1;
		cout<<"Nhap toa do diem 2:"<<endl;
		cout<<"Hoanh do: "; cin>>x3;
		cout<<"Tung do: "; cin>>y3;
		x2=x3; y2=y1;
		x4=x1; y4=y3;
		if (x1==x3 || y1==y3)
			cout<<"Khong ve duoc hinh chu nhat. Nhap lai:"<<endl;
	}
	while (x1==x3 || y1==y3); 
}
void HinhChuNhat::Xuat()
{
	TuGiac::Xuat();
}

void HinhVuong::Nhap()
{
	int d;
	cout<<"Nhap toa do diem phia tren ben trai:"<<endl;
	cout<<"Hoanh do: "; cin>>x1;
	cout<<"Tung do: "; cin>>y1;
	cout<<"Nhap do dai canh: "; cin>>d;
	x2=x1+d; y2=y1;
	x3=x2; y3=y2+d;
	x4=x1; y4=y3;
}
void HinhVuong::Xuat()
{
	TuGiac::Xuat();
}