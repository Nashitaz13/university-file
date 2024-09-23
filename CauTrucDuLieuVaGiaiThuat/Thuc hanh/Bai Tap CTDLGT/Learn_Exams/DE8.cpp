	                    /*DE 8*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<math.h>

typedef struct node
{
    unsigned int key;
    struct node *trai;
    struct node *phai;        
}node;
typedef node *tree;

int insert(tree &t,unsigned int x);
void nhap(tree &t);
void LNR(tree t);
void huynode(tree &t,unsigned int x);
void thaythe(tree &p,tree &t);
int chinhphuong(int x);
void xoaCP(tree &t);
int tong(node *p);
void tongCB(tree t);

main()
{
      int a;
      tree t;
      t=NULL;
      for(;;)
      {
             printf("\n1.nhap");
             printf("\n2.xuat");
             printf("\n3.xoa cac nut chinh phuong");
             printf("\n4.cac node co tong ben trai bang tong ben phai");
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
                                        LNR(t);
                                        getch();
                                        break;    
                                    }
                               case 3:
                                    {
                                        xoaCP(t);
                                        LNR(t);
                                        getch();
                                        break;    
                                    }
                               case 4:
                                    {
                                        tongCB(t);
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

int insert(tree &t,unsigned int x)
{
    if(t)
    {
        if(t->key==x)return 0;
        if(t->key>x) return insert(t->trai,x);
        else return insert(t->phai,x);     
    }    
    t=new node;
    if(t==NULL) return -1;
    t->key=x;
    t->trai=t->phai=NULL;
    return 1;
}

void nhap(tree &t)
{
    int n,x;
    printf("\nso phan tu can nhap: ");
    scanf("%d",&n);
    for(int i=0;i<n;i++)  
    {
        printf("so thu %d: ",i+1);
        scanf("%d",&x);
        insert(t,x);        
    }   
}

void LNR(tree t)
{
    if(t)
    { 
        LNR(t->trai);
        printf("%4d",t->key);
        LNR(t->phai); 
    }    
}

void huynode(tree &t,unsigned int x)
{
    if(t)
    {
        if(t->key<x) huynode(t->phai,x);
        else
        {
            if(t->key>x) huynode(t->trai,x);
            else
            {
                node *p;
                p=t;
                if(t->trai==NULL) t=t->phai;
                else
                {
                    if(t->phai==NULL) t=t->trai;
                    else thaythe(p,t->phai);    
                }   
                delete p; 
            }    
        }     
    }   
    else printf("\nkhong tim thay phan tu can tim");  
}

void thaythe(tree &p,tree &t)
{
    if(t->trai!=NULL)
    thaythe(p,t->trai);
    else
    {
        p->key=t->key;
        p=t;
        t=t->phai;    
    }     
}

int chinhphuong(int x)
{
    int a;
    a=sqrt(x);
    if((x!=2)&&(a*a==x))
    return 1;
    else return 0;    
}

void xoaCP(tree &t)
{
      if(t)
      {         
          xoaCP(t->trai);
          xoaCP(t->phai); 
          if(chinhphuong(t->key)==1)
          huynode(t,t->key);    
      }   
}

int tong(node *p)
{
    if(p==NULL)return 0;
    else return p->key+tong(p->trai)+tong(p->phai);    
}

void tongCB(tree t)
{
     if(t)
     {
        int a,b;
        a=tong(t->trai);
        b=tong(t->phai);
        if(a==b&&a!=0) printf("%4d",t->key);
        tong(t->trai);
        tong(t->phai); 
     }    
}












