#include <stdio.h>
#include <stdlib.h>

typedef struct xaukep
{
	int info;
	struct xaukep *prev,*next;
} dnode;
typedef struct danhsachkep
{
	dnode *head,*tail;
} dlist;

void khoitaoxau(dlist &l);
dnode *taophantu(int x);
void nhapdanhsach(dlist &l);
void xuatdanhsach(dlist l);
void themdau(dlist &l,dnode *moidau);
void themcuoi(dlist &l,dnode *moicuoi);
void themsauq(dlist &l,dnode *q,dnode *moisauq);
void xoadau(dlist &l);
void xoacuoi(dlist &l);
void xoasauq(dlist &l,dnode *q);
dnode *tim(dlist l,int x);
void xoaphantucoinfox(dlist &l,int x);
void copyxau(dlist &l1,dlist &l2);

int main()
{
	dlist l;
	dnode *moidau,*moicuoi,*q,*moisauq;
	int x,y,z,p,a;
	khoitaoxau(l);
	nhapdanhsach(l);
	xuatdanhsach(l);
	printf("\nNhap phan tu muon them vao dau danh sach: ");
	scanf("%d",&x);
	moidau=taophantu(x);
	themdau(l,moidau);
	xuatdanhsach(l);
	xoadau(l);
	xuatdanhsach(l);
	printf("\nNhap phan tu muon them vao cuoi danh sach: ");
	scanf("%d",&y);
	moicuoi=taophantu(y);
	themcuoi(l,moicuoi);
	xuatdanhsach(l);
	xoacuoi(l);
	xuatdanhsach(l);
	printf("\nNhap phan tu muon tim trong danh sach: ");
	scanf("%d",&z);
	q=tim(l,z);
	printf("\nNhap phan tu muon them vao sau gia tri da tim: ");
	scanf("%d",&p);
	moisauq=taophantu(p);
	themsauq(l,q,moisauq);
	xuatdanhsach(l);
	xoasauq(l,q);
	xuatdanhsach(l);
	printf("\nNhap phan tu muon xoa ");
	scanf("%d",&a);
	xoaphantucoinfox(l,a);
	xuatdanhsach(l);
}

void khoitaoxau(dlist &l)
{
	l.head=l.tail=NULL;
}
dnode *taophantu(int x)
{
	dnode *p;
	p=new dnode;
	if(p==NULL)
	{
		printf("Khong du bo nho");
		exit(1);
	}
	p->info=x;
	p->next=p->prev=NULL;
	return p;
}
void nhapdanhsach(dlist &l)
{
	int x,i=0;
	dnode *p;
	while(true)
	{
		printf("Nhap phan tu thu %d :",i);
		scanf("%d",&x);
		if(x==-1) break;
		p=taophantu(x);
		themcuoi(l,p);
		i=i++;
	}
}
void xuatdanhsach(dlist l)
{
	dnode *p;
	printf("\nDanh sach la: ");
	for(p=l.head;p!=NULL;p=p->next)
	{
		printf("   %d",p->info);
	}
}
void themdau(dlist &l, dnode *moidau)
{
	if(l.head==NULL)
	{
		l.head=l.tail=moidau;
	}
	else 
	{
		moidau->next=l.head;
		l.head->prev=moidau;
		l.head=moidau;
	}
}
void themcuoi(dlist &l,dnode *moicuoi)
{
	if(l.head==NULL)
		l.head=l.tail=moicuoi;
	else 
	{
		l.tail->next=moicuoi;
		moicuoi->prev=l.tail;
		l.tail=moicuoi;
	}
}
void themsauq(dlist &l,dnode *q,dnode *moisauq)
{
	if(q==NULL)
		printf("\nKhong them vao duoc vi khong co q!!");
	else
	{
		moisauq->next=q->next;
		q->next->prev=moisauq;
		q->next=moisauq;
		moisauq->prev=q;
	}
}
void xoadau(dlist &l)
{
	dnode *p;
	if(l.head==NULL)
		printf("\nDanh sach rong");
	else 
	{
		p=l.head;
		l.head->next->prev=NULL;
		l.head=l.head->next;
		delete p;
	}
}
void xoacuoi(dlist &l)
{
	dnode *p;
	if(l.head==NULL)
		printf("\nDanh sach rong!!");
	else 
	{
		p=l.tail;
		l.tail=l.tail->prev;
		delete p;
		if(l.tail!=NULL)
			l.tail->next=NULL;
		else
			l.tail=NULL;
	}
}
void xoasauq(dlist &l,dnode *q)
{
	dnode *p;
	if(q==NULL)
		printf("\nKhong co q trong danh sach!!");
	else
	{
		p=q->next;
		q->next=p->next;
		p->next->prev=q;
		delete p;
	}
}

dnode *tim(dlist l,int x)
{
	dnode *p;
	int dem=0;
	p=l.head;
	while(p!=NULL)
	{
		if(p->info==x) break;
		p=p->next;
		dem++;	
	}
	if(p==NULL)
		printf("\nKhong tim thay");
	else
	{ 
		printf("\nPhan tu can tim nam o vi tri: %d.",dem);
	}
	return p;
}
void xoaphantucoinfox(dlist &l,int x)
{
	dnode *p,*q;
	q=NULL;
	p=l.head;
	while(p!=NULL&&p->info!=x)
	{
		q=p;
		p=p->next;
	}
	if(p==NULL)
		printf("\nKhong co phan tu %d trong danh sach",x);
	else
	{
		if(q!=NULL)
			xoasauq(l,q);
	}
}