using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Warehouse;
using DTO.Warehouses;

namespace BLL.Warehouse
{
    public class BllWarehouse
    {

        private DalWarehouse _dalWarehouse;

        public BllWarehouse()
        {
            _dalWarehouse = new DalWarehouse();
        }

        public DataTable GetListWarehouses()
        {
            return _dalWarehouse.GetListWarehouse();
        }

        public bool AddWarehouse(DtoWarehouse data)
        {
            try
            {
                return _dalWarehouse.AddWarehouse(data) != 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool EditWarehouse(DtoWarehouse data)
        {
            try
            {
                return _dalWarehouse.EditWarehouse(data) != 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }

        } 
        public DataTable SearchWarehouse(string q)
        {
            return _dalWarehouse.SearchWarehouse(q);
        }
    }
}
