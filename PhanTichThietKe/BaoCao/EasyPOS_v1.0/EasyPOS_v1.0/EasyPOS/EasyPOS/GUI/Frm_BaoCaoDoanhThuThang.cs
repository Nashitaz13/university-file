using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyPOS.DAL;
using EasyPOS.BLL;
using EasyPOS.Utils;

namespace EasyPOS
{
    public partial class Frm_BaoCaoDoanhThuThang : Form
    {
        ThongKeBLL _thongkeBLL = new ThongKeBLL();
        public Frm_BaoCaoDoanhThuThang()
        {
            InitializeComponent();
            SetChart();
        }
        private void SetChart()
        {
            chart_DoanhThuThang.SeriesTemplate.ArgumentDataMember = "Thang";
            chart_DoanhThuThang.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Tong_Thanh_Toan" });
            chart_DoanhThuThang.SeriesDataMember = "So_Luong_HD";
            chart_DoanhThuThang.SeriesTemplate.View = new StackedBarSeriesView();
            chart_DoanhThuThang.SeriesNameTemplate.BeginText = "Số Lượng: ";
            // Dock the chart into its parent, and add it to the current form.
            chart_DoanhThuThang.Dock = DockStyle.Fill;
        }
        private void LoadData()
        {
            DateTime d1 = DateTime.Parse(dt_TuThang.Text);
            DateTime d2 = DateTime.Parse(dt_DenThang.Text);
  //          grid_DoanhThuTheoThang.DataSource = _thongkeBLL.ThongKeTheoThang(d1, d2);
  //          chart_DoanhThuThang.DataSource = _thongkeBLL.ThongKeTheoThang(d1, d2);
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
