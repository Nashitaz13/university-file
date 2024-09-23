#include "De.h"


De::De(void)
{
}
De::~De(void)
{
}
void De::Nhap()
{
	cout<<"Nhap so luong de: ";
	cin>>soluong;
	srand(time(0));
	sua=rand()%11+0;
	con=rand()%2+1;
}
void De::Xuat()
{
	cout<<"So luong de: "<<soluong<<endl;
	cout<<"So luong sua moi con de: "<<sua<<endl;
	cout<<"So luong sua cua dan de: "<<soluong*sua<<endl;
	cout<<"So luong con moi lua 1 con de co the sinh: "<<con<<endl;
	cout<<"So luong con moi lua dan de co the sinh: "<<soluong*con<<endl;
}
