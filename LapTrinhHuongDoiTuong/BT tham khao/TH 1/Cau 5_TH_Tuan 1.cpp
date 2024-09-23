/*
Ho Ten : Nguyen Van Canh
MSSV : 12520034
Lop : IT002.E13
BAI TAP THUC HANH TUAN 1
5.	Viết chương trình nhập họ tên, điểm toán, điểm văn của một học sinh. Tính điểm trung bình và xuất kết quả.
*/

#include <stdio.h>
#include <stdlib.h>
#include <iostream>
using namespace std;

typedef struct Student
{
	char cName[35];
	float fToan;
	float fVan;
	float fDTB;
};
typedef struct Student SINHVIEN;

void Input_sv(SINHVIEN &x);
void Print_sv(SINHVIEN x);
void Trim_string(char s[]);
void Trim_head_tail(char s[]);
void Process_sequence(char str[]);

int main()
{
	SINHVIEN x;
	Input_sv (x);
	Print_sv (x);
	return 0;
}

void Input_sv(SINHVIEN &x)
{
	cout<<"Moi Nhap Ho Ten sinh vien : "<<endl;
	cin.ignore();
	cin.getline(x.cName,35);
	cout<<"Moi Nhap Diem Toan : ";
	cin>>x.fToan;
	cout<<"Moi Nhap Diem Van : ";
	cin>>x.fVan;
	x.fDTB = (float)((x.fVan + x.fToan)/2);
}

//in sinh vien
void Print_sv (SINHVIEN x)
{
	cout<<"\nTHONG TIN SINH VIEN "<<endl;
	cout<<"Ho Ten :";
	Trim_string(x.cName);
	Process_sequence(x.cName);
	cout<<"Diem Toan :"<<x.fToan<<endl;
	cout<<"Diem Van :"<<x.fVan<<endl;
	cout<<"Diem trung binh la :"<<x.fDTB<<endl;
}

//xoa khoang trang
void Trim_string(char s[])
{
	int n = strlen(s);
	//xoa trang dau
	if(s[0] = ' ')
		for(int i = 0;i < n; i++)
		{
			s[i] = s[i+1];
		} 

	// xoa trang cuoi
	if(s[n-1] == ' ')
		s[n-1] = s[n];

	// xoa khoang trang o giua
	for(int i = 0;i < n; i++)
	{
		if(s[i] == ' ' && s[i+1] == ' ')
		{
			for(int j = i; j < n; j++)
				s[j] = s[j + 1];
			n--;
			i--;
		}
	}
}

//doi ki tu dau moi tu thanh chu hoa
void Process_sequence(char str[])
{
	int i;
	for(i=0;i<=strlen(str)-1;i++)
		if(str[i-1]==' ' || i==0)
			str[i]=toupper(str[i]); // ->chu in hoa
		else 
		str[i]=tolower(str[i]); //-> chu in thuong
	cout<<str<<endl;
}
