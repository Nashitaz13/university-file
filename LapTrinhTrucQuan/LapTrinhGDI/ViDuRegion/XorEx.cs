using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViDuRegion
{
    public partial class XorEx : Form
    {
        public XorEx()
        {
            InitializeComponent();
        }

        private void XorEx_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect1 = new Rectangle(10, 10, 120, 140);
            Rectangle rect2 = new Rectangle(80, 50, 160, 200);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            rgn1.Xor(rgn2);
            g.FillRegion(Brushes.Blue, rgn1);
            g.Dispose();
        }
    }
}
