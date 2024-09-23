//Sap xep Tron hay Merge sort
#include "stdio.h"
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

// Mergce Sort

void tronkphantu( int k, int B[], int Nb, int C[], int Nc, int A[])
{
	int i=0, vtb=0, vtc=0; // Vi tri cua A,B,C khi bat dau xet k fan tu tiep theo
	int jb=0, jc=0; // dem so fan tu cua B, C da dua vao A
	int kb, kc; // spt toi da cua B, C se dua vao A

	while ((Nb>0) &&(Nc>0))
	{
		if (k<Nb) kb=k; else kb=Nb;
		if (k<Nc) kc=k; else kc=Nc;
		if (B[vtb+jb]<= C[vtc+jc])
		{
			A[i++]=B[vtb+jb];// dua B vao
			jb++;
			if (jb==kb) // dua het kb fan tu cua B vao A
			{
				//dua luon so con lai cua C vao A
				for (;jc<kc; jc++) A[i++]=C[vtc+jc];
				//Chuan bi dua k fan tu tiep theo vao A
				vtb=vtb+kb;
				vtc=vtc+kc;
				Nb=Nb-kb;
				Nc=Nc-kc;
				jb=0;
				jc=0;
			}

		}
		else
		{
			A[i++]=C[vtc+jc];// dua C vao
			jc++;
			if (jc==kc) // dua het kc fan tu cua C vao A
			{
				//dua luon so con lai cua B vao A
				for (;jb<kb; jb++) A[i++]=B[vtb+jb];
				//Chuan bi dua k fan tu tiep theo vao A
				vtb=vtb+kb;
				vtc=vtc+kc;
				Nb=Nb-kb;
				Nc=Nc-kc;
				jb=0;
				jc=0;
			}
		}
	}

	while (Nb>0) // dua het so con lai cua B vao A
		{
			A[i++]=B[vtb+jb];
			jb++;
			Nb--;
		}
	while (Nc>0) // dua het so con lai cua C vao A
		{
			A[i++]=C[vtc+jc];
			jc++;
			Nc--;
		}
}


void sapxeptron(int A[], int N)
{

	int B[MAX], C[MAX];
	int j, Nb, Nc;
	int i, k=1; // k la do dai day con B, C
	do
	{
		// tach A ra B, C
		j=Nb=Nc=0;
		while (j<N)
		{
			for(i=0;(j<N)&&(i<k); i++) B[Nb++]=A[j++];
			for(i=0;(j<N)&&(i<k); i++) C[Nc++]=A[j++];
		}
		tronkphantu(k,B,Nb,C,Nc, A);//tron B, C vao A
		k=k*2;
	}
	while (k<N);
}
//========
void main()
{
  int a[MAX];
  int n=10;
  nhapmang(a,n);
  xuatmang(a,n);
  sapxeptron(a,n);
  printf("\nDa sap xong:");
  xuatmang(a,n);
}


