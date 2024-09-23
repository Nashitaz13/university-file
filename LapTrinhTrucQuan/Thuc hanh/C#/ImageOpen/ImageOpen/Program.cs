using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOpen
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ImageOpen i = new ImageOpen();
            Application.Run(i);
        }
    }
    class ImageOpen : Form
    {
        protected string strProgName;
        protected string strFileName;
        protected Image image;
        public ImageOpen()
        {
            Text = strProgName = "Image Open";
            ResizeRedraw = true;
            Menu = new MainMenu();
            Menu.MenuItems.Add("&File");
            Menu.MenuItems[0].MenuItems.Add(new MenuItem("&Open...",
            new EventHandler(MenuFileOpenOnClick),
            Shortcut.CtrlO));
        }
        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            if (image != null)
                grfx.DrawImage(image, 0, 0);
        }

        void MenuFileOpenOnClick(object obj, EventArgs ea)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;" +
            "*.jfif;*.png;*.tif;*.tiff;*.wmf;*.emf|" +
            "Windows Bitmap (*.bmp)|*.bmp|" +
            "All Files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = Image.FromFile(dlg.FileName);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, strProgName);
                    return;
                }
                strFileName = dlg.FileName;
                Text = strProgName + " - " + Path.GetFileName(strFileName);
                Invalidate();
            }
        }
    }
}