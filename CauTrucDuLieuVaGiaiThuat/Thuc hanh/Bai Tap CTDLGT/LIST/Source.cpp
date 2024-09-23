#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>

typedef struct ngaysinh
{
	int ng,th,nam;

}ngaysinh;

typedef struct sinhvien
{
	char hoten[50],MSSV[20],gioitinh[4];
	ngaysinh ngs;
	float DTB;
} data;

typedef struct node
{
	data info;
	node *next;
}node;

typedef struct list
{
	node *head,*tail;
}list;

void creatds(list &l)
{
	l.head=l.tail=NULL;
}

node *getnode(data x)
{
	node *p=new node;
	if(p)
	{
			p->info=x;
			p->next=NULL;
	}
	return p;
}

void addfirst(list &l,node *p)
{
	if(p!=NULL)
	{
		if(l.head==NULL)
			l.head=l.tail=p;
		else
		{
			p->next=l.head;
			l.head=p;
			
		}
	}
}

node *addlast(list &l,data x)
{
	node *p=getnode(x);
	if(p!=NULL)
	{
		if(p==NULL)
			l.head=l.tail=NULL;
		else
		{
			l.tail->next=p;
			l.tail=p;
		}
	}
	return p;
}

node *addtail(list &l,node *p)
{
	if(p)
	{
		if(p==NULL)
			l.head=l.tail=p;
		else
		{
			l.tail=p->next;
			l.tail=p;
		}
	}
	return p;
}

void addafter(list &l,node *q,data x)
{
	node *p=getnode(x);
	if(p==NULL) return;
	if(q!=NULL)
	{
		p->next=q->next;
		q->next=p;
		if(q!=l.tail) l.tail=p;
	}
	else addfirst(l,p);
}

void addbefore(list &l,node *q,data x)
{
	node *p=getnode(x),*t=l.head,*k;
	if(p==NULL) return;
	if(q=l.head)
	{
		addfirst(l,p);
		return;
	}
	if(q!=NULL)
	{
		while(t!=q)
		{
			k=t;
			t=t->next;
		}
			p->next=k->next;
			k->next=p;
	}
	else addfirst(l,p);
}

node *timms(list l,char *x)
{
	node *p=l.head;
	while(p!=NULL && strcmp(p->info.MSSV,x)!=0)
	{
		p=p->next;
	}
	return p;
}

node *timhoten(list l,char *x)
{
	node *p=l.head;
	while(p!=NULL && strcmp(p->info.hoten,x)!=0)
	{
		p=p->next;
	}
	return p;
}

data nhap1sv(data x)
{
	printf("MSSV: ");
	fflush(stdin);
	gets_s(x.MSSV);
	printf("Ho ten: ");
	fflush(stdin);
	gets_s(x.hoten);
	printf("Gioi tinh: ");
	fflush(stdin);
	gets_s(x.gioitinh);
	printf("Ngay sinh: ");
	scanf_s("%d %d %d",x.ngs.ng,x.ngs.th,x.ngs.nam);
	printf("Diem trung binh: ");
	float temp;
	scanf_s("%f",&temp);
	x.DTB=temp;
	return x;
}

void nhapds(list &l)
{
	data x;
	while(1)
	{
		printf("MSSV: ");
		fflush(stdin);
		gets_s(x.MSSV);
		printf("Ho ten: ");
		fflush(stdin);
		gets_s(x.hoten);
		printf("Gioi tinh: ");
		fflush(stdin);
		gets_s(x.gioitinh);
		printf("Ngay sinh: ");
		scanf_s("%d %d %d",x.ngs.ng,x.ngs.th,x.ngs.nam);
		printf("Diem trung binh: ");
		float temp;
		scanf_s("%f",&temp);
		x.DTB=temp;
		if(addlast(l,x)==NULL) break;
	}
}

void xuatsv(data x)
{
	printf("MSSV: %8s",x.MSSV);
	printf("Ho ten: %10s",x.hoten);
	printf("Gioi tinh: %4s",x.gioitinh);
	printf("Ngay sinh: %d/%d/%d ",x.ngs.ng,x.ngs.th,x.ngs.nam);
}

void inds(list l)
{
	if(l.head==NULL)
	{
		printf("Danh sach rong");
		return;
	}
	node *p=l.head;
	while(p)
	{
		xuatsv(p->info);
		p=p->next;
	}
}

