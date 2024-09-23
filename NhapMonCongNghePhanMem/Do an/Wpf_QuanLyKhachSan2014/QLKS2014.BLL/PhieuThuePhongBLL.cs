using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS2014.DATA;
using QLKS2014.PUBLIC;

namespace QLKS2014.BLL
{
    public class PhieuThuePhongBll
    {
        PhieuThuePhongData phieuThuePhongData = new PhieuThuePhongData();
        //Thêm Phieu Thue Phong
        public string insert(PhieuThuePhongPublic phieuThuePhongPublic)
        {
            return phieuThuePhongData.insert(phieuThuePhongPublic);
        }
    }
}
