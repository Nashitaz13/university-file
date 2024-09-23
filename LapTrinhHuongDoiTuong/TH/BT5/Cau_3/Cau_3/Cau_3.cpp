#include "text.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <conio.h>
using namespace std;
void main()
{
	int d[100],e[1000],max,i=0;
	ofstream bt;
	bt.open( "xuat_baitap.txt", ios::out);
	text T;
	vector<string> p1,p2;
	p1=T.LuuCau();
	p2=T.LuuTu();
	T.Doc();
	bt<<"So luong cau trong doan van: "<<T.SLCau()<<" cau"<<endl;
	bt<<"\nSo luong tu trong moi cau:";
	T.SLTu(d,i,bt);
	max=T.Max(p2,e);
	bt<<endl<<"\nNhung tu xuat hien nhieu nhat trong doan van: ";
	for(int i=0;i<p2.size();i++)
		if(max==e[i])  bt<<p2[i]<<" ";
	bt<<endl;
	bt<<"\nDoan van sau khi duoc sap xep: "<<endl;
	T.SapXep(p1);
	for(int j=0;j<p1.size();j++)
		bt<<p1[j]<<" ";
	bt.close();
	getch();
}