#include <conio.h>
#include <iostream> 
#include "st.h"
using namespace std;
int main() 
{    
	int i,n,s;
	st sta;
	do
	{
		cout<<"Nhap so nguyen n (n>=0): ";
		cin>>n;
		if (n<0) cout<<"Khong hop le. Nhap lai!"<<endl;
	}
	while (n<0);
	if (n==0||n==1) cout<<n<<" khong phai la so nguyen to!";
	else
	{
		s=n;
		for (i=2;i<=n;i++)
		{
			if (sta.ktsnt(i))
			{
				while(s%i==0)
				{
					sta.push(i);
					s=s/i;
				}
			}
		}
	cout<<n<<" = "; 
	sta.print(); 
	}
	getch();
	return 0; 
} 