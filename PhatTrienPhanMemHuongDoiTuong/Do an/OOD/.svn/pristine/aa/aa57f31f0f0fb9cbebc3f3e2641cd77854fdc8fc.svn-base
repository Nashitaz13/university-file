using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraBaoCaoDoanhSoBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraBaoCaoDoanhSoBanHang()
        {
            InitializeComponent();
            if (BaoCaoDoanhSoBanHang.Choose == 2)
            {
                this.baocaodoanhsobanhanG1TableAdapter1.FillBy(qlchdTdataset1.BAOCAODOANHSOBANHANG1, BaoCaoDoanhSoBanHang.Thang, BaoCaoDoanhSoBanHang.Nam);
                txt_label.Text = "Tháng " + BaoCaoDoanhSoBanHang.Thang + " năm " + BaoCaoDoanhSoBanHang.Nam;
            }
            if (BaoCaoDoanhSoBanHang.Choose == 1)                
            {                
                this.baocaodoanhsobanhanG1TableAdapter1.FillFrom(qlchdTdataset1.BAOCAODOANHSOBANHANG1, BaoCaoDoanhSoBanHang.NgayBatDau, BaoCaoDoanhSoBanHang.NgayKetThuc);
                txt_label.Text = "Từ " + BaoCaoDoanhSoBanHang.NgayBatDau.ToShortDateString() + " đến " + BaoCaoDoanhSoBanHang.NgayKetThuc.ToShortDateString();
             }
            this.DataAdapter = qlchdTdataset1.BAOCAODOANHSOBANHANG1;
            this.DataMember = "BAOCAODOANHSOBANHANG1";
            this.DataSource = this.qlchdTdataset1;

        }

    }
}
