using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// hien thi cac phong trong hoa don thanh toan
    /// </summary>
    public class ViewRoomInBill
    {
        public int idBill { get; set; }
        public int idRoom { get; set; }
        public int idTypeRoom { get; set; }
        public string nameRoom { get; set; }
        public int totalDate { get; set; }
        public decimal price { get; set; }
        public decimal totalMoneyNeedToPay { get; set; }
        public int idRentRoom { get; set; }
        public int totalCustomer { get; set; }
        public int moreTypeCustomer { get; set; }
    }
}
