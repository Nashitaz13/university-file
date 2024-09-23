
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// màn hình cho thuê phòng
    /// </summary>
    public partial class RentRoom : UserControl
    {
        //cac thao tac them, xoa thong tin
       // public DataRentRoom dataRentRoom;
        //phong duoc thue
        public int idRoom;
        //ngay bat dau thue
        public string date;
        //danh sach nhung khach trong phong
       // public List<CustomerDetail> customer;
        //chuoi ket noi du lieu
        //SqlCeConnection conecttionData;
        public RentRoom()
        {
            InitializeComponent();
            //conecttionData = 
            //    new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            //customer = new List<CustomerDetail>();
            //dataRentRoom = new DataRentRoom();
            
            //this.cbRoom.Focus();
            Loaded += RentRoom_Loaded;
        }

        /// <summary>
        /// hien thi danh sach nhung phong chua thue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RentRoom_Loaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    lbDate.Content = DateTime.Now.ToString();
            //    this.cbTypesCustomer.Items.Clear();
            //    this.cbRoom.Items.Clear();
            //    //mo ket noi
            //    conecttionData.Open();
            //}
            //catch
            //{ }
            //try
            //{
            //    //truy van lay ten phong chua duoc thue
            //    string cmdText = "SELECT TenPhong FROM PHONG WHERE (TinhTrang = 'Trong')";
            //    using (SqlCeCommand cmdViewData = new SqlCeCommand(cmdText, conecttionData))
            //    {
            //        SqlCeDataReader reader = cmdViewData.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            //gan du lieu cua combo phong bang cot TenPhong 
            //            this.cbRoom.Items.Add(reader["TenPhong"].ToString());
            //        }
            //    }
            //    cmdText = "SELECT TenLoaiKhach FROM LOAIKHACH";
            //    using (SqlCeCommand cmdViewData = new SqlCeCommand(cmdText, conecttionData))
            //    {
            //        SqlCeDataReader reader = cmdViewData.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            this.cbTypesCustomer.Items.Add(reader["TenLoaiKhach"].ToString());
            //        }
            //    }
            //}
            //catch { }
            //conecttionData.Close();
        }

        /// <summary>
        /// goi ham addNewRentRoom dr luu lai phieu thue phong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (string.IsNullOrEmpty(this.lbDate.Content.ToString()) ||
            //        string.IsNullOrEmpty(this.cbRoom.SelectedItem.ToString()))
            //    {
            //        MessageBox.Show("Hãy điền đầy đủ thông tin", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    try
            //    {
            //        dataRentRoom.AddNewRentRoom(this.cbRoom.SelectedItem.ToString(), this.lbDate.Content.ToString(), customer);
            //    }
            //    catch
            //    { }
            //    this.clear();
            //    MessageBox.Show("Lưu lại thành công", "Lưu dữ liệu", MessageBoxButton.OK);
            //}
            //catch
            //{
            //    MessageBox.Show("Thao tác bị lỗi", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        public int indexCus = 1;
        private void btnAddCotomer_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (string.IsNullOrEmpty(this.tbAdress.Text) ||
            //    string.IsNullOrEmpty(this.tbIdCard.Text) ||
            //    string.IsNullOrEmpty(this.tbName.Text) ||
            //    string.IsNullOrEmpty(this.cbTypesCustomer.SelectedItem.ToString()))
            //    {
            //        MessageBox.Show("Hãy điền đầy đủ thông tin", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    CustomerDetail item = new CustomerDetail();
            //    item.name = this.tbName.Text;
            //    item.idCard = this.tbIdCard.Text;
            //    item.typeCustomer = this.cbTypesCustomer.SelectedItem.ToString();
            //    item.index = indexCus;
            //    item.adress = tbAdress.Text;
            //    indexCus++;
            //    this.listCustomer.Items.Add(item);
            //    customer.Add(item);
            //}
            //catch
            //{

            //}
        }

        /// <summary>
        /// xoa mot khach hang trong phieu thue phong truoc khi luu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Delete)
            //{
            //    try
            //    {
            //        customer.Remove((CustomerDetail)listCustomer.SelectedItem);
            //        listCustomer.Items.Remove(listCustomer.SelectedItem);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Thao tác bị lỗi", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
        }

        /// <summary>
        /// kiem tra nhap so
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbCartId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// xoa thong tin tren form
        /// </summary>
        public void clear()
        {
            //this.tbAdress.Text = "";
            //this.lbDate.Content = DateTime.Now.ToString();
            //this.tbIdCard.Text = "";
            //this.tbName.Text = "";
            //try
            //{
            //    this.listCustomer.Items.Clear();
            //    customer.Clear();
            //}
            //catch { }

        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    try
            //    {
            //        if (string.IsNullOrEmpty(this.lbDate.Content.ToString()) ||
            //    string.IsNullOrEmpty(this.cbRoom.SelectedItem.ToString()))
            //        {
            //            MessageBox.Show("Hãy điền đầy đủ thông tin", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            //            return;
            //        }
            //        try
            //        {
            //            dataRentRoom.AddNewRentRoom(this.cbRoom.SelectedItem.ToString(), this.lbDate.Content.ToString(), customer);
            //        }
            //        catch
            //        { }
            //        this.clear();
            //    }
            //    catch
            //    {

            //    }
            //}
        }

        private void cbbRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.tbName.Focus();
        }

        private void cbbCustomerType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.tbIdCard.Focus();
        }

        private void dgCustomer_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void dgCustomer_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
