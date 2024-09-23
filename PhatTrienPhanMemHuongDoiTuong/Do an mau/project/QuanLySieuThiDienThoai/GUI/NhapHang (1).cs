using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThiDienThoai.GUI
{
    public partial class NhapHang : UserControl
    {
        public NhapHang()
        {
            InitializeComponent();

        }
        private void NhapHang_Load(object sender, EventArgs e)
        {

        }
        #region "Tự động tăng mã"
        public static string TangMa(string str1)
        {
            string str2 = "";
            foreach (char ch in str1)
            {
                if (ch >= 48 && ch <= 57)
                    str2 = str2 + ch.ToString();
            }
            int i = int.Parse(str2);
            i++;
            return str1.Substring(0, str1.Length - i.ToString().Length) + i.ToString();
        }
        #endregion
        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }

        private void btn_huy_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }
        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {

        }


    }
}
