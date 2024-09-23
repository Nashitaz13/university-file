#include "Date.h"
#include <iostream>
using namespace std;

void main()
{
	CDate d1,d2;
	int s;
	cout<<"Nhap ngay thang Date1:"<<endl; cin>>d1;
	cout<<"Date1: "<<d1<<endl;
	cout<<"\nCong them 1 ngay: "<<d1++<<endl;
	cout<<"Tru ra 1 ngay: "<<d1--<<endl;
	cout<<"\nCong (tru) them ngay: "; cin>>s;
	cout<<d1<<" + "<<s<<" ngay = "<<d1+s<<endl;
	cout<<d1<<" - "<<s<<" ngay = "<<d1-s<<endl;
	cout<<"\nNhap ngay thang Date2:"<<endl; cin>>d2;
	cout<<"Date2: "<<d2<<endl;
	cout<<"\nKhoang cach giua Date1 va Date2: "<<d1-d2<<" ngay"<<endl;
	system("pause");
}
