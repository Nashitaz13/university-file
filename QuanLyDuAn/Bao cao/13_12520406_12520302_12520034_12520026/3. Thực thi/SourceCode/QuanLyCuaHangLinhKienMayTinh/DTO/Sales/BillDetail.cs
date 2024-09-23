using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Sales
{
    class BillDetail
    {
        private string _productId;
        private string _billId;
        private int _amount;
        public string ProductId
        {
            get { return _productId; }
            set
            {
                if (value.Length <= 10)
                    _productId = value;
            }
        }
        public string BillId 
        {
            get { return _billId; }
            set {
                if (value.Length <= 10)
                    _billId = value;
            }
        }
        public int Amount
        {
            get { return _amount; }
            set
            {
                if (value > 0)
                    _amount = value;
            }
        }
    }
}
