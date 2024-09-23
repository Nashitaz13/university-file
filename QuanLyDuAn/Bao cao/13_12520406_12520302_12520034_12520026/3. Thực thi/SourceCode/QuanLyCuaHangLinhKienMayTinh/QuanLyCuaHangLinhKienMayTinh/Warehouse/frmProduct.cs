using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Warehouse;
using CommonLayer;
using DevExpress.Data.PLinq.Helpers;

using DevExpress.XtraPrinting.Native;
using DTO.Warehouse;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    public partial class frmProduct : Form
    {
        static int indexsearch = 0;

        #region Declare
        private BllProduct _bllProduct;
        private BllDistributor _bllDistributor;
        private BllWarehouse _bllWarehouse;

        private List<TextBox> _listTextBoxs;
        #endregion

        #region Initialization 
        public frmProduct()
        {
            InitializeComponent();

            _bllProduct = new BllProduct();
            _bllDistributor = new BllDistributor();
            _bllWarehouse = new BllWarehouse();

            _listTextBoxs = new List<TextBox>();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            dgvListProduct.DataSource = _bllProduct.GetListProducts();

            DgvDataBindings();

            InitListTextBoxs();


        }

        private void InitListTextBoxs()
        {
            _listTextBoxs.Add(txtMaSanPham);
            _listTextBoxs.Add(txtTenSanPham);
            _listTextBoxs.Add(txtLoaiSanPham);
            _listTextBoxs.Add(txtThoiGianBaoHanh);
            _listTextBoxs.Add(txtDonGiaNhap);
            _listTextBoxs.Add(txtDonGiaBan);
            _listTextBoxs.Add(txtSoLuong);
            _listTextBoxs.Add(txtDonViTinh);
        }

        private void DgvDataBindings()
        {
            txtMaSanPham.DataBindings.Clear();
            txtMaSanPham.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtMaSanPham.DataBindings.Add("Text", dgvListProduct.DataSource, "MaSanPham");

            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtTenSanPham.DataBindings.Add("Text", dgvListProduct.DataSource, "TenSanPham");

            txtLoaiSanPham.DataBindings.Clear();
            txtLoaiSanPham.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtLoaiSanPham.DataBindings.Add("Text", dgvListProduct.DataSource, "LoaiSanPham");

            txtThoiGianBaoHanh.DataBindings.Clear();
            txtThoiGianBaoHanh.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtThoiGianBaoHanh.DataBindings.Add("Text", dgvListProduct.DataSource, "ThoiGianBaoHanh");

            txtDonGiaNhap.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtDonGiaNhap.DataBindings.Add("Text", dgvListProduct.DataSource, "DonGiaNhap");

            txtDonGiaBan.DataBindings.Clear();
            txtDonGiaBan.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtDonGiaBan.DataBindings.Add("Text", dgvListProduct.DataSource, "DonGiaBan");

            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtSoLuong.DataBindings.Add("Text", dgvListProduct.DataSource, "SoLuong");
            
            txtDonViTinh.DataBindings.Clear();
            txtDonViTinh.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtDonViTinh.DataBindings.Add("Text", dgvListProduct.DataSource, "DonViTinh");
            
            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.Never;
            txtGhiChu.DataBindings.Add("Text", dgvListProduct.DataSource, "GhiChu");
        }

        #endregion

        #region Feature Function
        private void Clear()
        {
            dgvListProduct.Rows.Clear();
        }

        private void ClearTextBox()
        {
            foreach (TextBox box in _listTextBoxs)
            {
                box.Clear();
            }
            txtGhiChu.Clear();
        }
        #endregion

        #region  Button Event
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void dgListProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            txtMaSanPham.Enabled = true;
            btnLuu.Enabled = true;

        }

      
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text.IsEmpty())
            {
                if (_bllProduct.DeleteProduct(txtMaSanPham.Text))
                {
                    MessageBox.Show(Constants.MsgNotificationDeletetSuccessfuly);
                }
                else
                {
                    MessageBox.Show(Constants.MsgExceptionSql);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!CheckTextBox())
            {
                return;
            }
            DtoProduct data = new DtoProduct(
                txtMaSanPham.Text,
                txtTenSanPham.Text,
                txtLoaiSanPham.Text,
                int.Parse(txtThoiGianBaoHanh.Text),
                double.Parse(txtDonGiaNhap.Text),
                double.Parse(txtDonGiaBan.Text),
                int.Parse(txtSoLuong.Text),
                txtDonViTinh.Text,
                txtGhiChu.Text);

            if (_bllProduct.EditProduct(data))
            {
                MessageBox.Show(Constants.MsgNotificationEditSuccessfuly);
            }
            else
            {
                MessageBox.Show(Constants.MsgExceptionSql);
            }
            btnLamTuoi.PerformClick();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckTextBox())
            {
                return;
            }
            DtoProduct data  = new DtoProduct(
                txtMaSanPham.Text,
                txtTenSanPham.Text,
                txtLoaiSanPham.Text,
                int.Parse(txtThoiGianBaoHanh.Text),
                double.Parse(txtDonGiaNhap.Text),
                double.Parse(txtDonGiaBan.Text),
                int.Parse(txtSoLuong.Text),
                txtDonViTinh.Text,
                txtGhiChu.Text);
            
            if (_bllProduct.AddProduct(data))
            {
                MessageBox.Show(Constants.MsgNotificationSuccessfuly);
                btnLuu.Enabled = false;
            }
            else
            {
                MessageBox.Show(Constants.MsgAlreadyExist);
            }
            txtMaSanPham.Enabled = false;
            btnLamTuoi.PerformClick();

        }

      

        private void btnLamTuoi_Click(object sender, EventArgs e)
        {
            dgvListProduct.DataSource = _bllProduct.GetListProducts();
            DgvDataBindings();
        }
        #endregion

        #region TextBox Event
        private void txt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNumberic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        #endregion


        #region Check Data

        private bool CheckTextBox()
        {
            foreach (TextBox textBox in _listTextBoxs)
            {
                if (textBox.Name == "txtGhiChu")
                {
                    break;
                }
                if (textBox.Text.IsEmpty() || textBox.Text.Length == 0)
                {
                    textBox.BackColor = Color.Red;
                    return false;
                }
                else
                {
                    textBox.BackColor = System.Drawing.SystemColors.Window;
                }
            }
            return true;
        }





        #endregion

        private void btnFindnext_Click(object sender, EventArgs e)
        {
            indexsearch = CommonFunction.Search(dgvListProduct, txtFindText.Text, indexsearch);
        }
    }
}
