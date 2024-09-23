                            /*DE 6*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
typedef struct node 
{
    int key;
    struct node *trai;
    struct node *phai;
}node;
typedef node *tree;

int insert(tree &t,int x);
void nhap(tree &t);
void LNR(tree t);
void huy(tree &t,int x);
void thaythe(tree &p,tree &t);
int SNT(int x);
void huySNT(tree &t);
int count(node *p);
void demcb(tree t);

main()
{
      int a;
      tree t;
      t=NULL;
      for(;;)
      {
             printf("\n1.nhap");
             printf("\n2.xuat");
             printf("\n3.xoa cac so nguyen to");
             printf("\n4.cac nut can bang");
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
                                        huySNT(t);
                                        LNR(t);
                                        getch();
                                        break;    
                                    }
                                case 4:
                                    {
                                        demcb(t);
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
        if(t->key==x) return 0;
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
        printf("-%d: ",i+1);
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

void huy(tree &t,int x)
{
     if(t)
     {
          if(t->key<x) huy(t->phai,x);
          else
          {
              if(t->key>x) huy(t->trai,x);
              else
              {
                  node *p;
                  p=t;
                  if(t->trai==NULL) t=t->phai;
                  else 
                  {
                      if(t->phai==NULL)t=t->trai;
                      else thaythe(p,t->phai);     
                  } 
                  delete p;   
              }    
          }
     }  
     else printf("khong tim thay phan tu can xoa");   
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
int SNT(int x)
{
    int i;
    for(i=2;i<x;i++)
    {
        if(x%i==0)return 0;                
    }    
    return 1;
}

void huySNT(tree &t)
{
    if(t)
    {
        huySNT(t->trai);
        huySNT(t->phai);
        if(SNT(t->key)==1)huy(t,t->key);     
    }     
}


int count(node *p)
{
    if(p)
    {
        return 1+count(p->trai)+count(p->phai);     
    }   
    else return 0; 
}

void demcb(tree t)
{
    if(t)
    {
         int a=count(t->phai);
         int b=count(t->trai);
         if(a>0&&a==b) printf("%4d",t->key);
         demcb(t->trai);
         demcb(t->phai);
    }     
}



