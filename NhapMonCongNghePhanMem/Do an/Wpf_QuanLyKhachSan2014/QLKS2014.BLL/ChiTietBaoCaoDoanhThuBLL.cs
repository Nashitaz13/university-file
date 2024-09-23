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
    public class ChiTietBaoCaoDoanhThuBll
    {
        ChiTietBaoCaoDoanhThuData chiTietBaoCaoDoanhThuData = new ChiTietBaoCaoDoanhThuData();
        //select all
        public List<ChiTietBaoCaoDoanhThuPublic> selectAll()
        {
            return chiTietBaoCaoDoanhThuData.selectAll();
        }

        //select all theo MaBaoCao
        public List<ChiTietBaoCaoDoanhThuPublic> selectAllByMaBaoCao(ChiTietBaoCaoDoanhThuPublic chiTietBaoCaoDoanhThuPublic)
        {
            return chiTietBaoCaoDoanhThuData.selectAllByMaBaoCao(chiTietBaoCaoDoanhThuPublic);
        }

        //insert
        public int insert(ChiTietBaoCaoDoanhThuPublic chiTietBaoCaoDoanhThuPublic)
        {
            return chiTietBaoCaoDoanhThuData.insert(chiTietBaoCaoDoanhThuPublic);
        }
    }
}
