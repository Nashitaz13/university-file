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
    public class LoaiPhongBll
    {
        LoaiPhongData loaiPhongData = new LoaiPhongData();
        //Select All
        public List<LoaiPhongPublic> selectAll()
        {
            return loaiPhongData.selectAll();
        }
        //Update
        public int update(LoaiPhongPublic loaiPhongPublic)
        {
            return loaiPhongData.update(loaiPhongPublic);
        }

        //Delete
        public void delete(LoaiPhongPublic loaiPhongPublic)
        {
            loaiPhongData.delete(loaiPhongPublic);
        }
    }
}
