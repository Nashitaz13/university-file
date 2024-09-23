
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
    /// tìm kiếm phòng theo tên
    /// </summary>
    public partial class SearchByRoom : UserControl
    {
        //SqlCeConnection connectionData;
        List<int> idTypeRoom;
        //ket qua tim kiem
        //List<ViewDataRoom> dataResult;
        public SearchByRoom()
        {
            InitializeComponent();
            //connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            //idTypeRoom = new List<int>();
            //dataResult = new List<ViewDataRoom>();
            Loaded += SearchByRoom_Loaded;
        }

        /// <summary>
        /// load ten cac loai phong man hinh tim kiem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SearchByRoom_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    connectionData.Open();
            //}
            //catch
            //{ }
            //try
            //{
            //    comboTypeRoom.Items.Clear();
            //}
            //catch
            //{ }
            //try
            //{
            //    string cmdText = "SELECT * FROM LOAIPHONG";
            //    using (SqlCeCommand cmdGetNameTypeRoom = new SqlCeCommand(cmdText, connectionData))
            //    {
            //        SqlCeDataReader reader = cmdGetNameTypeRoom.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            int id = int.Parse(reader["MaLoaiPhong"].ToString());
            //            idTypeRoom.Add(id);
            //            string item = reader["TenLoaiPhong"].ToString();
            //            this.comboTypeRoom.Items.Add(item);
            //        }
            //    }
            //}
            //catch
            //{ }
            //connectionData.Close();
        }

        /// <summary>
        /// xu ly su kien tim kiem phong theo loai phong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //DataListRoom dataListRoom = new DataListRoom();
            //dataResult = dataListRoom.searchRoomByTypeRoom(idTypeRoom.ElementAt(this.comboTypeRoom.SelectedIndex));
            //listRoom.ItemsSource = dataResult;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //DataListRoom dataListRoom = new DataListRoom();
            //dataResult = dataListRoom.searchRoomByTypeRoom(idTypeRoom.ElementAt(this.comboTypeRoom.SelectedIndex));
            //listRoom.ItemsSource = dataResult;
        }
    }
}
