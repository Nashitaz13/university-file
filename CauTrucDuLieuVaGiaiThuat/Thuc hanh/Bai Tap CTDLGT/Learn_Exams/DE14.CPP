                                    /*DE 14*/
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
/*---------------khai bao cac ham--------------*/
int insert(tree &t,int x);
void nhap(tree &t);
void xuat(tree t);
void intang(tree t,int k);
int chieucao(tree t);
void cungmuc(tree t);
void min(tree t);
/*---------------------------------------------*/

main()
{
      int a;
      tree t;
      t=NULL;
      for(;;)
      {
	     printf("\n1.nhap");
	     printf("\n2.xuat");
	     printf("\n3.cac nut cung muc theo RLN");
	     printf("\n4.min");
	     printf("\n0.thoat");
	     printf("\nnhap lua chon: ");
	     scanf("%d",&a);
	     switch(a)
	     {
			       case 1:
				    {
                        nhap(t);
                         break;
				    }
			       case 2:
				    {
                        xuat(t);
                        getch();
    					break;
				    }
				    case 3:
                         {
                             cungmuc(t);        
                             break;     
                         }
                    case 4:
                         {
                             min(t);
                             getch();
                             break;    
                         }  
			       case 0: return 0;
			       default: break;

	     }
	     system("cls");
      }
      getch();
}

int insert(tree &t,int x)
{
	if(t)
	{
         if(t->key==x)return 0;
         if(t->key>x) return insert(t->trai,x);
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
        if(t->key==x)return 0;
        if(t->key>x)return sosanh(t->trai,x);
        else return sosanh(t->phai,x);     
    }  
    return 1;  
}
void nhap(tree &t)
{
    int n,x,a=0;
    printf("\nso phan tu can nhap: ");
    scanf("%d",&n);
    srand(time(0));  
    for(int i=0;i<n;i++)
    {
        x=rand()%9+11; 
        if(sosanh(t,x)==0)n++;
        else
        {   
            a++;
            printf("\n-%d: %d",a,x);
            insert(t,x) ;  
        }    
    }
    getch();   
}

void xuat(tree t)
{
    if(t)
    {
        xuat(t->phai);
        xuat(t->trai);
        printf("%4d",t->key);     
    }     
}
void intang(tree t,int k)
{
    if(t==NULL)return;
    if(k==0)
    {
        printf("%4d",t->key);        
    }     
    intang(t->phai,k-1);
    intang(t->trai,k-1);
}
int chieucao(tree t)
{
    if(t==NULL)return 0;
        int a=chieucao(t->trai),b=chieucao(t->phai);
        if(a>b)return a+1;
        else return b+1;     
       
}
void cungmuc(tree t)
{
    int h,i;
    h=chieucao(t)-1;
    for(i=h;i>=0;i--)
    {
        printf("\n-tang thu %d: ",i+1);
        intang(t,i);                 
    }     
    getch();
}
void min(tree t)
{
    
       // min(t->trai);
        if(t->trai==NULL)
        {
            printf("\n%d",t->key); 
            return;    
        }
        min(t->trai);
}
