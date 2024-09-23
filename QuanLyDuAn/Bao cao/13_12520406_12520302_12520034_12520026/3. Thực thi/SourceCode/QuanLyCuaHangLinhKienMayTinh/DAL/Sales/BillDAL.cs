using CommonLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Sales;
using DTO;
using Microsoft.ApplicationBlocks.Data;
using DTO.Sales;
using CommonLayer;
namespace DAL.Sales
{
    public class BillDAL
    {
        public BillDAL()
        {
            SqlQuery.writeSQL("set dateformat dmy");
        }
        //proList: Danh sách mã sản phẩm và số lượng tương ứng của một hóa đơn id= billId
        public void AddBill(string billId, string date, string cusId, string staffId, int sum, List<CommonFunction.BillProduct> proList)
        {
                SqlParameter[] para1 =
                {
                    new SqlParameter("@MaHD",billId),
                    new SqlParameter("@NgayHD",date),
                    new SqlParameter("@MaKH",cusId),
                    new SqlParameter("@MaNV",staffId),
                    new SqlParameter("@ThanhTien",sum),
                    
                };
                
                string sql = "insert into HOADON VALUES ('" + billId + "','" + date + "','" + cusId + "','" + staffId + "'," + sum + ")";
                SqlQuery.writeSQL(sql);
                //SqlQuery.writeSQL("insert into HOADON VALUES ('@MaHD','@NgayHD','@MaKH','@MaNV',@ThanhTien)", para1);
                for (int i = 1; i < proList.Count; i++)
                {
                    SqlParameter[] listpara ={
                            new SqlParameter("@MaHD", billId),
                            new SqlParameter("@MaSP",proList[i].proId),
                            new SqlParameter("@SL", proList[i].num),

                   };
                    SqlQuery.writeSQL("insert into CHITIETHOADON VALUES ('@MaHD','@MaSP','@SL')",listpara);
                }
        }
        public DataTable GetAllBill()
        {
            return SqlQuery.readSQL("select * from HOADON");
        }
        // Lấy danh sách hóa đơn được thanh toán trong ngày
        public DataTable GetBillToday()
        {
            string today = DateTime.Now.ToString();
            return SqlQuery.readSQL("Select* from HOADON where NgayHD=" + today);
        }
        //Lấy danh sách sản phẩm theo tên và loại
        public DataTable GetProduct(string productName, string categoryId)
        {
            return SqlQuery.readSQL("select MaSanPham, TenSanPham, SoLuong from SANPHAM where TenSanPham like '%" + productName + "%' and LoaiSanPham=N'"+categoryId+"'");

        }
        public DataTable GetProduct(string categoryId)
        {
            return SqlQuery.readSQL("select MaSanPham, TenSanPham, SoLuong from SANPHAM where LoaiSanPham=N'" + categoryId + "'");

        }
        public DataTable GetProductfromName(string productName)
        {
            return SqlQuery.readSQL("select MaSanPham, TenSanPham, SoLuong from SANPHAM where TenSanPham like '%"+productName+"%'");
        }
        // lấy danh sách khách hàng theo tên khách hàng và loại khách hàng 
        public DataTable GetCustomer(string cusName)
        {
           return SqlQuery.readSQL("select MaKH, TenKH from KHACHHANG where TenKH like '%"+cusName+"%'");
        }

        // Lấy tất cả khách hàng
        public DataTable GetAllCustomer()
        {
            return SqlQuery.readSQL("select MaKH, TenKH from KHACHHANG");
        }
        // Lấy tất cả sản phẩm
        public DataTable GetAllProduct()
        {
            return SqlQuery.readSQL("select MaSanPham, TenSanPham, SoLuong from SANPHAM");
        }
        public DataTable GetCustomerDetail(string cusId)
        {
            return SqlQuery.readSQL("Select CMND, DiaChi, SoDT from KHACHHANG where MaKH='"+cusId+"'");
        }
        public DataTable GetProductPrice(string productId)
        {
            return SqlQuery.readSQL("Select DonGiaBan from SANPHAM where MaSanPham='" + productId + "'");
        }
        public DataTable GetCategoryList()
        {
            return SqlQuery.readSQL("select distinct LoaiSanPham from SANPHAM");
        }
        // lấy quy định về thuế suất
        public DataTable GetRule(string rule)
        {
            return SqlQuery.readSQL("select GiaTri from QUYDINH where TenQD= N'"+rule+"'");
        }
        // Lấy mã hóa đơn cuối cùng
        public DataTable GetLastBillId()
        {
            return SqlQuery.readSQL("select top 1 MaHD from HOADON order by MaHD desc");
        }
        public DataTable GetLastCustomerId()
        {
            return SqlQuery.readSQL("select top 1 MaKH from KHACHHANG order by MaKH desc");
        }
    }
}
