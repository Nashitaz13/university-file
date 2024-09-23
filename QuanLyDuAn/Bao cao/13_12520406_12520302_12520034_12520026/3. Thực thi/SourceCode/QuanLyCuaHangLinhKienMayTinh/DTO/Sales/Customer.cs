using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Sales
{
    class Customer
    {
        private string _customerId;
        private string _customerName;
        private string _idNumber;
        private string _address;
        private string _phoneNumber;
        private string _customerType;
        public string BillId
        {
            get { return _customerId; }
            set
            {
                if (value.Length <= 10)
                    _customerId = value;
            }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        public string idNumber
        {
            get { return _idNumber; }
            set
            {
                if (value.Length < 10)
                {
                    _idNumber = value;
                }
            }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string PhoneNuber
        {
            get { return _phoneNumber; }
            set
            {
                if (value.Length < 12)
                {
                    _phoneNumber = value;
                }
            }
        }
        public string CustomerType
        {
            get { return _customerType; }
            set { _customerType = value; }
        }
    }
}
