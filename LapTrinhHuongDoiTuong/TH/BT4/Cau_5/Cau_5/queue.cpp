#include "queue.h"
#include <iostream>
using namespace std;

Queue::Queue(void)
{
	kichthuoc =100;
	data=new int(kichthuoc);
	rear=front=kichthuoc;
}
Queue::~Queue(void)
{
}
int Queue::isempty()
{
	if(front==kichthuoc && rear==kichthuoc)
		return 1;
	else
		return 0;

}
int Queue::isfull()
{
   if(rear-front+1==0 || rear-front+1==kichthuoc)
      return 1;
   else
	   return 0;   
}
void Queue::Add(int n)
{   
	if(isfull()==1)
	{
		cout<<"Queue Full";
		exit(0);
	}
	else
	{
		if(isempty()==0)
			front=0;
		if(rear>=kichthuoc-1)
		{
			rear=0;
			data[rear]=n;
		}
		else
			data[++rear]=n;
	}
}
int Queue::Remove()
{
	int x;
	if (isempty()==0)
	{
		x=data[front];
		if (front==rear)
			front=rear=kichthuoc;
		else
		{
			front++;
			if(front==kichthuoc)
				front=0;
		}
	}
	else
		x=-1;
    return x;
}
void Queue::Nhap(int k)
{
   int x;
   for(int i=1;i<=k;i++)
   {
      cout<<"Phan tu thu "<<i<<" :";
      cin>>x;
      Add(x);
   }   
}
void Queue::Xuat(int k)
{
   int i;
   cout<<"\nGia tri trong Queue: ";
   for(i=0;i<k;i++)
      cout<<Remove()<<" ";
}

