//-----------------------------------------------------------------------------
// File: CCollision.h
//
// Desc: Định nghĩa lớp CCollision hỗ trợ kiểm tra va chạm các đối tượng
//
//-----------------------------------------------------------------------------
#ifndef _CCOLLIION_H_
#define _CCOLLISION_H_

#include <math.h>
#include <limits>
#include "CGlobal.h"

//-----------------------------------------------------------------------------
// Cấu trúc CBox hỗ trợ việc tổng quát hóa các đối tượng đang cần xét va chạm
//
//-----------------------------------------------------------------------------
struct CBox
{
	float _vx, _vy;	// Vận tốc chuyển động các vật thể
	float _x, _y;	// Tọa độ các đối tượng trong hệ quy chiếu
	float _width, _height;	// Kích thước của vật thể

	CBox();

	//-----------------------------------------------------------------------------
	// x: vị trí x của box
	// y: vị trí y của box
	// width: kích thước ngang của box
	// height: kích thước dọc của box
	// vx: vận tốc chiều x của box
	// vy: vận tốc chiều y của box
	//-----------------------------------------------------------------------------
	CBox(float x, float y, float width, float height, float vx, float vy);

	//-----------------------------------------------------------------------------
	// Tạo box từ một rectangle, lúc này, vận tốc là 0
	//-----------------------------------------------------------------------------
	CBox(Rect rectangle);

	bool IntersecWith(CBox box, bool acceptDiffirent=false);
};

//-----------------------------------------------------------------------------
// Hướng va chạm của khối hộp
//-----------------------------------------------------------------------------
enum CDirection
{
	// Hướng lên
	ON_UP		= 101,
	// Hướng xuống
	ON_DOWN		= 102,
	// Hướng bên phải
	ON_RIGHT	= 103,
	// Hướng bên trái
	ON_LEFT		= 104,
	NONE_DIRECT	= 105,
	// Hai vật nằm lồng trong nhau
	INSIDE		= 106
};

//-----------------------------------------------------------------------------
// Hỗ trợ việc xét va chạm các đối tượng theo giải thuật SweepAABB
//
//-----------------------------------------------------------------------------
class CCollision{
public:
	//-----------------------------------------------------------------------------
	// Phương thức tạo swept box - là khối bao tổng thể theo vận tốc di chuyển đối tượng
	//
	// + frameTime: Khoảng thời gian chuyển khung hình
	//-----------------------------------------------------------------------------
	static CBox GetSweptBox(CBox box, float frameTime);

	//-----------------------------------------------------------------------------
	// Hàm hỗ trợ kiểm tra đơn giản xem box1 có va chạm với box hay không
	// bao khác hay không.
	//
	// + anotherBox: Khung bao được dùng để kiểm tra

	// return: Trả về true nếu va chạm, false nếu không va chạm
	//-----------------------------------------------------------------------------
	static bool AABBCheck(CBox box1, CBox box2);

	//-----------------------------------------------------------------------------
	// Kiểm tra xem box1 có va chạm với box2 theo hướng nào trong 1 khoảng thời gian chuyển khung hình nhất định
	//
	// + box1: Khung bao đối tượng di chuyển 1
	// + box2: Khung bao đối tượng đứng yên 2
	// + normalX: Hướng va chạm theo chiều x
	// + normalY: Hướng va chạm theo chiều y
	// + frameTime: Khoảng thời gian chuyển khung hình
	//
	// return: Thời gian bắt đầu va chạm theo trục x hoặc y
	//-----------------------------------------------------------------------------
	static float SweepAABB(CBox box1, CBox box2, CDirection &normalX, CDirection &normalY, float frameTime);

private:
	CCollision();
	~CCollision();
};

#endif //!_CCOLLISION_H