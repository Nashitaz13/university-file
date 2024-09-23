using System;
using System.Collections.Generic;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLKS2014.GUI.StupidContent
{
    /// <summary>
    /// thêm phòng mới hoặc cập nhật lại nếu phòng đã tồn tại
    /// </summary>
    public partial class UpdateRoom : UserControl
    {
        public string roomName;
        public int roomType ;
        public decimal price;
        public string note;
        public Boolean ready = false;
        //public Boolean finish = false;
        public UpdateRoom()
        {
            InitializeComponent();
            Loaded += UpdateRoom_Loaded;
        }

        void UpdateRoom_Loaded(object sender, RoutedEventArgs e)
        {
            loadTypeRoom();
        }

        private void btnUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                roomName = this.txtbRoomName.Text;
                roomType = selectIdTypeRoom();
                price = decimal.Parse(this.lbPriceRoom.Content.ToString());
                note = this.txtbNote.Text;
                ready = true;
            }
            catch
            {
                MessageBox.Show("Lỗi nhập dữ liệu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.txtbNote.Text = "";
            this.txtbRoomName.Text = "";
        }

        public void loadTypeRoom()
        {

            ////tao ket noi du lieu
            //SqlCeConnection conectData =
            //        new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            //try
            //{
            //    //mo ket noi du lieu
            //    conectData.Open();
            //}
            //catch { }

            //try
            //{
            //    //chuoi command, lay ten loai phong
            //    string cmdText = "SELECT TenLoaiPhong FROM LOAIPHONG";
            //    using (SqlCeCommand cmdData = new SqlCeCommand(cmdText, conectData))
            //    {
            //        //doc tung dong tra ve
            //        SqlCeDataReader reader = cmdData.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            //them item cho combobox loai phong
            //            string itemTypeRoom = reader["TenLoaiPhong"].ToString();
            //            this.cmbTypeRoom.Items.Add(itemTypeRoom);
            //        }
            //    }
            //}
            //catch { }
            ////dong ket noi
            //conectData.Close();
        }

        public int selectIdTypeRoom()
        {
            //SqlCeConnection conectData =
            //        new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            //try
            //{
            //    conectData.Open();
            //}
            //catch { }

            //try
            //{
            //    string cmdText = "SELECT * FROM LOAIPHONG WHERE TenLoaiPhong = '" +
            //        this.cmbTypeRoom.SelectedItem.ToString() + "'";
            //    using (SqlCeCommand cmdData = new SqlCeCommand(cmdText, conectData))
            //    {
            //        SqlCeDataReader reader = cmdData.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            return int.Parse(reader["MaLoaiPhong"].ToString());
            //        }
            //    }
            //}
            //catch
            //{

            //}
            //conectData.Close();
            return 0;
        }

        public void selectPriceRoom()
        {
            //SqlCeConnection conectData =
            //        new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            //try
            //{
            //    conectData.Open();
            //}
            //catch { }

            //try
            //{
            //    string cmdText = "SELECT * FROM LOAIPHONG WHERE TenLoaiPhong = '" +
            //        this.cmbTypeRoom.SelectedItem.ToString() + "'";
            //    using (SqlCeCommand cmdData = new SqlCeCommand(cmdText, conectData))
            //    {
            //        SqlCeDataReader reader = cmdData.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            string item = reader["DonGia"].ToString();
            //            this.lbPriceRoom.Content = item;
            //        }
            //    }
            //}
            //catch
            //{

            //}
            //conectData.Close();
        }

        private void cbbRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.lbPriceRoom.Content = "";
            selectPriceRoom();
        }

        private void UpdateRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    roomName = txtbRoomName.Text;
                    roomType = selectIdTypeRoom();
                    price = decimal.Parse(this.lbPriceRoom.Content.ToString());
                    note = this.txtbNote.Text;
                    ready = true;
                }
                catch
                {
                    MessageBox.Show("Lỗi nhập dữ liệu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                this.txtbNote.Text = "";
                this.txtbRoomName.Text = "";
            }
        }

        private void txtbRoomName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}