using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraBaoCaoDoanhThuBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraBaoCaoDoanhThuBanHang()
        {
            InitializeComponent();


            if (BaoCaoDoanhThuBanHang.Choose == 2)
            {
                this.baocaodoanhthubanhangTableAdapter1.FillBy(qlchdTdataset1.BAOCAODOANHTHUBANHANG, BaoCaoDoanhThuBanHang.Thang, BaoCaoDoanhThuBanHang.Nam);
                txt_label.Text = "Tháng " + BaoCaoDoanhThuBanHang.Thang + " năm " + BaoCaoDoanhThuBanHang.Nam;
            }
            if (BaoCaoDoanhThuBanHang.Choose == 1)
            {
                this.baocaodoanhthubanhangTableAdapter1.FillFrom(qlchdTdataset1.BAOCAODOANHTHUBANHANG, BaoCaoDoanhThuBanHang.NgayBatDau, BaoCaoDoanhThuBanHang.NgayKetThuc);
                txt_label.Text = "Từ " + BaoCaoDoanhThuBanHang.NgayBatDau.ToShortDateString() + " đến " + BaoCaoDoanhThuBanHang.NgayKetThuc.ToShortDateString();
            }
            this.DataAdapter = qlchdTdataset1.BAOCAODOANHTHUBANHANG;
            this.DataMember = "BAOCAODOANHTHUBANHANG";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
