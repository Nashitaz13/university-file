using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Warehouse;
using DTO.Warehouse;

namespace BLL.Warehouse
{
    public class BllProduct
    {
        private DalProduct _dalProduct;

        public BllProduct()
        {
            _dalProduct = new DalProduct();
        }

        public DataTable GetListProducts()
        {
            return _dalProduct.GetListProducts();
            //DataTable dt = _dalProduct.GetListProducts();
            //List<DtoProduct> products = new List<DtoProduct>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    DtoProduct pro = new DtoProduct(
            //        row[0].ToString(),
            //        row[1].ToString(),
            //        row[2].ToString(),
            //        row[3].ToString(),
            //        int.Parse(row[4].ToString()),
            //        double.Parse(row[5].ToString()),
            //        double.Parse(row[6].ToString()),
            //        int.Parse(row[7].ToString()),
            //        row[8].ToString(),
            //        row[9].ToString(),
            //        row[10].ToString());
            //    products.Add(pro);
            //}
            //return products;
        }

        public DtoProduct GetProductByID(string id)
        {
            return _dalProduct.GetProductByID(id);
        }

        public bool AddProduct(DtoProduct data)
        {
            try
            {
                return _dalProduct.AddProduct(data) == 1 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditProduct(DtoProduct data)
        {
            try
            {
                return _dalProduct.EditProduct(data) == 1 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct(string id)
        {
            try
            {
                return _dalProduct.DeleteProduct(id) == 1 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
