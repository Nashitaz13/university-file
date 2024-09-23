using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyKhachSan.ProcessData
{
    /// <summary>
    /// xu ly du lieu cua cac loai phong
    /// </summary>
    public class DataTypeRoom
    {
        SqlCeConnection connectionData;
        public DataTypeRoom()
        {
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
        }

        /// <summary>
        /// them mot loai phong moi
        /// </summary>
        /// <param name="name_">ten loai phong moi</param>
        /// <param name="price_">don gia loai phong moi</param>
        /// <param name="maxCustomer">so khach toi da</param>
        public void addNewTypeRoom(string name_, decimal price_, int maxCustomer_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            //tao ma loai phong moi
            string cmdText = "SELECT MaLoaiPhong FROM LOAIPHONG ORDER BY MaLoaiPhong DESC";
            int newId = 0;
            using (SqlCeCommand cmdGetNewId = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetNewId.ExecuteReader();
                while (reader.Read())
                {
                    newId = (int)reader["MaLoaiPhong"];
                    break;
                }
            }
            //them loai phong moi
            cmdText = "INSERT INTO LOAIPHONG VALUES(@MaLoaiPhong, @TenLoaiPhong, @DonGia, @SoKhachToiDa)";
            using (SqlCeCommand cmdInsert = new SqlCeCommand(cmdText, connectionData))
            {
                newId++;
                cmdInsert.Parameters.Add(new SqlCeParameter("MaLoaiPhong", newId));
                cmdInsert.Parameters.Add(new SqlCeParameter("TenLoaiPhong", name_));
                cmdInsert.Parameters.Add(new SqlCeParameter("DonGia", price_));
                cmdInsert.Parameters.Add(new SqlCeParameter("SoKhachToiDa", maxCustomer_));
                cmdInsert.ExecuteNonQuery();
            }
            connectionData.Close();
        }

        /// <summary>
        /// xoa mot loai phong trong co so du lieu
        /// </summary>
        /// <param name="idTypeRoom_"></param>
        public void deleteTypeRoom(int idTypeRoom_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "DELETE LOAIPHONG WHERE MaLoaiPhong = " + idTypeRoom_;
            using (SqlCeCommand cmdDelete = new SqlCeCommand(cmdText, connectionData))
            {
                cmdDelete.ExecuteNonQuery();
            }
            connectionData.Close();
        }

        /// <summary>
        /// cap nhat thong tin loai phong da co
        /// </summary>
        /// <param name="name_">ten loai phong</param>
        /// <param name="price_">don gia loai phong</param>
        /// <param name="maxCustomer_">so khach toi da</param>
        public void updateTypeRoom(string name_, decimal price_, int maxCustomer_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "UPDATE LOAIPHONG SET DonGia = " + price_ 
                + ", SoKhachToiDa = " + maxCustomer_ + "WHERE TenLoaiPhong = '" + name_ + "'";
            using (SqlCeCommand cmdUpdate = new SqlCeCommand(cmdText, connectionData)) 
            {
                cmdUpdate.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// kiem tra loai phong nhap vao co ton tai khong
        /// them moi neu khong ton tai
        /// cap nhat neu da ton tai
        /// </summary>
        /// <param name="name_">ten loai phong</param>
        /// <param name="price_">dong gia loai phong</param>
        /// <param name="maxCustomer_">so khach toi da</param>
        public void testExist(string name_, decimal price_, int maxCustomer_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "SELECT MaLoaiPhong FROM LOAIPHONG WHERE TenLoaiPhong = '" + name_ + "'";
            using (SqlCeCommand cmdTestExist = new SqlCeCommand(cmdText,connectionData))
            {
                SqlCeDataReader reader = cmdTestExist.ExecuteReader();
                while (reader.Read())
                {
                    updateTypeRoom(name_, price_, maxCustomer_);
                }
            }
            addNewTypeRoom(name_, price_, maxCustomer_);
            connectionData.Close();
        }
    }
}
