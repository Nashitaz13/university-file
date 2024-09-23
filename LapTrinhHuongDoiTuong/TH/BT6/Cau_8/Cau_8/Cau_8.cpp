#include "Matrix.h"
#include "Vector.h"
#include <iostream>
using namespace std;

void main()
{
	CVector x,y;
	CMatrix a,b;
	cout<<"Nhap vector X: "<<endl; cin>>x;
	cout<<"Nhap vector Y: "<<endl; cin>>y;
	cout<<"\nVector X: "<<x<<endl;
	cout<<"Vector Y: "<<y<<endl;
	cout<<"Tong cua vector X va vector Y"<<endl<<x+y<<endl;
	cout<<"Hieu cua vector X va vector Y"<<endl<<x-y<<endl;
	cout<<"\nNhap ma tran A: "<<endl; cin>>a;
	cout<<"Nhap ma tran B: "<<endl; cin>>b;
	cout<<"\nMa tran A:"<<endl<<a;
	cout<<"Ma tran B:"<<endl<<b;
	cout<<"Tong cua ma tran A va ma tran B"<<endl<<a+b;
	cout<<"Hieu cua ma tran A va ma tran B"<<endl<<a-b;
	cout<<"Tich cua vector X va ma tran A"<<endl<<x*a<<endl;
	cout<<"Tich cua ma tran A va ma tran B"<<endl<<a*b<<endl;
	system("pause");
}