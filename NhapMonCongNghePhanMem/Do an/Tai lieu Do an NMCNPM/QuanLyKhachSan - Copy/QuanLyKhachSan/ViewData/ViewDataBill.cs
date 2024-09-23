using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// item hien thi len list view
    /// </summary>
    public class ViewDataBill
    {
        public string id { get; set; }
        public string nameCustomer { get; set; }
        public DateTime date { get; set; }
        public decimal totalMoney { get; set; }
    }
}
