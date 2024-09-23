using QuanLySieuThiDienThoai.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.BLL
{
    class RestoreBackupBll
    {
        private static RestoreBackupDao data = new RestoreBackupDao();
        public static void DoBackup(string strBackup)
        {
            data.Backup(strBackup);
        }
        public static void DoRestore(string strRestore)
        {
            data.Restore(strRestore);
        }
    }
}
