using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Delivery;
using QuanLyCuaHangLinhKienMayTinh.Delivery;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    public partial class frmDeliveryBill : Form
    {
        private BllDeliveryBill _bllDeliveryBill;
        private BllDeliveryBillDetail _bllDeliveryBillDetail;

        public frmDeliveryBill()
        {
            InitializeComponent();

            _bllDeliveryBill = new BllDeliveryBill();
            _bllDeliveryBillDetail = new BllDeliveryBillDetail();

            Load += FrmDeliveryBill_Load;
        }

        private void FrmDeliveryBill_Load(object sender, EventArgs e)
        {
            LoadDgvDeliveryBillList();
        }

        private void LoadDgvDeliveryBillList()
        {
            dgvDeliveryBill.DataSource = _bllDeliveryBill.GetDeliveryBillList();
        }

        private void dgvWarehouseBill_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string id = dgvDeliveryBill.CurrentRow.Cells[0].Value.ToString();
                dgvDetailDeliveryBill.DataSource = _bllDeliveryBillDetail.GetDeliveryBillDetailWithDeliveryBillID(id);
                txtTotal.Text = _bllDeliveryBillDetail.SumTotal(id).ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAddDeliveryBill frm = new frmAddDeliveryBill();
            frm.Closed += Frm_Closed;
            frm.ShowDialog();
        }

        private void Frm_Closed(object sender, EventArgs e)
        {
            btnLamTuoi.PerformClick();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnLamTuoi_Click(object sender, EventArgs e)
        {
            LoadDgvDeliveryBillList();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
