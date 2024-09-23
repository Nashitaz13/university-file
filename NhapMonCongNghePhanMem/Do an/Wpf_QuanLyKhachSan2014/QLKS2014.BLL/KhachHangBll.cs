using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKS2014.DATA;
using QLKS2014.PUBLIC;

namespace QLKS2014.BLL
{
    public class KhachHangBll
    {
        KhachHangData khachHangData = new KhachHangData();
        List<KhachHangPublic> selectAll()
        {
            return khachHangData.selectAll();
        }
    }
}
