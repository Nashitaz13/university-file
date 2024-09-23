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
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace QLNT.BusinessLogicLayer
{
    public class BllTraCuuThuoc
    {
        DalThuocTonKho dalThuocTonKho;

        public BllTraCuuThuoc() 
        {
            dalThuocTonKho = new DalThuocTonKho();
        }

        public void TraCuuThuocTonKho(DataTable dtTraCuuThuoc, bool tatCaThuoc, int maNhomThuoc, string tenThuoc)
        {
            dalThuocTonKho.TraCuuThuocTonKho(dtTraCuuThuoc, tatCaThuoc, maNhomThuoc, tenThuoc);
        }
    }
}
