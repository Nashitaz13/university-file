Create Database QuanLyKhachSan
Go
Use QuanLyKhachSan
Go
--Tao Bang Loai Phong
Create Table LOAIPHONG
(
	MaLoaiPhong nchar(10) primary key,
	TenLoaiPhong nvarchar(50),
	DonGia float,
	SoKhachToiDa int
)

--Tao Bang Phong
Create Table PHONG
(
	MaPhong nchar(10) primary key,
	TenPhong nvarchar(50),
	MaLoaiPhong nchar(10) foreign key references LOAIPHONG(MaLoaiPhong),
	GhiChu nvarchar(50),
	TinhTrang nvarchar(50)
)

--Tao Bang Hoa Don
Create Table HOADON
(
	MaHoaDon nchar(10) primary key,
	TenKhachHang nvarchar(50),
	NgayLap smalldatetime,
	TriGia decimal(18,0)
)

--Tao Bang Phieu Thue Phong
Create Table PHIEUTHUEPHONG
(
	MaPhieuThue nchar(10) primary key,
	NgayThue smalldatetime,
	SoLuong int,
	MaPhong nchar(10) foreign key references PHONG(MaPhong)
)

--Tao Bang Chi Tiet Hoa Don
Create Table CHITIETHOADON
(
	MaChiTietHoaDon nchar(10) primary key,
	MaHoaDon nchar(10) foreign key references HOADON(MaHoaDon),
	SoNgayThue int,
	MaPhieuThue nchar(10) foreign key references PHIEUTHUEPHONG(MaPhieuThue)
)

--Tao Bang Loai Khach Hang
Create Table LOAIKHACHHANG
(
	MaLoaiKhachHang nchar(10) primary key,
	TenLoaiKhachHang nvarchar(50)
)

--Tao Bang Chi Tiet Phieu Thue Phong
Create Table CHITIETPHIEUTHUEPHONG
(
	MaChiTietPhieuThuePhong nchar(10) primary key,
	MaPhieuThue nchar(10) foreign key references PHIEUTHUEPHONG(MaPhieuThue),
	TenKhachHang nvarchar(50),
	CMND varchar(20),
	DiaChi nvarchar(100),
	MaLoaiKhachHang nchar(10) foreign key references LOAIKHACHHANG(MaLoaiKhachHang)
)

--Tao Bang Bao Cao Doanh Thu
Create Table BAOCAODOANHTHU
(
	MaBaoCao nchar(10) primary key,
	TenBaoCao nvarchar(50),
	NgayLap smalldatetime,
	ThangBaoCao int
)

--Tao Bang Chi Tiet Bao Cao Doanh Thu
Create Table CHITIETBAOCAODOANHTHU
(
	MaChiTietBaoCaoDoanhThu nchar(10) primary key,
	MaBaoCao nchar(10) foreign key references BAOCAODOANHTHU(MaBaoCao),
	MaLoaiPhong nchar(10) foreign key references LOAIPHONG(MaLoaiPhong),
	DoanhThu decimal(18,0),
	TyLe float
)

--Tao Bang Tham So
Create Table THAMSO
(
	MaThamSo nchar(10) primary key,
	TenThamSo nvarchar(50),
	GiaTri float
)

--Hiển thị phòng
CREATE PROCEDURE Phong_SelectAll
AS
BEGIN
	--select * from PHONG 
	select distinct * from PHONG, LOAIPHONG where PHONG.MaLoaiPhong=LOAIPHONG.MaLoaiPhong
END
GO

CREATE PROCEDURE ChiTietBaoCaoDoanhThu_SelectAll
AS
BEGIN
	select * from CHITIETBAOCAODOANHTHU
END
GO

CREATE PROCEDURE PhieuThuePhong_SelectAll
AS
BEGIN
	select * from PHIEUTHUEPHONG
END
GO

CREATE PROCEDURE ChiTietPhieuThuePhong_SelectAll
AS
BEGIN
	select * from CHITIETPHIEUTHUEPHONG
END
GO

CREATE PROCEDURE ChiTietHoaDon_SelectAll
AS
BEGIN
	select * from CHITIETHOADON
END
GO

-- Xóa phòng bằng Mã phòng
CREATE PROCEDURE Phong_DeleteById
@MaPhong nchar(10)
AS
BEGIN
	delete from PHONG where MaPhong = @MaPhong
END
GO

--Tìm phòng theo Tên loại phòng
CREATE PROCEDURE Phong_SelectByTenLoaiPhong
@TenLoaiPhong nvarchar(50)
AS
BEGIN
	select * from PHONG where MaLoaiPhong in (select MaLoaiPhong from LOAIPHONG where LOAIPHONG.TenLoaiPhong = @TenLoaiPhong)
GO

--Tìm phòng theo Thời gian thuê
CREATE PROCEDURE Phong_SelectByRentTime
@NgayThueDau smalldatetime,
@NgayThueCuoi smalldatetime
AS
BEGIN
	select * from PHONG where MaPhong in (select MaPhong from PHIEUTHUEPHONG where ((NgayThue >= @NgayThueDau ) and (NgayThue <= @NgayThueCuoi)))
END
GO

------------------------
select * from PHONG
select * from LOAIPHONG
select * from PHIEUTHUEPHONG

select NgayThue from PHIEUTHUEPHONG where MaPhieuThue = 1
select * from PHONG where MaPhong in (select MaPhong from PHIEUTHUEPHONG where ((NgayThue >= '1/1/2000' ) and (NgayThue <= '1/1/2001')))

select * from PHONG
where MaLoaiPhong in
(select MaLoaiPhong from LOAIPHONG where TenLoaiPhong = 'C')

-- Select All Báo cáo doanh thu
CREATE PROCEDURE BaoCaoDoanhThu_SelectAll
AS
BEGIN
	select * from BAOCAODOANHTHU
END
GO

--Select Chi Tiet Bao Cao Doanh Thu by MaBaoCao
CREATE PROCEDURE ChiTietBaoCaoDoanhThu_SelectByMaBaoCao
@MaBaoCao nchar(10)
AS
BEGIN
	select * from CHITIETBAOCAODOANHTHU where MaBaoCao = @MaBaoCao
END
GO

--Insert Chi Tiet Bao Cao Doanh Thu
CREATE PROCEDURE ChiTietBaoCaoDoanhThu_Insert
@MaChiTietBaoCaoDoanhThu nchar(10),
@MaBaoCao nchar(10),
@MaLoaiPhong nchar(10),
@DoanhThu decimal(18,0),
@TyLe float
AS
BEGIN
	insert into CHITIETBAOCAODOANHTHU (MaChiTietBaoCaoDoanhThu,MaBaoCao,MaLoaiPhong,DoanhThu,TyLe) 
	values (@MaChiTietBaoCaoDoanhThu,@MaBaoCao, @MaLoaiPhong, @DoanhThu, @Tyle)
END
GO

