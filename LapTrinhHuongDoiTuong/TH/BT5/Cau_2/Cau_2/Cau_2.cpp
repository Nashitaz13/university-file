#include "danhsach.h"
#include "node.h"
#include <iostream>
#include <conio.h>
using namespace std;
void main()
{
	danhsach l;
	node *a,*b;
	int x,y;
	l.Nhap();
	l.Xuat();
	cout<<"\nNhap phan tu can them dau: ";
	cin>>x;
	a=l.TaoNode(x);
	l.ThemDau(a);
	l.Xuat();
	cout<<"\nNhap phan tu can them cuoi: ";
	cin>>y;
	b=l.TaoNode(y);
	l.ThemCuoi(b);
	l.Xuat();
	getch();
}