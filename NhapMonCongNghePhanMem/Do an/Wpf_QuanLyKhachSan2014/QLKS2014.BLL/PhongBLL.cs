using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS2014.PUBLIC;
using QLKS2014.DATA;
using System.Data;

namespace QLKS2014.BLL
{
    public class PhongBll
    {
        PhongData phongData = new PhongData();
        //public DataTable selectAll()
        //{
          //  return phongData.selectAll();
        //}

        public List<PhongPublic> selectAll()
        {
            return phongData.selectAll();
        }

        //Xóa Phòng có MaPhong = "ID"
        public void deleteById(PhongPublic phongPublic)
        {
            phongData.deleteById(phongPublic);
        }

        //Tìm tất cả các phòng có TenLoaiPhong = "A"
        //public DataTable selectByTenLoaiPhong(LoaiPhongPUBLIC loaiPhongPublic)
        //{
        //    return phongData.selectByTenLoaiPhong(loaiPhongPublic);
        //}
        public List<PhongPublic> selectByTenLoaiPhong(LoaiPhongPublic loaiPhong)
        {
            return phongData.selectByTenLoaiPhong(loaiPhong);
        }

        //Thêm Phòng
        public void insert(PhongPublic phongPublic)
        {
            phongData.insert(phongPublic);
        }

        //Tìm Phòng Thuê Trong thời gian = NgayThue
        public List<PhongPublic> selectByRentTime(DateTime ngayDau, DateTime ngayCuoi)
        {
            return phongData.selectByRentTime(ngayDau,ngayCuoi);
        }

        //Update Phòng
        public int update(PhongPublic phongPublic)
        {
            return phongData.update(phongPublic);
        }

        //Tìm Phòng Trống
        public List<PhongPublic> selectPhongEmpty(PhongPublic phongPublic)
        {
            return phongData.selectPhongEmpty(phongPublic);
        }

        //Tìm Phòng Đã Thuê
        public List<PhongPublic> selectPhongNotEmpty(PhongPublic phongPublic)
        {
            return phongData.selectPhongNotEmpty(phongPublic);
        }
    }
}
