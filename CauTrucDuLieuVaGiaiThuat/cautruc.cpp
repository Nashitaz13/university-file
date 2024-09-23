#include "conio.h"
#include "stdio.h"
#include "string.h"
#include "stdlib.h"

#define ESC 27  //phim ESC co ma la 27
#define N0 50   // So sinh vien tu toi da

typedef struct sinhvien
{
	int maso;
	float diem;
	char hodem[12];
	char ten[8];

} KSV;


void nhap1sv_hoten( KSV & x);
void nhapds_hoten( KSV s[], int &n);
void xuatds( KSV s[], int n);
void saptheoten(KSV s[], int n);
void doicho( KSV &a, KSV &b);
void ganmaso(KSV s[], int n);
void nhapdiemds(KSV s[], int n, int vitri);
void chenk(KSV s[], int &n, KSV Z, int vitri);
void xoak(KSV s[], int &n, int vitri);
int timnhiphan(KSV s[], int n, int maso);
void themsvmoi(KSV s[], int &n);
void xoasv(KSV s[], int &n);


void main()
{
	KSV s[N0];
	int n;

	nhapds_hoten(s,n);
	printf("\nDANH SACH VUA NHAP LA:");
	xuatds(s,n);
	ganmaso(s,n);
	printf("\nDANH SACH DA GAN MA SO:");
	xuatds( s,n);
	nhapdiemds(s,n,0);
	printf("\nDANH SACH DA NHAP DIEM:");
	xuatds(s,n);
	printf("\nBO SUNG SV:");
	themsvmoi(s,n);
	printf("\nDANH SACH DA THEM SV:");
	xuatds(s,n);
	printf("\nXOA SV:");
	xoasv(s,n);
	printf("\nDANH SACH DA XOA:");
	xuatds(s,n);
}

void nhap1sv_hoten( KSV & x)
{
	// ham nay chi nhap ho, ten 1 sv
	printf("\nNhap ho va dem:");
	flushall();
	gets(x.hodem);
	printf("\nNhap ten:");
	flushall();
	gets(x.ten);
}

void nhapds_hoten( KSV s[], int &n)
{
	//nhap dsach sv cho den khi ten rong thi dung
	int i;
	printf("\nNHAP HO TEN CAC SV(DUNG KHI TEN LA RONG):");
	for ( i=0;i<N0; i++)
	{
		printf("\nNhap SV thu %d:", i+1);
		nhap1sv_hoten(s[i]);
		s[i].maso=-1; //chua co ma so thi gan maso=-1 
		s[i].diem=-1; //chua co diem thi gan diem=-1 
		if (strcmp(s[i].ten,"")==0) break; //ten rong thi ket thuc
	}
	n=i;
}

void xuatds( KSV s[], int n)
{
	int i;
	char temp_hoten[20];
	printf("\n STT MA SO     HO VA TEN        DIEM"); 
	for ( i=0;i<n; i++)
	{
		strcpy(temp_hoten,s[i].hodem); // chep hodem vao temp_hoten
		strcat(temp_hoten," ");        // Noi khoang trang
		strcat(temp_hoten,s[i].ten);   // Noi ten vao cuoi temp_hoten
		printf("\n%3d %5d %-20s %5.1f",i+1,s[i].maso, temp_hoten, s[i].diem);
	}
	printf("\n");
	
}

void doicho( KSV &x, KSV &y)
{
	KSV temp=x;
	x=y;
	y=temp;
}

void saptheoten(KSV s[], int n)
{
	//Sap tang theo ten
	int i, j;
	for (i=0; i<n-1; i++)
	for (j=i+1;j<n; j++)
		if( strcmp(s[i].ten,s[j].ten)>0) doicho(s[i],s[j]);
}

void ganmaso(KSV s[], int n)
{
	//Gan tu dong maso cho cac SV
	int i;
	saptheoten(s,n);
	for (i=0;i<n; i++) s[i].maso=i+1;
}
 
void nhapdiemds(KSV s[], int n, int vitri)
{
	
	int i;
	char temp_hoten[20];
	printf("\nHAY NHAP DIEM CHO SV:");
	i=vitri; // i la vitri bat dau nhap diem
	do
	{
		strcpy(temp_hoten,s[i].hodem);
		strcat(temp_hoten," ");
		strcat(temp_hoten,s[i].ten);
		printf("\nMa so  : %3d",s[i].maso);
		printf("\nHo ten : %-s", temp_hoten);
		do
		{
			printf("\nDiem  ?:");
			scanf("%f", &s[i].diem);
		}
		while ( s[i].diem<0 || s[i].diem>10);
		i++;
		printf("\nNhan phim ESC de ket thuc !");
	}
	while ( i<n && getch()!=ESC);
}

void chenk(KSV s[], int &n, KSV x, int vitri)
{
	//Chen sinh vien x vao vitri
	int i;
	if ( vitri<0 || vitri>n ) return ;// ket thuc
	for (i=n;i>vitri;i--) s[i]=s[i-1];
	s[vitri]=x;
	n++;
}

void xoak(KSV s[], int &n, int vitri)
{
	//Xoa sinh vien tai vitri
	int i;
	if ( vitri<0 || vitri>n-1 ) return ;// ket thuc
	for (i=vitri;i<n-1;i++) s[i]=s[i+1];
	n--;
}

int timnhiphan(KSV s[], int n, int k)
{
	//tim SV co maso==k
	int L=0, R=n-1, Mid ;
	do
	{
		Mid=(L+R)/2;
		if (k==s[Mid].maso) return Mid;
		else
			if (k<s[Mid].maso) R=Mid-1;
			else
				L=Mid+1;
	}
	while (L<=R); 
	return -1;
}

void themsvmoi(KSV s[], int &n)
{
	//Bo sung SV moi vao dsach
	KSV  x;
	int k, vitri;
	do
	{
		printf("\nNhap ma so SV de bo sung :");
		scanf("%d", &k);
		vitri=timnhiphan(s,n,k);
		if (vitri>-1) printf("\nMa so nay da co roi! Khong bo sung!");
		else
		{
		  x.maso=k;
		  nhap1sv_hoten(x);
		  printf("\nNhap diem :");
		  scanf("%f", &x.diem);
		  //chen vao cuoi mang
		  chenk(s,n,x,n);
		}
		printf("\nNhan phim ESC de thoi chen!");

	}
	while (getch()!=ESC);
}

void xoasv(KSV s[], int &n)
{
	//Xoa mot so SV
	int k, vitri;
	do
	{
		printf("\nNhap ma so SV de xoa :");
		scanf("%d", &k);
		vitri=timnhiphan(s,n,k);
		if (vitri==-1) printf("\nMa so nay khong co ! ");
		else
		{
		  printf("\nMuon xoa SV nay (Y/N)?");
          	  char traloi=getch();
		  if (traloi=='Y'||traloi=='y') 
		  {
			  xoak(s,n,vitri);
			  printf("\nDa xoa xong!");
		  }
		  else
			  printf("\nKhong xoa !");
		}
		printf("\nNhan phim ESC de thoi xoa tiep!");

	}
	while (getch()!=ESC);
}
