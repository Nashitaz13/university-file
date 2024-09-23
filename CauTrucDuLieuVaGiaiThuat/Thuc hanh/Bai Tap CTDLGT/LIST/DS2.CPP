#include<stdio.h>
#include<conio.h>
#include<alloc.h>
#include<string.h>
typedef struct SV{
	char MSSV[10];
	char HoTen[100];
	char NgaySinh[20];
	char DiaChi[100];
	float Diem;
};
typedef struct Node{
	SV * info;
	Node *next;
};
typedef struct List{
	Node *pHead;
	Node *pTail;
};
void KhoiTao_List(List *L){
	L->pHead=NULL;
	L->pTail=NULL;
}
SV * KhoiTao_SinhVien(){
	SV  * sv = new SV;
		 //   sv=(SV)malloc(sizeof(SV));
	float temp;
	printf("\n Nhap ma so sinh vien:");gets(sv->MSSV);
	printf("\n Nhap ho ten:   ");gets(sv->HoTen);
	printf("\n Nhap ngay sinh:   ");gets(sv->NgaySinh);
	printf("\n Nhap dia chi:   ");gets(sv->DiaChi);
	printf("\n Nhap diem:   ");scanf("%f",&temp);
	sv->Diem=temp;
//flushall();
	return sv;
}
Node * KhoiTao_Node(SV * pt){
		//   Node *p=(Node)malloc(sizeof(Node));
	Node*p=new Node;
	if(p==NULL)
		 printf("Khong lam");
	 else{
		 p->info=pt;
		 p->next=NULL;
	 }
	 return p;
}
void InDanhSach(List * L){
	Node *p= L->pHead;
	while (p!=NULL){
		printf("\n Ma so sv: %s",p->info->MSSV);
		printf("\t Ho ten sv: %s",p->info->HoTen);
		printf("\t Ngay sinh: %s",p->info->NgaySinh);
		printf("\t Dia chi: %s",p->info->DiaChi);
		printf("\t Diem: %.2f",p->info->Diem);
		p=p->next;
		printf("-----> \n");
	}
}
void chencuoi(List *L)
  {
	SV *t=KhoiTao_SinhVien();
	Node * p=KhoiTao_Node(t);
	if(L->pHead==NULL){
		L->pHead=L->pTail=p;
	}
	else{
		L->pTail->next=p;
		L->pTail = p;
	}
}
void sapxep_theodiem(List*L){
	Node *p1,*p2;
	SV *temp;
	for(p1=L->pHead;p1!=NULL;p1=p1->next)
		for(p2=p1->next;p2!=NULL;p2=p2->next)
	 if(p1->info->Diem>p2->info->Diem){
		 temp=p1->info;
		 p1->info=p2->info;
		 p2->info=temp;
	 }
}
void xoacuoi(List * L){
	Node *p= L->pHead;
	if(L->pHead==NULL||L->pTail==NULL)
		printf("\nKhong lam");
	else{
		while(p->next!=L->pTail && p!=NULL)
	 p=p->next;
		if(L->pHead==L->pTail)
	 L->pHead=L->pTail=NULL;
		else{
	 L->pTail=p;
	 delete(p->next);
	 L->pTail->next=NULL;
		}
	}
}
void main(){
	clrscr();
	int n;
	List L;
	printf("\n Nhap vao so sv: ");
	scanf("%d",&n);
	KhoiTao_List(&L);
	for(int i=1;i<=n;i++){
		printf("\n\nNhap thong tin sinh vien thu %d :\n\n",i);
	chencuoi(&L);
	}
	printf("\nDanh sach sinh vien vua nhap");
	InDanhSach(&L);
	sapxep_theodiem(&L);
	printf("\nDanh sach sau khi sap xep");
	InDanhSach(&L);
	printf("\n\nDanh sach sau khi xoa cuoi");
   xoacuoi(&L);
   InDanhSach(&L);
   getch();
}
