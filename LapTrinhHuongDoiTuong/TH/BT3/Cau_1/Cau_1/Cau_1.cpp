#include "graphics.h"
#include <iostream>
using namespace std;
class Point
{
private:
	int x,y;
public:
	void Nhap();
	void Xuat();
	void TinhTien(int, int);
	int UCLN(int, int);
};
int main()
{
	int a,b;
	Point A;
	A.Nhap();
	A.Xuat();
	cout<<"Tinh tien den diem co toa do: "<<endl;
	cout<<"Hoanh do: "; cin>>a;
	cout<<"Tung do: "; cin>>b;
	A.TinhTien(a,b);
	getch();
}
void Point::Nhap()
{
	cout<<"Nhap toa do diem:"<<endl;
	cout<<"Nhap hoanh do: "; cin>>x;
	cout<<"Nhap tung do: "; cin>>y;
}
void Point::TinhTien(int a, int b)
{
	int a1,b1,a2,b2;
	a1=a-x;
	b1=b-y;
	int UC=UCLN(a1,b1);
	a2=(a-x)/UC;
	b2=(b-y)/UC;
	putpixel(a,b,GREEN);
	do
	{
		putpixel(x,y,0);
		x=x+a2;
		y=y+b2;
		putpixel(x,y,15);
		delay(100);
	}
	while (x!=a||y!=b);
}
void Point::Xuat()
{
	cout<<"Toa do: ("<<x<<"/"<<y<<")"<<endl;
	initwindow(400, 300, "Point");
	putpixel(x,y,15);
}
int Point::UCLN(int a,int b)
{
	int r;
	if (a<0) 
		a = -a;
	if (b<0)
		b = -b;
	while(a * b != 0)
	{
		if(a > b)
			a -= b;
		else 
			b -= a;
	}
	r = a + b;
	return r;
}
