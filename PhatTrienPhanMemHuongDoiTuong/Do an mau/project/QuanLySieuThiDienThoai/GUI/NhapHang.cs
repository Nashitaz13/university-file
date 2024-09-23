using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySieuThiDienThoai.BLL;
using QuanLySieuThiDienThoai.DTO;
using DAO;
using System.Data.SqlClient;

namespace QuanLySieuThiDienThoai.GUI
{
    public partial class NhapHang : UserControl
    {
        private PhieuNhapBll phieuNhapBll;
        public NhapHang()
        {
            phieuNhapBll = new PhieuNhapBll();
            InitializeComponent();

        }
        private void NhapHang_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Mã Mặt Hàng";
            dataGridView1.Columns[1].Name = "Tên Mặt Hàng";
            dataGridView1.Columns[2].Name = "Mã NCC";
            dataGridView1.Columns[3].Name = "Tên NCC";
            dataGridView1.Columns[4].Name = "Số Lượng";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 100;

            #region "loaddata"
            DataProvider provider = new DataProvider();
            provider.connect();
            //Load data for  cbmathang
            MatHangBll matHang = new MatHangBll();
            cbmathang.DataSource = matHang.LayDanhSachMaMH();
            cbmathang.ValueMember = "MaMatHang";
            cbmathang.DisplayMember = "TenMatHang";

            //Load data for cbTenNCC
            NhaCungCapBll nhaCC = new NhaCungCapBll();
            cbTenNCC.DataSource = nhaCC.LayDanhSachNCC();
            cbTenNCC.ValueMember = "MaNhaCungCap";
            cbTenNCC.DisplayMember = "TenNhaCungCap";

            //Tự động mã phiếu nhập
            
            txtMaPN.Text = TangMa(phieuNhapBll.LayMaPhieuNhapMax());

            //Set txtMaNV
            txtMaNV.Text = main.MaNhanVien;
            #endregion

        }
        #region "Tự động tăng mã"
        public static string TangMa(string str1)
        {
            string str2 = "";
            foreach (char ch in str1)
            {
                if (ch >= 48 && ch <= 57)
                    str2 = str2 + ch.ToString();
            }
            int i = int.Parse(str2);
            i++;
            return str1.Substring(0, str1.Length - i.ToString().Length) + i.ToString();
        }
        #endregion
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btnThemMH_Click(object sender, EventArgs e)
        {
            KiemTraTenMH();
            KiemTraSoLuong();
            KiemTraTenNCC();
            if (cbmathang.Text != "" && txtSoLuong.Text != "")
            {
                string[] row = new string[] { cbmathang.SelectedValue.ToString(), cbmathang.Text, cbTenNCC.SelectedValue.ToString(), cbTenNCC.Text, txtSoLuong.Text };
                dataGridView1.Rows.Add(row);

                txtSoLuong.Clear();
                pbTenMH.Visible = false;
                lbTenMH.Visible = false;
                pbTenNCC.Visible = false;
                lbTenNCC.Visible = false;
                pbLoi.Visible = false;
                lbSoLuong.Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có muốn lưu!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            else
            if (dataGridView1.RowCount > 0)
            {

                //Add info to PhieuNhap
                PhieuNhap phieuNhap = new PhieuNhap();
                phieuNhap.MaPhieuNhap = txtMaPN.Text;
                phieuNhap.MaNhanVien = txtMaNV.Text;
                phieuNhap.NgayHoaDon = dtdNgayHD.Value.Date;

                phieuNhapBll.ThemPN(phieuNhap);

                //Add CTPhieuNhap
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    CTPhieuNhap ctPhieuNhap = new CTPhieuNhap();
                    MatHangBll matHang = new MatHangBll();
                    ctPhieuNhap.MaPhieuNhap = txtMaPN.Text;
                    ctPhieuNhap.MaMatHang = row.Cells[0].Value.ToString();
                    ctPhieuNhap.SoLuong = Int32.Parse(row.Cells[4].Value.ToString());
                    ctPhieuNhap.MaNCC = row.Cells[2].Value.ToString();
                    phieuNhapBll.ThemCTPN(ctPhieuNhap);
                    matHang.CapNhatSoLuongKhiNhap(Int32.Parse(row.Cells[4].Value.ToString()), row.Cells[0].Value.ToString());

                }

                //Reset value
                txtMaPN.Clear();
                txtMaNV.Clear();
                MessageBox.Show("Lưu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mặt hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void KiemTraSoLuong()
        {
            if (txtSoLuong.Text == "")
            {
                pbLoi.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbLoi.Visible = true;
                lbSoLuong.Text = "Bạn chưa nhập số lượng!";
                lbSoLuong.Visible = true;
            }
            else if(Int32.Parse(txtSoLuong.Text) <= 0)
            {
                pbLoi.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbLoi.Visible = true;
                lbSoLuong.Text = "Số lượng phải lớn hơn 0";
                lbSoLuong.Visible = true;
            }
            else
            {
                pbLoi.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pbLoi.Visible = true;
                lbSoLuong.Visible = false;
            }
        }


        public void KiemTraTenMH()
        {
            
            if (cbmathang.Text == "")
            {
                pbTenMH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbTenMH.Visible = true;
                lbTenMH.Text = "Bạn chưa chọn tên mặt hàng!";
                lbTenMH.Visible = true;
            }
            else
            {
                pbTenMH.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pbTenMH.Visible = true;
                lbTenMH.Visible = false;
            }
        }

        public void KiemTraTenNCC()
        {

            if (cbTenNCC.Text == "")
            {
                pbTenNCC.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbTenNCC.Visible = true;
                lbTenNCC.Text = "Bạn chưa chọn nhà cung cấp!";
                lbTenNCC.Visible = true;
            }
            else
            {
                pbTenNCC.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pbTenNCC.Visible = true;
                lbTenNCC.Visible = false;
            }
        }

      
    }
}
