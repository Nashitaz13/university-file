Use master
Go
Drop Database QuanLyKhachSan2014
Go
Create Database QuanLyKhachSan2014
Go
Use QuanLyKhachSan2014
Go
--Tao Bang Loai Phong
Create Table LOAIPHONG
(
	MaLoaiPhong int identity(1,1) primary key,
	TenLoaiPhong nvarchar(50),
	DonGia float,
	SoKhachToiDa int
)
Go
--Tao Bang Phong
Create Table PHONG
(
	MaPhong int identity primary key,
	TenPhong nvarchar(50),
	MaLoaiPhong int foreign key references LOAIPHONG(MaLoaiPhong),
	GhiChu nvarchar(50),
	TinhTrang nvarchar(50)
)
Go
--Tao Bang Hoa Don
Create Table HOADON
(
	MaHoaDon int identity(1,1) primary key,
	TenKhachHang nvarchar(50),
	NgayLap smalldatetime,
	TriGia decimal(18,0)
)
Go
--Tao Bang Phieu Thue Phong
Create Table PHIEUTHUEPHONG
(
	MaPhieuThue int identity(1,1) primary key,
	NgayThue smalldatetime,
	SoLuong int,
	MaPhong int foreign key references PHONG(MaPhong)
)
Go
--Tao Bang Chi Tiet Hoa Don
Create Table CHITIETHOADON
(
	MaChiTietHoaDon int identity(1,1) primary key,
	MaHoaDon int foreign key references HOADON(MaHoaDon),
	SoNgayThue int,
	MaPhieuThue int foreign key references PHIEUTHUEPHONG(MaPhieuThue)
)

Go
--Tao Bang Loai Khach Hang
Create Table LOAIKHACHHANG
(
	MaLoaiKhachHang int identity(1,1) primary key,
	TenLoaiKhachHang nvarchar(50),
	TyLePhuThu float
)
Go
--Tao Bang Chi Tiet Phieu Thue Phong
Create Table CHITIETPHIEUTHUEPHONG
(
	MaChiTietPhieuThuePhong int identity(1,1) primary key,
	MaPhieuThue int foreign key references PHIEUTHUEPHONG(MaPhieuThue),
	TenKhachHang nvarchar(50),
	CMND varchar(20),
	DiaChi nvarchar(100),
	MaLoaiKhachHang int foreign key references LOAIKHACHHANG(MaLoaiKhachHang)
)
Go
--Tao Bang Bao Cao Doanh Thu
Create Table BAOCAODOANHTHU
(
	MaBaoCao int identity(1,1) primary key,
	TenBaoCao nvarchar(50),
	NgayLap smalldatetime,
	ThangBaoCao int
)
Go
--Tao Bang Chi Tiet Bao Cao Doanh Thu
Create Table CHITIETBAOCAODOANHTHU
(
	MaChiTietBaoCaoDoanhThu int identity(1,1) primary key,
	MaBaoCao int foreign key references BAOCAODOANHTHU(MaBaoCao),
	MaLoaiPhong int foreign key references LOAIPHONG(MaLoaiPhong),
	DoanhThu decimal(18,0),
	TyLe float
)
Go
--Tao Bang Nguoi Dung
Create Table NGUOIDUNG
(
	MaNguoiDung int identity(1,1) primary key,
	TenNguoiDung nvarchar(20),
	MatKhau nvarchar(30),
	LoaiNguoiDung nvarchar (20)
) 
Go
--Tao Bang Tham So
Create Table THAMSO
(
	MaThamSo int identity(1,1) primary key,
	TenThamSo nvarchar(50),
	GiaTri float
)

Go
--Stored Procedure SelectAll Phong
CREATE PROCEDURE Phong_SelectAll
AS
BEGIN
select MaPhong as STT,TenPhong,LOAIPHONG.TenLoaiPhong,DonGia as GiaPhong,GhiChu,TinhTrang from PHONG, LOAIPHONG where PHONG.MaLoaiPhong=LOAIPHONG.MaLoaiPhong
END
GO
--Stored Procedure Delete Phong
CREATE PROCEDURE Phong_DeleteById
@MaPhong int
AS
BEGIN
 delete from Phong where MaPhong = @MaPhong
END
GO

--Stored Procedure SelectAll ChiTietBaoCaoDoanhThu
CREATE PROCEDURE ChiTietBaoCaoDoanhThu_SelectAll
AS
BEGIN
 select * from CHITIETBAOCAODOANHTHU
END
GO

