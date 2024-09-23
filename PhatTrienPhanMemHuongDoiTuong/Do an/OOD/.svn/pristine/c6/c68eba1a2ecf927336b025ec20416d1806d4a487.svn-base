using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraBaoCaoDoanhSoNhapHang : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraBaoCaoDoanhSoNhapHang()
        {
            InitializeComponent();

            if (BaoCaoDoanhSoNhapHang.Choose == 2)
            {
                this.baocaodoanhsonhaphangTableAdapter1.FillBy(qlchdTdataset1.BAOCAODOANHSONHAPHANG, BaoCaoDoanhSoNhapHang.Thang, BaoCaoDoanhSoNhapHang.Nam);
                txt_label.Text = "Tháng " + BaoCaoDoanhSoNhapHang.Thang + " năm " + BaoCaoDoanhSoNhapHang.Nam;
            }
            if (BaoCaoDoanhSoNhapHang.Choose == 1)
            {
                this.baocaodoanhsonhaphangTableAdapter1.FillFrom(qlchdTdataset1.BAOCAODOANHSONHAPHANG, BaoCaoDoanhSoNhapHang.NgayBatDau, BaoCaoDoanhSoNhapHang.NgayKetThuc);
                txt_label.Text = "Từ " + BaoCaoDoanhSoNhapHang.NgayBatDau.ToShortDateString() + " đến " + BaoCaoDoanhSoNhapHang.NgayKetThuc.ToShortDateString();
            }
            this.DataAdapter = this.baocaodoanhsonhaphangTableAdapter1;
            this.DataMember = "BAOCAODOANHSONHAPHANG";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
