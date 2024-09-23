#include "st.h"
#include <conio.h>
#include <iostream>
using namespace std;
st::st(void)
{
	top = 0; 
	m = 100;
}
st::~st(void)
{
}
int st::isempty()
{
	if(top==0) 
	return 1; 
	else 
	return 0;
} 
int st::isfull()
{
	if(top == m) return 1; 
	else return 0; 
}
void st::push(int a)
{
	if(!(isfull())) 
		sta[top++] = a; 
}
void st::pop(int &a)
{
	if(!isempty()) a = sta[--top]; 
}
void st::print() 
{ 
	int it = 0; 
	do 
	{ 
		if (top-it==1) 
			cout<<sta[top-it-1];
		else 
			cout<<sta[top-it-1]<<"*"; 
		it++; 
	} 
	while (it<top); 
}  
int st::ktsnt(int n)
{
	int i,ok=1;
	if(n<2) ok=0;
	if(n==2) ok=1;
	if(n>2)
	{
	for(i=2;i*i<=n;i++)
		if(n%i==0) break;
		if(i*i<=n) ok=0; else ok=1;
	}
	return ok;
}