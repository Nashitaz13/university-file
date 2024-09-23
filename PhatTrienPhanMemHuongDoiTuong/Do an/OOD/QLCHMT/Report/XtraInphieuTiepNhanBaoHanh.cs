using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraInphieuTiepNhanBaoHanh : DevExpress.XtraReports.UI.XtraReport
    {
        public static string MaPhieuTiepNhanBaoHanh;
        public XtraInphieuTiepNhanBaoHanh()
        {
            InitializeComponent();
            this.DataAdapter = this.inphieutiepnhanbaohanhTableAdapter1.FillByMa(qlchdTdataset1.INPHIEUTIEPNHANBAOHANH,MaPhieuTiepNhanBaoHanh);
            this.DataMember = "INPHIEUTIEPNHANBAOHANH";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
