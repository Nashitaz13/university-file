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
    public class ChiTietHoaDonBll
    {
        ChiTietHoaDonData chiTietHoaDonData = new ChiTietHoaDonData();
        //select all
        public List<ChiTietHoaDonPublic> selectAll()
        {
            return chiTietHoaDonData.selectAll();
        }
        
        //Insert 
        public void insert(ChiTietHoaDonPublic chiTietHoaDonPublic)
        {
            chiTietHoaDonData.insert(chiTietHoaDonPublic);
        }
    }
}
