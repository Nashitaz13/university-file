#include "queue.h"
#include <iostream>
#include <conio.h>
using namespace std;
int main()
{
   int n;
   Queue q;
   do
   {
	   cout<<"Nhap so phan tu : ";
	   cin>>n;
	   if (n<=0) cout<<"Khong hop le. Nhap lai!"<<endl;
   }
   while(n<=0);
   q.Nhap(n);
   q.Xuat(n);
   getch();
   return 0;
}
