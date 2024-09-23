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
    public partial class BaoCaoBanHang : UserControl
    {
        public BaoCaoBanHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bAOCAOBANHANGTableAdapter.FillASC(qLCHDTdataset.BAOCAOBANHANG, 2016, 1);
        }
    }
}
