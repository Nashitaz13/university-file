
--------------------------------------------------------
create proc GetPasswordEmployee
@MaNV nvarchar(10)
as
begin
select PassWord from NHANVIEN where MaNV = @MaNV;
end
--------------------------------------------------------------

go
---------------------------------------------------------------------------------------
create proc GeCountEmployee
as
begin
Select count(*)from NHANVIEN;
end
--------------------------------------------------------------
go
---------------------------------------------------------------------------------------
create proc InsertEmployee
@MaNV nvarchar(10),
@Ten nvarchar(50),
@GioiTinh nvarchar(50),
@CMND nvarchar(15),
@SDT nvarchar(15),
@NgaySinh smalldatetime,
@DiaChi nvarchar(50),
@NoiSinh nvarchar(50),
@Tuoi nvarchar(10),
@ChucVu nvarchar(10),
@Luong nvarchar(50),
@NgayVaoLam smalldatetime,
@AnhThe image,
@TrangThai nvarchar(50),
@Password nvarchar(16),
@MaCN nvarchar(10)
as
begin
insert into NHANVIEN values(@MaNV,@Ten,@GioiTinh,@CMND,@SDT,@NgaySinh,@DiaChi,@NoiSinh
,@Tuoi,@ChucVu,@Luong,@NgayVaoLam,@AnhThe,@TrangThai,@Password,@MaCN);
end
--------------------------------------------------------------
--------------------------------------------------------------------------------------
go
create proc UpdateEmployee
@MaNV nvarchar(10),
@Ten nvarchar(50),
@GioiTinh nvarchar(50),
@CMND nvarchar(15),
@SDT nvarchar(15),
@NgaySinh smalldatetime,
@DiaChi nvarchar(50),
@NoiSinh nvarchar(50),
@Tuoi nvarchar(10),
@ChucVu nvarchar(10),
@Luong nvarchar(50),
@NgayVaoLam smalldatetime,
@AnhThe image,
@TrangThai nvarchar(50),
@Password nvarchar(16),
@MaCN nvarchar(10)
as
begin
update NHANVIEN SET Ten=@Ten,GioiTinh=@GioiTinh,CMND=@CMND,SDT=@SDT,
NgaySinh=@NgaySinh,DiaChi=@DiaChi,NoiSinh=@NoiSinh,Tuoi=@Tuoi,ChucVu=@ChucVu,
Luong=@Luong,NgayVaoLam=@NgayVaoLam,AnhThe=@AnhThe,TrangThai=@TrangThai,PassWord=@Password 
where MaNV=@MaNV
end
--------------------------------------------------------------


go
--------------------------------------------------------------------------------------
create proc DeleteEmployee
@MaNV nvarchar(10),
@TrangThai nvarchar(50)
as
begin
update NHANVIEN SET TrangThai=@TrangThai  
where MaNV=@MaNV
end
--------------------------------------------------------------
go
-----------------------------------------------------------------------------------------
create proc GetEmployee
@MaNV nvarchar(10)
as
begin
Select * 
from NHANVIEN 
where  MaNV=@MaNV
end
--------------------------------------------------------------

go
-----------------------------------------------------------------------------------------
create proc GetAllPosition
as
begin
Select *
from CHUCVU 
where DaXoa='0'
end
--------------------------------------------------------------
go
-------------------------------------------------------------------------------------
create proc GetAllEmployee
as
begin
Select *
from NHANVIEN
end
--------------------------------------------------------------
go
-------------------------------------------------------------------------------------
create proc GetImage
@MaNV nvarchar(10)
as
begin
 Select AnhThe
from NHANVIEN 
where MaNV =@MaNV;
end
--------------------------------------------------------------
go
-------------------- co the dung lai 
create proc GetPositionName
@Machucvu nvarchar(10)
as
begin
Select TenChucVu
from CHUCVU
where MaChucVu =@Machucvu and DaXoa='0';
end
--------------------------------------------------------------
go
-------------------- co the dung lai 
create proc GetPosition
@Machucvu nvarchar(10)
as
begin
Select *
from CHUCVU
where MaChucVu =@Machucvu and DaXoa='0';
end
--------------------------------------------------------------

go
-------------------- ------------ 
create proc GetPositionCount
as
begin
Select COUNT (*)
from CHUCVU where DaXoa ='0'
end
--------------------------------------------------------------

go
-------------------- ------------ 
create proc GetFuntion
@MaCN nvarchar(10)
as
begin
Select *
from CHUCNANG where  MaCN = @MaCN
end
--------------------------------------------------------------

go
-------------------- ------------ 
create proc SavePosition
@MaChucVu nvarchar(10),
@TenChucVu nvarchar(20),
@Luong nvarchar(50),
@MaCN nvarchar(10)
as
begin
insert into CHUCVU values(@MaChucVu,@TenChucVu,@Luong,@MaCN,'0')
end
--------------------------------------------------------------

go
-------------------- ------------ 
create proc UpdatePosition
@MaChucVu nvarchar(10),
@TenChucVu nvarchar(20),
@Luong nvarchar(50),
@MaCN nvarchar(10),
@DaXoa int
as
begin
update CHUCVU SET  TenChucVu=@TenChucVu,Luong=@Luong,MaCN=@MaCN,
DaXoa=@DaXoa
where MaChucVu=@MaChucVu
end
--------------------------------------------------------------


go
-------------------- ------------ 
create proc DeletePosition
@MaChucVu nvarchar(10)
as
begin
update CHUCVU SET  DaXoa='1'
where MaChucVu=@MaChucVu
end
--------------------------------------------------------------


go
-------------------- ------------ 
create proc CreateFuntion
@MaChucNang nvarchar(10)
as
begin
Insert into CHUCNANG values(@MaChucNang,'0');
end
--------------------------------------------------------------

go
-------------------- ------------ 
create proc UpdateFuntion
@MaChucNang nvarchar(10)
as
begin
update CHUCNANG SET  cn1='1'
where MaCN=@MaChucNang
end
--------------------------------------------------------------

go
---------------------------------------------------------------------------------------
create proc GetCountEmployeeUsePosition
@MaChucVu nvarchar(10)
as
begin
Select count(*)from NHANVIEN where ChucVu = @MaChucVu
end
--------------------------------------------------------------