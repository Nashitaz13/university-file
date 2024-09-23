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
    public partial class BaosCaoBanHang : UserControl
    {
        public BaosCaoBanHang()
        {
            InitializeComponent();
        }

        private void btn_xem_Click(object sender, EventArgs e)
        {
            //frmBaoCao.Choose = 10;
            //if (radioButton_banchay.Checked)
            //{
            //    XtraBaoCaoBanHang.selection = 1;
            //}
            //if (radioButton_bancham.Checked)
            //{
            //    XtraBaoCaoBanHang.selection = 2;
            //}
            //panel2.Controls.Clear();
            //frmBaoCao uc = new frmBaoCao();
            //uc.Dock = System.Windows.Forms.DockStyle.Fill;
            //panel2.Controls.Add(uc);
            bAOCAOBANHANGTableAdapter.FillASC(qLCHDTdataset.BAOCAOBANHANG,  2016, 1);
        }

        private void BaosCaoBanHang_Load(object sender, EventArgs e)
        {
            radioButton_banchay.Checked = true;
        }
    }
}
