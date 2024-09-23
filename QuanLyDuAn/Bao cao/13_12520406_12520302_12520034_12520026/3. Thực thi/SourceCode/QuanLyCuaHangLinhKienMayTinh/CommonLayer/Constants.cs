using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class Constants
    {
        public static string ConnectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static string MsgExceptionSql = "Lỗi kết nối";

        public static string MsgExceptionError = "Lỗi hệ thống";

        public static string MsgNotificationSuccessfuly = "Thêm thành công!";

        public static string MsgNotificationEditSuccessfuly = "Sửa thành công!";

        public static string MsgAlreadyExist = "Dữ liệu đã tồn tại hoặc lỗi dữ liệu đầu vào.";
        public static string MsgNotificationDeletetSuccessfuly  = "Xóa thành công!";
    }
}
