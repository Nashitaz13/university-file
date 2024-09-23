using QuanLyKhachSan.ProcessData;
using QuanLyKhachSan.ViewData;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyKhachSan.View.Windows
{
    /// <summary>
    /// hien thi danh sach cac khach hang da thue phong
    /// </summary>
    public partial class DetailRoomRented : Window
    {
        //tao ket noi du lieu
        static SqlCeConnection connectionData;

        public DetailRoomRented()
        {
            InitializeComponent();
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            Loaded += DetailRoomRented_Loaded;
        }

        /// <summary>
        /// hien thi thong tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DetailRoomRented_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //mo ket noi
                connectionData.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối dữ liệu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //duyet bang chi tiet phieu thue phong
            string cmdText = "SELECT * FROM CHITIETPTP";
            using (SqlCeCommand cmdGetDetail = new SqlCeCommand(cmdText, connectionData))
            {
                //so thu tu
                int index = 1;
                SqlCeDataReader reader = cmdGetDetail.ExecuteReader();
                while (reader.Read())
                {
                    CustomerDetail item = new CustomerDetail();
                    item.index = index;
                    string idRentRoom = reader["MaPhieuThue"].ToString();
                    item.name = reader["TenKhachHang"].ToString();
                    item.idCard = reader["CMND"].ToString();
                    item.adress = reader["DiaChi"].ToString();
                    item.typeCustomer = DataRentRoom.getNameTypeCustomer(reader["MaLoaiKhach"].ToString());
                    //lay ma phong theo ma phieu thue phong
                    item.room = DataListRoom.getNameRoom(idRentRoom);
                    //lay ngay bat dau
                    item.startDate = DateTime.Parse(DataRentRoom.getStartDate(idRentRoom));
                    //lay so ngay thue
                    item.endDate = getEndDate(idRentRoom, item.startDate);
                    listCustomer.Items.Add(item);
                    index++;
                }
            }
            connectionData.Close();
        }

        /// <summary>
        /// lay ngay ket thuc thue phong
        /// </summary>
        /// <param name="idRentRoom">ma phieu thue phong</param>
        /// <returns></returns>
        private string getEndDate(string idRentRoom_, DateTime startDate_)
        {
            TimeSpan totalDay = new TimeSpan();
            string cmdText = "";
            cmdText = "SELECT SoNgayThue FROM CHITIETHD WHERE MaPTP = " + idRentRoom_;
            using (SqlCeCommand cmdGetEndDate = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader2 = cmdGetEndDate.ExecuteReader();
                while (reader2.Read())
                {
                    totalDay = TimeSpan.Parse(reader2["SoNgayThue"].ToString());
                }
            }
            //tinh ngay ket thuc
            DateTime endDate = startDate_.Add(totalDay);
            if (startDate_.Equals(endDate))
                return "";
            return endDate.ToString();
        }       
    }
}