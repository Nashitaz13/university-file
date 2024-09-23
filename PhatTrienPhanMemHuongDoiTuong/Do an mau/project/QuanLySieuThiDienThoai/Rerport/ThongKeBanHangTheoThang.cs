using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLySieuThiDienThoai.Rerport
{
    public partial class ThongKeBanHangTheoThang : DevExpress.XtraReports.UI.XtraReport
    {
        public ThongKeBanHangTheoThang()
        {
            InitializeComponent();
            this.THANG.Value = 11;
            this.NAM.Value = 2015;
            
            
        }

    }
}
