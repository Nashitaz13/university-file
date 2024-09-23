using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Warehouses;
using CommonLayer;
using DTO.Warehouses;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouses
{
    public partial class GuiAddWarehouse : Form
    {
        private static GuiAddWarehouse _instance;

        private BalWarehouses _balWarehouses;

        private bool _isAdd = true;

        public static GuiAddWarehouse GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GuiAddWarehouse();
            }
            return _instance;
        }
        public GuiAddWarehouse()
        {
            InitializeComponent();

            _balWarehouses = new BalWarehouses();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DtoWarehouse w = new DtoWarehouse();
            w.MaKho = txtWarehouseID.Text.ToString();
            w.TenKho = txtWarehouseName.Text.ToString();
            w.TrangThai = chkState.Checked;
            w.NgayTao = DateTime.Now;
            w.GhiChu = txtNote.Text.ToString();
            if (_balWarehouses.AddWarehouse(w))
            {
                MessageBox.Show(Constants.MsgNotification);
            }
            else
            {
                MessageBox.Show(Constants.MsgExceptionAlready);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckSave()
        {
            if (txtWarehouseID.Text != "" ||
                txtWarehouseName.Text != "" ||
                txtNote.Text != "")
            {
                return false;
            }
            return true;
        }

        private bool Validate()
        {
            if (txtWarehouseID.Text != "" &&
                txtWarehouseName.Text != "" &&
                txtNote.Text != "")
            {
                return true;
            }
            return false;
        }
       
        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (Validate())
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }
    }
}
