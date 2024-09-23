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
    public class NguoiDungBll
    {
        NguoiDungData nguoiDungData = new NguoiDungData();
        //Update Password
        public List<NguoiDungPublic> update(NguoiDungPublic nguoiDungPublic)
        {
            return nguoiDungData.update(nguoiDungPublic);
        }
    }
}
