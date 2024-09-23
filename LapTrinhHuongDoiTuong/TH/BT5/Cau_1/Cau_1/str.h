#pragma once
class str
{
private:
	char s[100];
public:
	str(void);
	~str(void);
	void Nhap();
	char Xuat();
	int ChieuDai();
	void NoiChuoi(str s2);
	void DaoChuoi();
	void DoiCho(char &,char &);
};

