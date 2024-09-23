using QuanLyKhachSan.ViewData;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QuanLyKhachSan.ProcessData
{
    /// <summary>
    /// xử lý dữ liệu báo cáo
    /// lưu bao cao
    /// xoa bao cao
    /// </summary>
    public class DataReport
    {
        SqlCeConnection connectionData;

        public DataReport()
        {
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
        }

        /// <summary>
        /// luu mot bao cao moi vao csdl
        /// </summary>
        /// <param name="dateBuild_">ngay lap bao cao</param>
        /// <param name="nameReport_">ten bao cao</param>
        public void addNewReport(DateTime dateBuild_, string nameReport_, ref ListView listView_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            //lay ngay bat dau 
            DateTime startDate = getStartDate();
            //tao mot id moi
            int newId = 0;
            string cmdText = "SELECT MaBaoCao FROM BAOCAODOANHTHU ORDER BY MaBaoCao DESC";
            using (SqlCeCommand cmdGetNewId = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetNewId.ExecuteReader();
                while (reader.Read())
                {
                    newId = int.Parse(reader["MaBaoCao"].ToString());
                    break;
                }
            }

            cmdText = "INSERT INTO BAOCAODOANHTHU VALUES(@MaBaoCao, @TenBaoCao, @NgayLap, @ThangBaoCao)";
            using (SqlCeCommand cmdInsertValue = new SqlCeCommand(cmdText, connectionData))
            {
                newId++;
                cmdInsertValue.Parameters.Add(new SqlCeParameter("MaBaoCao", newId));
                cmdInsertValue.Parameters.Add(new SqlCeParameter("TenBaoCao", nameReport_));
                cmdInsertValue.Parameters.Add(new SqlCeParameter("NgayLap", dateBuild_));
                cmdInsertValue.Parameters.Add(new SqlCeParameter("ThangBaoCao", dateBuild_.Month));
                cmdInsertValue.ExecuteNonQuery();
            }
            addNewDetailReport(newId, dateBuild_, ref listView_, startDate);
            connectionData.Close();
        }

        /// <summary>
        /// them mot chi tiet bao cao doanh thu moi
        /// </summary>
        /// <param name="idReport_">ma bao cao doanh thu</param>
        private void addNewDetailReport(int idReport_, DateTime dateBuild_, ref ListView listView_, DateTime startDate_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            //tao mot ma chi tiet bao cao moi
            string cmdText = "SELECT MaCTBCDT FROM CHITIETBAOCAODOANHTHU ORDER BY MaCTBCDT DESC";
            int newIdDetail = 0;
            using (SqlCeCommand cmdGetId = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetId.ExecuteReader();
                while (reader.Read())
                {
                    newIdDetail = (int)reader["MaCTBCDT"];
                    break;
                }
            }
            //danh sach nhung hoa don trong thang
            List<ViewDataBill> billInMonth = getAllDataBill(dateBuild_, startDate_);
            //danh sach cac loai phong
            List<int> idTypeRoom = getAllIdTypeRoom();
            //thu tu hien thi tren listview 
            int index =0;
            foreach (var item in idTypeRoom)
            {
                cmdText = "INSERT INTO CHITIETBAOCAODOANHTHU VALUES(@MaCTBCDT, @MaBaoCao, @MaLoaiPhong, @DoanhThu, @TyLe)";
                using (SqlCeCommand cmdInsertValue = new SqlCeCommand(cmdText, connectionData))
                {
                    newIdDetail++;
                    index++;
                    ViewDetailReport data = new ViewDetailReport();
                    data.index = index;
                    data.idDetailRepport = newIdDetail;
                    data.idReport = idReport_;
                    data.idTypeRoom = item;
                    data.totalMoney = getToTalMoney(item,billInMonth);
                    data.percent = calculatPercent(data.totalMoney,billInMonth);
                    data.nameTypeRoom = DataListRoom.getNameTypeRoom(data.idTypeRoom.ToString());
                    cmdInsertValue.Parameters.Add(new SqlCeParameter("MaCTBCDT", newIdDetail));
                    cmdInsertValue.Parameters.Add(new SqlCeParameter("MaBaoCao", idReport_));
                    cmdInsertValue.Parameters.Add(new SqlCeParameter("MaLoaiPhong", item));
                    cmdInsertValue.Parameters.Add(new SqlCeParameter("DoanhThu", data.totalMoney));
                    cmdInsertValue.Parameters.Add(new SqlCeParameter("TyLe", data.percent));
                    cmdInsertValue.ExecuteNonQuery();
                    listView_.Items.Add(data);
                }
            }
            connectionData.Close();
            
        }

        /// <summary>
        /// tinh ti le doanh thu theo loai phong
        /// </summary>
        /// <param name="moneyOfTypeRoom_">doanh thu cua loai phong can tinh</param>
        /// <param name="billInMonth_">tong doanh thu khach san</param>
        /// <returns>ty le</returns>
        private float calculatPercent(decimal moneyOfTypeRoom_, List<ViewDataBill> billInMonth_)
        {
            decimal totalMoney = 0;
            foreach (var item in billInMonth_)
            {
                totalMoney += item.totalMoney;
            }
            decimal percent = 0;
            try
            {
                percent = (moneyOfTypeRoom_ / totalMoney) * 100;
            }
            catch
            { }
            return (float)percent;
        }

        /// <summary>
        /// lay danh sach nhung hoa don trong thang bao cao
        /// </summary>
        /// <param name="dateBuild_">ngay lap bao cao</param>
        /// <returns>danh sach nhung hoa don</returns>
        private List<ViewDataBill> getAllDataBill(DateTime dateBuild_, DateTime startDate_)
        {
            //lay ngay bat dau
            List<ViewDataBill> data = new List<ViewDataBill>();
            string cmdText = "SELECT * FROM HOADON";
            using (SqlCeCommand cmdGetValue = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetValue.ExecuteReader();
                while (reader.Read())
                {
                    DateTime value = DateTime.Parse(reader["NgayLap"].ToString());
                    if (value >= startDate_ && value <= dateBuild_)
                    {
                        ViewDataBill item = new ViewDataBill();
                        item.id = reader["MaHoaDon"].ToString();
                        item.totalMoney = (decimal)reader["TriGia"];
                        data.Add(item);
                    }                    
                }
            }
            return data;
        }

        /// <summary>
        /// lay tong doanh thu cua loai phong can tinh
        /// </summary>
        /// <param name="idTypeRoom_">loai phong</param>
        /// <param name="billInMonth_">nhung hoa don trong thang can lap bao cao</param>
        /// <returns>doanh thu cua phong do</returns>
        private decimal getToTalMoney(int idTypeRoom_, List<ViewDataBill> billInMonth_)
        {
            decimal money = 0;
            //duyet tung hoa don
            foreach (var item in billInMonth_)
            {
                //lay ma phieu thue phong theo hoa don
                string cmdText = "SELECT * FROM CHITIETHD WHERE MaHoaDon = " + item.id;
                using (SqlCeCommand cmdGetIdRentRoom = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdGetIdRentRoom.ExecuteReader();
                    while (reader.Read())
                    {
                        //kiem tra loai phong trong phieu thue
                        if (testId(reader["MaPTP"].ToString(), idTypeRoom_) == true)
                            //tinh doanh thu cho loai phong dua vao
                            money += (decimal)reader["TriGia"];
                    }
                }                
            }
            return money;
        }

        /// <summary>
        /// kiem tra loai phong trong phieu thue phong dua vao co trung voi loai phong dua vao k
        /// </summary>
        /// <param name="idRentRoom_">ma phieu thue phong dua vao</param>
        /// <param name="idTypeRoom_">ma loai phong dua vao</param>
        /// <returns>true neu la trung khop</returns>
        private Boolean testId(string idRentRoom_, int idTypeRoom_)
        {
            int idRoom = DataRentRoom.getIdRoom(int.Parse(idRentRoom_));
            if (idTypeRoom_ == DataListRoom.getIdTypeRoom(idRoom.ToString()))
                return true;
            return false;
        }

        /// <summary>
        /// lay ma cac loai phong
        /// </summary>
        /// <returns>danh sach ma phong</returns>
        private List<int> getAllIdTypeRoom()
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText;
            cmdText = "SELECT MaLoaiPhong FROM LOAIPHONG";
            List<int> id = new List<int>();
            using (SqlCeCommand cmdGetIdTypeRoom = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetIdTypeRoom.ExecuteReader();
                while (reader.Read())
                {
                    id.Add((int)reader["MaLoaiPhong"]);
                }
            }
            return id;
        }

        /// <summary>
        /// lay ngay lap bao cao lan truoc
        /// </summary>
        /// <returns>ngay lap bao cao lan truoc</returns>
        public DateTime getStartDate()
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string getDate = "";
            string cmdTetx = "SELECT * FROM BAOCAODOANHTHU ORDER BY MaBaoCao DESC";
            using (SqlCeCommand cmdGetStartDate = new SqlCeCommand(cmdTetx, connectionData))
            {
                SqlCeDataReader reader = cmdGetStartDate.ExecuteReader();
                while (reader.Read())
                {
                    getDate = reader["NgayLap"].ToString();
                    break;
                }
            }
            return DateTime.Parse(getDate);
        }

        public void viewData(ref ListView listView)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            try
            {
                listView.Items.Clear();
            }
            catch
            { }
            string cmdText = "SELECT * FROM BAOCAODOANHTHU";
            using (SqlCeCommand cmdGetValue = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetValue.ExecuteReader();
                while (reader.Read())
                {
                    ViewDataReport dataReport = new ViewDataReport();
                    dataReport.idReport = (int)reader["MaBaoCao"];
                    dataReport.nameReport = reader["TenBaoCao"].ToString();
                    dataReport.dateBuil = (DateTime)reader["NgayLap"];
                    dataReport.month = (int)reader["ThangBaoCao"];
                    listView.Items.Add(dataReport);
                }
            }
            connectionData.Close();
        }
    }
}