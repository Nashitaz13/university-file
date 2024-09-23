using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraBaoCaoChiNhapHang : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraBaoCaoChiNhapHang()
        {
            InitializeComponent();

            if (BaoCaoChiNhapHang.Choose == 2)
            {
                this.baocaochinhaphangTableAdapter1.FillBy(qlchdTdataset1.BAOCAOCHINHAPHANG, BaoCaoChiNhapHang.Thang, BaoCaoChiNhapHang.Nam);
                txt_label.Text = "Tháng " + BaoCaoChiNhapHang.Thang + " năm " + BaoCaoChiNhapHang.Nam;
            }
            if (BaoCaoChiNhapHang.Choose == 1)
            {
                this.baocaochinhaphangTableAdapter1.FillFrom(qlchdTdataset1.BAOCAOCHINHAPHANG, BaoCaoChiNhapHang.NgayBatDau, BaoCaoChiNhapHang.NgayKetThuc);
                txt_label.Text = "Từ " + BaoCaoChiNhapHang.NgayBatDau.ToShortDateString() + " đến " + BaoCaoChiNhapHang.NgayKetThuc.ToShortDateString();
            }
            this.DataAdapter = this.baocaochinhaphangTableAdapter1;
            this.DataMember = "BAOCAOCHINHAPHANG";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
