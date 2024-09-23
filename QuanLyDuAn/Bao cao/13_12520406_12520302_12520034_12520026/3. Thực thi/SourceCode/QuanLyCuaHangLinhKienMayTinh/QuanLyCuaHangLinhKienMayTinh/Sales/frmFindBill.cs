using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLayer;


namespace QuanLyCuaHangLinhKienMayTinh
{
    public partial class frmFindBill : Form
    {
        public BLL.Sales.FindBillBLL findBillBLL = new BLL.Sales.FindBillBLL();
        public DataTable data;
        public int indexSearch=0;
        public frmFindBill()
        {
            InitializeComponent();
            data = findBillBLL.GetAllBill();
        }

        private void frmFillBill_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = data;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (pnlAdvanced.Visible == false)
            {
                pnlAdvanced.Visible = true;
                btnExpand.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            else
            {
                pnlAdvanced.Visible = false;
                btnExpand.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
        }

        private void btnFindnext_Click(object sender, EventArgs e)
        {
            dgvData.DataSource = CommonFunction.SortByColumn(data, 3, "13");
            indexSearch = CommonFunction.Search(dgvData, "mh", indexSearch);
        }
    }
}
