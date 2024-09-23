create table KHACHHANG(MAKH char(4)primary key, HOTEN varchar(40), DCHI varchar(50), SODT varchar(20), NGSINH smalldatetime, NGDK smalldatetime, DOANHSO money)
create table NHANVIEN(MANV char(4) primary key, HOTEN varchar(40), SODT varchar(20), NGVL smalldatetime)
create table SANPHAM(MASP char(4) primary key, TENSP varchar(40), DVT varchar(20), NUOCSX varchar(40), GIA money)
create table HOADON(SOHD int primary key, NGHD smalldatetime, MAKH char(4), MANV char(4), TRIGIA money)
create table CTHD(SOHD int primary key, MASP char(4), SL int)
alter table CTHD alter column MASP char(4) not NULL
alter table CTHD drop constraint PK__CTHD__A7FF3B410EA330E9
alter table CTHD add constraint PK_CTHD primary key(SOHD,MASP)
alter table HOADON add constraint FK_HOADON_KHACHHANG foreign key(MAKH) references KHACHHANG(MAKH)
alter table CTHD add constraint FK_CTHD_HOADON foreign key(SOHD) references HOADON(SOHD) 
alter table CTHD add constraint FK_CTHD_SANPHAM foreign key(MASP) references SANPHAM(MASP)
alter table HOADON add constraint FK_HOADON_NHANVIEN foreign key(MANV) references NHANVIEN(MANV)
select *from KHACHHANG
select *from NHANVIEN
select *from SANPHAM
select *from HOADON
select *from CTHD
alter table SANPHAM add GHICHU varchar(20)
alter table KHACHHANG add LOAIKH tinyint /*them thuoc tinh*/
alter table SANPHAM alter column GHICHU varchar(100)
alter table SANPHAM drop column GHICHU/*Xoa thuoc tinh*/
alter table KHACHHANG alter column LOAIKH varchar(20) /* Lam the nao de LOAIKH co the luu gia tri:"Vang lai"...*/
alter table SANPHAM add constraint CK_GIA_SP check (GIA>=500)/*Dieu kien gia phai lon hon hoc bang 500)*/
insert into SANPHAM values ('BT01','But Sap',NULL,NULL,600)
alter table CTHD add constraint CK_SLSP check (SL>=1)
alter table SANPHAM add constraint CK_DVT check(DVT='cay'or DVT='hop' or DVT='cai' or DVT='quyen' or DVT='chuc')
insert into SANPHAM values ('BT03','But Bi','but',NULL,500)
alter table SANPHAM drop constraint CK_DVT
alter table KHACHHANG add constraint CK_NgayDK check(NGDK>NGSINH)
insert into KHACHHANG values ('KH01','Nguyen Van A',NULL,NULL,'2/21/1994','2/22/1994',NULL,NULL)