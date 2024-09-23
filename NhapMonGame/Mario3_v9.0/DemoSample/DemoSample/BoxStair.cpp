#include "BoxStair.h"



void CBoxStair::KhoiTaoPhuongTrinhDuongThang(bool _UpLeft)
{
	Diem A, B;
	UpLeft = _UpLeft;
	if (_UpLeft)
	{
		A = Diem(currBox->x, currBox->y - currBox->height);	// A(x, y - height)
		B = Diem(currBox->x + currBox->width, currBox->y);		// B(x + width, y)
	}
	else
	{
		A = Diem(currBox->x, currBox->y);	// A(x, y - height)
		B = Diem(currBox->x + currBox->width, currBox->y - currBox->height);		// B(x + width, y)
	}

	Diem VectorChinhPhuong = Diem(B.x - A.x, B.y - A.y);		// VTCP(Xb - Xa, Yb - Ya)
	Diem VectorPhapTuyen = Diem(VectorChinhPhuong.y, -VectorChinhPhuong.x);

	d.ToaDoYCao = A.y > B.y ? A.y : B.y;
	d.ToaDoYThap = A.y < B.y ? A.y : B.y;
	d.a = VectorPhapTuyen.x;
	d.b = VectorPhapTuyen.y;
	d.c = (VectorPhapTuyen.x * -A.x) + (VectorPhapTuyen.y * -A.y);

}


CBoxStair::CBoxStair(float x, float y, float width, float height, bool _UpLeft)
{
	type = Type::ot_boxstair;
	this->currBox->SetBox(x, y, width, height);
	*preBox = *currBox;
	KhoiTaoPhuongTrinhDuongThang(_UpLeft);
}


CBoxStair::~CBoxStair()
{
}