--Stored Procedure SelectAll PhieuThuePhong
CREATE PROCEDURE PhieuThuePhong_SelectAll
AS
BEGIN
 select * from PHIEUTHUEPHONG
END
GO

--Stored Procedure SelectAll ChiTietPhieuThuePhong
CREATE PROCEDURE ChiTietPhieuThuePhong_SelectAll
AS
BEGIN
 select * from CHITIETPHIEUTHUEPHONG
END
GO

--Stored Procedure SelectAll ChiTietHoaDon
CREATE PROCEDURE ChiTietHoaDon_SelectAll
AS
BEGIN
 select * from CHITIETHOADON
END
GO


--1.Lấy phòng còn trống (Tên phòng)
CREATE PROCEDURE Phong_SelectPhongEmpty
AS
BEGIN
	select * from PHONG where TinhTrang = N'Trống' 
END
GO

--2.Lấy phòng đã thuê (Tên phòng)
CREATE PROCEDURE Phong_SelectPhongNotEmpty
AS
BEGIN
	select TenPhong from PHONG where TinhTrang = N'Đã Thuê' 
END
GO

--3.Insert vào phiếu thuê phòng mới
CREATE PROCEDURE PhieuThuePhong_Insert
@MaPhieuThue int,
@NgayThue smalldatetime,
@SoLuong int,
@MaPhong int
AS
BEGIN
	insert into PHIEUTHUEPHONG (MaPhieuThue, NgayThue, SoLuong, MaPhong) values (@MaPhieuThue, @NgayThue, @SoLuong, @MaPhong)
END
GO


--5.Insert vào chi tiết phiếu thuê phòng mới
CREATE PROCEDURE ChiTietPhieuThuePhong_Insert
--@MaChiTietPhieuThuePhong int,
@MaPhieuThue int,
@TenKhachHang nvarchar(50),
@CMND varchar(20),
@DiaChi nvarchar(100),
@MaLoaiKhachHang int
AS
BEGIN
	insert into CHITIETPHIEUTHUEPHONG (MaPhieuThue,TenKhachHang,CMND,DiaChi,MaLoaiKhachHang)
	values (@MaPhieuThue,@TenKhachHang,@CMND,@DiaChi,@MaLoaiKhachHang)
END
GO

--6.Select loại khách hàng (tên loại khách hàng)
CREATE PROCEDURE LoaiKhachHang_SelectByName
AS
BEGIN
	select TenLoaiKhachHang from LOAIKHACHHANG
END
GO

--7. Select all loại phòng
CREATE PROCEDURE LoaiPhong_SelectAll
AS
BEGIN
	select * from LOAIPHONG
END
GO

--8.
--9. Xóa loại phòng
CREATE PROCEDURE LoaiPhong_Delete
@MaLoaiPhong int
AS
BEGIN
	delete from LOAIPHONG where MaLoaiPhong = @MaLoaiPhong
END
GO

--10. Select all loại khách hàng
CREATE PROCEDURE LoaiKhachHang_SelectAll
AS
BEGIN
	select * from LOAIKHACHHANG
END
GO

--11. Xóa loại khách hàng
CREATE PROCEDURE LoaiKhachHang_Delete
@MaLoaiKhachHang int
AS
BEGIN
	delete from LOAIKHACHHANG where MaLoaiKhachHang = @MaLoaiKhachHang
END
GO

--Select All Hoa Don
CREATE PROCEDURE HoaDon_SelectAll
AS
BEGIN
 select * from HOADON
END
GO

/*Insert chi tiet hoa don*/
CREATE PROCEDURE ChiTietHoaDon_Insert
@MaChiTietHoaDon int,
@MaHoaDon int,
@SoNgayThue int,
@MaPhieuThue int
AS
BEGIN
 insert into CHITIETHOADON (MaChiTietHoaDon,MaHoaDon,SoNgayThue,MaPhieuThue) values (@MaChiTietHoaDon,@MaHoaDon,@SoNgayThue,@MaPhieuThue)
END
GO

-- Select All Báo cáo doanh thu
CREATE PROCEDURE BaoCaoDoanhThu_SelectAll
AS
BEGIN
 select * from BAOCAODOANHTHU
END
GO

--Insert bao cao doanh thu
CREATE PROCEDURE BaoCaoDoanhThu_Insert
@MaBaoCao int,
@TenBaoCao nvarchar(50),
@NgayLap smalldatetime,
@ThangBaoCao int
AS
BEGIN
 insert into BAOCAODOANHTHU (MaBaoCao,TenBaoCao,NgayLap,ThangBaoCao) values (@MaBaoCao,@TenBaoCao,@NgayLap,@ThangBaoCao)
