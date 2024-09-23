using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Delivery;
using DTO.Warehouse;

namespace BLL.Delivery
{
    public class BllDeliveryBill
    {

        private DalDeliveryBill _dalDeliveryBill;

        public BllDeliveryBill()
        {
            _dalDeliveryBill = new DalDeliveryBill();
        }

        public DataTable GetDeliveryBillList()
        {
            return _dalDeliveryBill.GetDeliveryBillList();
        }

        public DataTable GetEmployeeList()
        {
            return _dalDeliveryBill.GetEmployeeList();
        }

        public bool AddDeliveryBillTran(DtoDeliveryBill DeliveryBill, List<DtoDeliveryBillDetail> list)
        {
            return _dalDeliveryBill.AddDeliveryBillTran(DeliveryBill, list) == 0 ? false : true;
        }
    }
}
