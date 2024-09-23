using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using QuanLySieuThiDienThoai.DTO;

namespace QuanLySieuThiDienThoai.BLL
{
    class PhieuXuatBll
    {
        private PhieuXuatDao phieuXuat = new PhieuXuatDao();

        public void ThemPX(PhieuXuat px)
        {
            phieuXuat.ThemPX(px);
        }

        public void ThemCTPX(CTPhieuXuat ctpx)
        {
            phieuXuat.ThemCTPX(ctpx);
        }

        public string LayMaPhieuXuatMax()
        {
            return phieuXuat.LayMaPhieuXuatMax();
        }


    }
}
