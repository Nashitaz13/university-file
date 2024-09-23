                                    /*DE 10*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
typedef struct node
{
    int info;
    struct node *next;        
}node;
typedef struct list
{
    node *dau;
    node *cuoi;        
}list;

void taolist(list &l);
node *taonode(int x);
void themcuoi(list &l,node *p);
void nhap(list &l);
void xuat(list l);
void gheplist(list l,list l1);

main()
{
      int a;
      list A,B;
      for(;;)
      {
             printf("\n1.nhap");
             printf("\n2.xuat");
             printf("\n3.ghep list");
             printf("\n0.thoat");
             printf("\nnhap lua chon: ");
             scanf("%d",&a);
             switch(a)
             {
                               case 1:
                                    {
                                        printf("\nlist A: ");      
                                        taolist(A);
                                        nhap(A);
                                        printf("\nlist B: ");
                                        taolist(B);
                                        nhap(B);
                                        break;       
                                    }
                               case 2:
                                    {
                                        printf("\nlist A: ");
                                        xuat(A);
                                        printf("\nlist B: ");
                                        xuat(B);
                                        break;    
                                    }
                               case 3:
                                    {
                                        gheplist(A,B);
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

node *taonode(int x)
{
    node *p;
    p=new node;
    if(p==NULL) exit(1);
    p->info=x;
    p->next=NULL;
    return p;     
}

void themcuoi(list &l,node *p)
{
    if(l.dau==NULL)
    {
        l.dau=p;
        l.cuoi=l.dau;               
    }     
    else
    {
        l.cuoi->next=p;
        l.cuoi=p;    
    }
}

void nhap(list &l)
{
         int x,n,a=0;
         printf("\nso phan tu can nhap: ");
         scanf("%d",&n);
         for(int i=0;i<n;i++)
         {
             a++;
             printf("-%d: ",a);
             scanf("%d",&x);
             if(l.cuoi!=NULL)
             {
                if(l.cuoi->info>=x)
                {
                    do
                    {
                        printf("xin vui long nhap lai 1 so lon hon so truoc: ");
                        scanf("%d",&x);              
                    }while(l.cuoi->info>=x);                 
                }
             }      
             themcuoi(l,taonode(x)); 
         }
}

void xuat(list l)
{
    node *p;
    p=l.dau;
    while(p)
    {
        printf("%4d",p->info);
        p=p->next;        
    }
    getch();
}

void gheplist(list l,list l1)
{
    node *p,*q;
    p=l1.dau;
    q=l.dau;
    list g;
    taolist(g);
    while(p!=NULL||q!=NULL)
    {
        if(q!=NULL&&p!=NULL)
        {                   
            if(q->info>p->info)
            {
                themcuoi(g,taonode(p->info));
                p=p->next;
            }
            else 
            {
                themcuoi(g,taonode(q->info));
                q=q->next;    
            }
        }
        if(q!=NULL&&p==NULL)
        {
            themcuoi(g,taonode(q->info));
            q=q->next;
        }
        if(p!=NULL&&q==NULL)
        {
            themcuoi(g,taonode(p->info));
            p=p->next;
        }
    }
       xuat(g);
       getch();  
}












