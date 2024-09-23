using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Warehouse;
using DTO.Sales;
using DAL.Sales;
using System.Data;
using CommonLayer;
using BLL.Warehouse;
//chức năng add bill làm từ chủ nhật ngày 14/12
namespace BLL.Sales
{

    public class AddBillBLL
    {
        
        BillDAL dal= new BillDAL();
        DataTable customerList;
        public AddBillBLL()
        {
            customerList = dal.GetAllCustomer();
        }
        public DataTable GetAllCustomer()
        {
            return dal.GetAllCustomer();
        }
        public DataTable GetAllProduct()
        {
            return dal.GetAllProduct();
        }
        public DataTable SearchProduct (string productName, string category)
        {
            return dal.GetProduct (productName,category);
        }
        public DataTable SearchCustomer(string customerName)
        {
            return dal.GetCustomer(customerName);

        }
        public void SaveBill(string cusId, string staffId, int sum, List<CommonFunction.BillProduct>proList)
        {
           string now= DateTime.Now.ToString("MM-dd-yyyy");
            string lastBillId = dal.GetLastBillId().Rows.Count==0?"":dal.GetLastBillId().Rows[0][0].ToString();
            dal.AddBill(this.NextId("HD",lastBillId),now, cusId, staffId, sum, proList);
        }
        public DataTable GetCustomerDetail(string cusId)
        {
            return dal.GetCustomerDetail(cusId);
        }
        public String GetProductPrice(string productId)
        {
            return dal.GetProductPrice(productId).Rows[0][0].ToString();
        }
        public string NextId(string reStr, string id)
        {
            if (id == "")
            {
                return reStr+"1";
            }
            int len = id.Length;
            string str = id.Substring(2, len - 2);
            int nextNum = int.Parse(str) + 1;
            string num = nextNum.ToString();
            return reStr + num;
        }
        public DataTable GetCategoryList()
        {
            return dal.GetCategoryList();
        }
        public DataTable GetProduct(string category)
        {
            return dal.GetProduct(category);
        }
        public DataTable GetProduct(string category, string productName)
        {
            return dal.GetProduct(productName, category);
        }
        public DataTable GetProductfromName(string productName)
        {
            return dal.GetProductfromName(productName);
        }
        // Lấy thuế suất
        public int GetTax()
        {
            return int.Parse(dal.GetRule("Thuế suất").Rows[0][0].ToString());
        }
        public string GetLastCustomer()
        {
            return dal.GetLastCustomerId().Rows.Count==0?"":dal.GetLastCustomerId().Rows[0][0].ToString();
        }
    }
}
