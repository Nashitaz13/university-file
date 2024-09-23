using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowDashStyles
{
    public partial class Form1 : Form
    {
        MenuItem miChecked;

        public Form1()
        {
            Text = "DashStyles";

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
            Pen pen = new Pen(Color.Black);
            pen.Width = Convert.ToInt32(miChecked.Text);
            Brush brush = new SolidBrush(Color.Black);

            float y = 50.0F;
            float x = 50.0F;

            foreach (DashStyle ds in Enum.GetValues(typeof(DashStyle)))
            {
                pen.DashStyle = ds;                

                g.DrawLine(pen, x, y, x + 400, y);
                g.DrawString(ds.ToString(), this.Font, brush, x + 420, y);

                y += 50.0F;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Show(g);
        }
    }
}
