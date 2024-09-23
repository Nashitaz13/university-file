using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraInPhieuNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public static String MaPhieuNhap;
        public XtraInPhieuNhap()
        {
            InitializeComponent();
            this.DataAdapter = this.dshoadonnhapTableAdapter1.FillByMa(qlchdTdataset1.DSHOADONNHAP, MaPhieuNhap);
            this.DataMember = "DSHOADONNHAP";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
