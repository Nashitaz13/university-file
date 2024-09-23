using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// thong tin du lieu trong bao cao doanh thu
    /// </summary>
    public class ViewDataReport
    {
        public int idReport { get; set; }
        public string nameReport { get; set; }
        public DateTime dateBuil { get; set; }
        public int month { get; set; }
    }
}
