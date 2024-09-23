using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLCHMT.GUI
{
    public partial class TraHangBaoHanh : UserControl
    {
        public TraHangBaoHanh()
        {
            InitializeComponent();
            tRANGTHAITRAHANGTableAdapter.Fill(qLCHDTdataset.TRANGTHAITRAHANG);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            pHIEUTIEPNHANBAOHANHBindingSource.EndEdit();
            pHIEUTIEPNHANBAOHANHTableAdapter.Update(qLCHDTdataset);
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TraHangBaoHanh_Load(sender, e);
        }

        private void TraHangBaoHanh_Load(object sender, EventArgs e)
        {
            pHIEUTIEPNHANBAOHANHTableAdapter.FillByTTTH(qLCHDTdataset.PHIEUTIEPNHANBAOHANH,"TTSC0002","TTTH0001");

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            TraHangBaoHanh_Load(sender, e);
        }
    }
}
