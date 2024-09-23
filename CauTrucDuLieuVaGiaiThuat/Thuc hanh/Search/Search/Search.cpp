#include <stdio.h>
#include <conio.h>

void Nhap(int n, int a[]);
void Xuat(int n, int a[]);
int Max(int n, int a[]);
void TKTT(int n, int a[], int x);
int TKNP(int n, int a[], int x);
void Swap(int &a, int &b);
void InterChange_Sort(int n, int a[]);

void main()
{
	int n, a[100], x;
	printf("Nhap so phan tu: ");
	scanf_s("%d", &n);
	Nhap(n, a);
	Xuat(n, a);
	printf("\nPhan tu lon nhat la %d tai vi tri ", Max(n, a));
	TKTT(n, a, Max(n, a));
	printf("\nMang sap xep tang: ");
	InterChange_Sort(n, a);
	Xuat(n, a);
	printf("\nNhap phan tu x can tim: ");
	scanf_s("%d", &x);
	if (TKNP(n, a, x))
		printf("Da tim thay x!");
	else
		printf("Khong tim thay x!");
	_getch();
}

void Nhap(int n, int a[])
{
	for (int i = 0; i<n; i++)
	{
		printf("Nhap phan tu thu %d:", i + 1);
		scanf_s("%d", &a[i]);
	}
}
void Xuat(int n, int a[])
{
	for (int i = 0; i<n; i++)
		printf("%d ", a[i]);
}
int Max(int n, int a[])
{
	int max;
	max = a[0];
	for (int i = 0; i<n; i++)
	{
		if (a[i] >= max)
			max = a[i];
	}
	return max;
}
void TKTT(int n, int a[], int x)
{
	for (int i = 0; i<n; i++)
	{
		if (a[i] == x)
		{
			//return true;
			printf("%d ", i + 1);
		}
		//if(i==n-1 && a[i]!=x)
		//	printf("Khong tim thay %d",x);
		//return false;
	}
}
int TKNP(int n, int a[], int x)
{
	int l = 0, r = n - 1, mid;
	do
	{
		mid = (l + r) / 2;
		if (a[mid] == x) return 1;
		else
		{
			if (a[mid]<x)
				l = mid + 1;
			else
				r = mid - 1;
		}
	} while (l <= r);
	return 0;
}
void InterChange_Sort(int n, int a[])
{
	int temp;
	for (int i = 0; i<n - 1; i++)
	{
		for (int j = i + 1; j<n; j++)
		if (a[i]>a[j])
			Swap(a[i], a[j]);
	}
}
void Swap(int &a, int &b)
{
	int temp = a;
	a = b;
	b = temp;
}