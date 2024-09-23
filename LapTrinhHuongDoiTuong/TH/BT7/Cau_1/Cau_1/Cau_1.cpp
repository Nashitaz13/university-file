#include "Nguoi.h"
#include "NhanVien.h"

void main()
{
	int i,n,luongcb;
	NhanVien a[100];
	cout<<"Nhap luong co ban: "; cin>>luongcb;
	cout<<"\nNhap so nhan vien: "; cin>>n;
	for (i=0;i<n;i++) 
	{
		cout<<"\nNhan vien thu "<<i+1<<": "<<endl;
		a[i].Nhap(luongcb);
	}
	cout<<"\nThong tin cac nhan vien: "<<endl;
	for (i=0;i<n;i++)
	{
		cout<<"STT: "<<i+1<<endl;
		a[i].Xuat();
		cout<<endl;
	}
	system("pause");
}