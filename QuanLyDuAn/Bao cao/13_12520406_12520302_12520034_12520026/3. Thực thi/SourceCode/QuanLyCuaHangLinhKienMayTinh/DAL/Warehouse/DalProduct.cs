using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using DTO.Warehouse;
using Microsoft.ApplicationBlocks.Data;

namespace DAL.Warehouse
{
    public class DalProduct
    {
        public DataTable GetListProducts()
        {
            return SqlHelper.ExecuteDataset(Constants.ConnectionString,
                CommandType.StoredProcedure,
                "GetListProducts").Tables[0];
        }

        public DtoProduct GetProductByID(string id)
        {
            DataTable dt =  SqlHelper.ExecuteDataset(Constants.ConnectionString, CommandType.Text,
                "select * from SANPHAM where MaSanPham = @MaSanPham", new SqlParameter("@MaSanPham", id)).Tables[0];
            DtoProduct dto = new DtoProduct(
                dt.Rows[0].ItemArray[0].ToString(),
                dt.Rows[0].ItemArray[1].ToString(),
                dt.Rows[0].ItemArray[2].ToString(),
                int.Parse(dt.Rows[0].ItemArray[3].ToString()),
                double.Parse(dt.Rows[0].ItemArray[4].ToString()),
                double.Parse(dt.Rows[0].ItemArray[5].ToString()),
                int.Parse(dt.Rows[0].ItemArray[6].ToString()),
                dt.Rows[0].ItemArray[7].ToString(),
                dt.Rows[0].ItemArray[8].ToString()
                );
            return dto;
        }

        public int AddProduct(DtoProduct data)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@MaSanPham", data.MaSanPham), 
                new SqlParameter("@TenSanPham", data.TenSanPham), 
                new SqlParameter("@LoaiSanPham", data.LoaiSanPham), 
                new SqlParameter("@ThoiGianBaoHanh", data.ThoiGianBaoHanh), 
                new SqlParameter("@DonGiaNhap", data.DonGiaNhap), 
                new SqlParameter("@DonGiaBan", data.DonGiaBan), 
                new SqlParameter("@SoLuong", data.SoLuong), 
                new SqlParameter("@DonViTinh", data.DonViTinh), 
                new SqlParameter("@GhiChu", data.GhiChu)
            };
            try
            {
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, "AddProduct",
                    para);
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionSql);
            }
            catch (Exception)
            {
                throw new AggregateException(Constants.MsgExceptionError);
            }
        }

        public int EditProduct(DtoProduct data)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@MaSanPham", data.MaSanPham),
                new SqlParameter("@TenSanPham", data.TenSanPham),
                new SqlParameter("@LoaiSanPham", data.LoaiSanPham),
                new SqlParameter("@ThoiGianBaoHanh", data.ThoiGianBaoHanh),
                new SqlParameter("@DonGiaNhap", data.DonGiaNhap),
                new SqlParameter("@DonGiaBan", data.DonGiaBan),
                new SqlParameter("@SoLuong", data.SoLuong),
                new SqlParameter("@DonViTinh", data.DonViTinh),
                new SqlParameter("@GhiChu", data.GhiChu)
            };
            try
            {
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, "EditProduct",
                    para);
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionSql);
            }
            catch (Exception)
            {
                throw new AggregateException(Constants.MsgExceptionError);
            }
        }

        public int DeleteProduct(string maSanPham)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@MaSanPham", maSanPham),
            };
            try
            {
                return SqlHelper.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, "DeleteProduct",
                    para);
            }
            catch (SqlException)
            {
                throw new ArgumentException(Constants.MsgExceptionSql);
            }
            catch (Exception)
            {
                throw new AggregateException(Constants.MsgExceptionError);
            }
        }


    }
}
