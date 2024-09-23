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
    public class LoaiKhachHangBll
    {
        LoaiKhachHangData loaiKhachHangData = new LoaiKhachHangData();
        //Select All
        public List<LoaiKhachHangPublic> selectAll()
        {
            return loaiKhachHangData.selectAll();
        }

        //Select theo Tên
        public List<LoaiKhachHangPublic> selectByName(LoaiKhachHangPublic loaiKhachHangPublic)
        {
            return loaiKhachHangData.selectByName(loaiKhachHangPublic);
        }
        //Thêm vào loại khách hàng mới
        public void insert(LoaiKhachHangPublic loaiKhachHangPublic)
        {
            loaiKhachHangData.insert(loaiKhachHangPublic);
        }

        //Delete 
        public void delete(LoaiKhachHangPublic loaiKhachHangPublic)
        {
            loaiKhachHangData.delete(loaiKhachHangPublic);
        }
    }
}
