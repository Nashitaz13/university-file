using QuanLyKhachSan.ProcessData;
using QuanLyKhachSan.ViewData;
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
using System.Windows.Shapes;

namespace QuanLyKhachSan.View.Windows
{
    /// <summary>
    /// Mô tả: theo quy định 6
    /// thay đổi số lượng loại khách
    /// thany đổi số khách tối đa
    /// thay đổi tỉ lệ phụ thu
    /// </summary>
    /// 
    public partial class Setting : Window
    {

        DataSetting dataSetting = new DataSetting();

        public Setting()
        {
            InitializeComponent();
            Loaded += Setting_Loaded;
        }

        void Setting_Loaded(object sender, RoutedEventArgs e)
        {
            dataSetting.viewDataTypeRoom(ref this.listTypeRoom);
            dataSetting.viewDataTypeCustomer(ref this.listTypeCustomer);
        }

        /// <summary>
        /// chi cho phep nhap so
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// chi cho phep nhap so
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMaxCustomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// them mot loai phong moi vao csdl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewRoom_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxMaxCustomer.Text) &&
                string.IsNullOrEmpty(this.tbxNameNewTypeRoom.Text) &&
                string.IsNullOrEmpty(this.tbxPrice.Text))
                return;
            dataSetting.dataTypeRoom.testExist(this.tbxNameNewTypeRoom.Text,
                decimal.Parse(this.tbxPrice.Text),
                int.Parse(this.tbxMaxCustomer.Text));
            dataSetting.viewDataTypeRoom(ref this.listTypeRoom);

        }

        /// <summary>
        /// xoa loai khach
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listTypeRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                ViewDataSettingTypeRoom item = (ViewDataSettingTypeRoom)listTypeRoom.SelectedItem;
                dataSetting.dataTypeRoom.deleteTypeRoom(item.idTypeRoom);
                listTypeRoom.Items.RemoveAt(listTypeRoom.SelectedIndex);
                dataSetting.viewDataTypeRoom(ref this.listTypeRoom);
            }
            
        }

        private void btnAddTypeCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxNameTypeCustomer.Text) &&
                string.IsNullOrEmpty(this.tbxRateSurcharge.Text))
                return;
            dataSetting.dataCustomer.testExist(this.tbxNameTypeCustomer.Text, float.Parse(this.tbxRateSurcharge.Text));
            dataSetting.viewDataTypeCustomer(ref this.listTypeCustomer);
        }

        private void listTypeCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                ViewDataSettingTypeCustomer item = (ViewDataSettingTypeCustomer)listTypeCustomer.SelectedItem;
                dataSetting.dataCustomer.deleteTypeCustomer(item.id);
                listTypeRoom.Items.RemoveAt(listTypeCustomer.SelectedIndex);
                dataSetting.viewDataTypeCustomer(ref this.listTypeCustomer);
            }
        }

        private void tbxRateSurcharge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnEditPassWord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxUserName.Text) ||
                string.IsNullOrEmpty(this.pwbOldPassWord.Password) ||
                string.IsNullOrEmpty(this.pwbNewPassWord.Password) ||
                string.IsNullOrEmpty(this.pwbNewPassWord_Copy.Password))
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            if (!this.pwbNewPassWord.Password.Equals(this.pwbNewPassWord_Copy.Password))
            {
                MessageBox.Show("Xác nhận lại mật khẩu");
                return;
            }
            DataUser.editPassWord(this.pwbOldPassWord.Password, this.pwbNewPassWord.Password, this.tbxUserName.Text);

        }

        private void GroupBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(this.tbxMaxCustomer.Text) &&
                string.IsNullOrEmpty(this.tbxNameNewTypeRoom.Text) &&
                string.IsNullOrEmpty(this.tbxPrice.Text))
                    return;
                dataSetting.dataTypeRoom.testExist(this.tbxNameNewTypeRoom.Text,
                    decimal.Parse(this.tbxPrice.Text),
                    int.Parse(this.tbxMaxCustomer.Text));
                dataSetting.viewDataTypeRoom(ref this.listTypeRoom);
            }
        }

        private void GroupBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(this.tbxNameTypeCustomer.Text) &&
                string.IsNullOrEmpty(this.tbxRateSurcharge.Text))
                    return;
                dataSetting.dataCustomer.testExist(this.tbxNameTypeCustomer.Text, float.Parse(this.tbxRateSurcharge.Text));
                dataSetting.viewDataTypeCustomer(ref this.listTypeCustomer);
            }
        }

        private void GroupBox_KeyDown_2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(this.tbxUserName.Text) ||
                string.IsNullOrEmpty(this.pwbOldPassWord.Password) ||
                string.IsNullOrEmpty(this.pwbNewPassWord.Password) ||
                string.IsNullOrEmpty(this.pwbNewPassWord_Copy.Password))
                {
                    MessageBox.Show("Nhập đầy đủ thông tin");
                    return;
                }
                if (!this.pwbNewPassWord.Password.Equals(this.pwbNewPassWord_Copy.Password))
                {
                    MessageBox.Show("Xác nhận lại mật khẩu");
                    return;
                }
                DataUser.editPassWord(this.pwbOldPassWord.Password, this.pwbNewPassWord.Password, this.tbxUserName.Text);
            }
        }
    }
}