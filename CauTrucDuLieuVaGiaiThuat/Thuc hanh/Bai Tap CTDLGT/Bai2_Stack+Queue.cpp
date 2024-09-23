#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
typedef struct cautrucNode
{
    int info;												
    struct cautrucNode *next; 									
}NODE; 														
 
typedef struct stack
{
    NODE *head; 											
    NODE *tail; 											
}LIST; 														

void khoitao(LIST &L)
{
    L.head = NULL; 										
    L.tail = NULL; 										
}


NODE *taophantu(int x)
{
    NODE *p;
    p = new NODE;
    if (p==NULL)
    {
   return NULL;
    }
    p->info = x;
    p->next = NULL;
    return p;
}

void themdau(LIST &L, int x)
{
	NODE *moi;
	moi=taophantu(x);
	if(L.head==NULL)
		L.head=L.tail=moi;
	else
	{
		moi->next=L.head;
		L.head=moi;
	}
}
void themcuoi(LIST &L, int x)
{
	NODE *moi;
	moi=taophantu(x);
	if(L.head==NULL)
		L.head=L.tail=moi;
	else
	{
		L.tail->next=moi;
		L.tail=moi;
	}
}
void xoadau(LIST &L)
{
	NODE *p;
	if(L.head!=NULL)
	{
		p=L.head;
		L.head=p->next;
		delete p;
		if(L.head==NULL)
			L.tail=NULL;
	}
}
void nhapStack(LIST &L)
{
	NODE *p;
	p=L.head;
	printf("\nNhap -1 de ket thuc");
	int x,i=0;
	do
	{
		printf("\nNhap phan tu thu %d: ",i+1);
		scanf("%d",&x);
		if(x>=0)
		{
			themdau(L,x);
			i++;
		}
	}
	while(x>=0);
}
void nhapQueue(LIST &L)
{
	NODE *p;
	p=L.head;
	printf("\nNhap -1 de ket thuc");
	int x,i=0;
	do
	{
		printf("\nNhap phan tu thu %d: ",i+1);
		scanf("%d",&x);
		if(x>=0)
		{
			themcuoi(L,x);
			i++;
		}
	}
	while(x>=0);
}
void xuatds(LIST L)
{
	NODE *p;
	p=L.head;
	while(p!=NULL)
	{
		printf("%3d",p->info);
		p=p->next;
	}
	printf("\n");
}


char IsEmpty(LIST &L)
{
	if(L.head)
		return 0;
	else 
		return 1;
}


void themvaostack(LIST &L, int x)
{
	themdau(L,x);
}


void themvaoqueue(LIST &L, int x)
{
	themcuoi(L,x);
}


int Ptu_dau(LIST &L)
{
	int x;
	if(IsEmpty(L)==0) 
	{
		x=L.head->info;
		return x;
	}
	return NULL;
}


void huy_ptu_dau(LIST &L)
{
	if(IsEmpty(L)==0) 	
		xoadau(L);
	else
		printf("Danh sach rong");
}


void menu()    
{    
	printf("\n"); 
	printf("UNG DUNG DSLK DON CAI DAT STACK VA QUEUE"); 
	printf("\n");
	printf("\nThao tac voi STACK");
	printf("\n	1: Nhap Stack");
	printf("\n	2: Xuat Stack");
	printf("\n	3: Them Stack");
	printf("\n	4: In phan tu dau cua Stack");
	printf("\n	5: Huy phan tu dau cua Stack");
	printf("\n");
	
	printf("\nThao tac voi QUEUE");
	printf("\n	6: Nhap Queue");
	printf("\n	7: Xuat Queue");
	printf("\n	8: Them Queue");
	printf("\n	9: In phan tu dau cua Queue");
	printf("\n	10: Huy phan tu dau cua Queue");
	printf("\n");
	printf("\n*Nhap 0 de Thoat");
}

void main()
{
	int ch;
	LIST L;
	khoitao(L);
	int x;
	do
	{
		menu();
		printf("\nChon chuc nang can thuc hien: ");
		scanf("%d",&ch);
		switch(ch)
		{
			case 0: 
				return;
			case 1: 
				{
					khoitao(L);
					nhapStack(L);
					break;
				}
			case 2:
				{
					xuatds(L);
					break;
				}
			case 3:	
				{
					printf("\nThem phan tu co gia tri: ");
					scanf("%d",&x);
					themvaostack(L,x);
					break;
				}
			case 4: 
				{
					int s=Ptu_dau(L); 
					printf("\nPhan tu dau cua Strack la %d",s);
					printf("\n");
					break;
				}
			case 5: 
				{
					huy_ptu_dau(L);
					break;
				}
			case 6:
				{
					khoitao(L);
					nhapQueue(L);
					break;
				}
			case 7:
				{	
					xuatds(L);
					break;
				}
			case 8:	
				{
					printf("\nThem phan tu co gia tri: ");
					scanf("%d",&x);
					themvaoqueue(L,x);
					break;
				}
			case 9:
				{
					int q=Ptu_dau(L); 
					printf("\nPhan tu dau tien cua Queue la %d",q);
					printf("\n");
					break;
				}
			case 10:
				{
					huy_ptu_dau(L);
					break;
				}

			default: printf("\nChon lai !\n");break;
		}
	}
	while(1);
}