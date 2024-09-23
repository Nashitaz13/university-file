#include <iostream>
#include <conio.h>
using namespace std;

#define ESC 27

typedef struct CauTrucCay
{
	int data;
	struct CauTrucCay *left, *right;
}TNODE;
typedef TNODE *TREE;

void Menu();
TNODE *TaoPhanTu(int x);
void ThemNode(TREE &T, int x);
void NhapCay(TREE &T);
void DuyetLNR(TREE &T);
void DuyetRNL(TREE &T);
void DuyetNLR(TREE &T);
void TinhChieuCao(TREE &T, int &max, int i);
void DemNode(TREE &T, int &dem);
void XoaCay(TREE &T);
TNODE *TimNode(TREE &T, int x);
//XoaNode
void ThayThe(TREE &p, TREE&q);
int XoaNode(TREE &T, int x);

void main()
{
	int ch, h = 0, d, x;
	TREE T;
	T = NULL;
	do
	{
		Menu();
		cout << "\nNhap lua chon: ";
		cin >> ch;
		switch (ch)
		{
		case 0:
			exit(1);
			break;
		case 1:
			cout << "\n_Nhan Enter de tiep tuc nhap!\n_Nhan ESC de quay ve Menu!";
			NhapCay(T);
			break;
		case 2:
			cout << "\n\tDuyet LNR: ";
			DuyetLNR(T);
			break;
		case 3:
			cout << "\n\tDuyet RNL: ";
			DuyetRNL(T);
			break;
		case 4:
			cout << "\n\tDuyet NLR: ";
			DuyetNLR(T);
			break;
		case 5:
			TinhChieuCao(T, h, 0);
			cout << "\n\tChieu cao cay: " << h;
			break;
		case 6:
			d = 0;
			DemNode(T, d);
			cout << "\n\tTong so Node: " << d;
			break;
		case 7:
			XoaCay(T);
			cout << "\tDa xoa thanh cong!";
			break;
		case 8:
			cout << "\nNhap phan tu can tim: ";
			cin >> x;
			if (TimNode(T, x))
				cout << "\n\tDa tim thay! ";
			else
				cout << "\n\tKhong tim thay! " ;
		case 9:
			cout << "\nNhap phan tu can xoa: ";
			cin >> x;
			if (XoaNode(T, x))
				cout << "\tDa xoa Node chua phan tu " << x;
			else
				cout << "\tKhong tim thay Node chua phan tu " << x;
			break;
		case 10:
			cout << "\nNhap phan tu can them: ";
			cin >> x;
			ThemNode(T, x);
			cout << "\n\tDa them phan tu " << x << " vao cay!";
		}
	} while (1);
}
void Menu()
{
	cout << "\n\nMenu:";
	cout << "\n0: Thoat";
	cout << "\n1: Nhap cay";
	cout << "\n2: Duyet LNR";
	cout << "\n3: Duyet RNL";
	cout << "\n4: Duyet NLR";
	cout << "\n5: Chieu cao cay";
	cout << "\n6: Dem Node";
	cout << "\n7: Xoa Cay";
	cout << "\n8: Tim Node";
	cout << "\n9: Xoa Node";
	cout << "\n10: Them Node vao cay";
}

TNODE *TaoPhanTu(int x)
{
	TNODE *p;
	p = new TNODE;
	if (p == NULL)
	{
		cout << "\nKhong du bo nho!";
		exit(1);
	}
	p->data = x;
	p->left = p->right = NULL;
	return p;
}
void ThemNode(TREE &T, int x)
{
	if (T != NULL)
	{
		if (T->data == x)
			return;
		else
		if (T->data > x)
			return ThemNode(T->left, x);
		else
			return ThemNode(T->right, x);
	}
	else
	{
		T = new TNODE;
		T->data = x;
		T->left = T->right = NULL;
	}
}
void NhapCay(TREE &T)
{
	int x, i = 0;
	cout << "\nNhap cac phan tu: \n";
	do
	{
		cout << "Nhap phan tu thu "<< i+1 << ": ";
		cin >> x;
		ThemNode(T, x);
		i++;
	} 
	while (ESC != _getch());
}
void DuyetLNR(TREE &T)
{
	if (T != NULL)
	{
		DuyetLNR(T->left);
		cout << T->data << " ";
		DuyetLNR(T->right);
	}
}
void DuyetRNL(TREE &T)
{
	if (T != NULL)
	{
		DuyetRNL(T->right);
		cout << T->data << " ";
		DuyetRNL(T->left);
	}
}
void DuyetNLR(TREE &T)
{
	if (T != NULL)
	{
		cout << T->data << " ";
		DuyetNLR(T->left);
		DuyetNLR(T->right);
	}
}
void TinhChieuCao(TREE &T, int &max, int i)
{
	if (T != NULL)
	{
		if (i > max)
			max = i;
		TinhChieuCao(T->left, max, i + 1);
		TinhChieuCao(T->right, max, i + 1);
	}
}
void DemNode(TREE &T, int &dem)
{
	if (T != NULL)
	{
		dem++;
		DemNode(T->left, dem);
		DemNode(T->right, dem);
	}
}
void XoaCay(TREE &T)
{
	if (T != NULL)
	{
		XoaCay(T->left);
		XoaCay(T->right);
		delete T;
		T = NULL;
	}
}
TNODE *TimNode(TREE &T, int x)
{
	if (T != NULL)
	{
		TNODE *p;
		p = T;
		if (p->data == x)
			return p;
		else
		{
			if (p->data > x)
				return TimNode(T->left, x);
			if (p->data < x)
				return TimNode(T->right, x);
		}
	}
	return NULL;
}
//Xóa Node
void ThayThe(TREE &p, TREE&q)
{
	if (q->left)
		ThayThe(p, q->left);
	else
	{
		p->data = q->data;
		p = q;
		q = q->right;
	}
}
int XoaNode(TREE &T, int x)
{
	TNODE *p;
	if (T == NULL)
		return 0;
	if (x < T->data)
		XoaNode(T->left, x);
	else
	if (x > T->data)
		XoaNode(T->right, x);
	else
	{
		p = T;
		if (T->left == NULL)
			T = T->right;
		else
		if (T->right == NULL)
			T = T->left;
		else
			ThayThe(p, T->right);
		delete p;
		return 1;
	}
}