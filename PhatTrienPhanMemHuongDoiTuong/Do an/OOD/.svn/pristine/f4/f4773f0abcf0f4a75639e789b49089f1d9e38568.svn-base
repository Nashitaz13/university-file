using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraPhieuBaoHanh : DevExpress.XtraReports.UI.XtraReport
    {
        public static String MaPhieuBaoHanh;
        public XtraPhieuBaoHanh()
        {
            InitializeComponent();
            this.DataAdapter = this.inphieubaohanhTableAdapter1.FillByMa(qlchdTdataset1.INPHIEUBAOHANH,MaPhieuBaoHanh);
            this.DataMember = "INPHIEUBAOHANH";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
