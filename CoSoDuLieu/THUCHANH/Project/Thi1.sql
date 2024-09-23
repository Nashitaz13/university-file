create table SINHVIEN (MaSV varchar(10) primary key, HoSV varchar(20), TenSV varchar(10), NgaySinh DateTime, DiaChi varchar(50), Phai varchar(5), Nam varchar(5), Khoa varchar(20))
create table GIANGVIEN (MaGV varchar(10) primary key, HoGV varchar(20), TenGV varchar(10), NgaySinh DateTime, DiaChi varchar(50), Phai varchar(5), Khoa varchar(20))
create table MONHOC (MaMH varchar(10) primary key, TenMH varchar(50), STC int, Loai varchar(10))
create table KHOAHOC (MaKH varchar(10) primary key, MaMH varchar(10), HocKy int, NamHoc varchar(5), MaGV varchar(10))
create table KETQUA (MaSV varchar(10), MaKH varchar(10), Diem int, KetQua varchar(20))
alter table KETQUA alter column MaSV varchar(10) not null
alter table KETQUA alter column MaKH varchar (10) not null
alter table KETQUA add constraint PK_KETQUA primary key(MaSV,MaKH)
alter table KHOAHOC add constraint FK_KHOAHOC_MONHOC foreign key (MaMH) references MONHOC(MaMH)
alter table KHOAHOC add constraint FK_KHOAHOC_GIANGVIEN foreign key (MaGV) references GIANGVIEN(MaGV)
alter table KETQUA add constraint FK_KETQUA_SINHVIEN foreign key (MaSV) references SINHVIEN(MaSV)
alter table KETQUA add constraint FK_KETQUA_KHOAHOC foreign key (MaKH) references KHOAHOC(MaKH)

set dateformat dmy

insert into SINHVIEN values ('SV001','Nguyen Van','Anh','10/01/1990','Da Nang','Nam',2007,'Mang')
insert into SINHVIEN values ('SV002','Tran Anh','Tuan','20/09/1991','TpHCM','Nam',2008,'HTTT')
insert into SINHVIEN values ('SV003','Le Thi Diem','Thuy','12/04/1990','Hue','Nu',2007,'CNPM')
insert into SINHVIEN values ('SV004','Tran Kieu','Oanh','21/12/1991','TpHCM','Nu',2008,'CNPM')
insert into SINHVIEN values ('SV005','Vo Tuan','Phong','12/06/1989','BinhDuong','Nam',2006,'HTTT')
insert into SINHVIEN values ('SV006','Le Kim','Quoc','12/02/1990','TpHCM','Nam',2007,'Mang')

insert into GIANGVIEN values ('GV001','Vo Minh','Triet','01/04/1979','TpHCM','Nam','CNPM')
insert into GIANGVIEN values ('GV002','Tran Nhat','Thuy','20/08/1984','NhaTrang','Nu','HTTT')
insert into GIANGVIEN values ('GV003','Nguyen Thuy','Ngoc','09/07/1980','Hue','Nu','Mang')

insert into MONHOC values ('IT001','CSDL',4,'Bat buoc')
insert into MONHOC values ('IT002','Lap trinh ung dung Web',4,'Tu chon')
insert into MONHOC values ('IT003','Nhap mon CNPM',4,'Bat buoc')

insert into KHOAHOC values ('IT0012006','IT001',1,2006,'GV002')
insert into KHOAHOC values ('IT0012007','IT001',2,2007,'GV002')
insert into KHOAHOC values ('IT0022008','IT002',1,2008,'GV001')
insert into KHOAHOC values ('IT0032008','IT003',2,2008,'GV003')

insert into KETQUA values ('SV001','IT0012006',8,'Dat')
insert into KETQUA values ('SV001','IT0022008',4,'Khong Dat')
insert into KETQUA values ('SV001','IT0032008',9,'Dat')
insert into KETQUA values ('SV002','IT0012006',4,'Khong Dat')
insert into KETQUA values ('SV002','IT0012007',8,'Dat')
insert into KETQUA values ('SV002','IT0022008',7,'Dat')
insert into KETQUA values ('SV002','IT0032008',10,'Dat')
insert into KETQUA values ('SV003','IT0032008',9,'Dat')
insert into KETQUA values ('SV004','IT0022008',3,'Khong Dat')
insert into KETQUA values ('SV005','IT0012007',8,'Dat')

-- Câu 2
alter table MONHOC add constraint CK_Loai check (Loai='Bat buoc' or Loai='Tu chon' or Loai='Chuyen nganh')

-- Câu 3
--a
(select SV.MaSV, HoSV, TenSV
from SINHVIEN SV, KHOAHOC KH, KETQUA KQ
where SV.MaSV=KQ.MaSV and KH.MaKH=KQ.MaKH and MaMH='IT002')
intersect
(select SV.MaSV, HoSV, TenSV
from SINHVIEN SV, KHOAHOC KH, KETQUA KQ
where SV.MaSV=KQ.MaSV and KH.MaKH=KQ.MaKH and MaMH='IT003')

--b
select MaKH, A.MaSV, HoSV, TenSV, Diem
from SINHVIEN SV, (select MaKH, MaSV, Diem
					from KETQUA
					where MaKH in (select MaKH
									from KETQUA
									group by MaKH)
					and Diem in (select MAX(Diem)
								from KETQUA
								group by MaKH)) A
where SV.MaSV=A.MaSV
order by MaKH ASC

--c
select MaKH, MAX(Diem)diem_cao_nhat, MIN(Diem)diem_thap_nhat, AVG(Diem)diem_trung_binh
from SINHVIEN SV, KETQUA KQ
where SV.MaSV=KQ.MaSV
group by MaKH

--d
select MaSV, HoSV, TenSV
from SINHVIEN
where not exists
(select * from KHOAHOC
where not exists
(select * from KETQUA
where SINHVIEN.MaSV=KETQUA.MaSV and KHOAHOC.MaKH=KETQUA.MaKH))

select * from SINHVIEN
select * from GIANGVIEN
select * from MONHOC
select * from KHOAHOC
select * from KETQUA