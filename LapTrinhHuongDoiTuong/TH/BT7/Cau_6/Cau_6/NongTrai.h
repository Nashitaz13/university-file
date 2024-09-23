#pragma once
#include "Bo.h"
#include "Cuu.h"
#include "De.h"
class NongTrai:public De,Bo,Cuu
{
public:
	NongTrai(void);
	~NongTrai(void);
	void Nhap();
	void Xuat();
};

