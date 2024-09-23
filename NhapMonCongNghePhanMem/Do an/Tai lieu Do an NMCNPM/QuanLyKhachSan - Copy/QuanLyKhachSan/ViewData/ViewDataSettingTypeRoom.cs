using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// hien thi danh sach cac loai phong len listview
    /// </summary>
    public class ViewDataSettingTypeRoom
    {
        //so thu tu
        public int index { get; set; }
        //ma loai phong
        public int idTypeRoom { get; set; }
        //ten loai phong
        public string nameTypeRoom { get; set; }
        //don gia
        public decimal price { get; set; }
        //so khac toi da
        public int maxCustomer { get; set; }
    }
}
