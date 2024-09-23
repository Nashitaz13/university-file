#include "Points.h"


Points::Points(void)
{
}
Points::Points(int xx,int yy)
{
	x=xx;
	y=yy;
}
Points::~Points(void)
{
}
void Points::Nhap()
{
	cout<<"Tung do: "; cin>>x;
	cout<<"Hoanh do: "; cin>>y;
}

void HinhTron::Nhap()
{
	cout<<"Nhap toa do tam: "<<endl;
	Points::Nhap();
	cout<<"Nhap ban kinh: "; cin>>r;
}
void HinhTron::Ve()
{
	circle(x,y,r);
}

void Elip::Nhap()
{
	cout<<"Nhap toa do tam: "<<endl;
	Points::Nhap();
	cout<<"Nhap ban kinh truc x: "; cin>>xr;
	cout<<"Nhap ban kinh truc y: "; cin>>yr;
}
void Elip::Ve()
{
	ellipse(x,y,0,0,xr,yr);
}