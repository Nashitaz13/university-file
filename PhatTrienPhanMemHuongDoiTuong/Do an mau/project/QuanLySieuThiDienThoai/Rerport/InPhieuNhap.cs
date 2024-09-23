using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLySieuThiDienThoai.Rerport
{
    public partial class InPhieuNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public InPhieuNhap()
        {
            InitializeComponent();
            MaPhieuNhap.Value = QuanLySieuThiDienThoai.Rerport.TimPhieuNhapHang.maPhieuNhap;
        }

    }
}
