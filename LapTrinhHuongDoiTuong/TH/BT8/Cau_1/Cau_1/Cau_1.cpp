#include "Sach.h"


void main()
{
	int lc,dk;
	Sach *s;
	SachGiaoKhoa sgk;
	TieuThuyet tt;
	TapChi tc;
	cout<<"1. Sach giao khoa!"<<endl;
	cout<<"2. Tieu thuyet!"<<endl;
	cout<<"3. Tap chi!"<<endl;
	do
	{
		cout<<"Nhap lua chon: "; cin>>lc;
		switch(lc)
		{
		case 1:
			 {
				 s=&sgk;
				 s->Nhap();
				 s->Xuat();
				 break;
			 }
		case 2:
			 {
				 s=&tt;
				 s->Nhap();
				 s->Xuat();
				 break;
			 }
		case 3:
			{
				s=&tc;
				s->Nhap();
				s->Xuat();
				break;
			}
		}
		cout<<"\nNhap 1 de tiep tuc!"<<endl;
		cout<<"Nhap 0 de ket thuc!"<<endl;
		cin>>dk;
	}
	while (dk==1);
}