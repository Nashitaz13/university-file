using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// hien thi thong tin nguoi dung
    /// </summary>
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string typeUser { get; set; }
    }
}
