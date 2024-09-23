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
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.XtraPrinting.Native;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    public partial class frmWarehouse : Form
    {

        private BllWarehouse _bllWarehouse;
        public frmWarehouse()
        {
            InitializeComponent();

            _bllWarehouse = new BllWarehouse();
        }

        private async void frmWarehouse_Load(object sender, EventArgs e)
        {
            await FillListWarehouseDataTable(_bllWarehouse.GetListWarehouses());
        }

        private async Task FillListWarehouseDataTable(DataTable dt)
        {
            int index = 0;
            foreach (DataRow dataRow in dt.Rows)
            {
                dgWarehouse.Rows.Add(
                    dataRow[0].ToString(),
                    dataRow[1].ToString(),
                    CommonFunction.IntToBool(int.Parse(dataRow[2].ToString())),
                    dataRow[3].ToString()
                    );
                index++;
            }
        }

        private void Clear()
        {
            dgWarehouse.Rows.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddWarehouse frm = frmAddWarehouse.GetInstance();
            frm.Closing += Frm_Closing;
            frm.ShowDialog();
        }

        private async void Frm_Closing(object sender, CancelEventArgs e)
        {
            Clear();
            await FillListWarehouseDataTable(_bllWarehouse.GetListWarehouses());

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = !txtSearch.Text.IsEmpty();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Clear();
            await FillListWarehouseDataTable(_bllWarehouse.SearchWarehouse(txtSearch.Text.ToString()));
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void dgWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 )
            {
                frmAddWarehouse frm = new frmAddWarehouse(dgWarehouse.CurrentRow.Cells[0].Value.ToString());
                frm.Closing += Frm_Closing;
                frm.ShowDialog();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            await FillListWarehouseDataTable(_bllWarehouse.GetListWarehouses());
        }
    }
}
