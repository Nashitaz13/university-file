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
    public partial class frmBaoCao : UserControl
    {
        public static int Choose;
        public frmBaoCao()
        {
            InitializeComponent();
            switch(Choose){
                case 1:     //BaoCaoDoanhSoBanHang
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraBaoCaoDoanhSoBanHang);
                    break;
                case 2:     //BaoCaoDoanhSoNhapHang
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraBaoCaoDoanhSoNhapHang);
                    break;
                case 3:     //BaoCaoDoanhThuBanHang
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraBaoCaoDoanhThuBanHang);
                    break;
                case 4:     //BaoCaoChiNhapHang
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraBaoCaoChiNhapHang);
                    break;
                case 5:     //In phieu nhap
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraInPhieuNhap);
                    break;
                case 6:     //In phieu xuat
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraInPhieuXuat);
                    break;
                case 7:     //Bao cao ton kho
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraBaoCaoTonKho);
                    break;
                case 8:     //In phieu bao hanh
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraPhieuBaoHanh);
                    break;
                case 9:     //In phieu tiep nhan bao hanh
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraInphieuTiepNhanBaoHanh);
                    break;
                case 10:     //In phieu tiep nhan bao hanh
                    documentViewer1.DocumentSource = typeof(QLCHMT.Report.XtraBaoCaoBanHang);
                    break;
            }
        }
    }
}
