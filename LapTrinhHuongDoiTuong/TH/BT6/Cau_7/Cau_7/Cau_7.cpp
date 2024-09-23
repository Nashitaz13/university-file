#include "DaThuc.h"
#include <iostream>
using namespace std;

void main()
{
	DaThuc Fx,Gx;
	int x;
	cout<<"Nhap da thuc Fx:"<<endl; cin>>Fx;
	cout<<"\nNhap da thuc Gx:"<<endl; cin>>Gx;
	cout<<"\nFx = "<<Fx<<endl;
	cout<<"Gx = "<<Gx<<endl;
	cout<<"\nFx + Gx = "<<Fx+Gx<<endl;
	cout<<"Fx - Gx = "<<Fx-Gx<<endl;
	cout<<"\nNhap gia tri x: "; cin>>x;
	cout<<"Fx("<<x<<") = "<<Fx(x)<<endl;
	cout<<"Gx("<<x<<") = "<<Gx(x)<<endl;
	system("pause");
}