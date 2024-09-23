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
    public class ChiTietPhieuThuePhongBll
    {
        ChiTietPhieuThuePhongData chiTietPhieuThuePhongData = new ChiTietPhieuThuePhongData();
        //Select All
        public List<ChiTietPhieuThuePhongPublic> ChiTietPhieuThuePhong_SelectAll()
        {
            return chiTietPhieuThuePhongData.selectAll();
        }

        //Thêm ChiTietPhieuThuePhong Moi
        public void insert(ChiTietPhieuThuePhongPublic chiTietPhieuThuePhongPublic)
        {
            chiTietPhieuThuePhongData.insert(chiTietPhieuThuePhongPublic);
        }

    }
}
