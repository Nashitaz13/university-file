//Sap xep Cay hay Heap Sort
#include "stdio.h"
#include "conio.h"
const MAX=20;

// ham doi cho
void doicho( int &x, int &y)
{
	int tam;
	tam=x;
	x=y;
	y=tam;
}
// nhap mang
void nhapmang( int a[], int n)
{
  int i;
  for (i=0; i<n;i++)
   {
     printf("\nNhap ptu thu %d:", i);
     scanf("%d",&a[i]);
   }
}
// xuat mang
void xuatmang( int a[], int n)
{
  int i;
  for (i=0; i<n;i++) printf("%3d", a[i]);
  printf("\n");
}

// Heap Sort

/*void hieuchinh( int a[], int L, int R)
{
	int i,j,x;
	i=L;
	j=2*i+1;
	x=a[i];//a[j],a[j+1] la lien doi cua a[i]
	while (j<=R)
	{
		if ((j<R)&&(a[j]<a[j+1])) j=j+1; 
		// a[j] lien doi lon nhat
		if (x>=a[j]) break; // thoa lien doi
		else
			{
				//hieu chinh lan truyen
				a[i]=a[j];
				a[j]=x;
				i=j;
				j=2*i+1;
			}

	}

}
//-----

void taoheap(int a[], int n)
{
	int L;
	L=n/2-1;
	while (L>=0)
		{
			hieuchinh(a,L,n-1);
			L--;
		}
}
//-----

void sapxepcay(int a[], int n)
{
	int R;
	taoheap(a,n);
	R=n-1;
	while (R>0)
	{
		doicho(a[0],a[R]);
		R--;
		hieuchinh(a,0,R);
	}

}
//======
*/
void quicksort(int a[],int l,int r)
{
	int i,j,x;
	x=a[(l+r)/2];
	i=l;j=r;
	do
	{
		while(a[i]<x)i++;
		while(a[j]>x)j--;
		if(i<=j)
		{
			doicho(a[i],a[j]);
			i++;
			j--;
		}
	}
	while(i<=j);
	if(l<j)
		quicksort(a,l,j);
	if(r>i)
		quicksort(a,i,r);
}
void main()
{
  int a[MAX];
  int n=10;
  nhapmang(a,n);
  xuatmang(a,n);
  //sapxepcay(a,n);
  //printf("\nDa sap xong:");
  //xuatmang(a,n);
  quicksort(a,0,n-1);
  xuatmang(a,n);
}
