#include "Points.h"

void main()
{
	HinhTron ht;
	Elip el;
	cout<<"Nhap hinh tron:"<<endl; ht.Nhap();
	cout<<"\nNhap hinh ellipse:"<<endl; el.Nhap();
	initwindow(800,600,"Cau_4");
	ht.Ve();
	el.Ve();
	system("pause");
}