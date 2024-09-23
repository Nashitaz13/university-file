#include "text.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <string>
using namespace std;

text::text(void)
{
}
text::~text(void)
{
}
void text::Doc()
{
	int d=0;
	ifstream bt;
	bt.open( "baitap.txt",ios::in);
	while (!bt.eof() ) 
	{ 
		if(getline(bt,t))
			cout<<t<< endl;
	}
	bt.close();
}
vector<string> text::LuuCau()
{
	vector<string> p;
	int k,i=0;
	ifstream bt;
	bt.open( "baitap.txt", ios::in);
	while(!bt.eof() ) 
	{
		bt>>t;
		p.push_back(t);
	}
	bt.close();
	return p;
}
vector<string> text::LuuTu()
{
	vector<string> p;
	int k,i=0;
	ifstream bt;
	bt.open( "baitap.txt", ios::in);
	while(!bt.eof() ) 
	{
		bt>>t;
		p.push_back(t);
	}
	bt.close();
	for (int j=0;j<p.size();j++)
	{
		if(p[j].back()<'A'||p[j].back()>'z')
			 p[j]=p[j].erase(p[j].size()-1,1);
	}
	return p;
}
int text::SLCau()
{
	int d=0;
	ifstream bt;
	bt.open( "baitap.txt", ios::in);
	while (!bt.eof() ) 
	{ 
		if(getline(bt,t,'.')||getline(bt,t,'?')||getline(bt,t,'!'))
			d++;
	}
	bt.close();
	return d;
}
void text::SLTu(int d[], int &i, ofstream &bt)
{
	int k,q,p;
	d[0]=0;
	ifstream bt1;
	bt1.open( "baitap.txt", ios::in);
	while (!bt1.eof() ) 
	{ 
		if(getline(bt1,t,' '))
			{
				d[i]++;
				k=t.find(".");
				p=t.find("?");
				q=t.find("!");
				if((k>-1)||(p>-1)||(q>-1))
				{
					bt<<"\nSo luong tu trong cau "<<i+1<<": ";
					bt<<d[i]<<" tu";
					i++;
					d[i]=0;
				}
			}
	}
	bt1.close();
}
int text::Max(vector<string> &p, int d[])
{
	int max;
	max=0;
	for(int i=0;i<p.size();i++)
		{
			d[i]=0;
			for(int j=i+1;j<p.size();j++)
			{
				if(p[i]==p[j]) d[i]++;
				if(max<d[i]) max=d[i];
			}
		}
	return max;
}
void text::SapXep(vector<string> &p)
{
	int k,s,q;
	int v=0;
	for(int i=0;i<p.size();i++)
	{
		k=p[i].find(".");
		s=p[i].find("?");
		q=p[i].find("!");
		if((k>-1)||(s>-1)||(q>-1))
		{
			for(int j=v;j<i;j++)
			{
				for(int m=i;m>j;m--)
					if(p[m]<p[m-1])
					{	
						t=p[m];
						p[m]=p[m-1];
						p[m-1]=t;
					}
			}
			v=i+1;
		}
	}
}