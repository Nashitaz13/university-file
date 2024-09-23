using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// thong tin chi tiet bao cao doanh thu
    /// </summary>
    class ViewDetailReport
    {
        public int index { get; set; }
        public int idDetailRepport { get; set; }
        public int idReport { get; set; }
        public int idTypeRoom { get; set; }
        public string nameTypeRoom { get; set; }
        public decimal totalMoney { get; set; }
        public float percent { get; set; }
    }
}
