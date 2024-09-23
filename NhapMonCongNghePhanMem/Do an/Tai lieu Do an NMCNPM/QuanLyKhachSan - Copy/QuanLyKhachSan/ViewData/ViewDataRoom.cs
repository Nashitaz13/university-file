using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ViewData
{
    /// <summary>
    /// itemsource cua listview listroom
    /// </summary>
    public class ViewDataRoom
    {
            public int indexRoom { get; set; }
            public int id { get; set; }
            public string nameRoom { get; set; }
            public string typeRoom { get; set; }
            public decimal price { get; set; }
            public string status { get; set; }
            public string note { get; set; }
    }
}
