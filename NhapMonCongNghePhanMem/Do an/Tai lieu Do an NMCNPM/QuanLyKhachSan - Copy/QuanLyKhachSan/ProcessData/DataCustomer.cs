using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ProcessData
{
    /// <summary>
    /// xu ly du lieu nguoi dung
    /// </summary>
    public class DataCustomer
    {
        SqlCeConnection connectionData;
        public DataCustomer()
        {
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
        }

        /// <summary>
        /// them loai khach moi
        /// </summary>
        /// <param name="name_">ten loai khach</param>
        /// <param name="rateSurcharge_"></param>
        public void addNewTypeCustomer(string name_, float rateSurcharge_)
        {
            try
            {
                connectionData.Open();
            }
            catch { }
            //lay ma loai khach moi
            string cmdText = "SELECT MaLoaiKhach FROM LOAIKHACH ORDER BY MaLoaiKhach DESC";
            int newID = 0;
            using (SqlCeCommand cmdGetNewId = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetNewId.ExecuteReader();
                while (reader.Read())
                {
                    newID = (int)reader["MaLoaiKhach"];
                    break;
                }
            }

            cmdText = "INSERT INTO LOAIKHACH VALUES(@MaLoaiKhach, @TenLoaiKhach, @TiLePhuThu)";
            using (SqlCeCommand cmdInsertValue = new SqlCeCommand(cmdText, connectionData))
            { 
                newID++;
                cmdInsertValue.Parameters.Add(new SqlCeParameter("MaLoaiKhach", newID));
                cmdInsertValue.Parameters.Add(new SqlCeParameter("TenLoaiKhach", name_));
                cmdInsertValue.Parameters.Add(new SqlCeParameter("TiLePhuThu", rateSurcharge_));
                cmdInsertValue.ExecuteNonQuery();
            }
            connectionData.Close();
        }

        /// <summary>
        /// xoa mot loai khach trong du lieu
        /// </summary>
        /// <param name="idTypeCustomer_"></param>
        public void deleteTypeCustomer(int idTypeCustomer_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "DELETE FROM LOAIKHACH WHERE MaLoaiKhach = " + idTypeCustomer_;
            using (SqlCeCommand cmdDelete = new SqlCeCommand(cmdText, connectionData))
            {
                cmdDelete.ExecuteNonQuery();
            }
            connectionData.Close();
        }

        /// <summary>
        /// cap nhat thong tin loai khach co trong du lieu
        /// </summary>
        /// <param name="name_">ten loai khach</param>
        /// <param name="rateSurcharge_">ti le phu thu</param>
        public void updateTypeCustomer(string name_, float rateSurcharge_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "UPDATE LOAIKHACH SET TiLePhuThu = " 
                + rateSurcharge_ + "  WHERE TenLoaiKhach = " + name_;
            using (SqlCeCommand cmdUpdate = new SqlCeCommand(cmdText, connectionData))
            {
                cmdUpdate.ExecuteNonQuery();
            }
            connectionData.Close();
        }

        public void testExist(string name_, float rateSurcharge_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "SELECT MaLoaiKhach FROM LOAIKHACH WHERE TenLoaiKhach = '" + name_ + "'";
            using (SqlCeCommand cmdTestExist = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdTestExist.ExecuteReader();
                while (reader.Read())
                {
                    updateTypeCustomer(name_, rateSurcharge_);
                }
            }
            addNewTypeCustomer(name_, rateSurcharge_);
            connectionData.Close();
        }
    }
}
