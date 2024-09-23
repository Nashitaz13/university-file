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
    public partial class CapNhatSuaChuaBaoHanh : UserControl
    {
        public CapNhatSuaChuaBaoHanh()
        {
            InitializeComponent();
            tRANGTHAISUACHUATableAdapter.Fill(qLCHDTdataset.TRANGTHAISUACHUA);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            isChange = false;
            pHIEUTIEPNHANBAOHANHBindingSource.EndEdit();
            pHIEUTIEPNHANBAOHANHTableAdapter.Update(qLCHDTdataset);
            MessageBox.Show("Lưu thành công!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CapNhatSuaChuaBaoHanh_Load(sender, e);
        }

        private void CapNhatSuaChuaBaoHanh_Load(object sender, EventArgs e)
        {
            pHIEUTIEPNHANBAOHANHTableAdapter.FillByTTSC(qLCHDTdataset.PHIEUTIEPNHANBAOHANH,"TTSC0001");

        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            CapNhatSuaChuaBaoHanh_Load(sender, e);
        }

        bool isChange;

        private void CapNhatSuaChuaBaoHanh_Leave(object sender, EventArgs e)
        {
            if (isChange)
            {
                if (MessageBox.Show("Bạn chưa lưu chỉnh sửa.\nBạn có muốn lưu thay đổi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btn_luu_Click(sender, null);
                isChange = false;
            }
        }

        private void gridView_tiepnhanbh_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            isChange = true;
        }
    }
}
