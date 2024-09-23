using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Sales;
using CommonLayer;
using BLL.Warehouse;
namespace QuanLyCuaHangLinhKienMayTinh.Sales
{
    public partial class frmAddBill : Form
    {
        AddBillBLL bll= new AddBillBLL();
        string productId= "";
        string productName="";
        // tổng giấ trị hóa đơn
        int sumMoney = 0;
        public frmAddBill()
        {
            InitializeComponent();
        }
        public void frmAddBill_Load(object sender, EventArgs e)
        
        {
            dgvCustomer.DataSource = bll.GetAllCustomer();
            dgvProduct.DataSource = bll.GetAllProduct();
            cbProductType.Items.Add("Tất cả");
            DataTable dt = bll.GetCategoryList();
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                cbProductType.Items.Add(dt.Rows[i][0]);
            }
            cbProductType.SelectedIndex = 0;
            // load thue suat
            txtTaxPercent.Text = bll.GetTax().ToString()+"%";


        }

        private void txtSearchCustomerName_TextChanged(object sender, EventArgs e)
        {
        
            if (txtSearchCustomerName.Text == "")
            {
                dgvCustomer.DataSource = bll.GetAllCustomer();
            }
            else
            dgvCustomer.DataSource = bll.SearchCustomer(txtSearchCustomerName.Text);
        }
        //Khi nhấn tên khách hàng, hệ thống load dữ liệu lên panel bên phải
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewCell cellMaKH=dgvCustomer[0,e.RowIndex];
            string cusName = dgvCustomer[1, e.RowIndex].Value.ToString();
            // lấy dl kh
            DataTable cusDetail = bll.GetCustomerDetail(cellMaKH.Value.ToString());
            txtCustomerName.Text = cusName;
            txtIdCardNumber.Text=cusDetail.Rows[0][0].ToString();
            txtPhoneNumber.Text= cusDetail.Rows[0][1].ToString();
            txtAddress.Text= cusDetail.Rows[0][2].ToString();
            txtCustomerId.Text = cellMaKH.Value.ToString();

        }
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex==-1) return;
            this.productId = dgvProduct[0,e.RowIndex].Value.ToString();
            this.productName = dgvProduct[1, e.RowIndex].Value.ToString();
            string price=bll.GetProductPrice(productId);
            txtPrice.Text = price.Substring(0, price.IndexOf("."));
            
           
        }
        // Nhấn nút ghi
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (productId == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào!");
                return;
            }
            if (nUdAmount.Value == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng");
                return;
            }
            int productPrice = int.Parse(txtPrice.Text);
            string[] row = new string[] { productId, productName, nUdAmount.Value.ToString(), productPrice.ToString(), (productPrice * nUdAmount.Value).ToString() };
            dgvProductList.Rows.Add(row);
            sumMoney += productPrice * (int)nUdAmount.Value;
            txtTaxMoney.Text = (sumMoney * 0.1).ToString();
            txtSumMoney.Text = sumMoney.ToString();
        }

        private void cbProductType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /**/
        }

        private void cbProductType_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("commit now!");
            //th1: không nhập tên sp, chọn loại là tất cả
            if (txtSearchProductName.Text == "" && cbProductType.Text == "Tất cả")
            {
                dgvProduct.DataSource = bll.GetAllProduct();
            }
            // TH2: không nhập tên sp, có chọn tên loại 
            else if (txtSearchProductName.Text == "")
            {
                dgvProduct.DataSource = bll.GetProduct(cbProductType.Text);
            }
            // TH3: có nhập tên sản phẩm, chọn loại là tất cả
            else if (cbProductType.Text == "Tất cả")
            {
                dgvProduct.DataSource = bll.GetProductfromName(txtSearchProductName.Text);
            }
            // TH4: có nhập tên sản phẩm chọn loại sp xác định
            else
            {
                dgvProduct.DataSource = bll.GetProduct(cbProductType.Text, txtSearchProductName.Text);
            }
        }

        private void txtSearchProductName_TextChanged(object sender, EventArgs e)
        {

            // TH3: có nhập tên sản phẩm, chọn loại là tất cả
            if (cbProductType.Text == "Tất cả")
            {
                dgvProduct.DataSource = bll.GetProductfromName(txtSearchProductName.Text);
            }
            // TH4: có nhập tên sản phẩm chọn loại sp xác định
            else
            {
                dgvProduct.DataSource = bll.GetProduct(cbProductType.Text, txtSearchProductName.Text);
            }
        }
        // Thêm hóa đơn
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCustomerId.Text==""){
                txtCustomerId.Text=bll.NextId("KH",bll.GetLastCustomer());
            }
            List<CommonFunction.BillProduct> proList = new List<CommonFunction.BillProduct>();
            foreach(DataGridViewRow row in dgvProductList.Rows)
            {
                CommonFunction.BillProduct bp = new CommonFunction.BillProduct();
                bp.proId= row.Cells[0].Value.ToString();
                bp.num= int.Parse(row.Cells[2].Value.ToString());
                proList.Add(bp);
            }
            //chú ý !!!!!!!!!!!!!!!!! chổ này chưa lấy được mã nhân viên
            bll.SaveBill(txtCustomerId.Text, "NV1", int.Parse(txtSumMoney.Text), proList);
            MessageBox.Show("Thành Công");
        }


        

    }
}