int removehead(list &l)
{
	node *p=l.head;
	if(p!=NULL)
	{
		l.head=l.head->next;
		delete p;
		return 1;
	}
	return 0;
}

int removetail(list &l)
{
	node *p=l.head,*q;
	if(l.head==NULL)
		return 0;
	if(l.head==l.tail) 
		return removehead(l);
	else
	{
		while(p!=l.tail)
		{
			q=p;
			p=q->next;
		}
		l.tail=q;
		q->next=NULL;
		delete p;
		return 1;
	}
}

int removeafter(list &l,node *q)
{
	node *p;
	if(q!=NULL)
	{
		if(q=l.tail)
			return 0;
		p=q->next;
		q->next=p->next;
		if(p=l.tail)
			l.tail=q;
		delete p;
		return 1;
	}
	else 
		return 0;
}

int removebefore(list &l,node *q)
{
	if(q!=NULL)
	{
		node *t=l.head,*p=t->next,*w;
		if(l.head==NULL || q==l.head) return 0;
		if(p==q) return removehead(l);
		while(p!=q)
		{
			w=t;
			t=p;
			p=p->next;
		}
		w->next=t->next;
		delete t;
		return 1;
	}
	else return 0;
}

void menu()
{
	printf("Chuong trinh quan ly sinh vien");
	printf("1. Input ");
	printf("2. Output ");
	printf("3. Add after ");
	printf("4. Add before ");
	printf("5. Search student ID ");
	printf("6. Search student name ");
	printf("7. Remove head ");
	printf("8. Remove tail ");
	printf("9. Remove node ");
	printf("10. Remove after ");
	printf("11. Remove before ");
	printf("0. Exit ");
}

void main()
{
	list l;
	int chon;
	creatds(l);
	char a[50];
	node *p;
	data x;
		do
		{
			menu();
				printf("Chon chuc nang : ");
				scanf_s("%d",&chon);
				switch(chon)
				{
				case 1:nhapds(l); break;
				case 2:inds(l); break;
				case 3:
					{
						fflush(stdin);
						printf("Them mot sinh vien vao dau DS ");
						gets_s(a);
						p=timms(l,a);
						x=nhap1sv(x);
						if(p!=NULL) addafter(l,p,x);
						else addlast(l,x);
						break;
					}
				case 4: 
					{
						fflush(stdin);
						printf("Them mot sinh vien vao cuoi DS ");
						gets_s(a);
						p=timms(l,a);
						x=nhap1sv(x);
						if(p!=NULL) addbefore(l,p,x);
						else addlast(l,x);
						break;
					}
				case 5:
					{
						fflush(stdin);
						printf("Nhap MSSV can tim ");
						gets_s(a);
						p=timms(l,a);
						if(p==NULL) printf(" Khong tim thay ");
						else xuatsv(p->info);
						break;
					}
				case 6:
					{
						fflush(stdin);
						printf("Nhap ten sinh vien can tim: ");
						gets_s(a);
						p=timhoten(l,a);
						if(p==NULL) printf(" Khong tim thay ");
						else xuatsv(p->info);
						break;
					}
				case 7: 
					{
						if(removehead(l)==1) printf("Da xoa xong");
						else printf("Khong xoa duoc ");
						break;
					}
				case 8:
					{
						if(removetail(l)==1) printf("Da xoa xong");
						else printf("Khong xoa duoc");
						break;
					}
				case 9:
					{
						fflush(stdin);
						printf("Nhap MSSV: ");
						gets_s(a);
						p=timms(l,a);
						if(p==NULL)
						{
							printf("Khong xoa duoc");
							break;
						}
						p=p->next;
						if(p!=NULL) removebefore(l,p);
						else removetail(l);
						break;
					}
				case 10:
					{
						fflush(stdin);
						printf("Nhap MSSV can xoa : ");
						gets_s(a);
						p=timms(l,a);
						if(removeafter(l,p)==1) printf("Da xoa xong");
						else printf("Khong xoa duoc");
						break;
					}
				case 11:
					{
						fflush(stdin);
						printf("Nhap MSSV can xoa : ");
						gets_s(a);
						p=timms(l,a);
						if(removebefore(l,p)==1) printf("Da xoa xong");
						else printf("Khong xoa duoc");
						break;
					}
				case 12:
					{
						return;
					}
				}
		
		}while(1);
		_getch();
}