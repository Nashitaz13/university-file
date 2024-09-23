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
using DevExpress.Data.PLinq.Helpers;
using DevExpress.XtraPrinting.Native;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouse
{
    public partial class frmAddProduct : Form
    {
        private static frmAddProduct _instance;
        


        public static frmAddProduct GetInstance()
        {
            if (_instance == null)
            {
                _instance = new frmAddProduct();
            }
            return _instance;
        }

        private BllProduct _bllProduct;
        private BllDistributor _bllDistributor;
        private BllWarehouse _bllWarehouse;

        public frmAddProduct()
        {
            InitializeComponent();

            _bllProduct = new BllProduct();
            Load += FrmAddProduct_Load;
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = IsValidate();
        }

        private bool IsValidate()
        {
            if (txtProductID.Text.IsEmpty() ||
                txtProductName.Text.IsEmpty() ||
                txtUnitImport.Text.IsEmpty() ||
                txtUnit.Text.IsEmpty() ||
                txtPrice.Text.IsEmpty())
            {
                return false;
            }
            return true;
        }
    }
}