END
GO

--Insert Chi Tiet Bao Cao Doanh Thu
CREATE PROCEDURE ChiTietBaoCaoDoanhThu_Insert
@MaChiTietBaoCaoDoanhThu int,
@MaBaoCao int,
@MaLoaiPhong int,
@DoanhThu decimal(18,0),
@TyLe float
AS
BEGIN
 insert into CHITIETBAOCAODOANHTHU (MaChiTietBaoCaoDoanhThu,MaBaoCao,MaLoaiPhong,DoanhThu,TyLe) 
 values (@MaChiTietBaoCaoDoanhThu,@MaBaoCao, @MaLoaiPhong, @DoanhThu, @Tyle)
END
GO

--Select Chi Tiet Bao Cao Doanh Thu by MaBaoCao
CREATE PROCEDURE ChiTietBaoCaoDoanhThu_SelectByMaBaoCao
@MaBaoCao int
AS
BEGIN
 select * from CHITIETBAOCAODOANHTHU where MaBaoCao = @MaBaoCao
END
GO

--Select MaPhieuThue tu TenPhong va TenKhachHang
CREATE PROCEDURE PhieuThuePhong_SelectMaPhieuThue
@TenPhong nvarchar (50),
@TenKhachHang nvarchar (50)
AS
BEGIN
 declare @MaPhong int, @MaPhieuThue int
 select @MaPhong from PHONG where TenPhong = @TenPhong
 select @MaPhieuThue from CHITIETPHIEUTHUEPHONG where TenKhachHang = @TenKhachHang
 select MaPhieuThue from PHIEUTHUEPHONG where (MaPhong = @MaPhong and MaPhieuThue = @MaPhieuThue)
END
GO

--LoaiPhong_Update
CREATE PROCEDURE LoaiPhong_Update
@MaLoaiPhong int,
@TenLoaiPhong nvarchar(50),
@DonGia float,
@SoKhachToiDa int
AS
BEGIN
 declare @check int
 select @check = COUNT(*) from LOAIPHONG where (MaLoaiPhong = @MaLoaiPhong)
 if @check = 0
 begin
  insert into LOAIPHONG (MaLoaiPhong, TenLoaiPhong, DonGia, SoKhachToiDa) values (@MaLoaiPhong, @TenLoaiPhong, @DonGia, @SoKhachToiDa)
 end
  else
  begin 
   update LOAIPHONG
   set
    TenLoaiPhong = @TenLoaiPhong,
    DonGia = @DonGia,
    SoKhachToiDa = @SoKhachToiDa
   where (MaLoaiPhong = @MaLoaiPhong)
  end
END
GO

--NguoiDung_Update
CREATE PROCEDURE NguoiDung_Update
@MaNguoiDung int,
@MatKhau nvarchar(30)
AS
BEGIN
  update NGUOIDUNG set MatKhau = @MatKhau where (MaNguoiDung = @MaNguoiDung)
END
GO

--KhachHang SelectAll
CREATE PROCEDURE KhachHang_SelectAll
AS
BEGIN
	declare @NgayDi smalldatetime
	select CTPTP.TenKhachHang, CTPTP.CMND, CTPTP.DiaChi, LKH.TenLoaiKhachHang, P.TenPhong, (PTP.NgayThue) NgayDen, (PTP.NgayThue + CTHD.SoNgayThue) NgayDi
	from CHITIETPHIEUTHUEPHONG CTPTP, LOAIKHACHHANG LKH, PHIEUTHUEPHONG PTP, PHONG P, CHITIETHOADON CTHD
	where CTPTP.MaLoaiKhachHang = LKH.MaLoaiKhachHang and CTPTP.MaPhieuThue = PTP.MaPhieuThue and PTP.MaPhong = P.MaPhong and PTP.MaPhieuThue = CTHD.MaPhieuThue
END
GO

CREATE PROCEDURE NguoiDung_SelectAll
AS
BEGIN
select MaNguoiDung,TenNguoiDung,MatKhau,LoaiNguoiDung from NGUOIDUNG
END
GO

CREATE PROCEDURE NguoiDung_SelectById
@MaNguoiDung_ int
AS
BEGIN
	select * from NGUOIDUNG where MaNguoiDung = @MaNguoiDung_
END
GO

CREATE PROCEDURE NguoiDung_SelectByName
@TenNguoiDung nvarchar(20)
AS
BEGIN
	select * from NGUOIDUNG where TenNguoiDung = @TenNguoiDung
