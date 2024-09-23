using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SqlServerCe;
using System.Windows;
using System.Data;
using System.Windows.Media;
using QuanLyKhachSan.ViewData;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.ProcessData
{
    /// <summary>
    /// xử lý dữ liệu của danh sách phòng 
    /// bao gồm:
    /// thêm phòng
    /// xóa phòng
    /// cập nhật phòng
    /// </summary>
    public class DataListRoom
    {
        //chuoi ket noi du lieu
        public static SqlCeConnection connectionData;

        public DataListRoom()
        {
            //khoi tao chuoi ket noi
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
        }

        /// <summary>
        /// mo ket noi du lieu, hien thi toan bo thong tin len control listview cua cua so danh sach phong
        /// </summary>
        /// <param name="listRoom" >control tren cua so danh sach phong can hien thi</param>
        public void viewListRoom(ref ListView listRoom)
        {
            try
            {
                //xoa nhung item cu
                listRoom.Items.Clear();
            }
            catch
            { }
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            {
            }

            //khoi tao command truy van csdl
            SqlCeCommand dataCommand =
                new SqlCeCommand("SELECT * FROM PHONG ORDER BY MaPhong ASC", connectionData);
            try
            {
                //thuc hien truy van
                SqlCeDataReader reader = dataCommand.ExecuteReader();
                //so thu tu phong
                int indexRoom = 0;
                //doc ket qua truy van
                while (reader.Read())
                {
                    //khoi tao mot item cho listRoom
                    ViewDataRoom item = new ViewDataRoom();
                    indexRoom++;
                    item.indexRoom = indexRoom;
                    item.id = int.Parse(reader["MaPhong"].ToString());
                    item.nameRoom = reader["TenPhong"].ToString();
                    string idTypeRoom = reader["MaLoaiPhong"].ToString();
                    item.typeRoom = getNameTypeRoom(idTypeRoom);
                    item.price = getPriceRoom(idTypeRoom);
                    item.status = reader["TinhTrang"].ToString();
                    item.note = reader["GhiChu"].ToString();
                    //them item cho listRoom
                    listRoom.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Truy vấn cơ sở dữ liệu thất bại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connectionData.Close();
        }

        /// <summary>
        /// them mot phong moi vao csdl
        /// </summary>
        /// <param name="name_"> ten phong </param>
        /// <param name="typeRoom_">loai phong</param>
        /// <param name="price_">don gia phong</param>
        /// <param name="note_">ghi chu</param>
        public void addNewRoom(string name_,
            int typeRoom_,
            decimal price_,
            string note_)
        {
            //mo ket noi du lieu
            try
            {
                connectionData.Open();
            }
            catch { }

            try
            {
                //tao mot ma phong moi
                int newId = 0;
                //kiem tra trung lap voi ma phong cu
                string cmdText = "SELECT MaPhong FROM PHONG ORDER BY MaPhong DESC";
                //thuc hien truy van kiem tra cac ma phong trong csdl
                using (SqlCeCommand dataCommand = new SqlCeCommand(cmdText, connectionData))
                {

                    SqlCeDataReader reader = dataCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            //lay id cao nhat
                            newId = int.Parse(reader["MaPhong"].ToString());
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                //them du lieu
                using (SqlCeCommand dataCommand
                    = new SqlCeCommand("INSERT INTO PHONG VALUES(@MaPhong, @TenPhong, @MaLoaiPhong, @TinhTrang, @GhiChu)",
                        connectionData))
                {
                    dataCommand.Parameters.Add(new SqlCeParameter("MaPhong",newId + 1));
                    dataCommand.Parameters.Add(new SqlCeParameter("TenPhong", name_));
                    dataCommand.Parameters.Add(new SqlCeParameter("MaLoaiPhong", typeRoom_));
                    dataCommand.Parameters.Add(new SqlCeParameter("TinhTrang", "Trong"));
                    dataCommand.Parameters.Add(new SqlCeParameter("GhiChu", note_));
                    dataCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Không thể thêm phòng mới", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connectionData.Close();
        }

        /// <summary>
        /// cap nhat lai phong da co
        /// </summary>
        /// <param name="id_">ma phong</param>
        /// <param name="name_">ten phong</param>
        /// <param name="typeRoom_">loai phong</param>
        /// <param name="price_">don gia phong</param>
        /// <param name="note_">ghi chu</param>
        /// <param name="status_">tinh trang phong</param>
        public void updateRoom(int id_,  
            string name_, 
            int typeRoom_,
            decimal price_,
            string note_) 
        {
            try
            {
                connectionData.Open();
            }
            catch
            {
            }
            try
            {
                string cmdText = "UPDATE PHONG SET TenPhong = '" +
                    name_ + "', MaLoaiPhong = " +
                    typeRoom_ + ", GhiChu = '"+ note_+"' WHERE MaPhong = " + id_;
                using (SqlCeCommand dataCommand =
                    new SqlCeCommand(cmdText,
                        connectionData))
                {
                    dataCommand.ExecuteNonQuery();
                }
                
            }
            catch 
            {
                MessageBox.Show("Đã xảy ra lỗi\nKhông thể cập nhật phòng có mã phòng trên",
                    "Cập nhật phòng", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connectionData.Close();
        }

        /// <summary>
        /// xoa mot phong da co
        /// </summary>
        /// <param name="id_">id phong</param>
        /// <param name="name_">ten phong</param>
        public void deleteRoom(int id_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            {
            }
            try
            {
                using (SqlCeCommand dataCmd =
                    new SqlCeCommand("DELETE FROM PHONG WHERE MaPhong=" + id_ , connectionData)) 
                {
                    dataCmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi\nKhông thể xóa phòng có mã phòng trên",
                    "Xóa phòng", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connectionData.Close();
        }

        /// <summary>
        /// kiem tra xem phong duoc them vao co ton tai hay khong
        /// neu co thi cap nhat lai thong tin
        /// neu khong thi tao mot phong moi
        /// </summary>
        /// <param name="name_">ten phong</param>
        /// <param name="typeRoom_">loai phong</param>
        /// <param name="price_">don gia</param>
        /// <param name="status_">tinh trang</param>
        /// <param name="note_">ghi chu</param>
        public void testRoomExits(string name_, int typeRoom_, decimal price_, string note_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            {
            }
            try
            {
                string cmdText = "SELECT MaPhong FROM PHONG WHERE TenPhong = '" + name_ + "'";
                using (SqlCeCommand cmdReadData = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdReadData.ExecuteReader();
                    while (reader.Read())
                    {
                        updateRoom(int.Parse(reader["MaPhong"].ToString()), name_, typeRoom_, price_, note_);
                    }
                }

                addNewRoom(name_, typeRoom_, price_, note_);
            }
            catch
            { 

            }
            connectionData.Close();
        }

        /// <summary>
        /// tim kiem phong theo loai phong
        /// </summary>
        /// <param name="p">ma loai phong duoc chon</param>
        public List<ViewDataRoom> searchRoomByTypeRoom(int idTypeRoom_)
        {
            List<ViewDataRoom> dataResult = new List<ViewDataRoom>();
            try
            {
                connectionData.Open();
            }
            catch
            { }

            try
            {
                string cmdText = "SELECT * FROM PHONG WHERE MaLoaiPhong = " + idTypeRoom_;
                using (SqlCeCommand cmdSearch = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdSearch.ExecuteReader();
                    int index = 1;
                    while (reader.Read())
                    {
                        ViewDataRoom item = new ViewDataRoom();
                        item.indexRoom = index;
                        item.id = int.Parse(reader["MaPhong"].ToString());
                        item.nameRoom = reader["TenPhong"].ToString();
                        //lay ten loai phong va don gia
                        cmdText = "SELECT * FROM LOAIPHONG WHERE MaLoaiPhong = " + reader["MaLoaiPhong"].ToString();
                        using (SqlCeCommand cmdGetPriceAndNameTypeRoom = new SqlCeCommand(cmdText, connectionData))
                        {
                            SqlCeDataReader reader1 = cmdGetPriceAndNameTypeRoom.ExecuteReader();
                            while (reader1.Read())
                            {
                                item.typeRoom = reader1["TenLoaiPhong"].ToString();
                                item.price = decimal.Parse(reader1["DonGia"].ToString());
                            }
                        }
                        item.status = reader["TinhTrang"].ToString();
                        dataResult.Add(item);
                        index++;
                    }
                }
            }
            catch
            { }
            connectionData.Close();
            return dataResult;
        }

        public List<ViewDataRoom> searchByTime(DateTime startTime_, DateTime endTime_)
        {
            List<ViewDataRoom> dataResult = new List<ViewDataRoom>();
            try
            {
                connectionData.Open();
            }
            catch
            { }
            try
            { 
                //truy cap bang phieu thue phong lay ma phong da duoc thue trong thoi gian dua vao
                string cmdText = "SELECT * FROM PHIEUTHUEPHONG";
                using (SqlCeCommand cmdGetIdRoomInDates = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdGetIdRoomInDates.ExecuteReader();
                    while (reader.Read())
                    {
                        string idRoom = reader["MaPhong"].ToString();
                        DateTime dateInData = DateTime.Parse(reader["NgayThue"].ToString());
                        if ((dateInData >= startTime_) && (dateInData <= endTime_)) 
                        {
                            //truy van bang phong theo ma phong vua nhan duoc
                            cmdText = "SELECT * FROM PHONG WHERE MaPhong = " + idRoom;
                            using (SqlCeCommand cmdGetNameRoom = new SqlCeCommand(cmdText, connectionData))
                            {
                                int index = 1;
                                SqlCeDataReader reader1 = cmdGetNameRoom.ExecuteReader();
                                while (reader1.Read())
                                {
                                    ViewDataRoom item = new ViewDataRoom();
                                    item.indexRoom = index;
                                    item.id = int.Parse(idRoom);
                                    item.nameRoom = reader1["TenPhong"].ToString();
                                    string idTypeRoom = "";
                                    idTypeRoom = reader1["MaLoaiPhong"].ToString();
                                    item.price = getPriceRoom(idTypeRoom);
                                    item.typeRoom = getNameTypeRoom(idTypeRoom);
                                    item.status = reader1["TinhTrang"].ToString();
                                    dataResult.Add(item);
                                    index++;
                                }
                            }
                        }
                            
                    }
                }
            }
            catch
            { }
            connectionData.Close();
            return dataResult;
        }

        /// <summary>
        /// lay ten loai phong
        /// </summary>
        /// <param name="idTypeRoom_">ma loai phong can lay ten</param>
        /// <returns>ten loai phong</returns>
        public static string getNameTypeRoom(string idTypeRoom_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string name = "";
            using (SqlCeCommand getDataTypeRoom =
                        new SqlCeCommand("SELECT TenLoaiPhong FROM LOAIPHONG WHERE MaLoaiPhong = " + idTypeRoom_,
                            connectionData))
            {
                //try cap bang loai phong
                SqlCeDataReader getNameTypeRoom = getDataTypeRoom.ExecuteReader();
                while (getNameTypeRoom.Read())
                {
                    name = getNameTypeRoom["TenLoaiPhong"].ToString();
                }
            }
            return name;
        }

        /// <summary>
        /// lay gia cua loai phong
        /// </summary>
        /// <param name="idTypeRoom_">ma loai phong can lay gia</param>
        /// <returns>gia cua loai phong</returns>
        public static decimal getPriceRoom(string idTypeRoom_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            decimal price = 0;
            using (SqlCeCommand getDataTypeRoom =
                        new SqlCeCommand("SELECT * FROM LOAIPHONG WHERE MaLoaiPhong = " + idTypeRoom_,
                            connectionData))
            {
                //try cap bang loai phong
                SqlCeDataReader getNameTypeRoom = getDataTypeRoom.ExecuteReader();
                while (getNameTypeRoom.Read())
                {
                    price = decimal.Parse(getNameTypeRoom["DonGia"].ToString());
                }
            }
            return price;
        }

        /// <summary>
        /// lay ma phong theo ten phong
        /// </summary>
        /// <param name="nameRoom_">ten phong</param>
        /// <returns>ma phong</returns>
        public static int getIdRoom(string nameRoom_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            int idRoom = 0;
            string cmdText = "SELECT * FROM PHONG WHERE TenPhong = " + nameRoom_;
            using (SqlCeCommand cmdGetIdRoom = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetIdRoom.ExecuteReader();
                while(reader.Read())
                {
                    idRoom = int.Parse(reader["MaPhong"].ToString());
                }
            }
            return idRoom;
        }

        /// <summary>
        /// lay ma loai phong theo ma phong
        /// </summary>
        /// <param name="idRoom_">ma phong</param>
        /// <returns>ma loai phong</returns>
        public static int getIdTypeRoom(string idRoom_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            int idTypeRoom = 0;
            string cmdText = "SELECT * FROM PHONG WHERE MaPhong = " + idRoom_;
            using (SqlCeCommand cmdGetIdTypeRoom = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetIdTypeRoom.ExecuteReader();
                while (reader.Read())
                {
                    idTypeRoom = int.Parse(reader["MaLoaiPhong"].ToString());
                }
            }
            return idTypeRoom;
        }

        /// <summary>
        /// lay ten phong
        /// </summary>
        /// <param name="idRoomRented_">ma chi tiet phieu thue phong</param>
        /// <returns>ten phong duoc thue</returns>
        public static string getNameRoom(string idRoomRented_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string nameRoom = "";
            string cmdText = "";
            cmdText = "SELECT MaPhong FROM PHIEUTHUEPHONG WHERE MaPTP = " +
                        idRoomRented_;
            using (SqlCeCommand cmdGetIdRoom = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader1 = cmdGetIdRoom.ExecuteReader();
                while (reader1.Read())
                {
                    //ten phong theo ma phong
                    cmdText = "SELECT TenPhong FROM PHONG WHERE MaPhong = " + reader1["MaPhong"].ToString();
                    using (SqlCeCommand cmdGetNameRoom = new SqlCeCommand(cmdText, connectionData))
                    {
                        SqlCeDataReader reader2 = cmdGetNameRoom.ExecuteReader();
                        while (reader2.Read())
                        {
                            nameRoom = reader2["TenPhong"].ToString();
                        }
                    }
                }
            }
            return nameRoom;
        }
    }
}
