#pragma once
#include "BasicObject.h"


// ax + by + c = 0;
struct PhuongTrinhDuongThang {
	float a;
	float b;
	float c;
	int ToaDoYCao;
	int ToaDoYThap;
	float TinhY (float x){
		return (-c - a * x) / b;
	}
};

struct Diem {
	float x; 
	float y;

	Diem()
	{
		x = 0;
		y = 0;
	}

	Diem(float _x, float _y)
	{
		x = _x; 
		y = _y;
	}
};

class CBoxStair:public BasicObject
{
private:
	void KhoiTaoPhuongTrinhDuongThang(bool);
public:
	PhuongTrinhDuongThang d;
	CBoxStair(float, float, float, float, bool);
	bool UpLeft;
	~CBoxStair();
};

