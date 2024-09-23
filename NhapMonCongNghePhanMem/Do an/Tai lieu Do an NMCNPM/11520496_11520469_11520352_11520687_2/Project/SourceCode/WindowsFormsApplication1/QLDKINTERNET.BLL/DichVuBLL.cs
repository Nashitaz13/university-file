using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Public;
using QLDKINTERNET.Data;

namespace QLDKINTERNET.BLL
{
    public class DichVuBLL
    {
        DichVuData cls = new DichVuData();

        public int DangKyDichVu(DichVuPublic dv)
        {
            return cls.DangKyDichVu(dv);
        }

        public int HuyDichVu(DichVuPublic dv)
        {
            return cls.HuyDichVu(dv);
        }

        public DataTable TimKiemDichVu(DichVuPublic dv)
        {
            return cls.TimKiemDichVu(dv);
        }

        public int CapNhatDichVu(DichVuPublic dv)
        {
            return cls.CapNhatDichVu(dv);
        }

        public DataTable DichVu_Select_TheoTinhTrangThanhToan(DichVuPublic dv)
        {
            return cls.DichVu_Select_TheoTinhTrangThanhToan(dv);
        }

        public int DichVu_Update_TinhTrangThanhToan(DichVuPublic dv)
        {
            return cls.DichVu_Update_TinhTrangThanhToan(dv);
        }

        public DataTable DichVu_Select_TinhTrangDichVu_ThanhToan()
        {
            return cls.DICHVU_Select_TinhTrangDichVu_ThanhToan();
        }

        public DataTable DichVu_Select_TinhTrangDichVu()
        {
            return cls.DICHVU_Select_TinhTrangDichVu();
        }

        public int DichVu_Update_TinhTrangDichVu(DichVuPublic dv)
        {
            return cls.DichVu_Update_TinhTrangDichVu(dv);
        }

        public DataTable DichVu_Select_MaDV(DichVuPublic dv)
        {
            return cls.DichVu_Select_MaDV(dv);
        }

        public int DichVu_CatMangDichVuChuaThanhToan()
        {
            return cls.DichVu_CatMangDichVuChuaThanhToan();
        }
    }
}
