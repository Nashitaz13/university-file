using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ReturningBill
    {
        private string _returningBillId;
        private DateTime _returningDate;
        private string _customerId;
        private string _staffId;
        private string _billId;
        private string _returningProductId;
        private int _returningFee;
        public string ReturningBillId
        {
            get { return _returningBillId; }
            set
            {
                if (value.Length <= 10)
                    _returningBillId = value;
            }
        }
        public DateTime ReturningDate
        {
            get { return _returningDate; }
            set
            {
                if (value < DateTime.Now)
                    _returningDate = value;
            }
        }
        public string BillId
        {
            get { return _billId; }
            set
            {
                if (value.Length <= 10)
                    _billId = value;
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
        public string ReturningProductId
        {
            get { return _returningProductId; }
            set
            {
                if (value.Length <= 10)
                    _returningProductId = value;
            }
        }
        public int ReturningFee
        {
            get { return _returningFee; }
            set
            {
                if (value > 0)
                    _returningFee = value;
            }
        }
    }
}
