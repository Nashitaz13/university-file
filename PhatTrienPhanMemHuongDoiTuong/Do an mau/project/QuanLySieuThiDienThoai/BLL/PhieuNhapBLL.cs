using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using QuanLySieuThiDienThoai.DTO;
using QuanLySieuThiDienThoai.DAO;

namespace QuanLySieuThiDienThoai.BLL
{
    class PhieuNhapBll
    {
        private PhieuNhapDao phieuNhap = new PhieuNhapDao();

        public void ThemPN(PhieuNhap info)
        {
            phieuNhap.ThemPN(info);
        }

        public void ThemCTPN(CTPhieuNhap info)
        {
            phieuNhap.ThemCTPN(info);
        }

        public string LayMaPhieuNhapMax()
        {
            return phieuNhap.LayMaPhieuNhapMax();
        }
    }
}
