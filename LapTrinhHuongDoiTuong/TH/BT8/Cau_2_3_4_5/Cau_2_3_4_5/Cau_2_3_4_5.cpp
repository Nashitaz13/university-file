#include "DaGiac.h"

void main()
{
	int lc,dk;
	DaGiac *dg;
	TuGiac t1;
	TamGiac t2;
	HinhBinhHanh hbh;
	HinhChuNhat hcn;
	HinhVuong hv;
	cout<<"1. Ve tu giac!"<<endl;
	cout<<"2. Ve tam giac!"<<endl;
	cout<<"3. Ve hinh binh hanh!"<<endl;
	cout<<"4. Ve hinh chu nhat!"<<endl;
	cout<<"5. Ve hinh vuong!"<<endl;
	do
	{
		cout<<"Nhap lua chon: "; cin>>lc;
		switch(lc)
		{
		case 1:
			{
				cout<<"\nVe tu giac:"<<endl;
				dg=&t1;
				dg->Nhap();
				initwindow(800,600,"TuGiac");
				dg->Xuat();
				break;
			}
		case 2:
			{
				cout<<"\nVe tam giac:"<<endl;
				dg=&t2;
				dg->Nhap();
				initwindow(800,600,"TamGiac");
				dg->Xuat();
				break;
			}
		case 3:
			{
				cout<<"\nVe hinh binh hanh:"<<endl;
				dg=&hbh;
				dg->Nhap();
				initwindow(800,600,"HinhBinhHanh");
				dg->Xuat();
				break;
			}
		case 4:
			{
				cout<<"\nVe hinh chu nhat:"<<endl;
				dg=&hcn;
				dg->Nhap();
				initwindow(800,600,"HinhChuNhat");
				dg->Xuat();
				break;
			}
		case 5:
			{
				cout<<"\nVe hinh vuong:"<<endl;
				dg=&hv;
				dg->Nhap();
				initwindow(800,600,"HinhVuong");
				dg->Xuat();
				break;
			}
		}
		cout<<"\nNhap 1 de tiep tuc!"<<endl;
		cout<<"Nhap 0 de ket thuc!"<<endl;
		cin>>dk;
	}
	while (dk==1);
}