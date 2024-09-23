#include "st.h"
#include <conio.h>
#include <iostream>
using namespace std;
int main() 
{    
	int i,s,np,bp,tlp;
	char c;
	st stnp;
	st stbp;
	st sttlp;
	do
	{
		cout<<"Nhap so nguyen duong (He thap phan): ";
		cin>>s;
		if (s<=0) cout<<"Khong hop le. Nhap lai!"<<endl;
	}
	while (s<=0);
	np=s;
	while (np!=0)
	{
		i=np-(np/2)*2;
		np=np/2;
		stnp.push(i);
	}
	bp=s;
	while (bp!=0)
	{
		i=bp-(bp/8)*8;
		bp=bp/8;
		stbp.push(i);
	}
	tlp=s;
	while (tlp!=0)
	{
		i=tlp-(tlp/16)*16;
		if (i==0) c='0';
		if (i==1) c='1';
		if (i==2) c='2';
		if (i==3) c='3';
		if (i==4) c='4';
		if (i==5) c='5';
		if (i==6) c='6';
		if (i==7) c='7';
		if (i==8) c='8';
		if (i==9) c='9';
		if (i==10) c='A';
		if (i==11) c='B';
		if (i==12) c='C';
		if (i==13) c='D';
		if (i==14) c='E';
		if (i==15) c='F';
		tlp=tlp/16;
		sttlp.pushchar(c);
	}
	cout<<"\nHe thap luc phan: ";
	sttlp.printchar();
	cout<<"\nHe bat phan: ";
	stbp.print();
	cout<<"\nHe nhi phan: ";
	stnp.print();
	getch();
	return 0; 
} 