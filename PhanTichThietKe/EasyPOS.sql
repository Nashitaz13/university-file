set dateformat dmy

delete from DONVI
delete from LOAIHANGHOA
delete from HANGHOA
delete from NHACUNGCAP
delete from KHACHHANG
delete from NGUOIDUNG
delete from DONDATHANG
delete from CTDONDATHANG
delete from PHIEUXUAT
delete from CTPHIEUXUAT
delete from PHIEUNHAP
delete from CTPHIEUNHAP
delete from CONGNO
delete from LICHSUGIAODICH

--Reset mã tự tăng
DBCC CHECKIDENT (DONVI, RESEED, 0)
DBCC CHECKIDENT (LOAIHANGHOA, RESEED, 0)
DBCC CHECKIDENT (HANGHOA, RESEED, 0)
DBCC CHECKIDENT (NHACUNGCAP, RESEED, 0)
DBCC CHECKIDENT (KHACHHANG, RESEED, 0)
DBCC CHECKIDENT (NGUOIDUNG, RESEED, 0)
DBCC CHECKIDENT (DONDATHANG, RESEED, 0)
DBCC CHECKIDENT (CTDONDATHANG, RESEED, 0)
DBCC CHECKIDENT (PHIEUXUAT, RESEED, 0)
DBCC CHECKIDENT (CTPHIEUXUAT, RESEED, 0)
DBCC CHECKIDENT (PHIEUNHAP, RESEED, 0)
DBCC CHECKIDENT (CTPHIEUNHAP, RESEED, 0)
DBCC CHECKIDENT (CONGNO, RESEED, 0)
DBCC CHECKIDENT (LICHSUGIAODICH, RESEED, 0)


insert into DONVI (TenDonVi) values (N'Lon')
insert into DONVI (TenDonVi) values (N'Hộp')
insert into DONVI (TenDonVi) values (N'Chai')
insert into DONVI (TenDonVi) values (N'Gói')
insert into DONVI (TenDonVi) values (N'Bao')
insert into DONVI (TenDonVi) values (N'Cái')

insert into LOAIHANGHOA (TenLoaiHangHoa) values (N'Loại 1')
insert into LOAIHANGHOA (TenLoaiHangHoa) values (N'Loại 2')
insert into LOAIHANGHOA (TenLoaiHangHoa) values (N'Loại 3')
insert into LOAIHANGHOA (TenLoaiHangHoa) values (N'Loại 4')

insert into HANGHOA (TenHangHoa, MaDonVi, MaLoaiHangHoa, SoLuongTon, DonGiaNhap, DonGiaBanLe, DonGiaBanSi, MucBanSi)
values (N'Bia Sài Gòn', 1, 1, 100, 7000, 10000, 9000, 24)
insert into HANGHOA (TenHangHoa, MaDonVi, MaLoaiHangHoa, SoLuongTon, DonGiaNhap, DonGiaBanLe, DonGiaBanSi, MucBanSi)
values (N'CocaCola', 3, 3, 100, 6000, 8000, 7000, 20)
insert into HANGHOA (TenHangHoa, MaDonVi, MaLoaiHangHoa, SoLuongTon, DonGiaNhap, DonGiaBanLe, DonGiaBanSi, MucBanSi)
values (N'Nước rửa chén', 3, 2, 100, 15000, 16000, 17000, 20)
insert into HANGHOA (TenHangHoa, MaDonVi, MaLoaiHangHoa, SoLuongTon, DonGiaNhap, DonGiaBanLe, DonGiaBanSi, MucBanSi)
values (N'Oishi', 4, 4, 100, 4000, 6000, 5000, 10)
insert into HANGHOA (TenHangHoa, MaDonVi, MaLoaiHangHoa, SoLuongTon, DonGiaNhap, DonGiaBanLe, DonGiaBanSi, MucBanSi)
values (N'Thuốc Lá', 4, 3, 100, 18000, 20000, 19000, 20)
insert into HANGHOA (TenHangHoa, MaDonVi, MaLoaiHangHoa, SoLuongTon, DonGiaNhap, DonGiaBanLe, DonGiaBanSi, MucBanSi)
values (N'Sữa', 1, 1, 100, 20000, 25000, 24000, 20)

