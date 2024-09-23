using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowDashCaps
{
    public partial class Form1 : Form
    {
        MenuItem miChecked;

        public Form1()
        {
            
            Menu = new MainMenu();
            Menu.MenuItems.Add("&Width");

            int[] aiWidth = { 1, 2, 5, 10, 15, 20, 25 };

            foreach (int iWidth in aiWidth)
                Menu.MenuItems[0].MenuItems.Add(iWidth.ToString(), 
                    new EventHandler(MenuWidthOnClick));

            miChecked = Menu.MenuItems[0].MenuItems[0];
            miChecked.Checked = true;
        }

        private void MenuWidthOnClick(object obj, EventArgs ea)
        {
            miChecked.Checked = false;
            miChecked = (MenuItem)obj;
            miChecked.Checked = true;
            Invalidate();
        }

        private void Show(Graphics g)
        {
            Pen pen = new Pen(Color.Black, Convert.ToInt32(miChecked.Text));
            Brush brush = new SolidBrush(Color.Black);

            pen.DashStyle = DashStyle.DashDotDot;

            float y = 100.0F;
            float x = 50.0F;

            foreach (DashCap dc in Enum.GetValues(typeof(DashCap)))
            {
                pen.DashCap = dc;
                pen.StartCap = pen.EndCap = (LineCap)(int)dc;

                g.DrawLine(pen, x, y, x + 400, y);
                g.DrawString(dc.ToString(), this.Font, brush, x + 420, y);

                y += 100.0F;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
            Show(g);
        }
    }
}
