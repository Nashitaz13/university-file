using QuanLyKhachSan.ProcessData;
using QuanLyKhachSan.ViewData;
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

namespace QuanLyKhachSan.View.ContentView
{
    /// <summary>
    /// tìm kiếm phòng dựa theo thời gian
    /// </summary>
    public partial class SearchByTime : UserControl
    {
        //ket qua tim kiem
        List<ViewDataRoom> dataResult;
        public SearchByTime()
        {
            InitializeComponent();
            dataResult = new List<ViewDataRoom>();
        }

        //xu ly su kien tim kiem
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(datepickerFromDate.Text) || string.IsNullOrEmpty(datepickerToDate.Text))
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                DataListRoom dataListRoom = new DataListRoom();
                dataResult = dataListRoom.searchByTime((DateTime)datepickerFromDate.SelectedDate, (DateTime)datepickerToDate.SelectedDate);
                listRoom.ItemsSource = dataResult;
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(datepickerFromDate.Text) || string.IsNullOrEmpty(datepickerToDate.Text))
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                DataListRoom dataListRoom = new DataListRoom();
                dataResult = dataListRoom.searchByTime((DateTime)datepickerFromDate.SelectedDate, (DateTime)datepickerToDate.SelectedDate);
                listRoom.ItemsSource = dataResult;
            }
        }
    }
}
