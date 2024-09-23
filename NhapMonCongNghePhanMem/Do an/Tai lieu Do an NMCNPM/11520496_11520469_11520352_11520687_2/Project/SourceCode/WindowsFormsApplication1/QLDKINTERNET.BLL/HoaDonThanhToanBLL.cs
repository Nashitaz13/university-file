using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLDKINTERNET.Data;
using QLDKINTERNET.Public;
namespace QLDKINTERNET.BLL
{
    public class HoaDonThanhToanBLL
    {
        public HoaDonThanhToanData cls = new  HoaDonThanhToanData(); 
        public int HoaDonThanhToan_Insert(HoaDonThanhToanPublic hd)
        {
            return cls.HoaDonThanhToan_Insert(hd);
        }
        public int HoaDonThanhToan_Update_TinhTrangThanhToan(HoaDonThanhToanPublic hd)
        {
            return cls.HoaDonThanhToan_Update_TinhTrangThanhToan(hd);
        }
        public DataTable HoaDonThanhToan_Select(HoaDonThanhToanPublic hd)
        {
            return cls.HoaDonThanhToan_Select(hd);
        }
        public DataTable HoaDonThanhToan_HoaDonChuaThanhToan()
        {
            return cls.HoaDonThanhToan_HoaDonChuaThanhToan();
        }
        public DataTable HoaDonThanhToan_HoaDonQuaHan()
        {
            return cls.HoaDonThanhToan_HoaDonQuaHan();
        }
    }
}
