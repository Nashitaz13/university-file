﻿using QuanLyKhachSan.ProcessData;
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
    /// Interaction logic for ListRentRoom.xaml
    /// </summary>
    public partial class ListRentRoom : Window
    {
        //chuoi ket noi du lieu
        public SqlCeConnection connectionData;
        DataRentRoom data;

        public ListRentRoom()
        {
            InitializeComponent();
            //khoi tao chuoi ket noi
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            data = new DataRentRoom();
            Loaded += ListRentRoom_Loaded;
        }

        void ListRentRoom_Loaded(object sender, RoutedEventArgs e)
        {
            data.viewAllData(ref this.listRentRoom);   
        }

        private void listRentRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                try
                {
                    if (DataUser.userName == "Admin")
                    {
                        int length = this.listRentRoom.Items.Count;
                        ViewDataRentRoom item = (ViewDataRentRoom)listRentRoom.SelectedItem;
                        data.deleteRentRoom(item.idRentRoom);
                        listRentRoom.Items.Remove(listRentRoom.SelectedItem);
                        MessageBox.Show("Xóa thành công", "Xóa dữ liệu", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Xóa dữ liệu", MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                }
                catch
                { 
                }
            }
        }
    }
}
