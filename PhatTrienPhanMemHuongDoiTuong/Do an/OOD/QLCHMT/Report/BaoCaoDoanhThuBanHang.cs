using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCHMT.Report
{
    public partial class BaoCaoDoanhThuBanHang : UserControl
    {
        public static DateTime NgayBatDau, NgayKetThuc;
        public static decimal Thang, Nam;
        public static int Choose;
        public BaoCaoDoanhThuBanHang()
        {
            InitializeComponent();
        }

        private void radioButton_chonthang_CheckedChanged(object sender, EventArgs e)
        {
            tHANG_XUATTableAdapter.Fill(qLCHDTdataset.THANG_XUAT);
            nAM_XUATTableAdapter.Fill(qLCHDTdataset.NAM_XUAT);
        }

        private void BaoCaoDoanhThuBanHang_Load(object sender, EventArgs e)
        {
            radioButton_tungaydenngay.Checked = true;
        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            frmBaoCao.Choose = 3;
            if (radioButton_tungaydenngay.Checked)
            {
                if (dateEdit_denngay.Text.Length == 0 || dateEdit_tungay.Text.Length == 0)
                {
                    {
                        MessageBox.Show("Phải chọn ngày bắt đầu và ngày kết thúc", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Choose = 1;
                NgayBatDau = dateEdit_tungay.DateTime;
                NgayKetThuc = dateEdit_denngay.DateTime;
                if (NgayKetThuc <= NgayBatDau)
                {
                    MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc");
                    return;
                }
            }
            if (radioButton_chonthang.Checked)
            {
                if (comboBox_nam.Text.Length == 0 || comboBox_thang.Text.Length == 0)
                {
                    {
                        MessageBox.Show("Phải chọn tháng và năm báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Choose = 2;
                Thang = decimal.Parse(comboBox_thang.Text);
                Nam = decimal.Parse(comboBox_nam.Text);
            }
            panel2.Controls.Clear();
            frmBaoCao uc = new frmBaoCao();
            uc.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Controls.Add(uc);
        }
    }
}
