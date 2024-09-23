#include "st.h"
#include <conio.h>
#include <iostream> 
using namespace std;

int main() 
{    
	int i,n,s;
	st sta;
	do
	{
		cout<<"Nhap so phan tu : ";
		cin>>n;
		if (n<=0) cout<<"Khong hop le. Nhap lai!"<<endl;
	}
	while(n<=0);
	for (i=1;i<=n;i++)
	{ 
		cout<<"Phan tu thu "<<i<<": "; cin>>s; 
		sta.push(s); 
	} 
	cout<<"\nGia tri trong Stack: "; 
	sta.print(); 
	getch();
	return 0; 
}