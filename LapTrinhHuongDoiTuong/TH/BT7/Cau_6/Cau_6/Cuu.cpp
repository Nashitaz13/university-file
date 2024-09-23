#include "Cuu.h"


Cuu::Cuu(void)
{
}
Cuu::~Cuu(void)
{
}
void Cuu::Nhap()
{
	cout<<"Nhap so luong cuu: ";
	cin>>soluong;
	srand(time(0));
	sua=rand()%6+0;
	con=rand()%2+1;
}
void Cuu::Xuat()
{
	cout<<"So luong cuu: "<<soluong<<endl;
	cout<<"So luong sua moi con cuu: "<<sua<<endl;
	cout<<"So luong sua cua dan cuu: "<<soluong*sua<<endl;
	cout<<"So luong con moi lua 1 con cuu co the sinh: "<<con<<endl;
	cout<<"So luong con moi lua dan cuu co the sinh: "<<soluong*con<<endl;
}
