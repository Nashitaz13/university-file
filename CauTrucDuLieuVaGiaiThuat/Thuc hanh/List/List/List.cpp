#include <iostream>
#include <conio.h>
using namespace std;

typedef struct SinhVien
{
	char MSSV[8];
	char HoTen[30];
	char NgaySinh[20];
	char DiaChi[50];
	float Diem;
}SV;

typedef struct Node
{
	SV *info;
	struct Node *next;
}Node;

typedef struct List
{
	Node *pHead;
	Node *pTail;
}List;

void KhoiTaoList(List &l);
SV *KhoiTaoSinhVien();
Node *KhoiTaoNode(SV *sv);
void ChenCuoi(List &l);
void InDanhSach(List &l);
void SapXepTheoDiem(List &l);
void XoaCuoi(List &l);

void main()
{
	List L;
	int n;
	cout << "Nhap so luong sinh vien: "; cin >> n;
	KhoiTaoList(L);
	for (int i = 0; i < n; i++)
	{
		cout << "Nhap thong tin sinh vien thu " << i + 1 << ": ";
		ChenCuoi(L);
	}
	cout << "\n_Danh sach sinh vien: ";
	InDanhSach(L);
	//Sắp xếp theo điểm
	SapXepTheoDiem(L);
	cout << "\n_Danh sach sau khi sap xep: ";
	InDanhSach(L);
	//Xóa cuối
	XoaCuoi(L);
	cout << "\nDanh sach sau khi xoa cuoi: ";
	InDanhSach(L);
	_getch();
}

void KhoiTaoList(List &l)
{
	l.pHead = l.pTail = NULL;
}
SV *KhoiTaoSinhVien()
{
	SinhVien *sv;
	sv = new SinhVien;
	cout << "\nNhap MSSV: ";
	cin.ignore(1);	
	cin.getline(sv->MSSV, 8);
	cout << "Nhap Ho Ten: ";
	cin.getline(sv->HoTen, 30);
	cout << "Nhap Ngay Sinh: ";
	cin.getline(sv->NgaySinh, 20);
	cout << "Nhap Dia Chi: ";	
	cin.getline(sv->DiaChi, 50);
	cout << "Nhap diem trung binh: ";
	cin >> sv->Diem;
	return sv;
}
Node *KhoiTaoNode(SV *sv)
{
	Node *p;
	p = new Node;
	if (p == NULL)
		cout << "Khong du bo nho";
	else
	{
		p->info = sv;
		p->next = NULL;
	}
	return p;
}
void ChenCuoi(List &l)
{
	SV *t = KhoiTaoSinhVien();
	Node *p = KhoiTaoNode(t);
	if (l.pHead == NULL)
		l.pHead = l.pTail = p;
	else
	{
		//Thêm đầu:
		//p->next = l.pHead;
		//l.pHead = p;
		l.pTail->next = p;
		l.pTail = p;
	}
}
void InDanhSach(List &l)
{
	Node *p;
	p = l.pHead;
	while (p != NULL)
	{
		cout << "\nMSSV: " << p->info->MSSV<<endl;
		cout << "HoTen: " << p->info->HoTen<<endl;
		cout << "NgaySinh: " << p->info->NgaySinh<<endl;
		cout << "DiaChi: " << p->info->DiaChi<<endl;
		cout << "Diem: " << p->info->Diem<<endl;
		p = p->next;
	}
}
void SapXepTheoDiem(List &l)
{
	Node *p1, *p2;
	SV *temp;
	for (p1 = l.pHead; p1 != NULL;p1=p1->next)
		for (p2 = p1->next; p2 != NULL; p2 = p2->next)
		{
			if (p1->info->Diem > p2->info->Diem)
			{
				temp = p1->info;
				p1->info = p2->info;
				p2->info = temp;
			}
		}
}
void XoaCuoi(List &l)
{
	Node *p = l.pHead;
	if (l.pHead == NULL || l.pTail == NULL)
		cout << "Khong thuc hien" << endl;
	else
	{
		while (p->next != l.pTail && p != NULL)
			p = p->next;
		if (l.pHead == l.pTail)
			l.pHead = l.pTail = NULL;
		else
		{
			l.pTail = p;
			delete(p->next);
			l.pTail->next = NULL;
		}
	}
}