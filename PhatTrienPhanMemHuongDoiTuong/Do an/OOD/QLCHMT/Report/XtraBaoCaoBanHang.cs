using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraBaoCaoBanHang : DevExpress.XtraReports.UI.XtraReport
    {
        public static int selection;
        public XtraBaoCaoBanHang()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            if (selection == 2)
            {
                lbl_title.Text = "BÁO CÁO HÀNG CÓ DOANH SỐ CHẬM";
                this.DataAdapter = this.datakhuyenmaiTableAdapter1.FillASC(qlchdTdataset1.DATAKHUYENMAI, now.Year, now.Month);
            }
            else
            {
                lbl_title.Text = "BÁO CÁO HÀNG CÓ DOANH SỐ TỐT";
                this.DataAdapter = this.datakhuyenmaiTableAdapter1.FillDESC(qlchdTdataset1.DATAKHUYENMAI, now.Year, now.Month);
            }
            this.DataMember = "DATAKHUYENMAI";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
