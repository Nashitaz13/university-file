
                            /*DE 2*/
                            /*cay nhi phan tim kiem*/

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
/*-------------khai bao cac ham------------*/
void taocay(tree &t);
int themnode(tree &t,int x);
void RNL(tree t);
void nhap(tree &t);

void huynode(tree &t,int x);
void thaythe(tree &p,tree &t);
int SNT(int x);
void huySNT(tree &t);
void demla(tree t,int &count);

/*------------------------------------------*/
main()
{
      int a,count=0;
      tree t;
      taocay(t);
      for(;;)
      {
             printf("\n1.nhap node");
             printf("\n2.xuat theo chieu giam dan");
             printf("\n3.huy cac so nguyen to trong cay");
             printf("\n4.dem la");
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
                                        RNL(t);
                                        getch();
                                        break;    
                                    }
                               case 3:
                                    {
                                      huySNT(t);
                                      RNL(t);
                                      getch();
                                      break;    
                                    }
                               case 4:
                                    {
                                        demla(t,count);
                                        printf("\nso la cua cay la : %d",count);
                                        getch();
                                    }
                               case 0: return 0;
                               default: break;
                                    
             }
             system("cls");                  
      } 
      getch();     
}

void taocay(tree &t)
{
     t=NULL;     
}

int themnode(tree &t,int x)
{
   if(t!=NULL)
   {
       if(t->key==x) return 0;
       if(t->key>x) return themnode(t->trai,x);
       else return themnode(t->phai,x);      
   }
   t=new node;
   if(t==NULL) return -1;
   t->key=x;
   t->trai=t->phai=NULL;
   return 1;
}

void RNL(tree t)
{
     if(t)
     {
          RNL(t->phai);
          printf("%4d",t->key);
          RNL(t->trai);     
     }     
}
void nhap(tree &t)
{
    int n,x;
    printf("so node can nhap: ")
    scanf("%d",&n);
    for(int i=0;i<n;i++)
    {
        printf("so thu %d: ",i+1);
        scanf("%d",&x);
        themnode(t,x); 
    }     
}
int SNT(int x)
{
        int i;
        for(i=2;i<x;i++)
        {
              if(x%i==0) return 0;
        }
        return 1;
}

void huynode(tree &t,int x)
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
                    else thaythe(p,t->phai); //tim nho nhat ben nhanh phai   
                }
                delete p;        
            }     
        } 
     
    }   
    else printf("\nkhong tim thay so can tim ");   
}

void thaythe(tree &p,tree &t)
{
     if(t->trai)
               thaythe(p,t->trai);
     else
     {
         p->key=t->key;
         p=t;
         t=t->phai;    
     }    
}

void huySNT(tree &t)
{
     if(t)
     {
          huySNT(t->trai);
          huySNT(t->phai);
          if(SNT(t->key)==1) huynode(t,t->key);
             
     }
}

void demla(tree t,int &count)
{
          if(t)
          {
               if(t->phai==NULL&&t->trai==NULL) count++;
               else
               {
               demla(t->trai,count);
               demla(t->phai,count);
               }
          }
}
























