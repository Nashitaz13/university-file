#include <stdio.h>
#include <stdlib.h>
typedef struct xaudon
{
	int info;
	struct xaudon *next;
}node;
typedef struct danhsach
{
	node *head,*tail;
}list;


void khoitaods(list &l);
node *taophantu(int x);
void nhapds(list &l,int n);
void xuatds(list l);
void themdau(list &l,node *moidau);
void themcuoi(list &l,node *moicuoi);
void themsauq(list &l,node *q,node *moisauq);
void xoadau(list &l);
void xoacuoi(list &l,int n);
void xoasauq(list &l,node *q);
void xoaphantucoinfox(list &l,int x);

node *tim(list l,int x);

int main()
{
	list l;
	node *moidau,*moicuoi,*moisauq,*q;
	int n,x,y,z,a;
	printf("Nhap so phan tu cua xau: ");
	scanf("%d",&n);
	khoitaods(l);
	nhapds(l,n);
	xuatds(l);
	printf("\nNhap phan tu muon them vao dau xau: ");
	scanf("%d",&x);
	moidau=taophantu(x);
	themdau(l,moidau);
	xuatds(l);
	printf("\nXoa phan tu dau xau vua them vao: ");
	xoadau(l);
	xuatds(l);
	printf("\nNhap phan tu muon them vao cuoi xau : ");
	scanf("%d",&y);
	moicuoi=taophantu(y);
	themcuoi(l,moicuoi);
	xuatds(l);
	printf("\nXoa phan tu cuoi xau vua them vao: ");
	xoacuoi(l,n);
	xuatds(l);
	printf("\nNhap info cua phan tu muon them phan tu moi vao sau no :");
	scanf("%d",&z);
	q=tim(l,z);
	printf("\nNhap phan tu muon them vao sau %d: ",q->info);
	scanf("%d",&a);
	moisauq=taophantu(a);
	themsauq(l,q,moisauq);
	xuatds(l);
	printf("\nXoa phan tu vua them vao");
	xoasauq(l,q);
	xuatds(l);
	printf("\nXoa phan tu co info la %d",z);
	xoaphantucoinfox(l,z);
	xuatds(l);
	return 0;
}
void khoitaods(list &l)
{
	l.head=l.tail=NULL;
}
node *taophantu(int x)
{
	node *p;
	p=new node;
	if(p==NULL)
	{ 
		printf("khong du bo nho");
		exit(1);
	}
	p->info=x;
	p->next=NULL;
	return p;
}
void nhapds(list &l,int n)
{
	int x,i;
	node *moi;
	for(i=0;i<n;i++)
	{
		printf("Nhap phan tu thu %d: ",i);
		scanf("%d",&x);
		if(x==-1) break;
		moi=taophantu(x);
		themcuoi(l,moi);
	}
}
void xuatds(list l)
{
	node *p;
	printf("\n danh sanh la: ");
	for(p=l.head;p!=NULL;p=p->next)
		printf("   %d",p->info);
}
void themdau(list &l,node *moidau)
{
	if(l.head==NULL)
		l.head=l.tail=moidau;
	else
	{
		moidau->next=l.head;
		l.head=moidau;
	}
}
void themcuoi(list &l,node *moicuoi)
{
	if(l.head==NULL)
		l.head=l.tail=moicuoi;
	else
	{
		l.tail->next=moicuoi;
		l.tail=moicuoi;
	}
}
void themsauq(list &l,node *q,node *moisauq)
{
	if(q==NULL)
		themdau(l,moisauq);
	else
	{
		moisauq->next=q->next;
		q->next=moisauq;
		if(q==l.tail)
			themcuoi(l,moisauq);
	}
}
void xoadau(list &l)
{
	node *p;
	if(l.head==NULL)
	{
		printf("khong co phan tu de xoa");
		exit(1);
	}
	else
	{
		p=l.head;
		l.head=l.head->next;
		delete p;
	}
}
void xoasauq(list &l,node *q)
{
	node *p;
	if(q==NULL)
	{
		printf("khong co phan tu de xoa");
		exit(1);
	}
	else
	{
		p=q->next;
		q->next=q->next->next;
		delete p;
	}
}
void xoaphantucoinfox(list &l,int x)
{
	node *p,*q;
	p=l.head;
	q=NULL;
	while(p!=NULL&&p->info!=x)
	{
		q=p;
		p=p->next;
	}
	if(p==NULL)
	{
		printf("khong co phan tu nao co info bang x trong xau");
	}
	else
	{
		if(q==NULL)
			xoadau(l);
		else
		{
			xoasauq(l,q);
		}
	}
}
node *tim(list l,int x)
{
	node *p;
	for(p=l.head;p!=NULL;p=p->next)
	{
		if(p->info==x) break;
		printf("%d",*p);
	}
	return p;
}
void xoacuoi(list &l,int n)
{
	node *p,*q;
	p=l.head;
	q=NULL;
	for(int i=0;i<n;i++)
	{
		q=p;
		p=p->next;
	}
	if(p==NULL)
	{
		printf("khong the xoa vi xau don khong co phan tu");
		exit(1);
	}
	else
		xoasauq(l,q);
}