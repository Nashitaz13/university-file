using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThiDienThoai.Rerport
{
    public partial class frmReport : Form
    {
        public static string strReport;
        public frmReport()
        {
            InitializeComponent();
            if (strReport == "ThongKeTonKho")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.ThongKeTonKho);
            if(strReport=="ThongKeBanHangTheoThang")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.ThongKeBanHangTheoThang);
            if (strReport == "ThongKeBanHangTheoNgay")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.ThongKeBanHangTheoNgay);
            if (strReport == "DanhSachNhanVien")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.DanhSachNhanVien);
            if (strReport == "InPhieuXuat")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.InPhieuXuat);
            if (strReport == "InPhieuNhap")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.InPhieuNhap);
            if (strReport == "DoanhThuTheoThang")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.DoanhThuTheoThang);
            if (strReport == "DoanhThuTheoNgay")
                this.documentViewer1.DocumentSource = typeof(QuanLySieuThiDienThoai.Rerport.DoanhThuTheoNgay);
        }


    }
}
