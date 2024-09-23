using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Warehouse;

namespace BLL.Warehouse
{
    public class BllWarehouseBillDetail
    {
        private DalWarehouseBillDetail _dalWarehouseBillDetail;

        public BllWarehouseBillDetail()
        {
            _dalWarehouseBillDetail = new DalWarehouseBillDetail();
        }


        public DataTable GetWarehouseBillDetailList()
        {
            return _dalWarehouseBillDetail.GetWarehouseBillDetailList();
        }

        public DataTable GetWarehouseBillDetailWithWarehouseBillID(string id)
        {
            return _dalWarehouseBillDetail.GetWarehouseBillDetailWithWarehouseBillID(id);
        }

        public double SumTotal(string id)
        {
            double s = 0;
            DataTable dt = _dalWarehouseBillDetail.GetWarehouseBillDetailWithWarehouseBillID(id);
            foreach (DataRow row in dt.Rows)
            {
                s += double.Parse(row["DonGiaNhap"].ToString())*
                     int.Parse(row["SoLuong"].ToString());
            }
            return s;
        }
    }
}
