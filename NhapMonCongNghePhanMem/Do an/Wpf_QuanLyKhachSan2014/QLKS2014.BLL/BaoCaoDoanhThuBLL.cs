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
    public class BaoCaoDoanhThuBll
    {
        BaoCaoDoanhThuData baoCaoDoanhThuData = new BaoCaoDoanhThuData();
        //select all 
        public List<BaoCaoDoanhThuPublic> selectAll()
        {
            return baoCaoDoanhThuData.selectAll();
        }

        //insert danh thu tra ve MaBaoCaoDanhThu
        public int insert(BaoCaoDoanhThuPublic baoCaoDoanhThuPublic)
        {
            return baoCaoDoanhThuData.insert(baoCaoDoanhThuPublic);
        }
    }
}
