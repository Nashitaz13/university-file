using QuanLyKhachSan.ProcessData;
using QuanLyKhachSan.ViewData;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
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

namespace QuanLyKhachSan.View.ContentView
{
    /// <summary>
    /// màn hình hóa đơn thanh tóa
    /// </summary>
    public partial class Bill : UserControl
    {
        DataBill dataBill = new DataBill();
        //ten nhung phong da duoc thue
        List<string> nameRoom = new List<string>();
        //ngay lap hoa don
        DateTime dateBuild;
        //tong tien
        decimal total = 0;
        public Bill()
        {
            InitializeComponent();
            this.tbxCustomer.Focus();
            Loaded += Bill_Loaded;
        }

        void Bill_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.cboRoom.Items.Clear();
            }
            catch { }
            dateBuild = DateTime.Now;
            this.lbDateBuild.Content = dateBuild.ToString();
            //load danh sach nhung phong da duoc thue
            SqlCeConnection connectionData = 
                new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            connectionData.Open();
            string cmdText = "SELECT TenPhong FROM PHONG WHERE TinhTrang = 'Da Thue'";
            using (SqlCeCommand cmdGetValue = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetValue.ExecuteReader();
                while (reader.Read())
                {
                    string item = reader["TenPhong"].ToString();
                    this.cboRoom.Items.Add(item);
                    //nameRoom.Add(item);
                }
            }
            connectionData.Close();
        }

        //kiem tra nhap so
        private void tbDiscount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.tbDiscount.Text))
                    this.tbDiscount.Text = "0";
                if (string.IsNullOrEmpty(this.tbxCustomer.Text) ||
                    string.IsNullOrEmpty(this.tbxAdress.Text))
                {
                    MessageBox.Show("Nhập đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DateTime dateBuild = DateTime.Now;
                dataBill.addNewBill(this.tbxCustomer.Text, dateBuild,
                    this.tbxAdress.Text,
                    nameRoom, float.Parse(this.tbDiscount.Text));
                MessageBox.Show("Lưu lại thành công", "Lưu dữ liệu", MessageBoxButton.OK);
            }
            catch
            {
                MessageBox.Show("Thao tác bị lỗi", "Lưu dữ liệu", MessageBoxButton.OK);
            }

        }

        /// <summary>
        /// xoa thong tin 
        /// </summary>
        public void clear()
        {
            this.tbDiscount.Text = "";
            this.tbxAdress.Text = "";
            this.tbxCustomer.Text = "";
            try
            {
                this.lstRoom.Items.Clear();
                nameRoom.Clear();
            }
            catch
            { }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if (string.IsNullOrEmpty(this.tbDiscount.Text))
                        this.tbDiscount.Text = "0";
                    if (string.IsNullOrEmpty(this.tbxCustomer.Text) ||
                        string.IsNullOrEmpty(this.tbxAdress.Text))
                    {
                        MessageBox.Show("Nhập đầy đủ thông tin", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    DateTime dateBuild = DateTime.Now;
                    dataBill.addNewBill(this.tbxCustomer.Text, dateBuild,
                        this.tbxAdress.Text,
                        nameRoom, float.Parse(this.tbDiscount.Text));
                    MessageBox.Show("Lưu lại thành công", "Lưu dữ liệu", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Thao tác bị lỗi", "Lưu dữ liệu", MessageBoxButton.OK);
                }
            }
        }

        /// <summary>
        /// them mot phong vao danh sach nhung phong can thanh toan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRoomToBill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float discount = 0;
                try
                {
                    discount = float.Parse(this.tbDiscount.Text);
                }
                catch
                {
                    return;
                }
                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show("Chiết khấu phải nhỏ hơn 100%", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                ViewRoomInBill item = dataBill.getValue(
                    this.cboRoom.SelectedItem.ToString(),
                    dateBuild, discount);
                this.lstRoom.Items.Add(item);
                nameRoom.Add(item.nameRoom);
                total += item.totalMoneyNeedToPay;
                //if ((discount > 0) && (discount <= 100))
                //    total = total * (1 - (decimal)discount / 100);
                this.lbTotalMoney.Content = total.ToString();
                this.cboRoom.Items.RemoveAt(this.cboRoom.SelectedIndex);
            }
            catch { }
            
        }

        private void cboRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this.btnAddRoomToBill.Focus();
            }
            catch
            { }
        }
    }
}
