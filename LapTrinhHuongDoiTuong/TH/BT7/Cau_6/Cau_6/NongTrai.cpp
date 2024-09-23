#include "NongTrai.h"


NongTrai::NongTrai(void)
{
}
NongTrai::~NongTrai(void)
{
}
void NongTrai::Nhap()
{
	Bo::Nhap();
	Cuu::Nhap();
	De::Nhap();
}
void NongTrai::Xuat()
{
	Bo::Xuat(); cout<<endl;
	Cuu::Xuat(); cout<<endl;
	De::Xuat(); cout<<endl;
}