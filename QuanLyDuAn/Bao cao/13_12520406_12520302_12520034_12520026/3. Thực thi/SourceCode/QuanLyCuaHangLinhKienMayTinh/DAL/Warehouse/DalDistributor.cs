using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;

namespace DAL.Warehouse
{
    public class DalDistributor
    {
        public DataTable GetDistributorList()
        {
            return
                SqlHelper.ExecuteDataset(CommonLayer.Constants.ConnectionString, CommandType.StoredProcedure,
                    "GetDistributorList").Tables[0];
        }
    }
}
