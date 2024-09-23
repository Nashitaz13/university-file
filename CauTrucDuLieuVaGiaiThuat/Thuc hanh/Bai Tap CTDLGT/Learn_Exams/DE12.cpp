                                /*DE 12*/
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
void themdau(list &l,node *p);
void themcuoi(list &l,node *p);
void nhap(list &l);
void daolist(list l,list &l1);
void xuat(list l);
int sosanh(list l1,list l2);
void kiemtra(list l1,list l2);

main()
{
      int a;
      list l,l1;
      taolist(l);
      taolist(l1);
      for(;;)
      {
             printf("\n1.nhap");
             printf("\n2.xuat");
             printf("\n3.tao list dao");
             printf("\n4.kiem tra doi xung");
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
                                        daolist(l,l1);
                                        xuat(l);
                                        printf("\n");
                                        xuat(l1);
                                        break;    
                                    }
                                case 4:
                                    {
                                        kiemtra(l,l1);
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
    if(p==NULL)exit(1);
    p->info=x;
    p->next=NULL;
    return p ;    
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
    node *p;
    int x,n;
    printf("\nso phan tu can nhap: ");
    scanf("%d",&n);
    for(int i=0;i<n;i++)
    {
        printf("-%d: ",i+1);
        scanf("%d",&x);
        themcuoi(l,taonode(x));        
    }     
}

void daolist(list l,list &l1)
{
    node *p;
    p=l.dau;
    while(p)
    {
        themdau(l1,taonode(p->info));
        p=p->next;        
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

int sosanh(list l1,list l2)
{
    node *p,*q;
    for(p=l1.dau,q=l2.dau;p!=NULL,q!=NULL;p=p->next,q=q->next)
    {
                if(p->info!=q->info)return 0;                                            
    }
    return 1;
}
void kiemtra(list l1,list l2)
{
    if(sosanh(l1,l2)==0)
    printf("\ndanh sach khong doi xung");
    else printf("\ndanh sach doi xung");
    getch();     
}
