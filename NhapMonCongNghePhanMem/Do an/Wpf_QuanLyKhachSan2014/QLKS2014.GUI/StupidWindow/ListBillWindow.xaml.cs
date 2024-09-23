
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
using System.Windows.Shapes;

namespace QLKS2014.GUI.StupidWindow
{
    /// <summary>
    /// danh sach cac hoa don
    /// </summary>
    public partial class ListBillWindow : Window
    {
        //DataBill dataBill;
        public ListBillWindow()
        {
            InitializeComponent();
            //dataBill = new DataBill();
            Loaded += ListBiil_Loaded;
        }

        //hien thi noi dung len listview
        void ListBiil_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    //xoa item cu
            //    listBill.Items.Clear();
            //}
            //catch
            //{ }
            //dataBill.viewAllData(ref this.listBill);
        }

        /// <summary>
        /// xoa mot hoa don
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBill_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Delete)
            //{
            //    if (DataUser.userName.Equals("Admin") == false)
            //    {
            //        MessageBox.Show("Bạn không có quyền thực hiện thao tác này", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    try
            //    {
            //        ViewDataBill item = (ViewDataBill)listBill.SelectedItem;
            //        dataBill.deleteBill(item);
            //        //xoa khoi listview 
            //        listBill.Items.Remove(listBill.SelectedItem);
            //        MessageBox.Show("Xóa thành công", "Xóa dữ liệu", MessageBoxButton.OK);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Thao tác bị lỗi", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //}
        }

        
    }
}
