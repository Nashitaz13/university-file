#include "conio.h"
#include "stdio.h"
#include "stdlib.h"
#include "iostream"

#define ESC 27
using namespace std;

typedef struct Data
{
	int ts;
	int ms;
};

typedef struct tagLNode
{
	Data info;
	struct tagLNode *pNext;
}LNode;

typedef struct tagLList
{
	LNode *pHead;
	LNode *pTail;
}LList;

//tao danh sach rong
void create_list(LList &l)
{
	l.pHead = l.pTail = NULL;
}

//tao phan tu co truong la data

LNode *create_node_list(Data x)
{
	LNode *p = new LNode;
	if(!p)
	{
		cout<<"Ko du bo nho!";
		exit(1);
	}
	p->info = x;
	p->pNext = NULL;
	return p;
}

//them phan tu vao dau danh sach
void add_head_list(LList &l,Data x)
{
	LNode *newnode = create_node_list(x);
	if(!l.pHead)
	{
		l.pHead = newnode;
		l.pTail = l.pHead;
	}
	else
	{
		newnode->pNext = l.pHead;
		l.pHead = newnode;
	}
}

void add_tail_list(LList &l, Data x)
{
	LNode *newnode = create_node_list(x);
	if(!l.pHead)
	{
		l.pHead = newnode;
		l.pTail = l.pHead;
	}
	else
	{
		l.pTail->pNext = newnode;
		l.pTail = newnode;
	}
}

//nhap xau
void input_list(LList &l )
{
	Data x;
	LNode *p;
	do
	{
		cout<<"\nNhap tu so: ";
		cin>>x.ts;
		cout<<"\nNhap mau so: ";
		cin>>x.ms;
		if(x.ms == 0 )
			break;
		p = create_node_list(x);
		add_tail_list(l,p->info);

	} while (x.ms != 0);
}

//tim phan tu trong xau
LNode *search_node_list(LList &l , Data x)
{
	LNode *p = l.pHead;
	if( !l.pHead )
		return NULL;
	else
	{
		while (p != NULL && (p->info.ms != x.ms || p->info.ts != x.ts))
		{
			p = p->pNext;
		}
	}
	return p;
}

//Them phan tu vao sau phan tu Q
void add_afterQ(LList &l)
{
	Data x, y;
	LNode *p , *q=NULL;
	cout<<"\nNhap phan tu can them phia sau: ";
	cin>>x.ts>>x.ms;
	cout<<"\nNhap phan tu muon them: ";
	cin>>y.ts>>y.ms;
	q = search_node_list(l,x);
	p = create_node_list(y);

	if(q)
	{
		p->pNext =q->pNext;
		q->pNext = p;
		if(l.pTail == q)
			l.pTail = p;
	}
	else
	{
		cout<<"\nVi tri ko ton tai!";
		exit(1);
	}
}

//them phan tu  x vao truoc phan tu thu k
void add_at_list(LList &l , int index ,Data x)
{
	int count = 1;//đếm
	int found = 0;//kết quả
	LNode *p ,*q=NULL;
	
	p = l.pHead;
	while (p && found == 0)
	{
		if(count == index-1) // dem = chi so -1
		{
			q = new LNode; //gan cho q vung nho
			q->info = x;
			q->pNext = p->pNext;
			p->pNext = q;
			found = 1;
		}
		
		if(index == 1)
		{
			add_head_list(l,x);
			found = 1;
		}
		count ++;
		p = p->pNext;
	}
	if(found == 0)
	{
		cout<<"\nKo tim thay vi tri can tim!";
	}
}

//xoa phan tu dau xau
void remove_head_list(LList &l)
{
	LNode *p;
	if( !l.pHead )
		return ;
	p = l.pHead;
	l.pHead = l.pHead->pNext;
	p->pNext = NULL;
	free(p);
}

//xoa phan tu cuoi xau
void remove_tail_list(LList &l)
{
	LNode *p = l.pHead;
	while (p)
	{
		if(p->pNext == l.pTail)
			break;
		p = p->pNext;
	}

	if( !p && l.pHead )
	{
		p = l.pHead;
		l.pHead = l.pTail = NULL;
		free(p);
	}
	else
	{
		l.pTail = p;
		free(p->pNext);
		p->pNext =NULL;
	}
}

//xoa phan tu có giá tri = x
void remove_value_list(LList &l , Data x)
{
	LNode * p, *q = NULL;
	p = l.pHead;
	while (p && (p->info.ts != x.ts && p->info.ms != x.ms))
	{
		q=p;
		p = p->pNext;
	}
	if( !p ) return;
	if(q)
	{
		q->pNext = p->pNext;
		p->pNext = NULL;
		delete p;
	}
	else
	{
		l.pHead = l.pHead->pNext;
	}
}

//xoa phan tu sau phan tu Q
void remove_afterQ_list(LList &l, int index)
{
	int count = 1;// dem
	int found = 0;//ket qua
	LNode *p, *q=NULL;
	p = l.pHead;
	while (p && found == 0)
	{
		if(count == index)//dem  = chi so
		{
			q = p->pNext;
			p->pNext = q->pNext;
			q->pNext = NULL;
			free(q);
			found = 1;
		}
		count ++;
		p = p->pNext;
	}
	if(found == 0)
		cout<<"\nKO tim thay phan tu!";
}

