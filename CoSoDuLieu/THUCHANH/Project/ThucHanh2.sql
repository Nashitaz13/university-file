CREATE TABLE HOCVIEN(
MAHV CHAR(4),
HOTEN VARCHAR(20),
GIOITINH VARCHAR(3)
)

create trigger HocVien_GioiTinh
on HOCVIEN
for update
as
raiserror ('Dang goi trigger',16,10)

insert into HOCVIEN values ('HV01','A','Nam')
 
update HOCVIEN
set GIOITINH='Nam'
where MAHV='HV01'

select * from HOCVIEN
