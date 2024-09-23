//Hình vuông và hình chữ nhật có quan hệ "IS-A". Khai báo lớp:
class HinhChuNhat{};
class HinhVuong:public HinhChuNhat{};

//Đa giác và điểm có quan hệ "HAS-A". Khai báo lớp:
class Diem{};
class DaGiac
{
private:
	Diem *m_Diem;
}

//Giám đốc và nhân viên có quan hệ "IS-A"
class NhanVien{};
class GiamDoc:public NhanVien{};

//Hình ellipse và hình tròn có quan hệ "IS-A"
class Ellipse{};
class HinhTron:public Ellipse{};

//Máy bay và động có máy bay có quan hệ "HAS-A"
class DongCo{};
class MayBay
{
private:
	DongCo *m_DongCo;
}

//Câu và từ có quan hệ "HAS-A"
class Tu{};
class Cau
{
private:
	Tu *m_Tu;
}

//Hàng hóa và mỹ phẩm có quan hệ "IS-A"
class HangHoa{};
class MyPham:public HangHoa{};

//Cây trồng và cây lúa có quan hệ "IS-A"
class CayTrong{};
class CayLua:public CayTrong{};

//Thư viện và sách có quan hệ "HAS-A"
class Sach{};
class ThuVien
{
private:
	Sach *m_Sach;
}

//Phim ảnh và phim hoạt hình có quan hệ "IS-A"
class PhimAnh{};
class PhimHoatHinh:public PhimAnh{};
