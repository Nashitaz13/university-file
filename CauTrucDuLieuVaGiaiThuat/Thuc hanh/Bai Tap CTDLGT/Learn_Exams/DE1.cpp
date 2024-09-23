                                /*DE SO 1*/
                          /*DUNG DANH SACH LIEN KET*/
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>

struct date
{
       unsigned int ngay;
       unsigned int thang;
       unsigned int nam;       
};
typedef struct sv
{
        char hoten[80];
        struct date ngaysinh;        
}sv;

typedef struct nodesv
{
        sv info;
        struct nodesv *next;        
}nodesv;

typedef struct list
{
        nodesv *dau;
        nodesv *cuoi;        
}list;
/*---------khai bao cac ham---------- */
void taolist(list &l);
nodesv *taosv();
void nhapsv(list &l);
void xuat(list l);
void huy(list &l);
void sapsep(list &l);
/*-------------------------------------*/
           
main()
{
      int a;
      list l;
      taolist(l);
      nodesv *p;
      for(;;)
      {
             printf("\n1nhap sinh vien");
             printf("\n2xuat sinh vien");
             printf("\n3.huy");
             printf("\n4.sap xep");
             printf("\n0.thoat");
             printf("\nnhap lua chon: ");
             scanf("%d",&a);
             switch(a)
             {
                               case 1:
                                    {
                                         
                                       nhapsv(l);
                                        break;       
                                    }
                               case 2:
                                    {
                                        xuat(l);
                                        break;    
                                    }
                               case 3:
                                    {
                                        huy(l);
                                        break;    
                                    }
                               case 4:
                                    {
                                        sapsep(l);
                                        xuat(l);
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


nodesv *taosv()
{
       nodesv *p;
       sv t;
       p=new nodesv;
       if(p==NULL) exit(1);
       printf("\nnhap ten sinh vien: ");fflush(stdin);
       gets(t.hoten);
       strcpy(p->info.hoten,t.hoten);
       
       printf("ngay sinh (dd mm yy): ");
       scanf("%d %d %d",&t.ngaysinh.ngay,&t.ngaysinh.thang,&t.ngaysinh.nam);
       
       p->info.ngaysinh.ngay=t.ngaysinh.ngay;
       p->info.ngaysinh.thang=t.ngaysinh.thang;     
       p->info.ngaysinh.nam=t.ngaysinh.nam;
       
       p->next=NULL;
       
       return p;            
}

void themdau(list &l,nodesv *p)
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

void nhapsv(list &l)
{
     int a,i;
     nodesv *p;    
     printf("so sinh vien can nhap: ");
     scanf("%d",&a);
     for(i=0;i<a;i++)
     {
         printf("\nsinh vien thu %d",i+1);
       
         themdau(l,taosv());         
     }     
}

void xuat(list l)
{
     nodesv *p;
     p=l.dau;
     printf("\n+---------------------+-------------------+");
     printf("\n|TEN SINH VIEN        |   NGAY SINH       |");
     printf("\n+---------------------+-------------------+");
     while(p)
     {
      printf("\n|%-20s |   %-2d-%-2d-%-4d      |",p->info.hoten,p->info.ngaysinh.ngay,p->info.ngaysinh.thang,p->info.ngaysinh.nam);
      p=p->next;
                 
     } 
     printf("\n+---------------------+-------------------+");   
     getch(); 
}

void huy(list &l)
{
    nodesv *p;
    while(l.dau!=NULL)
    {
                p=l.dau;
                l.dau=p->next;
                delete p;            
    }     
}

void sapsep(list &l)
{
     sv t;
     for (nodesv *p=l.dau;p!=NULL;p=p->next)
			for (nodesv *q=p->next; q!= NULL;q=q->next)
				if (stricmp(p->info.hoten,q->info.hoten)> 0)
				{
					t = p->info;
					p->info = q->info;
					q->info = t;
				} 
}


