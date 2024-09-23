using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLySieuThiDienThoai.Rerport
{
    public partial class TimPhieuNhapHang : UserControl
    {
        public static string maPhieuNhap;
        public TimPhieuNhapHang()
        {
            InitializeComponent();
            BLL.TTNhapBll ttNhap=new BLL.TTNhapBll();
            gridControl1.DataSource = ttNhap.layTTNhap();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

            GridControl grid = sender as GridControl;
            Point p = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            GridView gridView = grid.GetViewAt(p) as GridView;
            if (gridView != null)
            {
                txtMaPN.Text = gridView.GetFocusedRowCellDisplayText("MaPhieuNhap");
                txtTenNV.Text = gridView.GetFocusedRowCellDisplayText("TenNhanVien");
                dtpNgayLap.Value = DateTime.Parse(gridView.GetFocusedRowCellDisplayText("NgayHoaDon"));
            }

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            maPhieuNhap = txtMaPN.Text;
            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "InPhieuNhap";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
