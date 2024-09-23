#include "PhanSo.h"
#include <iostream>
#include <conio.h>
using namespace std;

void main()
{
	PhanSo a,b;
	cout<<"Nhap phan so thu 1:"<<endl; cin>>a;
	cout<<"Nhap phan so thu 2:"<<endl; cin>>b;
	cout<<a<<" + "<<b<<" = "<<a+b<<endl;
	cout<<a<<" - "<<b<<" = "<<a-b<<endl;
	cout<<a<<" * "<<b<<" = "<<a*b<<endl;
	if (b==0)
		cout<<"Khong thuc hien duoc phep chia!"<<endl;
	else
		cout<<a<<" / "<<b<<" = "<<a/b<<endl;
	cout<<"!("<<a<<") = "<<!a<<endl;
	cout<<"!("<<b<<") = "<<!b<<endl;
	if (a==b)
		cout<<"Hai phan so bang nhau!"<<endl;
	if (a!=b)
		cout<<"Hai phan so khac nhau!"<<endl;
	system("pause");
}
