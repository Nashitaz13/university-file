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
    public class DalThuocTonKho
    {
        public DalThuocTonKho() { }

        public void TraCuuThuocTonKho(DataTable dtTraCuuThuoc, bool tatCaThuoc, int maNhomThuoc, string tenThuoc)
        {
            SqlParameter[] parameters = { 
                                            new SqlParameter("@TatCaThuoc", tatCaThuoc) ,
                                            new SqlParameter("@MaNhomThuoc", maNhomThuoc) ,
                                            new SqlParameter("@TenThuoc", tenThuoc) 
                                        };
            SqlHelper.FillDataTable(Constants.ConnectionString, "TraCuuThuocTonKho", dtTraCuuThuoc, parameters);
        }
    }
}
