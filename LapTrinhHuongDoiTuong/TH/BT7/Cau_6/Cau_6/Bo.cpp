#include "Bo.h"


Bo::Bo(void)
{
}
Bo::~Bo(void)
{
}
void Bo::Nhap()
{
	cout<<"Nhap so luong bo: ";
	cin>>soluong;
	srand(time(0));
	sua=rand()%21+0;
	con=rand()%2+1;
}
void Bo::Xuat()
{
	cout<<"So luong bo: "<<soluong<<endl;
	cout<<"So luong sua moi con bo: "<<sua<<endl;
	cout<<"So luong sua cua dan bo: "<<soluong*sua<<endl;
	cout<<"So luong con moi lua 1 con bo co the sinh: "<<con<<endl;
	cout<<"So luong con moi lua dan bo co the sinh: "<<soluong*con<<endl;
}
