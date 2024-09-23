create Database QLSV
create table SinhVien (MSSV char(4), HoTen varchar(20), NTNS datetime, DiaChi varchar(50))
create table Lop (Malop char(5) primary key, TenLop varchar(20), LopTruong char(10))
alter table SinhVien alter column MSSV char(4) not null /*Hieu chinh not null cho "MSSV"*/
go /*Hieu chinh not null sau do them khoa chinh*/
alter table SinhVien add primary key(MSSV) /*Them khoa chinh*/
alter table SinhVien add MaLop char(5) /*Them "MaLop" vao bang "SinhVien"*/
alter table SinhVien add foreign key(MaLop)references Lop(MaLop)/*Tham chieu khoa ngoai toi khoa chinh*/
alter table Lop alter column LopTruong char(4)/*Thay doi kieu du lieu*/
alter table Lop add constraint FK_Lop_SinhVien foreign key(LopTruong) references SinhVien(MSSV)/*Tham chieu va doi ten khoa ngoai*/
create table MonHoc (MaMH char(5), TenMH varchar(30), primary key(MaMH))
create table Thi (MSSV char(4)foreign key references SinhVien(MSSV)/*Tham chieu khoa ngoai trong bang*/, MaMH char(5), Diem int, primary key(MSSV,MaMH))
alter table Thi add constraint FK_Thi_MonHoc foreign key(MaMH) references MonHoc(MaMH)
alter table Lop drop FK_Lop_SinhVien
exec sp_rename 'SinhVien.HoTen','Ten','column' /*Doi ten cot*/
drop table Thi /*Xoa bang*/
