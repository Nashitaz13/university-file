using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// hien thi du lieu len listview
    /// </summary>
    public class CustomerDetail
    {
        public int index { get; set; }
        public string name { get; set; }
        public string idCard { get; set; }
        public string adress { get; set; }
        public string typeCustomer { get; set; }
        public string room { get; set; }
        public DateTime startDate { get; set; }
        public string endDate { get; set; }
    }
}
