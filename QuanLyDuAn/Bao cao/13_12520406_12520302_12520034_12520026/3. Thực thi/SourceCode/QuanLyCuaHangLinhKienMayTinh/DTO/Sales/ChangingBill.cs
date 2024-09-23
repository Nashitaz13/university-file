using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Sales
{
    class ChangingBill
    {
        private string _changingBillId;
        private DateTime _changingDate;
        private string _customerId;
        private string _staffId;
        private string _billId;
        private string _chagingProductId;
        private string _replaceProductId;
        private int _changingFee;
        private int _returningFee;
        public string ChangingBillId
        {
            get { return _changingBillId; }
            set
            {
                if (value.Length <= 10)
                    _changingBillId = value;
            }
        }
        public DateTime ChangingDate
        {
            get { return _changingDate; }
            set
            {
                if (value < DateTime.Now)
                    _changingDate = value;
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
        public string ChagingProductId
        {
            get { return _chagingProductId; }
            set
            {
                if (value.Length <= 10)
                    _chagingProductId = value;
            }
        }
        public string ReplaceProductId
        {
            get { return _replaceProductId; }
            set
            {
                if (value.Length <= 10)
                    _replaceProductId = value;
            }
        }
        public int ChangingFee
        {
            get { return _changingFee; }
            set
            {
                if (value > 0)
                    _changingFee = value;
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
