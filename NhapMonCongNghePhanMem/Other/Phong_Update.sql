USE [QuanLyKhachSan]
GO
/****** Object:  StoredProcedure [dbo].[Phong_Update]    Script Date: 11/29/2014 8:38:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Phong_Update]
/*@MaPhong int,
@TenPhong nvarchar(50),
@TenLoaiPhong nvarchar(50)
as
begin tran
declare @maloaiphong nchar(1) -- khai báo biến chứa mã loại phòng

-- lấy mã loại phòng theo tên loại phòng nhập phòng
Select @maloaiphong = lp.MaLoaiPhong
From LOAIPHONG as lp
Where lp.TenLoaiPhong = @TenLoaiPhong;
if(@@ERROR <>0 or @@ROWCOUNT =0) -- kiểm tra nếu có lỗi(@@ERROR <>0) hoặc k tìm thấy dữ liệu(@@ROWCOUNT =0) thì thoát
begin
print 'tên loại phòng k đúng';
return
end
-- lấy thử tên phòng theo mã phòng
select @TenPhong= p.TenPhong from PHONG as p where p.MaPhong = @MaPhong;
if (@@ROWCOUNT = 0) -- nếu k có dữ liệu thì insert
begin
insert into PHONG(MaPhong,TenPhong,MaLoaiPhong) values(@MaPhong,@TenPhong,@maloaiphong);
if(@@ERROR <>0 or @@ROWCOUNT =0) -- kiểm tra nếu có lỗi hoặc k insert dc thì hủy thao tác và thoát
begin
print 'Insert k thành công';
rollback -- hủy thao tác insert kế trước
return
end
end
else --ngược lại đã có dữ liệu thì update
begin
update phong set tenphong=@TenPhong, maloaiphong=@maloaiphong where maphong= @Maphong;
if(@@ERROR <>0 or @@ROWCOUNT =0) -- kiểm tra
begin
print 'update k thành công';
rollback
return
end
end
commit
go
execute inserts 1,'anh','hai';*/
@TenPhong nvarchar(50),
@TenLoaiPhong nvarchar(50),
@GhiChu nvarchar(50)
AS
BEGIN
	declare @check int, @MaPhong nchar(10)
	select @MaPhong from PHONG
	select @check = COUNT(*) from PHONG where (MaPhong = @MaPhong)
	if @check = 0
	begin
		EXEC Phong_Insert
	end
	else
		begin
			update PHONG
			set
				TenPhong = @TenPhong,
				GhiChu = @GhiChu
			where (MaPhong = @MaPhong)
		end
END
