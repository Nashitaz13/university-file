using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL.Delivery;
using BLL.Delivery;
using BLL.Warehouse;
using CommonLayer;
using DevExpress.XtraPrinting.Native;
using DTO.Warehouse;

namespace QuanLyCuaHangLinhKienMayTinh.Delivery
{
    public partial class frmAddDeliveryBill : Form
    {

        private BllProduct _bllProduct;
        private BllDeliveryBill _bllDeliveryBill;
        private BllDeliveryBillDetail _bllDeliveryBillDetail;

        public frmAddDeliveryBill()
        {
            InitializeComponent();

            _bllProduct = new BllProduct();
            _bllDeliveryBill = new BllDeliveryBill();
            _bllDeliveryBillDetail = new BllDeliveryBillDetail();

            Load += FrmAddDeliveryBill_Load ;
        }

        private void FrmAddDeliveryBill_Load(object sender, EventArgs e)
        {
            txtMaPhieuXuatKho.Text = CreateNewDeliveryBillID();
            maNguoiNhanComboBox.DataSource = _bllDeliveryBill.GetEmployeeList();
            nguoiLapPhieuComboBox.DataSource = _bllDeliveryBill.GetEmployeeList();

            MaSanPham.DataSource = _bllProduct.GetListProducts();
            MaSanPham.DisplayMember = "TenSanPham";
            MaSanPham.ValueMember = "MaSanPham";
        }

        private void dgvDetailDeliveryBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var s = dgvDetailDeliveryBill.CurrentRow.Cells[1].Value.ToString();
                if (!s.IsEmpty() || s != null)
                {
                    DtoProduct dto = _bllProduct.GetProductByID(s);
                    dgvDetailDeliveryBill.CurrentRow.Cells[2].Value = dto.DonGiaNhap;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            List<DtoDeliveryBillDetail> list = new List<DtoDeliveryBillDetail>();
            DtoDeliveryBill DeliveryBill = new DtoDeliveryBill();
            DeliveryBill.MaPhieuXuatKho = txtMaPhieuXuatKho.Text;
            DeliveryBill.NgayLapPhieu = DateTime.Now;
            DeliveryBill.MaNguoiNhan = maNguoiNhanComboBox.SelectedValue.ToString();
            DeliveryBill.MaNguoiLapPhieu = nguoiLapPhieuComboBox.SelectedValue.ToString();
            DeliveryBill.GhiChu = txtGhiChu.Text;

            for (int i = 0; i < dgvDetailDeliveryBill.Rows.Count - 1; i++)
            {
                DtoDeliveryBillDetail detail = new DtoDeliveryBillDetail();
                detail.MaChiTietPhieuXuatKho = dgvDetailDeliveryBill.Rows[i].Cells[0].Value.ToString();
                detail.MaPhieuXuatKho = DeliveryBill.MaPhieuXuatKho;
                detail.MaSanPham = dgvDetailDeliveryBill.Rows[i].Cells[1].Value.ToString();
                detail.SoLuong = int.Parse(dgvDetailDeliveryBill.Rows[i].Cells[3].Value.ToString());
                detail.GhiChu = dgvDetailDeliveryBill.Rows[i].Cells[4].Value.ToString();
                list.Add(detail);
            }

            if (_bllDeliveryBill.AddDeliveryBillTran(DeliveryBill, list))
            {
                MessageBox.Show(Constants.MsgNotificationSuccessfuly);
                btnThoat.PerformClick();
            }
            else
            {
                MessageBox.Show(Constants.MsgExceptionError);
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
            for (int i = 0; i < dgvDetailDeliveryBill.Rows.Count - 1; i++)
            {
                if (dgvDetailDeliveryBill.Rows[i].Cells[0].Value == null ||
                    dgvDetailDeliveryBill.Rows[i].Cells[1].Value == null ||
                    dgvDetailDeliveryBill.Rows[i].Cells[3].Value == null)
                {
                    MessageBox.Show("Không được để trống mã chi tiết phiếu nhập kho, sản phẩm, số lượng");
                    return;
                }

                DtoProduct dto = _bllProduct.GetProductByID(dgvDetailDeliveryBill.Rows[i].Cells[1].Value.ToString());
                if (dto.SoLuong < int.Parse(dgvDetailDeliveryBill.Rows[i].Cells[3].Value.ToString()))
                {
                    MessageBox.Show(String.Format("Kho không có đủ sản phẩm {0}, kho con {1} san pham", dto.TenSanPham, dto.SoLuong));
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
            for (int i = 0; i < dgvDetailDeliveryBill.Rows.Count - 1; i++)
            {
                s += double.Parse(dgvDetailDeliveryBill.Rows[i].Cells[2].Value.ToString()) *
                     double.Parse(dgvDetailDeliveryBill.Rows[i].Cells[3].Value.ToString());
            }
            return s;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Feature function
        private string CreateNewDeliveryBillID()
        {
            return DateTime.Now.ToString("yy HH:mm:ss").
                Replace(" ", "").
                Replace("-", "").
                Replace(":", "");
        }
        #endregion
    }
}
