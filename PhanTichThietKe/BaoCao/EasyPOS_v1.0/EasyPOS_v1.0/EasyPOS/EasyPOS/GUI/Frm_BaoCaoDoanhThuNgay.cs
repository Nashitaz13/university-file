using DevExpress.XtraCharts;
using EasyPOS.DAL;
using EasyPOS.BLL;
using EasyPOS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS
{
    public partial class Frm_BaoCaoDoanhThuNgay : Form
    {
        ThongKeBLL _thongkeBLL = new ThongKeBLL();
        public Frm_BaoCaoDoanhThuNgay()
        {
            InitializeComponent();
            SetChart();
        }
        private void SetChart()
        {
            chart_DoanhThuTheoNgay.SeriesTemplate.ArgumentDataMember = "Ngay_Lap";
            chart_DoanhThuTheoNgay.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Tong_Thanh_Toan" });
            chart_DoanhThuTheoNgay.SeriesDataMember = "So_Luong_HD";
            chart_DoanhThuTheoNgay.SeriesTemplate.View = new StackedBarSeriesView();
            chart_DoanhThuTheoNgay.SeriesNameTemplate.BeginText = "Số Lượng: ";
            // Dock the chart into its parent, and add it to the current form.
            chart_DoanhThuTheoNgay.Dock = DockStyle.Fill;

        }
        private void LoadData()
        {
            DateTime d1 = DateTime.Parse(dateEdit1.Text);
            DateTime d2 = DateTime.Parse(dateEdit2.Text);
  //          grid_DoanhThuTheoNgay.DataSource = _thongkeBLL.ThongKeTheoNgay(d1, d2);
  //          chart_DoanhThuTheoNgay.DataSource = _thongkeBLL.ThongKeTheoNgay(d1, d2);
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
