/*
Ho Ten : Nguyen Van Canh
MSSV : 12520034
Lop : IT002.E13
BAI TAP THUC HANH TUAN 1
4.	Viết chương trình nhập vào một ngày. Tìm ngày kế tiếp và xuất kết quả.
*/
#include <iostream>
using namespace std;

typedef struct Date_Time
{
	unsigned iDay;
	unsigned iMonth;
	unsigned iYear;
};
typedef struct Date_Time DATE;

void Input_date(DATE &x);
void Print_date(DATE x);
int Test_date(DATE x);
void Next_date(DATE x);
int Test_leap_year(DATE x);
int main()
{
	DATE x;
	Input_date (x);
	Print_date (x);
	Next_date(x);
	return 0;
}

//nhap ngay thang nam
void Input_date(DATE &x)
{
	cout<<"Nhap ngay : "<<endl;
	cin>>x.iDay;
	cout<<"Nhap thang : "<<endl;
	cin>>x.iMonth;
	cout<<"Nhap nam : "<<endl;
	cin>>x.iYear;
}

// in ngay thang nam
void Print_date(DATE x)
{
	cout<<"Date Time :";
	cout<<x.iDay<<"/"<<x.iMonth<<"/"<<x.iYear<<endl;
}

//Kiem tra nam nhuan
int Test_leap_year(DATE x)
{
	if(x.iYear % 4 == 0 && x.iYear % 100 != 0)
		return 1;
	if(x.iYear % 400 == 0)
		return 1;
	return 0;
}

//kiem tra ngay nhap vao hop le ko
int Test_date(DATE x)
{
	int kq = 1;
	if(x.iDay >=1 && x.iDay <= 31 &&
		x.iMonth >= 1 && x.iMonth <= 12 && x.iYear > 0)
	{
		if(x.iMonth == 1 || x.iMonth == 3 || x.iMonth == 5
			|| x.iMonth == 7 || x.iMonth == 8 ||x.iMonth == 10)
		{
			if(x.iDay <= 31)
				kq = 1;
			else
				kq = 0;
		}

		if(x.iMonth == 4 || x.iMonth == 6 || x.iMonth == 9 || x.iMonth == 11)
		{
			if(x.iDay <= 30)
				kq = 1;
			else
				kq = 0;
		}

		if(x.iMonth == 2 && Test_leap_year(x) == 1)
		{
			if(x.iDay <= 29)
				kq = 1;
			else
				kq = 0;
		}

		if(x.iMonth == 2 && Test_leap_year(x) == 0)
		{
			if(x.iDay <= 28)
				kq = 1;
			else
				kq = 0;
		}
	}
	else
		kq = 0;
	return kq;
}

//tim ngay ke tiep
void Next_date(DATE x)
{
	int kq = Test_date(x);
	if(kq == 0)
	{
		cout<<"Not Date Time !!!  "<<x.iDay<<"/"<<x.iMonth<<"/"<<x.iYear;
		exit(1);
		cout<<"NHAP LAI!";
	}
	else
	{
		if(x.iDay == 31 || (x.iDay == 30 && (x.iMonth == 4 || x.iMonth == 6 || x.iMonth == 9 || x.iMonth == 11))
			|| (x.iDay == 29 && x.iMonth == 2) ||(x.iDay == 28 && x.iMonth == 2 && Test_leap_year(x) == 0))
		{
			x.iDay = 1;
			x.iMonth ++;
			if(x.iMonth > 12)
			{
				x.iMonth = 1;
				x.iYear ++;
			}
		}
		else
		{
			x.iDay = x.iDay + 1;
		}
	}
	cout<<"Next Date Time:"<<endl;
	cout<<x.iDay<<"/"<<x.iMonth<<"/"<<x.iYear<<endl;
}