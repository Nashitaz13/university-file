using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CheckAndRadioCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckAndRadioCheck a = new CheckAndRadioCheck();
            Application.Run(a);
        }
    }
    class CheckAndRadioCheck : Form
    {
        MenuItem miColor;
        MenuItem miFill;

        public CheckAndRadioCheck()
        {
            Text = "Check and Radio Check";
            ResizeRedraw = true;
            string[] astrColor = { "Black", "Blue", "Green", "Cyan", "Red", "Magenta", "Yellow", "White" };
            MenuItem[] ami = new MenuItem[astrColor.Length + 2];
            EventHandler ehColor = new EventHandler(Click);
            for (int i = 0; i < astrColor.Length; i++)
            {
                ami[i] = new MenuItem(astrColor[i], ehColor);
                ami[i].RadioCheck = true;
            }
            miColor = ami[0];
            miColor.Checked = true;
            ami[astrColor.Length] = new MenuItem("-");
            miFill = new MenuItem("&Fill", new EventHandler(FillClick));
            ami[astrColor.Length + 1] = miFill;
            MenuItem mi = new MenuItem("&Fomart", ami);
            Menu = new MainMenu(new MenuItem[] { mi });
        }

        void Click(object obj, EventArgs e)
        {
            miColor.Checked = false;
            miColor = (MenuItem)obj;
            miColor.Checked = true;
            Invalidate();
        }
        void FillClick(object obj, EventArgs e)
        {
            MenuItem mi = (MenuItem)obj;
            mi.Checked = !mi.Checked;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            if (miFill.Checked)
            {
                Brush brush = new SolidBrush(Color.FromName(miColor.Text));
                g.FillEllipse(brush, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
            else
            {
                Pen pen = new Pen(Color.FromName(miColor.Text));
                g.DrawEllipse(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            }
        }
    }

}
