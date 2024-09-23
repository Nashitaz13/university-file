using System.Windows.Forms;

namespace EasyPOS.Utils
{
    public static class Notification
    {
        public static void Warning(string message)
        {
            MessageBox.Show(message, "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message, "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Success(string message)
        {
            MessageBox.Show(message, "THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Answers(string message)
        {
            return MessageBox.Show(message, "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
