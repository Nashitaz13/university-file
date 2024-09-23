using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL.Sales
{
    
    public class FindBillBLL
    {
        DAL.Sales.FindBillDAL findBillDAL = new DAL.Sales.FindBillDAL();
        public DataTable GetAllBill()
        {
            return findBillDAL.GetAllBill();
        }
    }
}
