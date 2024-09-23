using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using QLNT.DataAccessLayer;
using QLNT.CommonLayer;
using QLNT.DataTransferObject;

namespace QLNT.BusinessLogicLayer
{
    public class BllNhanVien
    {
        DalNhanVien dalNhanVien;

        public BllNhanVien()
        {
            dalNhanVien = new DalNhanVien();
        }

        public DataTable DocDanhSachNhanVienTheoPhanLoai(int maPhanLoaiNhanVien)
        {
            return (dalNhanVien.DocDanhSachNhanVienTheoPhanLoai(maPhanLoaiNhanVien));
        }

        public void DocDanhSachNhanVien(DataTable dtNhanVien)
        {
            dalNhanVien.DocDanhSachNhanVien(dtNhanVien);
        }
    }
}
