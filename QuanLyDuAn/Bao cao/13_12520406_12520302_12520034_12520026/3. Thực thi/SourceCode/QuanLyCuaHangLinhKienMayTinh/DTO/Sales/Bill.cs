using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Warehouse;

namespace DTO.Sales
{
    public class Bill
    {
        private string _billId;
        private DateTime _billDate;
        private string _customerId;
        private string _staffId;
        private int _sum;
        private List<DtoProduct> _productList = new List<DtoProduct>();
        
        public string BillId
        {
            get { return _billId; }
            set
            {
                if (value.Length <= 10)
                    _billId = value;
            }
        }
        public DateTime BillDate
        {
            get { return _billDate; }
            set
            {
                if (value < DateTime.Now)
                    _billDate = value;
            }
        }
        public string CustomerId
        {
            get { return _customerId; }
            set
            {
                if (value.Length <= 10)
                    _customerId = value;
            }

        }
        public string StaffId
        {
            get { return _staffId; }
            set
            {
                if (value.Length <= 10)
                    _staffId = value;
            }
        }
       
        public int Sum
        {
            get { return _sum; }
            set
            {
                if (value > 0)
                    _sum = value;
            }
        }
        public List<DtoProduct> ProductList
        {
            get { return _productList; }
            set
            {
                if (value.Count > 0)
                {
                    foreach (DtoProduct p in value)
                    {
                        _productList.Add(p);
                    }
                }
            }
        }
        //end class
    }
}
