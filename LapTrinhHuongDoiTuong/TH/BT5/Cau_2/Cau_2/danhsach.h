#pragma once
#include "node.h"
class danhsach: public node
{
private:
	node* head;
	node* tail;
public:
	danhsach(void);
	~danhsach(void);
	void ThemDau(node *);
	void ThemCuoi(node *);
	void Nhap();
	void Xuat();
};

