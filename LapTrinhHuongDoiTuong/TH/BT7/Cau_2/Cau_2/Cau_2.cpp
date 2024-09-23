#include "Nguoi.h"

void main()
{
	SinhVien sv;
	HocSinh hs;
	CongNhan cn;
	NgheSi ns;
	CaSi cs;
	int lc,dk;
	cout<<"1. Nhap thong tin sinh vien!"<<endl;
	cout<<"2. Nhap thong tin hoc sinh!"<<endl;
	cout<<"3. Nhap thong tin cong nhan!"<<endl;
	cout<<"4. Nhap thong tin nghe si!"<<endl;
	cout<<"5. Nhap thong tin ca si!"<<endl;
	do
	{
		cout<<"Nhap lua chon: "; cin>>lc; cout<<endl;
		switch(lc)
		{
		case 1:
			{
				cout<<"Nhap thong tin sinh vien: "<<endl;
				sv.Nhap(); cout<<endl;
				sv.Xuat();
				break;
			}
		case 2:
			{
				cout<<"Nhap thong tin hoc sinh: "<<endl;
				hs.Nhap(); cout<<endl;
				hs.Xuat();
				break;
			}
		case 3:
			{
				cout<<"Nhap thong tin cong nhan: "<<endl;
				cn.Nhap(); cout<<endl;
				cn.Xuat();
				break;
			}
		case 4:
			{
				cout<<"Nhap thong tin nghe si: "<<endl;
				ns.Nhap(); cout<<endl;
				ns.Xuat();
				break;
			}
		case 5:
			{
				cout<<"Nhap thong tin ca si: "<<endl;
				cs.Nhap(); cout<<endl;
				cs.Xuat();
				break;
			}
		}
		cout<<"\nNhap 1 de tiep tuc!"<<endl;
		cout<<"Nhap 0 de ket thuc!"<<endl;
		cin>>dk;
	}
	while (dk==1);
}