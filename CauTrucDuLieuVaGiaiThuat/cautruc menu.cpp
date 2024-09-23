
// VI DU MAU VE MENU voi CAU TRUC ( struct ):


#include "conio.h"
#include "stdio.h"
#include "string.h"
#include "stdlib.h"

#define ESC 27  //phim ESC co ma la 27

#define N  50   // So sinh vien tu toi da

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
void nhapdiemds(KSV s[], int n);
void chenk(KSV s[], int &n, KSV Z, int vitri);
void xoak(KSV s[], int &n, int vitri);
int  timnhiphan(KSV s[], int n, int maso);//Chi dung trong ham timkiem
void themsvmoi(KSV s[], int &n);
void xoasv(KSV s[], int &n);

void saptheomaso(KSV s[], int n);
void inthucdon(void);
void xuat1sv(KSV s[],int vitri);
int timkiem(KSV s[], int n);
void chu_dautu_lahoa(char *st);
void suadulieu( KSV s[], int n);
int timtuyentinh(KSV s[],int n,int k);

void main()
{
	KSV s[N];
	int n=0;
	char ch ;
	// xay dung thuc don ( menu)
	do
	{
	 inthucdon();
     ch=getch();
     switch (ch)
      {
		case '1':
				nhapds_hoten(s,n);
				printf("\n\n Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '2':
				xuatds( s,n);
				printf("\n\n In xong. Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '3':
				saptheoten(s,n);
				ganmaso(s,n);
				printf("\n\n Gan ma so xong. Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '4':
				saptheomaso(s,n);
				printf("\n\n Sap xep xong. Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '5':
				nhapdiemds(s,n);
				printf("\n\n Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '6':
				timkiem(s,n);
				printf("\n\n Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '7':
				themsvmoi(s,n);
				printf("\n\n Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '8':
				xoasv(s,n);
				printf("\n\n Enter de tro lai thuc don chinh.");
				getch();
				break;;
		case '9':
				suadulieu( s,n);
				printf("\n\n Enter de tro lai thuc don chinh.");
				getch();
				break;
		case '0':
				ch=ESC;
	 } // het case
	}
	while (ch !=ESC);
}//Het main()

//-----------------

void inthucdon()
{
	 printf("\n  CHUONG TRINH QUAN LY SINH VIEN\n");
	 printf("\n 1.Nhap them ho ten thi sinh\n");
	 printf("\n 2.In danh sach thi sinh\n");
	 printf("\n 3.Gan ma so theo thu tu tang cua ten\n");
	 printf("\n 4.Sap tang theo ma so\n");
	 printf("\n 5.Nhap diem cac thi sinh\n");
	 printf("\n 6.Tim thi sinh\n");
	 printf("\n 7.Them thi sinh moi\n");
	 printf("\n 8.Xoa thi sinh\n");
	 printf("\n 9.Sua du lieu thi sinh\n");
	 printf("\n 0.Ket thuc ( go ESC )\n");
}
//------------------

void nhap1sv_hoten( KSV & x)
{
	// ham nay chi nhap ho, ten 1 sv
	printf("\nNhap ho va dem:");
	flushall();
	gets(x.hodem);
	printf("\nNhap ten:");
	flushall();
	gets(x.ten);
	//Doi chu cai dau tu cua ho dem ra chu hoa
	chu_dautu_lahoa(x.hodem);
	//Doi chu cai dau tien cua ten ra chu hoa
	if (x.ten[0]>='a' && x.ten[0]<='z') 
					x.ten[0] = x.ten[0]-32; 
}
//------------------

void nhapds_hoten( KSV s[], int &n)
{
	//nhap bo sung vao dsach sv cho den khi ten rong thi dung
	int i;
	printf("\nNHAP HO TEN CAC SV ( Nhap ten rong de thoi nhap ):");
	for ( i=n;i<N; i++)
	{
		printf("\nNhap SV thu %d:", i+1);
		nhap1sv_hoten(s[i]);
		s[i].maso=-1; //chua co ma so thi gan maso=-1 
		s[i].diem=-1; //chua co diem thi gan   diem=-1 
		if (s[i].ten[0]==0) //ten rong thi ket thuc 
		{
			printf("\n Thoi nhap.");
			break;
		}
		
	}
	if (i==N) printf("\n Mang day (full) roi !");
	n=i; //n la tong so thi sinh
}
//------------------

void xuat1sv( KSV s[],int vitri)
{
	//in 1 sinh vien tai vitri
	char temp_hoten[20];
	strcpy(temp_hoten,s[vitri].hodem); // chep hodem vao temp_hoten
	strcat(temp_hoten," ");        // Noi khoang trang
	strcat(temp_hoten,s[vitri].ten);   // Noi ten vao cuoi temp_hoten
	printf("\n%3d %5d %-20s %5.1f",vitri+1,s[vitri].maso, temp_hoten, s[vitri].diem);
}
//------------------

void xuatds( KSV s[], int n)
{
	// in tat ca sinh vien
	int i;
	printf("\n STT MA SO     HO VA TEN        DIEM"); 
	for ( i=0;i<n; i++) xuat1sv(s, i);
	printf("\n");
}

//----------------
void doicho( KSV &x, KSV &y)
{
 	KSV temp=x;
	x=y;
	y=temp;
}
//-----------------

void saptheoten(KSV s[], int n)
{
	//Sap tang theo ten
	int i, j;
	for (i=0; i<n-1; i++)
	for (j=i+1;j<n; j++)
		if( strcmp(s[i].ten,s[j].ten)>0) doicho(s[i],s[j]);
}
//----------------

void ganmaso(KSV s[], int n)
{
	//Gan tu dong maso cho cac SV
	int i;
	for (i=0;i<n; i++) s[i].maso=i+1;
}
//----------------
 
void nhapdiemds(KSV s[], int n)
{
	//Nhap diem cho thi sinh
	int i;
	char temp_hoten[20];
	//Tim vi tri phan tu co diem=-1 dau tien
	i=0;
	while (i<n && s[i].diem!= -1) i++; 
	if (i==n) 
	{
		printf("\n Tat ca thi sinh da co diem. Khong phai nhap !");  
		return ;
	}
	// neu i< n thi lam viec duoi day
	printf("\nHAY NHAP DIEM CHO SV:");
	do
	{
		strcpy(temp_hoten,s[i].hodem);
		strcat(temp_hoten," ");
		strcat(temp_hoten,s[i].ten);
		printf("\n Ma so  : %3d",s[i].maso);
		printf("\n Ho ten : %-s", temp_hoten);
		do
		{
			printf("\n Nhap diem :");
			scanf("%f", &s[i].diem);
		}
		while ( s[i].diem<0 || s[i].diem>10);
		i++;
		if (i<n) printf("\n ESC de dung nhap diem. Enter de nhap diem tiep");
	}
	while ( i<n && getch()!=ESC);
	if (i<n) printf("\n Dung nhap diem.");
	else
		printf("\n Da nhap diem xong cho tat ca thi sinh");

}
//---------------- 

void chenk(KSV s[], int &n, KSV x, int vitri)
{
	//Chen sinh vien x vao vitri
	int i;
	vitri--; // vi tri tinh tu 0
	if ( vitri<0 || vitri>n ) return ;// ket thuc
	for (i=n;i>vitri;i--) s[i]=s[i-1];
	s[vitri]=x;
	n++;
}
//----------------

void xoak(KSV s[], int &n, int vitri)
{
	//Xoa sinh vien tai vitri
	int i;
	if ( vitri<0 || vitri>n-1 ) return ;// ket thuc
	for (i=vitri;i<n-1;i++) s[i]=s[i+1];
	n--;
}
//----------------

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
//----------------
int timtuyentinh(KSV s[],int n,int k)
{
	//tim SV co maso==k
	int i;
	for (i=0;i<n; i++)
		if (s[i].maso==k) break;
	if (i<n) return i;
	else
		return -1; //Khong tim thay
}
//------------------
int timkiem(KSV s[], int n)
{	int k, vitri;
	printf("\n Chu y: Tim ma so co the SAI neu chua sap tang theo MA SO!");
	getch();
	printf("\nNhap ma so thi sinh can tim:");
	scanf("%d",&k);
	vitri=timnhiphan(s,n,k);
	if(vitri==-1) printf("\n Khong tim thay");
	else
	{
		printf("\n Da tim thay :");
		printf("\n STT MA SO     HO VA TEN        DIEM"); 
		xuat1sv(s, vitri);
	} 
	return vitri;
}

//---------------------
void themsvmoi(KSV s[], int &n)
{
	//Bo sung SV moi vao dsach
	KSV  x;
	int k, vitri, j;
	do
	{
		printf("\nNhap ma so SV de bo sung :");
		scanf("%d", &k);
		vitri=timtuyentinh(s,n,k);
		if (vitri>-1) printf("\nMa so nay da co roi! Khong bo sung!");
		else
		{
		  x.maso=k;
		  nhap1sv_hoten(x);
		  printf("\nNhap diem :");
		  scanf("%f", &x.diem);
		  printf("\nNhap vi tri chen >0:");
		  scanf("%d", &j); // j tinh tu 1,..., n
		  chenk(s,n,x,j);//chen vao vi tri j 
		}
		printf("\n Chen xong.Nhan ESC:thoi chen, Enter:chen tiep!");

	}
	while (getch()!=ESC);
}
//----------------

void xoasv(KSV s[], int &n)
{
	//Xoa mot so SV
	int k, vitri;
	do
	{
		printf("\nNhap ma so SV de xoa :");
		scanf("%d", &k);
		vitri=timtuyentinh(s,n,k);
		if (vitri==-1) printf("\nMa so nay khong co ! ");
		else
		{
		  printf("\nMuon xoa SV nay (Y/N)?");
		  if (getch()=='y') 
		  {
			  xoak(s,n,vitri);
			  printf("\nDa xoa xong!");
		  }
		  else
			  printf("\nKhong xoa !");
		}
		printf(" Nhan ESC de thoi xoa tiep!");

	}
	while (getch()!=ESC);
}
//-----------------

void chu_dautu_lahoa( char *st)
{
	//Doi chu cai dau 1 tu cua chuoi st ra chu hoa
	int i, n=strlen(st);
	if(st[0]>='a' && st[0]<='z') st[0]=st[0]-32;       //toupper(st[0]);
	for (i=1; i<n;i++) 
		 if (st[i-1]==' ' && st[i]>='a' && st[i]<='z') st[i]=st[i]-32; //toupper(st[i]);

}
 
//-----------------

void suadulieu( KSV s[], int n)
{
	int vitri;
	char ch;
	vitri=timkiem(s,n);
	if (vitri==-1) return ;
	do
	{
	 printf("\n\n Sua du lieu nao ?");
     printf("\n 1.Ma so");
	 printf("\n 2.Hodem");
	 printf("\n 3.Ten");
	 printf("\n 4.Diem");
	 printf("\n 5.Thoat (ESC)\n");
	 ch=getch();
	 switch (ch)
	 {
		case '1':
				int k, daco;
				do
				{
					printf("\n Nhap ma so moi:");
					scanf("%d", &k);
					daco=timnhiphan(s,n,k);
					if (daco>-1) printf("\nMa so nay da co roi. Nhap ma so khac");
				}
				while (daco >-1);
				s[vitri].maso=k;
				printf("\n Da sua ma so xong.");
				break;
		case '2':
				printf("\n Nhap ho va dem moi:");
				flushall();
				gets(s[vitri].hodem);
				printf("\n Da sua ho dem xong.");
				break;
		case '3':
				printf("\n Nhap ten moi:");
				flushall();
				gets(s[vitri].ten);
				printf("\n Da sua ten xong.");
				break;
		case '4':
				printf("\n Nhap diem moi:");
				scanf("%f",&s[vitri].diem);
				printf("\n Da sua diem xong.");
				break;
		case '5': 
				ch=ESC;
	 }
	
	}
	while (ch!=ESC);
}
//----------------

void saptheomaso(KSV s[], int n)
{
//Sap tang theo maso
	int i, j;
	for (i=0; i<n-1; i++)
	for (j=i+1;j<n; j++)
		if( s[i].maso> s[j].maso) doicho(s[i],s[j]);	
}

