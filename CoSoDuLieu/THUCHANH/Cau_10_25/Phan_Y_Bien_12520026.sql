/*Họ Tên: Phan Y Biển
MSSV: 12520026
Lớp: IT004.E16*/

-- Bài tập QLGV_Phần III_Câu 10_25
-- Câu 10
select MAMH, TENMH
from MONHOC
where MAMH in (select DK.MAMH
				from MONHOC MH, DIEUKIEN DK
				where MH.MAMH=DK.MAMH_TRUOC and TENMH='Cau Truc Roi Rac')
-- Câu 11
select distinct HOTEN
from GIANGDAY GD, GIAOVIEN GV
where GD.MAGV=GV.MAGV and (MALOP='K11' or MALOP='K12') and MAMH='CTRR' and HOCKY=1 and NAM=2006

-- Câu 12
select MAHV,HO,TEN
from HOCVIEN 
where MAHV in (select MAHV
				from KETQUATHI
				where MAMH='CSDL' and KQUA='Khong Dat'
				group by MAHV
				having COUNT(MAHV)=1)

-- Câu 13
select MAGV,HOTEN
from GIAOVIEN
where MAGV not in (select MAGV
					from GIANGDAY)

-- Câu 14 
select distinct GV.MAGV, GV.HOTEN
from GIANGDAY GD, GIAOVIEN GV
where GD.MAGV = GV.MAGV AND 
		GV.MAGV NOT IN (select distinct GV.MAGV
						from GIAOVIEN GV, MONHOC MH, GIANGDAY GD
						where MH.MAMH = GD.MAMH AND MH.MAKHOA = GV.MAKHOA AND GD.MAGV = GV.MAGV)

-- Câu 15
select HO,TEN
from HOCVIEN HV, KETQUATHI KQT
where HV.MAHV=KQT.MAHV and MALOP='K11' and ((LANTHI=3 and KQUA='Khong Dat') or (LANTHI=2 and MAMH='CTRR' and DIEM=5))

-- Câu 16
select HOTEN
from GIAOVIEN GV, (select MAGV, NAM, HOCKY, COUNT(MALOP) SL_Lop_CTRR
					from GIANGDAY
					where MAMH='CTRR' 
					group by NAM, HOCKY, MAGV
					having COUNT(MALOP)>=2) A
where GV.MAGV=A.MAGV

-- Câu 17 
select KQT.MAHV, HO, TEN, MAMH, LANTHI, DIEM
from KETQUATHI KQT, HOCVIEN HV
where KQT.MAHV=HV.MAHV and MAMH='CSDL' and KQT.MAHV not in (select MAHV
															from KETQUATHI
															where MAMH='CSDL' and (LANTHI=2 or LANTHI=3))
union
(select KQT.MAHV, HO, TEN, MAMH, LANTHI, DIEM
from KETQUATHI KQT, HOCVIEN HV
where KQT.MAHV=HV.MAHV and MAMH='CSDL' and LANTHI=2 and KQT.MAHV not in (select MAHV
																		from KETQUATHI
																		where MAMH='CSDL' and LANTHI=3))
union
(select KQT.MAHV, HO, TEN, MAMH, LANTHI, DIEM
from KETQUATHI KQT, HOCVIEN HV
where KQT.MAHV=HV.MAHV and KQT.MAMH='CSDL' and LANTHI=3)

-- Câu 18
select HV.MAHV,HO,TEN,NGSINH,GIOITINH,NOISINH,MALOP,DT_Mon_Co_So_Du_Lieu
from HOCVIEN HV , (select MAHV, MAX(DIEM) DT_Mon_Co_So_Du_Lieu
					from KETQUATHI KQT, MONHOC MH
					where KQT.MAMH=MH.MAMH and TENMH='Co So Du Lieu'
					group by MAHV) A
where HV.MAHV=A.MAHV

-- Câu 19
select MAKHOA, TENKHOA
from KHOA
where NGTLAP in(select min(NGTLAP)
				from KHOA)

-- Câu 20
select count(HOCHAM) So_hoc_ham_GS_PGS
from (select HOCHAM
		from GIAOVIEN
		where HOCHAM='GS' or HOCHAM='PGS') A
		
-- Câu 21
select MAKHOA, HOCVI, COUNT(MAGV) SLGV
from GIAOVIEN
group by HOCVI, MAKHOA

-- Câu 22
select SL.MAMH,TENMH, KQUA, So_Luong_HV
from MONHOC MH, (select MAMH, KQUA, COUNT(MAHV) So_Luong_HV
				from KETQUATHI
				group by MAMH, KQUA) SL
where MH.MAMH=SL.MAMH

-- Câu 23
select MAGVCN, HOTEN
from LOP, GIAOVIEN
where MAGVCN=MAGV and MAGVCN in (select distinct MAGV
								from GIANGDAY
								where MAGV in (select MAGVCN
												from LOP))

-- Câu 24
select TRGLOP, HO, TEN
from LOP L, HOCVIEN HV
where L.TRGLOP=HV.MAHV and SISO in (select MAX(SISO)
									from LOP)

-- Câu 25
select MAHV, HO, TEN
from HOCVIEN
where MAHV in 									
((select KQT.MAHV
from KETQUATHI KQT, HOCVIEN HV
where KQT.MAHV=HV.MAHV and KQUA='Khong Dat' and KQT.MAHV not in (select MAHV
																from KETQUATHI
																where KQUA='Khong Dat' and (LANTHI=2 or LANTHI=3))
											and KQT.MAHV in (select TRGLOP
																from LOP)
group by KQT.MAHV
having COUNT(MAMH)>3)
union
(select KQT.MAHV
from KETQUATHI KQT, HOCVIEN HV
where KQT.MAHV=HV.MAHV and KQUA='Khong Dat' and LANTHI=2 and KQT.MAHV not in (select MAHV
																				from KETQUATHI
																				where KQUA='Khong Dat' and LANTHI=3)
														and KQT.MAHV in (select TRGLOP
																from LOP)
group by KQT.MAHV
having COUNT(MAMH)>3)
union
(select KQT.MAHV
from KETQUATHI KQT, HOCVIEN HV
where KQT.MAHV=HV.MAHV and KQUA='Khong Dat' and  LANTHI=3 and KQT.MAHV in (select TRGLOP
																from LOP)
group by KQT.MAHV
having COUNT(MAMH)>3))
