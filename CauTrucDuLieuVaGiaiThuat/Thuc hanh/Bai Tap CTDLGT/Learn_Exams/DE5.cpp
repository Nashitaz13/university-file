                /*DE 5*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<ctype.h>
typedef struct node
{
    char info;
    struct node *next;        
}node;
typedef struct list
{
    node *dau;
    node *cuoi;        
}list;

void taolist(list &l);
node *taonode(char x);
void themsau(list &l,node *p);
char kytu(char k);
void nhap(list &l);
int dem(list l);
int sosanh(list l1,list l2);

main()
{
      int a;
      list l1,l2;
      for(;;)
      {
             printf("\n1.nhap ");
             printf("\n2.so sanh");
             //printf("\n");
            // printf("\n");
             printf("\n0.thoat");
             printf("\nnhap lua chon: ");
             scanf("%d",&a);
             switch(a)
             {
                               case 1:
                                    {
                                        taolist(l1);
                                        printf("Nhap so Hex A:\n");
                                        nhap(l1);
                                        taolist(l2);
                                        printf("Nhap so Hex B:\n");
                                        nhap(l2);
                                        break;       
                                    }
                              case 2:
                                    {
                                        if (sosanh(l1,l2)== -1)
		                                printf("B > A");
	                                    else if (sosanh(l1,l2)== 1)
		                                printf("A > B");
	                                    else
		                                printf("A = B");
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

node *taonode(char x)
{
    node *p;
    p=new node;
    if(p==NULL) exit(1);
    p->info=x;
    p->next=NULL;
    return p;     
}

void themsau(list &l,node *p)
{
    if(l.cuoi==NULL)
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
char kytu(char k)
{
    return((k>='0'&&k<='9')||(k>='A'&&k<='F'));
}

void nhap(list &l)
{
        //taolist(l);
        char k;
        int n=0;
        do
        {
           n++;
           printf("%d.",n);
           fflush(stdin);
           scanf("%c",&k);
           k=toupper(k);
           if(kytu(k))
           themsau(l,taonode(k));
        }while(kytu(k));        
}

int dem(list l)
{
    node *p;
    int a=0;
    p=l.dau;
    while(p)
    {
        a++;
        p=p->next;        
    }   
    return a; 
}

int sosanh(list l1,list l2)
{
    if(dem(l1)<dem(l2))return -1;
    else if(dem(l1)>dem(l2)) return 1;
    
    node *p,*q;
     for(p=l1.dau,q=l2.dau;p!=NULL,q!=NULL;p=p->next,q=q->next) 
         if(p->info<q->info) return -1;
         else if(p->info>q->info) return 1;                                                            
     return 0;
}