END
GO


CREATE PROCEDURE Phong_Update
@MaPhong int,
@TenPhong nvarchar(50),
@MaLoaiPhong int,
@GhiChu nvarchar(50),
@TinhTrang nvarchar(50)
AS
BEGIN
	update PHONG
	set 
		TenPhong = 'B101',
		MaLoaiPhong = '2',
		GhiChu = '',
		TinhTrang = N'Trống'
	where MaPhong = 4
END
GO
select * from PHONG

CREATE PROCEDURE LoaiPhong_Insert
@TenLoaiPhong nvarchar(50),
@DonGia float,
@SoKhachToiDa int
AS
BEGIN
	insert into LOAIPHONG (TenLoaiPhong, DonGia, SoKhachToiDa) values (@TenLoaiPhong, @DonGia, @SoKhachToiDa)
END
GO

CREATE PROCEDURE LoaiKhachHang_Insert
@TenLoaiKhachHang nvarchar(50),
@TyLePhuThu int
AS
BEGIN
	insert into LOAIKHACHHANG (TenLoaiKhachHang,TyLePhuThu) values (@TenLoaiKhachHang,@TyLePhuThu)
END
GO

CREATE PROCEDURE Phong_SelectByTenPhong
@TenPhong nvarchar(50)
AS
BEGIN
	select * from PHONG where TenPhong = @TenPhong
END
GO

CREATE PROCEDURE Phong_Insert
@TenPhong nvarchar(50),
@MaLoaiPhong int,
@GhiChu nvarchar(50),
@TinhTrang nvarchar(50)
AS
BEGIN
 insert into PHONG (TenPhong,MaLoaiPhong,GhiChu,TinhTrang) values (@TenPhong,@MaLoaiPhong,@GhiChu,@TinhTrang)
END
GO

--
CREATE PROCEDURE LoaiPhong_SelectByMaLoaiPhong
@MaLoaiPhong int
AS
BEGIN
	select * from LoaiPhong where MaLoaiPhong = @MaLoaiPhong
END
GO


CREATE PROCEDURE Phong_SelectByRentTime
@NgayThueDau smalldatetime,
@NgayThueCuoi smalldatetime
AS
BEGIN
select P.MaPhong, P.TenPhong, LOAIPHONG.TenLoaiPhong, P.TinhTrang, LOAIPHONG.DonGia
 from LOAIPHONG,
 (select * from PHONG where MaPhong in 
 (select MaPhong
 from PHIEUTHUEPHONG
  where ((NgayThue >= @NgayThueDau ) and (NgayThue <= @NgayThueCuoi)))) P
where LOAIPHONG.MaLoaiPhong = P.MaLoaiPhong
END
GO

CREATE PROCEDURE Phong_SelectByTenLoaiPhong
@TenLoaiPhong nvarchar(50)
AS
BEGIN
	select P.MaPhong, P.TenPhong, LP.TenLoaiPhong, LP.DonGia, P.GhiChu, P.TinhTrang
	from PHONG P,LOAIPHONG LP
	where LP.TenLoaiPhong = @TenLoaiPhong and P.MaLoaiPhong = LP.MaLoaiPhong
END
GO

CREATE PROCEDURE PhieuThuePhong_SelectByMaxMaPhieuThue
@MaPhong int
AS
BEGIN
	select * from PHIEUTHUEPHONG where (MaPhieuThue = (select max (MaPhieuThue) from PHIEUTHUEPHONG)) and MaPhong = @MaPhong
END
GO

CREATE PROCEDURE ChiTietPhieuThuePhong_SelectByMaPhieuThue
@MaPhieuThue int
AS
BEGIN
	select * from CHITIETPHIEUTHUEPHONG where MaPhieuThue = @MaPhieuThue
END
GO

insert into LOAIPHONG (TenLoaiPhong,DonGia,SoKhachToiDa)
values ('A',150000,2)
Insert Into LOAIPHONG (TenLoaiPhong,DonGia,SoKhachToiDa)
Values ('B',170000,3)
Insert Into LOAIPHONG (TenLoaiPhong,DonGia,SoKhachToiDa)
Values ('C',200000,3)
Insert Into LOAIPHONG (TenLoaiPhong,DonGia,SoKhachToiDa)
Values ('VIP',500000,2)
Go

