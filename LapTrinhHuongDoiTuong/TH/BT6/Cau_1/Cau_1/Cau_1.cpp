#include "SoPhuc.h"
#include <iostream>
#include <conio.h>
using namespace std;

void main()
{
	SoPhuc a,b;
	cout<<"Nhap so phuc thu 1:"<<endl; cin>>a;
	cout<<"Nhap so phuc thu 2:"<<endl; cin>>b; cout<<endl;
	cout<<a<<" + "<<b<<" = "<<a+b<<endl;
	cout<<a<<" - "<<b<<" = "<<a-b<<endl;
	cout<<a<<" * "<<b<<" = "<<a*b<<endl;
	cout<<a<<" / "<<b<<" = "<<a/b<<endl;
	cout<<"!"<<a<<" = "<<!a<<endl;
	cout<<"!"<<b<<" = "<<!b<<endl;
	if (a==b)
		cout<<"Hai so phuc bang nhau!"<<endl;
	if (a!=b)
		cout<<"Hai so phuc khac nhau!"<<endl;
	system("pause");
}
