using QuanLyKhachSan.ViewData;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyKhachSan.ProcessData
{
    /// <summary>
    /// xử lý dữ liệu cho thuê phòng
    /// lưu, xóa, xuất phiếu
    /// </summary>
    public class DataRentRoom
    {
        //tao ket noi
        public static SqlCeConnection connectionData;

        public DataRentRoom()
        {
            //khoi tao ket noi
            connectionData =
                new SqlCeConnection(Properties.Settings
                    .Default.QUANLYKHACHSANConnectionString1);
        }

        /// <summary>
        /// hien thi thong tin cac phieu thue phong len list view
        /// </summary>
        /// <param name="listRentRoom_">noi hien thi</param>
        public void viewAllData(ref ListView listRentRoom_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch { }

            try
            {
                //do du lieu tu csdl
                string cmdText = "SELECT * FROM PHIEUTHUEPHONG";
                using (SqlCeCommand cmdGetValue = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdGetValue.ExecuteReader();
                    while (reader.Read())
                    {
                        ViewDataRentRoom item = new ViewDataRentRoom();
                        item.idRentRoom = int.Parse(reader["MaPTP"].ToString());
                        item.idRoom = int.Parse(reader["MaPhong"].ToString());
                        item.date = reader["NgayThue"].ToString();
                        listRentRoom_.Items.Add(item);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đa xảy ra lỗi \nKhông thể load dữ liệu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connectionData.Close();
        }

        /// <summary>
        /// them mot phieu thue phong moi vao csdl
        /// </summary>
        /// <param name="idRoom_">ma phong</param>
        /// <param name="typeRoom_">ma loai phong</param>
        /// <param name="date_">ngay bat dau thue</param>
        /// <param name="customer_">danh sach khach hang</param>
        public void AddNewRentRoom(string nameRoom_,
            string date_,
            List<CustomerDetail> customer_)
        {
            try
            {
                // mo ket noi du lieu
                connectionData.Open();
            }
            catch { }
            try
            {
                //tao mot id phieu thue phong moi khong trung voi cac id cu
                int newIdRentRoom = 0;
                //ma phong duoc thue
                int idRoom = 0;
                string cmdText = "SELECT MaPTP FROM PHIEUTHUEPHONG ORDER BY MaPTP DESC";
                using (SqlCeCommand cmdGetNewId = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdGetNewId.ExecuteReader();
                    while (reader.Read())
                    {
                        newIdRentRoom = int.Parse(reader["MaPTP"].ToString());
                        break;
                    }
                }                

                //lay ma phong theo ten phong
                cmdText = "SELECT MaPhong FROM PHONG WHERE TenPhong = '" + nameRoom_ + "'";
                using (SqlCeCommand cmdGetIdRoom = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdGetIdRoom.ExecuteReader();
                    while (reader.Read())
                    {
                        idRoom = int.Parse(reader["MaPhong"].ToString());
                        break;
                    }
                }

                //them du lieu cho phieu thue phong
                cmdText = "INSERT INTO PHIEUTHUEPHONG VALUES(@MaPTP, @MaPhong, @NgayThue, @SoLuong, @DaThanhToan)";
                using (SqlCeCommand cmdInsertValueToRentRoomTable = 
                    new SqlCeCommand(cmdText, connectionData))
                {
                    newIdRentRoom++;
                    cmdInsertValueToRentRoomTable.Parameters.Add(new SqlCeParameter("MaPTP", newIdRentRoom));
                    cmdInsertValueToRentRoomTable.Parameters.Add(new SqlCeParameter("MaPhong", idRoom));
                    cmdInsertValueToRentRoomTable.Parameters.Add(new SqlCeParameter("NgayThue", date_));
                    cmdInsertValueToRentRoomTable.Parameters.Add(new SqlCeParameter("SoLuong", customer_.Count));
                    cmdInsertValueToRentRoomTable.Parameters.Add(new SqlCeParameter("DaThanhToan", "CHUA"));
                    cmdInsertValueToRentRoomTable.ExecuteNonQuery();
                }

                //cap nhat tinh trang phong
                cmdText = "UPDATE PHONG SET TinhTrang = 'Da Thue' WHERE MaPhong = " + idRoom;
                using (SqlCeCommand updateStatusRoom =
                    new SqlCeCommand(cmdText, connectionData))
                {
                    updateStatusRoom.ExecuteNonQuery();
                }

                //tao mot id chi tiet phieu thue phong moi
                int newIdDetailRentRoom = 0;
                cmdText = "SELECT MaCTPTP FROM CHITIETPTP ORDER BY MaCTPTP DESC";
                using (SqlCeCommand cmdGetNewId = new SqlCeCommand(cmdText,connectionData))
                {
                    SqlCeDataReader reader = cmdGetNewId.ExecuteReader();
                    while (reader.Read())
                    {
                        newIdDetailRentRoom = int.Parse(reader["MaCTPTP"].ToString());
                        break;
                    }
                }

                //them du lieu cho chi tiet phieu thue phong
                foreach (var item in customer_)
                {
                    cmdText = "INSERT INTO CHITIETPTP VALUES(@MaCTPTP, @MaPhieuThue, @TenKhachHang, @CMND, @DiaChi, @MaLoaiKhach)";
                    using (SqlCeCommand cmdInsertValueToDetailRentRoomTable = new SqlCeCommand(cmdText, connectionData))
                    {
                        int idTypeCustomer = 0;
                        newIdDetailRentRoom++;
                        cmdInsertValueToDetailRentRoomTable.Parameters.Add(new SqlCeParameter("MaCTPTP", newIdDetailRentRoom));
                        cmdInsertValueToDetailRentRoomTable.Parameters.Add(new SqlCeParameter("MaPhieuThue", newIdRentRoom));
                        cmdInsertValueToDetailRentRoomTable.Parameters.Add(new SqlCeParameter("TenKhachHang", item.name));
                        cmdInsertValueToDetailRentRoomTable.Parameters.Add(new SqlCeParameter("CMND", item.idCard));
                        cmdInsertValueToDetailRentRoomTable.Parameters.Add(new SqlCeParameter("DiaChi", item.adress));
                        string cmdText1 = "SELECT * FROM LOAIKHACH WHERE TenLoaiKhach = '" + item.typeCustomer + "'";
                        using (SqlCeCommand getIdTypeCustomer = new SqlCeCommand(cmdText1, connectionData))
                        {
                            SqlCeDataReader reader = getIdTypeCustomer.ExecuteReader();
                            while (reader.Read())
                            {
                                idTypeCustomer = int.Parse(reader["MaLoaiKhach"].ToString());
                            }
                            
                        }
                        cmdInsertValueToDetailRentRoomTable.Parameters.Add(new SqlCeParameter("MaLoaiKhach", idTypeCustomer));
                        cmdInsertValueToDetailRentRoomTable.ExecuteNonQuery();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //dong ket noi du lieu
            connectionData.Close();
        }

        /// <summary>
        /// xoa mot phieu thue phong
        /// </summary>
        /// <param name="idRentRoom_"></param>
        public void deleteRentRoom(int idRentRoom_)
        {
            try
            {
                //mo ket noi du lieu
                connectionData.Open();
            }
            catch { }

            try
            {
                //cap nhat lai tinh trang phong cho thue
                string cmdText = "SELECT * FROM PHIEUTHUEPHONG WHERE MaPTP = " + idRentRoom_;
                using (SqlCeCommand cmdGetStatusPay = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdGetStatusPay.ExecuteReader();
                    while (reader.Read())
                    {
                        int idRoom = int.Parse(reader["MaPhong"].ToString());
                        //neu phieu thue phong da thanh toan roi thi cap nhat lai tinh trang phong
                        string status = reader["DaThanhToan"].ToString();
                        if (status.ToUpper().Equals("CHUA"))
                        {
                            string cmdText1 = "UPDATE PHONG SET TinhTrang = 'Trong' WHERE MaPhong = " + idRoom;
                            using (SqlCeCommand cmdUpdateStatusRoom =
                                new SqlCeCommand(cmdText1, connectionData))
                            {
                                    cmdUpdateStatusRoom.ExecuteNonQuery();
                            }
                        }
                    }
                }

                //lay ma phong tu phieu thue phong can xoa
                cmdText = "SELECT MaPhong FROM PHIEUTHUEPHONG WHERE MaPTP = " + idRentRoom_;
                int idRoomForUpdate = 0;
                using (SqlCeCommand cmdGetIdRoom = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdGetIdRoom.ExecuteReader();
                    while (reader.Read())
                    {
                        idRoomForUpdate = int.Parse(reader["MaPhong"].ToString());
                    }
                }
                //xoa mot phieu thue phong trong bang PHIEUTHUEPHONG
                cmdText = "DELETE FROM PHIEUTHUEPHONG WHERE MaPTP = " + idRentRoom_;
                using (SqlCeCommand cmdDeleteRentRoom = new SqlCeCommand(cmdText, connectionData))
                {
                    cmdDeleteRentRoom.ExecuteNonQuery();
                }
                //xoa chi tiet cua phieu thue phong da chon
                cmdText = "DELETE FROM CHITIETPTP WHERE MaPhieuThue = " + idRentRoom_;
                using (SqlCeCommand cmdDeleteDetailRentRoom = new SqlCeCommand(cmdText,connectionData))
                {
                    cmdDeleteDetailRentRoom.ExecuteNonQuery();
                }

                
            }
            catch 
            {
                MessageBox.Show("Đã xảy ra lỗi\nKhông thể xóa phòng đã chọn","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            //dong ket noi
            connectionData.Close();
        }

        /// <summary>
        /// lay ma phieu thue phong bang ma phong
        /// </summary>
        /// <param name="idRoom_">ma phong</param>
        /// <returns>ma phieu thue moi nhat</returns>
        public static int getIdRentRoom(int idRoom_)
        {
            try
            {
                //mo ket noi du lieu
                connectionData.Open();
            }
            catch { }
            int idRentRoom = 0;
            string cmdText = "SELECT * FROM PHIEUTHUEPHONG WHERE MaPhong = " + idRoom_ + " ORDER BY MaPTP DESC ";
            using (SqlCeCommand cmdGetIdRentRoom = new SqlCeCommand(cmdText, connectionData))
            {
                try
                {
                    SqlCeDataReader reader = cmdGetIdRentRoom.ExecuteReader();
                    while (reader.Read())
                    {
                        idRentRoom = int.Parse(reader["MaPTP"].ToString());
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            return idRentRoom;
        }

        /// <summary>
        /// lay so ngay bat dau
        /// </summary>
        /// <param name="idRentRoom_">ma phieu thue phong</param>
        /// <returns>ngay bat dau thue phong</returns>
        public static string getStartDate(string idRentRoom_)
        {
            try
            {
                //mo ket noi du lieu
                connectionData.Open();
            }
            catch { }
            string startDate = "";
            string cmdText = "";
            cmdText = "SELECT NgayThue FROM PHIEUTHUEPHONG WHERE MaPTP = " + idRentRoom_;
            using (SqlCeCommand cmdGetStartDate = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader1 = cmdGetStartDate.ExecuteReader();
                while (reader1.Read())
                {
                    startDate = reader1["NgayThue"].ToString();
                }
            }
            return startDate;
        }

        /// <summary>
        /// lay ten loai khach theo ma loai khach
        /// </summary>
        /// <param name="idTypeCustomer_">ma loai khach</param>
        /// <returns>ten loai khach hang</returns>
        public static string getNameTypeCustomer(string idTypeCustomer_)
        {
            try
            {
                //mo ket noi du lieu
                connectionData.Open();
            }
            catch { }
            string nameTypeCustomer = "";
            string cmdText = "SELECT TenLoaiKhach FROM LOAIKHACH WHERE MaLoaiKhach = " + idTypeCustomer_;
            SqlCeCommand cmdGetNameTypeRoom = new SqlCeCommand(cmdText, connectionData);

            SqlCeDataReader reader = cmdGetNameTypeRoom.ExecuteReader();
            while (reader.Read())
            {
                nameTypeCustomer = reader["TenLoaiKhach"].ToString();
            }
            return nameTypeCustomer;
        }

        /// <summary>
        /// lay ma phong theo ten ma phieu thue phong
        /// </summary>
        /// <param name="idRentRoom_"></param>
        /// <returns></returns>
        public static int getIdRoom(int idRentRoom_)
        { 
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "SELECT * FROM PHIEUTHUEPHONG WHERE MaPTP = " + idRentRoom_;
            int idRoom = 0;
            using (SqlCeCommand cmdGetDatRentRoom = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetDatRentRoom.ExecuteReader();
                while (reader.Read())
                {
                    idRoom = (int)reader["MaPhong"];
                }
            }
            return idRoom;
        }
    }
}