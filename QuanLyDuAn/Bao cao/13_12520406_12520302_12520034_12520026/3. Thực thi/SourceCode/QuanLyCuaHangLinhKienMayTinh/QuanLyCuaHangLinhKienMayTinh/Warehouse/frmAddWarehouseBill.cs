using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Warehouse;
using CommonLayer;
using DevExpress.XtraPrinting.Native;
using DTO.Warehouse;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    public partial class frmAddWarehouseBill : Form
    {

        private BllProduct _bllProduct;
        private BllWarehouseBill _bllWarehouseBill;
        private BllWarehouseBillDetail _bllWarehouseBillDetail;
        public frmAddWarehouseBill()
        {
            InitializeComponent();

            _bllProduct = new BllProduct();    
            _bllWarehouseBill = new BllWarehouseBill();
            _bllWarehouseBillDetail = new BllWarehouseBillDetail();

            Load += FrmAddWarehouseBill_Load;
        }

        private void FrmAddWarehouseBill_Load(object sender, EventArgs e)
        {
            txtMaPhieuNhapKho.Text = CreateNewWarehouseBillID();
            nguoiLapPhieuComboBox.DataSource = _bllWarehouseBill.GetEmployeeList();

            MaSanPham.DataSource = _bllProduct.GetListProducts();
            MaSanPham.DisplayMember = "TenSanPham";
            MaSanPham.ValueMember = "MaSanPham";
        }

        #region Feature function
        private string CreateNewWarehouseBillID()
        {
            return DateTime.Now.ToString("yy HH:mm:ss").
                Replace(" ", "").
                Replace("-", "").
                Replace(":", "");
        }
        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            List<DtoWarehouseBillDetail> list = new List<DtoWarehouseBillDetail>();
            DtoWarehouseBill warehouseBill = new DtoWarehouseBill();
            warehouseBill.MaPhieuNhapKho = txtMaPhieuNhapKho.Text;
            warehouseBill.NgayLapPhieu = DateTime.Now;
            warehouseBill.MaNguoiLapPhieu = nguoiLapPhieuComboBox.SelectedValue.ToString();
            warehouseBill.GhiChu = txtGhiChu.Text;

            for (int i = 0; i < dgvDetailWarehouseBill.Rows.Count - 1; i++)
            {
                DtoWarehouseBillDetail detail = new DtoWarehouseBillDetail();
                detail.MaChiTietPhieuNhapKho = dgvDetailWarehouseBill.Rows[i].Cells[0].Value.ToString();
                detail.MaPhieuNhapKho = warehouseBill.MaPhieuNhapKho;
                detail.MaSanPham = dgvDetailWarehouseBill.Rows[i].Cells[1].Value.ToString();
                detail.SoLuong =  int.Parse(dgvDetailWarehouseBill.Rows[i].Cells[3].Value.ToString());
                detail.GhiChu = dgvDetailWarehouseBill.Rows[i].Cells[4].Value.ToString();
                list.Add(detail);
            }

            if (_bllWarehouseBill.AddWarehouseBillTran(warehouseBill, list))
            {
                MessageBox.Show(Constants.MsgNotificationSuccessfuly);
                btnThoat.PerformClick();
            }
            else
            {
                MessageBox.Show(Constants.MsgExceptionError);
            }
        }

        private void dgvDetailWarehouseBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var s = dgvDetailWarehouseBill.CurrentRow.Cells[1].Value.ToString();
                if (!s.IsEmpty() || s != null)
                {
                    DtoProduct dto = _bllProduct.GetProductByID(s);
                    dgvDetailWarehouseBill.CurrentRow.Cells[2].Value = dto.DonGiaNhap;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (nguoiLapPhieuComboBox.SelectedValue == null ||
                nguoiLapPhieuComboBox.SelectedValue.ToString().IsEmpty())
            {
                MessageBox.Show("Không được để trống người lập phiếu");
                return;
            }
            for (int i = 0; i < dgvDetailWarehouseBill.Rows.Count - 1; i++)
            {
                if (dgvDetailWarehouseBill.Rows[i].Cells[0].Value == null ||
                    dgvDetailWarehouseBill.Rows[i].Cells[1].Value == null ||
                    dgvDetailWarehouseBill.Rows[i].Cells[3].Value == null)
                {
                    MessageBox.Show("Không được để trống mã chi tiết phiếu nhập kho, sản phẩm, số lượng");
                    return;
                }
            }
            MessageBox.Show("OK!");
            btnThem.Enabled = true;

            txtTotal.Text = SumTotal().ToString();
        }

        private double SumTotal()
        {
            double s = 0;
            for (int i = 0; i < dgvDetailWarehouseBill.Rows.Count - 1; i++)
            {
                s += double.Parse(dgvDetailWarehouseBill.Rows[i].Cells[2].Value.ToString())*
                     double.Parse(dgvDetailWarehouseBill.Rows[i].Cells[3].Value.ToString());
            }
            return s;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
