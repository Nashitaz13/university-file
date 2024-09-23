#include "danhsach.h"
#include "node.h"
#include <iostream>
using namespace std;

danhsach::danhsach(void)
{
	head=tail=NULL;
}
danhsach::~danhsach(void)
{
}
void danhsach::Nhap()
{
	node *p;
	int i,x,n;
	cout<<"Nhap so phan tu:";
	cin>>n;
	for(i=0; i<n;i++)
	{
		cout<<"Nhap phan tu thu "<<i+1<<": ";
		cin>>x;
		p=TaoNode(x);
		ThemCuoi(p);
	}
}
void danhsach::Xuat()
{
	for (node *a=head; a; a=a->next)
	{
		if (a!=head)
			cout<<"->";
		cout<<a->data;
	}
}
void danhsach::ThemDau(node *p)
{
	if (head)
	{
		p->next=head;
		head=p;
	}
	else
		head=tail=p;
}
void danhsach::ThemCuoi(node *p)
{
	if (tail)
	{
		tail->next=p;
		tail=p;
	}
	else
		head=tail=p;
}