Insert Into PHONG (TenPhong,MaLoaiPhong,GhiChu,TinhTrang)
Values ('A101',1,' ',N'Trống')
Insert Into PHONG (TenPhong,MaLoaiPhong,GhiChu,TinhTrang)
Values ('A102',2,' ',N'Trống')
Insert Into PHONG (TenPhong,MaLoaiPhong,GhiChu,TinhTrang)
Values ('A103',3,' ',N'Đầy')
Insert Into PHONG (TenPhong,MaLoaiPhong,GhiChu,TinhTrang)
Values ('A103',2,' ',N'Đầy')
Go

Insert Into NGUOIDUNG (TenNguoiDung,MatKhau,LoaiNguoiDung)
Values ('Admin','123456','Administrator')
Insert Into NGUOIDUNG (TenNguoiDung,MatKhau,LoaiNguoiDung)
Values (N'Trần Trung','11111',N'Quản lý 1')
Insert Into NGUOIDUNG (TenNguoiDung,MatKhau,LoaiNguoiDung)
Values (N'Minh Vương','098765',N'Quản lý 2')
Go

Insert Into PHIEUTHUEPHONG (NgayThue,SoLuong,MaPhong)
Values ('01/08/2015',1,1)
Insert Into PHIEUTHUEPHONG (NgayThue,SoLuong,MaPhong)
Values ('12/31/2014',1,2)
Insert Into PHIEUTHUEPHONG (NgayThue,SoLuong,MaPhong)
Values ('12/11/2014',2,1)
Go

Insert Into LOAIKHACHHANG (TenLoaiKhachHang,TyLePhuThu)
Values (N'Nội Địa',0)
Insert Into LOAIKHACHHANG (TenLoaiKhachHang,TyLePhuThu)
Values (N'Nước Ngoài',1.5)
Go

Insert Into CHITIETPHIEUTHUEPHONG (MaPhieuThue,TenKhachHang,CMND,DiaChi,MaLoaiKhachHang)
Values (1,N'Sơn Tùng','123456789','Q1',1)
Insert Into CHITIETPHIEUTHUEPHONG (MaPhieuThue,TenKhachHang,CMND,DiaChi,MaLoaiKhachHang)
Values (3,N'Khởi My','987654321','Q3',2)
Insert Into CHITIETPHIEUTHUEPHONG (MaPhieuThue,TenKhachHang,CMND,DiaChi,MaLoaiKhachHang)
Values (2,N'Hà Hồ','111111111','Q5',1)
Go

Insert Into HOADON (TenKhachHang,NgayLap,TriGia)
Values (N'Sơn Tùng','01/01/2015',200000)
Insert Into HOADON (TenKhachHang,NgayLap,TriGia)
Values (N'Minh Hằng','01/05/2015',500000)
Insert Into HOADON (TenKhachHang,NgayLap,TriGia)
Values (N'Quang Lê','01/03/2015',200000)
Go

Insert Into CHITIETHOADON (MaHoaDon,SoNgayThue,MaPhieuThue)
Values (2,1,1)
Insert Into CHITIETHOADON (MaHoaDon,SoNgayThue,MaPhieuThue)
Values (2,3,2)
Insert Into CHITIETHOADON (MaHoaDon,SoNgayThue,MaPhieuThue)
Values (2,4,3)
Go

Insert Into BAOCAODOANHTHU (TenBaoCao,NgayLap,ThangBaoCao)
Values (N'Báo Cáo 1','01/08/2015',1)
Insert Into BAOCAODOANHTHU (TenBaoCao,NgayLap,ThangBaoCao)
Values (N'Báo Cáo 2','12/08/2014',12)
Insert Into BAOCAODOANHTHU (TenBaoCao,NgayLap,ThangBaoCao)
Values (N'Báo Cáo 3','11/08/2014',11)
Go

Insert Into CHITIETBAOCAODOANHTHU (MaBaoCao,MaLoaiPhong,DoanhThu,TyLe)
Values (1,1,1000000,0.25)
Insert Into CHITIETBAOCAODOANHTHU (MaBaoCao,MaLoaiPhong,DoanhThu,TyLe)
Values (2,3,750000,0.4)
Insert Into CHITIETBAOCAODOANHTHU (MaBaoCao,MaLoaiPhong,DoanhThu,TyLe)
Values (3,4,1200000,0.5)
Go

Insert into THAMSO(TenThamSo,GiaTri)
values (N'Số khách tối đa mỗi phòng', 3)
Insert into THAMSO(TenThamSo,GiaTri)
values (N'Đơn giá phòng cho 2 khách', 2)
Insert into THAMSO(TenThamSo,GiaTri)
values (N'Phụ thu khách thứ 3', 0.25)

