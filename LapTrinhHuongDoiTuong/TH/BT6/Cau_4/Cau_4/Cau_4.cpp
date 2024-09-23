#include "C_Time.h"
#include <iostream>
using namespace std;

void main()
{
	C_Time t1,t2,t3;
	int s;
	cout<<"Nhap thoi gian T1:"<<endl; cin>>t1;
	cout<<"T1: "<<t1<<endl;
	cout<<"\nThem 1 giay: "<<t1++<<endl;
	cout<<"Bot 1 giay: "<<t1--<<endl;
	cout<<"\nCong(tru) mot so nguyen giay: "; cin>>s;
	cout<<t1<<" + "<<s<<" giay = "<<t1+s<<endl;
	cout<<t1<<" - "<<s<<" giay = "<<t1-s<<endl;
	cout<<"\nNhap thoi gian T2:"<<endl; cin>>t2;
	cout<<"T2: "<<t2<<endl;
	cout<<"\nKhoang thoi gian giua T1 va T2:"<<endl;
	cout<<t1-t2<<endl;
	cout<<"\nNhap thoi gian bat dau cho dong ho: "<<endl; cin>>t3;
	t3.DongHo();
}
