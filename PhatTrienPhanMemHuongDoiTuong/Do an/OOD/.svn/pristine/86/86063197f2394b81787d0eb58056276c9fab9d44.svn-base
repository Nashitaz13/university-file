using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLCHMT.Report
{
    public partial class XtraInPhieuXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public static String MaPhieuXuat;
        public XtraInPhieuXuat()
        {
            InitializeComponent(); 
            this.DataAdapter = this.dshoadonxuatTableAdapter1.FillByMa(qlchdTdataset1.DSHOADONXUAT,MaPhieuXuat);
            this.DataMember = "DSHOADONXUAT";
            this.DataSource = this.qlchdTdataset1;
        }

    }
}
