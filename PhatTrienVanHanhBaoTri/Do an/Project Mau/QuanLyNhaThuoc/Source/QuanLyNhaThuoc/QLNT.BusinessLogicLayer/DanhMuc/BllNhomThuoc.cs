using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using QLNT.DataAccessLayer;
using QLNT.CommonLayer;
using QLNT.DataTransferObject;

namespace QLNT.BusinessLogicLayer
{
    public class BllNhomThuoc
    {

         DalNhomThuoc dalNhomThuoc;
        
        public BllNhomThuoc()
        {
            dalNhomThuoc = new DalNhomThuoc();
        }

        public DataTable DocDanhMucNhomThuoc()
        {
            return (dalNhomThuoc.DocDanhMucNhomThuoc());
        }

        public void LuuDanhMucNhomThuoc(DataTable dt)
        {
            try
            {
                // Tạo ra một TransactionScope để thực thi các lệnh trong một giao tác,
                // đảm bảo các lệnh này hoặc là được thực thi hết hoặc không lệnh nào được thực thi
                // như là một hành động không thể chia cắt
                using (TransactionScope scope = new TransactionScope())
                {
                    int SoMauTin = 0;
                    foreach (DataRow dRow in dt.Rows)
                    {
                        switch (dRow.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                DtoNhomThuoc dtoNhomThuoc = new DtoNhomThuoc()
                                {
                                    MaNhomThuoc = (dRow["MaNhomThuoc"] == DBNull.Value) ? 0 : (int)dRow["MaNhomThuoc"],
                                    TenNhomThuoc = dRow["TenNhomThuoc"].ToString()                                   
                                };
                                SoMauTin += dalNhomThuoc.LuuDanhMucNhomThuoc(dtoNhomThuoc);
                                break;

                            case DataRowState.Deleted:                               
                                int MaNhomThuoc = (int)dRow["MaNhomThuoc", DataRowVersion.Original];
                                dalNhomThuoc.XoaDanhMucNhomThuoc(MaNhomThuoc);
                                break;                          
                        }
                    }
                    
                    // Nếu các lệnh trong giao tác thực hiện thành công hết thì phương thức Complete sẽ được gọi
                    // để triển khai ghi nhận kết quả của các lệnh trong giao tác. Nếu phương thức này không được gọi thì
                    // kết quả của các lệnh trong gia tác bị hủy để trở về trạng thái trước khi thực hiện giao tác
                    dt.AcceptChanges();
                    scope.Complete();
                }
            }
            catch (ArgumentException ex)
            {                
                throw ex;
            }
            catch (TransactionAbortedException)
            {
                throw new ArgumentException(Constants.MsgExceptionLuuLoi);
            }
            catch (ApplicationException)
            {
                throw new ArgumentException(Constants.MsgExceptionLoiChung);
            }

        }
       

    }
}
