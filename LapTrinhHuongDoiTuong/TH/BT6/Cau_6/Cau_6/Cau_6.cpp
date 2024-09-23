#include "C_String.h"
#include <iostream>
using namespace std;

void main()
{
	C_String s1,s2,s3;
	s3="Nhap 2 chuoi:";
	cout<<s3<<endl;
	cout<<"Nhap chuoi 1:"<<endl; cin>>s1;
	cout<<"Nhap chuoi 2:"<<endl; cin>>s2;
	if (s1==s2)
		cout<<"\nHai chuoi giong nhau!"<<endl;
	if (s1!=s2)
		cout<<"\nHai chuoi khac nhau!"<<endl;
	cout<<"Noi chuoi:"<<endl<<s1+s2<<endl;
	system("pause");
}
