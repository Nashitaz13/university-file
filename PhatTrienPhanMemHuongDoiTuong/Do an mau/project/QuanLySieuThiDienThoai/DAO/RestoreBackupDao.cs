using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.DAO
{
    class RestoreBackupDao
    {
        private DataProvider provider = new DataProvider();
        public RestoreBackupDao()
        {
            provider.connect();
        }
        public void Backup(string strBackup)
        {
            string backupCommand = "BACKUP DATABASE [QLSTDT] TO DISK='" + strBackup + "'";
            provider.executeNonQuery(backupCommand);
        }
        public void Restore(string strRestore)
        {
            string restoreCommand = "Use master Restore Database [QLSTDT] from disk='" + strRestore + "'";
            provider.executeNonQuery(restoreCommand);
        }
    }
}