insert into NHACUNGCAP (TenNhaCungCap, DiaChi, SDT) values (N'Vinamilk', N'Bình Dương', 0123111111)
insert into NHACUNGCAP (TenNhaCungCap, DiaChi, SDT) values (N'PepsiCo', N'Q.Thủ Đức', 0123222222)
insert into NHACUNGCAP (TenNhaCungCap, DiaChi, SDT) values (N'Tân Hiệp Phát', N'Q.Phú Nhuận', 0123333333)
insert into NHACUNGCAP (TenNhaCungCap, DiaChi, SDT) values (N'Unilever', N'London', 0123444444)
insert into NHACUNGCAP (TenNhaCungCap, DiaChi, SDT) values (N'Sabeco', N'TP.HCM', 0123555555)

insert into KHACHHANG (TenKhachHang, GioiTinh, DiaChi, SDT) values (N'Khởi My', N'Nữ', N'Quận 1', 01678111111)
insert into KHACHHANG (TenKhachHang, GioiTinh, DiaChi, SDT) values (N'Ưng Hoàng Phúc', N'Nam', N'Quận 8', 01678222222)
insert into KHACHHANG (TenKhachHang, GioiTinh, DiaChi, SDT) values (N'Sơn Tùng', N'Nam', N'Quận 3', 01678333333)
insert into KHACHHANG (TenKhachHang, GioiTinh, DiaChi, SDT) values (N'Tăng Thanh Hà', N'Nữ', N'Quận 10', 01678444444)
insert into KHACHHANG (TenKhachHang, GioiTinh, DiaChi, SDT) values (N'Hoài Linh', N'Nam', N'Quận 7', 01678555555)
insert into KHACHHANG (TenKhachHang, GioiTinh, DiaChi, SDT) values (N'Chí Tài', N'Nam', N'Quận 6', 01678666666)

insert into NGUOIDUNG (TenNguoiDung, TenTaiKhoan, MatKhau, LoaiNguoiDung) values (N'Võ Hoài Phương', 'phuongvh', '123456', 'admin')
insert into NGUOIDUNG (TenNguoiDung, TenTaiKhoan, MatKhau, LoaiNguoiDung) values (N'Võ Thanh Sĩ', 'sivt', '123456', 'user')
insert into NGUOIDUNG (TenNguoiDung, TenTaiKhoan, MatKhau, LoaiNguoiDung) values (N'Phan Y Biển', 'bienpy', '123456', 'user')
insert into NGUOIDUNG (TenNguoiDung, TenTaiKhoan, MatKhau, LoaiNguoiDung) values (N'Lê Duy Quân', 'quanld', '123456', 'user')

insert into DONDATHANG (MaKhachHang, NgayDat, NgayNhan, TienCoc, TrangThaiGiaoHang) values (1, '2/3/2016', '7/3/2016', 100000, 0)
insert into DONDATHANG (MaKhachHang, NgayDat, NgayNhan, TienCoc, TrangThaiGiaoHang) values (3, '5/3/2016', '10/3/2016', 150000, 0)
insert into DONDATHANG (MaKhachHang, NgayDat, NgayNhan, TienCoc, TrangThaiGiaoHang) values (2, '24/2/2016', '7/3/2016', 200000, 0)
insert into DONDATHANG (MaKhachHang, NgayDat, NgayNhan, TienCoc, TrangThaiGiaoHang) values (5, '6/3/2016', '19/3/2016', 300000, 0)
insert into DONDATHANG (MaKhachHang, NgayDat, NgayNhan, TienCoc, TrangThaiGiaoHang) values (6, '5/1/2016', '12/4/2016', 50000, 0)
insert into DONDATHANG (MaKhachHang, NgayDat, NgayNhan, TienCoc, TrangThaiGiaoHang) values (4, '3/3/2016', '9/3/2016', 100000, 0)

insert into CTDONDATHANG (MaDonDatHang, MaHangHoa, SoLuong) values (2, 1, 30)
insert into CTDONDATHANG (MaDonDatHang, MaHangHoa, SoLuong) values (3, 2, 15)
insert into CTDONDATHANG (MaDonDatHang, MaHangHoa, SoLuong) values (1, 4, 20)
insert into CTDONDATHANG (MaDonDatHang, MaHangHoa, SoLuong) values (5, 3, 10)
insert into CTDONDATHANG (MaDonDatHang, MaHangHoa, SoLuong) values (4, 6, 5)
insert into CTDONDATHANG (MaDonDatHang, MaHangHoa, SoLuong) values (6, 5, 20)

