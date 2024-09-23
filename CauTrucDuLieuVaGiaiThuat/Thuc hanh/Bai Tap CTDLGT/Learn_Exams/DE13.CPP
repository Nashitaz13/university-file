				    /*DE 13*/
			       /*n = rand%(b-a+1)+a;*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<time.h>
typedef struct node
{
    int key;
    struct node *trai;
    struct node *phai;
}node;
typedef node *tree;
/*-------------khai bao cac ham-----------*/
int insert(tree &t,int x);
int sosanh(tree t,int x);
void nhap(tree &t);
void LRN(tree t);
int chieucao(tree t);
void intang(tree t,int k);
void cungmuc(tree t);

/*----------------------------------------*/
main()
{
      int a;
      tree t;
      t=NULL;
      for(;;)
      {
	     printf("\n1.nhap");
	     printf("\n2.xuat");
	     printf("\n3.cac khoa cung muc");
	     printf("\n4.chieu cao");
	     printf("\n0.thoat");
	     printf("\nnhap lua chon: ");
	     scanf("%d",&a);
	     switch(a)
	     {
			       case 1:
				    {   nhap(t);
					break;
				    }
			       case 2:
				    {   LRN(t);
					getch();
					break;
				    }
			       case 3:
				    {
					cungmuc(t);
					getch();
					break;

				    }
			       case 4:
				    {
					printf("\nchieu cao cua cay la: %d",chieucao(t));
					getch();
					break;
				    }
			       case 0: return 0;
			       default: break;

	     }
	     system("cls");
      }
      getch();
      return 0;
}
int insert(tree &t,int x)
{
	if(t)
	{
		if(t->key==x)return 0;
		if(t->key>x)return insert(t->trai,x);
		else return insert(t->phai,x);
	}
	t=new node;
	if(t==NULL)return -1;
	t->key=x;
	t->trai=t->phai=NULL;
	return 1;
}
int sosanh(tree t,int x)
{
    if(t)
    {
    	if(t->key==x) return 1;
    	if(t->key>x)return sosanh(t->trai,x);
    	else return sosanh(t->phai,x);
    }
    else return 0;
}

void nhap(tree &t)
{
	int n,x,a=0;
	srand(time(0));
	printf("\nso phan tu can nhap: ");
	scanf("%d",&n);
	for(int i=0;i<n;i++)
	{
		x=(rand()%9+11);
		if(sosanh(t,x)==1)n++;
		else
	{
	     a++;
	     printf("\n-%d: %d",a,x);
		     insert(t,x);
	}
	}
     getch();
}

void LRN(tree t)
{
     if(t)
     {
	LRN(t->trai);
	LRN(t->phai);
	printf("%4d",t->key);
     }
}

int chieucao(tree t)
{
	if(t==NULL)return 0;
	int a=chieucao(t->trai),b=chieucao(t->phai);
	if(a>b) return a+1;
	else return b+1;
}
void intang(tree t,int k)
{
	if(t==NULL)return; 

		if(k==0)
		{
			printf("%4d",t->key);
		}
		intang(t->trai,k-1);
		intang(t->phai,k-1);



}

void cungmuc(tree t)
{
	int h,k;
	h=chieucao(t)-1;
	for(int i=h;i>=0;i--)
	{
		printf("\n-tang %d: ",i+1);
		intang(t,i);

	}

}
