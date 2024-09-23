#include "HinhThang.h"

void main()
{
	int lc,dk;
	HinhThang ht;
	HinhBinhHanh hbh;
	HinhChuNhat hcn;
	HinhVuong hv;
	cout<<"1. Ve hinh thang!"<<endl;
	cout<<"2. Ve hinh binh hanh!"<<endl;
	cout<<"3. Ve hinh chu nhat!"<<endl;
	cout<<"4. Ve hinh vuong!"<<endl;
	do
	{
		cout<<"Nhap lua chon: "; cin>>lc;
		switch(lc)
		{
		case 1:
			 {
				 cout<<"\nVe hinh thang:"<<endl;
				 ht.Nhap();
				 ht.Ve();
				 break;
			 }
		case 2:
			 {
				 cout<<"\nVe hinh binh hanh:"<<endl;
				 hbh.Nhap();
				 hbh.Ve();
				 break;
			 }
		case 3:
			{
				cout<<"\nVe hinh chu nhat:"<<endl;
				hcn.Nhap();
				hcn.Ve();
				break;
			}
		case 4:
			{
				cout<<"\nVe hinh vuong:"<<endl;
				hv.Nhap();
				hv.Ve();
				break;
			}
		}
		cout<<"\nNhap 1 de tiep tuc!"<<endl;
		cout<<"Nhap 0 de ket thuc!"<<endl;
		cin>>dk;
	}
	while (dk==1);
}