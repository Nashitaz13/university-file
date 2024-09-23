#include "MYINT.h"
#include <iostream>
using namespace std;

void main()
{
	MYINT a,b;
	cout<<"Nhap so a: "; cin>>a;
	cout<<"Nhap so b: "; cin>>b;
	cout<<a<<" + "<<b<<" = "<<a+b<<endl;
	cout<<a<<" - "<<b<<" = "<<a-b<<endl;
	cout<<a<<" * "<<b<<" = "<<a*b<<endl;
	cout<<a<<" / "<<b<<" = "<<a/b<<endl;
	if (a==b)
		cout<<"a bang b!"<<endl;
	if (a!=b)
		cout<<"a khac b!"<<endl;
	system("pause");
}
