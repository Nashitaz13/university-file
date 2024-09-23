#include "HinhThang.h"
HinhThang::HinhThang(void)
{
}
HinhThang::~HinhThang(void)
{
}
int HinhThang::DieuKien()
{
	if (ydaylon==ydaybe || (ydaylon!=ydaybe && (x1daylon==x2daylon || x1daybe==x2daybe)))
		return 1;
	else
		return 0;
}
void HinhThang::Nhap()
{
	do
	{
		cout<<"Nhap hoanh do diem 1: "; cin>>x1daylon;
		cout<<"Nhap hoanh do diem 2: "; cin>>x2daylon;
		cout<<"Nhap tung do cua diem 1 va diem 2: "; cin>>ydaylon;
		cout<<"Nhap hoanh do diem 3: "; cin>>x1daybe;
		cout<<"Nhap hoanh do diem 4: "; cin>>x2daybe;
		cout<<"Nhap tung do cua diem 3 va diem 4: "; cin>>ydaybe;
		if (HinhThang::DieuKien())
			cout<<"\nKhong ve duoc hinh thang! Nhap lai:"<<endl;
	}
	while(ydaylon==ydaybe || (ydaylon!=ydaybe && (x1daylon==x2daylon || x1daybe==x2daybe)));
}
void HinhThang::Ve()
{
	initwindow(800,600,"Cau_5");
	line(x1daylon,ydaylon,x2daylon,ydaylon);
	line(x1daybe,ydaybe,x2daybe,ydaybe);
	if (x1daylon < x2daylon)
	{
		if(x1daybe < x2daybe)
		{
			line(x1daylon,ydaylon,x1daybe,ydaybe);
			line(x2daylon,ydaylon,x2daybe,ydaybe);
		}
		else
		{
			line(x1daylon,ydaylon,x2daybe,ydaybe);
			line(x2daylon,ydaylon,x1daybe,ydaybe);
		}
	}
	else
	{
		if(x1daybe < x2daybe)
		{
			line(x2daylon,ydaylon,x1daybe,ydaybe);
			line(x1daylon,ydaylon,x2daybe,ydaybe);
		}
		else
		{
			line(x2daylon,ydaylon,x2daybe,ydaybe);
			line(x1daylon,ydaylon,x1daybe,ydaybe);
		}
	}
}

void HinhBinhHanh::Nhap()
{
	int d;
	do
	{
		cout<<"Nhap hoanh do diem 1: "; cin>>x1daylon;
		cout<<"Nhap hoanh do diem 2: "; cin>>x2daylon;
		cout<<"Nhap tung do cua diem 1 va diem 2: "; cin>>ydaylon;
		cout<<"Nhap hoanh do diem 3: "; cin>>x1daybe;
		cout<<"Nhap tung do diem 3: "; cin>>ydaybe;
		if (x2daylon > x1daylon)
			d = x2daylon - x1daylon;
		else
			d = x1daylon - x2daylon;
		x2daybe = d + x1daybe;
		if (HinhThang::DieuKien())
			cout<<"\nKhong ve duoc hinh binh hanh! Nhap lai:"<<endl;
	}
	while (ydaylon==ydaybe || (ydaylon!=ydaybe && (x1daylon==x2daylon || x1daybe==x2daybe)));
}
void HinhBinhHanh::Ve()
{
	HinhThang::Ve();
}

void HinhChuNhat::Nhap()
{
	do
	{
		cout<<"Nhap diem 1:"<<endl;
		cout<<"Hoanh do: "; cin>>x1daylon;
		cout<<"Tung do: "; cin>>ydaylon;
		cout<<"Nhap diem 2:"<<endl;
		cout<<"Hoanh do: "; cin>>x2daybe;
		cout<<"Tung do: "; cin>>ydaybe;
		x2daylon = x2daybe;
		x1daybe = x1daylon;
		if (HinhThang::DieuKien())
			cout<<"\nKhong ve duoc hinh chu nhat! Nhap lai:"<<endl;
	}
	while (ydaylon==ydaybe || (ydaylon!=ydaybe && (x1daylon==x2daylon || x1daybe==x2daybe)));
}
void HinhChuNhat::Ve()
{
	HinhThang::Ve();
}

void HinhVuong::Nhap()
{
	int dodai;
	cout<<"Nhap 1 diem (Dinh tren ben trai):"<<endl;
	cout<<"Hoanh do: "; cin>>x1daylon;
	cout<<"Tung do: "; cin>>ydaylon;
	cout<<"Nhap do dai canh: "; cin>>dodai;
	x2daylon = x1daylon + dodai;
	ydaybe = ydaylon + dodai;
	x1daybe = x1daylon;
	x2daybe = x2daylon;
}
void HinhVuong::Ve()
{
	HinhThang::Ve();
}