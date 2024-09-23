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
using DevComponents.DotNetBar.Controls;
using DevExpress.XtraPrinting.Native;
using DTO.Warehouses;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    public partial class frmAddWarehouse : Form
    {
        private static frmAddWarehouse _instance;

        private BllWarehouse _bllWarehouse;

        private bool _isEditing = false;

        public static frmAddWarehouse GetInstance()
        {
            if (_instance == null)
            {
                _instance = new frmAddWarehouse();
            }
            return _instance;
        }

        public frmAddWarehouse()
        {
            InitializeComponent();

            _bllWarehouse = new BllWarehouse();
        }

        public frmAddWarehouse(string warehouseID)
        {
            InitializeComponent();

            _bllWarehouse = new BllWarehouse();

            FillDetails(_bllWarehouse.SearchWarehouse(warehouseID));

            EditGui();
        }

        private void EditGui()
        {
            lblTitle.Text = "Sửa Kho";
            btnAdd.Text = "Lưu";
            this.Text = "Sửa Kho";
            txtWarehouseID.Enabled = false;
            _isEditing = true;
        }

        private void FillDetails(DataTable dt)
        {
            txtWarehouseID.Text = dt.Rows[0][0].ToString();
            txtWarehouseName.Text = dt.Rows[0][1].ToString();
            txtNote.Text = dt.Rows[0][3].ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DtoWarehouse w = new DtoWarehouse();
            w.MaKho = txtWarehouseID.Text.ToString();
            w.TenKho = txtWarehouseName.Text.ToString();
            w.GhiChu = txtNote.Text.ToString();

            if (_isEditing)
            {
                if (_bllWarehouse.EditWarehouse(w))
                {
                    MessageBox.Show(Constants.MsgNotificationEditSuccessfuly);
                }
                else
                {
                    MessageBox.Show(Constants.MsgAlreadyExist);
                }
                btnCancel.PerformClick();
                return;
            }
            if (_bllWarehouse.AddWarehouse(w))
            {
                MessageBox.Show(Constants.MsgNotificationSuccessfuly);
            }
            else
            {
                MessageBox.Show(Constants.MsgAlreadyExist);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = isValidate();
        }

        private bool isValidate()
        {
            if (txtWarehouseID.Text.IsEmpty() ||
                txtWarehouseName.Text.IsEmpty() && txtWarehouseName.Text.Length >= 10
                )
            {
                return false;
            }
            return true;
        }

        private void txt_Click(object sender, EventArgs e)
        {
            ((sender) as TextBoxX).SelectAll();
        }
    }
}
