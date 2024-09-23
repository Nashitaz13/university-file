using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS
{
    public class BienToanCuc
    {
        public static string TenNguoiDung;
        public static int IDNguoiDung;
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Frm_DangNhap frmDangNhap = new Frm_DangNhap();
            if(frmDangNhap.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Frm_Chinh());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
