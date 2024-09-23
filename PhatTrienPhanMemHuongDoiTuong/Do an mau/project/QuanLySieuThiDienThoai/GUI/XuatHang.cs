using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySieuThiDienThoai.BLL;
using QuanLySieuThiDienThoai.DTO;
using DAO;


namespace QuanLySieuThiDienThoai.GUI
{
    public partial class XuatHang : UserControl
    {
        private PhieuXuatBll phieuXuatBll;
        public XuatHang()
        {
            InitializeComponent();
            phieuXuatBll = new PhieuXuatBll();
        }
        private void XuatHang_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Mã Mặt Hàng";
            dataGridView1.Columns[1].Name = "Tên Mặt Hàng";
            dataGridView1.Columns[2].Name = "Số Lượng";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 200;

            #region "loaddata"
            DataProvider provider = new DataProvider();
            provider.connect();

            //Load data for cbTenMatHang
            MatHangBll matHang = new MatHangBll();
            cbTenMatHang.DataSource = matHang.LayDanhSachMaMH();
            cbTenMatHang.ValueMember = "MaMatHang";
            cbTenMatHang.DisplayMember = "TenMatHang";

            //Load data for txtMaKH
            KhachHangBll khachHang = new KhachHangBll();
            cbMaKH.DataSource = khachHang.LayDanhSachMaKH();
            cbMaKH.ValueMember = "MaKhachHang";
            cbMaKH.DisplayMember = "MaKhachHang";
            //Tự động mã phiếu xuất
            txtMaPX.Text = TangMa(phieuXuatBll.LayMaPhieuXuatMax());

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
        

        //Add item to datagridview
        private void btnThemMH_Click(object sender, EventArgs e)
        {
            KiemTraTenMH();
           
            if (cbTenMatHang.Text != "" &&  KiemTraSoLuong() == 1)
            {
                string[] row = new string[] { cbTenMatHang.SelectedValue.ToString(), cbTenMatHang.Text, txtSoLuong.Text };
                dataGridView1.Rows.Add(row);

                txtSoLuong.Clear();
                pbTenMH.Visible = false;
                lbTenMH.Visible = false;
                pbSoLuong.Visible = false;
                lbSoLuong.Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có muốn lưu!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;
            else
            {
                KiemTraMaKH();
                if (dataGridView1.RowCount > 0 && cbMaKH.Text != "")
                {
                    //Add info to PhieuXuat

                    
                    if (cbMaKH.Text != "")
                    {
                        PhieuXuat phieuXuat = new PhieuXuat();
                        phieuXuat.MaPhieuXuat = txtMaPX.Text;
                        phieuXuat.MaNhanVien = txtMaNV.Text;
                        phieuXuat.MaKhachHang = cbMaKH.Text;
                        phieuXuat.NgayHoaDon = dtpNgayHD.Value.Date;

                        phieuXuatBll.ThemPX(phieuXuat);
                    }

                    //Add info to CTPX

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        CTPhieuXuat ctPhieuXuat = new CTPhieuXuat();
                        MatHangBll matHang = new MatHangBll();
                        ctPhieuXuat.MaPhieuXuat = txtMaPX.Text;
                        ctPhieuXuat.MaMatHang = row.Cells[0].Value.ToString();
                        ctPhieuXuat.SoLuong = Int32.Parse(row.Cells[2].Value.ToString());
                        phieuXuatBll.ThemCTPX(ctPhieuXuat);
                        matHang.CapNhatSoLuongKhiXuat(Int32.Parse(row.Cells[2].Value.ToString()), row.Cells[0].Value.ToString());

                    }


                    //Reset value

                    txtMaNV.Clear();
                    txtMaPX.Clear();
                    pbMaKH.Visible = false;
                    lbMaKH.Visible = false;
                    MessageBox.Show("Lưu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mặt hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private bool KiemTraSoLuong(int s)
        {
            if (s < 1)
            {
                MessageBox.Show("Số lượng phải nhỏ hơn 0");
                return false;
            }
            return true;

        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void KiemTraMaKH()
        {

            if (cbMaKH.Text == "")
            {
                pbMaKH.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbMaKH.Visible = true;
                lbMaKH.Text = "Bạn chưa chọn mã khách khàng";
                lbMaKH.Visible = true;
            }
            else
            {
                pbMaKH.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pbMaKH.Visible = true;
                lbMaKH.Visible = false;
            }
        }

        public int KiemTraSoLuong()
        {
            MatHangBll matHang = new MatHangBll();
            int soLuong =  matHang.LaySoLuongMatHang(cbTenMatHang.SelectedValue.ToString());
            if (txtSoLuong.Text == "")
            {
                pbSoLuong.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbSoLuong.Visible = true;
                lbSoLuong.Text = "Bạn chưa nhập số lượng!";
                lbSoLuong.Visible = true;
                return 0;
            }
            else if (Int32.Parse(txtSoLuong.Text) <= 0)
            {
                pbSoLuong.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbSoLuong.Visible = true;
                lbSoLuong.Text = "Số lượng phải lớn hơn 0";
                lbSoLuong.Visible = true;
                return 0;
            }
            else if (Int32.Parse(txtSoLuong.Text) > soLuong)
            {
                pbSoLuong.Image = QuanLySieuThiDienThoai.Properties.Resources.error;
                pbSoLuong.Visible = true;
                lbSoLuong.Text = "Không đủ hàng";
                lbSoLuong.Visible = true;
                return 0;
            }
            else
            {
                pbSoLuong.Image = QuanLySieuThiDienThoai.Properties.Resources.success;
                pbSoLuong.Visible = true;
                lbSoLuong.Visible = false;
                return 1;
            }
        }


        public void KiemTraTenMH()
        {

            if (cbTenMatHang.Text == "")
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

        private void txtSoLuong_Click(object sender, EventArgs e)
        {
            txtSoLuong.Text = "";
        }

        
        
    }
}
