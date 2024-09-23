using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using QLNT.DataTransferObject;
using QLNT.CommonLayer;

namespace QLNT.DataAccessLayer
{
    public class DalNhanVien
    {
        public DalNhanVien()
        {
           
        }

        public DataTable DocDanhSachNhanVienTheoPhanLoai(int maPhanLoaiNhanVien)
        {
            SqlParameter[] parameters = {new SqlParameter("@MaPhanLoaiNhanVien",maPhanLoaiNhanVien)};
            return SqlHelper.ExecuteDatatable(Constants.ConnectionString, "DocDSNhanVienTheoMaPhanLoai", parameters);
        }
        
        public void DocDanhSachNhanVien(DataTable dtNhanVien)
        {
            SqlHelper.FillDataTable(Constants.ConnectionString, "DocDSNhanVien", dtNhanVien, null);           
        }
    }
}
