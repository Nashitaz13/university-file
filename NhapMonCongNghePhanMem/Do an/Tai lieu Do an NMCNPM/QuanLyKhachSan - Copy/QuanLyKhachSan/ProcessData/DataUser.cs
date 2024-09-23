using QuanLyKhachSan.ViewData;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.ProcessData
{
    /// <summary>
    /// xu ly du lieu nguoi dung
    /// </summary>
    public class DataUser
    {
        static SqlCeConnection connectionData;
        public static string userName;
        public DataUser(string userName_)
        {
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            userName = userName_;
        }

        public DataUser()
        {
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
        }
        /// <summary>
        /// ma hoa mat khau
        /// </summary>
        /// <param name="pass_">mat khau nguoi dung</param>
        /// <returns>mat khau da duoc ma hoa</returns>
        private static string encryptionPassWord(string pass_)
        {
            string newPass = "";
            char[] arrayPass = pass_.ToCharArray();
            for (int i = arrayPass.Length - 1; i >= 0; i--)
            {
                newPass += arrayPass[i];
            }
            return newPass;
        }

        /// <summary>
        /// kiem tra dang nhap
        /// </summary>
        /// <param name="user">ten nguoidung</param>
        /// <param name="pass_">mat khau</param>
        public Boolean testAccount(string pass_)
        {
            try
            {
                connectionData.Open();
            }
            catch
            { }
            string cmdText = "SELECT * FROM NGUOIDUNG WHERE TenNguoiDung = '" + userName + "'";
            using (SqlCeCommand cmdTestValue = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdTestValue.ExecuteReader();
                while (reader.Read())
                {
                    string pass = encryptionPassWord(pass_);
                    if (pass.Equals(reader["MatKhau"].ToString()))
                        return true;
                }
            }
            connectionData.Close();
            return false;
        }

        /// <summary>
        /// thay doi mat khau nguoi dung
        /// </summary>
        /// <param name="oldPass_">mat khau cu</param>
        /// <param name="newPass_">mat khau moi</param>
        public static void editPassWord(string oldPass_,string newPass_, string userName_)
        { 
            try
            {
                connectionData.Open();
            }
            catch{}
            if (oldPass_.Equals(getPassword(userName_)))
            {
                newPass_ = encryptionPassWord(newPass_);
                setPassWord(userName_, newPass_);
            }
            connectionData.Close();
        }

        /// <summary>
        /// lay mat khau theo ten nguoi dung
        /// </summary>
        /// <param name="userName_"></param>
        /// <returns></returns>
        public static string getPassword(string userName_)
        {
            string pass = "";
            string cmdText = "SELECT MatKhau FROM NGUOIDUNG WHERE TenNguoiDung = '" + userName_+ "'";
            using (SqlCeCommand cmdGetPass = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetPass.ExecuteReader();
                while (reader.Read())
                {
                    pass = reader["MatKhau"].ToString();
                }
            }
            pass = encryptionPassWord(pass);
            return pass;
        }

        /// <summary>
        /// cap nhat lai mat khau moi
        /// </summary>
        /// <param name="userName_">ten nguoi dung</param>
        /// <param name="newPass_">mat khau moi</param>
        public static void setPassWord(string userName_, string newPass_)
        {
            string cmdText = "UPDATE NGUOIDUNG SET MatKhau = '" +
                newPass_ + "' WHERE TenNguoiDung = '" + userName_ + "'";
            using (SqlCeCommand cmdSetPass = new SqlCeCommand(cmdText, connectionData))
            {
                cmdSetPass.ExecuteNonQuery();
            }
        }
    }
}
