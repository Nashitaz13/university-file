using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLySieuThiDienThoai.Rerport
{
    public partial class InPhieuXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public InPhieuXuat()
        {
            InitializeComponent();
            MaPhieuXuat.Value = QuanLySieuThiDienThoai.Rerport.TimPhieuXuatHang.maPhieuXuat;
        }

    }
}
