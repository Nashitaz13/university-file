using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Delivery;

namespace BLL.Delivery
{
    public class BllDeliveryBillDetail
    {
        private DalDeliveryBillDetail _dalDeliveryBillDetail;

        public BllDeliveryBillDetail()
        {
            _dalDeliveryBillDetail = new DalDeliveryBillDetail();
        }


        public DataTable GetDeliveryBillDetailList()
        {
            return _dalDeliveryBillDetail.GetDeliveryBillDetailList();
        }

        public DataTable GetDeliveryBillDetailWithDeliveryBillID(string id)
        {
            return _dalDeliveryBillDetail.GetDeliveryBillDetailWithDeliveryBillID(id);
        }

        public double SumTotal(string id)
        {
            double s = 0;
            DataTable dt = _dalDeliveryBillDetail.GetDeliveryBillDetailWithDeliveryBillID(id);
            foreach (DataRow row in dt.Rows)
            {
                s += double.Parse(row["DonGiaNhap"].ToString()) *
                     int.Parse(row["SoLuong"].ToString());
            }
            return s;
        }
    }
}
