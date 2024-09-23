using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLKS2014.PUBLIC;
using QLKS2014.DATA;

namespace QLKS2014.BLL
{
    public class HoaDonBll
    {
        HoaDonData hoaDonData = new HoaDonData();
        //Select All;
        public List<HoaDonPublic> selectAll()
        {
            return hoaDonData.selectAll();
        }

        //insert 
        public int insert(HoaDonPublic hoaDonPublic)
        {
            return hoaDonData.insert(hoaDonPublic);
        }
    }
}
