// Listdon_dathuc.cpp : Defines the entry point for the console application.
//

#include "stdio.h"
#include "conio.h"
#include "stdlib.h"
typedef struct cautrucdonthuc
{
	int heso;
	int somu;
}donthuc;
typedef struct cautrucdon
{
	donthuc info;
	struct cautrucdon *next;
}NODE;
typedef struct dathuc
{
	NODE *head,*tail;
}LIST;

void menu()
{
	printf("\nO: thoat");
	printf("\n1: nhap cac don thuc");
	printf("\n2: Xuat da thuc");
	printf("\n3: Them don thuc vao dau danh sach");
	printf("\n4: Them don thuc vao cuoi danh sach");
	printf("\n5: Rut gon");
	printf("\n6: Sap xep da thuc");
	printf("\n7: Cong 2 da thuc");
	printf("\n9: Tru 2 da thuc");
	printf("\n10: Nhan 2 da thuc");
}
void khoitaods(LIST &L)
{
	L.head=L.tail=NULL;
}
NODE *taophantu(donthuc x)
{
	NODE *p;
	p=new NODE;
	if(p==NULL)
	{
		printf("\nKhong du bo nho!");
		exit(1);
	}
	else
	{
		p->info=x;
		p->next=NULL;
	}
	return p;
}
void themdau(LIST &L, donthuc x)
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

void themcuoi(LIST &L, donthuc x)
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
void nhapDonthuc(donthuc &x)
{
	int tam;
	printf("\nNhap he so: ");
	scanf("%d",&tam);
	x.heso=tam;
	printf("Nhap so mu: ");
	scanf("%d",&tam);
	x.somu=tam;
}
void nhapds(LIST &L)
{
	NODE *p;
	donthuc x;
	p=L.head;
	printf("\nNhap -1 de ket thuc");
	int i=0;
	do
	{
		printf("\nNhap phan tu thu %d: ",i+1);
		nhapDonthuc(x);
		themcuoi(L,x);
		i++;

	}
	while(x.somu>0);
}

void xuatDonthuc(donthuc x)
{
	if(x.somu==0)
		printf(" %d ",x.heso);
	else
	{
		if(x.somu==1)
			printf(" %dx +",x.heso);
		else
			printf(" %dx^%d +",x.heso,x.somu);
	}
}
void xuatds(LIST L)
{
	NODE *p;
	p=L.head;
	while(p!=NULL)
	{
		xuatDonthuc(p->info);
		p=p->next;
	}
	printf("\n");
}
void xoa(LIST &L, NODE *p)
{
	NODE *q;
	q=L.head;
	if (q==p)
	{
		L.head=p->next;
		delete p;
	}
	while(q&&(q->next!=p))
		q=q->next;
	if(q!=NULL)
	{
		if(p==L.tail)
			L.tail=q;
		q->next=p->next;
		delete p;
	}
}
LIST rutgon(LIST &L)
{
	NODE *p,*q;
	p=L.head;
	q=p->next;
	while(q!=NULL)
	{
		if(q->info.somu==p->info.somu)
			{
				p->info.heso=p->info.heso+q->info.heso;
				p->next=q->next;
				xoa(L,q);
				q=q->next;
			}
		else
		{
			q=q->next;
			p=p->next;
		}
	}
	return L;
}
void doicho(donthuc &x, donthuc &y)
{
	donthuc tam;
	tam=x;
	x=y;
	y=tam;
}
void sapxep(LIST &L)
{
	NODE *p,*q,*vt;
	p=L.head;
	while(p!=L.tail)
	{
		vt=p;
		q=p->next;
		while(q)
		{
			if(q->info.somu>vt->info.somu)
				vt=q;
			q=q->next;
		}
		doicho(p->info,vt->info);
		p=p->next;
	}
}

LIST cong2dt(LIST L1, LIST L2)
{
	LIST L;
	if(L1.head==NULL)
	{
		L.head=L2.head;
		L.tail=L2.tail;
	}
	else
	{
		if(L2.head==NULL)
		{
			L.head=L1.head;
			L.tail=L1.tail;
		}
		else
		{
			L.head=L1.head;
			L1.tail->next=L2.head;
			L.tail=L2.tail;
		}
	}
	sapxep(L);
	rutgon(L);
	return L;
}
LIST tru2dt(LIST L1, LIST L2)
{
	LIST L;
	NODE *p;
	p=L2.head;
	while(p)
	{
		p->info.heso=p->info.heso*-1;
		p=p->next;
	}
	L=cong2dt(L1,L2);
	return L;
}
donthuc nhandonthuc(NODE *p, NODE *q)
{
	donthuc x;
	x.heso=p->info.heso*q->info.heso;
	x.somu=p->info.somu+q->info.somu;
	return x;
}
LIST nhan2dt(LIST L1, LIST L2)
{
	donthuc x;
	LIST L;
	khoitaods(L);
	NODE *p,*q;
	p=L1.head;
	while(p)
	{
		q=L2.head;
		while(q)
		{
			x=nhandonthuc(p,q);
			themdau(L,x);
			q=q->next;
		}
		p=p->next;
	}
	sapxep(L);
	rutgon(L);
	return L;
}
int main()
{
	int c;
	donthuc x,y;
	LIST L,L1,L2;
	khoitaods(L);
	do
	{
		menu();
		printf("\nChon chuc nang can thuc hien: ");
		scanf("%d",&c);
		switch(c)
		{
			case 0:
				exit (1);
			case 1:
				khoitaods(L);
				nhapds(L);
				break;
			case 2:
                printf("\n");
				xuatds(L);
				break;
			case 3:
				printf("\nNhap don thuc can them: ");
				nhapDonthuc(x);
				themdau(L,x);
				break;
			case 4:
				printf("\nNhap don thuc can them: ");
				nhapDonthuc(x);
				themcuoi(L,x);
				break;

			case 5:
				rutgon(L);
				break;
			case 6:
				sapxep(L);
				break;
			case 7:
				khoitaods(L);
				khoitaods(L1);
				khoitaods(L2);
				printf("\nNhap da thuc L1: ");
				nhapds(L1);
				printf("\nNhap da thuc L2: ");
				nhapds(L2);
				L=cong2dt(L1,L2);
				break;
			case 8:
				khoitaods(L);
				khoitaods(L1);
				khoitaods(L2);
				printf("\nNhap da thuc L1: ");
				nhapds(L1);
				printf("\nNhap da thuc L2: ");
				nhapds(L2);
				L=tru2dt(L1,L2);
				break;
			case 9:
				khoitaods(L);
				khoitaods(L1);
				khoitaods(L2);
				printf("\nNhap da thuc L1: ");
				nhapds(L1);
				printf("\nNhap da thuc L2: ");
				nhapds(L2);
				L=nhan2dt(L1,L2);
				break;
		default:
				printf("\nSai chuc nang!!!");
				break;
		}
	}
	while (1);
	return 1;
}

