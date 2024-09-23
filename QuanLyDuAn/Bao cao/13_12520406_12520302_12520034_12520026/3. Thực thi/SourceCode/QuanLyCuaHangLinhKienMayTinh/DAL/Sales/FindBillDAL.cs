using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using System.Data;

namespace DAL.Sales
{
    public class FindBillDAL
    {
        public DataTable GetAllBill()
        {
            return SqlQuery.readSQL("select * from HOADON");
        }
    }
}
