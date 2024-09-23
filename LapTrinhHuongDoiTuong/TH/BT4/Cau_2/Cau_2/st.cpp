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
		cout<<sta[top-it-1]<<" "; 
		it++; 
	} 
	while (it<top); 
}  