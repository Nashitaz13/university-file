// bai3_BinarySearchTree_songuyen.cpp : Defines the entry point for the console application.
//

#include "stdio.h"
#include "conio.h"
#include "stdlib.h"
#include "math.h"
typedef struct cautruccay
{
	int info;
	struct cautruccay *left,*right;
}TNODE;
typedef TNODE *TREE;

TNODE *taophantu(int x);
int them(TREE &T, int x);
void nhapcay(TREE &T);
void xuatNLR(TREE T);
void xuatNRL(TREE T);
void xuatLNR(TREE T);
void xuatRNL(TREE T);
void docao(TREE T, int &max, int i);
void InmucM(TREE T, int m, int i);
void DemNodeM(TREE T, int m, int &dem, int i);
void DemNode(TREE T, int &dem);
void timqthayp(TREE &p, TREE &q);
int DemnhanhTrai(TREE T, int x);
void DemNodebac0(TREE T, int &dem);
void DemNodebac1(TREE T, int &dem);
void DemNodebac2(TREE T, int &dem);
TNODE *timnode(TREE T, int x);
int xoanode(TREE &T, int x);
void xoaSoNgto(TREE &T);
void xoacay(TREE &T);

void menu()
{
	printf("\n0: Thoat");
	printf("\n1: Nhap cay");
	printf("\n2: Duyet cay tang dan");
	printf("\n3: Duyet cay giam dan");
	printf("\n4: Duyet Node - left - right");
	printf("\n5: Duyet Node - right - left");
	printf("\n6: Tinh do cao cay");
	printf("\n7: Duyet cay theo muc");
	printf("\n8: Dem node muc thu m");
	printf("\n9: Dem so node o cay con trai");
	printf("\n10: Dem node bac 0");
	printf("\n11: Dem node bac 1");
	printf("\n12: Dem node bac 2");
	printf("\n13: Tim node");
	printf("\n14: Xoa 1 node");
	printf("\n15: Xoa tat ca so nguyen to tren cay");
	printf("\n");
	printf("\nChon thao tac: ");
}
void main()
{
	char ch;
	int x,m,kq=0,h=0;
	TREE T;
	T=NULL;
	do
	{
		menu();
		scanf("%d",&ch);
		switch(ch)
		{
		case 0:
			return;
		case 1:
			T=NULL;
			nhapcay(T);
			break;
		case 2:
			xuatLNR(T);
			break;
		case 3:
			xuatRNL(T);
			break;
		case 4:
			xuatNLR(T);
			break;
		case 5:
			xuatNRL(T);
			break;
		case 6:
			h=0;
			docao(T,h,0);
			h=h+1;
			printf("\nChieu cao cay la: %d",h);
			break;
		case 7:
			printf("\nNhap muc: ");
			scanf("%d",&m);
			InmucM(T,m,0);
			break;
		case 8:
			kq=0;
			printf("\nNhap muc: ");
			scanf("%d",&m);
			DemNodeM(T,m,kq,0);
			printf("\nMuc %d co %d Node",m,kq);
			break;
		case 9:
			printf("\nNhap x:");
			scanf("%d",&x);
			if(timnode(T,x)==NULL)
				printf("\nKhong co Node %d",x);
			else
				printf("\nCay con trai co %d Node",DemnhanhTrai(T,x));
			break;
		case 10:
			kq=0;
			DemNodebac0(T,kq);
			printf("\nCo %d node bac 0",kq);
			break;
		case 11:
			kq=0;
			DemNodebac1(T,kq);
			printf("\nCo %d node bac 1",kq);
			break;
		case 12:
			kq=0;
			DemNodebac2(T,kq);
			printf("\nCo %d node bac 2",kq);
			break;
		case 13:
			printf("\nNhap phan tu x: ");
			scanf("%d",&x);
			if(timnode(T,x))
				printf("\nTim thay %d",x);
			else
				printf("\nKhong co phan tu %d",x);
			break;
		case 14:
			printf("\nNhap node can xoa: ");
			scanf("%d",&x);
			xoanode(T,x);
			break;
		case 15:
			xoaSoNgto(T);
			break;
		default:
			printf("\nSai chuc nang!");
			break;
		}
	}
	while(1);
}
TNODE *taophantu(int x)
{
	TNODE *p;
	p=new TNODE;
	if(p==NULL)
	{
		printf("\nKhong du bo nho!");
		exit(1);
	}
	p->info=x;
	p->left=p->right=NULL;
	return p;
}
int them(TREE &T, int x)
{
	if(T==NULL)
	{
		T=new TNODE;
		if(T==NULL)
			return -1;
		T->info=x;
		T->left=T->right=NULL;
		return 1;
	}
	if(T->info>x)
		return them(T->left,x);
	if(T->info<x)
		return them(T->right,x);
	return 0;
}
void nhapcay(TREE &T)
{
	int kq, x, i=0;
	T=NULL;
	printf("\nNhap cac phan tu khong am:");
	do
	{
		printf("\nNhap phan tu thu %d: ",i+1);
		scanf("%d",&x);
		if(x>=0)
		{
			kq=them(T,x);
			if(kq==0)
				printf("\nNhap gia tri khac!");
			if(kq==-1)
			{
				printf("\nKhong du bo nho!");
				exit(1);
			}
		}
		i++;
	}
	while(x>=0);
}
void xuatLNR(TREE T)
{
	if(T!=NULL)
	{
		xuatLNR(T->left);
		printf("%3d",T->info);
		xuatLNR(T->right);
	}
}
void xuatRNL(TREE T)
{
	if(T!=NULL)
	{
		xuatRNL(T->right);
		printf("%3d",T->info);
		xuatRNL(T->left);
	}
}
void xuatNLR(TREE T)
{
	if(T!=NULL)
	{
		printf("%3d",T->info);
		xuatNLR(T->left);
		xuatNLR(T->right);
	}
}
void xuatNRL(TREE T)
{
	if(T!=NULL)
	{
		printf("%3d",T->info);
		xuatNRL(T->right);
		xuatNRL(T->left);
	}
}
void docao(TREE T, int &max, int i)
{
	if(T)
	{
		if(i>max)
			max=i;
		docao(T->left,max, i+1);
		docao(T->right,max, i+1);
	}
}
void InmucM(TREE T, int m, int i)
{
	if(T)
	{
		if(i==m)
			printf("%3d",T->info);
		InmucM(T->left,m,i+1);
		InmucM(T->right,m,i+1);
	}
}
void DemNodeM(TREE T, int m, int &dem, int i)
{
	if(T)
	{
		if(i==m)
			dem++;
		DemNodeM(T->left,m,dem,i+1);
		DemNodeM(T->right,m,dem,i+1);
	}
}
TNODE *timnode(TREE T, int x)
{
	if(T)
	{
		TNODE *p;
		p=T;
		if(p->info==x)
			return p;
		else
		{
			if(p->info>x)
				return timnode(T->left,x);
			else
				return timnode(T->right,x);
		}
	}
	return NULL;
}
void DemNode(TREE T, int &dem)
{
	if(T)
	{
		dem++;
		DemNode(T->left,dem);
		DemNode(T->right,dem);
	}
}
int DemnhanhTrai(TREE T, int x)
{
	int dem=0;
	TNODE *p;
	if(T)
	{
		p=timnode(T,x);
		DemNode(p->left,dem);
	}
	return dem;
}
void DemNodebac0(TREE T, int &dem)
{
	if(T)
	{
		if(T->left==NULL && T->right==NULL)
			dem++;
		DemNodebac0(T->left,dem);
		DemNodebac0(T->right,dem);
	}
}
void DemNodebac1(TREE T, int &dem)
{
	if(T)
	{
		if(T->left)
			if(T->right==NULL)
				dem++;
		else
			if(T->right)
				dem++;
		DemNodebac1(T->left,dem);
		DemNodebac2(T->right,dem);
	}
}
void DemNodebac2(TREE T, int &dem)
{
	if(T)
	{
		if(T->left && T->right)
			dem++;
		DemNodebac2(T->left,dem);
		DemNodebac2(T->right,dem);
	}
}
void timqthayp(TREE &p, TREE &q)
{
	if(q->left)
		timqthayp(p,q->left);
	else
	{
		p->info=q->info;
		p=q;
		q=q->right;
	}
}
int xoanode(TREE &T, int x)
{
	TNODE *p;
	if(T==NULL)
		return 0;
	if(x<T->info)
		return xoanode(T->left,x);
	else
		if(x>T->info)
			return xoanode(T->right,x);
		else
		{
			p=T;
			if(T->left==NULL)
				T=T->right;
			else
				if(T->right==NULL)
					T=T->left;
				else
					timqthayp(p,T->right);
			delete p;
			return 1;
		}
}
int soNgto(int x)
{
	if(x<2)
		return 0;
	for(int i=2;i<=sqrt(x);i++)
		if(x%i==0)
			return 0;
	return 1;
}
void xoaSoNgto(TREE &T)
{
	int x;
	if(T!=NULL)
	{
		
		
		xoaSoNgto(T->left);
		xoaSoNgto(T->right);
		if(soNgto(T->info))
		{
			x=T->info;
			xoanode(T,x);
		}
	}
}
void xoacay(TREE &T)
{
	if(T)
	{
		xoacay(T->left);
		xoacay(T->right);
		delete T;
	}
}
