#include "str.h"
#include <iostream>
#include <conio.h>
using namespace std;
void main()
{
	str S1,S2;
	cout<<"Nhap chuoi 1:"<<endl;
	S1.Nhap();
	cout<<"Nhap chuoi 2:"<<endl;
	S2.Nhap();
	cout<<"\nChuoi 1 co do dai "<<S1.ChieuDai()<<" ki tu"<<endl;
	cout<<"Chuoi 2 co do dai "<<S2.ChieuDai()<<" ki tu"<<endl;
	cout<<"\nNoi 2 chuoi:"<<endl;
	S1.NoiChuoi(S2);
	cout<<"\nDao chuoi:"<<endl;
	S1.DaoChuoi();
	getch();
}
