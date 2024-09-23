create table SinhVien (MSSV char(4) primary key, HoTen varchar(20), NTNS datetime, DiaChi varchar(50), MaLop char(5))
create table Lop (MaLop char(5)primary key, TenLop varchar(50))
alter table SinhVien add constraint FK_SinhVien_Lop foreign key(MaLop) references Lop(MaLop)
/*Nhap du lieu*/insert into SinhVien (MSSV, HoTen, NTNS, DiaChi, MaLop) values ('SV01','Nguyen Van A','1/1/2000', 'Q10', NULL)
insert into SinhVien values ('SV02', 'Nguyen Van B','2/7/2000','Q11','L01')
insert into SinhVien values ('SV03', 'Nguyen Van C',NULL,NULL,NULL)
/* cap nhat du lieu*/update SinhVien set MaLop = 'L01' where MSSV='SV03'
update SinhVien set MaLop = 'L02', DiaChi = 'Q9' where MSSV = 'SV01'
update SinhVien set MaLop = 'L01' where MSSV = 'SV01'
update Lop set MaLop = 'L05' where MaLop = 'L01'
select * from SinhVien
insert into Lop (MaLop, TenLop) values ('L01','Lop 1')
insert into Lop values ('L02','Lop 2')
insert into Lop (MaLop) values ('L03')
insert into Lop (TenLop, MaLop) values ('Lop 4','L04')
select *from Lop
/*Xoa du lieu*/delete from Lop where MaLop='L05'
/* Dat lai ngay thang*/Set dateformat dmy
insert into SinhVien values ('SV05','Nguyen Van D','20/6/2000',NULL,NULL)
insert into SinhVien values ('SV06','Nguyen Van E','23/7/2000',NULL,NULL)