                            /*DE4*/
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
/*----------khai bao cac ham-----------------*/
void taolist(list &l);
node *taonode(unsigned int x);
void themdau(list &l,node *p);
int nhap(list &l);
void xuat(list l);
int huysau(list &l,node *q);
int huydau(list &l);
void hoandoi(list &l1,list &l2);
void nhap2list(list &l1,list &l2);
/*----------------------------------------------*/

main()
{
      int a;
      node *p;
      list l,l1,l2;
      taolist(l);
      taolist(l1);
      taolist(l2);
      for(;;)
      {
             printf("\n1.nhap list");
             printf("\n2.xuat list");
             printf("\n3.hoan doi");
             //printf("\n");
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
                                        getch();
                                        break;    
                                    }
                               case 3:
                                    {
                                        nhap2list(l1,l2);
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

int nhap(list &l)
{
    unsigned int n,i=1;
    int x;
    for(;;)
    {
         
         printf("so thu %d: ",i++);
        scanf("%d",&x);
        //gets(x);
         if(x==-1) break;
         else themdau(l,taonode(x));   
    }      
    return 0; 
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

int huysau(list &l,node *q)
{
     node *p;
     if(q!=NULL)
     {
         p=q->next;
         if(p!=NULL)//q khong phai la nut cuoi
         {
              if(p==l.cuoi)
              l.cuoi=q;
              q->next=p->next;
              delete p;
         }          
         return 1;
     }
     else return 0;
}
int huydau(list &l)
{
    node *p;
    if(l.dau!=NULL)
    {
        p=l.dau;
        l.dau=l.dau->next;
        delete p;
        if(l.dau==NULL)l.cuoi=NULL;
        return 1;
    }
    return 0;
}

void hoandoi(list &l1,list &l2)
{
    
    node *p1,*p2,*q,*a;
    
    /*chuyen tat ca so chan o list 2 len list 1 
    dong thoi xoa cac so chan trong list 2*/ 
    q=l2.dau;
    p2=l2.dau;
    while(p2)
    {                   
        while((l2.dau->info%2)==0)//thuc hien khi phan tu dau dung
        {
            themdau(l1,taonode(l2.dau->info));
            huydau(l2); 
            if(l2.dau!=NULL) p2=l2.dau;//gan phan tu dau lai cho p2
            else return;//ket thuc                
        }            
        if(p2->info%2==0)
        {
            themdau(l1,taonode(p2->info));
            huysau(l2,q);
                                  
        }
        else q=p2;//gan so le cho q
        p2=p2->next;    
         
    } 
    
    /*chuyen tat ca so le o list 1 len list 2 
    dong thoi xoa cac so chan trong list 1*/ 
    a=l1.dau;
    p1=l1.dau;
    while(p1)
    {
        while((l1.dau->info%2)!=0)//thuc hien khi phan tu dau dung
        {
            themdau(l2,taonode(l1.dau->info));
            huydau(l1);
            if(l1.dau!=NULL) p1=l1.dau;//gan lai phan tu dau cho p1
            else return; //neu ket thuc thi thoat                       
        }         
        if((p1->info%2)!=0)
        {
            themdau(l2,taonode(p1->info));
            huysau(l1,a);              
        }
        else a=p1;//gan so chan cho a
        p1=p1->next;
    }     
}

void nhap2list(list &l1,list &l2)
{
    printf("\nnhap list 1: \n");
    nhap(l1);
    printf("\nnhap list 2: \n");
    nhap(l2);
    hoandoi(l1,l2);
    xuat(l1);
    printf("\n");
    xuat(l2);        
}
