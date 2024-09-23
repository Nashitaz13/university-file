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
    public partial class TimPhieuXuatHang : UserControl
    {
        public static string maPhieuXuat;

        public TimPhieuXuatHang()
        {
            InitializeComponent();
            BLL.TTXuatBll ttXuat = new BLL.TTXuatBll();
            gridControl1.DataSource = ttXuat.layTTXuat();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            GridControl grid = sender as GridControl;
            Point p = new Point(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            GridView gridView = grid.GetViewAt(p) as GridView;
            if (gridView != null)
            {
                txtMaPX.Text = gridView.GetFocusedRowCellDisplayText("MaPhieuXuat");
                txtMaNV.Text = gridView.GetFocusedRowCellDisplayText("MaNhanVien");
                dtpNgayLP.Value = DateTime.Parse(gridView.GetFocusedRowCellDisplayText("NgayHoaDon"));
                txtDiaChi.Text = gridView.GetFocusedRowCellDisplayText("DiaChi");
                txtSDT.Text = gridView.GetFocusedRowCellDisplayText("SoDienThoai");
                txtTenKH.Text = gridView.GetFocusedRowCellDisplayText("TenKhachHang");
            }
        }

        private void btnInPX_Click_1(object sender, EventArgs e)
        {
            maPhieuXuat = txtMaPX.Text;

            QuanLySieuThiDienThoai.Rerport.frmReport.strReport = "InPhieuXuat";
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }
    }
}