//xoa toan bo xau
void remove_list(LList &l)
{
	LNode *p;
	while (l.pHead != NULL)
	{
		p = l.pHead;
		l.pHead = l.pHead->pNext;
		delete p;
	}
}
//xuat xau
void print_list(LList l)
{
	LNode *p = l.pHead;
	while(p!=NULL)
	{
		cout<<p->info.ts<<"/"<<p->info.ms<<"    ";
		p = p->pNext;
	}
}

//sao chep xau
void copy_list(LList l ,LList &cpy)
{
	LNode *p =l.pHead;
	while (p)
	{
		add_tail_list(cpy,p->info);
		p = p->pNext;
	}
}

//dao nguoc xau
void invert_list(LList l, LList &l1)
{
	LNode *p = l.pHead;
	while (p != NULL)
	{
		add_head_list(l1,p->info);
		p = p->pNext;
	}
}

//bubble sort
void bubblesort_list(LList &l)
{
	if(l.pHead == l.pTail )return;
	int swap;
	do
	{
		swap = 0;
		for(LNode *j = l.pHead ; j->pNext != NULL ; j=j->pNext)
		{
			if(j->info.ts/j->info.ms > j->pNext->info.ts/j->pNext->info.ms)
			{
				swap = 1;
			    Data x = j->info;
			    j->info = j->pNext->info;
			    j->pNext->info = x;
			}
		}
	} while (swap);
}
//so trung vi
int median_list(LList l)
{
	LList temp;
	create_list(temp);
	copy_list(l,temp);
	bubblesort_list(temp);
	int count = 0;
	LNode *p = l.pHead;
	while (p)
	{
		count ++;
		p = p->pNext;
	}
	p = temp.pHead;
	for(int i=0 ; i < count/2 ; i++)
	{
		p = p->pNext;
	}
	return p->info.ts/p->info.ms;
}

void menu()
{
	cout<<"\n0: exit(go ESC)";
	cout<<"\n1: Nhap xau";
	cout<<"\n2: Xuat xau";
	cout<<"\n3: Them pt sau pt Q";
	cout<<"\n4: Them pt truoc pt k";
	cout<<"\n5: Tim phan tu";
	cout<<"\n6: Xoa pt dau xau";
	cout<<"\n7: Xoa pt cuoi xau";
	cout<<"\n8: Xoa phan tu co gia tri x";
	cout<<"\n9: Xoa phan tu sau phan tu x";
	cout<<"\n10: Xoa toan bo xau";
	cout<<"\n11: Sao chep xau";
	cout<<"\n12: Dao nguoc xau";
	cout<<"\n13: Bubble Sort";
	cout<<"\n14: tim so trung vi";
	cout<<"\n";
}
int main()
{
	Data x;
	int n;
	LNode *p;
	LList l;
	LList l1;
	create_list(l);
	create_list(l1);
	menu();
	int c;
	do
	{
		cout<<"\nNhap lua chon: ";
		cin>>c;
		switch(c)
		{
		case 0:
			exit(1);
			break;
		case 1:
			{
			input_list(l);
			break;
			}
		case 2:
			{
			print_list(l);
			break;
			}
		case 3:
			{
			    add_afterQ(l);
				print_list(l);
			    break;
			}
		case 4:
			{
				int a;
				Data b;
				cout<<"\nNhap vi tri: ";
				cin>>a;
				cout<<"\nNhap phan tu can them: ";
				cin>>b.ts>>b.ms;
				add_at_list(l,a,b);
				cout<<"\n";
				print_list(l);
				break;
			}
		case 5:
			{
				cout<<"\nNhap phan tu can tim: ";
	            cin>>x.ts>>x.ms;
	            p = search_node_list(l,x);
	            if(p!=NULL)
		           cout<<"\nTim thay!";
	            else
		           cout<<"\nKo Tim thay!";
				break;
			}
		case 6:
			{
				remove_head_list(l);
				print_list(l);
				break;
			}
		case 7:
			{
				remove_tail_list(l);
				print_list(l);
				break;
			}
		case 8:
			{
				cout<<"\Nhap phan tu muon xoa: ";
				cin>>x.ts>>x.ms;
				remove_value_list(l,x);
				print_list(l);
				break;
			}
		case 9:
			{
				cout<<"\nNhap vi tri phan tu muon xoa sau: ";
				cin>>n;
				remove_afterQ_list(l,n);
				print_list(l);
				break;
			}
		case 10:
			{
				remove_list(l);
				print_list(l);
			}
		case 11:
			{
				copy_list(l,l1);
				print_list(l1);
				remove_list(l);
				cout<<"\nList l da xoa :\n ";
				print_list(l);
				cout<<"\nList l1 van con: \n";
				print_list(l1);
				break;
			}
		case 12:
			{
				invert_list(l,l1);
				cout<<"\nList sau khi dao nguoc: \n";
				print_list(l1);
				break;
			}
		case 13:
			{
				bubblesort_list(l);
				print_list(l);
				break;
			}
		case 14:
			{
				cout<<"\nSo trung vi la: "<<median_list(l);
				break;
			}
		}
	} while (1);
	
	return 0;
}
