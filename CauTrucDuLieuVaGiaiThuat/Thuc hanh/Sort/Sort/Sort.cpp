#include <stdio.h>
#include <conio.h>
#include <time.h>
#include <stdlib.h>

void Nhap(int n, int a[]);
void Xuat(int n, int a[]);
void Swap(int &a, int &b);
void InterChange_Sort(int n, int a[]); // Đổi chỗ trực tiếp
void Selection_Sort(int n, int a[]); // Chọn trực tiếp
void Insertion_Sort(int n, int a[]);
void BInsertion_Sort(int n, int a[]);
void Bubble_Sort(int n, int a[]); // Nổi bọt
void Shaker_Sort(int n, int a[]);
void Shell_Sort(int n, int a[]);
void Quick_Sort(int a[], int l, int r); // Quick Sort
void TimeSort(int n, int a[]);

void main()
{
	int n, *a;
	int l = 0,r;
	printf("Nhap so phan tu: ");
	scanf_s("%d", &n);
	a = new int[n];
	r = n - 1;
	Nhap(n, a);
	printf("Mang phan so: ");
	Xuat(n, a);
	//Quick_Sort(a, l, r);
	//InterChange_Sort(n, a);
	//Selection_Sort(n, a);
	//Insertion_Sort(n, a);
	//Bubble_Sort(n, a);
	//Shaker_Sort(n, a);
	printf("\nMang sap tang: ");
	Xuat(n, a);
	//TimeSort(n, a);
	_getch();
}

void Nhap(int n, int a[])
{
	srand(time(NULL));
	for (int i = 0; i < n; i++)
	{
		//printf("Phan tu thu %d: ", i + 1);
		a[i] = rand() % 100;
		//printf("%d\n", a[i]);
	}
}
void Xuat(int n, int a[])
{
	for (int i = 0; i < n; i++)
		printf("%d ", a[i]);
}
void Swap(int &a, int &b)
{
	int c = a;
	a = b;
	b = c;
}
void InterChange_Sort(int n, int a[])
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = i + 1; j < n; j++)
		if (a[i]>a[j])
			Swap(a[i], a[j]);
	}
}
void Bubble_Sort(int n, int a[])
{
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = n - 1; j>i; j--)
		if (a[j] < a[j - 1])
			Swap(a[j], a[j - 1]);
	}
}
void Selection_Sort(int n, int a[])
{
	int min;
	for (int i = 0; i < n - 1; i++)
	{
		min = i;
		for (int j = i + 1; j < n; j++)
			if (a[j] < a[min])
				min = j;
		if (min!=i) // Cải tiến: thêm điều kiện để giảm bớt trường hợp hoán vị chính nó
			Swap(a[min], a[i]);
	}
}
void Quick_Sort(int a[], int l, int r)
{
	int i, j, x;
	x = a[(l + r) / 2];
	i = l; j = r;
	do
	{
		while (a[i]<x) i++;
		while (a[j]>x) j--;
		if (i <= j)
		{
			Swap(a[i], a[j]);
			i++;
			j--;
		}
	} while (i <= j);
	if (l<j) Quick_Sort(a, l, j);
	if (i<r) Quick_Sort(a, i, r);
}
void Insertion_Sort(int n, int a[])
{
	int pos, i, x;
	for (i = 1; i < n; i++)
	{
		x = a[i];
		pos = i - 1;
		while (pos >= 0 && a[pos]>x)
		{
			a[pos + 1] = a[pos];
			pos--;
		}
		a[pos+1] = x;
	}
}
void Shaker_Sort(int n, int a[])
{
	int i = 0, j, left, right, k;
	left = 0;
	right = n - 1;
	k = n - 1;
	while (left < right)
	{
		for (j = right; j > left; j--)
		{
			if (a[j] < a[j - 1])
			{
				Swap(a[j], a[j - 1]);
				k = j;
			}	
		}
		left = k;
		for (j = left; j < right; j++)
		{
			if (a[j] > a[j + 1])
			{
				Swap(a[j], a[j + 1]);
				k = j;
			}	
		}
		right = k;
	}
}
/*void BInsertion_Sort(int n, int a[])
{
	int l, r, m, i, x;
	for (i = 1; i < n; i++)
	{
		x = a[i]; l = 1; r = i - 1;
		while (i <= r)  // tìm vị trí chèn x
		{
			m = (l + r) / 2;  // tìm vị trí thích hợp m
			if (x < a[m]) r = m - 1;
			else  l = m + 1;
		}
		for (int j = i - 1; j >= l; j--)
			a[j + 1] = a[j];// dời các phần tử sẽ đứng sau x
		a[l] = x;    // chèn x vào dãy
	}
}*/
/*void Shell_Sort(int n, int a[])
{
	int *h, k;
	h = new int[n];
	int step, i, j, x, len;
	for (step = 0; step < k; step++)
	{
		len = h[step];
			for (i = len; i < n; i++)
			{
				x = a[i];
				j = i - len;
				while ((x < a[j]) && (j >= 0))
				{
					a[j + len] = a[j];
					j = j - len;
				}
				a[j + len] = x;
			}
	}
}*/

void TimeSort(int n, int a[])
{
	int ch;
	clock_t batdau, ketthuc;
	double thoigian;
	printf("Nhap lua chon: ");
	printf("\n1. BubbleSortTime!");
	printf("\n2. InsertionSortTime!");
	printf("\n3. ShakerSortTime!\n");
	scanf_s("%d", &ch);
	switch (ch)
	{
	case 1:
		batdau = clock();
		Bubble_Sort(n, a);
		ketthuc = clock();
		thoigian = double(ketthuc - batdau) / CLOCKS_PER_SEC;
		printf("Time BubbleSort: %0.3f giay", thoigian);
		break;
	case 2:
		batdau = clock();
		Insertion_Sort(n, a);
		ketthuc = clock();
		thoigian = double(ketthuc - batdau) / CLOCKS_PER_SEC;
		printf("Time InsertionSort: %0.3f giay", thoigian);
		break;
	case 3:
		batdau = clock();
		Shaker_Sort(n, a);
		ketthuc = clock();
		thoigian = double(ketthuc - batdau) / CLOCKS_PER_SEC;
		printf("Time ShakerSort: %0.3f giay", thoigian);
		break;
	}
}
