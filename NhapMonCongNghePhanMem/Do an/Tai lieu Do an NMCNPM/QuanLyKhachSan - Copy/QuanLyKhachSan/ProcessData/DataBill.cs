using QuanLyKhachSan.View.Windows;
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
    /// xử lý dữ liệu của việc lập hóa đơn, lưu hóa đơn, xuất hóa đơn
    /// </summary>
    public class DataBill
    {
        SqlCeConnection connectionData;
        public DataBill()
        {
            connectionData = 
                new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
        }

        /// <summary>
        /// hien thi du lieu len list view
        /// </summary>
        /// <param name="listBill_">noi hien thi</param>
        public void viewAllData(ref ListView listBill_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            try
            {
                //duyet bang hoa don
                string cmdText = "SELECT * FROM HOADON";
                using (SqlCeCommand cmdViewBill = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdViewBill.ExecuteReader();
                    while (reader.Read())
                    {
                        //tao mot item moi
                        ViewDataBill item = new ViewDataBill();
                        item.id = reader["MaHoaDon"].ToString();
                        item.nameCustomer = reader["TenKhachHang"].ToString();
                        item.date = DateTime.Parse(reader["NgayLap"].ToString());
                        item.totalMoney = decimal.Parse(reader["TriGia"].ToString());
                        //them vao list view
                        listBill_.Items.Add(item);
                    }
                }
            }
            catch
            { }
            //dong ket noi
            connectionData.Close();
        }

        /// <summary>
        /// lay thong tin tung phong
        /// </summary>
        /// <param name="nameRoom_">danh sach ten phong</param>
        /// <param name="dateBuild_">ngay lap hoa don</param>
        /// <returns>danh sach chi tiet cac phong</returns>
        public ViewRoomInBill getValue(string nameRoom_, DateTime dateBuild_, float discount_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            //danh sach nhung phong trong hoa don
            ViewRoomInBill dataRoom = new ViewRoomInBill();
            //lay id phong theo ten
            dataRoom.idRoom = DataListRoom.getIdRoom(nameRoom_);
            //luu lai ten phong
            dataRoom.nameRoom = nameRoom_;
            //lay gia phong
            dataRoom.price = DataListRoom.getPriceRoom(
                DataListRoom.getIdTypeRoom((dataRoom.idRoom).ToString()).ToString());
            //lay ma phieu thue phong
            dataRoom.idRentRoom = DataRentRoom.getIdRentRoom(dataRoom.idRoom);
            //tinh so ngay thue
            dataRoom.totalDate = getTotalDay(dateBuild_, dataRoom.idRentRoom);
            //tong so khach hang trong phong
            dataRoom.totalCustomer = getTotalCustomer(dataRoom.idRentRoom);
            //tinh tong gia tri moi phong
            dataRoom.totalMoneyNeedToPay = getTotalMoney(dataRoom.idRentRoom,
                dataRoom.price,
                dataRoom.totalDate,
                dataRoom.totalCustomer, discount_);
            return dataRoom;
        }

        /// <summary>
        /// them mot hoa don moi
        /// </summary>
        public void addNewBill(string nameCustomer_, 
            DateTime dateBuild_,
            string adress_,
            List<string> nameRoom_,
            float discount_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            List<ViewRoomInBill> roomInBill = new List<ViewRoomInBill>();

            foreach (var item in nameRoom_)
            {
                roomInBill.Add(getValue(item, dateBuild_, discount_));
            }
            //tao ma hoa don moi 
            string cmdText;
            int newIdBill = 0;
            cmdText = "SELECT MaHoaDon FROM HOADON ORDER BY MaHoaDon DESC";
            using (SqlCeCommand cmdGetNewIdBill = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetNewIdBill.ExecuteReader();
                while (reader.Read())
                {
                    newIdBill = int.Parse(reader["MaHoaDon"].ToString());
                    break;
                }
            }
            newIdBill++;
            //tinh tong tri gia
            decimal totalMoney = 0;
            foreach (var item in roomInBill)
            {
                //them mot chi tiet hoa don moi
                addNewDetailBill(newIdBill, item, item.totalMoneyNeedToPay);
                totalMoney += item.totalMoneyNeedToPay;
            }
            //them vao csdl
            cmdText = "INSERT INTO HOADON VALUES(@MaHoaDon, @TenKhachHang, @NgayLap, @TriGia, @DiaChi)";
            using (SqlCeCommand cmdInsertNewBill = new SqlCeCommand(cmdText, connectionData))
            {
                cmdInsertNewBill.Parameters.Add(new SqlCeParameter("MaHoaDon", newIdBill));
                cmdInsertNewBill.Parameters.Add(new SqlCeParameter("TenKhachHang",nameCustomer_));
                cmdInsertNewBill.Parameters.Add(new SqlCeParameter("NgayLap",dateBuild_));
                cmdInsertNewBill.Parameters.Add(new SqlCeParameter("TriGia",totalMoney));
                cmdInsertNewBill.Parameters.Add(new SqlCeParameter("DiaChi", adress_));
                try
                {
                    cmdInsertNewBill.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            foreach (var item in roomInBill)
            {
                cmdText = "UPDATE PHONG SET TinhTrang = 'Trong' WHERE MaPhong = " + item.idRoom;
                using (SqlCeCommand cmdUpdateRoom = new SqlCeCommand(cmdText, connectionData))
                {
                    cmdUpdateRoom.ExecuteNonQuery();
                }
            }
            
            connectionData.Close();
        }

        /// <summary>
        /// lay tong so khach trong phong
        /// </summary>
        /// <param name="idRentRoom_">ma phong</param>
        /// <returns>tong so khach</returns>
        private int getTotalCustomer(int idRentRoom_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            int totalCustomer = 0;
            string cmdText = "SELECT * FROM PHIEUTHUEPHONG WHERE MaPTP = " + idRentRoom_;
            using (SqlCeCommand cmdGetTotalCustomer = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetTotalCustomer.ExecuteReader();
                while (reader.Read())
                {
                    totalCustomer = int.Parse(reader["SoLuong"].ToString());
                }
            }
            return totalCustomer;
        }

        /// <summary>
        /// tinh tong tien cho moi phong 
        /// </summary>
        /// <param name="idRentRoom_">ma phieu thue phong</param>
        /// <param name="price_">gia phong</param>
        /// <param name="totalDate_">tong ngay thue</param>
        /// <returns>tong tien cho 1 phong</returns>
        private decimal getTotalMoney(int idRentRoom_,
            decimal price_,
            int totalDate_, 
            int totalCustomer_,
            float discount_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            decimal totalMoney = 0;
            Boolean overlow = false;
            Boolean foreignVisitors = false;
            int maxCustomer = 0;
            //kiem tra so khach toi da
            string cmdText = "SELECT * FROM THAMSO WHERE MaThamSo = " + 1;
            using (SqlCeCommand cmdGetMaxCustomer = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetMaxCustomer.ExecuteReader();
                while (reader.Read())
                {
                    maxCustomer = int.Parse(reader["GiaTri"].ToString());
                }
            }
            //kiem tra co qua so luong hay khong,co khach nuoc ngoai hay khong 
            if (maxCustomer < totalCustomer_)
                overlow = true;
            int idTypeCustomer = 0;
            foreignVisitors = testTypeCustomer(idRentRoom_, ref idTypeCustomer);
            //tinh tong tien cho 1 phong
            totalMoney = totalDate_ * price_;
            if (overlow == true)
                totalMoney = getTotalMoneyWhileOverlow(totalMoney);
            if (foreignVisitors == true)
                totalMoney = getTotalMoneyWhileHaveMoreTypeCustomer(totalMoney, idTypeCustomer);
            if (discount_ > 0)
                totalMoney = totalMoney - totalMoney * ((decimal)discount_ / 100);
            return totalMoney;
        }

        /// <summary>
        /// tinh tong tien khi co nhieu loai khach trong 1 phong
        /// </summary>
        /// <param name="totalMoney">tong tien chua nhan he so</param>
        /// <returns>tong tien da nhan he so</returns>
        private decimal getTotalMoneyWhileHaveMoreTypeCustomer(decimal totalMoney_, int typeCustomer_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            decimal coefficient = 0;
            string cmdText = "SELECT * FROM LOAIKHACH WHERE MaLoaiKhach = " + typeCustomer_;
            using (SqlCeCommand cmdGetCoefficient = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetCoefficient.ExecuteReader();
                while (reader.Read())
                {
                    coefficient = decimal.Parse(reader["TiLePhuThu"].ToString());
                }
            }
            return totalMoney_ * coefficient;
        }

        /// <summary>
        /// tinh tong tien khi so khach trong phong vuot qua so luong 
        /// </summary>
        /// <param name="totalMoney_">so tien ban dau</param>
        /// <returns>tong tien sau khi nhan he so</returns>
        private decimal getTotalMoneyWhileOverlow(decimal totalMoney_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            decimal coefficient = 0;
            string cmdText = "SELECT * FROM THAMSO WHERE MaThamSo = 2";
            using (SqlCeCommand cmdGetCoefficient = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetCoefficient.ExecuteReader();
                while (reader.Read())
                {
                    coefficient = decimal.Parse(reader["GiaTri"].ToString());
                }
            }
            return totalMoney_ * (1 + coefficient);
        }

        /// <summary>
        /// kiem tra co khach nuoc ngoai hay k
        /// </summary>
        /// <param name="idRentRoom_">ma phieu thue phong</param>
        /// <returns>true neu co</returns>
        private bool testTypeCustomer(int idRentRoom_,ref int idTypeCustomer_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "SELECT * FROM CHITIETPTP WHERE MaPhieuThue = " + idRentRoom_;
            using (SqlCeCommand cmdGetTypeCustomer = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetTypeCustomer.ExecuteReader();
                while (reader.Read())
                {
                    idTypeCustomer_ = int.Parse(reader["MaLoaiKhach"].ToString());
                    string nameTypeRoom = 
                        DataRentRoom.getNameTypeCustomer(idTypeCustomer_.ToString());
                    nameTypeRoom = nameTypeRoom.Replace(" ", "");
                    if (nameTypeRoom.ToUpper().Equals("NUOCNGOAI"))
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// tinh tong so ngay thue
        /// </summary>
        /// <param name="dateBuild_">ngay lap hoa don</param>
        /// <param name="idRentRoom_">ma phieu thue phong</param>
        /// <returns>tong so ngay thue</returns>
        private int getTotalDay(DateTime dateBuild_, int idRentRoom_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            float totalDay = 0;
            DateTime startDate = DateTime.Parse(DataRentRoom.getStartDate(idRentRoom_.ToString()));
            //khoang cach giua ngay thue va ngay lap hoa don
            string[] space = ((dateBuild_.Subtract(startDate)).ToString()).Trim().Split('.');
            try
            {
                totalDay = float.Parse(space[0]);
            }
            catch { }
            if (totalDay == 0)
                return 1;
            string[] hour = space[2].Trim().Split(':');
            if (int.Parse(hour[0]) > 0)
                totalDay += 1;
            return (int)totalDay;
        }

        

        /// <summary>
        /// them chi tiet cho mot hoa don moi
        /// </summary>
        /// <param name="idBill_">ma hoa don</param>
        /// <param name="dateBuild_">ngay lap</param>
        /// <param name="idRentRoom_">ma phieu thue phong</param>
        public void addNewDetailBill(int idBill_, 
            ViewRoomInBill room_, 
            decimal totalMoneyOneRoom_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
                //tao ma chi tiet hoa don moi
                int newIdDetailBill = 0;
                string cmdText = "SELECT MaCTHD FROM CHITIETHD ORDER BY MaCTHD DESC";
                using (SqlCeCommand cmdCaculatorNewId = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdCaculatorNewId.ExecuteReader();
                    while (reader.Read())
                    {
                        newIdDetailBill = int.Parse(reader["MaCTHD"].ToString());
                        break;
                    }
                }
                cmdText = "INSERT INTO CHITIETHD VALUES(@MaCTHD, @MaHoaDon, @SoNgayThue, @MaPTP, @TriGia)";
                using (SqlCeCommand cmdInsertValues = new SqlCeCommand(cmdText, connectionData))
                {
                    newIdDetailBill++;
                    cmdInsertValues.Parameters.Add(new SqlCeParameter("MaCTHD", newIdDetailBill));
                    cmdInsertValues.Parameters.Add(new SqlCeParameter("MaHoaDon", idBill_));
                    cmdInsertValues.Parameters.Add(new SqlCeParameter("SoNgayThue", room_.totalDate));
                    cmdInsertValues.Parameters.Add(new SqlCeParameter("MaPTP", room_.idRentRoom));
                    cmdInsertValues.Parameters.Add(new SqlCeParameter("TriGia", room_.totalMoneyNeedToPay));
                    cmdInsertValues.ExecuteNonQuery();
                }
        }

        /// <summary>
        /// xoa mot hoa don
        /// </summary>
        /// <param name="selectedItem_">hoa don da chon</param>
        public void deleteBill(ViewDataBill selectedItem_)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            { }
            try
            {
                //xoa khoi bang hoa don
                string cmdText = "DELETE FROM HOADON WHERE MaHoaDon = " + selectedItem_.id;
                try
                {
                    using (SqlCeCommand cmdDeleteBill = new SqlCeCommand(cmdText, connectionData))
                    {
                        //thuc thi lenh xoa
                        cmdDeleteBill.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa dữ liệu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //xoa khoi bang chi tiet hoa don
                cmdText = "DELETE FROM CHITIETHD WHERE MaHoaDon = " + selectedItem_.id;
                try
                {
                    using (SqlCeCommand cmdDeleteDetailBill = new SqlCeCommand(cmdText, connectionData))
                    {
                        cmdDeleteDetailBill.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa dữ liệu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            { }
            connectionData.Close();
        }
    }
}