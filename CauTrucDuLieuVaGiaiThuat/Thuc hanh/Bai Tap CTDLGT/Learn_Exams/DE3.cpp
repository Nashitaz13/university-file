                            /*DE 3*/
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

/*----------khai bao ham-----------*/
void taolist(list &l);
node *taonode(int x);
void themdau(list &l,node *p);
void nhap(list &l);
void xuat(list l);
void sapxep(list &l);
void cong(list &l1,list &l2);
void thcong();

/*---------------------------------*/

main()
{
      int a;
      list l,l1,l2;
      
      for(;;)
      {
             printf("\n1.nhap list");
             printf("\n2.xuat list");
             printf("\n3cong 2 list");
             printf("\n0.thoat");
             printf("\nnhap lua chon: ");
             scanf("%d",&a);
             switch(a)
             {
                               case 1:
                                    {
                                        taolist(l);
                                        nhap(l);
                                        break;       
                                    }
                               case 2:
                                    {
                                        xuat(l);
                                        getch();
                                        break;    
                                    }
                               case 3:
                                    {
                                        thcong();
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

node *taonode(int x)
{
    node *p;
    p=new node;
    if(p==NULL) exit(1);
    
    p->info=x;
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

void nhap(list &l)
{
    int n,x;
    printf("\nso phan tu can nhap: ");
    scanf("%d",&n);
    for(int i=0;i<n;i++)
    {
         printf("so thu %d: ",i+1);
         scanf("%d",&x);
         themdau(l,taonode(x));
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
}

void themvitri(list &l,node *p,node *q)
{
    if(q!=NULL)
    {
        p->next=q->next;
        q->next=p;
        if(l.cuoi=q)
        l.cuoi=p;
                   
    }  
    else themdau(l,p);
}

void sapxep(list &l)
{
     int t;
     for(node *p=l.dau;p!=NULL;p=p->next)
              for(node *q=p->next;q!=NULL;q=q->next)
              if(q->info>p->info)
              {
                  t=q->info;
                  q->info=p->info;
                  p->info=t;                  
              } 
}
void cong(list &l1,list &l2)
{
    node *p1,*p2; 
    int a;
    list l3;
    taolist(l3);
    p1=l1.dau;
    while(p1)
    {
           a=p1->info;  
           themdau(l3,taonode(a));   
           p1=p1->next;      
    } 
    p2=l2.dau;
    while(p2)
    {
        a=p2->info;
        themdau(l3,taonode(a));
        p2=p2->next;         
    } 
    sapxep(l3); 
    xuat(l3);   
}

void thcong()
{
        list l1,l2;
        taolist(l1);
        printf("\nlist thu 1: \n");
        nhap(l1);
        taolist(l2);
        printf("\nlist thu 2: \n");
        nhap(l2);
        cong(l1,l2); 
}
