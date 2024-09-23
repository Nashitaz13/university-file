using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO.Warehouse;

namespace BLL.Warehouse
{
    public class BllWarehouseBill
    {
        private DalWarehouseBill _dalWarehouseBill;

        public BllWarehouseBill()
        {
            _dalWarehouseBill = new DalWarehouseBill();
        }

        public DataTable GetWarehouseBillList()
        {
            return _dalWarehouseBill.GetWarehouseBillList();
        }

        public DataTable GetEmployeeList()
        {
            return _dalWarehouseBill.GetEmployeeList();
        }

        public bool AddWarehouseBillTran(DtoWarehouseBill warehouseBill, List<DtoWarehouseBillDetail> list)
        {
            return _dalWarehouseBill.AddWarehouseBillTran(warehouseBill, list) == 0 ? false : true;
        }
    }
}
