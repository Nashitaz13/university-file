                            /*DE 11*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
#include<time.h>
typedef struct node
{
    char key;
    int dem;
    struct node *next;        
}node;

typedef struct list
{
    node *dau;
    node *cuoi;        
}list;
void taolist(list &l);
node *taonode(char x);
void themdau(list &l,node *p);
void nhap(list &l);
void xuat(list l);
main()
{
      int a;
      list l;
      taolist(l);
      for(;;)
      {
             printf("\n1.nhap");
             printf("\n2.xuat");
             printf("\n");
             printf("\n");
             printf("\n0.thoat");
             printf("\nnhap lua chon");
             scanf("%d",&a);
             switch(a)
             {
                               case 1:
                                    {
                                        nhap(l);
                                        getch();
                                        break;       
                                    }
                               case 2:
                                    {
                                        xuat(l);
                                        break;    
                                    }
                               case 0: return 0;
                               default: break;
                                    
             }
             system("cls");                  
      } 
      getch();     
}
void taolist(list &l)
{
    l.dau=NULL;
    l.cuoi=NULL;     
}
node *taonode(char x)
{
       node *p;
       p=new node;
       if(p==NULL)exit(1);
       //strcpy(p->key,x);
       p->key=x;
       p->dem=1;
       p->next=NULL;
       return p;  
}
void themdau(list &l,node *p)
{
    if(l.dau==NULL)
    {
        l.dau=p;
        l.cuoi=l.dau;               
    }     
    else
    {
          p->next=l.dau;
          l.dau=p;  
    }
}
int sosanh(list l,char x)
{
    node *p;
    p=l.dau;
    while(p)
    {
        if(p->key==x)
        {
            p->dem++;  
            return 0;          
        }  
        p=p->next;      
    }    
    return 1;
}

void nhap(list &l)
{
    int n,a=0;
    char x;
    node *p;
   // printf("\nso phan tu can nhap: ");
   // scanf("%d",&n);
    srand(time(0));
    for(int i=0;i<10000;i++)
    {
         x=char(rand()%26+65);
         if(sosanh(l,x)==0);
         else
         {   
             a++;          
             printf("\n-%d: %c",a,x);             
             themdau(l,taonode(x));
             //p->dem++;
         }
                
    }     
}
void xuat(list l)
{
    node *p;
    p=l.dau;
    int a=0;
    printf("\n----------------------------------------");
    printf("\n|STT  | chu so   |    so lan xuat hien |");
    printf("\n------+----------+---------------------|"); 
    while(p)
    {
        a++;   
        printf("\n| %3d |%4c      |       %5d         |",a,p->key,p->dem);
        p=p->next;        
    } 
    printf("\n------+----------+----------------------"); 
    getch();   
}




















