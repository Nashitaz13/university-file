using EasyPOS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyPOS.BLL
{
    class CongNoBLL
    {
        POS_DBDataContext dbContext = new POS_DBDataContext();

        //public IEnumerable<CONGNO> LayDanhSachCongNo()
        //{
        //    IEnumerable<CONGNO> query = from c in dbContext.CONGNOs select c;
        //    return query;
        //}
        //public IEnumerable<LICHSUGIAODICH> LayDanhSachLichSuGiaoDich(int MaCongNo)
        //{
        //    IEnumerable<LICHSUGIAODICH> query = from c in dbContext.LICHSUGIAODICHes where c.MaCongNo == MaCongNo select c;
        //    return query;
        //}
        //public void CapNhatCongNo(int MaCongNo, float congNo)
        //{
        //    CONGNO c = dbContext.CONGNOs.Single<CONGNO>(x => x.MaCongNo == MaCongNo);
        //    c.SoTienNo = congNo;
        //    dbContext.SubmitChanges();
        //}


        //// Thêm lịch sử giao dịch công nợ: Nếu là nợ: thì hình thức là trừ -1, còn nếu là thanh toán thì hình thức là +1
        //public void ThemGiaoDich(int maCongNo, int hinhThuc, DateTime thoiGian, float SoTien, float CongNo)
        //{
        //    LICHSUGIAODICH lichSuGiaoDich = new LICHSUGIAODICH();
        //    lichSuGiaoDich.MaCongNo = maCongNo;
        //    lichSuGiaoDich.HinhThucThanhToan = hinhThuc;
        //    lichSuGiaoDich.ThoiGian = thoiGian;
        //    lichSuGiaoDich.SoTien = SoTien;
        //    lichSuGiaoDich.CongNo = CongNo;
        //    dbContext.LICHSUGIAODICHes.InsertOnSubmit(lichSuGiaoDich);
        //    dbContext.SubmitChanges();
        //}

        
    }
}
