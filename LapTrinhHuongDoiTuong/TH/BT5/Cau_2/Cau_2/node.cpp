#include "node.h"
#include <iostream>
using namespace std;

node::node(void)
{
}
node::node(int x)
{
	data=x;
	next=NULL;
}
node::~node(void)
{
}
node* node::TaoNode(int x)
{
	node *p;
	p=new node;
	if(p==NULL)
	{
		cout<<"Bo Nho Day!"<<endl;
		exit(1);
	}
	p->data=x;
	p->next=NULL;
	return p;
}