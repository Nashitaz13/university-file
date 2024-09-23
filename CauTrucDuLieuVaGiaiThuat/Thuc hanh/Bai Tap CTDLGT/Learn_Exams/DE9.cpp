                            /*DE 9*/
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
void themdau(list &l,node *p);
void nhap(list &l);
void xuat(list l);
int huysau(list &l,node *q);
void huycuoi(list &l);
void xoatrung(list &l);
int sosanh(list l,int x);
void nhapchuan(list &l);

main()
{
      int a;
      list l;
      taolist(l);
      for(;;)
      {
             printf("\n1.nhap");
             printf("\n2.xuat");
             printf("\n3xoa trung");
             printf("\n4.them khac");
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
                                        xoatrung(l);
                                        xuat(l);
                                        break;    
                                    }
                               case 4:
                                    {
                                        nhapchuan(l);
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
    int x,n=0;
    do
    {
        n++;
        printf("-%d: ",n);
        scanf("%d",&x);
        if(x>0)themdau(l,taonode(x));
            
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
int huysau(list &l,node *q)
{
    node *p;
    if(q)
    {
        p=q->next;
        if(p!=NULL)
        {
            if(p==l.cuoi)l.cuoi=q;
            q->next=p->next;
            delete p;           
        }  
        return 1;  
    }    
    else return 0;
}
void huycuoi(list &l)
{
    node *p,*q;
    q=NULL;
    p=l.dau;
    while(p!=l.cuoi)
    {
        q=p;
        p=p->next; 
    }
        if(q==NULL)
        {
           l.dau=NULL;
           l.cuoi=NULL;
        }            
        else 
        {
            q->next=NULL;
            l.cuoi=q;
            delete p;     
        }
        
}

void xoatrung(list &l)
{
    node *p,*q,*a;
    p=l.dau;
    while(p!=l.cuoi)
    {
        a=p;//dung a lam khoa de xoa thang truoc a
        q=p->next;
        while(q!=NULL)
        {
            if(q->info==p->info)
            {    
            //khi q o vi tri cuoi thi` xoa cuoi sau do thoat
                if(q==l.cuoi)
                {
                    huycuoi(l);
                    break;                              
                }  
                else 
                /*neu khong ta huy sau a dong thoi gan lai q vi sau khi xoa
                q , q khong con gia tri nao nua phai gan lai q*/ 
                {
                     huysau(l,a);
                     q=a->next;
                }
            }   
            else 
            /*khi q va p khong giong nhat thi thag a phai dc chuyen len thang q 
            dong thoi q cung chuyen len 1 buoc, de dam bao a luon luon o phai sau*/
            {
                a=q;
                q=q->next;     
            }   
        } 
        //dung de tranh khoi vong lap vo han 
        if(p->next==NULL)return;  
        else p=p->next;            
    }
  
}
int sosanh(list l,int x)
{
      node *p;
      p=l.dau;
      while(p)
      {
          if(p->info==x) return 0; 
          p=p->next;       
      }   
      return 1;    
}

void nhapchuan(list &l)
{
    int x,n=0;
    do
    {
        n++;
        printf("-%d: ",n);
        scanf("%d",&x);
        if((sosanh(l,x)==0))
        {
            do
            {
                            
                 printf("\nnhap lai: ");
                 scanf("%d",&x);
                 
            }while(sosanh(l,x)==0);
        }
        
        if(x>0)themdau(l,taonode(x));
    
            
    }while(x>0);    
}