insert into PHIEUXUAT (MaKhachHang, MaNguoiDung, NgayLap, LoaiPhieu, TongThanhTien, TrangThaiThanhToan)
values (1, 1, '2/3/2016', '',100000, 'Chưa Thanh Toán')
insert into PHIEUXUAT (MaKhachHang, MaNguoiDung, NgayLap, LoaiPhieu, TongThanhTien, TrangThaiThanhToan)
values (2, 2, '4/4/2016', '',200000, 'Chưa Thanh Toán')
insert into PHIEUXUAT (MaKhachHang, MaNguoiDung, NgayLap, LoaiPhieu, TongThanhTien, TrangThaiThanhToan)
values (5, 3, '5/6/2016', '',300000, 'Chưa Thanh Toán')
insert into PHIEUXUAT (MaKhachHang, MaNguoiDung, NgayLap, LoaiPhieu, TongThanhTien, TrangThaiThanhToan)
values (4, 4, '6/2/2016', '',400000, 'Chưa Thanh Toán')
insert into PHIEUXUAT (MaKhachHang, MaNguoiDung, NgayLap, LoaiPhieu, TongThanhTien, TrangThaiThanhToan)
values (6, 1, '7/12/2016', '',500000, 'Chưa Thanh Toán')
insert into PHIEUXUAT (MaKhachHang, MaNguoiDung, NgayLap, LoaiPhieu, TongThanhTien, TrangThaiThanhToan)
values (3, 2, '8/9/2016', '',600000, 'Chưa Thanh Toán')

insert into CTPHIEUXUAT (MaPhieuXuat, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (1, 2, 20, 6000, 120000)
insert into CTPHIEUXUAT (MaPhieuXuat, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (2, 1, 40, 7000, 280000)
insert into CTPHIEUXUAT (MaPhieuXuat, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (3, 3, 20, 15000, 300000)
insert into CTPHIEUXUAT (MaPhieuXuat, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (4, 5, 10, 18000, 180000)
insert into CTPHIEUXUAT (MaPhieuXuat, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (5, 4, 50, 4000, 200000)
insert into CTPHIEUXUAT (MaPhieuXuat, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (6, 6, 30, 25000, 750000)

insert into PHIEUNHAP (MaNhaCungCap, MaNguoiDung, NgayLap, TongThanhTien) values (1, 1, '2/3/2016', null)
insert into PHIEUNHAP (MaNhaCungCap, MaNguoiDung, NgayLap, TongThanhTien) values (2, 2, '3/3/2016', null)
insert into PHIEUNHAP (MaNhaCungCap, MaNguoiDung, NgayLap, TongThanhTien) values (3, 3, '4/3/2016', null)
insert into PHIEUNHAP (MaNhaCungCap, MaNguoiDung, NgayLap, TongThanhTien) values (4, 4, '5/3/2016', null)
insert into PHIEUNHAP (MaNhaCungCap, MaNguoiDung, NgayLap, TongThanhTien) values (5, 1, '6/3/2016', null)

insert into CTPHIEUNHAP (MaPhieuNhap, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (1, 2, 20, 6000, 120000)
insert into CTPHIEUNHAP (MaPhieuNhap, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (2, 1, 30, 7000, 210000)
insert into CTPHIEUNHAP (MaPhieuNhap, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (3, 3, 10, 15000, 150000)
insert into CTPHIEUNHAP (MaPhieuNhap, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (4, 4, 15, 4000, 60000)
insert into CTPHIEUNHAP (MaPhieuNhap, MaHangHoa, SoLuong, DonGiaNhap, ThanhTien) values (5, 1, 50, 7000, 350000)

insert into CONGNO (MaKhachHang, ThoiHanTra, SoTienNo) values (1, '1/7/2016', 200000)
insert into CONGNO (MaKhachHang, ThoiHanTra, SoTienNo) values (2, '2/7/2016', 100000)
insert into CONGNO (MaKhachHang, ThoiHanTra, SoTienNo) values (3, '3/7/2016', 250000)
insert into CONGNO (MaKhachHang, ThoiHanTra, SoTienNo) values (4, '4/7/2016', 300000)

insert into LICHSUGIAODICH (MaCongNo, HinhThucThanhToan, ThoiGian, SoTien, CongNo) values (2, null, '1/5/2016', null, null)

select * from DONVI
select * from LOAIHANGHOA
select * from HANGHOA
select * from NHACUNGCAP
select * from KHACHHANG
select * from NGUOIDUNG
select * from DONDATHANG
select * from CTDONDATHANG
select * from PHIEUXUAT
select * from CTPHIEUXUAT
select * from PHIEUNHAP
select * from CTPHIEUNHAP
select * from CONGNO
select * from LICHSUGIAODICH