                        /*DE 7*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>

typedef struct node
{
    unsigned int info;
    struct node *next;        
}node;
typedef struct list
{
    node *dau;
    node *cuoi;        
}list;

void taolist(list &l);
node *taonode(unsigned int x);
void themcuoi(list &l,node *p);
void nhap(list &l);
void xuat(list l);
void sapxep(list &l);
int huysau(list &l,node *q);
void tinhchinh(list &l);
int CSC(list &l);


main()
{
      int a;
      list l;
      taolist(l);
      for(;;)
      {
             printf("\n1.nhap");
             printf("\n2.xuat");
             printf("\n3.sap xep");
             printf("\n4.kiem tra cap so cong");
             printf("\n0.thoat");
             printf("\nnhap lua chon: ");
             scanf("%d",&a);
             switch(a)
             {
                               case 1:
                                    {
                                         nhap(l);
                                        break;       
                                    }
                               case 2:
                                    {
                                        xuat(l);
                                        break;    
                                    }
                               case 3:
                                    {
                                        sapxep(l);
                                        tinhchinh(l);
                                        xuat(l);
                                        break;    
                                    }
                               case 4:
                                    {
                                        if(CSC(l)==1)printf("\nla 1 cap so cong");
                                        else printf("\nkhong phai la 1 cap so cong");
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

void taolist(list &l)
{
    l.dau=NULL;
    l.cuoi=NULL;     
}

node *taonode(unsigned int x)
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
    int n=0;
    int x;
    do
    {
        n++;
        printf("-%d: ",n);
        scanf("%d",&x);
        if(x>0)themcuoi(l,taonode(x));
    }while(x>0);     
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

void sapxep(list &l)
{
    unsigned t;
    for(node *p=l.dau;p!=NULL;p=p->next)
             for(node *q=p->next;q!=NULL;q=q->next)
              if(q->info<p->info)
              {
                  t=q->info;
                  q->info=p->info;
                  p->info=t;                                     
              }                                
}

int huysau(list &l,node *q)
{
    node *p;
    if(q)
    {
        p=q->next;
        if(p)
        {
            if(p==l.cuoi) l.cuoi=q;
            q->next=p->next;
            delete p;     
        }     
        return 1;
    }
    else return 0;
}

void tinhchinh(list &l)
{
    node *p,*q;
    p=l.dau;
   
    while(p!=l.cuoi)
    {
        
        q=p->next;
        if(q->info==p->info)
        huysau(l,p);         
         p=p->next;            
    }    
}

int CSC(list &l)
{
       node *p;
       p=l.dau;
       if(p==NULL||p->next==NULL)
       return 1;
       else 
       {
           int a=p->next->info-p->info;
           for(p=l.dau;p!=l.cuoi;p=p->next)
               if((p->next->info-p->info)!=a)
                           return 0;
                return 1;                               
           
                
       }  
}
