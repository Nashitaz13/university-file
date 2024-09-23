// VI DU MAU VE MENU
#include "conio.h"
#include "stdio.h"
#define ESC 27  //phim ESC co ma la 27

void nhap( float &a, float &b)
{
  printf("\n Nhap 2 canh a b:");
  scanf("%f%f", &a,&b);
}
void xuat( float a, float b)
{
  printf("\n HCN co canh a= %.2f, va b=%.2f", a,b);
}
//--------
void tinhdientich(float a, float b)
{
  float s=a*b;
  printf("\n Dien tich= %.2f\n",s);
}
//---------
void tinhchuvi(float a, float b)
{
  float cv=a*b;
  printf("\n Chu vi= %.2f\n",cv);
}
//---------
void inthucdon()
{
     printf("\n\n    TINH DIEN TICH CHU VI HCN\n");
     printf("\n     1.Nhap 2 canh HCN\n");
     printf("\n     2.Xuat cac canh HCN\n");
     printf("\n     3.Tinh dien tich HCN\n");
     printf("\n     4.Tinh chu vi HCN\n");
     printf("\n     ESC. Ket thuc\n");
}
//------
void main()
{
    float a=0,b=0;
    char ch;
	do
	{
	 inthucdon();
	 ch=getch();
	 switch (ch)
	   {
	      case '1':
		  nhap(a,b);
		  printf("\n\n ENTER ve lai thuc don chinh");
		  getch();
		  break;
	      case '2':
		  xuat(a,b);
		  printf("\n\n ENTER ve lai thuc don chinh");
		  getch();
		  break;
	      case '3':
		  tinhdientich( a,b);
		  printf("\n\n ENTER ve lai thuc don chinh");
		  getch();
		  break;
	      case '4':
		  tinhchuvi(a,b);
		  printf("\n\n ENTER ve lai thuc don chinh");
		  getch();
		  break;
	   } // het case
	}
	while (ch !=ESC);
}//Het main()


