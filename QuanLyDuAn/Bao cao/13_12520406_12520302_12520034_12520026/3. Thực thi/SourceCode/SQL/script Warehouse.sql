
Create database QLCHLKMT
USE QLCHLKMT

create table TINHTRANG 
(
	MaTinhTrang nvarchar(10) not null, 
	TenTinhTrang nvarchar(50) not null,
	primary key(MaTinhTrang)
)


create table NHAPHANPHOI 
(
	MaNhaPhanPhoi nvarchar(10) not null,
	TenNhaPhanPhoi nvarchar(50) not null, 
	DiaChi nvarchar(50) not null, 
	SoDienThoai nvarchar(20) not null, 
	Email nvarchar(50),
	MaSoThue nvarchar(50),
	TrangThai int not null,
	GhiChu nvarchar(100),
	primary key(MaNhaPhanPhoi),
	check(TrangThai >= 0 and TrangThai <= 1)
)

create table KHO 
(
	MaKho nvarchar(10) not null, 
	TenKho nvarchar(50) not null,
	TrangThai int not null, 
	GhiChu nvarchar(100), 
	primary key(MaKho),
	check(TrangThai >= 0 and TrangThai <= 1)
)

create table SANPHAM
(
	MaSanPham nvarchar(10) not null, 
	TenSanPham nvarchar(50) not null, 
	XuatXu nvarchar(50) not null, 
	NhaPhanPhoi nvarchar(10) not null,
	NgaySanXuat smalldatetime not null,
	NgayHetHan smalldatetime, 
	DonGiaNhap money not null, 
	DonGiaBan money not null, 
	DonViTinh nvarchar(10) not null, 
	TinhTrang nvarchar(10) not null, 
	Kho nvarchar(10) not null, 
	GhiChu nvarchar(100),
	primary key(MaSanPham),
	foreign key(NhaPhanPhoi) references NhaPhanPhoi(MaNhaPhanPhoi),
	foreign key(TinhTrang) references TinhTrang(MaTinhTrang),
	foreign key(Kho) references Kho(MaKho)
)

create table PHIEUXUATKHO
(
	MaPhieuXuatKho nvarchar(10) not null,
	NgayLapPhieu smalldatetime not null,	 
	MaNguoiYeuCau nvarchar(10) not null, 
	MaNguoiNhan nvarchar(10) not null, 
	MaNguoiLapPhieu nvarchar(10) not null, 
	GhiChu nvarchar(100),
	primary key(MaPhieuXuatKho)
	-- MaNguoiYeuCau, MaNguoiNhan, MaNguoiLapPhieu la khoa ngoai
)

create table PHIEUNHAPKHO
(
	MaPhieuNhapKho nvarchar(10) not null, 
	NgayLapPhieu smalldatetime not null, 
	MaNguoiNhan nvarchar(10) not null, 
	MaNguoiLapHieu nvarchar(10) not null, 
	GhiChu nvarchar(100),
	primary key(MaPhieuNhapKho)
	-- MaNguoiNhan, MaNguoiLapPhieu la khoa ngoai
)

create table PHIEUTRAHANG
(
	MaPhieuTraHang nvarchar(10) not null, 
	NgayLap smalldatetime not null,
	MaNhaPhanPhoi nvarchar(10) not null, 
	MaNguoiLapPhieu nvarchar(10) not null,
	primary key(MaPhieuTraHang)
	-- MaNhaPhanPhoi, MaNguoiLaPhieu la khoa ngoai
)

create table CHITIETPHIEUNHAPKHO
(
	MaChiTietPhieuNhapKho nvarchar(10) not null, 
	MaPhieuNhapKho nvarchar(10) not null, 
	MaSanPham nvarchar(10) not null, 
	SoLuong int not null, 
	GhiChu nvarchar(100),
	primary key(MaChiTietPhieuNhapKho),
	check(SoLuong > 0),
	foreign key(MaPhieuNhapKho) references PHIEUNHAPKHO(MaPhieuNhapKho),
	foreign key(MaSanPham) references SANPHAM(MaSanPham)
)

create table CHITIETPHIEUXUATKHO
(
	MaChiTietPhieuXuatKho nvarchar(10) not null, 
	MaPhieuXuatKho nvarchar(10) not null, 
	MaSanPham nvarchar(10) not null,
	SoLuong int not null, 
	GhiChu nvarchar(100),
	primary key(MaChiTietPhieuXuatKho),
	foreign key(MaPhieuXuatKho) references PHIEUXUATKHO(MaPhieuXuatKho),
	foreign key(MaSanPham) references SANPHAM(MaSanPham),
	check(SoLuong > 0)

)

create table ChiTietPhieuTraHang
(
	MaChiTietPhieuTraHang nvarchar(10) not null, 
	MaPhieuTraHang nvarchar(10) not null,
	MaSanPham nvarchar(10) not null, 
	SoLuong int not null, 
	GhiChu nvarchar(100),
	primary key(MaChiTietPhieuTraHang),
	foreign key(MaPhieuTraHang) references PHIEUTRAHANG(MaPhieuTraHang),
	foreign key(MaSanPham) references SANPHAM(MaSanPham),
	check(SoLuong > 0)
)